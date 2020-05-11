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
	public class ExchangeBondsMap : EntityTypeConfiguration<ExchangeBonds>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// ExchangeBondsMap.
		/// </summary>
		public ExchangeBondsMap()
		{
			#region Configure Relations For Foreign Key ParentKeyExchangeBondsId
			this.HasMany(entity => entity.ChildTranslatedExchangeBondss)
					.WithOptional(entity => entity.ParentKeyExchangeBonds)
					.HasForeignKey(entity => entity.ParentKeyExchangeBondsId);
			#endregion
		}
		#endregion
	}
}
