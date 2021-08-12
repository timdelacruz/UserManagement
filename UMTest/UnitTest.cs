using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using UserManagement.Repository;
using UserManagement.Models;
using UserManagement.Methods;

namespace UMTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void AdminInsertTest()
        {
            DataTable dt = new DataTable();
            Essentials es = new Essentials();
            es.CreateDataTable(dt);

            User userInput = new User();
            User userOutput = new User();

            userInput.id = 1;
            userInput.adminId = 1;
            userInput.firstName = "Theo";
            userInput.lastName = "DC";
            userInput.email = "test@test.com";

            IAdminUser _admin = new AdminUser();
            var userAdded = _admin.RegisterAdmin(userInput, dt);

            if(userAdded)
            {
                userOutput = _admin.GetAdminUser(1, dt);

                Assert.AreEqual(userInput.id, userOutput.id);
                Assert.AreEqual(userInput.adminId, userOutput.adminId);
                Assert.AreEqual(userInput.firstName, userOutput.firstName);
                Assert.AreEqual(userInput.lastName, userOutput.lastName);
                Assert.AreEqual(userInput.email, userOutput.email);
            }
            else
            {
                Assert.AreEqual(userAdded, true);
            }

        }

        [TestMethod]
        public void CustomerInsertTest()
        {
            DataTable dt = new DataTable();
            Essentials es = new Essentials();
            es.CreateDataTable(dt);

            User userInput = new User();
            User userOutput = new User();

            userInput.id = 1;
            userInput.customerId = 1;
            userInput.firstName = "Theo";
            userInput.lastName = "DC";
            userInput.email = "test@test.com";

            ICustomer _customer = new Customer();
            var userAdded = _customer.RegisterCustomer(userInput, dt);

            if (userAdded)
            {
                userOutput = _customer.GetCustomerUser(1, dt);

                Assert.AreEqual(userInput.id, userOutput.id);
                Assert.AreEqual(userInput.customerId, userOutput.customerId);
                Assert.AreEqual(userInput.firstName, userOutput.firstName);
                Assert.AreEqual(userInput.lastName, userOutput.lastName);
                Assert.AreEqual(userInput.email, userOutput.email);
            }
            else
            {
                Assert.AreEqual(userAdded, true);
            }

        }

        [TestMethod]
        public void MerchantInsertTest()
        {
            DataTable dt = new DataTable();
            Essentials es = new Essentials();
            es.CreateDataTable(dt);

            User userInput = new User();
            User userOutput = new User();

            userInput.id = 1;
            userInput.firstName = "Theo";
            userInput.lastName = "DC";
            userInput.email = "test@test.com";
            userInput.address = "123 Queen Street";
            userInput.phone = "+61123456789";

            IMerchant _merchant = new Merchant();
            var userAdded = _merchant.RegisterMerchant(userInput, dt);

            if (userAdded)
            {
                userOutput = _merchant.GetMerchantUser(1, dt);

                Assert.AreEqual(userInput.id, userOutput.id);
                Assert.AreEqual(userInput.firstName, userOutput.firstName);
                Assert.AreEqual(userInput.lastName, userOutput.lastName);
                Assert.AreEqual(userInput.email, userOutput.email);
                Assert.AreEqual(userInput.address, userOutput.address);
                Assert.AreEqual(userInput.phone, userOutput.phone);
            }
            else
            {
                Assert.AreEqual(userAdded, true);
            }

        }
    }
}
