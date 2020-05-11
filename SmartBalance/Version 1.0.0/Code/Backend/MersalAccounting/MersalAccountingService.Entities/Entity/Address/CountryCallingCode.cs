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
	/// Provides a CountryCallingCode entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * كود نداء الدولة
	 */
	public class CountryCallingCode : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type CountryCallingCode.
		/// </summary>
		public CountryCallingCode()
		{
			this.Mobiles = new HashSet<Mobile>();
			this.ChildTranslatedCountryCallingCodes = new HashSet<CountryCallingCode>();
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
		public Nullable<long> CountryId { get; set; }
		public virtual Country Country { get; set; }
		public virtual ICollection<Mobile> Mobiles { get; set; }
		public string Code { get; set; }


		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyCountryCallingCodeId { get; set; }
		public virtual CountryCallingCode ParentKeyCountryCallingCode { get; set; }


		public virtual ICollection<CountryCallingCode> ChildTranslatedCountryCallingCodes { get; set; }
		#endregion

		#endregion
	}
}
