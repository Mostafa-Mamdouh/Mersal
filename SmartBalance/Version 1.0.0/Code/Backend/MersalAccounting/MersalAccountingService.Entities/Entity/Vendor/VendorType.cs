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
	/// Provides a VendorType entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * انواع الموردين
	 */
	public class VendorType : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type VendorType.
		/// </summary>
		public VendorType()
		{
			this.Vendors = new HashSet<Vendor>();

			this.ChildTranslatedVendorTypes = new HashSet<VendorType>();
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
		public virtual ICollection<Vendor> Vendors { get; set; }


		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyVendorTypeId { get; set; }
		public virtual VendorType ParentKeyVendorType { get; set; }

 
		public virtual ICollection<VendorType> ChildTranslatedVendorTypes { get; set; }
		#endregion

		#endregion
	}
}
