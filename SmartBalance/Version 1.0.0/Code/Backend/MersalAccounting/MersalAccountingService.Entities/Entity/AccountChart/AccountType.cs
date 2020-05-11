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
	/// Provides a AccountType entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * نوع الحساب
	 */
	public class AccountType : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type AccountType.
		/// </summary>
		public AccountType()
		{
			this.ChildTranslatedAccountTypes = new HashSet<AccountType>();
			this.AccountCharts = new HashSet<AccountChart>();
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

		public virtual ICollection<AccountChart> AccountCharts { get; set; }

		#region Translation Functionality
		public Language? Language { get; set; }
		public long? ParentKeyAccountTypeId { get; set; }
		public virtual AccountType ParentKeyAccountType { get; set; }
		public virtual ICollection<AccountType> ChildTranslatedAccountTypes { get; set; }
		#endregion

		#endregion
	}
}
