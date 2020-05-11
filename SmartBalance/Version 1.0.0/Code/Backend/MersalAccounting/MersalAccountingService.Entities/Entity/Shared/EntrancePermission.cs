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
	/// Provides a EntrancePermission entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * 
	 */
	public class EntrancePermission : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type EntrancePermission.
		/// </summary>
		public EntrancePermission()
		{
			this.ChildTranslatedEntrancePermissions = new HashSet<EntrancePermission>();
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
		//public Nullable<long> PurchaseInvoiceId { get; set; }
		//public virtual PurchaseInvoice PurchaseInvoice { get; set; }
		public Nullable<DateTime> Date { get; set; }
		public bool IsApproved { get; set; }
		public string Description { get; set; }


		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyEntrancePermissionId { get; set; }
		public virtual EntrancePermission ParentKeyEntrancePermission { get; set; }


		public virtual ICollection<EntrancePermission> ChildTranslatedEntrancePermissions { get; set; }
		#endregion

		#endregion
	}
}
