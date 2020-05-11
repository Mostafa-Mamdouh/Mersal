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
	public class MeasurementUnitMap : EntityTypeConfiguration<MeasurementUnit>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// MeasurementUnitMap.
		/// </summary>
		public MeasurementUnitMap()
		{
			#region Configure Relations For Foreign Key ParentKeyMeasurementUnitId
			this.HasMany(entity => entity.ChildTranslatedMeasurementUnits)
					.WithOptional(entity => entity.ParentKeyMeasurementUnit)
					.HasForeignKey(entity => entity.ParentKeyMeasurementUnitId);
			#endregion
		}
		#endregion
	}
}
