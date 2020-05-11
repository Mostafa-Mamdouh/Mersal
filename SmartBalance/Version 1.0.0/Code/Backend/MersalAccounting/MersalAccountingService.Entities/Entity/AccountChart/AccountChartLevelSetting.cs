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
	/// Provides a AccountChartLevelSetting entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Level={Level}, Length={Length}")]
	/*
	 * @EntityDescription: 
	 * 
	 */
	public class AccountChartLevelSetting : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type AccountChartLevelSetting.
		/// </summary>
		public AccountChartLevelSetting()
		{

		}
		#endregion

		#region Properties

		#region IEntityIdentity<T>
		public long Id { get; set; }
		#endregion

		#region IEntityDateTimeSignature
		public DateTime CreationDate { get; set; }
		public DateTime? FirstModificationDate { get; set; }
		public DateTime? LastModificationDate { get; set; }
		#endregion

		public int Level { get; set; }
		public int Length { get; set; }
        public int TotalLength { get; set; }


        public long? AccountChartSettingId { get; set; }
		public virtual AccountChartSetting AccountChartSetting { get; set; }
		#endregion
	}
}
