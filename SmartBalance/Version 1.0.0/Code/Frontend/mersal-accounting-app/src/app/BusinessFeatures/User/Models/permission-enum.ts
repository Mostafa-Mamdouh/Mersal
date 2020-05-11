export enum PermissionEnum {
  /**
  * قائمة حركات المقبوضات
  */
  movementsReceivedList = 1,
  /**
  * اضافة حركة مقبوضات
  */
  addMovementsReceived = 2,
  /**
  * تعديل حركة مقبوضات
  */
  editMovementsReceived = 3,
  /**
  *  طباعة ايصال مقبوضات
  */
  printReceipt = 4,
  /**
  * قائمة حركات المدفوعات
  */
  paymentsMovementsList = 5,
  /**
  * اضافة حركة مدفوعات
  */
  addPaymentsMovements = 6,
  /**
  * تعديل حركة مدفوعات
  */
  editPaymentsMovements = 7,
  /**
  * قائمة فواتير المشتريات
  */
  purchaseInvoicesList = 8,
  /**
  * اضافة فاتورة مشتريات
  */
  addPurchaseInvoice = 9,
  /**
  * تعديل فاتورة مشتريات
  */
  editPurchaseInvoice = 10,
  /**
  * قائمة مرتد المشتريات
  */
  purchaseRebateList = 11,
  /**
  * اضافة مرتد مشتريات
  */
  addPurchaseRebate = 12,
  /**
  * تعديل مرتد مشتريات
  */
  editPurchaseRebate = 13,
  /**
  * قائمة حركات البنوك
  */
  bankMovementsList = 14,
  /**
  * اضافة حركات البنوك
  */
  addBankMovement = 15,
  /**
  * تعديل حركات البنوك
  */
  editBankMovement = 16,
  /**
  * قائمة قيود اليومية
  */
  journalEntriesList = 17,
  /**
  * اضافة حركة يومية
  */
  addJournalEntries = 18,
  /**
  * عكس قيد يومية
  */
  reverseJournalEntries = 19,
  /**
  * الموافقة على قيود قيد الترحيل
  */
  approveOrRejectJournalEntriesUnderReview = 20,
  /**
  * ترحيل قيود اليومية
  */
  postJournalEntries = 21,
  /**
  * التحكم فى حسابات كل ترحيل
  */
  controlPostingJournalEntries = 22,
  /**
  * مشاهدة الشجرة المحاسبية
  */
  viewAccountChart = 23,
  /**
  * اضافة حساب للشجرة المحاسبية
  */
  addAccountChart = 24,
  /**
  * تعديل حساب فى الشجرة المحاسبية
  */
  editAccountChart = 25,
  /**
  * التحكم فى شيكات تحت التحصيل
  */
  controlChecksUnderCollection = 26,
  /**
  * قائمة الرصيد الافتتاحى للمخازن
  */
  openingBalanceList = 27,
  /**
  * اضافة رصيد افتتاحى
  */
  addOpeningBalance = 28,
  /**
  * تعديل رصيد افتتاحى
  */
  editOpeningBalance = 29,
  /**
  * قائمة حركة المخزون
  */
  inventoryMovementList = 30,
  /**
  * اضافة حركة مخزون
  */
  addInventoryMovement = 31,
  /**
  * تعديل حركة مخزون
  */
  editInventoryMovement = 32,
  /**
  * قائمة تحويلات المخزون
  */
  inventoryTransfersList = 33,
  /**
  * اضافة تحويلات المخزون
  */
  addInventoryTransfers = 34,
  /**
  * تعديل تحويلات المخزون
  */
  editInventoryTransfers = 35,
  /**
  * إعدادات ضريبة القيمة المضافة
  */
  vatSettings = 36,
  /**
  * إعدادات نظام الموردين
  */
  vendorSystemSettings = 37,
  /**
  * إعدادات الحركة المالية
  */
  financialMovementSettings = 38,
  /**
  * إعدادات ترحيل القيود
  */
  postingJournalSettings = 39,
  /**
  * اعدادات عملة النظام
  */
  systemCurrencySettings = 40,
  /**
  * إعدادات عامة
  */
  generalSettings = 41,
  /**
  * تقرير كشف حساب
  */
  accountReport = 42,
  /**
  * تقرير كشف حساب خزنة
  */
  safeAccountReport = 43,
  /**
  * تقرير كشف حساب مورد
  */
  vendorAccountReport = 44,
  /**
  * تقرير كشف حساب بنك
  */
  bankAccountReport = 45,
  /**
  * تقرير كشف حساب مركز التكلفة
  */
  costCenterAccountReport = 46,
  /**
  * ميزان مراجعة
  */
  balanceReviewReport = 47,
  /**
  * تقرير رصيد الحساب
  */
  accountBalanceReport = 48,
  /**
  * تقرير رصيد حساب خزنة
  */
  safeBalanceReport = 49,
  /**
  * تقرير رصيد حساب مورد
  */
  vendorBalanceReport = 50,
  /**
  * تقرير رصيد حساب بنك
  */
  bankBalanceReport = 51,
  /**
  * تقرير رصيد حساب مركز التكلفة
  */
  costCenterBalanceReport = 52,
  /**
  * تقرير ارصدة المخزون
  */
  stockBalancesReport = 53,
  /**
  * تقرير اهلاك الاصول الثابتة
  */
  fixedAssetsDepreciationReport = 54,
  /**
  * تقرير اماكن الاصول الثابتة
  */
  fixedAssetsLocationReport = 55,
  /**
  * تقرير تنقلات الاصول الثابتة
  */
  fixedAssetsMovementsReport = 56,
  /**
  * تقرير جرد الاصول الثابتة
  */
  fixedAssetsInventoryReport = 57,
  /**
  * تقرير الاصول الثابتة المفقودة
  */
  fixedAssetsLostReport = 58,
  /**
  * تقرير الاصول الثابتة المستبعدة
  */
  excludedFixedAssetsReport = 59,
  /**
  * قائمة البنوك
  */
  banksList = 60,
  /**
  * اضافة بنك
  */
  addBank = 61,
  /**
  * تعديل بنك
  */
  editBank = 62,
  /**
  * قائمة العملات
  */
  currencyList = 63,
  /**
  * اضافة عملة
  */
  addCurrency = 64,
  /**
  * تعديل عملة
  */
  editCurrency = 65,
  /**
  * قائمة اسعار صرف العملات
  */
  currencyExchangeList = 66,
  /**
  * اضافة سعر صرف جديد
  */
  addCurrencyExchange = 67,
  /**
  * تعديل سعر صرف عملة
  */
  editCurrencyExchange = 68,
  /**
  * قائمة الموردين
  */
  vendorList = 69,
  /**
  * اضافة مورد
  */
  addVendor = 70,
  /**
  * تعدبل مورد
  */
  editVendor = 71,
  /**
  * قائمة الفروع
  */
  branchList = 72,
  /**
  * اضافة فرع
  */
  addBranch = 73,
  /**
  * تعديل فرع
  */
  editBranch = 74,
  /**
  * قائمة الخزن
  */
  safeList = 75,
  /**
  * اضافة خزينة
  */
  addSafe = 76,
  /**
  * تعديل خزينة
  */
  editSafe = 77,
  /**
  * قائمة مراكز التكلفة
  */
  costCenterList = 78,
  /**
  * اضافة مركز تكلفة
  */
  addCostCenter = 79,
  /**
  * تعديل مركز تكلفة
  */
  editCostCenter = 80,
  /**
  * قائمة المندوبين
  */
  delegateList = 81,
  /**
  * اضافة مندوب
  */
  addDelegate = 82,
  /**
  * تعديل مندوب
  */
  editDelegate = 83,
  /**
  * قائمة وحدات القياس
  */
  measurementUnitList = 84,
  /**
  * اضافة وحدة قياس
  */
  addMeasurementUnit = 85,
  /**
  * تعديل وحدة قياس
  */
  editMeasurementUnit = 86,
  /**
  * قائمة الاصناف
  */
  brandsList = 87,
  /**
  * اضافة صنف
  */
  addBrand = 88,
  /**
  * تعديل صنف
  */
  editBrand = 89,
  /**
  * قائمة المتبرعين
  */
  donorList = 90,
  /**
  * اضافة متبرع
  */
  addDonor = 91,
  /**
  * تعديل متبرع
  */
  editDonor = 92,
  /**
  * قائمة المخازن
  */
  storesList = 93,
  /**
  * اضافة مخزن
  */
  addStore = 94,
  /**
  * تعديل مخزن
  */
  editStore = 95,
  /**
  * تفعيل وتعطيل الصلاحيات
  */
  enableDisablePermissions = 96,
  /**
  * قائمة الادوار
  */
  roleList = 97,
  /**
  * اضافة دور
  */
  addRole = 98,
  /**
  * تعديل دور
  */
  editRole = 99,
  /**
  * قائمة المجموعات
  */
  groupList = 100,
  /**
  * اضافة مجموعة
  */
  addGroup = 101,
  /**
  * تعديل مجموعة
  */
  editGroup = 102,
  /**
  * قائمة المستخدمين
  */
  userList = 103,
  /**
  * اضافة مستخدم
  */
  addUser = 104,
  /**
  * تعديل مستخدم
  */
  editUser = 105,
  /**
  * قائمة القوائم
  */
  menuItemList = 106,
  /**
  * اضافة قائمة
  */
  addMenuItem = 107,
  /**
  * تعديل قائمة
  */
  editMenuItem = 108,
  /**
  * قائمة الاصول الثابتة المستلمة
  */
  receivedFixedAssetsList = 109,
  /**
  * اضافة اصل مستلم
  */
  addReceivedFixedAsset = 110,
  /**
  * تعديل اصل مستلم
  */
  editReceivedFixedAsset = 111,
  /**
  * قائمة مصروفات الاصول الثابتة
  */
  expensesFixedAssetList = 112,
  /**
  * اضافة مصروف لاصل ثابت
  */
  addExpensesFixedAsset = 113,
  /**
  * تعديل مصروف اصل ثابت
  */
  editExpensesFixedAsset = 114,
  /**
  * قائمة اهلاك الاصول الثابتة
  */
  fixedAssetsDepreciationList = 115,
  /**
  * اضافة اهلاك اصول ثابتة
  */
  addFixedAssetsDepreciation = 116,
  /**
  * تعديل اهلاك اصول ثابتة
  */
  editFixedAssetsDepreciation = 117,
  /**
  * قائمة الاصول الثابتة المستبعدة
  */
  excludedFixedAssetsList = 118,
  /**
  * اضافة اصل ثابت مستبعد
  */
  addExcludedFixedAsset = 119,
  /**
  * تعديل اصل ثابت مستبعد
  */
  editExcludedFixedAsset = 120,
  /**
  * نخصيص صلاحيات الدور
  */
  changeRolePermisstions = 121,
  /**
  * نخصيص صلاحيات المجموعة
  */
  changeGroupPermisstions = 122,
  /**
  * نخصيص ادوار المجموعة
  */
  changeGroupRoles = 123,
  /**
  * نخصيص صلاحيات المستخدمين
  */
  changeUserPermisstions = 124,
  /**
  * نخصيص ادوار المستخدمين
  */
  changeUserRoles = 125,
  /**
  * نخصيص مجموعات المستخدمين
  */
  changeUserGroups = 126,
  /**
  * نخصيص قوائم المستخدمين
  */
  changeUserMenus = 127,
  /**
  * قائمة الاماكن
  */
  locationList = 128,
  /**
  * اضافة مكان
  */
  addLocation = 129,
  /**
  * تعديل مكان
  */
  editLocation = 130,
  /**
  * قائمة جرد الاصول الثابتة
  */
  fixedAssetsInventoryList = 131,
  /**
  * اضافة جرد للاصول
  */
  addFixedAssetsInventory = 132,
  /**
  * تعديل جرد للاصول
  */
  editFixedAssetsInventory = 133,
  /**
  * اعدادات الشجرة المحاسبية
  */
  accountChartSetting = 134,
  /**
* تقرير تاريخ التبرعات
*/
  donatorCasesHistoryReport = 135,
  /**
* تقرير ارصدة التبرعات للحالات
*/
  donationCasesBalanceReport = 136,
  /**
  * قائمة انواع المصروفات
  */
  expenseTypeList = 137,
  /**
  * اضافة نوع مصروف
  */
  addExpenseType = 138,
  /**
  * تعديل نوع مصروف
  */
  editExpenseType = 139,
  /**
  * قائمة الدفاتر
  */
  documentList = 140,
  /**
  * اضافة دفتر
  */
  addDocument = 141,
  /**
  * قائمة الدفاتر الحساب
  */
  accountChartDocumentList = 142,
  /**
  * اضافة دفتر الحساب
  */
  addAccountChartDocument = 143,
  /**
  * تعديل دفتر الحساب
  */
  editAccountChartDocument = 144,
  /**
  * قائمة انواع مراكز التكلفة
  */
  costCenterTypeList = 145,
  /**
  * اضافة نوع مركز تكلفة
  */
  addCostCenterType = 146,
  /**
  * تعديل نوع مركز تكلفة
  */
  editCostCenterType = 147,
  /**
  * قائمة قيود اليومية قيد الترحيل
  */
  journalEntriesUnderReviewList = 148,
  /**
  * قائمة الشهور المغلقة
  */
  closedMonthList = 149,
  /**
  * اضافة شهر مغلق
  */
  addClosedMonth = 150,
  /**
  * تعديل شهر مغلق
  */
  editClosedMonth = 151,
  /**
  * قائمة اماكن الاصول
  */
  assetLocationList = 152,
  /**
  * تغيير مكان اصل
  */
  editAssetLocation = 153,
  /**
	* قائمة حسابات البنك
	*/
  bankAccountChartsList = 154,
  /**
  * تعديل حسابات البنك
  */
  editBankAccountCharts = 155,
  /**
   * امين مخازن
   */
  Storekeeper = 156,
  /** 
  * تغير فروع المستخدم
  */
  changeUserBranchs = 157,
  /*
  * قائمة حسابات الخزن
  */
  safeAccountChartsList = 158,
  /*
  * تعديل حسابات الخزن
  */
  editSafeAccountCharts = 159,
  /* 
  * قائمة نسبة الخصم
  */
  discountPercentageList = 160,
  /*
  * اضافة نسبة الخصم
  */
  addDiscountPercentage = 161,
  /*
   * تعديل نسبة الخصم
  */
  editDiscountPercentage = 162,
  /*
  * قائمة العهد و السلفيات
  */
  testamentList = 163,
  /*
  * اضافة العهد و السلفيات
  */
  addTestament = 164,
  /*
  * تعديل العهد و السلفيات
  */
  editTestament = 165,
  /**
* إعدادات العهد و السلفيات
*/
  testamentAndAdvancesSettings = 166,
}