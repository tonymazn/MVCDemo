using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using DemoProduct.Controllers;
using NUnit.Framework;

namespace DemoProduct.Test
{
    [TestFixture]
    public class HomeControllerTests
    {
        private HomeController controller = new HomeController();

        [Test]
        public void ShouldLoadTheIndexPage()
        {
            var result =(ViewResult)controller.Index();

            Assert.That(result.ViewName, Is.EqualTo("Index"));
        }
    }
}
