using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using System.Configuration;

namespace DataServ
{

    //Data-access-layer 
    public class Dal
    {
        public DataTable GetJobs(string word)
        {
            DataTable dt = new DataTable();
            string connStr = ConfigurationManager.ConnectionStrings["azureConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SearchJobs", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@word", word);
                    dt.Load(cmd.ExecuteReader());
                    conn.Close();
                    
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Exception Message: " + ex.Message);
                }
               
            }
            return dt;
        }

        public string DataTableToJSONWithJSONNet(DataTable table)
        {
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(table);
            return JSONString;
        }
    }


}