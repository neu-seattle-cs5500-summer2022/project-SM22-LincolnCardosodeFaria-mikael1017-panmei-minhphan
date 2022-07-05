namespace CS5500_Final.Models
{
    public class Schedule
    {
        public int scheduleId { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public string Location { get; set; }
        public int UserId { get; set; }

    }
}
