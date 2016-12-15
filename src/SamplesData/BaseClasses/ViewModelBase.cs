using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using SamplesData.PagingClasses;

namespace SamplesData.BaseClasses
{
  public class ViewModelBase
  {
    #region Constructor
    public ViewModelBase()
    {
      Init();
    }
    #endregion

    #region Public Properties
    /// <summary>
    /// Get/Set the current sort direction
    /// </summary>
    public SortDirection SortDirection { get; set; }
    /// <summary>
    /// Get/Set the new sort direction
    /// </summary>
    public SortDirection SortDirectionNew { get; set; }
    /// <summary>
    /// Get/Set the current column you wish to sort on
    /// </summary>
    public string SortExpression { get; set; }
    /// <summary>
    /// Get/Set the last column you sorted on
    /// </summary>
    public string LastSortExpression { get; set; }
    /// <summary>
    /// Get/Set the Pager object
    /// </summary>
    public Pager Pager { get; set; }
    /// <summary>
    /// Get/Set whether or not the pager is visible
    /// </summary>
    public bool IsPagerVisible { get; set; }
    /// <summary>
    /// Get/Set the page collection
    /// </summary>
    public PagerItemCollection Pages { get; set; }
    /// <summary>
    /// Get/Set the current command executed on the client-side
    /// </summary>
    public string EventCommand { get; set; }
    /// <summary>
    /// Get/Set any parameters for the current command executed. This could be a page number for paging, etc.
    /// </summary>
    public string EventArgument { get; set; }
    /// <summary>
    /// Get/Set whether or not the view model is in a valid state
    /// </summary>
    public bool IsValid { get; set; }
    /// <summary>
    /// Get/Set the mode we are in
    /// </summary>
    public string Mode { get; set; }
    /// <summary>
    /// Get/Set whether or not the Search area is visible
    /// </summary>
    public bool IsSearchAreaVisible { get; set; }
    /// <summary>
    /// Get/Set whether or not the Detail area is visible
    /// </summary>
    public bool IsDetailAreaVisible { get; set; }
    /// <summary>
    /// Get/Set whether or not the Grid area is visible
    /// </summary>
    public bool IsGridAreaVisible { get; set; }
    #endregion

    #region Init Method
    public virtual void Init()
    {
      Pager = new Pager();
      IsPagerVisible = true;
      Pages = new PagerItemCollection(Pager.TotalRecords, Pager.PageSize, Pager.PageIndex);
      
      EventCommand = string.Empty;
      EventArgument = string.Empty;

      EventCommand = string.Empty;
      SortExpression = string.Empty;
      LastSortExpression = string.Empty;
      SortDirection = SortDirection.Ascending;

      Mode = "Normal";
      IsSearchAreaVisible = true;
      IsGridAreaVisible = true;
      IsDetailAreaVisible = false;
      IsValid = true;
    }
    #endregion
    
    #region SetSortDirection Method
    protected virtual void SetSortDirection()
    {
      if (SortExpression == LastSortExpression)
      {
        if (SortDirection == SortDirection.Ascending)
          SortDirection = SortDirection.Descending;
        else
          SortDirection = SortDirection.Ascending;
      }
      else
      {
        SortDirection = SortDirectionNew;
      }
    }
    #endregion
    
    #region Sort Method
    protected virtual List<T> Sort<T>(IQueryable<T> list)
    {
      string orderby = SortExpression;

      // NOTE: Using System.Linq.Dynamic DLL
      list = list.OrderBy(SortExpression +
        (SortDirection == SortDirection.Ascending ? " ASC" : " DESC"));

      return list.ToList();
    }
    #endregion

    #region HandleRequest Method
    public virtual void HandleRequest()
    {
    }
    #endregion
    
    #region AddMode Method
    public virtual void AddMode()
    {
      IsDetailAreaVisible = true;
      IsGridAreaVisible = false;
      IsSearchAreaVisible = false;

      Mode = "Add";
    }
    #endregion

    #region EditMode Method
    public virtual void EditMode()
    {
      IsDetailAreaVisible = true;
      IsGridAreaVisible = false;
      IsSearchAreaVisible = false;

      Mode = "Edit";
    }
    #endregion

    #region NormalMode Method
    public virtual void NormalMode()
    {
      IsValid = true;
      IsDetailAreaVisible = false;
      IsGridAreaVisible = true;
      IsSearchAreaVisible = true;

      Mode = "Normal";
    }
    #endregion

    #region ResetSearch Method
    public virtual void ResetSearch()
    {
      Pager.PageIndex = 0;
      Pager.StartingRow = 0;
    }
    #endregion

    #region SetModeAfterValidation Method
    public virtual void SetModeAfterValidation()
    {
      if (IsValid)
      {
        NormalMode();
      }
      else
      {
        if (Mode == "Edit")
          EditMode();
        else
          AddMode();
      }
    }
    #endregion
    
    #region SetPagerObject Method
    protected virtual void SetPagerObject(int totalRecords)
    {
      // Set Pager Information
      Pager.TotalRecords = totalRecords;
      Pager.SetPagerProperties(EventArgument);

      // Build paging collection
      Pages = new PagerItemCollection(Pager.TotalRecords, Pager.PageSize, Pager.PageIndex);
      // Set total pages
      Pager.TotalPages = Pages.PageCount;
    }
    #endregion
  }
}
