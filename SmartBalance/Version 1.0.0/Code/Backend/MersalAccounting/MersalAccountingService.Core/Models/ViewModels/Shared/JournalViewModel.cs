#region Using ...
using Framework.Common.Enums;
using Framework.Core.Models.ViewModels.Base;
using MersalAccountingService.Common.Enums;
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
    [DebuggerDisplay("Id={Id}, Code={Code}, Date={Date}, IsReversed={IsReversed}, Transactions={Transactions.Count()}")]
    public class JournalViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type JournalViewModel.
        /// </summary>
        public JournalViewModel()
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

        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public MovementType? MovementType { get; set; }
        public long? ObjectId { get; set; }
        public bool IsAutomaticPosting { get; set; }
        public bool IsBulkPosting { get; set; }

        public bool IsReversed { get; set; }
        public long? ReversedFromId { get; set; }
        public long? ReversedToId { get; set; }

        public PostingStatus PostingStatus { get; set; }


        public virtual ICollection<TransactionViewModel> Transactions { get; set; }


        //#region Translation Functionality
        //public Language? Language { get; set; }

        //public long? ParentKeyJournalId { get; set; }
        //public JournalViewModel ParentKeyJournal { get; set; }


        //public IList<JournalViewModel> ChildTranslatedJournals { get; set; }
        //#endregion

        #endregion
    }
}
