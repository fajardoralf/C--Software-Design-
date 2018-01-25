using Microsoft.VisualStudio.TestTools.UnitTesting;
using BazaarOfTheBizarre;

namespace BazaarOfTheBizarre_Test
{
    [TestClass]
    public class BazaarTest
    {
        [TestMethod]
        public void Customer_Test()
        {
            Customer customer = new Customer("Thor");

            string test = "Thor";

            string actual = customer.Name;


            Assert.AreEqual(test, actual);
        }
        [TestMethod]
        public void Runestone_Id_Test()
        {
            Runestone runestone = new Runestone(1);

            int test = 1;

            int actual = runestone.Id;


            Assert.AreEqual(test, actual);
        }
    }
}
