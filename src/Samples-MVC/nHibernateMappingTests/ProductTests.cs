using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nHibernateMapping.Domain;
using NUnit.Framework;
using Repository;

namespace nHibernateMappingTests
{
    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void WhenInsertNewData_ShouldWork()
        {
            var product = new Product()
            {
                IntroductionDate = new DateTime(2000, 03, 04),
                IsDiscontinued = false,
                Price = 123.45m,
                ProductName = "ProductName"
            };

            var productId = ProductRepository.Add(product);
            ProductRepository.Delete( ProductRepository.FindById(productId));
        }
    }
}
