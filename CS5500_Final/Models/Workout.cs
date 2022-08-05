namespace CS5500_Final.Models
{
    public class Workout
    {
        public int id { get; set; }
        public string nameOfWorkout { get; set; }
        public int numberOfSets { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public int UserId { get; set; }
        
    }
}
