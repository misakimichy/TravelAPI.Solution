using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc;
using Travel.Models;
using Microsoft.EntityFrameworkCore;

namespace Travel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        private TravelContext _db;
        public PlacesController(TravelContext db)
        {
            _db = db;
        }

        //GET api Places list
        [HttpGet]
        public ActionResult<IEnumerable<Place>> Get(string country, string city)
        {
            var query = _db.Places.AsQueryable();
            if (country != null)
            {
                query = query.Where(entry => entry.Country == country);
            }
            if (city != null)
            {
                query = query.Where(entry => entry.City == city);
            }
            // if(rating != 0)
            // {
            //     query = query.Where(entry => entry.Rating == rating);
            // }

            return query.ToList();
        }
        
        //Posting a new country
        [HttpPost]
        public void Post([FromBody] Place place)
        {
            _db.Places.Add(place);
            _db.SaveChanges();
        }

        //GETTING single place from db
        [HttpGet("{id}")]
        public ActionResult<Place> Get(int id)
        {
            return _db.Places.FirstOrDefault(entry => entry.PlaceId == id);
        }

        [HttpPut("{id}")]
        public void Put (int id, [FromBody] Place place)
        {
            place.PlaceId = id;
            _db.Entry(place).State = EntityState.Modified;
            _db.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete (int id)
        {
            var placeToDelete = _db.Places.FirstOrDefault(entry => entry.PlaceId == id);
            _db.Places.Remove(placeToDelete);
            _db.SaveChanges();
        }

    }
}