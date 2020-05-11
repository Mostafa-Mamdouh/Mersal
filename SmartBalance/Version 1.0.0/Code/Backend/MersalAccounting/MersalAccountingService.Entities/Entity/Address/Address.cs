#region Using ...
using Framework.Common.Enums;
using Framework.Common.Interfaces;
using MersalAccountingService.Common.Enums;
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
	/// Provides a Address entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * العنوان
	 */
	public class Address : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type Address.
		/// </summary>
		public Address()
		{

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

		public long ObjectId { get; set; }
        public ObjectType ObjectType { get; set; }

		public Nullable<long> DistrictId { get; set; }
		public virtual District District { get; set; }

		public string Street { get; set; }
		public string BuildingNo { get; set; }
		public string Floor { get; set; }
		public string LandMark { get; set; }
		public string Description { get; set; }

        public bool IsActive { get; set; }
        public bool IsMain { get; set; }

		#endregion
	}
}
