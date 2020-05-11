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
	/// Provides a DelegateMan entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * المندوبين
	 */
	public class DelegateMan : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type DelegateMan.
		/// </summary>
		public DelegateMan()
		{
			this.ChildTranslatedDelegateMans = new HashSet<DelegateMan>();
			this.SalesBills = new HashSet<SalesBill>();
			this.PaymentMovments = new HashSet<PaymentMovment>();
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
		public string Code { get; set; }
		public string Description { get; set; }
		public DateTime? Date { get; set; }


		public virtual ICollection<SalesBill> SalesBills { get; set; }
		public virtual ICollection<PaymentMovment> PaymentMovments { get; set; }
		public virtual ICollection<Donation> Donations { get; set; }


		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyDelegateManId { get; set; }
		public virtual DelegateMan ParentKeyDelegateMan { get; set; }


		public virtual ICollection<DelegateMan> ChildTranslatedDelegateMans { get; set; }
		#endregion

		#endregion
	}
}
