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
	/// Provides a JournalType entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * قيود اليومية
	 */
	public class JournalType : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type JournalType.
		/// </summary>
		public JournalType()
		{
			this.ChildTranslatedJournalTypes = new HashSet<JournalType>();
			this.BankMovements = new HashSet<BankMovement>();
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
		public string Code { get; set; }


		public virtual ICollection<BankMovement> BankMovements { get; set; }

		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyJournalTypeId { get; set; }
		public virtual JournalType ParentKeyJournalType { get; set; }


		public virtual ICollection<JournalType> ChildTranslatedJournalTypes { get; set; }
		#endregion

		#endregion
	}
}
