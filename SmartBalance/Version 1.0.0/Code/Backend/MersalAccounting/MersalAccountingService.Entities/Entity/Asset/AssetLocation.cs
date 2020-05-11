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
	/// Provides a AssetLocation entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Date={Date}")]
	/*
	 * @EntityDescription: 
	 * اماكن الاصول
	 */
	public class AssetLocation : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type AssetLocation.
		/// </summary>
		public AssetLocation()
		{
			this.ChildTranslatedAssetLocations = new HashSet<AssetLocation>();
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


		public virtual long? AssetId { get; set; }
		public virtual Asset Asset { get; set; }


		public long? LocationId { get; set; }
		public virtual Location Location { get; set; }


		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyAssetLocationId { get; set; }
		public virtual AssetLocation ParentKeyAssetLocation { get; set; }


		public virtual ICollection<AssetLocation> ChildTranslatedAssetLocations { get; set; }
		#endregion

		#endregion
	}
}
