#region Using ...
using Framework.Common.Enums;
using Framework.Core.Models.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Core.Models.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    [DebuggerDisplay("Id={Id}")]
    public class DiscountPercentageViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type DiscountPercentageViewModel.
        /// </summary>
        public DiscountPercentageViewModel()
        {

        }
        #endregion        

        #region Properties

        #region IEntityIdentity<T>
        public long Id { get; set; }
        #endregion

        #region IEntityDateTime
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreationDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? FirstModificationDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? LastModificationDate { get; set; }
		#endregion

		public float? Percentage { get; set; }
		public string Name { get; set; }       
        public string Description { get; set; }

        public string DescriptionAr { get; set; }

        public string DescriptionEn { get; set; }



        #region Translation Functionality
        public Language? Language { get; set; }

        public long? ParentKeyDiscountPercentageId { get; set; }
        public DiscountPercentageViewModel ParentKeyDiscountPercentage { get; set; }


        //public IList<DiscountPercentageViewModel> ChildTranslatedDiscountPercentages { get; set; }
        #endregion

        #endregion
    }
}
