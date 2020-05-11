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
	public class TransferMap : EntityTypeConfiguration<Transfer>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// TransferMap.
		/// </summary>
		public TransferMap()
		{
			#region Configure Relations For Foreign Key ParentKeyTransferId
			this.HasMany(entity => entity.ChildTranslatedTransfers)
					.WithOptional(entity => entity.ParentKeyTransfer)
					.HasForeignKey(entity => entity.ParentKeyTransferId);
			#endregion
		}
		#endregion
	}
}
