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
	public class AccountChartGroupMap : EntityTypeConfiguration<AccountChartGroup>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// AccountChartGroupMap.
		/// </summary>
		public AccountChartGroupMap()
		{
			#region Configure Relations For Foreign Key ParentKeyAccountChartGroupId
			this.HasMany(entity => entity.ChildTranslatedAccountChartGroups)
					.WithOptional(entity => entity.ParentKeyAccountChartGroup)
					.HasForeignKey(entity => entity.ParentKeyAccountChartGroupId);
			#endregion
		}
		#endregion
	}
}
