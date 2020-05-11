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
	public class JournalTypeViewModel : BaseViewModel
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type JournalTypeViewModel.
		/// </summary>
		public JournalTypeViewModel()
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
		public string Code { get; set; }


		public virtual ICollection<BankMovementViewModel> BankMovements { get; set; }

		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyJournalTypeId { get; set; }
		public virtual JournalTypeViewModel ParentKeyJournalType { get; set; }


		public virtual ICollection<JournalTypeViewModel> ChildTranslatedJournalTypes { get; set; }
		#endregion

		#endregion
	}
	}
