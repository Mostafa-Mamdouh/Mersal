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
	/// Provides a Journal entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Code={Code}, Date={Date}, IsReversed={IsReversed}, Transactions={Transactions.Count()}")]
	/*
	 * @EntityDescription: 
	 * قيود اليومية
	 */
	public class Journal : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type Journal.
		/// </summary>
		public Journal()
		{
            this.ChildTranslatedJournals = new HashSet<Journal>();
            this.Transactions = new HashSet<Transaction>();
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
       
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public MovementType? MovementType { get; set; }
        public long? ObjectId { get; set; }
        public bool IsAutomaticPosting { get; set; }
        public bool IsBulkPosting { get; set; }

        public bool IsReversed { get; set; }
        public long? ReversedFromId { get; set; }
        public long? ReversedToId { get; set; }

        public PostingStatus PostingStatus { get; set; }


        public virtual ICollection<Transaction> Transactions { get; set; }

        #region Translation Functionality
        public Language? Language { get; set; }

        public long? ParentKeyJournalId { get; set; }
        public virtual Journal ParentKeyJournal { get; set; }


        public virtual ICollection<Journal> ChildTranslatedJournals { get; set; }
        #endregion

        #endregion
    }
}
