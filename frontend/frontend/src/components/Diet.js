import React, { useState, useEffect } from 'react';
import GymDataService from '../services/callAPI';
import { useParams } from 'react-router-dom';
import MealList from "./MealList"
import "../style/Diet.css";


const Diet = ({ user }) => {
    let params = useParams();


    // const [mealData, setMealData] = useState(null)
    // const [calories, setCalories] = useState(2000)
    const [mealData, setMealData] = useState(null);

    function getMealData(id) {
        console.log("getmealdata");
        GymDataService.findDiet(id)
            .then(response => {
                setMealData(response.data)
                console.log("get meal data------------", response);
                console.log("data type -----------", typeof (response))
            })
            .catch(() => {
                console.log("error")
            })
    }

    return (
        <div>
            <button onClick={() => getMealData(params.id)}>Get Daily Meal Plan</button>
            {mealData && <MealList mealData={mealData} />}
        </div >
    )

    // // get Diet Plan from Spoonacular API based on Calories
    // function getMealData() {
    //     fetch(
    //         `https://api.spoonacular.com/mealplanner/generate?apiKey=cb1c464d94f142c08b156c5beddade8b&timeFrame=day&targetCalories=${calories}`
    //     )
    //         .then(response => response.json())
    //         .then(data => {
    //             console.log("get meal------------", data)
    //             console.log("data type -----------", typeof (data))
    //             setMealData(data)
    //         })
    //         .catch(() => {
    //             console.log("error")
    //         })
    // }

    // function handleChange(e) {
    //     setCalories(e.target.value)
    // }

    // return (
    //     <div className="App">
    //         <section className="controls">
    //             <input
    //                 type="number"
    //                 placeholder="Calories (e.g. 2000)"
    //                 onChange={handleChange}
    //             />
    //             <button onClick={getMealData}>Get Daily Meal Plan</button>
    //         </section>
    //         {mealData && <MealList mealData={mealData} />}
    //     </div>
    // )


}

export default Diet;