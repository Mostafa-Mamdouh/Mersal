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
	/// Provides a ExchangeBonds entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * سندات الصرف
	 */
	public class ExchangeBonds : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type ExchangeBonds.
		/// </summary>
		public ExchangeBonds()
		{
			this.ChildTranslatedExchangeBondss = new HashSet<ExchangeBonds>();
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
		public decimal Amount { get; set; }


		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyExchangeBondsId { get; set; }
		public virtual ExchangeBonds ParentKeyExchangeBonds { get; set; }


		public virtual ICollection<ExchangeBonds> ChildTranslatedExchangeBondss { get; set; }
		#endregion

		#endregion
	}
}
