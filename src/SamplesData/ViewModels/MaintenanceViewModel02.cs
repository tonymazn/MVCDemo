using System;
using nHibernateMapping.Domain;
using SamplesData.BaseClasses;
using SamplesData.ProductClasses;

namespace SamplesData
{
  public class MaintenanceViewModel02 : ViewModelBase
  {
    #region Constructor
    public MaintenanceViewModel02()
      : base()
    {
    }
    #endregion

    #region Public Properties
    /// <summary>
    /// Get/Set a Single Product Entity
    /// </summary>
    public Product Entity { get; set; }
    #endregion

    #region HandleRequest Method
    public override void HandleRequest()
    {
      base.HandleRequest();

      switch (EventCommand.ToLower())
      {
        case "add":
          Add();
          break;

        case "save":
          Save();
          break;
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
      //Save();
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
    }
    #endregion
  }
}
