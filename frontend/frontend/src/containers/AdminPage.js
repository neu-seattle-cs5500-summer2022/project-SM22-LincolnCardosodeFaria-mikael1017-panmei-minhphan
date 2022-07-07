import React, { useState, useEffect } from "react";
// import { useParams } from "react-router";
// import Image from 'react-bootstrap/Image';
// import Col from 'react-bootstrap/Col';
// import Row from 'react-bootstrap/Row';
// import Container from 'react-bootstrap/Container';
// import Card from 'react-bootstrap/Card';
import Schedule from "../components/Schedule";
import WorkoutPlan from "../components/WorkoutPlan";
import Attendence from "../components/Attendence";
import MyNavbar from "../components/Navbar.js";
import Sidebar from "../components/Sidebar";
import AdminDiet from "../components/AdminDiet";

const Admin = (props) => {
  return (
    <div className="Admin">
      <Sidebar />
      <MyNavbar />
      <div id="page-wrap">
        <AdminDiet />
        {/* <Schedule />
        <Attendence />
        <WorkoutPlan /> */}
      </div>
    </div>
  );
};

export default Admin;
