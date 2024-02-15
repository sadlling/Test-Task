async function fetchData(url) {
  const response = await fetch(url);
  return response.json();
}

async function renderImageToCanvas(imageUrl) {
  const response = await fetch(imageUrl);
  const blob = await response.blob();
  const image = new Image();
  image.src = URL.createObjectURL(blob);
  image.style.height = "300px";
  return image;
}

async function createCard(imageUrl) {
  const colDiv = document.createElement("div");
  colDiv.classList.add("col");

  const cardDiv = document.createElement("div");
  cardDiv.classList.add("card", "shadow-sm");

  const img = await renderImageToCanvas(imageUrl);

  const cardBodyDiv = document.createElement("div");
  cardBodyDiv.classList.add("card-body");

  const downloadButton = document.createElement("button");
  downloadButton.type = "button";
  downloadButton.id = "saveImageButton";
  downloadButton.dataset.imageUrl = img.src;
  downloadButton.classList.add("btn", "btn-sm", "btn-outline-secondary");
  downloadButton.innerText = "Download";

  cardBodyDiv.appendChild(downloadButton);
  cardDiv.appendChild(img);
  cardDiv.appendChild(cardBodyDiv);
  colDiv.appendChild(cardDiv);
  return colDiv;
}

async function acceptTermsOfUse(jsonData) {
  let termsOfUse = jsonData.terms_of_use.paragraphs.sort(
    (a, b) => a.index - b.index
  );
  let termsOfUseString = termsOfUse
    .map((paragraph) => {
      return paragraph.content
        ? `<b>${paragraph.index}.${paragraph.title}:</b> ${paragraph.content} <br>`
        : `<b>${paragraph.index}.${paragraph.title}:</b> ${paragraph.text} <br>`;
    })
    .join("\n");
  return new Promise((resolve) => {
    Swal.fire({
      icon: "info",
      title: "Terms of use",
      width: 900,
      html: `<div>${termsOfUseString}</div>`,
      confirmButtonColor: "#228B22",
      confirmButtonText: "Accept!",
    }).then((result) => {
      if (result.isConfirmed) {
        document.getElementById("imageGalleryContainer").style.display =
          "block";
        resolve(true);
      } else if (result.isDismissed) {
        Swal.fire(
          "Terms of use not accepted. To continue, refresh the page and accept terms of use!",
          "",
          "info"
        );
        resolve(false);
      }
    });
  });
}

function saveImage(imageUrl) {
  const a = document.createElement("a");
  a.href = imageUrl;
  a.download = "image.png";
  a.click();
}

async function main() {
  const jsonData = await fetchData("http://188.166.203.164/static/test.json");

  if (await acceptTermsOfUse(jsonData)) {
    let imageUrls = jsonData.images.map(
      (image) => `http://188.166.203.164${image.image_url}`
    );
    imageUrls.forEach(async (imageUrl) => {
      const cardWithImage = await createCard(imageUrl);
      document.getElementById("imageContainer").appendChild(cardWithImage);

      const saveImageButton = cardWithImage.querySelector("#saveImageButton");
      saveImageButton.addEventListener("click", (event) => {
        const currentImageUrl = event.target.dataset.imageUrl;
        saveImage(currentImageUrl);
      });
    });
  }
}

main();
