import React, { useState, useEffect } from "react";
// import { useParams } from "react-router";
// import Image from 'react-bootstrap/Image';
// import Col from 'react-bootstrap/Col';
// import Row from 'react-bootstrap/Row';
// import Container from 'react-bootstrap/Container';
// import Card from 'react-bootstrap/Card';
import Members from "../components/Members";
import Schedule from "../components/Schedule";
import WorkoutPlan from "../components/WorkoutPlan";
import Diet from "../components/Diet";
import Attendence from "../components/Attendence";
import MyNavbar from "../components/Navbar.js";
import Sidebar from "../components/Sidebar";

const Admin = (props) => {
  return (
    <div className="Admin">
      <Sidebar />
      <MyNavbar />
      <div id="page-wrap">
        <Members />
        {/* <Schedule />
        <Attendence />
        <WorkoutPlan /> */}
      </div>
    </div>
  );
};

export default Admin;
