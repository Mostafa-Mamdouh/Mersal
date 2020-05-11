#region Using ...
using Framework.Common.Enums;
using Framework.Core.Models.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Core.Models.ViewModels
{
	/// <summary>
	/// 
	/// </summary>
	[DebuggerDisplay("Id={Id}")]
	public class AccountChartLevelSettingViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type AccountChartLevelSettingViewModel.
        /// </summary>
        public AccountChartLevelSettingViewModel()
        {

        }
        public AccountChartLevelSettingViewModel(int level, int length)
        {
            this.Level = level;
            this.Length = length;
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
		public virtual AccountChartSettingViewModel AccountChartSetting { get; set; }
		#endregion
	}
}
