using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace MovieDatabase.Models
{
    public class GenreDBHandler
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["MovieConn"].ToString();
            con = new SqlConnection(constring);
        }

        // **************** ADD NEW Genre *********************

        public bool AddGenre(Genre smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AddNewGenre", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", smodel.Name);
       

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********** VIEW Genre DETAILS ********************
        public List<Genre> GetGenre()
        {
            connection();
            List<Genre> Genrelist = new List<Genre>();

            SqlCommand cmd = new SqlCommand("GetGenreDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Genrelist.Add(
                    new Genre
                    {
                        GenreID = Convert.ToInt32(dr["GenreID"]),
                        Name = Convert.ToString(dr["Name"])
                    });
            }
            return Genrelist;
        }

        // ***************** UPDATE Genre DETAILS *********************
        public bool UpdateDetails(Genre smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateGenreDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@GenreID", smodel.GenreID);
            cmd.Parameters.AddWithValue("@Name", smodel.Name);
    

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********************** DELETE Genre DETAILS *******************
        public bool DeleteGenre(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DeleteGenre", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@GenreID", id);

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
