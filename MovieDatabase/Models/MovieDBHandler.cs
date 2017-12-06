using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace MovieDatabase.Models
{
    public class MovieDBHandler
    {
        private SqlConnection con;
        private void Connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["MovieConn"].ToString();
            con = new SqlConnection(constring);
        }

        // **************** ADD NEW Movie *********************

        public bool AddMovie(Movie smodel)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("AddNewMovie", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProducerFirstName", smodel.ProducerFirstName);
            cmd.Parameters.AddWithValue("@ProducerLastName", smodel.ProducerLastName);
            cmd.Parameters.AddWithValue("@FilmName", smodel.FilmName);
            cmd.Parameters.AddWithValue("@FilmYear", smodel.FilmYear);
            cmd.Parameters.AddWithValue("@FilmReleased", smodel.FilmReleased);
            cmd.Parameters.AddWithValue("@FilmRuntime", smodel.FilmRuntime);
            cmd.Parameters.AddWithValue("@FilmimdbID", smodel.FilmimdbID);
            cmd.Parameters.AddWithValue("@FilmPoster", smodel.FilmPoster);
            cmd.Parameters.AddWithValue("@GenreName", smodel.GenreName);
            cmd.Parameters.AddWithValue("@RatingName", smodel.RatingName);
            cmd.Parameters.AddWithValue("@ActorFirstName", smodel.ActorFirstName);
            cmd.Parameters.AddWithValue("@ActorLastName", smodel.ActorLastName);
            cmd.Parameters.AddWithValue("@ActorBirthday", smodel.ActorBirthday);
            cmd.Parameters.AddWithValue("@ActorBirthCity", smodel.ActorBirthCity);
            cmd.Parameters.AddWithValue("@ActorBirthState", smodel.ActorBirthState);
            cmd.Parameters.AddWithValue("@ActorBirthCountry", smodel.ActorBirthCountry);
            cmd.Parameters.AddWithValue("@RoleName", smodel.ActorLastName);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********** VIEW Movie DETAILS ********************
        public List<Movie> GetMovie()
        {
            Connection();
            List<Movie> Movielist = new List<Movie>();

            SqlCommand cmd = new SqlCommand("GetMovieDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {

                Movielist.Add(
                    new Movie
                    {
                        FilmName = Convert.ToString(dr["FilmName"]),
                        FilmYear=Convert.ToDateTime(dr["FilmYear"] as DateTime?),
                        FilmReleased = Convert.ToDateTime(dr["FilmReleased"] as DateTime?),
                        FilmRuntime = Convert.ToString(dr["FilmRuntime"]),
                        FilmimdbID = Convert.ToString(dr["FilmimdbID"]),
                        FilmPoster = Convert.ToString(dr["FilmPoster"]),
                        FilmID = Convert.ToInt32(dr["FilmID"]),
                        ProducerID = Convert.ToInt32(dr["ProducerID"]),
                        GenreID = Convert.ToInt32(dr["GenreID"]),
                        RatingID = Convert.ToInt32(dr["RatingID"]),
                        RatingName = Convert.ToString(dr["RatingName"]),
                        GenreName = Convert.ToString(dr["GenreName"]),
                        ProducerFirstName = Convert.ToString(dr["ProducerFirstName"]),
                        ProducerLastName = Convert.ToString(dr["ProducerLastName"]),
                        ActorFirstName= Convert.ToString(dr["ActorFirstName"]),
                        ActorLastName = Convert.ToString(dr["ActorLastName"]),
                        ActorBirthday = Convert.ToDateTime(dr["ActorBirthday"] as DateTime?),
                        ActorBirthCity = Convert.ToString(dr["ActorBirthCity"]),
                        ActorBirthState = Convert.ToString(dr["ActorBirthState"]),
                        ActorBirthCountry = Convert.ToString(dr["ActorBirthCountry"]),
                        RoleName = Convert.ToString(dr["RoleName"])

                    });
            }
            return Movielist;
        }

        // ***************** UPDATE Movie DETAILS *********************
        public bool UpdateDetails(Movie smodel)
        {

            Connection();
            SqlCommand cmd = new SqlCommand("UpdateMovieDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FilmID", smodel.FilmID);
            cmd.Parameters.AddWithValue("@ProducerFirstName", smodel.ProducerFirstName);
            cmd.Parameters.AddWithValue("@ProducerLastName", smodel.ProducerLastName);
            cmd.Parameters.AddWithValue("@FilmName", smodel.FilmName);
            cmd.Parameters.AddWithValue("@FilmYear", smodel.FilmYear);
            cmd.Parameters.AddWithValue("@FilmReleased", smodel.FilmReleased);
            cmd.Parameters.AddWithValue("@FilmRuntime", smodel.FilmRuntime);
            cmd.Parameters.AddWithValue("@FilmimdbID", smodel.FilmimdbID);
            cmd.Parameters.AddWithValue("@FilmPoster", smodel.FilmPoster);
            cmd.Parameters.AddWithValue("@GenreName", smodel.GenreName);
            cmd.Parameters.AddWithValue("@RatingName", smodel.RatingName);
            cmd.Parameters.AddWithValue("@ActorFirstName", smodel.ActorFirstName);
            cmd.Parameters.AddWithValue("@ActorLastName", smodel.ActorLastName);
            cmd.Parameters.AddWithValue("@ActorBirthday", smodel.ActorBirthday);
            cmd.Parameters.AddWithValue("@ActorBirthCity", smodel.ActorBirthCity);
            cmd.Parameters.AddWithValue("@ActorBirthState", smodel.ActorBirthState);
            cmd.Parameters.AddWithValue("@ActorBirthCountry", smodel.ActorBirthCountry);
            cmd.Parameters.AddWithValue("@RoleName", smodel.RoleName);


            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********************** DELETE Movie DETAILS *******************
        public bool DeleteMovie(int id)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("DeleteMovie", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FilmID", id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        // ********************** JM1 GetActorsStateCount *******************
        public List<Movie> GetActorsStateCount()
        {
            Connection();
            List<Movie> Movielist = new List<Movie>();

            SqlCommand cmd = new SqlCommand("GetActorsStateCount", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {

                Movielist.Add(
                    new Movie
                    {
               
                        ActorBirthState = Convert.ToString(dr["BirthState"]),
                
                        ActorsPerState = Convert.ToInt32(dr["Actors Per State"])

                    });
            }
            return Movielist;
        }
        // ********************** JM2 GetActorMovies *******************
        public List<Movie> GetActorMovies(int id)
        {
            Connection();
            List<Movie> Movielist = new List<Movie>();

            SqlCommand cmd = new SqlCommand("GetActorMovies", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ActorID", id);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {

                Movielist.Add(
                    new Movie
                    {
                        FilmPoster = Convert.ToString(dr["FilmPoster"]),
                        FilmName = Convert.ToString(dr["FilmName"]),
                        ActorFirstName = Convert.ToString(dr["ActorFirstName"]),
                        ActorLastName = Convert.ToString(dr["ActorLastName"]),
                        ActorID = Convert.ToInt32(dr["ActorID"])
                    });
            }
            return Movielist;
        }
        // ********************** JM2All GetActos *******************
        public List<Movie> GetActors()
        {
            Connection();
            List<Movie> Movielist = new List<Movie>();

            SqlCommand cmd = new SqlCommand("GetActors", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {

                Movielist.Add(
                    new Movie
                    {
                        ActorFirstName = Convert.ToString(dr["ActorFirstName"]),
                        ActorLastName = Convert.ToString(dr["ActorLastName"]),
                        ActorID = Convert.ToInt32(dr["ActorID"])
                    });
            }
            return Movielist;
        }

        public List<Movie> GetActionActorCalifornia()
        {
            Connection();
            List<Movie> Movielist = new List<Movie>();

            SqlCommand cmd = new SqlCommand("GetActorActionCalifornia", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {

                Movielist.Add(
                    new Movie
                    {
                        FilmPoster = Convert.ToString(dr["Poster"]),
                        ActorBirthState = Convert.ToString(dr["BirthState"]),
                        ActorFirstName = Convert.ToString(dr["FirstName"]),
                        ActorLastName = Convert.ToString(dr["LastName"]),
                        GenreName = Convert.ToString(dr["Name"])
                    });
            }
            return Movielist;
        }

        // ********************** CK1 GetActorsMovieCount *******************
        public List<Movie> GetActorsMovieCount()
        {
            Connection();
            List<Movie> ActorList = new List<Movie>();
            SqlCommand cmd = new SqlCommand("GetActorsMovieCount", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ActorList.Add(new Movie
                {
                    ActorID = Convert.ToInt32(dr["ActorID"]),
                    ActorFirstName = Convert.ToString(dr["FirstName"]),
                    ActorLastName = Convert.ToString(dr["LastName"]),
                    MoviesPerActor = Convert.ToInt32(dr["Number of Films"])
                });
            }

            return ActorList;
        }
    }
}