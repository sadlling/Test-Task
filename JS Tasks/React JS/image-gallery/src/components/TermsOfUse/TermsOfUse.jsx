import React from "react";
import "./TermsOfUse.css";

const TermsOfUse = ({ onAccept, terms }) => {
  return (
    <div className="terms-container">
      <h1>Terms of Use</h1>
      <div>{terms}</div>
      <button onClick={onAccept}>Accept</button>
    </div>
  );
};

export default TermsOfUse;
