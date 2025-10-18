using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace yt_tutorial_dropdown
{
    public partial class department : System.Web.UI.Page
    {
        DbCon db = new DbCon();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //insert button:
        protected void Button1_Click(object sender, EventArgs e)
        {
            int status;
            if (DropDownList1.SelectedValue == "Active")
            {
                status = 1;
            } else
            {
                status = 0;
            }

            SqlCommand cmd = new SqlCommand("insert into department (Id, name, status) values (@Id, @name, @status)");
            cmd.Parameters.AddWithValue("@Id", int.Parse(TextBox1.Text));
            cmd.Parameters.AddWithValue("@name", TextBox2.Text);
            cmd.Parameters.AddWithValue("@status", status);

            if (db.UDI(cmd))
            {
                Response.Write("<script>alert('inserted')</script>");
            } else
            {
                Response.Write("<script>alert('insertion failed')</script>");
            }
        }
    }
}
