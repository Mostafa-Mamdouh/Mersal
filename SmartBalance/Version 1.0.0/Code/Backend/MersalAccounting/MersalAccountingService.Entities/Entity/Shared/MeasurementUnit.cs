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
	public class MeasurementUnit : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type MeasurementUnit.
		/// </summary>
		public MeasurementUnit()
		{
			this.ChildTranslatedMeasurementUnits = new HashSet<MeasurementUnit>();
			this.Products = new HashSet<Product>();
			//this.DonationProducts = new HashSet<DonationProduct>();
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

		public virtual ICollection<Product> Products { get; set; }
		//public virtual ICollection<DonationProduct> DonationProducts { get; set; }

		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyMeasurementUnitId { get; set; }
		public virtual MeasurementUnit ParentKeyMeasurementUnit { get; set; }


		public virtual ICollection<MeasurementUnit> ChildTranslatedMeasurementUnits { get; set; }

		#endregion

		#endregion
	}
}
