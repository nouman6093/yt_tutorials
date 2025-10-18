using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DbCon
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Study\\Semester 6\\Visual Programming\\vs projects\\yt_tutorial_3tier\\yt_tutorial_3tier\\App_Data\\Database1.mdf;Integrated Security=True");

        //insert, update, delete:
        public bool UDI(SqlCommand cmd)
        {
            try
            {
                con.Open();
                cmd.Connection = con;
                return (cmd.ExecuteNonQuery() > 0);
            } catch (Exception e)
            {
                throw new Exception(e.Message);
            } finally
            {
                con.Close();
            }
        }
        
        //search, view:
        public DataTable Search(SqlCommand cmd)
        {
            cmd.Connection = con;
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            return dt;
        }
    }
}
