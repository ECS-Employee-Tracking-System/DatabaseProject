using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace MovieDatabase.Models
{
    public class RatingDBHandler
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["MovieConn"].ToString();
            con = new SqlConnection(constring);
        }

        // **************** ADD NEW Rating *********************

        public bool AddRating(Rating smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AddNewRating", con);
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

        // ********** VIEW Rating DETAILS ********************
        public List<Rating> GetRating()
        {
            connection();
            List<Rating> Ratinglist = new List<Rating>();

            SqlCommand cmd = new SqlCommand("GetRatingDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Ratinglist.Add(
                    new Rating
                    {
                        RatingID = Convert.ToInt32(dr["RatingID"]),
                        Name = Convert.ToString(dr["Name"])
                    });
            }
            return Ratinglist;
        }

        // ***************** UPDATE Rating DETAILS *********************
        public bool UpdateDetails(Rating smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateRatingDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@RatingID", smodel.RatingID);
            cmd.Parameters.AddWithValue("@Name", smodel.Name);


            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********************** DELETE Rating DETAILS *******************
        public bool DeleteRating(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DeleteRating", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@RatingID", id);

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