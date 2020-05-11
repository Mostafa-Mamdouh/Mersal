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

namespace MersalAccountingService.Core.Models.ViewModels.LightViewModels
{
	/// <summary>
	/// Provides a lite model for entity 
	/// BankMovement, and this lite model 
	/// do not contains a children 
	/// relations for speeding up the 
	/// retrivement process.
	/// </summary>
	[DebuggerDisplay("Id={Id}")]
	public class BankMovementLightViewModel : BaseViewModel
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type BankMovementLightViewModel.
		/// </summary>
		public BankMovementLightViewModel()
		{

		}
		#endregion

		#region Properties

		#region IEntityIdentity<T>
		public long Id { get; set; }
		#endregion

		#region IEntityDateTime
		public DateTime CreationDate { get; set; }
		public DateTime? FirstModificationDate { get; set; }
		public DateTime? LastModificationDate { get; set; }
		#endregion

		#region IEntityUserSignature		
		public long? CreatedByUserId { get; set; }
		public long? FirstModifiedByUserId { get; set; }
		public long? LastModifiedByUserId { get; set; }
        #endregion

        #region IPostingSignature
        public bool IsPosted { get; set; }
        public DateTime? PostingDate { get; set; }
        public long? PostedByUserId { get; set; }
        #endregion

        public string Code { get; set; }
		public Nullable<DateTime> Date { get; set; }
		public decimal Amount { get; set; }
		public string Description { get; set; }
        public string RemittanceVoucherNumber { get; set; }

        public string DescriptionAr { get; set; }
		public string DescriptionEn { get; set; }

		public long? BankId { get; set; }
		public virtual BankLightViewModel Bank { get; set; }

		public long? JournalTypeId { get; set; }
		public virtual JournalTypeLightViewModel JournalType { get; set; }

		public long? ToBankId { get; set; }
		public virtual BankLightViewModel ToBank { get; set; }

		public long? AccountChartId { get; set; }
		public virtual AccountChartLightViewModel AccountChart { get; set; }

		public long? SafeId { get; set; }
		public virtual SafeLightViewModel Safe { get; set; }		

		#endregion
	}
}
