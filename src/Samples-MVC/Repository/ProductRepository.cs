using System.Collections.Generic;
using nHibernateMapping.Domain;
using NHibernate.Criterion;

namespace Repository
{
    public class ProductRepository
    {
        public static ICollection<Product> GetAll()
        {
            using (NHibernate.ISession session = SessionFactory.GetNewSession())
            {
                return session.CreateCriteria(typeof(Product)).List<Product>();
            }

        }


        public static Product FindById(int productId)
        {
            using (NHibernate.ISession session = SessionFactory.GetNewSession())
            {
                return session.CreateCriteria(typeof(Product)).Add(Restrictions.Like("ProductId", productId)).FutureValue<Product>().Value;
            }

        }


        public static int Add(Product student)
        {
            int result;
            using (NHibernate.ISession session = SessionFactory.GetNewSession())
            {
                using (NHibernate.ITransaction transaction = session.BeginTransaction())
                {
                    result = (int)session.Save(student);
                    transaction.Commit();
                }
            }
            return result;
        }

        public static void Delete(Product student)
        {
            using (NHibernate.ISession session = SessionFactory.GetNewSession())
            {
                using (NHibernate.ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(student);
                    transaction.Commit();
                }
            }
        }

        public static int GetProductCount()
        {
            using (NHibernate.ISession session = SessionFactory.GetNewSession())
            {
                return session.CreateCriteria(typeof(Product)).SetProjection(Projections.RowCount()).FutureValue<int>().Value;
            }
        }

        public static ICollection<Product> GetProductsByWildcard(string productName)
        {
            using (NHibernate.ISession session = SessionFactory.GetNewSession())
            {
                var searchCriteria = session.CreateCriteria(typeof(Product));
                searchCriteria.Add(Expression.Sql(string.Format("ProductName like '%{0}%'", productName)));
                return searchCriteria.List<Product>();
            }
        }

        public static ICollection<Product> GetPaging(int page, int maxResule)
        {
            using (NHibernate.ISession session = SessionFactory.GetNewSession())
            {
                 return session.CreateCriteria(typeof(Product)).SetFirstResult(page).SetMaxResults(maxResule).List<Product>();
            }

        }
    }
}
