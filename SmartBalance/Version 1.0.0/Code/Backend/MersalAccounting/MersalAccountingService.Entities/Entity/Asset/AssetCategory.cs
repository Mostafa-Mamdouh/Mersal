#region Using ...
using Framework.Common.Enums;
using Framework.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Entities.Entity
{
	/// <summary>
	/// Provides a AssetCategory entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * فئات الاصول
	 */
	public class AssetCategory : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type AssetCategory.
		/// </summary>
		public AssetCategory()
		{
			this.Assets = new HashSet<Asset>();
			this.ChildTranslatedAssetCategorys = new HashSet<AssetCategory>();
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

		public string Name { get; set; }
		public string Description { get; set; }
		public virtual ICollection<Asset> Assets { get; set; }


		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyAssetCategoryId { get; set; }
		public virtual AssetCategory ParentKeyAssetCategory { get; set; }


		public virtual ICollection<AssetCategory> ChildTranslatedAssetCategorys { get; set; }
		#endregion

		#endregion
	}
}
