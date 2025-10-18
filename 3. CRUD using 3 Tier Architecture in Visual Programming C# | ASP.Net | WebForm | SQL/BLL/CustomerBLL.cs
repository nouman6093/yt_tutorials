using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using AppProps;
using DAL;

namespace BLL
{
    public class CustomerBLL
    {
        CustomerDAL dal = new CustomerDAL();

        //insert:
        public bool insertCustomerBLL(CustomerProps c)
        {
            return dal.insertCustomer(c);
        }

        //update:
        public bool updateCustomerBLL(CustomerProps c)
        {
            return dal.updateCustomer(c);
        }

        //delete:
        public bool deleteCustomerBLL(CustomerProps c)
        {
            return dal.deleteCustomer(c);
        }

        //view:
        public DataTable viewCustomerBLL()
        {
            return dal.viewCustomer();
        }

        //search:
        public DataTable searchCustomerBLL(string ids)
        {
            return dal.searchCustomer(ids);
        }
    }
}
