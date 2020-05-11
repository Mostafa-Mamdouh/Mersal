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
	/// Provides a StoreMeasurementUnit entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * وحدات القياس المخزنية
	 */
	public class StoreMeasurementUnit : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type StoreMeasurementUnit.
		/// </summary>
		public StoreMeasurementUnit()
		{
			this.ChildTranslatedStoreMeasurementUnits = new HashSet<StoreMeasurementUnit>();
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


		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyStoreMeasurementUnitId { get; set; }
		public virtual StoreMeasurementUnit ParentKeyStoreMeasurementUnit { get; set; }

 
		public virtual ICollection<StoreMeasurementUnit> ChildTranslatedStoreMeasurementUnits { get; set; }
		#endregion

		#endregion
	}
}
