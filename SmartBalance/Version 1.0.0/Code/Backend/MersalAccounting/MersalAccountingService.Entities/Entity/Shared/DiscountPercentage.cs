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
	/// Provides a DiscountPercentage entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * المدينة
	 */
	public class DiscountPercentage : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type DiscountPercentage.
		/// </summary>
		public DiscountPercentage()
		{
			this.ChildTranslatedDiscountPercentages = new HashSet<DiscountPercentage>();
			this.PaymentMovmentNotificationDiscounts = new HashSet<PaymentMovmentNotificationDiscount>();
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
		public float? Percentage { get; set; }


		public virtual ICollection<PaymentMovmentNotificationDiscount> PaymentMovmentNotificationDiscounts { get; set; }

		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyDiscountPercentageId { get; set; }
		public virtual DiscountPercentage ParentKeyDiscountPercentage { get; set; }


		public virtual ICollection<DiscountPercentage> ChildTranslatedDiscountPercentages { get; set; }
		#endregion

		#endregion
	}
}
