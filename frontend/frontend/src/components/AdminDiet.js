import React, { useState, useEffect } from "react";
import axios from "axios";
import { Button, Card, ListGroup, Form } from "react-bootstrap";
import styled from "styled-components";

const FormContainer = styled.div`
  margin: auto;
  width: 25%;
`;

function AdminDiet(props) {
  const [diet, setDiet] = useState("");
  const [weekDay, setWeekDay] = useState(0);
  const instance = axios.create({
    baseURL: "https://gymmanagement.cropfix.ca",
  });

  const createDiet = (e) => {
    e.preventDefault();

    instance
      .post(
        "/Diet/CreateDiet",
        // headers: { "Access-Control-Allow-Origin": "*" },
        // withCredentials: true,
        {
          userId: props.id,
          weekDay: weekDay,
          diet: diet,
        }
      )
      .then(function (response) {
        console.log(response);
        setDiet("");
        setWeekDay("");
        alert("Diet has been created for selected user");
      })
      .catch(function (error) {
        console.log(error);
      });
  };

  return (
    <div>
      <FormContainer className="mb-3">
        <Form onSubmit={createDiet}>
          <Form.Label>Create a diet </Form.Label>
          <Form.Group className="mb-3">
            {/* <Form.Label>Username</Form.Label> */}

            <Form.Control
              as="textarea"
              rows={4}
              type="diet"
              placeholder="Description of the diet"
              value={diet}
              onChange={(e) => setDiet(e.target.value)}
            />
          </Form.Group>
          <Form.Group>
            <Form.Control
              as="select"
              className="mb-3"
              value={weekDay}
              onChange={(e) => setWeekDay(e.target.value)}
            >
              <option value={1}> Monday </option>
              <option value={2}> Tuesday </option>
              <option value={3}> Wednesday </option>
              <option value={4}> Thursday </option>
              <option value={5}> Friday</option>
              <option value={6}> Saturday</option>
              <option value={0}> Sunday</option>
            </Form.Control>
          </Form.Group>
          <div>
            <Button type="submit" variant="primary">
              Create
            </Button>
          </div>
        </Form>
      </FormContainer>
    </div>
  );
}

export default AdminDiet;
