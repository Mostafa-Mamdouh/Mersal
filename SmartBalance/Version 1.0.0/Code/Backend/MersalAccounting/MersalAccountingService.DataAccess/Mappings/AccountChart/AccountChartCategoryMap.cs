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
	public class AccountChartCategoryMap : EntityTypeConfiguration<AccountChartCategory>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// AccountChartCategoryMap.
		/// </summary>
		public AccountChartCategoryMap()
		{
			#region Configure Relations For Foreign Key ParentKeyAccountChartCategoryId
			this.HasMany(entity => entity.ChildTranslatedAccountChartCategorys)
					.WithOptional(entity => entity.ParentKeyAccountChartCategory)
					.HasForeignKey(entity => entity.ParentKeyAccountChartCategoryId);
			#endregion
		}
		#endregion
	}
}
