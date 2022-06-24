import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import { Button } from "react-bootstrap";

function LoginPage() {
  const navigate = useNavigate();
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const requestLogin = (e) => {
    e.preventDefault();
    // TODO: post request here
  };

  const goHome = () => {
    navigate("/");
  };
  return (
    <div>
      <h1> Login Page</h1>
      <form className="form" onSubmit={requestLogin}>
        {}
        <div> Email </div>
        <input
          label="Email"
          variant="filled"
          type="email"
          required
          value={email}
          onChange={(e) => setEmail(e.target.value)}
        />
        <div> Password </div>
        <input
          label="Password"
          variant="filled"
          required
          value={password}
          onChange={(e) => setPassword(e.target.value)}
        />

        <div>
          <Button type="submit" variant="primary">
            Login
          </Button>
        </div>
      </form>

      <div>
        <Button variant="primary" onClick={goHome}>
          back to Home
        </Button>
      </div>
    </div>
  );
}

export default LoginPage;
