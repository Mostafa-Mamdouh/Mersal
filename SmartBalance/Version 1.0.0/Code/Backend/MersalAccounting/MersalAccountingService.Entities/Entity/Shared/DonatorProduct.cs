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
	public class DonatorProduct : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Properties
		#region IEntityIdentity<T>
		public long Id { get; set; }
		#endregion

		//CutomerRelation
		public long DonatorId { get; set; }
		public Donator Donator { get; set; }

		public long ProductId { get; set; }
		public Product Product { get; set; }


		#region IEntityDateTime
		public DateTime CreationDate { get; set; }
		public DateTime? FirstModificationDate { get; set; }
		public DateTime? LastModificationDate { get; set; }
		#endregion

		#endregion
	}
}
