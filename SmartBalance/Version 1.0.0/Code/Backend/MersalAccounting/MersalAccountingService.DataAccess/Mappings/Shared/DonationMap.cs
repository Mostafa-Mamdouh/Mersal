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
	public class DonationMap : EntityTypeConfiguration<Donation>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// DonationMap.
		/// </summary>
		public DonationMap()
		{
			#region Configure Relations For Foreign Key ParentKeyDonationId
			this.HasMany(entity => entity.ChildTranslatedDonations)
					.WithOptional(entity => entity.ParentKeyDonation)
					.HasForeignKey(entity => entity.ParentKeyDonationId);
			#endregion
		}
		#endregion
	}
}
