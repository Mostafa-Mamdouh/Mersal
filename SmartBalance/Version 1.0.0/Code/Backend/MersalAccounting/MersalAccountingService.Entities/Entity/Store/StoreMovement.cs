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
    /// 
    /// </summary>
    [DebuggerDisplay("Id={Id}, Name={Name}")]
    public class StoreMovement : IEntityIdentity<long>, IEntityDateTimeSignature, IEntityUserSignature
    {
        #region Data Members

        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type StoreMovement.
        /// </summary>
        public StoreMovement()
        {
            this.ChildTranslatedStoreMovements = new HashSet<StoreMovement>();
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

        #region IEntityUserSignature		
        public long? CreatedByUserId { get; set; }
        public long? FirstModifiedByUserId { get; set; }
        public long? LastModifiedByUserId { get; set; }
        #endregion

        #region IPostingSignature
        public bool IsPosted { get; set; }
        public DateTime? PostingDate { get; set; }
        public long? PostedByUserId { get; set; }
        #endregion

        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }


        #region Translation Functionality
        public Language? Language { get; set; }

        public long? ParentKeyStoreMovementId { get; set; }
        public virtual StoreMovement ParentKeyStoreMovement { get; set; }

        public virtual ICollection<StoreMovement> ChildTranslatedStoreMovements { get; set; }
        #endregion

        #endregion
    }
}
