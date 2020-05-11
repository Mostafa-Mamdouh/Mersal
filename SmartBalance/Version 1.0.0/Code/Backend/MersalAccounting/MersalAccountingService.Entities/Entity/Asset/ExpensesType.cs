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
    /// Provides a ExpensesType entity.
    /// </summary>
    [DebuggerDisplay("Id={Id}, Name={Name}")]
    /*
	 * @EntityDescription: 
	 * نوع الاهلاك
	 */
    public class ExpensesType : IEntityIdentity<long>, IEntityDateTimeSignature
    {
        #region Data Members

        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type ExpensesType.
        /// </summary>
        public ExpensesType()
        {
            this.Expenses = new HashSet<Expense>();
            this.ChildTranslatedExpensesTypes = new HashSet<ExpensesType>();
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

        public string Code { get; set; }
        public string Name { get; set; }       
        public string Description { get; set; }



        public virtual ICollection<Expense> Expenses { get; set; }


        #region Translation Functionality
        public Language? Language { get; set; }

        public long? ParentKeyExpensesTypeId { get; set; }
        public virtual ExpensesType ParentKeyExpensesType { get; set; }


        public virtual ICollection<ExpensesType> ChildTranslatedExpensesTypes { get; set; }
        #endregion

        #endregion
    }
}
