using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace yt_tutorial_dropdown
{
    public class DbCon
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Study\\Semester 6\\Visual Programming\\vs projects\\yt_tutorial_dropdown\\yt_tutorial_dropdown\\App_Data\\Database1.mdf;Integrated Security=True");

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

        //view, search:
        public DataTable Search(SqlCommand cmd)
        {
            cmd.Connection = con;
            SqlDataAdapter dr = new SqlDataAdapter(cmd);    //this fetches data, or we can its bridge which is used to fetch data from db
            DataTable dt = new DataTable(); //that fetched data is used to be stored in datatable and that datatable is being created here
            dr.Fill(dt);    //this is where that data is actually being stored in datatable
            return dt;
        }
    }
}
