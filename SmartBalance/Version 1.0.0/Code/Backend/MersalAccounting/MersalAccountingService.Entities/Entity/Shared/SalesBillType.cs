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
	public class SalesBillType : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type SalesBillType.
		/// </summary>
		public SalesBillType()
		{
			this.ChildTranslatedSalesBillTypes = new HashSet<SalesBillType>();
			this.SalesBills = new HashSet<SalesBill>();
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

		public virtual ICollection<SalesBill> SalesBills { get; set; }

		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeySalesBillTypeId { get; set; }
		public virtual SalesBillType ParentKeySalesBillType { get; set; }


		public virtual ICollection<SalesBillType> ChildTranslatedSalesBillTypes { get; set; }
		#endregion

		#endregion
	}
}
