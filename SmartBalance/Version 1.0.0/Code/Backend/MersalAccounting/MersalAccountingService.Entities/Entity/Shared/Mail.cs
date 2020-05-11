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
	/// Provides a Mail entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * البريد الالكترونى
	 */
	public class Mail : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type Mail.
		/// </summary>
		public Mail()
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

		public string Email { get; set; }
		public long ObjectId { get; set; }
		public ObjectType ObjectType { get; set; }
		public bool IsMain { get; set; }
		public bool IsActive { get; set; }
		public bool IsVerified { get; set; }



		#endregion
	}
}
