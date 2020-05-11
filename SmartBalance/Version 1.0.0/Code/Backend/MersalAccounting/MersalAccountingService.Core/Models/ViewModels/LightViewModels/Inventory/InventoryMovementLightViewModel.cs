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
	/// InventoryMovement, and this lite model 
	/// do not contains a children 
	/// relations for speeding up the 
	/// retrivement process.
	/// </summary>
	[DebuggerDisplay("Id={Id}")]
	public class InventoryMovementLightViewModel : BaseViewModel
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type InventoryMovementLightViewModel.
		/// </summary>
		public InventoryMovementLightViewModel()
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

        #region IPostingSignature
        public bool IsPosted { get; set; }
        public DateTime? PostingDate { get; set; }
        public long? PostedByUserId { get; set; }
        #endregion

		public Nullable<DateTime> InventroryDate { get; set; }
		public string Description { get; set; }

        public string Code { get; set; }
        public string Inventory { get; set; }
        public long ReferenceNumber { get; set; }
        public string InventoryMovementType { get; set; }
        public DateTime? Date { get; set; }

        public string BillNumber { get; set; }

        public virtual long? VendorId { get; set; }
        public virtual VendorLightViewModel Vendor { get; set; }


        #region Translation Functionality
        public Language? Language { get; set; }

		public long? ParentKeyInventoryMovementId { get; set; }
		public InventoryMovementLightViewModel ParentKeyInventoryMovement { get; set; }		
		#endregion

		#endregion
	}
}
