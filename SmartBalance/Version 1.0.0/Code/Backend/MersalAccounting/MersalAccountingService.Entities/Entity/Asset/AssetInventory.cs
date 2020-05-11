#region Using ...
using Framework.Common.Enums;
using Framework.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
#endregion

namespace MersalAccountingService.Entities.Entity
{
	/// <summary>
	/// 
	/// </summary>
	[DebuggerDisplay("Id={Id}, Date={Date}, Location={Location}")]
	public class AssetInventory : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type Asset.
		/// </summary>
		public AssetInventory()
		{
			this.ChildTranslatedAssetInventorys = new HashSet<AssetInventory>();
			this.AssetInventoryDetails = new HashSet<AssetInventoryDetail>();
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


		public string Description { get; set; }

		public DateTime? Date { get; set; }


		public long? LocationId { get; set; }
		public virtual Location Location { get; set; }


		public virtual ICollection<AssetInventoryDetail> AssetInventoryDetails { get; set; }


		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyAssetInventoryId { get; set; }
		public virtual AssetInventory ParentKeyAssetInventory { get; set; }


		public virtual ICollection<AssetInventory> ChildTranslatedAssetInventorys { get; set; }
		#endregion

		#endregion
	}
}
