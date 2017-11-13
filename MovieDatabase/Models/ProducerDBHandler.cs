using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace MovieDatabase.Models
{
    public class ProducerDBHandler
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["MovieConn"].ToString();
            con = new SqlConnection(constring);
        }

        // **************** ADD NEW Producer *********************

        public bool AddProducer(Producer smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AddNewProducer", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FirstName", smodel.FirstName);
            cmd.Parameters.AddWithValue("@LastName", smodel.LastName);


            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********** VIEW Producer DETAILS ********************
        public List<Producer> GetProducer()
        {
            connection();
            List<Producer> producerlist = new List<Producer>();

            SqlCommand cmd = new SqlCommand("GetProducerDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                producerlist.Add(
                    new Producer
                    {
                        ProducerID = Convert.ToInt32(dr["ProducerID"]),
                        FirstName = Convert.ToString(dr["FirstName"]),
                        LastName = Convert.ToString(dr["LastName"])
                    });
            }
            return producerlist;
        }

        // ***************** UPDATE Producer DETAILS *********************
        public bool UpdateDetails(Producer smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateProducerDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ProducerID", smodel.ProducerID);
            cmd.Parameters.AddWithValue("@FirstName", smodel.FirstName);
            cmd.Parameters.AddWithValue("@LastName", smodel.LastName);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********************** DELETE Producer DETAILS *******************
        public bool DeleteProducer(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DeleteProducer", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ProducerID", id);

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
