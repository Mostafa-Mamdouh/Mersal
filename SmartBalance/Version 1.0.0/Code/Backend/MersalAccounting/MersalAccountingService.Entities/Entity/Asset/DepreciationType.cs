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
    /// Provides a DepreciationType entity.
    /// </summary>
    [DebuggerDisplay("Id={Id}, Name={Name}")]
    /*
	 * @EntityDescription: 
	 * نوع الاهلاك
	 */
    public class DepreciationType : IEntityIdentity<long>, IEntityDateTimeSignature
    {
        #region Data Members

        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type DepreciationType.
        /// </summary>
        public DepreciationType()
        {
            this.Assets = new HashSet<Asset>();
            this.ChildTranslatedDepreciationTypes = new HashSet<DepreciationType>();
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
        public DepreciationTypeCodeEnum? DepreciationTypeCode { get; set; }
        public string Description { get; set; }



        public virtual ICollection<Asset> Assets { get; set; }


        #region Translation Functionality
        public Language? Language { get; set; }

        public long? ParentKeyDepreciationTypeId { get; set; }
        public virtual DepreciationType ParentKeyDepreciationType { get; set; }


        public virtual ICollection<DepreciationType> ChildTranslatedDepreciationTypes { get; set; }
        #endregion

        #endregion
    }
}
