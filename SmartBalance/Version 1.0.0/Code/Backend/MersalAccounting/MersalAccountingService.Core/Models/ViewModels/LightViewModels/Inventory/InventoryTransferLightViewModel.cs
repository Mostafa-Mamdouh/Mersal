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
	/// InventoryTransfer, and this lite model 
	/// do not contains a children 
	/// relations for speeding up the 
	/// retrivement process.
	/// </summary>
	[DebuggerDisplay("Id={Id}")]
	public class InventoryTransferLightViewModel : BaseViewModel
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type InventoryTransferLightViewModel.
		/// </summary>
		public InventoryTransferLightViewModel()
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

        public string Code { get; set; }
        public string Description { get; set; }

        public string InventoryFrom { get; set; }

        public string InventoryTo { get; set; }
        public DateTime? Date { get; set; }

        #region Translation Functionality
        public Language? Language { get; set; }

		public long? ParentKeyInventoryTransferId { get; set; }
		public InventoryTransferLightViewModel ParentKeyInventoryTransfer { get; set; }		
		#endregion

		#endregion
	}
}
