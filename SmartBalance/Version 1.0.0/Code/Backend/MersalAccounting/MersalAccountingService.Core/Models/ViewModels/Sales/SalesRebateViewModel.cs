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
	public class SalesRebateViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type SalesRebateViewModel.
        /// </summary>
        public SalesRebateViewModel()
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

        #region 

        public bool IsPosted { get; set; }
        public DateTime? PostingDate { get; set; }
        public long? PostedByUserId { get; set; }
        #endregion

        public string Name { get; set; }
		public string Description { get; set; }
		public virtual IList<SalesRebateProductViewModel> SalesRebateProducts { get; set; }



		#region Translation Functionality
		public Language? Language { get; set; }

        public long? ParentKeySalesRebateId { get; set; }
        public SalesRebateViewModel ParentKeySalesRebate { get; set; }


        public IList<SalesRebateViewModel> ChildTranslatedSalesRebates { get; set; }
        #endregion

        #endregion
    }
}
