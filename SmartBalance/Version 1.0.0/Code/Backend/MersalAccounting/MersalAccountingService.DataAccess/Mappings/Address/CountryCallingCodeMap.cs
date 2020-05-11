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
	public class CountryCallingCodeMap : EntityTypeConfiguration<CountryCallingCode>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// CountryCallingCodeMap.
		/// </summary>
		public CountryCallingCodeMap()
		{
			#region Configure Relations For Foreign Key ParentKeyCountryCallingCodeId
			this.HasMany(entity => entity.ChildTranslatedCountryCallingCodes)
					.WithOptional(entity => entity.ParentKeyCountryCallingCode)
					.HasForeignKey(entity => entity.ParentKeyCountryCallingCodeId);
			#endregion
		}
		#endregion
	}
}
