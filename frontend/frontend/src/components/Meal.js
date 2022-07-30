import "../style/Diet.css";

export default function Meal({ meal }) {
    console.log("meal-------", meal);
    function dayOfWeekAsString(dayIndex) {
        return ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"][dayIndex] || '';
    }

    return (
        < article >
            <h1>{dayOfWeekAsString(meal.weekDay)}</h1>
            <h2>{meal.diet}</h2>
            {/* <img src={imageUrl} alt="recipe" /> */}

            <ul className="instructions">
                <li >Number of servings: 5</li>
            </ul>

            <a href={meal.sourceUrl} class="purple">Go to Recipe</a>
        </article >
    )




    // Healper function if need to get Diet Plan from Spoonacular API based on Calories
    // useEffect(() => {
    //     fetch(
    //         `https://api.spoonacular.com/recipes/${meal.id}/information?apiKey=cb1c464d94f142c08b156c5beddade8b&includeNutrition=false`
    //     )
    //         .then(response => response.json())
    //         .then(data => {
    //             setImageUrl(data.image)
    //         })
    //         .catch(() => {
    //             console.log("error")
    //         })
    // }, [meal.id])

    // return (
    //     <article>
    //         <h1>{meal.title}</h1>
    //         <img src={imageUrl} alt="recipe" />
    //         <ul className="instructions">
    //             <li>Preparation time: {meal.readyInMinutes} minutes</li>
    //             <li>Number of servings: {meal.servings}</li>
    //         </ul>

    //         <a href={meal.sourceUrl}>Go to Recipe</a>
    //     </article>
    // )
}