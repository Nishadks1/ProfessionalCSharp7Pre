using System;

namespace DataLib
{
    public class Championship
    {
        public Championship()
        {

        }
        public Championship(int year, string first, string second, string third)
        {
            Year = year;
            First = first;
            Second = second;
            Third = third;
        }
        public int Year { get; set; }
        public string First { get; set; }
        public string Second { get; set; }
        public string Third { get; set; }
    }
}