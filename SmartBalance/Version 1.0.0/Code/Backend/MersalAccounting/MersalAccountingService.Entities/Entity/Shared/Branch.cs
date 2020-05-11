#region Using ...
using Framework.Common.Enums;
using Framework.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Entities.Entity
{
	/// <summary>
	/// Provides a Branch entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * الفروع
	 */
	public class Branch : IEntityIdentity<int>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type Branch.
		/// </summary>
		public Branch()
		{
			this.ChildTranslatedBranchs = new HashSet<Branch>();
			this.Donations = new HashSet<Donation>();
			this.PaymentMovments = new HashSet<PaymentMovment>();
			this.Safes = new HashSet<Safe>();
			this.AccountCharts = new HashSet<AccountChart>();
			this.UserBranches = new HashSet<UserBranch>();
		}
		#endregion

		#region Properties

		#region IEntityIdentity<T>
		public int Id { get; set; }
		#endregion

		#region IEntityDateTime
		public DateTime CreationDate { get; set; }
		public DateTime? FirstModificationDate { get; set; }
		public DateTime? LastModificationDate { get; set; }
		#endregion

		public string Name { get; set; }
		public string Code { get; set; }
		public string Description { get; set; }
		public DateTime? Date { get; set; }


		public virtual ICollection<Donation> Donations { get; set; }
		public virtual ICollection<PaymentMovment> PaymentMovments { get; set; }
		public virtual ICollection<Safe> Safes { get; set; }
		public virtual ICollection<AccountChart> AccountCharts { get; set; }
		public virtual ICollection<UserBranch> UserBranches { get; set; }


		#region Translation Functionality
		public Language? Language { get; set; }

		public int? ParentKeyBranchId { get; set; }
		public virtual Branch ParentKeyBranch { get; set; }


		public virtual ICollection<Branch> ChildTranslatedBranchs { get; set; }
		#endregion

		#endregion
	}
}
