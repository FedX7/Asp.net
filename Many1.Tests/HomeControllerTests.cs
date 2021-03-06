﻿using System;
using System.Web.Mvc;
using Many1.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Many1.Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        private HomeController controller;
        private ViewResult result;

        [TestInitialize]
        public void SetupContext()
        {
            controller = new HomeController();
            result = controller.Index() as ViewResult;
        }

        [TestMethod]
        public void IndexViewResultNotNull()
        {
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IndexViewEqualIndexCshtml()
        {
            Assert.AreEqual("", result.ViewName);
        }

       
    }
}
