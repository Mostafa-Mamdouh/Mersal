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
	public class Brand : IEntityIdentity<long>, IEntityDateTimeSignature, IEntityUserSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type Product.
		/// </summary>
		public Brand()
		{
			this.ChildBrands = new HashSet<Brand>();
			this.ChildTranslatedBrands = new HashSet<Brand>();
			this.Products = new HashSet<Product>();
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

		#region IEntityUserSignature		
		public long? CreatedByUserId { get; set; }
		public long? FirstModifiedByUserId { get; set; }
		public long? LastModifiedByUserId { get; set; }
		#endregion

		public string Name { get; set; }
		public string Code { get; set; }
		public string Description { get; set; }
		public DateTime? Date { get; set; }


		public virtual ICollection<Product> Products { get; set; }

		public long? ParentBrandId { get; set; }
		public virtual Brand ParentBrand { get; set; }

		public virtual ICollection<Brand> ChildBrands { get; set; }


		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyBrandId { get; set; }
		public virtual Brand ParentKeyBrand { get; set; }


		public virtual ICollection<Brand> ChildTranslatedBrands { get; set; }
		#endregion

		#endregion
	}
}
