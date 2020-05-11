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
    /// Provides a InventoryOutputType entity.
    /// </summary>
    [DebuggerDisplay("Id={Id}, Name={Name}")]
    /*
	 * @EntityDescription: 
	 * نوع الاهلاك
	 */
    public class InventoryOutputType : IEntityIdentity<long>, IEntityDateTimeSignature
    {
        #region Data Members

        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type InventoryOutputType.
        /// </summary>
        public InventoryOutputType()
        {
            this.InventoryMovements = new HashSet<InventoryMovement>();
            this.ChildTranslatedInventoryOutputTypes = new HashSet<InventoryOutputType>();
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



        public virtual ICollection<InventoryMovement> InventoryMovements { get; set; }


        #region Translation Functionality
        public Language? Language { get; set; }

        public long? ParentKeyInventoryOutputTypeId { get; set; }
        public virtual InventoryOutputType ParentKeyInventoryOutputType { get; set; }


        public virtual ICollection<InventoryOutputType> ChildTranslatedInventoryOutputTypes { get; set; }
        #endregion

        #endregion
    }
}

