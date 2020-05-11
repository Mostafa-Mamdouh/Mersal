//#region Using ...
//using Framework.Common.Enums;
//using Framework.Common.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//#endregion

//namespace MersalAccountingService.Entities.Entity
//{
//	/// <summary>
//	/// Provides a Transaction entity.
//	/// </summary>
//	[DebuggerDisplay("Id={Id}, Name={Name}")]
//	public class TransactionTranslation : IEntityIdentity<long>, IEntityDateTime
//	{
//		#region Data Members

//		#endregion

//		#region Constructors
//		/// <summary>
//		/// Initializes a new instance of 
//		/// type Transaction.
//		/// </summary>
//		public TransactionTranslation()
//		{

//            this.ChildTranslatedTransactionTranslations = new HashSet<TransactionTranslation>();

//        }
//		#endregion

//		#region Properties

//		#region IEntityIdentity<T>
//		public long Id { get; set; }
//		#endregion

//		#region IEntityDateTime
//		public DateTime CreationDate { get; set; }
//		public DateTime? FirstModificationDate { get; set; }
//		public DateTime? LastModificationDate { get; set; }
//        #endregion

//        //public string Name { get; set; }

//        public decimal Amount { get; set; }
//        public bool IsCreditor { get; set; }

//        //Description
//        public string Description { get; set; }

//        public long AccountChartId { get; set; }
//        public virtual AccountChart AccountChart { get; set; }


//        public long? JournalId { get; set; }
//        public virtual Journal Journal { get; set; }


//        public long? CostCenterId { get; set; }
//        public virtual CostCenter CostCenter { get; set; }

//        public long TransactionId { get; set; }
//        public virtual Transaction Transaction { get; set; }

//        #region Translation Functionality
//        public Language? Language { get; set; }
//        public long? ParentKeyTransactionTranslationId { get; set; }
//        public virtual TransactionTranslation ParentKeyTransactionTranslation { get; set; }
//        public virtual ICollection<TransactionTranslation> ChildTranslatedTransactionTranslations { get; set; }
//        #endregion

//        #endregion
//    }
//}
