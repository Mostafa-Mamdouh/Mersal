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
	/// Provides a Mobile entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * المحمول
	 */
	public class Mobile : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type Mobile.
		/// </summary>
		public Mobile()
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
		public string Number { get; set; }
		public bool IsMain { get; set; }
		public ObjectType ObjectType { get; set; }
		public long ObjectId { get; set; }
		public bool IsActive { get; set; }
		public Nullable<long> CountryCallingCodeId { get; set; }
		public virtual CountryCallingCode CountryCallingCode { get; set; }


		

		#endregion
	}
}
