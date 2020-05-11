#region Using ...
using Framework.Common.Enums;
using Framework.Core.Models.ViewModels.Base;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Core.Models.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    [DebuggerDisplay("Id={Id}")]
    public class TestamentExtractionViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type TestamentExtractionViewModel.
        /// </summary>
        public TestamentExtractionViewModel()
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

        public string Name { get; set; }
        public string Description { get; set; }

        public string NameAr { get; set; }
        public string NameEn { get; set; }

        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }



        #region Translation Functionality
        public Language? Language { get; set; }

        public long? ParentKeyTestamentExtractionId { get; set; }
        public virtual TestamentExtraction ParentKeyTestamentExtraction { get; set; }

        public virtual ICollection<TestamentExtraction> ChildTranslatedTestamentExtractions { get; set; }
        #endregion


        #endregion
    }
}
