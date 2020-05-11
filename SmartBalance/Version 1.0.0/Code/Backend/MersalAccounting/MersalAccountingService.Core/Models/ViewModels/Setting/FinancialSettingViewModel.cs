#region Using ...
using Framework.Common.Enums;
using Framework.Core.Models.ViewModels.Base;
using MersalAccountingService.Core.Models.ViewModels.LightViewModels;
using MersalAccountingService.Entities.Entity;
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
	/// إعدادات الحركة المالية
	/// </summary>
	[DebuggerDisplay("Id={Id}")]
	public class FinancialSettingViewModel : BaseViewModel
    {
        #region Properties      

        /// <summary>
        /// اظهار الحالات التى استوفت المبلغ المطلوب
        /// </summary>
        public bool ShowCasesThatMetRequiredAmount { get; set; }

        /// <summary>
        /// استخدام شيكات تحت التحصيل
        /// </summary>
        public bool UseChecksUnderCollection { get; set; }


		/// <summary>
		/// رقم حساب ضريبة الخصم والاضافة
		/// </summary>
		public string VATAccountNumber { get; set; }
		public AccountChartLightViewModel VATAccount { get; set; }

		/// <summary>
		/// رقم حساب شيكات تحت التحصيل
		/// </summary>
		public string ChecksUnderCollectionAccountNumber { get; set; }
        public AccountChartLightViewModel ChecksUnderCollectionAccount { get; set; }

        /// <summary>
        /// رقم حساب التبرعات
        /// </summary>
        public string DonationAccountNumber { get; set; }
        public AccountChartLightViewModel DonationAccount { get; set; }

        /// <summary>
        /// رقم حساب رد التبرعات
        /// </summary>
        public string DonationReturnAccountNumber { get; set; }
        public AccountChartLightViewModel DonationReturnAccount { get; set; }



        /// <summary>
        /// رقم حساب العهد المؤقتة
        /// </summary>
        public string TemporaryCovenantAccountNumber { get; set; }
        public AccountChartLightViewModel TemporaryCovenantAccount { get; set; }

        /// <summary>
        /// رقم حساب المصروفات البنكية
        /// </summary>
        public string BankingPaymentsAccountNumber { get; set; }
        public AccountChartLightViewModel BankingPaymentsAccount { get; set; }



        /// <summary>
        /// رقم حساب اوراق القبض
        /// </summary>
        public string ReceiptPapersAccountNumber { get; set; }
        public AccountChartLightViewModel ReceiptPapersAccount { get; set; }

        /// <summary>
        ///  رقم حساب اوراق القبض تحت التحصيل
        /// </summary>
        public string ChecksUnderReceiptPapersAccountNumber { get; set; }
        public AccountChartLightViewModel ChecksUnderReceiptPapers { get; set; }


        /// <summary>
        /// رقم حساب التبرعات العامة
        /// </summary>
        public string GeneralDonationsAccountNumber { get; set; }
        public AccountChartLightViewModel GeneralDonations { get; set; }



        #endregion
    }
}
