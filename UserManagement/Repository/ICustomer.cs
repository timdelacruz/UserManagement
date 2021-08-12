using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using UserManagement.Models;

namespace UserManagement.Repository
{
    public interface ICustomer
    {
        public bool RegisterCustomer(User user, DataTable dt);

        public List<string> ListCustomerUsers(DataTable dt);

        public User GetCustomerUser(int id, DataTable dt);
    }
}
