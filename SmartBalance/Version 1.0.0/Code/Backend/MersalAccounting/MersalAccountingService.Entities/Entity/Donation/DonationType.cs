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
	/// Provides a PaymentMethod entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * طريقة الدفع
	 */
	public class DonationType : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type DonationType.
		/// </summary>
		public DonationType()
		{
			this.ChildTranslatedDonationTypes = new HashSet<DonationType>();
			this.ChildDonations = new HashSet<DonationType>();
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
		public long? ParentId { get; set; }
		public virtual DonationType Parent { get; set; }

		public virtual ICollection<DonationType> ChildDonations { get; set; }

		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyDonationTypeId { get; set; }
		public virtual DonationType ParentKeyDonationType { get; set; }

		public virtual ICollection<DonationType> ChildTranslatedDonationTypes { get; set; }
		#endregion

		#endregion
	}
}
