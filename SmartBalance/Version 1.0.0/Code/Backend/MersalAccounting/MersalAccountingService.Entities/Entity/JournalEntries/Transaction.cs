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
	/// Provides a Transaction entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Amount={Amount}, IsCreditor={IsCreditor}, AccountChartId={AccountChartId}")]
	/*
	 * @EntityDescription: 
	 * المعاملات
	 */
	public class Transaction : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type Transaction.
		/// </summary>
		public Transaction()
		{
			//this.ChildTranslatedTransactions = new HashSet<Transaction>();
			//this.TransactionTranslations = new HashSet<TransactionTranslation>();
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

		//public string Name { get; set; }

		public decimal Amount { get; set; }
		public bool IsCreditor { get; set; }

		//Description
		public string DescriptionAR { get; set; }
		public string DescriptionEN { get; set; }

		//دائن+ 
		//public long FromObjectId { get; set; } //customer
		//public string FromObjectType { get; set; }
		//مدين-
		//public long? ToObjectId { get; set; } //case
		//public string ToObjectType { get; set; }

		public ObjectType? ObjectType { get; set; }
		public long? ObjectId { get; set; }


		public long? AccountChartId { get; set; }
		public virtual AccountChart AccountChart { get; set; }


		public long? JournalId { get; set; }
		public virtual Journal Journal { get; set; }


		public long? CostCenterId { get; set; }
		public virtual CostCenter CostCenter { get; set; }

		// public virtual ICollection<TransactionTranslation> TransactionTranslations { get; set; }


		//      #region Translation Functionality
		//      public Language? Language { get; set; }

		//public long? ParentKeyTransactionId { get; set; }
		//public virtual Transaction ParentKeyTransaction { get; set; }



		//      public virtual ICollection<Transaction> ChildTranslatedTransactions { get; set; }
		//#endregion

		#endregion
	}
}
