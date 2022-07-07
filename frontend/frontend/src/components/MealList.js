import React from "react"
import Meal from "./Meal"
import "../style/Diet.css";

export default function MealList({ mealData }) {
    console.log("meallist-----------", mealData);

    return (
        <main>
            <section className="nutrients">
                <h1>Meal</h1>
                <ul>
                    <li>Calories: </li>
                    <li>Carbohydrates: </li>
                    <li>Fat:</li>
                    <li>Protein: </li>
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