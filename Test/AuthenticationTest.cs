using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;

namespace Test
{
    [TestClass]
    public class AuthenticationTest
    {
        [TestMethod]
        public void Authentication_Test()
        {
            // Arrange

            var _username = "kasparas";
            var _password = "kasparas";
            var _accountExists = true;

            // Act

            Authentication member = new Authentication(_username, _password);

            // Assert

            Assert.AreEqual(_accountExists, member.Authenticated);


        }
    }
}
