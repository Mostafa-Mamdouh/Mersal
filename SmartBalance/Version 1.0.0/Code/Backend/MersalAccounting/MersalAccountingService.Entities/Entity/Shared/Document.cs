#region Using ...
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
	public class Document : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public Document()
		{
			this.Documents = new HashSet<Document>();
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

		public int DocumentNumber { get; set; }

		public int CountReceipts { get; set; }

		public int FirstNumber { get; set; }

		public virtual ICollection<Document> Documents { get; set; }
		#endregion
	}
}
