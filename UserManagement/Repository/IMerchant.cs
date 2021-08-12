using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using UserManagement.Models;

namespace UserManagement.Repository
{
    public interface IMerchant
    {
        public bool RegisterMerchant(User user, DataTable dt);

        public List<string> ListMerchantUsers(DataTable dt);

        public User GetMerchantUser(int id, DataTable dt);
    }
}
