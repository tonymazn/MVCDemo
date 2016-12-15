
using System.Web.Mvc;
using DemoProduct.Controllers;
using NUnit.Framework;
using SamplesData;

namespace DemoProduct.Test
{
    [TestFixture]
    public class ProductControllerTests
    {
        private ProductController controller = new ProductController();

        [Test]
        public void ShouldLoadSearchAndGridPage()
        {
            var result = (ViewResult)controller.SearchAndGrid();
            Assert.That(result.ViewName, Is.EqualTo(""));
            Assert.That(result.Model,Is.Not.Null);
        }

        [Test]
        public void WhenPostBack_ShouldDoTheSearch()
        {
            var result = (ViewResult)controller.SearchAndGrid(new MaintenanceViewModel01());
            Assert.That(result.ViewName, Is.EqualTo(""));
            Assert.That(result.Model, Is.Not.Null);
        }

        [Test]
        public void ShouldLoadDetailPage()
        {
            var result = (ViewResult)controller.Detail();
            Assert.That(result.ViewName, Is.EqualTo(""));
            Assert.That(result.Model, Is.Not.Null);
        }

        [Test]
        public void WhenPostBack_ShouldShowTheDetail()
        {
            var result = (ViewResult)controller.Detail(new MaintenanceViewModel02());
            Assert.That(result.ViewName, Is.EqualTo(""));
            Assert.That(result.Model, Is.Not.Null);
        }

        [Test]
        public void ShouldLoadEditPage()
        {
            var result = (ViewResult)controller.Edit();
            Assert.That(result.ViewName, Is.EqualTo(""));
            Assert.That(result.Model, Is.Not.Null);
        }

        [Test]
        public void WhenPostBack_ShouldShowTheEdit()
        {
            var result = (ViewResult)controller.Edit(new ProductMaintenanceViewModel());
            Assert.That(result.ViewName, Is.EqualTo(""));
            Assert.That(result.Model, Is.Not.Null);
        }

        [Test]
        public void ShouldLoadMaintenancePage()
        {
            var result = (ViewResult)controller.Maintenance();
            Assert.That(result.ViewName, Is.EqualTo(""));
            Assert.That(result.Model, Is.Not.Null);
        }

        [Test]
        public void WhenPostBack_ShouldShowTheMaintenance()
        {
            var result = (ViewResult)controller.Edit(new ProductMaintenanceViewModel());
            Assert.That(result.ViewName, Is.EqualTo(""));
            Assert.That(result.Model, Is.Not.Null);
        }


    }
}
