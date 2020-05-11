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
	public class BranchViewModel : BaseViewModel
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type BranchViewModel.
		/// </summary>
		public BranchViewModel()
		{

		}
		#endregion

		#region Properties

		#region IEntityIdentity<T>
		public int Id { get; set; }
		#endregion

		#region IEntityDateTime
		public DateTime CreationDate { get; set; }
		public DateTime? FirstModificationDate { get; set; }
		public DateTime? LastModificationDate { get; set; }
		#endregion

		public string Name { get; set; }
		public string Code { get; set; }
		public string Description { get; set; }
		public DateTime? Date { get; set; }


		public string NameAr { get; set; }
		public string NameEn { get; set; }

		public string DescriptionAr { get; set; }
		public string DescriptionEn { get; set; }


		//public IList<DonationViewModel> Donations { get; set; }
		//public IList<PaymentMovmentViewModel> PaymentMovments { get; set; }
		//public IList<SafeViewModel> Safes { get; set; }



		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyBranchId { get; set; }
		public BranchViewModel ParentKeyBranch { get; set; }


		public IList<BranchViewModel> ChildTranslatedBranchs { get; set; }
		#endregion

		#endregion
	}
}
