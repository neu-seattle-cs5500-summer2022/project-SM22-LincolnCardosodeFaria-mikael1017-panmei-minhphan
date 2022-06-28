import React from "react";
import { Navigate, useNavigate } from "react-router-dom";
import "bootstrap/dist/css/bootstrap.min.css";
import { Button, Card } from "react-bootstrap";
import cardImage from "../homepage_card.jpeg";
import MyNavbar from "../components/Navbar.js";

export default function Homepage() {
  const navigate = useNavigate();
  const goSignUp = () => {
    navigate("/signup");
  };

  return (
    <div>
      <MyNavbar></MyNavbar>
      <header className="App-header">
        <Card className="m-5 border-0" style={{ color: "#000" }}>
          <Card.Img src={cardImage} />
          <Card.Body>
            <Card.Title>Gym management app</Card.Title>
            <Card.Text>This is an description of an app</Card.Text>
            <Button variant="primary" onClick={goSignUp}>
              SignUp
            </Button>
          </Card.Body>
        </Card>
      </header>
    </div>
  );
}
