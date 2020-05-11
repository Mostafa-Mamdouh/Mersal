#region Using ...
using Framework.Common.Enums;
using Framework.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Entities.Entity
{
	/// <summary>
	/// Provides a Country entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * الدولة
	 */
	public class Country : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type Country.
		/// </summary>
		public Country()
		{
			this.Cities = new HashSet<City>();
			this.CountryCallingCodes = new HashSet<CountryCallingCode>();
			this.ChildTranslatedCountrys = new HashSet<Country>();
		}
		#endregion

		#region Properties

		#region IEntityIdentity<T>
		public long Id { get; set; }
		#endregion

		#region IEntityDateTime
		public DateTime CreationDate { get; set; }
		public DateTime? FirstModificationDate { get; set; }
		public DateTime? LastModificationDate { get; set; }
		#endregion

		public string Name { get; set; }
		public virtual ICollection<City> Cities { get; set; }
		public string Code { get; set; }
		public virtual ICollection<CountryCallingCode> CountryCallingCodes { get; set; }


		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyCountryId { get; set; }
		public virtual Country ParentKeyCountry { get; set; }


		public virtual ICollection<Country> ChildTranslatedCountrys { get; set; }
		#endregion

		#endregion
	}
}
