using CS5500_Final.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Net;

namespace CS5500_Final.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class WorkOutController : Controller
    {
        private readonly IConfiguration _configuration;

        public WorkOutController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="workout"></param>
        /// <returns></returns>
        [HttpPost(nameof(CreateWorkout))]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<JsonResult> CreateWorkout(WorkoutViewModel workout)
        {
            string myDb1ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (var connection = new SqlConnection(myDb1ConnectionString))
                {
                    await connection.OpenAsync();


                    var parameters = new { NameOfWorkout = workout.nameOfWorkout, NumberOfSets = workout.numberOfSets, Start = workout.start, End = workout.end, UserId = workout.UserId };
                    var sqlStatement = @"
                                    INSERT INTO Workouts 
                                    (NameOfWorkout
                                    ,NumberOfSets
                                    ,Start
                                    ,end_workout
                                    ,UserId
                                    
                                    )
                                    VALUES (
                                     @NameOfWorkout
                                    ,@NumberOfSets
                                    ,@Start
                                    ,@End
                                    ,@UserId
      
                                    )";

                    var insertedDiet = await connection.QueryAsync<Diet>(sqlStatement, parameters);


                    var sqlStatementLatestId = @"SELECT IDENT_CURRENT('Workouts')";

                    var lastId = await connection.QueryAsync<int>(sqlStatementLatestId);
                    int id = lastId.FirstOrDefault();



                    return new JsonResult(new { workoutId = id, message = "Workouts created" })
                    {
                        StatusCode = StatusCodes.Status200OK // Status code here 
                    };
                }
            }
            catch (Exception e)
            {
                return new JsonResult(e.Message)
                {
                    StatusCode = StatusCodes.Status500InternalServerError // Status code here 
                };


            }


        }
        /// <summary>
        /// Update a Workout
        /// </summary>
        /// <param name="workout"></param>
        /// <returns></returns>
        [HttpPut(nameof(UpdateWorkout))]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<JsonResult> UpdateWorkout(Workout workout)
        {
            string myDb1ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (var connection = new SqlConnection(myDb1ConnectionString))
                {
                    await connection.OpenAsync();

                    var sqlStatementQueryDit = @"select * from Workouts where id = @WorkoutId";
                    var selectParemeter = new { WorkoutId = workout.id };
                    var selectedDiet = await connection.QueryAsync<Workout>(sqlStatementQueryDit, selectParemeter);

                    var updateParameters = new { WorkoutId = workout.id, NameOfWorkout = workout.nameOfWorkout, NumberOfSets = workout.numberOfSets, Start = workout.start, End = workout.end, UserId = workout.UserId };
                    string updateQuery = @"UPDATE Workouts 
                                         SET nameOfWorkout = @NameOfWorkout, 
                                         numberOfSets = @NumberOfSets,
                                         start =@Start, 
                                         end_workout =@End ,
                                         UserId =@UserId
                                         WHERE id = @WorkoutId";
                    await connection.QueryAsync<int>(updateQuery, updateParameters);


                    return new JsonResult("Workout Updated")
                    {
                        StatusCode = StatusCodes.Status200OK // Status code here 
                    };
                }
            }
            catch (Exception e)
            {
                return new JsonResult(e.Message)
                {
                    StatusCode = StatusCodes.Status500InternalServerError // Status code here 
                };


            }

        }
        /// <summary>
        /// Get All Workouts for an User
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet(nameof(GetAllWorkoutByUser))]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<JsonResult> GetAllWorkoutByUser(int userId)
        {
            string myDb1ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (var connection = new SqlConnection(myDb1ConnectionString))
                {
                    await connection.OpenAsync();


                    var parameters = new { UserId = userId };
                    var sqlStatementQueryDit = @"select* from Workouts where UserId = @UserId";

                    var selectedWorkouts = await connection.QueryAsync<WorkoutDataModel>(sqlStatementQueryDit, parameters);

                    List<Workout> workouts = new List<Workout>();
                    foreach (var item in selectedWorkouts)
                    {
                        Workout t = new Workout();
                        t.end = item.end_workout;
                        t.UserId = item.UserId;
                        t.start = item.start;
                        t.id = item.id;
                        t.nameOfWorkout = item.nameOfWorkout;
                        t.numberOfSets = item.numberOfSets;

                        workouts.Add(t);



                    }
                    if (workouts.Count() > 0)
                    {
                        return new JsonResult(workouts)
                        {
                            StatusCode = StatusCodes.Status200OK // Status code here 
                        };
                    }
                    else
                    {
                        return new JsonResult("Workouts related to this user id not found")
                        {
                            StatusCode = StatusCodes.Status200OK // Status code here 
                        };

                    }
                }
            }
            catch (Exception e)
            {
                return new JsonResult(e.Message)
                {
                    StatusCode = StatusCodes.Status500InternalServerError // Status code here 
                };

            }
        }
    }
}
