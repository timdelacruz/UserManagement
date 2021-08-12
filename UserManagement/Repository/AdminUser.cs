using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Models;
using static UserManagement.Models.User;

namespace UserManagement.Repository
{
    public class AdminUser : IAdminUser
    {
        public User GetAdminUser(int id, DataTable dt)
        {
            User user = new User();
            if (dt.Rows.Count > 0)
            {
                DataRow[] dr = dt.Select("Id= " + id);

                if(dr.Length > 0)
                {
                    foreach (DataRow row in dr)
                    {
                        user.id = Convert.ToInt32(row["Id"]);
                        user.adminId = Convert.ToInt32(row["AdminId"]);
                        user.firstName = row["FirstName"].ToString();
                        user.lastName = row["LastName"].ToString();
                        user.email = row["Email"].ToString();
                    }
                }
            }

            return user;
        }

        public List<string> ListAdminUsers(DataTable dt)
        {
            List<string> admins = new List<string>();

            DataRow[] dr = dt.Select("UserType= 'Admin'");

            if (dr.Length > 0)
            {
                foreach (DataRow row in dr)
                {
                    admins.Add(row["FirstName"].ToString() + " " + row["LastName"].ToString());
                }
            }

            return admins;
        }

        public bool RegisterAdmin(User user, DataTable dt)
        {
            bool userAdded = false;
            DataRow newUser = dt.NewRow();

            newUser["Id"] = user.id;
            newUser["AdminId"] = user.adminId;
            newUser["FirstName"] = user.firstName;
            newUser["LastName"] = user.lastName;
            newUser["Email"] = user.email;
            newUser["UserType"] = userType.Admin;

            try 
            {
                dt.Rows.Add(newUser);
                userAdded = true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return userAdded;
        }
    }
}
