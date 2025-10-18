using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BLL;
using AppProps;

namespace yt_tutorial_3tier
{
    public partial class customer : System.Web.UI.Page
    {
        CustomerBLL bll = new CustomerBLL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //insert:
        protected void Button1_Click(object sender, EventArgs e)
        {
            CustomerProps c = new CustomerProps
            {
                Id = int.Parse(TextBox1.Text),
                name = TextBox2.Text
            };
            if (bll.insertCustomerBLL(c))
            {
                Response.Write("<script>alert('inserted')</script>");
            } else
            {
                Response.Write("<script>alert('insertion failed')</script>");
            }
        }

        //update:
        protected void Button2_Click(object sender, EventArgs e)
        {
            CustomerProps c = new CustomerProps
            {
                Id = int.Parse(TextBox1.Text),
                name = TextBox2.Text
            };
            if (bll.updateCustomerBLL(c))
            {
                Response.Write("<script>alert('updated')</script>");
            }
            else
            {
                Response.Write("<script>alert('updation failed')</script>");
            }
        }

        //delete:
        protected void Button3_Click(object sender, EventArgs e)
        {
            CustomerProps c = new CustomerProps
            {
                Id = int.Parse(TextBox1.Text),
            };
            if (bll.deleteCustomerBLL(c))
            {
                Response.Write("<script>alert('deleted')</script>");
            }
            else
            {
                Response.Write("<script>alert('deletion failed')</script>");
            }
        }

        //view:
        protected void Button4_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = bll.viewCustomerBLL();
            GridView1.DataBind();
        }

        //clear:
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
                DataTable dt = bll.searchCustomerBLL(TextBox1.Text);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            } else
            {
                DataTable dt = bll.searchCustomerBLL(TextBox1.Text);
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
