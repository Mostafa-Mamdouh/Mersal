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
	public class StoreMeasurementUnitMap : EntityTypeConfiguration<StoreMeasurementUnit>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// StoreMeasurementUnitMap.
		/// </summary>
		public StoreMeasurementUnitMap()
		{
			#region Configure Relations For Foreign Key ParentKeyStoreMeasurementUnitId
			this.HasMany(entity => entity.ChildTranslatedStoreMeasurementUnits)
					.WithOptional(entity => entity.ParentKeyStoreMeasurementUnit)
					.HasForeignKey(entity => entity.ParentKeyStoreMeasurementUnitId);
			#endregion
		}
		#endregion
	}
}
