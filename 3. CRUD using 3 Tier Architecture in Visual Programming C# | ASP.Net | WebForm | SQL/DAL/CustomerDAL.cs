using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using AppProps;

namespace DAL
{
    public class CustomerDAL
    {
        DbCon db = new DbCon();

        //insert:
        public bool insertCustomer(CustomerProps c)
        {
            SqlCommand cmd = new SqlCommand("insert into customer (Id, name) values (@Id, @name)");
            cmd.Parameters.AddWithValue("@Id", c.Id);
            cmd.Parameters.AddWithValue("@name", c.name);
            return db.UDI(cmd);
        }

        //update:
        public bool updateCustomer(CustomerProps c)
        {
            SqlCommand cmd = new SqlCommand("update customer set name = @name where Id = @Id");
            cmd.Parameters.AddWithValue("@Id", c.Id);
            cmd.Parameters.AddWithValue("@name", c.name);
            return db.UDI(cmd);
        }

        //delete:
        public bool deleteCustomer(CustomerProps c)
        {
            SqlCommand cmd = new SqlCommand("delete from customer where Id = @Id");
            cmd.Parameters.AddWithValue("@Id", c.Id);
            return db.UDI(cmd);
        }

        //view:
        public DataTable viewCustomer()
        {
            SqlCommand cmd = new SqlCommand("select * from customer");
            DataTable dt = db.Search(cmd);
            return dt;
        }

        //search:
        public DataTable searchCustomer(string ids)
        {
            if (ids.Contains(","))
            {
                SqlCommand cmd = new SqlCommand("select * from customer where Id IN (" + ids + ")");
                DataTable dt = db.Search(cmd);
                return dt;
            } else
            {
                SqlCommand cmd = new SqlCommand("select * from customer where Id = @Id");
                cmd.Parameters.AddWithValue("@Id", ids);
                DataTable dt = db.Search(cmd);
                return dt;
            }
        }
    }
}
