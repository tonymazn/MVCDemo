using System;
using System.ComponentModel.DataAnnotations;

namespace nHibernateMapping.Domain
{
    public class Product :IEntity
    {
        public virtual int ProductId { get; set; }

        [Required(ErrorMessage = "Product Name must be filled in.")]
        [Display(Description = "Product Name")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Product Name must be greater than {2} characters and less than {1} characters.")]
        public virtual string ProductName { get; set; }

        [Range(typeof(DateTime), "1/1/2000", "12/31/2020",
          ErrorMessage = "Introduction Date must be between {1} and {2}")]
        public virtual DateTime IntroductionDate { get; set; }

        [Range(0, 9999, ErrorMessage = "{0} must be between {1} and {2}")]
        public virtual decimal Cost { get; set; }

        [Range(1, 9999, ErrorMessage = "{0} must be between {1} and {2}")]
        public virtual decimal Price { get; set; }

        public virtual bool IsDiscontinued { get; set; }

        #region ToString Override
        public override string ToString()
        {
            return ProductName;
        }
        #endregion
    }
}
