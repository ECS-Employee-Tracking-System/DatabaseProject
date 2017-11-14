using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieDatabase.Models
{
    public class Movie
    {
        public virtual int FilmID { get; set; }
        public virtual int ProducerID { get; set; }
        public virtual int GenreID { get; set; }
        public virtual int RatingID { get; set; }
        public virtual int RoleID { get; set; }
        public virtual int ActorID { get; set; }
        public virtual String ProducerFirstName { get; set; }
        public virtual String ProducerLastName { get; set; }
        public virtual String FilmName { get; set; }
        public virtual String RatingName { get; set; }
        public virtual String GenreName { get; set; }
        public virtual String RoleName { get; set; }
        public virtual String ActorFirstName { get; set; }
        public virtual String ActorLastName { get; set; }
    }
}