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
	public class StockAssessmentPolicyMap : EntityTypeConfiguration<StockAssessmentPolicy>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// StockAssessmentPolicyMap.
		/// </summary>
		public StockAssessmentPolicyMap()
		{
			#region Configure Relations For Foreign Key ParentKeyStockAssessmentPolicyId
			this.HasMany(entity => entity.ChildTranslatedStockAssessmentPolicys)
					.WithOptional(entity => entity.ParentKeyStockAssessmentPolicy)
					.HasForeignKey(entity => entity.ParentKeyStockAssessmentPolicyId);
			#endregion
		}
		#endregion
	}
}
