#region Using ...
using Framework.Common.Enums;
using Framework.Core.Models.ViewModels.Base;
using MersalAccountingService.Core.Models.ViewModels.JournalEntries;
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
	public class InventoryMovementViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type InventoryMovementViewModel.
        /// </summary>
        public InventoryMovementViewModel()
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

        public string Code { get; set; }
		public Nullable<DateTime> Date { get; set; }
		public string Description { get; set; }
        public long ReferenceNumber { get; set; }

        public virtual Nullable<long> InventoryId { get; set; }
        public virtual InventoryViewModel Inventory { get; set; }

        public Nullable<long> InventoryMovementTypeId { get; set; }
        public virtual InventoryMovementTypeViewModel InventoryMovementType { get; set; }

        public long? OutgoingTypeId { get; set; }
        public virtual InventoryMovementTypeViewModel OutgoingType { get; set; }

        public string BillNumber { get; set; }

        public virtual long? VendorId { get; set; }
        public virtual VendorViewModel Vendor { get; set; }


        public virtual IList<InventoryDifferenceViewModel> InventoryDifferences { get; set; }

        public AddJournalEntriesViewModel Journal { get; set; }



        #region Translation Functionality
        public Language? Language { get; set; }

        public long? ParentKeyInventoryMovementId { get; set; }
        public InventoryMovementViewModel ParentKeyInventoryMovement { get; set; }


        public IList<InventoryMovementViewModel> ChildTranslatedInventoryMovements { get; set; }
        #endregion

        #endregion
    }
}
