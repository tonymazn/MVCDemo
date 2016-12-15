using System;

namespace SamplesData.PagingClasses
{
  public class Pager
  {
    #region Constructor
    public Pager()
    {
      Init();
    }

    public Pager(int pageSize)
    {
      Init();

      PageSize = pageSize;
    }
    #endregion

    #region Init Method
    public void Init()
    {
      PageSize = 5;
      PageIndex = 0;
      StartingRow = 1;
      TotalPages = 0;
      TotalRecords = 0;
    }
    #endregion

    #region Public Properties
    /// <summary>
    /// Get/Set the page size selected
    /// </summary>
    private int _PageSize = 0;
    public int PageSize
    {
      get { return _PageSize; }
      set
      {
        _PageSize = value;
        CalculateTotalPages();
      }
    }
    /// <summary>
    /// Get/Set the Current Page Index
    /// </summary>
    public int PageIndex { get; set; }
    /// <summary>
    /// Get/set the row to start at
    /// </summary>
    public int StartingRow { get; set; }
    /// <summary>
    /// Get/Set the total number of pages
    /// </summary>
    public int TotalPages { get; set; }
    /// <summary>
    /// Get/Set the total records read
    /// </summary>
    private int _TotalRecords = 0;
    public int TotalRecords
    {
      get { return _TotalRecords; }
      set
      {
        _TotalRecords = value;
        CalculateTotalPages();
      }
    }
    #endregion

    #region CalculateTotalPages Method
    public void CalculateTotalPages()
    {
      if (PageSize > 0)
      {
        TotalPages = Convert.ToInt32(
                      Math.Ceiling(
                         Convert.ToDecimal(TotalRecords) /
                         Convert.ToDecimal(PageSize)));       
      }
    }
    #endregion

    #region SetPagerProperties Method
    public void SetPagerProperties(string argument)
    {
      int page = -1;

      if (int.TryParse(argument, out page))
      {
        this.PageIndex = page;
      }
      else
      {
        switch (argument)
        {
          case PagerCommands.First:
            this.PageIndex = 0;
            break;

          case PagerCommands.Next:
            if (this.PageIndex < this.TotalPages)
            {
              this.PageIndex++;
            }
            break;

          case PagerCommands.Previous:
            if (this.PageIndex != 0)
            {
              this.PageIndex--;
            }
            break;

          case PagerCommands.Last:
            this.PageIndex = this.TotalPages - 1;
            break;
        }
      }

      StartingRow = (PageIndex * PageSize);
    }
    #endregion
  }
}
