namespace CS5500_Final.ViewModels
{
    public class DietViewModel
    {
        public List<FoodViewModel> Foods { get; set; }
        //public List<int> foodsids { get; set; }
        public int userId { get; set; }

        public int weekDay { get; set; }
    }
}
