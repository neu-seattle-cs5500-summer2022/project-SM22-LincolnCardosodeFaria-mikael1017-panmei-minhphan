import React, { useState } from "react";
import { useNavigate } from "react-router-dom";

function LoginPage() {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const requestLogin = (e) => {
    e.preventDefault();
    // TODO: post request here
  };
  return (
    <div>
      <h1> Sign Up Page</h1>
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
    </div>
  );
}

export default LoginPage;
