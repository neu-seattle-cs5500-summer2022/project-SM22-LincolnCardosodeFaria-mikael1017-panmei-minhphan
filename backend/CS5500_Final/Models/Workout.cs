namespace CS5500_Final.Models
{
    public class Workout
    {
        public int WorkoutId { get; set; }
        public Exercise Exercise { get; set; }
        public DateTime date { get; set; }
    
        public int UserId { get; set; }
    }
}
