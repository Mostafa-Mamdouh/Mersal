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
	public class DonationTypeMap : EntityTypeConfiguration<DonationType>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// DonationTypeMap.
		/// </summary>
		public DonationTypeMap()
		{
			#region Configure Relations For Foreign Key ParentKeyDonationTypeId
			this.HasMany(entity => entity.ChildTranslatedDonationTypes)
					.WithOptional(entity => entity.ParentKeyDonationType)
					.HasForeignKey(entity => entity.ParentKeyDonationTypeId);
			#endregion
		}
		#endregion
	}
}
