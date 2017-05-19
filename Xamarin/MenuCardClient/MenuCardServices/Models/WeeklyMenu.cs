using System;
using System.Collections.Generic;
using System.Text;

namespace MenuCardServices.Models
{
    public class WeeklyMenu
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }

        public string ThumbnaailUrl { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public override string ToString() => $"{Title} {Subtitle}";
    }
}
