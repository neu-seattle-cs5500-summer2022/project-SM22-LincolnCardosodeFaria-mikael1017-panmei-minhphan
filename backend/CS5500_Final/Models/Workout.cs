namespace CS5500_Final.Models
{
    public class Workout
    {
        public int WorkoutId { get; set; }
        public Exercise Exercise { get; set; }
        public DateTime Date { get; set; }
        public TimeOnly Time { get; set; }
    }
}
