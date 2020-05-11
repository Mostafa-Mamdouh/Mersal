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
	[DebuggerDisplay("Id={Id}")]
	public class VendorSettingViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type SettingViewModel.
        /// </summary>
        public VendorSettingViewModel()
        {

        }
        #endregion

        #region Properties

        #region إعدادات فاتورة المشتريات

        #region رقم حساب المشتريات النقدية
        /// <summary>
        /// رقم حساب المشتريات النقدية
        /// </summary>
        public string CashPurchaseAccountNumber { get; set; }
        /// <summary>
        /// رقم حساب المشتريات النقدية
        /// </summary>
        public AccountChartLightViewModel CashPurchaseAccount { get; set; }
        #endregion

        #region رقم حساب المشتريات الاجلة
        /// <summary>
        /// رقم حساب المشتريات الاجلة
        /// </summary>
        public string FuturePurchaseAccountNumber { get; set; }
        /// <summary>
        /// رقم حساب المشتريات الاجلة
        /// </summary>
        public AccountChartLightViewModel FuturePurchaseAccount { get; set; }
        #endregion

        #region رقم حساب خصم المشتريات المكتسب
        /// <summary>
        /// رقم حساب خصم المشتريات المكتسب
        /// </summary>
        public string PurchaseDiscountAccountNumber { get; set; }
        /// <summary>
        /// رقم حساب خصم المشتريات المكتسب
        /// </summary>
        public AccountChartLightViewModel PurchaseDiscountAccount { get; set; }
        #endregion

        #region رقم حساب مصروفات المشتريات
        /// <summary>
        /// رقم حساب مصروفات المشتريات
        /// </summary>
        public string PurchaseExpensesAccountNumber { get; set; }
        /// <summary>
        /// رقم حساب مصروفات المشتريات
        /// </summary>
        public AccountChartLightViewModel PurchaseExpensesAccount { get; set; }
        #endregion

        #region رقم حساب ضريبة المشتريات
        /// <summary>
        /// رقم حساب ضريبة المشتريات
        /// </summary>
        public string PurchaseTaxAccountNumber { get; set; }
        /// <summary>
        /// رقم حساب ضريبة المشتريات
        /// </summary>
        public AccountChartLightViewModel PurchaseTaxAccount { get; set; }
        #endregion

        #endregion


        #region إعدادات مرتد المشتريات

        #region رقم حساب مرتد المشتريات النقدية
        /// <summary>
        /// رقم حساب مرتد المشتريات النقدية
        /// </summary>
        public string CashPurchasesRebateAccountNumber { get; set; }
        /// <summary>
        /// رقم حساب مرتد المشتريات النقدية
        /// </summary>
        public AccountChartLightViewModel CashPurchasesRebateAccount { get; set; }
        #endregion

        #region رقم حساب مرتد المشتريات الاجلة
        /// <summary>
        /// رقم حساب مرتد المشتريات الاجلة
        /// </summary>
        public string FuturePurchaseRebateAccountNumber { get; set; }
        /// <summary>
        /// رقم حساب مرتد المشتريات الاجلة
        /// </summary>
        public AccountChartLightViewModel FuturePurchaseRebateAccount { get; set; }
        #endregion

        #region رقم حساب خصم مرتد المشتريات المكتسب
        /// <summary>
        /// رقم حساب خصم مرتد المشتريات المكتسب
        /// </summary>
        public string PurchaseRebateDiscountAccountNumber { get; set; }
        /// <summary>
        /// رقم حساب خصم مرتد المشتريات المكتسب
        /// </summary>
        public AccountChartLightViewModel PurchaseRebateDiscountAccount { get; set; }
        #endregion

        #region رقم حساب مصروفات مرتد المشتريات
        /// <summary>
        /// رقم حساب مصروفات مرتد المشتريات
        /// </summary>
        public string PurchaseRebateExpensesAccountNumber { get; set; }
        /// <summary>
        /// رقم حساب مصروفات مرتد المشتريات
        /// </summary>
        public AccountChartLightViewModel PurchaseRebateExpensesAccount { get; set; }
        #endregion

        #region رقم حساب ضريبة مرتد المشتريات
        /// <summary>
        /// رقم حساب ضريبة مرتد المشتريات
        /// </summary>
        public string PurchaseRebateTaxAccountNumber { get; set; }
        /// <summary>
        /// رقم حساب ضريبة مرتد المشتريات
        /// </summary>
        public AccountChartLightViewModel PurchaseRebateTaxAccount { get; set; }
        #endregion

        #endregion

        #endregion
    }
}
