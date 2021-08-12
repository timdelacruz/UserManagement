using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using UserManagement.Models;
using static UserManagement.Models.User;

namespace UserManagement.Repository
{
    public class Merchant : IMerchant
    {
        public User GetMerchantUser(int id, DataTable dt)
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
                        user.firstName = row["FirstName"].ToString();
                        user.lastName = row["LastName"].ToString();
                        user.email = row["Email"].ToString();
                        user.address = row["Address"].ToString();
                        user.phone = row["Phone"].ToString();
                    }
                }
            }

            return user;
        }

        public List<string> ListMerchantUsers(DataTable dt)
        {
            List<string> merchants = new List<string>();

            DataRow[] dr = dt.Select("UserType= 'Merchant'");

            if (dr.Length > 0)
            {
                foreach (DataRow row in dr)
                {
                    merchants.Add(row["FirstName"].ToString() + " " + row["LastName"].ToString());
                }
            }

            return merchants;
        }

        public bool RegisterMerchant(User user, DataTable dt)
        {
            bool userAdded = false;
            DataRow newUser = dt.NewRow();

            newUser["Id"] = user.id;
            newUser["FirstName"] = user.firstName;
            newUser["LastName"] = user.lastName;
            newUser["Email"] = user.email;
            newUser["Address"] = user.address;
            newUser["Phone"] = user.phone;
            newUser["UserType"] = userType.Merchant;

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
