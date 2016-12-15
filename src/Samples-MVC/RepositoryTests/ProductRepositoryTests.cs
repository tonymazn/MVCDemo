using System;
using nHibernateMapping.Domain;
using NUnit.Framework;
using Repository;

namespace RepositoryTests
{
    [TestFixture]
    public class ProductRepositoryTests
    {
        [Test]
        public void GetAllTest()
        {
            var result = ProductRepository.GetAll();
            Assert.That(result.Count, Is.GreaterThan(0));
        }

        [Test]
        public void FindByIdTest()
        {
            var productId = ProductRepository.Add(new Product()
            {
                Cost = 123m,
                IntroductionDate = new DateTime(2000, 05, 06),
                IsDiscontinued = false,
                Price = 234m,
                ProductName = "ProductName"
            });

            var result = ProductRepository.FindById(productId);
            ProductRepository.Delete(result);
            Assert.That(result, Is.Not.Null);

        }

        [Test]
        public void DeleteTest()
        {
            var productId = ProductRepository.Add(new Product()
            {
                Cost = 123m,
                IntroductionDate = new DateTime(2000, 05, 06),
                IsDiscontinued = false,
                Price = 234m,
                ProductName = "ProductName"
            });

            var result = ProductRepository.FindById(productId);
            ProductRepository.Delete(result);
            result = ProductRepository.FindById(productId);
            Assert.That(result, Is.Null);


        }
    }
}
