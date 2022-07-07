import React, { useState, useEffect } from "react";
import axios from "axios";
import { Button, Card, ListGroup } from "react-bootstrap";

const Members = (props) => {
  const [members, setMembers] = useState([]);
  const instance = axios.create({
    baseURL: "https://gymmanagement.cropfix.ca",
  });

  useEffect(() => {
    instance
      .get(
        "/User/GetAllUsers"
        // headers: { "Access-Control-Allow-Origin": "*" },
        // withCredentials: true,
      )
      .then(function (response) {
        // console.log(response);
        setMembers(response.data);
      })
      .catch(function (error) {
        console.log(error);
      });
  }, []);

  console.log(members);
  return (
    <div className="members">
      <Card className="mb-3">
        <Card.Header>List of members</Card.Header>
        <ListGroup variant="flush">
          {members.map((member, index) => (
            <ListGroup.Item key={member.id}>{member.fullname} </ListGroup.Item>
          ))}
        </ListGroup>
      </Card>
    </div>
  );
};

export default Members;
