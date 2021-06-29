using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Quiz_Application
{
    class view_class
    {
        private string connstring = ConfigurationManager.ConnectionStrings["quiz"].ConnectionString;

        string querry;
        
        public view_class(string q)
        {
            this.querry = q;
        }

        public DataTable showrecord()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(connstring);
            SqlCommand cmd = new SqlCommand(querry, conn);
            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    dt.Load(dr);
                }
            }
            catch(Exception)
            {
                
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
    }
}
