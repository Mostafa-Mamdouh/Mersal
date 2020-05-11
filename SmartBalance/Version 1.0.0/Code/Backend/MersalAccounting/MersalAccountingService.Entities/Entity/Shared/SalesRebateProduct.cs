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
	/// Provides a SalesRebateProduct entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * منتجات مرتد المبيعات
	 */
	public class SalesRebateProduct : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type SalesRebateProduct.
		/// </summary>
		public SalesRebateProduct()
		{
			this.ChildTranslatedSalesRebateProducts = new HashSet<SalesRebateProduct>();
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
		public Nullable<long> ProductId { get; set; }
		public virtual Product Product { get; set; }
		public Nullable<long> SalesRebateId { get; set; }
		public virtual SalesRebate SalesRebate { get; set; }
		public int Count { get; set; }
		public decimal Price { get; set; }
		public string Reason { get; set; }


		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeySalesRebateProductId { get; set; }
		public virtual SalesRebateProduct ParentKeySalesRebateProduct { get; set; }

 
		public virtual ICollection<SalesRebateProduct> ChildTranslatedSalesRebateProducts { get; set; }
		#endregion

		#endregion
	}
}
