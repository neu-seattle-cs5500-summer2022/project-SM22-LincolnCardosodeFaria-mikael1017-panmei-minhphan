namespace CS5500_Final.Models
{
    public class Attendence
    {
        public int AttendenceId { get; set; }
        public int UserId { get; set; }

        public int ScheduleId { get; set; }

        public bool IsPresent { get; set; }

        public DateTime Date { get; set; }

    }
}
