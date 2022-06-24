import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import "./HomePage";
import { Button } from "react-bootstrap";

function SignupPage() {
  // create state variables for each input
  const navigate = useNavigate();
  const [username, setUsername] = useState("");
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [dateOfBirth, setDateOfBirth] = useState("");
  const [address, setAddress] = useState("");
  const [city, setCity] = useState("");
  const [state, setState] = useState("");
  const [zipcode, setZipcode] = useState("");
  const [phone, setPhone] = useState("");

  const createUser = (e) => {
    e.preventDefault();
    // TODO: post request here
  };

  const goHome = () => {
    navigate("/");
  };

  return (
    <div>
      <h1> Sign Up Page</h1>
      <form className="form" onSubmit={createUser}>
        {}
        <div> Username </div>
        <input
          label="Username"
          variant="filled"
          required
          value={username}
          onChange={(e) => setUsername(e.target.value)}
        />
        <div> Password </div>
        <input
          label="Password"
          variant="filled"
          required
          value={password}
          onChange={(e) => setPassword(e.target.value)}
        />
        <div> Email </div>
        <input
          label="Email"
          variant="filled"
          type="email"
          required
          value={email}
          onChange={(e) => setEmail(e.target.value)}
        />
        <div> First Name </div>
        <input
          label="First Name"
          variant="filled"
          required
          value={firstName}
          onChange={(e) => setFirstName(e.target.value)}
        />
        <div> Last Name </div>
        <input
          label="Last Name"
          variant="filled"
          required
          value={lastName}
          onChange={(e) => setLastName(e.target.value)}
        />
        <div> Date of Birth </div>
        <input
          label="Date of Birth"
          variant="filled"
          required
          value={dateOfBirth}
          onChange={(e) => setDateOfBirth(e.target.value)}
        />
        <div> Address </div>
        <input
          label="Date of Birth"
          variant="filled"
          required
          value={address}
          onChange={(e) => setAddress(e.target.value)}
        />
        <div> City </div>
        <input
          label="city"
          variant="filled"
          required
          value={city}
          onChange={(e) => setCity(e.target.value)}
        />
        <div> State </div>
        <input
          label="State"
          variant="filled"
          required
          value={state}
          onChange={(e) => setState(e.target.value)}
        />
        <div> Zipcode </div>
        <input
          label="Zipcode"
          variant="filled"
          required
          value={zipcode}
          onChange={(e) => setZipcode(e.target.value)}
        />
        <div> Phone </div>
        <input
          label="Phone"
          variant="filled"
          required
          value={phone}
          onChange={(e) => setPhone(e.target.value)}
        />

        <div>
          <Button type="submit" variant="primary">
            Signup
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

export default SignupPage;
