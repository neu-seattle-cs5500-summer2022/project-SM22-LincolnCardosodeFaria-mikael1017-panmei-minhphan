import "../style/App.css";
import { Routes, Route } from "react-router-dom";
import Homepage from "./HomePage";
import SignupPage from "./SignupPage";
import LoginPage from "./LoginPage";
import ClientPage from "./ClientPage";
import AdminPage from "./AdminPage";

function App() {
  return (
    <div className="App">
      <Routes>
        <Route path="/" element={<Homepage />}></Route>
        <Route path="signup" element={<SignupPage />} />
        <Route path="login" element={<LoginPage />} />
        <Route path={"client/:id"} element={<ClientPage />} />
<<<<<<< HEAD
        <Route path={"admin/:id"} element={<AdminPage />} />
=======
        <Route path={"admin"} element={<AdminPage />} />
>>>>>>> 72e18e14caaadbecfbbd9c02a2d0101f19e64d98
      </Routes>
    </div>
  );
}

export default App;
