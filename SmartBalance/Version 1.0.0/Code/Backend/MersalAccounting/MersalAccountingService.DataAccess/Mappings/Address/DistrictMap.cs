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
	public class DistrictMap : EntityTypeConfiguration<District>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// DistrictMap.
		/// </summary>
		public DistrictMap()
		{
			#region Configure Relations For Foreign Key ParentKeyDistrictId
			this.HasMany(entity => entity.ChildTranslatedDistricts)
					.WithOptional(entity => entity.ParentKeyDistrict)
					.HasForeignKey(entity => entity.ParentKeyDistrictId);
			#endregion
		}
		#endregion
	}
}
