using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace yt_tutorial_crud
{
    public class DbCon
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Study\\Semester 6\\Visual Programming\\vs projects\\yt_tutorial_crud\\yt_tutorial_crud\\App_Data\\Database1.mdf;Integrated Security=True");
        //insert, update, delete:
        public bool UDI(SqlCommand cmd)
        {
            try
            {
                con.Open();
                cmd.Connection = con;   //points to a specific db
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
            SqlDataAdapter dr = new SqlDataAdapter(cmd);    //its a bridge which is used to fetch data from db and then it inserts it in datatable
            DataTable dt = new DataTable();
            dr.Fill(dt);    //this line fills data in datatable which was fetched with the help of sql data adatoper (bridge)
            return dt;
        }
    }
}
