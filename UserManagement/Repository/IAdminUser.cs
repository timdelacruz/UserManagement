using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Models;

namespace UserManagement.Repository
{
    public interface IAdminUser
    {
        public bool RegisterAdmin(User user, DataTable dt);

        public List<string> ListAdminUsers(DataTable dt);

        public User GetAdminUser(int id, DataTable dt);

    }
}
