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
    public class ExpenseViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type ExpenseViewModel.
        /// </summary>
        public ExpenseViewModel()
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
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public decimal? Amount { get; set; }

        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }


        public long? AssetId { get; set; }
        public virtual AssetViewModel Asset { get; set; }


        public long? AccountChartId { get; set; }
        public virtual AccountChartViewModel AccountChart { get; set; }

        public long? ExpensesTypeId { get; set; }
        public virtual ExpensesTypeViewModel ExpensesType { get; set; }



        #region Translation Functionality
        public Language? Language { get; set; }

        public long? ParentKeyExpenseId { get; set; }
        public virtual ExpenseViewModel ParentKeyExpense { get; set; }


        public virtual ICollection<ExpenseViewModel> ChildTranslatedExpenses { get; set; }
        #endregion

        #endregion
    }
}