using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieDatabase.Models
{
    public class Film
    {
        public int FilmID { get; set; }
        public String Name { get; set; }
        public virtual int GenreID { get; set; }
       // public virtual IEnumerable<Genre> Genre { get; set; }
        public virtual int RatingID { get; set; }
       // public virtual IEnumerable<Rating> Rating { get; set; }
        public virtual String RatingName { get; set; }
        public virtual String GenreName { get; set; }
    }
}