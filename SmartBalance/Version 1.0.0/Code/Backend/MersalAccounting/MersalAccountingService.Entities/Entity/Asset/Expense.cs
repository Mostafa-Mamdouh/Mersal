#region Using ...
using Framework.Common.Enums;
using Framework.Common.Interfaces;
using MersalAccountingService.Common.Enums;
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
	/// Provides a Expenses entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * نوع الاهلاك
	 */
	public class Expense : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type Expenses.
		/// </summary>
		public Expense()
		{
			this.ChildTranslatedExpenses = new HashSet<Expense>();
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


		public long? AssetId { get; set; }
		public virtual Asset Asset { get; set; }


		public long? AccountChartId { get; set; }
		public virtual AccountChart AccountChart { get; set; }

		public long? ExpensesTypeId { get; set; }
		public virtual ExpensesType ExpensesType { get; set; }



		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyExpenseId { get; set; }
		public virtual Expense ParentKeyExpense { get; set; }


		public virtual ICollection<Expense> ChildTranslatedExpenses { get; set; }
		#endregion

		#endregion
	}
}
