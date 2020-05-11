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
	/// Provides a Transfer entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * حوالات
	 */
	public class Transfer : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type Transfer.
		/// </summary>
		public Transfer()
		{
			this.ChildTranslatedTransfers = new HashSet<Transfer>();
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
		public decimal Amount { get; set; }
		public string Description { get; set; }


		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyTransferId { get; set; }
		public virtual Transfer ParentKeyTransfer { get; set; }

 
		public virtual ICollection<Transfer> ChildTranslatedTransfers { get; set; }
		#endregion

		#endregion
	}
}
