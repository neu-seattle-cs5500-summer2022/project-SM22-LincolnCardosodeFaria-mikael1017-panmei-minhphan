import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import { Button, Form } from "react-bootstrap";
import axios from "axios";
import styled from "styled-components";
import MyNavbar from "../components/Navbar";

const FormContainer = styled.div`
  margin: auto;
  width: 25%;
`;

function LoginPage() {
  const navigate = useNavigate();
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const requestLogin = (e) => {
    e.preventDefault();
    // TODO: post request here
    axios
      .post("/user/login", {
        email: email,
        password: password,
      })
      .then(function (response) {
        console.log(response);
        setEmail("");
        setPassword("");
        //TODO: Should return userId
      })
      .catch(function (error) {
        console.log(error);
      });
  };

  const goHome = () => {
    navigate("/");
  };

  return (
    <div>
      <MyNavbar />
      <h1> Login Page</h1>
      <FormContainer>
        <Form onSubmit={requestLogin}>
          <Form.Group className="mb-3">
            {/* <Form.Label>Username</Form.Label> */}
            <Form.Control
              type="email"
              placeholder="Email"
              required
              value={email}
              onChange={(e) => setEmail(e.target.value)}
            />
          </Form.Group>
          <Form.Group className="mb-3">
            {/* <Form.Label>Password</Form.Label> */}
            <Form.Control
              type="password"
              placeholder="Password"
              required
              value={password}
              onChange={(e) => setPassword(e.target.value)}
            />
          </Form.Group>

          <div>
            <Button type="submit" variant="primary">
              Login
            </Button>
          </div>
        </Form>
      </FormContainer>
    </div>
  );
}

export default LoginPage;
