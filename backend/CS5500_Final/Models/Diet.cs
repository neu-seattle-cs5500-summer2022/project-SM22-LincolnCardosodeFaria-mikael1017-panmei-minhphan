using CS5500_Final.ViewModels;

namespace CS5500_Final.Models
{
    public class Diet
    {
        public int id { get; set; }

        //public List<Food> foods { get; set; }
        
        public string diet { get; set; }
        public int userId { get; set; }

        public int weekDay { get; set; }
    }
}
