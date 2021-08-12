using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using UserManagement.Models;
using UserManagement.Repository;

namespace UserManagement.Methods
{
    public class Essentials
    {
        public void SelectAction(DataTable dt)
        {
            Console.WriteLine("Howdy!");
            Console.WriteLine("What are you after (enter the corresponding number)?");
            Console.WriteLine("1-Add User    2-Get User List    3-View User");
            var selectedAction = Console.ReadKey(true);

            switch (selectedAction.Key)
            {
                case ConsoleKey.D1:
                    AddUser(dt);
                    break;
                case ConsoleKey.D2:
                    ListUsers(dt);
                    break;
                case ConsoleKey.D3:
                    GetUserDetails(dt);
                    break;
                default:
                    Console.WriteLine("Exit application (Y/N)?");
                    var exitKey = Console.ReadKey(true);
                    if(exitKey.Key == ConsoleKey.N)
                    {
                        Console.Clear();
                        SelectAction(dt);
                    }
                    else if(exitKey.Key == ConsoleKey.Y)
                    {
                        Environment.Exit(0);
                    }
                    break;
            }
        }
        public void AddUser(DataTable dt)
        {
            Console.WriteLine("Select user type (enter the corresponding number):");
            Console.WriteLine("1-Admin    2-Customer   3-Merchant");
            var selectedUserType = Console.ReadKey(true);

            if (selectedUserType.Key == ConsoleKey.D1 || selectedUserType.Key == ConsoleKey.D2 || selectedUserType.Key == ConsoleKey.D3)
            {
                User newUser = new User();
                var userRegistered = false;

                //get id
                Console.WriteLine("Please enter the user's Id");
                newUser.id = Convert.ToInt32(Console.ReadLine());

                //get name
                Console.WriteLine("Please enter the user's first name");
                newUser.firstName = Console.ReadLine().ToString();
                Console.WriteLine("Please enter the user's last name");
                newUser.lastName = Console.ReadLine().ToString();

                //get email
                Console.WriteLine("Please enter the user's email");
                newUser.email = Console.ReadLine().ToString();

                switch (selectedUserType.Key)
                {
                    case ConsoleKey.D1:
                        //get adminId
                        Console.WriteLine("Please enter the user's Admin Id");
                        newUser.adminId = Convert.ToInt32(Console.ReadLine());

                        IAdminUser _adminUser = new AdminUser();
                        userRegistered = _adminUser.RegisterAdmin(newUser, dt);
                        break;
                    case ConsoleKey.D2:
                        //get adminId
                        Console.WriteLine("Please enter the user's customer Id");
                        newUser.customerId = Convert.ToInt32(Console.ReadLine());

                        ICustomer _customer = new Customer();
                        userRegistered = _customer.RegisterCustomer(newUser, dt);
                        break;
                    case ConsoleKey.D3:
                        //get name
                        Console.WriteLine("Please enter the user's address");
                        newUser.address = Console.ReadLine().ToString();
                        Console.WriteLine("Please enter the user's phone");
                        newUser.phone = Console.ReadLine().ToString();

                        IMerchant _merchant = new Merchant();
                        userRegistered = _merchant.RegisterMerchant(newUser, dt);
                        break;
                }

                if(userRegistered)
                {
                    Console.WriteLine("User registered!");
                    Console.WriteLine("Add another user (Y/N)?");
                    var addKey = Console.ReadKey(true);
                    if (addKey.Key == ConsoleKey.N)
                    {
                        Console.Clear();
                        SelectAction(dt);
                    }
                    else if (addKey.Key == ConsoleKey.Y)
                    {
                        Console.Clear();
                        AddUser(dt);
                    }
                }
                else
                {
                    Console.WriteLine("There was an issue registering the user, please try again.");
                    Console.Clear();
                    AddUser(dt);
                }
            }
            else
            {
                Console.WriteLine("Please select from the options.");
                Console.Clear();
                AddUser(dt);
            }
        }

