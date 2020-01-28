using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Travel.Models;
using Microsoft.EntityFrameworkCore;

namespace Travel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private TravelContext _db;
        public CountriesController(TravelContext db)
        {
            _db = db;
        }

        //GET api countries list
        [HttpGet]
        public ActionResult<IEnumerable<Country>> Get(string name)
        {
            var query = _db.Countries.AsQueryable();
            if (name != null)
            {
                query = query.Where(entry => entry.Name == name);
            }
            return query.ToList();
        }
        
        //Posting a new country
        [HttpPost]
        public void Post([FromBody] Country country)
        {
            _db.Countries.Add(country);
            _db.SaveChanges();
        }

        //GETTING single country from db
        [HttpGet("{id}")]
        public ActionResult<Country> Get(int id)
        {
            return _db.Countries.FirstOrDefault(entry => entry.CountryId == id);
        }

        [HttpPut("{id}")]
        public void Put (int id, [FromBody] Country country)
        {
            country.CountryId = id;
            _db.Entry(country).State = EntityState.Modified;
            _db.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete (int id)
        {
            var countryToDelete = _db.Countries.FirstOrDefault(entry => entry.CountryId == id);
            _db.Countries.Remove(countryToDelete);
            _db.SaveChanges();
        }

    }
}