import React from "react";
import { Nav, Container } from "react-bootstrap";
import Navbar from "react-bootstrap/Navbar";

export default function MyNavbar() {
  return (
    <Navbar bg="dark" variant="dark">
      <Container>
        <Navbar.Brand href="/">Home</Navbar.Brand>
        <Nav className="ml-auto">
          <Nav.Link href="/login">Sign in</Nav.Link>
        </Nav>
      </Container>
    </Navbar>
  );
}
