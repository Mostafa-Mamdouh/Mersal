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
	public class AdvancesType : IEntityIdentity<int>, IEntityDateTimeSignature
	{
		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public AdvancesType()
		{
			this.ChildTranslatedAdvancesTypes = new HashSet<AdvancesType>();
			this.Testaments = new HashSet<Testament>();
		}
		#endregion

		#region Properties

		#region IEntityIdentity<T>
		public int Id { get; set; }
		#endregion

		#region IEntityDateTime
		public DateTime CreationDate { get; set; }
		public DateTime? FirstModificationDate { get; set; }
		public DateTime? LastModificationDate { get; set; }
		#endregion

		public string Name { get; set; }

		public virtual ICollection<Testament> Testaments { get; set; }

		#region Translation Functionality
		public Language? Language { get; set; }

		public int? ParentKeyAdvancesTypeId { get; set; }
		public virtual AdvancesType ParentKeyAdvancesTypes { get; set; }


		public virtual ICollection<AdvancesType> ChildTranslatedAdvancesTypes { get; set; }
		#endregion

		#endregion
	}
}
