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
	/// Provides a Receipts entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * سندات القبض
	 */
	public class Receipts : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type Receipts.
		/// </summary>
		public Receipts()
		{
			this.ChildTranslatedReceiptss = new HashSet<Receipts>();
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
		public string Description { get; set; }
		public decimal Amount { get; set; }


		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyReceiptsId { get; set; }
		public virtual Receipts ParentKeyReceipts { get; set; }


		public virtual ICollection<Receipts> ChildTranslatedReceiptss { get; set; }
		#endregion

		#endregion
	}
}
