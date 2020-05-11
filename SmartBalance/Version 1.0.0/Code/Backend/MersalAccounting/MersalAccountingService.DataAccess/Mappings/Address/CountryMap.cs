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
	public class CountryMap : EntityTypeConfiguration<Country>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// CountryMap.
		/// </summary>
		public CountryMap()
		{
			#region Configure Relations For Foreign Key ParentKeyCountryId
			this.HasMany(entity => entity.ChildTranslatedCountrys)
					.WithOptional(entity => entity.ParentKeyCountry)
					.HasForeignKey(entity => entity.ParentKeyCountryId);
			#endregion
		}
		#endregion
	}
}
