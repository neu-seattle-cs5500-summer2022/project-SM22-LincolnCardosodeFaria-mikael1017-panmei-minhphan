import React, { useState } from "react";
import { useNavigate } from "react-router-dom";

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
          <button type="submit" variant="contained" color="primary">
            Login
          </button>
        </div>
      </form>

      <div>
        <button variant="contained" color="secondary" onClick={goHome}>
          back to Home
        </button>
      </div>
    </div>
  );
}

export default LoginPage;
