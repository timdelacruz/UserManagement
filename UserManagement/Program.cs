using System;
using UserManagement.Models;
using UserManagement.Methods;
using System.Data;

namespace UserManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Essentials essen = new Essentials();
            DataTable dt = new DataTable("Users");

            essen.CreateDataTable(dt);
            essen.SelectAction(dt);
        }
    }
}
