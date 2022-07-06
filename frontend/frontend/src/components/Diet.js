import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import Card from 'react-bootstrap/Card';
import Row from 'react-bootstrap/Row';
import MealList from "./MealList"


const Diet = ({ user }) => {
    let params = useParams();

    const [mealData, setMealData] = useState(null)
    const [calories, setCalories] = useState(2000)

    function getClientData(id) {
        //call API to get one month calories

    }

    // Spoonacular API
    function getMealData() {
        fetch(
            `https://api.spoonacular.com/mealplanner/generate?apiKey=cb1c464d94f142c08b156c5beddade8b&timeFrame=day&targetCalories=${calories}`
        )
            .then(response => response.json())
            .then(data => {
                console.log("get meal------------", data)
                console.log("data type -----------", typeof (data))
                setMealData(data)
            })
            .catch(() => {
                console.log("error")
            })
    }

    function handleChange(e) {
        setCalories(e.target.value)
    }

    return (
        <div className="App">
            <section className="controls">
                <input
                    type="number"
                    placeholder="Calories (e.g. 2000)"
                    onChange={handleChange}
                />
                <button onClick={getMealData}>Get Daily Meal Plan</button>
            </section>
            {mealData && <MealList mealData={mealData} />}
        </div>
    )

    // return (
    //     <div>
    //         <Card>
    //             <Card.Body>
    //                 <button onClick={getMealData}>Prev</button>
    //                 <button onClick={getMealData}>Get Today's Meal Plan</button>
    //                 <button onClick={getMealData}>Next</button>
    //                 {mealData && <MealList mealData={mealData} />}

    //             </Card.Body>
    //         </Card>
    //     </div>
    // )
}

export default Diet;