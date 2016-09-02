using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Tests
{
    [TestClass()]
    public class CustomerTests
    {
        [TestMethod()]
        public void WeakIsStrongPasswordTest()
        {
            Customer customer = new Customer();
            Boolean result = customer.IsStrongPassword("12345678");
            Assert.AreEqual(false, result, "Strong Passoword");
        }

        [TestMethod()]
        public void StrongIsStrongPasswordTest()
        {
            Customer customer = new Customer();
            Boolean result = customer.IsStrongPassword("Tj%12345678");
            Assert.AreEqual(true, result, "Weak Passoword");
        }
    }
}