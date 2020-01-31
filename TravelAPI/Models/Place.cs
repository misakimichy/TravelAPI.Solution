using System.Collections.Generic;

namespace TravelAPI.Models
{
    public class Place
    {
        public int PlaceId { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public double Rating { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
        public Place()
        {
            this.Reviews = new HashSet<Review>();
        }
    }
}