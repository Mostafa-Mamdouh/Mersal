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
	public class TransactionViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type TransactionViewModel.
        /// </summary>
        public TransactionViewModel()
        {

        }
        #endregion        

        #region Properties

        #region IEntityIdentity<T>
        public long Id { get; set; }
		#endregion

		#region IEntityDateTime
		/// <summary>
		/// 
		/// </summary>
		public DateTime CreationDate { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime? FirstModificationDate { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime? LastModificationDate { get; set; }
		#endregion

		public string Name { get; set; }
		public decimal Amount { get; set; }
		public bool IsCreditor { get; set; }
        public string DescriptionAR { get; set; }
        public string DescriptionEN { get; set; }

        public long? AccountChartId { get; set; }
        public virtual AccountChartViewModel AccountChart { get; set; }

        public long? JournalId { get; set; }
        public virtual JournalViewModel Journal { get; set; }

        public long? CostCenterId { get; set; }
        public virtual CostCenterViewModel CostCenter { get; set; }

        //#region Translation Functionality
        //public Language? Language { get; set; }

        //      public long? ParentKeyTransactionId { get; set; }
        //      public TransactionViewModel ParentKeyTransaction { get; set; }


        //      public IList<TransactionViewModel> ChildTranslatedTransactions { get; set; }
        //      #endregion

        #endregion
    }
}
