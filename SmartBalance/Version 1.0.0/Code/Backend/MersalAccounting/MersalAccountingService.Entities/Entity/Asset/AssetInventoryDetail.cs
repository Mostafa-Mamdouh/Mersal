#region Using ...
using Framework.Common.Enums;
using Framework.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
#endregion

namespace MersalAccountingService.Entities.Entity
{
    [DebuggerDisplay("Id={Id}, Name={Name}")]
    public  class AssetInventoryDetail : IEntityIdentity<long>, IEntityDateTimeSignature
    {
        #region Data Members

        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type Asset.
        /// </summary>
        public AssetInventoryDetail()
        {
           
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


        public long? AssetInventoryId { get; set; }
        public virtual AssetInventory AssetInventory { get; set; }


        public long? BrandId { get; set; }
        public virtual Brand Brand { get; set; }


        public int? ExpectedQuantity { get; set; }
        public int? ActualQuantity { get; set; }
        public int? Difference { get; set; }




        //#region Translation Functionality
        //public Language? Language { get; set; }

        //public long? ParentKeyAssetInventoryId { get; set; }
        //public virtual AssetInventory ParentKeyAssetInventory { get; set; }


        //public virtual ICollection<AssetInventory> ChildTranslatedAssetInventorys { get; set; }
        //#endregion

        #endregion
    }
}
