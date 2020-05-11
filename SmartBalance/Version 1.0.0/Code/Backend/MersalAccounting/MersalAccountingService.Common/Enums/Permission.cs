#region Using ...
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
#endregion

namespace MersalAccountingService.Common.Enums
{
    public enum Permissions
    {
        /// <summary>
        /// قائمة حركات المقبوضات
        /// </summary>
        MovementsReceivedList = 1,
        /// <summary>
        /// اضافة حركة مقبوضات
        /// </summary>
        AddMovementsReceived = 2,
        /// <summary>
        /// تعديل حركة مقبوضات
        /// </summary>
        EditMovementsReceived = 3,
        /// <summary>
        ///  طباعة ايصال مقبوضات
        /// </summary>
        PrintReceipt = 4,
        /// <summary>
        /// قائمة حركات المدفوعات
        /// </summary>
        PaymentsMovementsList = 5,
        /// <summary>
        /// اضافة حركة مدفوعات
        /// </summary>
        AddPaymentsMovements = 6,
        /// <summary>
        /// تعديل حركة مدفوعات
        /// </summary>
        EditPaymentsMovements = 7,
        /// <summary>
        /// قائمة فواتير المشتريات
        /// </summary>
        PurchaseInvoicesList = 8,
        /// <summary>
        /// اضافة فاتورة مشتريات
        /// </summary>
        AddPurchaseInvoice = 9,
        /// <summary>
        /// تعديل فاتورة مشتريات
        /// </summary>
        EditPurchaseInvoice = 10,
		/// <summary>
		/// قائمة مرتد المشتريات
		/// </summary>
		PurchaseRebateList = 11,
        /// <summary>
        /// اضافة مرتد مشتريات
        /// </summary>
        AddPurchaseRebate = 12,
        /// <summary>
        /// تعديل مرتد مشتريات
        /// </summary>
        EditPurchaseRebate = 13,
        /// <summary>
        /// قائمة حركات البنوك
        /// </summary>
        BankMovementsList = 14,
        /// <summary>
        /// اضافة حركات البنوك
        /// </summary>
        AddBankMovement = 15,
        /// <summary>
        /// تعديل حركات البنوك
        /// </summary>
        EditBankMovement = 16,
        /// <summary>
        /// قائمة قيود اليومية
        /// </summary>
        JournalEntriesList = 17,
        /// <summary>
        /// اضافة حركة يومية
        /// </summary>
        AddJournalEntries = 18,
        /// <summary>
        /// عكس قيد يومية
        /// </summary>
        ReverseJournalEntries = 19,
        /// <summary>
        /// الموافقة على قيود قيد الترحيل
        /// </summary>
        ApproveOrRejectJournalEntriesUnderReview = 20,
        /// <summary>
        /// ترحيل قيود اليومية
        /// </summary>
        PostJournalEntries = 21,
        /// <summary>
        /// التحكم فى حسابات كل ترحيل
        /// </summary>
        ControlPostingJournalEntries = 22,
        /// <summary>
        /// مشاهدة الشجرة المحاسبية
        /// </summary>
        ViewAccountChart = 23,
        /// <summary>
        /// اضافة حساب للشجرة المحاسبية
        /// </summary>
        AddAccountChart = 24,
        /// <summary>
        /// تعديل حساب فى الشجرة المحاسبية
        /// </summary>
        EditAccountChart = 25,
        /// <summary>
        /// التحكم فى شيكات تحت التحصيل
        /// </summary>
        ControlChecksUnderCollection = 26,
        /// <summary>
        /// قائمة الرصيد الافتتاحى للمخازن
        /// </summary>
        OpeningBalanceList = 27,
        /// <summary>
        /// اضافة رصيد افتتاحى
        /// </summary>
        AddOpeningBalance = 28,
        /// <summary>
        /// تعديل رصيد افتتاحى
        /// </summary>
        EditOpeningBalance = 29,
        /// <summary>
        /// قائمة حركة المخزون
        /// </summary>
        InventoryMovementList = 30,
        /// <summary>
        /// اضافة حركة مخزون
        /// </summary>
        AddInventoryMovement = 31,
        /// <summary>
        /// تعديل حركة مخزون
        /// </summary>
        EditInventoryMovement = 32,
        /// <summary>
        /// قائمة تحويلات المخزون
        /// </summary>
        InventoryTransfersList = 33,
        /// <summary>
        /// اضافة تحويلات المخزون
        /// </summary>
        AddInventoryTransfers = 34,
        /// <summary>
        /// تعديل تحويلات المخزون
        /// </summary>
        EditInventoryTransfers = 35,
        /// <summary>
        /// إعدادات ضريبة القيمة المضافة
        /// </summary>
        VATSettings = 36,
        /// <summary>
        /// إعدادات نظام الموردين
        /// </summary>
        VendorSystemSettings = 37,
        /// <summary>
        /// إعدادات الحركة المالية
        /// </summary>
        FinancialMovementSettings = 38,
        /// <summary>
        /// إعدادات ترحيل القيود
        /// </summary>
        PostingJournalSettings = 39,
        /// <summary>
        /// اعدادات عملة النظام
        /// </summary>
        SystemCurrencySettings = 40,
        /// <summary>
        /// إعدادات عامة
        /// </summary>
        GeneralSettings = 41,
        /// <summary>
        /// تقرير كشف حساب
        /// </summary>
        AccountReport = 42,
        /// <summary>
        /// تقرير كشف حساب خزنة
        /// </summary>
        SafeAccountReport = 43,
        /// <summary>
        /// تقرير كشف حساب مورد
        /// </summary>
        VendorAccountReport = 44,
        /// <summary>
        /// تقرير كشف حساب بنك
        /// </summary>
        BankAccountReport = 45,
        /// <summary>
        /// تقرير كشف حساب مركز التكلفة
        /// </summary>
        CostCenterAccountReport = 46,
        /// <summary>
        /// ميزان مراجعة
        /// </summary>
        BalanceReviewReport = 47,
        /// <summary>
        /// تقرير رصيد الحساب
        /// </summary>
        AccountBalanceReport = 48,
        /// <summary>
        /// تقرير رصيد حساب خزنة
        /// </summary>
        SafeBalanceReport = 49,
        /// <summary>
        /// تقرير رصيد حساب مورد
        /// </summary>
        VendorBalanceReport = 50,
        /// <summary>
        /// تقرير رصيد حساب بنك
        /// </summary>
        BankBalanceReport = 51,
        /// <summary>
        /// تقرير رصيد حساب مركز التكلفة
        /// </summary>
        CostCenterBalanceReport = 52,
        /// <summary>
        /// تقرير ارصدة المخزون
        /// </summary>
        StockBalancesReport = 53,
        /// <summary>
        /// تقرير اهلاك الاصول الثابتة
        /// </summary>
        FixedAssetsDepreciationReport = 54,
        /// <summary>
        /// تقرير اماكن الاصول الثابتة
        /// </summary>
        FixedAssetsLocationReport = 55,
        /// <summary>
        /// تقرير تنقلات الاصول الثابتة
        /// </summary>
        FixedAssetsMovementsReport = 56,
        /// <summary>
        /// تقرير جرد الاصول الثابتة
        /// </summary>
        FixedAssetsInventoryReport = 57,
        /// <summary>
        /// تقرير الاصول الثابتة المفقودة
        /// </summary>
        FixedAssetsLostReport = 58,
        /// <summary>
        /// تقرير الاصول الثابتة المستبعدة
        /// </summary>
        ExcludedFixedAssetsReport = 59,
        /// <summary>
        /// قائمة البنوك
        /// </summary>
        BanksList = 60,
        /// <summary>
        /// اضافة بنك
        /// </summary>
        AddBank = 61,
        /// <summary>
        /// تعديل بنك
        /// </summary>
        EditBank = 62,
        /// <summary>
        /// قائمة العملات
        /// </summary>
        CurrencyList = 63,
        /// <summary>
        /// اضافة عملة
        /// </summary>
        AddCurrency = 64,
        /// <summary>
        /// تعديل عملة
        /// </summary>
        EditCurrency = 65,
        /// <summary>
        /// قائمة اسعار صرف العملات
        /// </summary>
        CurrencyExchangeList = 66,
        /// <summary>
        /// اضافة سعر صرف جديد
        /// </summary>
        AddCurrencyExchange = 67,
        /// <summary>
        /// تعديل سعر صرف عملة
        /// </summary>
        EditCurrencyExchange = 68,
        /// <summary>
        /// قائمة الموردين
        /// </summary>
        VendorList = 69,
        /// <summary>
        /// اضافة مورد
        /// </summary>
        AddVendor = 70,
        /// <summary>
        /// تعدبل مورد
        /// </summary>
        EditVendor = 71,
        /// <summary>
        /// قائمة الفروع
        /// </summary>
        BranchList = 72,
        /// <summary>
        /// اضافة فرع
        /// </summary>
        AddBranch = 73,
        /// <summary>
        /// تعديل فرع
        /// </summary>
        EditBranch = 74,
        /// <summary>
        /// قائمة الخزن
        /// </summary>
        SafeList = 75,
        /// <summary>
        /// اضافة خزينة
        /// </summary>
        AddSafe = 76,
        /// <summary>
        /// تعديل خزينة
        /// </summary>
        EditSafe = 77,
        /// <summary>
        /// قائمة مراكز التكلفة
        /// </summary>
        CostCenterList = 78,
        /// <summary>
        /// اضافة مركز تكلفة
        /// </summary>
        AddCostCenter = 79,
        /// <summary>
        /// تعديل مركز تكلفة
        /// </summary>
        EditCostCenter = 80,
        /// <summary>
        /// قائمة المندوبين
        /// </summary>
        DelegateList = 81,
        /// <summary>
        /// اضافة مندوب
        /// </summary>
        AddDelegate = 82,
        /// <summary>
        /// تعديل مندوب
        /// </summary>
        EditDelegate = 83,
        /// <summary>
        /// قائمة وحدات القياس
        /// </summary>
        MeasurementUnitList = 84,
        /// <summary>
        /// اضافة وحدة قياس
        /// </summary>
        AddMeasurementUnit = 85,
        /// <summary>
        /// تعديل وحدة قياس
        /// </summary>
        EditMeasurementUnit = 86,
        /// <summary>
        /// قائمة الاصناف
        /// </summary>
        BrandsList = 87,
        /// <summary>
        /// اضافة صنف
        /// </summary>
        AddBrand = 88,
        /// <summary>
        /// تعديل صنف
        /// </summary>
        EditBrand = 89,
        /// <summary>
        /// قائمة المتبرعين
        /// </summary>
        DonorList = 90,
        /// <summary>
        /// اضافة متبرع
        /// </summary>
        AddDonor = 91,
        /// <summary>
        /// تعديل متبرع
        /// </summary>
        EditDonor = 92,
        /// <summary>
        /// قائمة المخازن
        /// </summary>
        StoresList = 93,
        /// <summary>
        /// اضافة مخزن
        /// </summary>
        AddStore = 94,
        /// <summary>
        /// تعديل مخزن
        /// </summary>
        EditStore = 95,
        /// <summary>
        /// تفعيل وتعطيل الصلاحيات
        /// </summary>
        EnableDisablePermissions = 96,
        /// <summary>
        /// قائمة الادوار
        /// </summary>
        RoleList = 97,
        /// <summary>
        /// اضافة دور
        /// </summary>
        AddRole = 98,
        /// <summary>
        /// تعديل دور
        /// </summary>
        EditRole = 99,
        /// <summary>
        /// قائمة المجموعات
        /// </summary>
        GroupList = 100,
        /// <summary>
        /// اضافة مجموعة
        /// </summary>
        AddGroup = 101,
        /// <summary>
        /// تعديل مجموعة
        /// </summary>
        EditGroup = 102,
        /// <summary>
        /// قائمة المستخدمين
        /// </summary>
        UserList = 103,
        /// <summary>
        /// اضافة مستخدم
        /// </summary>
        AddUser = 104,
        /// <summary>
        /// تعديل مستخدم
        /// </summary>
        EditUser = 105,
        /// <summary>
        /// قائمة القوائم
        /// </summary>
        MenuItemList = 106,
        /// <summary>
        /// اضافة قائمة
        /// </summary>
        AddMenuItem = 107,
        /// <summary>
        /// تعديل قائمة
        /// </summary>
        EditMenuItem = 108,
        /// <summary>
        /// قائمة الاصول الثابتة المستلمة
        /// </summary>
        ReceivedFixedAssetsList = 109,
        /// <summary>
        /// اضافة اصل مستلم
        /// </summary>
        AddReceivedFixedAsset = 110,
        /// <summary>
        /// تعديل اصل مستلم
        /// </summary>
        EditReceivedFixedAsset = 111,
        /// <summary>
        /// قائمة مصروفات الاصول الثابتة
        /// </summary>
        ExpensesFixedAssetList = 112,
        /// <summary>
        /// اضافة مصروف لاصل ثابت
        /// </summary>
        AddExpensesFixedAsset = 113,
        /// <summary>
        /// تعديل مصروف اصل ثابت
        /// </summary>
        EditExpensesFixedAsset = 114,
        /// <summary>
        /// قائمة اهلاك الاصول الثابتة
        /// </summary>
        FixedAssetsDepreciationList = 115,
        /// <summary>
        /// اضافة اهلاك اصول ثابتة
        /// </summary>
        AddFixedAssetsDepreciation = 116,
        /// <summary>
        /// تعديل اهلاك اصول ثابتة
        /// </summary>
        EditFixedAssetsDepreciation = 117,
        /// <summary>
        /// قائمة الاصول الثابتة المستبعدة
        /// </summary>
        ExcludedFixedAssetsList = 118,
        /// <summary>
        /// اضافة اصل ثابت مستبعد
        /// </summary>
        AddExcludedFixedAsset = 119,
        /// <summary>
        /// تعديل اصل ثابت مستبعد
        /// </summary>
        EditExcludedFixedAsset = 120,
        /// <summary>
        /// نخصيص صلاحيات الدور
        /// </summary>
        ChangeRolePermisstions = 121,
        /// <summary>
        /// نخصيص صلاحيات المجموعة
        /// </summary>
        ChangeGroupPermisstions = 122,
        /// <summary>
        /// نخصيص ادوار المجموعة
        /// </summary>
        ChangeGroupRoles = 123,
        /// <summary>
        /// نخصيص صلاحيات المستخدمين
        /// </summary>
        ChangeUserPermisstions = 124,
        /// <summary>
        /// نخصيص ادوار المستخدمين
        /// </summary>
        ChangeUserRoles = 125,
        /// <summary>
        /// نخصيص مجموعات المستخدمين
        /// </summary>
        ChangeUserGroups = 126,
        /// <summary>
        /// نخصيص قوائم المستخدمين
        /// </summary>
        ChangeUserMenus = 127,
		/// <summary>
		/// قائمة الاماكن
		/// </summary>
		LocationList = 128,
		/// <summary>
		/// اضافة مكان
		/// </summary>
		AddLocation = 129,
		/// <summary>
		/// تعديل مكان
		/// </summary>
		EditLocation = 130,
		/// <summary>
		/// قائمة جرد الاصول الثابتة
		/// </summary>
		FixedAssetsInventoryList = 131,
		/// <summary>
		/// اضافة جرد للاصول
		/// </summary>
		AddFixedAssetsInventory = 132,
		/// <summary>
		/// تعديل جرد للاصول
		/// </summary>
		EditFixedAssetsInventory = 133,
		/// <summary>
		/// اعدادات الشجرة المحاسبية
		/// </summary>
		AccountChartSetting = 134,
        /// <summary>
		/// تقرير تاريخ التبرعات
		/// </summary>
		DonatorCasesHistoryReport = 135,
        /// <summary>
		/// تقرير ارصدة التبرعات للحالات
		/// </summary>
		DonationCasesBalanceReport = 136,
        /// <summary>
        /// قائمة انواع المصروفات
        /// </summary>
        ExpenseTypeList = 137,
        /// <summary>
        /// اضافة نوع مصروف
        /// </summary>
        AddExpenseType = 138,
        /// <summary>
        /// تعديل نوع مصروف
        /// </summary>
        EditExpenseType = 139,
        /// <summary>
        /// قائمة الدفاتر
        /// </summary>
        DocumentList = 140,
        /// <summary>
        /// اضافة دفتر
        /// </summary>
        AddDocument = 141,
        /// <summary>
        /// قائمة الدفاتر الحساب
        /// </summary>
        AccountChartDocumentList = 142,
        /// <summary>
        /// اضافة دفتر الحساب
        /// </summary>
        AddAccountChartDocument = 143,
        /// <summary>
        /// تعديل دفتر الحساب
        /// </summary>
        EditAccountChartDocument = 144,
        /// <summary>
        /// قائمة انواع مراكز التكلفة
        /// </summary>
        CostCenterTypeList = 145,
        /// <summary>
        /// اضافة نوع مركز تكلفة
        /// </summary>
        AddCostCenterType = 146,
        /// <summary>
        /// تعديل نوع مركز تكلفة
        /// </summary>
        EditCostCenterType = 147,
        /// <summary>
        /// قائمة قيود اليومية قيد الترحيل
        /// </summary>
        JournalEntriesUnderReviewList = 148,
        /// <summary>
        /// قائمة الشهور المغلقة
        /// </summary>
        ClosedMonthList = 149,
        /// <summary>
        /// اضافة شهر مغلق
        /// </summary>
        AddClosedMonth = 150,
        /// <summary>
        /// تعديل شهر مغلق
        /// </summary>
        EditClosedMonth = 151,
        /// <summary>
        /// قائمة اماكن الاصول
        /// </summary>
        AssetLocationList = 152,
        /// <summary>
        /// تغيير مكان اصل
        /// </summary>
        EditAssetLocation = 153,
		/// <summary>
		/// قائمة حسابات البنك
		/// </summary>
		BankAccountChartsList = 154,
		/// <summary>
		/// تعديل حسابات البنك
		/// </summary>
		EditBankAccountCharts = 155,
        /// <summary>
        /// امين مخازن
        /// </summary>
        Storekeeper = 156,
        /// <summary>
        /// تغير فروع المستخدم
        /// </summary>
        ChangeUserBranchs = 157,
        /// <summary>
        /// قائمة حسابات الخزن
        /// </summary>
        SafeAccountChartsList = 158,
        /// <summary>
        /// تعديل حسابات الخزن
        /// </summary>
        EditSafeAccountCharts = 159,
        /// <summary>
        /// قائمة نسبة الخصم
        /// </summary>
        DiscountPercentageList = 160,
        /// <summary>
        /// اضافة نسبة الخصم
        /// </summary>
        AddDiscountPercentage = 161,
        /// <summary>
        /// تعديل نسبة الخصم
        /// </summary>
        EditDiscountPercentage = 162,
        /// <summary>
        /// قائمة العهد و السلفيات
        /// </summary>
        TestamentList = 163,
        /// <summary>
        /// اضافة العهد و السلفيات
        /// </summary>
        AddTestament = 164,
        /// <summary>
        /// تعديل العهد و السلفيات
        /// </summary>
        EditTestament = 165,
        /// <summary>
        /// إعدادات العهد و السلفيات
        /// </summary>

        testamentAndAdvancesSettings=166

        //      AddDelegateMan = 1,
        //AddCostCenter = 2,
        //ListDelegateMan = 3
    }
}
