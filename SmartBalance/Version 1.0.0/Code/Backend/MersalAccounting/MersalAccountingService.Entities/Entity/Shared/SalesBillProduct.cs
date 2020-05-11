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
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	public class SalesBillProduct : IEntityIdentity<long>
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type SalesBillProduct.
		/// </summary>
		public SalesBillProduct()
		{
			this.ChildTranslatedSalesBillProducts = new HashSet<SalesBillProduct>();
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
		public long ProductId { get; set; }
		public Product Product { get; set; }

		public long SalesBillId { get; set; }
		public SalesBill SalesBill { get; set; }

		public decimal Price { get; set; }
		public float Quantity { get; set; }

		#region Translation Functionality
		public Language? Language { get; set; }
		public long? ParentKeySalesBillProductId { get; set; }
		public virtual SalesBillProduct ParentKeySalesBillProduct { get; set; }

		public virtual ICollection<SalesBillProduct> ChildTranslatedSalesBillProducts { get; set; }
		#endregion

		#endregion
	}
}
