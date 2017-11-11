using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace MovieDatabase.Models
{
    public class FilmDBHandler
    {
        private SqlConnection con;
        private void Connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["MovieConn"].ToString();
            con = new SqlConnection(constring);
        }

        // **************** ADD NEW Film *********************

        public bool AddFilm(Film smodel)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("AddNewFilm", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FilmName", smodel.Name);
            cmd.Parameters.AddWithValue("@RatingName", smodel.RatingName);
            cmd.Parameters.AddWithValue("@GenreName", smodel.GenreName);
           
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********** VIEW Film DETAILS ********************
        public List<Film> GetFilm()
        {
            Connection();
            List<Film> Filmlist = new List<Film>();

            SqlCommand cmd = new SqlCommand("GetFilmDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Filmlist.Add(
                    new Film
                    {
                        FilmID = Convert.ToInt32(dr["FilmID"]),
                        Name = Convert.ToString(dr["Name"]),
                        GenreID = Convert.ToInt32(dr["GenreID"]),
                        RatingID = Convert.ToInt32(dr["RatingID"]),
                        RatingName= Convert.ToString(dr["RatingName"]),
                        GenreName = Convert.ToString(dr["GenreName"])
                    });
            }
            return Filmlist;
        }

        // ***************** UPDATE Film DETAILS *********************
        public bool UpdateDetails(Film smodel)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("UpdateFilmDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FilmID", smodel.FilmID);
            cmd.Parameters.AddWithValue("@Name", smodel.Name);
            cmd.Parameters.AddWithValue("@GenreName", smodel.GenreName);
            cmd.Parameters.AddWithValue("@RatingName", smodel.RatingName);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********************** DELETE Film DETAILS *******************
        public bool DeleteRating(int id)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("DeleteFilm", con);
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