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
    /// Provides a AccountChartCategory entity.
    /// </summary>
    [DebuggerDisplay("Id={Id}, Name={Name}")]
    /*
     * @EntityDescription: 

     */
    public class AccountChartCategory : IEntityIdentity<long>, IEntityDateTimeSignature
    {
        #region Data Members

        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type AccountChartCategory.
        /// </summary>
        public AccountChartCategory()
        {
            this.ChildTranslatedAccountChartCategorys = new HashSet<AccountChartCategory>();
            this.AccountCharts = new HashSet<AccountChart>();
            //this.Safes = new HashSet<Safe>();
            //this.GeneralAccounts = new HashSet<GeneralAccount>();
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

        public virtual ICollection<AccountChart> AccountCharts { get; set; }



        #region Translation Functionality
        public Language? Language { get; set; }

        public long? ParentKeyAccountChartCategoryId { get; set; }
        public virtual AccountChartCategory ParentKeyAccountChartCategory { get; set; }

        public virtual ICollection<AccountChartCategory> ChildTranslatedAccountChartCategorys { get; set; }
        #endregion

        #endregion
    }
}
