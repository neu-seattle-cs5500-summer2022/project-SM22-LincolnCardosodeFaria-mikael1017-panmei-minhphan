import React from "react";
import { Navigate, useNavigate } from "react-router-dom";

function Homepage() {
  const navigate = useNavigate();
  const goSignUp = () => {
    navigate("/signup");
  };

  const goLogin = () => {
    navigate("/login");
  };
  return (
    <div>
      <button variant="contained" onClick={goSignUp}>
        SignUp
      </button>
      <button variant="contained" onClick={goLogin}>
        Login
      </button>
    </div>
  );
}

export default Homepage;
