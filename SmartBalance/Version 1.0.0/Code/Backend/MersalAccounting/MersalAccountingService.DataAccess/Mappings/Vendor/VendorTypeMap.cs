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
	public class VendorTypeMap : EntityTypeConfiguration<VendorType>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// VendorTypeMap.
		/// </summary>
		public VendorTypeMap()
		{
			#region Configure Relations For Foreign Key ParentKeyVendorTypeId
			this.HasMany(entity => entity.ChildTranslatedVendorTypes)
					.WithOptional(entity => entity.ParentKeyVendorType)
					.HasForeignKey(entity => entity.ParentKeyVendorTypeId);
			#endregion
		}
		#endregion
	}
}
