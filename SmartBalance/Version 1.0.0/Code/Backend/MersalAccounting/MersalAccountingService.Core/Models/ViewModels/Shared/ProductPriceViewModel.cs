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
	public class ProductPriceViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type ProductPriceViewModel.
        /// </summary>
        public ProductPriceViewModel()
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

		public string Name { get; set; }
		public Nullable<long> ProductId { get; set; }
		public virtual ProductViewModel Product { get; set; }
		public decimal Price { get; set; }
		public Nullable<decimal> Discount { get; set; }
		public bool IsOriginalPrice { get; set; }
		public string Description { get; set; }



		#region Translation Functionality
		public Language? Language { get; set; }

        public long? ParentKeyProductPriceId { get; set; }
        public ProductPriceViewModel ParentKeyProductPrice { get; set; }


        public IList<ProductPriceViewModel> ChildTranslatedProductPrices { get; set; }
        #endregion

        #endregion
    }
}
