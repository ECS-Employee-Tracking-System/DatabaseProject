using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieDatabase.Models
{
    public class Role
    {
        public int RoleID { get; set; }
        public String Name { get; set; }
        public virtual int ActorID { get; set; }
        public virtual int FilmID { get; set; }
    }
}