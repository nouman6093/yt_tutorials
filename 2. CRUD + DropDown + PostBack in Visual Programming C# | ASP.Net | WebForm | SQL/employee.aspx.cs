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
    public partial class employee : System.Web.UI.Page
    {
        DbCon db = new DbCon();

        protected void Page_Load(object sender, EventArgs e)
        {
            //postback = when you click a button and if page reloads data from server that is postback
            //ispostback = boolean function if true it means page is being reloaded after button click, false means page is being loaded for first time
            //!ispostback = false of ispostback (page is being loaded for first time)
            //if ispostback is false that means = !ispostback that means = do something when page is being loaded for first time

            if (!IsPostBack)
            {
                SqlCommand cmd = new SqlCommand("select name from department where status = 1");
                DataTable dt = db.Search(cmd);
                DropDownList1.DataSource = dt;
                DropDownList1.DataTextField = "name";
                DropDownList1.DataValueField = "name";
                DropDownList1.DataBind();
            }
        }
        
        //insert button:
        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into employee (Id, department) values (@Id, @department)");
            cmd.Parameters.AddWithValue("@Id", int.Parse(TextBox1.Text));
            cmd.Parameters.AddWithValue("@department", DropDownList1.SelectedItem.Text);
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
            SqlCommand cmd = new SqlCommand("update employee set department = @department where Id = @Id");
            cmd.Parameters.AddWithValue("@Id", int.Parse(TextBox1.Text));
            cmd.Parameters.AddWithValue("@department", DropDownList1.SelectedItem.Text);
            if (db.UDI(cmd))
            {
                Response.Write("<script>alert('updated')</script>");
            }
            else
            {
                Response.Write("<script>alert('updation failed')</script>");
            }
        }

        //delete button:
        protected void Button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("delete from employee where Id = @Id");
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
            SqlCommand cmd = new SqlCommand("select * from employee");
            DataTable dt = db.Search(cmd);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        //clear button:
        protected void Button5_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            DropDownList1.ClearSelection();
        }

        //search button:
        protected void Button6_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text.Trim().Contains(","))
            {
                SqlCommand cmd = new SqlCommand("select * from employee where Id IN (" + TextBox1.Text + ")");
                DataTable dt = db.Search(cmd);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            } else
            {
                SqlCommand cmd = new SqlCommand("select * from employee where Id = @Id");
                cmd.Parameters.AddWithValue("@Id", int.Parse(TextBox1.Text));
                DataTable dt = db.Search(cmd);
                if (dt.Rows.Count > 0)
                {
                    DropDownList1.SelectedValue = dt.Rows[0]["department"].ToString();
                } else
                {
                    Response.Write("<script>alert('no records found')</script>");
                }
            }
        }
    }
}
