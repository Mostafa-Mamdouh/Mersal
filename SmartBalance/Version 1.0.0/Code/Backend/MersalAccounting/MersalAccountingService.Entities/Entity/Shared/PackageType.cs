//using Framework.Common.Enums;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MersalAccountingService.Entities.Entity
//{
//    class PackageType
//    {
//        #region Data Members

//        #endregion

//        #region Constructors
//        /// <summary>
//        /// Initializes a new instance of 
//        /// type AccountChart.
//        /// </summary>
//        public PackageType()
//        {
          
//        }
//        #endregion

//        #region Properties

//        #region IEntityIdentity<T>
//        public long Id { get; set; }
//        #endregion

//        #region IEntityDateTime
//        public DateTime CreationDate { get; set; }
//        public DateTime? FirstModificationDate { get; set; }
//        public DateTime? LastModificationDate { get; set; }
//        #endregion

//        public string Name { get; set; }
      
//        public string Code { get; set; }



//        #region Translation Functionality
//        public Language? Language { get; set; }

//        public long? ParentKeyPackageTypeId { get; set; }
//        public virtual PackageType ParentKeyPackageType { get; set; }
//        public virtual ICollection<PackageType> ChildTranslatedPackageType { get; set; }
//        #endregion

//        #endregion
//    }
//}
