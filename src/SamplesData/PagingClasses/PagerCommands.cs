
namespace SamplesData.PagingClasses
{
  /// <summary>
  /// This class contains Pager commands for moving through a pager.
  /// It also contains the Text for displaying pager information.
  /// </summary>
  public class PagerCommands
  {
    static PagerCommands()
    {
      FirstTooltipText = "First Page";
      PreviousTooltipText = "Previous Page";
      NextTooltipText = "Next Page";
      LastTooltipText = "Last Page";

      FirstText = "&laquo;";
      PreviousText = "&lsaquo;";
      NextText = "&rsaquo;";
      LastText = "&raquo;";

      PageText = "Page";
    }

    public const string First = "first";
    public const string Next = "next";
    public const string Previous = "prev";
    public const string Last = "last";

    public static string FirstTooltipText { get; set; }
    public static string NextTooltipText { get; set; }
    public static string PreviousTooltipText { get; set; }
    public static string LastTooltipText { get; set; }
    
    public static string FirstText { get; set; }
    public static string NextText { get; set; }
    public static string PreviousText { get; set; }
    public static string LastText { get; set; }
    
    public static string PageText { get; set; }
  }
}
