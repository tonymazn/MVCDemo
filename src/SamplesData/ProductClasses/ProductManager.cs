using System.Collections.Generic;
using System.Linq;
using nHibernateMapping.Domain;
using Repository;

namespace SamplesData.ProductClasses
{
  public class ProductManager
  {
    #region GetProducts Method
    /// <summary>
    /// Get all Products from Product table
    /// </summary>
    /// <returns>A List of Product objects</returns>
    public List<Product> GetProducts()
    {
      return ProductRepository.GetAll().ToList();
    }
    #endregion

    #region GetProducts (Sorted) Method
    /// <summary>
    /// Get all Products from Product table
    /// </summary>
    /// <returns>A List of Product objects</returns>
    public List<Product> GetProducts(string sortOrder, string sortDirection)
    {
      return GetProducts(sortOrder, sortDirection, null);
    }

    public List<Product> GetProducts(string sortOrder, SortDirection sortDirection)
    {
      return GetProducts(sortOrder,
        (sortDirection == SortDirection.Ascending ? "ASC" : "DESC").ToString(), null);
    }

    /// <summary>
    /// Get all Products from Product table
    /// </summary>
    /// <returns>A List of Product objects</returns>
    public List<Product> GetProducts(string sortOrder, string sortDirection, Product entity)
    {
        return ProductRepository.GetProductsByWildcard(entity.ProductName).ToList();
    }
    #endregion

    #region GetProducts (Server-Side Paging) Method
    /// <summary>
    /// Get all Products from Product table
    /// </summary>
    /// <returns>A List of Product objects</returns>
    public List<Product> GetProducts(int pageIndex,
      int pageSize)
    {
      return GetProducts(pageIndex, pageSize, "ProductName", " ASC");
    }

    public List<Product> GetProducts(int pageIndex,
      int pageSize,
      string sortOrder,
      SortDirection sortDirection)
    {
      return GetProducts(pageIndex, pageSize,
        sortOrder,
        (sortDirection == SortDirection.Ascending ? "ASC" : "DESC").ToString());
    }

    /// <summary>
    /// Get all Products from Product table
    /// </summary>
    /// <returns>A List of Product objects</returns>
    public List<Product> GetProducts(int pageIndex,
      int pageSize,
      string sortOrder,
      string sortDirection)
    {
        return ProductRepository.GetPaging(pageIndex, pageSize).ToList();
    }
    #endregion

      #region GetProductsCount Method
    public int GetProductsCount()
    {
        return ProductRepository.GetProductCount();
    }
    #endregion

    #region GetProduct Method
    /// <summary>
    /// Get a single Product from the Product table
    /// </summary>
    /// <param name="productId">A Product ID to find</param>
    /// <returns>A Product object</returns>
    public Product GetProduct(int productId)
    {
        return ProductRepository.FindById(productId);
    }
    #endregion

    #region Insert Method
    /// <summary>
    /// Insert a new Product
    /// </summary>
    /// <param name="entity">The product to insert</param>
    /// <returns>True if successful, false otherwise</returns>
    public bool Insert(Product entity)
    {
      bool ret = false;

      ret = Validate(entity);

      if (ret)
      {
          ProductRepository.Add(entity);
      }

      return ret;
    }
    #endregion

    #region Update Method
    /// <summary>
    /// Update an Existing Product
    /// </summary>
    /// <param name="entity">The product to update</param>
    /// <returns>True if successful, false otherwise</returns>
    public bool Update(Product entity)
    {
      bool ret = false;

      ret = Validate(entity);

      if (ret)
      {
        /// TODO: Create UPDATE code here
      }

      return ret;
    }
    #endregion

    #region Delete Method
    /// <summary>
    /// Delete an Existing Product
    /// </summary>
    /// <param name="entity">The product to delete</param>
    /// <returns>True if successful, false otherwise</returns>
    public bool Delete(Product entity)
    {
      /// TODO: Create DELETE code here
      return true;
    }
    #endregion

    #region Validate Method
    public bool Validate(Product entity)
    {
      // TODO: Perform other validation logic here
      // This is for any validation not accomplished
      // using the data annotations on the Product class

      return true;
    }
    #endregion
  }
}
