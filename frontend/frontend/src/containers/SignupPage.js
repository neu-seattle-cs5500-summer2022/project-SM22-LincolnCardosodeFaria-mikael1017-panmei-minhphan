import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import "./HomePage";
import { Button, Form } from "react-bootstrap";
import styled from "styled-components";
import MyNavbar from "../components/Navbar";

function SignupPage() {
  // create state variables for each input
  const navigate = useNavigate();
  const [username, setUsername] = useState("");
  const [fullName, setFullName] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [dateOfBirth, setDateOfBirth] = useState("");
  const [address, setAddress] = useState("");
  const [phone, setPhone] = useState("");

  const createUser = (e) => {
    e.preventDefault();
    // TODO: post request here
  };

  const goHome = () => {
    navigate("/");
  };

  const FormContainer = styled.div`
    margin: auto;
    width: 25%;
  `;

  return (
    <div>
      <MyNavbar />
      <h1> Sign Up Page</h1>
      <FormContainer>
        <Form onSubmit={createUser}>
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
          <Form.Group className="mb-3">
            {/* <Form.Label>Email</Form.Label> */}
            <Form.Control
              type="email"
              placeholder="Email"
              required
              value={email}
              onChange={(e) => setEmail(e.target.value)}
            />
          </Form.Group>

          <Form.Group className="mb-3">
            {/* <Form.Label>Full Name</Form.Label> */}
            <Form.Control
              type="text"
              placeholder="Full Name"
              required
              value={fullName}
              onChange={(e) => setFullName(e.target.value)}
            />
          </Form.Group>

          <Form.Group className="mb-3">
            {/* <Form.Label>Date of Birth</Form.Label> */}
            <Form.Control
              type=""
              placeholder="Date of Birth"
              required
              value={dateOfBirth}
              onChange={(e) => setDateOfBirth(e.target.value)}
            />
          </Form.Group>
          <Form.Group className="mb-3">
            {/* <Form.Label>Address</Form.Label> */}
            <Form.Control
              type=""
              placeholder="Address"
              required
              value={address}
              onChange={(e) => setAddress(e.target.value)}
            />
          </Form.Group>
          <Form.Group className="mb-3">
            {/* <Form.Label>Phone</Form.Label> */}
            <Form.Control
              type="number"
              placeholder="Phone"
              required
              value={phone}
              onChange={(e) => setPhone(e.target.value)}
            />
          </Form.Group>

          <div>
            <Button type="submit" variant="primary">
              Signup
            </Button>
          </div>
        </Form>
      </FormContainer>
    </div>
  );
}

export default SignupPage;
