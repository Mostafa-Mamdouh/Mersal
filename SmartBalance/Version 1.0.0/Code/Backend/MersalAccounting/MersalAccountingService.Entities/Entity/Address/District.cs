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
	/// Provides a District entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * الحى
	 */
	public class District : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type District.
		/// </summary>
		public District()
		{
			this.Addresses = new HashSet<Address>();
			this.ChildTranslatedDistricts = new HashSet<District>();
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
		public virtual ICollection<Address> Addresses { get; set; }
		public Nullable<long> CityId { get; set; }
		public virtual City City { get; set; }
		public string Description { get; set; }


		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyDistrictId { get; set; }
		public virtual District ParentKeyDistrict { get; set; }

 
		public virtual ICollection<District> ChildTranslatedDistricts { get; set; }
		#endregion

		#endregion
	}
}
