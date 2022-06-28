import React, { useState, useEffect } from 'react';
// import { useParams } from "react-router";
// import Image from 'react-bootstrap/Image';
// import Col from 'react-bootstrap/Col';
// import Row from 'react-bootstrap/Row';
// import Container from 'react-bootstrap/Container';
// import Card from 'react-bootstrap/Card';

import Schedule from '../components/Schedule'
import WorkoutPlan from '../components/WorkoutPlan';
import Diet from '../components/Diet';
import Attendence from '../components/Attendence';
import Sidebar from '../components/Sidebar';

const Client = props => {
    return (
        <div className="Client">
            <Sidebar />
            <div id="page-wrap">
                Client Page Placeholder
                <Schedule />
                <Diet />
                <Attendence />
                <WorkoutPlan />
            </div>
        </div>

    )
}

export default Client;