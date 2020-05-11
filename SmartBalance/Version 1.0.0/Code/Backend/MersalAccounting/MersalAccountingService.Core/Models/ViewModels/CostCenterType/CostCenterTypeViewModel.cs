#region Using ...
using Framework.Common.Enums;
using Framework.Core.Models.ViewModels.Base;
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
    public class CostCenterTypeViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type ExpenseTypeViewModel.
        /// </summary>
        public CostCenterTypeViewModel()
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

        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }


        //public IList<CostCenterViewModel> CostCenters { get; set; }


        #region Translation Functionality
        public Language? Language { get; set; }

        public long? ParentKeyCostCenterTypeId { get; set; }
        public virtual CostCenterTypeViewModel ParentKeyCostCenterType { get; set; }


        public IList<CostCenterTypeViewModel> ChildTranslatedCostCenterTypes { get; set; }
        #endregion

        #endregion
    }
}
