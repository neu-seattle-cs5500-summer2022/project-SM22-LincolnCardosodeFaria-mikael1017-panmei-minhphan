import React, { useEffect, useState } from "react";
import Users from "./Users";
import axios from "axios";
import styled from "styled-components";
import AdminDiet from "../components/AdminDiet";

const AdminContainer = styled.div`
  margin: 25px;
`;
const UsersContainer = styled.div`
  max-width: 45%;
  max-height: 80vh;
  overflow-y: scroll;
`;

function AdminPage() {
  const [users, setUsers] = useState([]);

  const instance = axios.create({
    baseURL: "https://gymmanagement.cropfix.ca",
  });

  const getAllUsers = () => {
    instance
      .get("/User/GetAllUsers")
      .then(function (response) {
        setUsers(response.data);
        // console.log("Get all user Response: ", response);
      })
      .catch(function (error) {
        console.log(error);
      });
  };
  useEffect(() => {
    getAllUsers();
  }, []);
  return (
    <AdminContainer>
      <UsersContainer>
        <Users users={users} />
      </UsersContainer>
    </AdminContainer>
  );
}

export default AdminPage;
