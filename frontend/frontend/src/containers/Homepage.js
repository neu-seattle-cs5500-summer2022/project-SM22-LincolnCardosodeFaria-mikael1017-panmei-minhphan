import React from "react";
import { Navigate, useNavigate } from "react-router-dom";

function Homepage() {
  const navigate = useNavigate();
  const goSignUp = () => {
    navigate("/signup");
  };
  return (
    <div>
      <button variant="contained" onClick={goSignUp}>
        SignUp
      </button>
    </div>
  );
}

export default Homepage;
