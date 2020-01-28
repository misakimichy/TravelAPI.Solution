using System.Collections.Generic;

namespace Travel.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        // public List<string> Review { get; set; }
        public int Rating { get; set; }
        // private List<Country> _instances = new List<Country>{};
        // private List<City> cities = new List<City>{};
        // public Country(string name)
        // {
        //     Name = name;
        //     _instances.Add(this);
        //     CountryId = _instances.Count;
        // }
    }
}