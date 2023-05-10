using kursovik;
using kursovik.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using NUnit.Framework;
using System.Data.SqlClient;
using Assert = NUnit.Framework.Assert;
using System.ComponentModel.DataAnnotations;

namespace kursovik.Tests.Controllers
{
   

    [TestFixture]
    public class UnitTest1
    {
       
        [Test]
        public void IndexViewResult()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

        [Test]
        public void IndexViewEqualIndexCshtml()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }


    }
}
