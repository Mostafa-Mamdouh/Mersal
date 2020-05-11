#region Using ...
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
	/// 
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	public class GeneralAccount : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type Group.
		/// </summary>
		public GeneralAccount()
		{
			this.Donations = new HashSet<Donation>();
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
		public decimal Amount { get; set; }
		//public long? AccountChartId { get; set; }
		//public virtual AccountChart AccountChart { get; set; }
		public virtual ICollection<Donation> Donations { get; set; }
		#endregion
	}
}
