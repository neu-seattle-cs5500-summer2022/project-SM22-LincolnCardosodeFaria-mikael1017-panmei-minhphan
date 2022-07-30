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
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");

  const instance = axios.create({
    baseURL: "https://gymmanagement.cropfix.ca",
  });

  const goAdminPage = (id) => {
    navigate(`/admin/${id}`);
  };
  const goClientPage = (id) => {
    navigate(`/client/${id}`);
  };
  const requestLogin = (e) => {
    e.preventDefault();

    instance
      .post("/Authentication/Login", {
        username: username,
        password: password,
      })
      .then(function (response) {
        console.log(response);
        setUsername("");
        setPassword("");

        console.log("LOGIN Response: ", response.data.authentication);
        if (response.data.authentication) {
          goClientPage(24);
        } else {
          alert("Wrong credential");
        }
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
              type="text"
              placeholder="Username"
              required
              value={username}
              onChange={(e) => setUsername(e.target.value)}
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
