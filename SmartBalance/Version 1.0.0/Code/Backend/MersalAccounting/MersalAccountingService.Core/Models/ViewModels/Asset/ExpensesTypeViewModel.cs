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
    public class ExpensesTypeViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type ExpenseTypeViewModel.
        /// </summary>
        public ExpensesTypeViewModel()
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


        //public IList<ExpenseViewModel> Expenses { get; set; }


        #region Translation Functionality
        public Language? Language { get; set; }

        public long? ParentKeyExpensesTypeId { get; set; }
        public virtual ExpensesTypeViewModel ParentKeyExpensesType { get; set; }


        public IList<ExpensesTypeViewModel> ChildTranslatedExpensesTypes { get; set; }
        #endregion

        #endregion
    }
}
