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
    public class ClosedMonthViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type ClosedMonthViewModel.
        /// </summary>
        public ClosedMonthViewModel()
        {

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


        public string NameAr { get; set; }
        public string NameEn { get; set; }

        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }



        #region Translation Functionality
        public Language? Language { get; set; }

        public long? ParentKeyClosedMonthId { get; set; }
        public virtual ClosedMonthViewModel ParentKeyClosedMonth { get; set; }


        //public virtual ICollection<ClosedMonthViewModel> ChildTranslatedClosedMonths { get; set; }
        #endregion

        #endregion
    }
}
