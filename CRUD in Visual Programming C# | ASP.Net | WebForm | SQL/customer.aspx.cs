using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace yt_tutorial_crud
{
    public partial class customer : System.Web.UI.Page
    {
        DbCon db = new DbCon();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //insert button:
        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into customer (Id, name) values (@Id, @name)");
            cmd.Parameters.AddWithValue("@Id", int.Parse(TextBox1.Text));
            cmd.Parameters.AddWithValue("@name", TextBox2.Text);
            if (db.UDI(cmd))
            {
                Response.Write("<script>alert('inserted')</script>");
            } else
            {
                Response.Write("<script>alert('insertion failed')</script>");
            }
        }

        //update button:
        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update customer set name = @name where Id = @Id");
            cmd.Parameters.AddWithValue("@Id", int.Parse(TextBox1.Text));
            cmd.Parameters.AddWithValue("@name", TextBox2.Text);
            if (db.UDI(cmd))
            {
                Response.Write("<script>alert('update')</script>");
            }
            else
            {
                Response.Write("<script>alert('updation failed')</script>");
            }
        }

        //delete button:
        protected void Button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("delete customer where Id = @Id");
            cmd.Parameters.AddWithValue("@Id", int.Parse(TextBox1.Text));
            if (db.UDI(cmd))
            {
                Response.Write("<script>alert('deleted')</script>");
            }
            else
            {
                Response.Write("<script>alert('deletion failed')</script>");
            }
        }

        //view button:
        protected void Button4_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from customer");
            DataTable dt = db.Search(cmd);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        //clear button:
        protected void Button5_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }

        //search:
        protected void Button6_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text.Trim().Contains(","))
            {
                SqlCommand cmd = new SqlCommand("select * from customer where Id IN (" + TextBox1.Text + ")");
                DataTable dt = db.Search(cmd);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            } else
            {
                SqlCommand cmd = new SqlCommand("select * from customer where Id = @Id");
                cmd.Parameters.AddWithValue("@Id", int.Parse(TextBox1.Text));
                DataTable dt = db.Search(cmd);
                if (dt.Rows.Count > 0)
                {
                    TextBox2.Text = dt.Rows[0]["name"].ToString();
                } else
                {
                    Response.Write("<script>alert('no records found')</script>");
                }
            }
        }
    }
}
