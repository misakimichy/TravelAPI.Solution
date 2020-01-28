using System.Collections.Generic;

namespace Travel.Models
{
    public class City
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        // public List<City> _instances = new List<City>{};
        // public City(string name)
        // {
        //     Name = name;
        //     _instances.Add(this);
        //     CityId = _instances.Count;
        // }
    }
}