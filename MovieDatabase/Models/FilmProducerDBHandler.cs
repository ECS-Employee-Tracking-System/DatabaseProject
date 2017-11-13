using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace MovieDatabase.Models
{
    public class FilmProducerDBHandler
    {
        private SqlConnection con;
        private void Connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["MovieConn"].ToString();
            con = new SqlConnection(constring);
        }

        // **************** ADD NEW FilmProducer *********************

        public bool AddFilmProducer(FilmProducer smodel)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("AddNewFilmProducer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProducerFirstName", smodel.ProducerFirstName);
            cmd.Parameters.AddWithValue("@ProducerLastName", smodel.ProducerLastName);
            cmd.Parameters.AddWithValue("@FilmName", smodel.FilmName);
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

        // ********** VIEW FilmProducer DETAILS ********************
        public List<FilmProducer> GetFilmProducer()
        {
            Connection();
            List<FilmProducer> FilmProducerlist = new List<FilmProducer>();

            SqlCommand cmd = new SqlCommand("GetFilmProducerDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
    
                    FilmProducerlist.Add(
                        new FilmProducer
                        {
                            FilmName = Convert.ToString(dr["FilmName"]),
                            FilmID = Convert.ToInt32(dr["FilmID"]),
                            ProducerID = Convert.ToInt32(dr["ProducerID"]),
                            GenreID = Convert.ToInt32(dr["GenreID"]),
                            RatingID = Convert.ToInt32(dr["RatingID"]),
                            RatingName = Convert.ToString(dr["RatingName"]),
                            GenreName = Convert.ToString(dr["GenreName"]),
                            ProducerFirstName = Convert.ToString(dr["ProducerFirstName"]),
                            ProducerLastName = Convert.ToString(dr["ProducerLastName"])

                        });
            }
            return FilmProducerlist;
        }

        // ***************** UPDATE FilmProducer DETAILS *********************
        public bool UpdateDetails(FilmProducer smodel)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("UpdateFilmProducerDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FilmID", smodel.FilmID);
            cmd.Parameters.AddWithValue("@FilmName", smodel.FilmName);
            cmd.Parameters.AddWithValue("@GenreName", smodel.GenreName);
            cmd.Parameters.AddWithValue("@RatingName", smodel.RatingName);
            cmd.Parameters.AddWithValue("@ProducerFirstName", smodel.ProducerFirstName);
            cmd.Parameters.AddWithValue("@ProducerLastName", smodel.ProducerLastName);
            cmd.Parameters.AddWithValue("@ProducerID", smodel.ProducerID);
    
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********************** DELETE FilmProducer DETAILS *******************
        public bool DeleteRating(int id)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("DeleteFilmProducer", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FilmProcuerID", id);

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