        public void ListUsers(DataTable dt)
        {
            Console.WriteLine("Select user type (enter the corresponding number):");
            Console.WriteLine("1-Admin    2-Customer   3-Merchant");
            var selectedUserType = Console.ReadKey(true);

            if (selectedUserType.Key == ConsoleKey.D1 || selectedUserType.Key == ConsoleKey.D2 || selectedUserType.Key == ConsoleKey.D3)
            {
                List<string> userList = new List<string>();
                switch (selectedUserType.Key)
                {
                    case ConsoleKey.D1:
                        IAdminUser _adminUser = new AdminUser();
                        userList = _adminUser.ListAdminUsers(dt);
                        break;
                    case ConsoleKey.D2:
                        ICustomer _customer = new Customer();
                        userList = _customer.ListCustomerUsers(dt);
                        break;
                    case ConsoleKey.D3:
                        IMerchant _merchant = new Merchant();
                        userList = _merchant.ListMerchantUsers(dt);
                        break;
                }

                if(userList.Count > 0)
                {
                    userList.ForEach(Console.WriteLine);
                }
                else
                {
                    Console.WriteLine("There are currently no users of this type.");
                }

                Console.WriteLine("Return to start or Exit application (R/E)?");
                var returnKey = Console.ReadKey(true);
                if (returnKey.Key == ConsoleKey.R)
                {
                    Console.Clear();
                    SelectAction(dt);
                }
                else if (returnKey.Key == ConsoleKey.E)
                {
                    Environment.Exit(0);
                }

            }
            else
            {
                Console.WriteLine("Please select from the options.");
                Console.Clear();
                ListUsers(dt);
            }
        }

        public void GetUserDetails(DataTable dt)
        {
            Console.WriteLine("Select user type (enter the corresponding number):");
            Console.WriteLine("1-Admin    2-Customer   3-Merchant");
            var selectedUserType = Console.ReadKey(true);

            if (selectedUserType.Key == ConsoleKey.D1 || selectedUserType.Key == ConsoleKey.D2 || selectedUserType.Key == ConsoleKey.D3)
            {
                User user = new User();
                Console.WriteLine("Please enter the user's id.");
                var searchId = Console.ReadLine();

                if (Int32.TryParse(searchId, out int result))
                {
                    switch (selectedUserType.Key)
                    {
                        case ConsoleKey.D1:
                            IAdminUser _adminUser = new AdminUser();
                            user = _adminUser.GetAdminUser(result, dt);
                            break;
                        case ConsoleKey.D2:
                            ICustomer _customer = new Customer();
                            user = _customer.GetCustomerUser(result, dt);
                            break;
                        case ConsoleKey.D3:
                            IMerchant _merchant = new Merchant();
                            user = _merchant.GetMerchantUser(result, dt);
                            break;
                    }
                }
                else 
                {
                    Console.WriteLine("Please enter a numeric value.");
                    Console.Clear();
                    GetUserDetails(dt);
                }

                if(user != null)
                {
                    Console.WriteLine("Id: " + user.id);
                    Console.WriteLine("Firstname: " + user.firstName);
                    Console.WriteLine("Lastname: " + user.lastName);
                    Console.WriteLine("Email: " + user.email);

                    switch (selectedUserType.Key)
                    {
                        case ConsoleKey.D1:
                            Console.WriteLine("Admin Id: " + user.adminId);
                            break;
                        case ConsoleKey.D2:
                            Console.WriteLine("Customer Id: " + user.customerId);
                            break;
                        case ConsoleKey.D3:
                            Console.WriteLine("Address: " + user.address);
                            Console.WriteLine("Phone: " + user.phone);
                            break;
                    }

                    Console.WriteLine("Search for another user (Y/N)?");
                    var returnKey = Console.ReadKey(true);
                    if (returnKey.Key == ConsoleKey.Y)
                    {
                        Console.Clear();
                        GetUserDetails(dt);
                    }
                    else if (returnKey.Key == ConsoleKey.N)
                    {
                        Console.Clear();
                        SelectAction(dt);
                    }
                }
                else
                {
                    Console.WriteLine("There is no user with that Id. Please enter a different Id.");
                    Console.Clear();
                    GetUserDetails(dt);
                }
            }
            else
            {
                Console.WriteLine("Please select from the options.");
                Console.Clear();
                GetUserDetails(dt);
            }
        }

        public void CreateDataTable(DataTable dt)
        {
            DataColumn idCol = dt.Columns.Add("Id", typeof(Int32));
            idCol.AllowDBNull = false;
            idCol.Unique = true;

            dt.Columns.Add("AdminId", typeof(Int32));
            dt.Columns.Add("CustomerId", typeof(Int32));
            dt.Columns.Add("FirstName", typeof(String));
            dt.Columns.Add("LastName", typeof(String));
            dt.Columns.Add("Email", typeof(String));
            dt.Columns.Add("UserType", typeof(String));
            dt.Columns.Add("Address", typeof(String));
            dt.Columns.Add("Phone", typeof(String));
        }
    }
}
