namespace CS5500_Final.Models
{
    public class WorkoutDataModel
    {
        public int id { get; set; }
        public string nameOfWorkout { get; set; }
        public int numberOfSets { get; set; }
        public string start { get; set; }
        public string end_workout { get; set; }
        public int UserId { get; set; }
    }
}
