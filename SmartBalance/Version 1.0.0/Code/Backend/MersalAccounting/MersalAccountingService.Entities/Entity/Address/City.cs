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
	/// Provides a City entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * المدينة
	 */
	public class City : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type City.
		/// </summary>
		public City()
		{
			this.Districts = new HashSet<District>();
			this.ChildTranslatedCitys = new HashSet<City>();
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
		public virtual ICollection<District> Districts { get; set; }
		public bool IsCapital { get; set; }
		public string Description { get; set; }


		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyCityId { get; set; }
		public virtual City ParentKeyCity { get; set; }


		public virtual ICollection<City> ChildTranslatedCitys { get; set; }
		#endregion

		#endregion
	}
}
