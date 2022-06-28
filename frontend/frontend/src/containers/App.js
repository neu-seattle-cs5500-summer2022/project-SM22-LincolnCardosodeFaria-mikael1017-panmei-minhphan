import "../style/App.css";
import { Routes, Route } from "react-router-dom";
import Homepage from "./HomePage";
import SignupPage from "./SignupPage";
import LoginPage from "./LoginPage";

function App() {
  return (
    <div className="App">
      <Routes>
        <Route path="/" element={<Homepage />}></Route>
        <Route path="signup" element={<SignupPage />} />
        <Route path="login" element={<LoginPage />} />
      </Routes>
    </div>
  );
}

export default App;
