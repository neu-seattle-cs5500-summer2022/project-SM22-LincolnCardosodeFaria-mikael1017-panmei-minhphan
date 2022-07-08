import Accordion from 'react-bootstrap/Accordion';
import React, { useState, useEffect } from 'react';
import GymDataService from '../services/callAPI';
import { useParams } from 'react-router-dom';
import "../style/Diet.css";

function Diet({ user }) {
  let params = useParams();
  console.log("diet-large params", params.id);

  const [mealData, setMealData] = useState(null);

  useEffect(() => {
    const getMealData = id => {
      GymDataService.findDiet(id)
        .then(response => {
          console.log("diet-large---------------- ", response);
          setMealData(response.data);
        })
        .catch(e => {
          console.log(e);
        });
    };
    getMealData(params.id);
  }, [params.id]);

  return (
    <div id="compnents">
      {/* mealData.data.map(weeklyMeal => {
                return(
                weeklyMeal.foods.map(everyDayMeal => {
                <Accordion defaultActiveKey="0">
                    <Accordion.Item eventKey="0">
                        <Accordion.Header>{everyDayMeal.name}</Accordion.Header>
                        <Accordion.Body>
                            foods
                        </Accordion.Body>
                    </Accordion.Item>
                </Accordion>
            }))
            }) */}

    </div>

  );
}
export default Diet;
