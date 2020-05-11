#region Using ...
using Framework.Common.Enums;
using Framework.Common.Interfaces;
using MersalAccountingService.Common.Interfaces;
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
	/// Provides a SalesRebate entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * مرتد مبيعات
	 */
	public class SalesRebate : IEntityIdentity<long>, IEntityDateTimeSignature, IPostingSignature
    {
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type SalesRebate.
		/// </summary>
		public SalesRebate()
		{
			this.SalesRebateProducts = new HashSet<SalesRebateProduct>();
			this.ChildTranslatedSalesRebates = new HashSet<SalesRebate>();
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

        #region IPostingSignature
        public bool IsPosted { get; set; }
        public DateTime? PostingDate { get; set; }
        public long? PostedByUserId { get; set; }
        #endregion

        public string Name { get; set; }
		public string Description { get; set; }
		public virtual ICollection<SalesRebateProduct> SalesRebateProducts { get; set; }


		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeySalesRebateId { get; set; }
		public virtual SalesRebate ParentKeySalesRebate { get; set; }

 
		public virtual ICollection<SalesRebate> ChildTranslatedSalesRebates { get; set; }
		#endregion

		#endregion
	}
}
