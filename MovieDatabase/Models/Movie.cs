using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieDatabase.Models
{
    public class Movie
    {
        public int ProducerID { get; set; }
        public int FilmID { get; set; }
        public int RatingID { get; set; }
        public int GenreID { get; set; }
        public int RoleID { get; set; }
        public int ActorID { get; set; }

        public String ProducerFirstName { get; set; }
        public String ProducerLastName { get; set; }
        
        public String FilmName { get; set; }
        public DateTime FilmYear { get; set; }
        public DateTime FilmReleased { get; set; }
        public String FilmRuntime { get; set; }
        public String FilmimdbID { get; set; }
        public String FilmPoster { get; set; }

        public String RatingName { get; set; }
        
        public String GenreName { get; set; }
      
        public String ActorFirstName { get; set; }
        public String ActorLastName { get; set; }
        public DateTime ActorBirthday { get; set; }
        public String ActorBirthCity { get; set; }
        public String ActorBirthState { get; set; }
        public String ActorBirthCountry { get; set; }

        public String RoleName { get; set; }
    }
}