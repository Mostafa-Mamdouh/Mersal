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
	/// Provides a Case entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * الحالات
	 */
	public class Case : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type Case.
		/// </summary>
		public Case()
		{
			this.DonationCases = new HashSet<DonationCase>();
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
		public string ExternalId { get; set; }
		//public string Description { get; set; }
		public virtual ICollection<DonationCase> DonationCases { get; set; }

		//#region Translation Functionality
		//public Language? Language { get; set; }

		//public long? ParentKeyCaseId { get; set; }
		//public virtual Case ParentKeyCase { get; set; }


		//public virtual ICollection<Case> ChildTranslatedCases { get; set; }
		//#endregion

		#endregion
	}
}
