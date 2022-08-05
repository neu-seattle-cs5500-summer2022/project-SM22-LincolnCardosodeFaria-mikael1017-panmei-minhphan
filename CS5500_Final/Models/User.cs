namespace CS5500_Final.Models
{
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string fullname { get; set; }
        public string email { get; set; }
        public  string password { get; set; }
        public string dob { get; set; }
        public string address { get; set; } 
        public string phone { get; set; }
        public bool isadmin { get; set; }


    }
}
