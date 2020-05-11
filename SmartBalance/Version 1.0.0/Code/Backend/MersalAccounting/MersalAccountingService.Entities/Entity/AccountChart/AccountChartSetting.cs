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
	/// Provides a AccountChartSetting entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * اعدادات الدليل المحاسبى
	 */
	public class AccountChartSetting : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type AccountChartSetting.
		/// </summary>
		public AccountChartSetting()
		{
			this.AccountChartLevelSettings = new HashSet<AccountChartLevelSetting>();
			//this.ChildTranslatedAccountChartSettings = new HashSet<AccountChartSetting>();
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

		
		public int LevelCount { get; set; }

		public virtual ICollection<AccountChartLevelSetting> AccountChartLevelSettings { get; set; }

		//public string Code { get; set; }
		//public string Description { get; set; }


		//#region Translation Functionality
		//public Language? Language { get; set; }

		//public long? ParentKeyAccountChartSettingId { get; set; }
		//public virtual AccountChartSetting ParentKeyAccountChartSetting { get; set; }


		//public virtual ICollection<AccountChartSetting> ChildTranslatedAccountChartSettings { get; set; }
		//#endregion

		#endregion
	}
}
