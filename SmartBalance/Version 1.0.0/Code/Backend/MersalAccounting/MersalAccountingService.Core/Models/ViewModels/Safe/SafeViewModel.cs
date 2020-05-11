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
	public class SafeViewModel : BaseViewModel
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type SafeViewModel.
		/// </summary>
		public SafeViewModel()
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
		public string Code { get; set; }
		public string Description { get; set; }
		public DateTime? Date { get; set; }

		public string DisplyedName { get; set; }

		public string NameAr { get; set; }
		public string NameEn { get; set; }

		public string DescriptionAr { get; set; }
		public string DescriptionEn { get; set; }


		public decimal? OpeningCredit { get; set; }
        public bool? IsDebt { get; set; }


        public int? BranchId { get; set; }
		public virtual BranchViewModel Branch { get; set; }


        //public long? AccountChartId { get; set; }
        //public virtual AccountChartViewModel AccountChart { get; set; }

  //      public IList<BankMovementViewModel> BankMovements { get; set; }

		//public IList<PurchaseInvoiceViewModel> PurchaseInvoices { get; set; }
		//public IList<PurchaseRebateViewModel> PurchaseRebates { get; set; }

		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeySafeId { get; set; }
		public SafeViewModel ParentKeySafe { get; set; }


		public IList<SafeViewModel> ChildTranslatedSafes { get; set; }
		#endregion

		#endregion
	}
}
