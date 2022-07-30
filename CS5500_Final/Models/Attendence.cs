﻿using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace CS5500_Final.Models
{
    public class Attendence
    {
        public int id { get; set; }
        public string date { get; set; }
        public string day { get; set; }
        public string time { get; set; }
        public double? spentTime { get; set; }
        public int UserId { get; set; }


    }
}
