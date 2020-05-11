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
	public class ReceivingMethodMap : EntityTypeConfiguration<ReceivingMethod>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// ReceivingMethodMap.
		/// </summary>
		public ReceivingMethodMap()
		{
			#region Configure Relations For Foreign Key ParentKeyReceivingMethodId
			this.HasMany(entity => entity.ChildTranslatedReceivingMethods)
					.WithOptional(entity => entity.ParentKeyReceivingMethod)
					.HasForeignKey(entity => entity.ParentKeyReceivingMethodId);
			#endregion
		}
		#endregion
	}
}
