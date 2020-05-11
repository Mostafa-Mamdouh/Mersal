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
	/// Provides a ProductPrice entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * سعر المنتج
	 */
	public class ProductPrice : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type ProductPrice.
		/// </summary>
		public ProductPrice()
		{
			this.ChildTranslatedProductPrices = new HashSet<ProductPrice>();
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
		//public Nullable<long> ProductId { get; set; }
		//public virtual Product Product { get; set; }
		public decimal Price { get; set; }
		public Nullable<decimal> Discount { get; set; }
		public bool IsOriginalPrice { get; set; }
		public string Description { get; set; }


		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyProductPriceId { get; set; }
		public virtual ProductPrice ParentKeyProductPrice { get; set; }


		public virtual ICollection<ProductPrice> ChildTranslatedProductPrices { get; set; }
		#endregion

		#endregion
	}
}
