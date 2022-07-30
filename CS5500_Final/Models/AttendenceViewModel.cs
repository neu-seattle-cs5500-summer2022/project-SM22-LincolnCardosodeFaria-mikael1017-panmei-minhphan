namespace CS5500_Final.Models
{
    public class AttendenceViewModel
    {   
        public string date { get; set; }
        public string day { get; set; }
        public string time { get; set; }
        public double? spentTime { get; set; }
        public int UserId { get; set; }
    }
}
