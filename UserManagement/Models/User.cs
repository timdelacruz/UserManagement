using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Models
{
    public class User
    {
        public int id { get; set; }

        public int adminId { get; set; }

        public int customerId { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string email { get; set; }

        public string address { get; set; }

        public string phone { get; set; }

        public enum userType
        {
            Admin,
            Customer,
            Merchant
        }
    }
}
