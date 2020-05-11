#region Using ...
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
	/// 
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	public class TranactionDetails :IEntityIdentity<long>, IEntityDateTimeSignature
    {
        #region Data Members

        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type Transaction.
        /// </summary>
        public TranactionDetails()
        {
            //this.ChildTranslatedTransactions = new HashSet<Transaction>();
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
        //public bool IsCreditor { get; set; }

        //دائن+ 
        public long FromObjectId { get; set; } //customer
        public string FromObjectType { get; set; }
        //مدين-
        public long? ToObjectId { get; set; } //case
        public string ToObjectType { get; set; }

        public long TransactionId { get; set; }
        public virtual Transaction Transaction { get; set; }
        #endregion
    }
}
