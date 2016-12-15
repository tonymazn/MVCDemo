using System;
using System.Collections.Generic;
using System.Linq;
using nHibernateMapping.Domain;
using SamplesData.BaseClasses;
using SamplesData.ProductClasses;

namespace SamplesData
{
  public class ProductMaintenanceViewModel : ViewModelBase
  {
    #region Constructor
    public ProductMaintenanceViewModel()
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
    /// Get/Set a Single Product Entity
    /// </summary>
    public Product Entity { get; set; }
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
          ResetSearch();
          ProductNameSearch = string.Empty;
          // Get Products
          GetProducts();
          break;

        case "add":
          Add();
          break;

        case "edit":
          Edit();
          break;

        case "delete":
          ResetSearch();
          Delete();
          break;

        case "save":
          Save();
          break;

        case "cancel":
          NormalMode();
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

    #region Add Method
    private void Add()
    {
      // Initialize Entity Object
      Entity = new Product();
      Entity.IntroductionDate = DateTime.Now;
      Entity.Cost = 0;
      Entity.Price = 0;

      // Put ViewModel into Add Mode
      AddMode();
    }
    #endregion

    #region Edit Method
    private void Edit()
    {
      ProductManager mgr = new ProductManager();

      // Get Product Data
      Entity = mgr.GetProduct(Convert.ToInt32(EventArgument));

      // Put View Model into Edit Mode
      EditMode();
    }
    #endregion

    #region Delete Method
    private void Delete()
    {
      ProductManager mgr = new ProductManager();

      // Create new entity
      Entity = new Product();
      // Get primary key from EventArgument
      Entity.ProductId = Convert.ToInt32(EventArgument);
      // Call data layer to delete record
      mgr.Delete(Entity);
      // Have to reset EventArgument to empty
      // for paging to be reset
      EventArgument = string.Empty;

      // Reload the Data
      GetProducts();

      NormalMode();
    }
    #endregion

    #region Save Method
    private void Save()
    {
      ProductManager mgr = new ProductManager();

      // Save data here
      if (Mode == "Edit")
      {
        IsValid = mgr.Update(Entity);
      }
      else
      {
        IsValid = mgr.Insert(Entity);
      }

      // Set mode after validation
      SetModeAfterValidation();

      // if valid, then re-load data
      if (IsValid)
      {
        // Get Products
        GetProducts();
      }
    }
    #endregion

    #region GetProduct Method
    public void GetProduct(int productId)
    {
      ProductManager mgr = new ProductManager();

      Entity = mgr.GetProduct(productId);

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
