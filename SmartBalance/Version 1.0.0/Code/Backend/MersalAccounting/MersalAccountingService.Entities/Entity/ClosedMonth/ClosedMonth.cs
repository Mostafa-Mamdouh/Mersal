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
    /// Provides a ClosedMonth entity.
    /// </summary>
    [DebuggerDisplay("Id={Id}, Name={Name}")]
    /*
	 * @EntityDescription: 
	 * 
	 */
    public class ClosedMonth : IEntityIdentity<long>, IEntityDateTimeSignature
    {
        #region Data Members

        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type ClosedMonth.
        /// </summary>
        public ClosedMonth()
        {
            this.ChildTranslatedClosedMonths = new HashSet<ClosedMonth>();
        }
        #endregion

        #region Properties

        #region IEntityIdentity<T>
        public long Id { get; set; }
        #endregion

        #region IEntityDateTimeSignature
        public DateTime CreationDate { get; set; }
        public DateTime? FirstModificationDate { get; set; }
        public DateTime? LastModificationDate { get; set; }
        #endregion

        public byte? Month { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public bool? IsClosed { get; set; }
        public long? ClosedByUserId { get; set; }
        public string Name { get; set; }      
        public string Description { get; set; }


        #region Translation Functionality
        public Language? Language { get; set; }

        public long? ParentKeyClosedMonthId { get; set; }
        public virtual ClosedMonth ParentKeyClosedMonth { get; set; }


        public virtual ICollection<ClosedMonth> ChildTranslatedClosedMonths { get; set; }
        #endregion

        #endregion
    }
}
