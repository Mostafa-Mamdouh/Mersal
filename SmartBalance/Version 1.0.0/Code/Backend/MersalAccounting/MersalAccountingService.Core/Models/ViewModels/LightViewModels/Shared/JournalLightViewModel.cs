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

namespace MersalAccountingService.Core.Models.ViewModels.LightViewModels
{
    /// <summary>
    /// Provides a lite model for entity 
    /// Journal, and this lite model 
    /// do not contains a children 
    /// relations for speeding up the 
    /// retrivement process.
    /// </summary>
    [DebuggerDisplay("Id={Id}, Code={Code}, Date={Date}, IsReversed={IsReversed}, Transactions={Transactions.Count()}")]
    public class JournalLightViewModel : BaseViewModel
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type JournalLightViewModel.
		/// </summary>
		public JournalLightViewModel()
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


        #region Translation Functionality
        public Language? Language { get; set; }

		public long? ParentKeyJournalId { get; set; }
		public JournalLightViewModel ParentKeyJournal { get; set; }		
		#endregion

		#endregion
	}
}
