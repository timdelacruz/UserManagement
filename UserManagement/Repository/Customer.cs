using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using UserManagement.Models;
using static UserManagement.Models.User;

namespace UserManagement.Repository
{
    public class Customer : ICustomer
    {
        public User GetCustomerUser(int id, DataTable dt)
        {
            User user = new User();
            if (dt.Rows.Count > 0)
            {
                DataRow[] dr = dt.Select("Id= " + id);

                if (dr.Length > 0)
                {
                    foreach (DataRow row in dr)
                    {
                        user.id = Convert.ToInt32(row["Id"]);
                        user.customerId = Convert.ToInt32(row["CustomerId"]);
                        user.firstName = row["FirstName"].ToString();
                        user.lastName = row["LastName"].ToString();
                        user.email = row["Email"].ToString();
                    }
                }
            }

            return user;
        }

        public List<string> ListCustomerUsers(DataTable dt)
        {
            List<string> customers = new List<string>();

            DataRow[] dr = dt.Select("UserType= 'Customer'");

            if (dr.Length > 0)
            {
                foreach (DataRow row in dr)
                {
                    customers.Add(row["FirstName"].ToString() + " " + row["LastName"].ToString());
                }
            }

            return customers;
        }

        public bool RegisterCustomer(User user, DataTable dt)
        {
            bool userAdded = false;
            DataRow newUser = dt.NewRow();

            newUser["Id"] = user.id;
            newUser["CustomerId"] = user.customerId;
            newUser["FirstName"] = user.firstName;
            newUser["LastName"] = user.lastName;
            newUser["Email"] = user.email;
            newUser["UserType"] = userType.Customer;

            try
            {
                dt.Rows.Add(newUser);
                userAdded = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return userAdded;
        }
    }
}
