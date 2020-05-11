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
	public class FiscalYearViewModel : BaseViewModel
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type FiscalYearViewModel.
		/// </summary>
		public FiscalYearViewModel()
		{

		}
		#endregion

		#region Properties

		#region IEntityIdentity<T>
		public long Id { get; set; }
		#endregion

		#region IEntityDateTimeSignature
		public DateTime CreationDate { get; set; }
		public DateTime? FirstModificationDate { get; set; }
		public DateTime? LastModificationDate { get; set; }
		#endregion

		public string Name { get; set; }
		public DateTime? From { get; set; }
		public DateTime? To { get; set; }
		public string Description { get; set; }


		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyFiscalYearId { get; set; }
		public FiscalYearViewModel ParentKeyFiscalYear { get; set; }


		public IList<FiscalYearViewModel> ChildTranslatedFiscalYears { get; set; }
		#endregion

		#endregion
	}
}
