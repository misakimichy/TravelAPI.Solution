using System.Collections.Generic;

namespace Travel.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string individualReview { get; set; }

        //Sharons addition
        public int PlaceId { get; set; }
        public virtual Place Place { get; set; }
    }
}