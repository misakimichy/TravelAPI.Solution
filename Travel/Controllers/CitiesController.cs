using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Travel.Models;
using Microsoft.EntityFrameworkCore;

namespace Travel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private TravelContext _db;
        public CitiesController(TravelContext db)
        {
            _db = db;
        }

        //GET api Cities list
        [HttpGet]
        public ActionResult<IEnumerable<City>> Get(string name, int rating)
        {
            var query = _db.Cities.AsQueryable();
            if (name != null)
            {
                query = query.Where(entry => entry.Name == name);
            }
            if(rating != 0)
            {
                query = query.Where(entry => entry.Rating == rating);
            }
            return query.ToList();
        }
        
        //Posting a new city
        [HttpPost]
        public void Post([FromBody] City city)
        {
            _db.Cities.Add(city);
            _db.SaveChanges();
        }

        //GETTING single city from db
        [HttpGet("{id}")]
        public ActionResult<City> Get(int id)
        {
            return _db.Cities.FirstOrDefault(entry => entry.CityId == id);
        }

        [HttpPut("{id}")]
        public void Put (int id, [FromBody] City city)
        {
            city.CityId = id;
            _db.Entry(city).State = EntityState.Modified;
            _db.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete (int id)
        {
            var cityToDelete = _db.Cities.FirstOrDefault(entry => entry.CityId == id);
            _db.Cities.Remove(cityToDelete);
            _db.SaveChanges();
        }

    }
}