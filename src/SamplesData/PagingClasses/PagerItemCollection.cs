using System;
using System.Collections.Generic;

namespace SamplesData.PagingClasses
{
  /// <summary>
  /// Class to hold a collection of pager items to display on a page
  /// </summary>
  public class PagerItemCollection : List<PagerItem>
  {
    #region Constructor
    public PagerItemCollection(int rowCount, int pageSize, int pageIndex)
    {
      // Calculate total pages based on RowCount and PageSize
      int pageCount = 0;
      
      pageCount = Convert.ToInt32(
                    Math.Ceiling(
                       Convert.ToDecimal(rowCount) /
                       Convert.ToDecimal(pageSize)));

      // Initialize the collection of pager items
      Init(pageCount, pageIndex);
    }
    #endregion

    #region Public Properties
    public int PageCount { get; set; }
    #endregion

    #region Init Method
    private void Init(int pageCount, int pageIndex)
    {
      int itemIndex = 0;

      PageCount = pageCount;

      Add(new PagerItem(PagerCommands.FirstText, 
                            PagerCommands.First,
                            (pageIndex == 0), PagerCommands.FirstTooltipText));
      itemIndex++;
      Add(new PagerItem(PagerCommands.PreviousText, 
                            PagerCommands.Previous,
                            (pageIndex == 0), PagerCommands.PreviousTooltipText));
      itemIndex++;

      for (int i = 0; i < PageCount; i++)
      {
        Add(new PagerItem(i, pageIndex, 
                              PagerCommands.PageText + " " + (i + 1).ToString()));
        itemIndex++;
      }

      Add(new PagerItem(PagerCommands.NextText, 
                            PagerCommands.Next,
                            (PageCount - 1 == pageIndex), PagerCommands.NextTooltipText));
      itemIndex++;
      Add(new PagerItem(PagerCommands.LastText, 
                            PagerCommands.Last,
                            (PageCount - 1 == pageIndex), PagerCommands.LastTooltipText));
    }
    #endregion
  }
}
