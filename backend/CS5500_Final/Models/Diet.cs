using CS5500_Final.ViewModels;

namespace CS5500_Final.Models
{
    public class Diet
    {
        public int DietId { get; set; }

        public List<Food> Foods { get; set; }
        
        public int UserId { get; set; }

        public int WeekDay { get; set; }
    }
}
