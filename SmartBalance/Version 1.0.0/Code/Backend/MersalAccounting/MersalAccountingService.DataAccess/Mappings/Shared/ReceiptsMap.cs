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
	public class ReceiptsMap : EntityTypeConfiguration<Receipts>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// ReceiptsMap.
		/// </summary>
		public ReceiptsMap()
		{
			#region Configure Relations For Foreign Key ParentKeyReceiptsId
			this.HasMany(entity => entity.ChildTranslatedReceiptss)
					.WithOptional(entity => entity.ParentKeyReceipts)
					.HasForeignKey(entity => entity.ParentKeyReceiptsId);
			#endregion
		}
		#endregion
	}
}
