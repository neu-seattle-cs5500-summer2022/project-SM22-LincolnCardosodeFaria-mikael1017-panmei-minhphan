import React from "react";
import { Navigate, useNavigate } from "react-router-dom";
import "bootstrap/dist/css/bootstrap.min.css";
import { Button } from "react-bootstrap";

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
      <Button variant="primary" onClick={goSignUp}>
        SignUp
      </Button>
      <Button variant="primary" onClick={goLogin}>
        Login
      </Button>
    </div>
  );
}

export default Homepage;
