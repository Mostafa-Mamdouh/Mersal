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
	public class SalesRebateProductViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type SalesRebateProductViewModel.
        /// </summary>
        public SalesRebateProductViewModel()
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
		public Nullable<long> SalesRebateId { get; set; }
		public virtual SalesRebateViewModel SalesRebate { get; set; }
		public int Count { get; set; }
		public decimal Price { get; set; }
		public string Reason { get; set; }



		#region Translation Functionality
		public Language? Language { get; set; }

        public long? ParentKeySalesRebateProductId { get; set; }
        public SalesRebateProductViewModel ParentKeySalesRebateProduct { get; set; }


        public IList<SalesRebateProductViewModel> ChildTranslatedSalesRebateProducts { get; set; }
        #endregion

        #endregion
    }
}
