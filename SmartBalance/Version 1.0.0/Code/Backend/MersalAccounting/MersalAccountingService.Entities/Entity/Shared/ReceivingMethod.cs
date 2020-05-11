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
	/// 
	/// </summary>
	[DebuggerDisplay("Id={Id}, Code={Code}, Name={Name}")]
	public class ReceivingMethod : IEntityIdentity<int>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type AccountChart.
		/// </summary>
		public ReceivingMethod()
		{
			this.ChildTranslatedReceivingMethods = new HashSet<ReceivingMethod>();
			this.Donations = new HashSet<Donation>();
			this.PaymentMovments = new HashSet<PaymentMovment>();
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
		public string Description { get; set; }
		public string Code { get; set; }

		public virtual ICollection<PaymentMovment> PaymentMovments { get; set; }

		public virtual ICollection<Donation> Donations { get; set; }

		#region Translation Functionality
		public Language? Language { get; set; }
		public long? ParentKeyReceivingMethodId { get; set; }
		public virtual ReceivingMethod ParentKeyReceivingMethod { get; set; }

		public virtual ICollection<ReceivingMethod> ChildTranslatedReceivingMethods { get; set; }
		#endregion

		#endregion
	}
}
