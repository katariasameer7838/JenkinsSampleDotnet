using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nagarro.BookEvents.Main.Controllers;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Index()
        {

            //HomeController controller = new HomeController();
            AccountController controller = new AccountController();
            ViewResult result = controller.Login() as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}
