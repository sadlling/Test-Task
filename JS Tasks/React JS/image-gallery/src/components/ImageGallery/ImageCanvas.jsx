import React, { useState, useEffect, useCallback } from "react";

function ImageCanvas({ imageUrl }) {

  const [imageData, setImageData] = useState(null);

  const loadImageData = useCallback(() => {
    
    const img = new Image();
    img.src = `http://188.166.203.164${imageUrl}`;
    setImageData(img.src);
    
  }, [imageUrl]);

  useEffect(() => {
    loadImageData();
  }, [loadImageData]);

  return <img src={imageData} alt="info" width="200" height="200" />;
}

export default ImageCanvas;
