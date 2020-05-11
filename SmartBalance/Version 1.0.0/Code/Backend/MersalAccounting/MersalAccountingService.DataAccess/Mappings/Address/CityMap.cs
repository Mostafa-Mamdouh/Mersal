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
	public class CityMap : EntityTypeConfiguration<City>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// CityMap.
		/// </summary>
		public CityMap()
		{
			#region Configure Relations For Foreign Key ParentKeyCityId
			this.HasMany(entity => entity.ChildTranslatedCitys)
					.WithOptional(entity => entity.ParentKeyCity)
					.HasForeignKey(entity => entity.ParentKeyCityId);
			#endregion
		}
		#endregion
	}
}
