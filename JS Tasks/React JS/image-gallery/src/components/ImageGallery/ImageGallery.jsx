import React, { useState, useEffect } from "react";
import TermsOfUse from "../TermsOfUse/TermsOfUse";
import ImageCanvas from "./ImageCanvas";
import SaveButton from "./SaveButton";
import "./ImageGallery.css";

function ImageGallery() {
  const [termsAccepted, setTermsAccepted] = useState(false);
  const [images, setImages] = useState([]);
  const [termsData, setTermsData] = useState([]);

  const formattingTermsOfUse = (termsOfUse) => {
    return termsOfUse.terms_of_use.paragraphs
      .sort((a, b) => a.index - b.index)
      .map((paragraph, index) => {
        return (
          <div key={index}>
            <h3>{paragraph.title}</h3>
            <p>{paragraph.content ? paragraph.content : paragraph.text}</p>
          </div>
        );
      });
  };

  useEffect(() => {
    fetch("http://188.166.203.164/static/test.json", {
      headers: {
        Origin: "http://localhost:3000",
      },
    })
      .then((response) => response.json())
      .then((data) => {
        setImages(data.images);
        setTermsData(formattingTermsOfUse(data));
      })
      .catch((error) => console.error("error:", error));
  }, [termsAccepted]);

  const acceptTermsOfUse = () => {
    setTermsAccepted(true);
  };

  const saveImage = async (imageUrl) => {
    try {
      const response = await fetch(`http://188.166.203.164${imageUrl}`);
      const blob = await response.blob();
      const objectUrl = URL.createObjectURL(blob);

      const a = document.createElement("a");
      a.href = objectUrl;
      a.download = "image.png";
      a.click();

      URL.revokeObjectURL(objectUrl);
    } catch (error) {
      console.error("Error downloading image:", error);
    }
  };

  return (
    <div className="image-gallery">
      {!termsAccepted && (
        <TermsOfUse onAccept={acceptTermsOfUse} terms={termsData} />
      )}
      {termsAccepted && (
        <div>
          <h1>Image Gallery</h1>
          <div className="images-container">
            {images.map((image, index) => (
              <div key={index} className="item">
                <ImageCanvas imageUrl={image.image_url} />
                <SaveButton onClick={() => saveImage(image.image_url)} />
              </div>
            ))}
          </div>
        </div>
      )}
    </div>
  );
}

export default ImageGallery;
