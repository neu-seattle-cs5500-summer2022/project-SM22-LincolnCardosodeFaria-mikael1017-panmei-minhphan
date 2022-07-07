import React from "react"
import Meal from "./Meal"
import "../style/Diet.css";

export default function MealList({ mealData }) {
    console.log("meallist-----------", mealData);
    //sort meal base on weekday
    mealData = [...mealData].sort((a, b) => a.weekDay - b.weekDay);
    console.log("sorted meal-------", mealData);

    return (
        <main>
            <section className="nutrients">
                <h1>Weekly Diet Plan</h1>
                <ul>
                    <li>Calories: 000</li>
                    <li>Carbohydrates: 000</li>
                    <li>Fat: 000</li>
                    <li>Protein: 000</li>
                </ul>
            </section>

            <section className="meals">
                {mealData.map(meal => {
                    return <Meal key={meal.id} meal={meal} />
                })}
            </section>
        </main>


        // Healper function if need to get Diet Plan from Spoonacular API based on Calories
        // const nutrients = mealData.nutrients

        // return (
        //     <main>
        //         <section className="nutrients">
        //             <h1>Meal</h1>
        //             <ul>
        //                 <li>Calories: {nutrients.calories.toFixed(0)}</li>
        //                 <li>Carbohydrates: {nutrients.carbohydrates.toFixed(0)}</li>
        //                 <li>Fat: {nutrients.fat.toFixed(0)}</li>
        //                 <li>Protein: {nutrients.protein.toFixed(0)}</li>
        //             </ul>
        //         </section>

        //         <section className="meals">
        //             {mealData.meals.map(meal => {
        //                 return <Meal key={meal.id} meal={meal} />
        //             })}
        //         </section>
        //     </main>
    )
}