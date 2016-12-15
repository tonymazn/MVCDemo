using System.Collections.Generic;
using System.Linq;
using nHibernateMapping.Domain;
using SamplesData.BaseClasses;
using SamplesData.ProductClasses;
//using Microsoft.Build.Tasks.Deployment.Bootstrapper;

namespace SamplesData
{
  public class MaintenanceViewModel01 : ViewModelBase
  {
    #region Constructor
    public MaintenanceViewModel01()
      : base()
    {
      Products = new List<Product>();

      // Set initial sort expression
      SortExpression = "ProductName";
      SortDirection = SortDirection.Ascending;
      EventCommand = "page";
    }
    #endregion

    #region Public Properties
    /// <summary>
    /// Get/Set the collection of Products
    /// </summary>
    public List<Product> Products { get; set; }
    /// <summary>
    /// Get/Set the product name to search for
    /// </summary>
    public string ProductNameSearch { get; set; }
    #endregion

    #region HandleRequest Method
    public override void HandleRequest()
    {
      base.HandleRequest();

      if (EventCommand == "sort")
      {
        // Check to see if we need to change the sort order 
        // because the sort expression changed
        SetSortDirection();
      }

      switch (EventCommand.ToLower())
      {
        case "page":
          GetProducts();
          break;

        case "search":
          Pager.PageIndex = 0;
          GetProducts();
          break;

        case "resetsearch":
          Pager.PageIndex = 0;
          ProductNameSearch = string.Empty;
          // Get Products
          GetProducts();
          break;

        default:
          // Get Products
          GetProducts();
          break;
      }

      // Build paging info & get current page of records
      if (Products.Count > 0)
      {
        // Setup Pager Object
        SetPagerObject(Products.Count);

        GetProductsByPage();
      }
    }
    #endregion
  
    #region GetProducts Method
    public void GetProducts()
    {
      ProductManager mgr = new ProductManager();
      Product entity = new Product();

      entity.ProductName = ProductNameSearch;
      Products = mgr.GetProducts(SortExpression,
        (SortDirection == SortDirection.Ascending ? "ASC" : "DESC"),
        entity);
    }
    #endregion

    #region GetProductsByPage Method
    private void GetProductsByPage()
    {
      IQueryable<Product> query;

      // Put list of products into queryable item
      query = Products.AsQueryable<Product>();

      // Extract rows for the page requested
      query = query.Skip(Pager.StartingRow).Take(Pager.PageSize);
      // Put extracted rows into Products collection
      Products = new List<Product>(query.ToList<Product>());
    }
    #endregion
  }
}
