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
            cmd.Parameters.AddWithValue("@GenreName", smodel.GenreName);
            cmd.Parameters.AddWithValue("@RatingName", smodel.RatingName);
            cmd.Parameters.AddWithValue("@ActorFirstName", smodel.ActorFirstName);
            cmd.Parameters.AddWithValue("@ActorLastName", smodel.ActorLastName);
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
            cmd.Parameters.AddWithValue("@GenreName", smodel.GenreName);
            cmd.Parameters.AddWithValue("@RatingName", smodel.RatingName);
            cmd.Parameters.AddWithValue("@ActorFirstName", smodel.ActorFirstName);
            cmd.Parameters.AddWithValue("@ActorLastName", smodel.ActorLastName);
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
    }
}