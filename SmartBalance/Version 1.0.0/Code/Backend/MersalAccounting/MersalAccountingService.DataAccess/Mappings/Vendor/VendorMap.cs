#region Using ...
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.DataAccess.Mappings
{
	public class VendorMap : EntityTypeConfiguration<Vendor>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// VendorMap.
		/// </summary>
		public VendorMap()
		{
			#region Configure Relations For Foreign Key ParentKeyVendorId
			this.HasMany(entity => entity.ChildTranslatedVendors)
					.WithOptional(entity => entity.ParentKeyVendor)
					.HasForeignKey(entity => entity.ParentKeyVendorId);
			#endregion
		}
		#endregion
	}
}
