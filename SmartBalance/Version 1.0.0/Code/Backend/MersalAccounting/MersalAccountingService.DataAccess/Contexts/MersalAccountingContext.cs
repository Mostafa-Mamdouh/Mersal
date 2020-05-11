#region Using ...
using MersalAccountingService.DataAccess.Mappings;
using MersalAccountingService.DataAccess.Migrations;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.DataAccess.Contexts
{
	/// <summary>
	/// 
	/// </summary>
	public class MersalAccountingContext : DbContext
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type MersalAccountingContext.
		/// </summary>
		public MersalAccountingContext()
			: base("MersalAccountingConnection")
		{
			#region Do Not Initialize Database Here Because It Bad Practice For Performance
			//Database.SetInitializer(new MigrateDatabaseToLatestVersion<MersalAccountingContext, Configuration>());
			#endregion
		}
		#endregion

		#region Methods
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new AccountChartMap());
			modelBuilder.Configurations.Add(new JournalTypeMap());
			modelBuilder.Configurations.Add(new PurchaseInvoiceTypeMap());
			modelBuilder.Configurations.Add(new PurchaseInvoiceCostCenterMap());
			modelBuilder.Configurations.Add(new PurchaseRebateCostCenterMap());
			modelBuilder.Configurations.Add(new AccountChartLevelSettingMap());
			modelBuilder.Configurations.Add(new BrandMap());
			modelBuilder.Configurations.Add(new BranchMap());
			modelBuilder.Configurations.Add(new StoreMovementMap());
			modelBuilder.Configurations.Add(new JournalPostingMap());
			modelBuilder.Configurations.Add(new FiscalYearMap());
			modelBuilder.Configurations.Add(new SafeMap());
			modelBuilder.Configurations.Add(new UserPermissionMap());
			modelBuilder.Configurations.Add(new MenuItemMap());
			modelBuilder.Configurations.Add(new UserMenuItemMap());
			modelBuilder.Configurations.Add(new AssetMap());
			modelBuilder.Configurations.Add(new LocationMap());
			modelBuilder.Configurations.Add(new DepreciationRateMap());
			modelBuilder.Configurations.Add(new DepreciationTypeMap());
			modelBuilder.Configurations.Add(new DepreciationMap());
			modelBuilder.Configurations.Add(new ExpenseMap());
			modelBuilder.Configurations.Add(new ExpensesTypeMap());
			modelBuilder.Configurations.Add(new ExcludeMap());
			modelBuilder.Configurations.Add(new GroupPermissionMap());
			modelBuilder.Configurations.Add(new AssetInventoryMap());
			modelBuilder.Configurations.Add(new AssetInventoryDetailMap());
			modelBuilder.Configurations.Add(new CostCenterTypeMap());
			modelBuilder.Configurations.Add(new InventoryMovementMap());
			modelBuilder.Configurations.Add(new InventoryMovementTypeMap());
			modelBuilder.Configurations.Add(new ClosedMonthMap());
			modelBuilder.Configurations.Add(new AssetLocationMap());
			modelBuilder.Configurations.Add(new CurrencyMap());
			modelBuilder.Configurations.Add(new CurrencyRateMap());
			modelBuilder.Configurations.Add(new EffiencyRaiseHistoryMap());
			modelBuilder.Configurations.Add(new UserBranchMap());
			modelBuilder.Configurations.Add(new SafeAccountChartMap());
			modelBuilder.Configurations.Add(new TestamentMap());
			modelBuilder.Configurations.Add(new AdvancesTypeMap());
            modelBuilder.Configurations.Add(new BankMovementCostCentersMap());
            modelBuilder.Configurations.Add(new TestamentExtractionMap());
			modelBuilder.Configurations.Add(new AdvanceMap());
            modelBuilder.Configurations.Add(new LiquidationMap());


            //modelBuilder.Configurations.Add(new BankMap());
            //modelBuilder.Configurations.Add(new CostCenterMap());


            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
		}


		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets ExitPermission of context
		/// </summary>
		public IDbSet<ExitPermission> ExitPermissions { get; set; }

		/// <summary>
		/// Gets or sets EntrancePermission of context
		/// </summary>
		public IDbSet<EntrancePermission> EntrancePermissions { get; set; }

		/// <summary>
		/// Gets or sets PurchaseRebateProduct of context
		/// </summary>
		public IDbSet<PurchaseRebateProduct> PurchaseRebateProducts { get; set; }

		/// <summary>
		/// Gets or sets SalesRebateProduct of context
		/// </summary>
		public IDbSet<SalesRebateProduct> SalesRebateProducts { get; set; }

		/// <summary>
		/// Gets or sets AccountChartSetting of context
		/// </summary>
		public IDbSet<AccountChartSetting> AccountChartSettings { get; set; }

		/// <summary>
		/// Gets or sets UserGroup of context
		/// </summary>
		public IDbSet<UserGroup> UserGroups { get; set; }
		 
		/// <summary>
		/// Gets or sets GroupRole of context
		/// </summary>
		public IDbSet<GroupRole> GroupRoles { get; set; }

		/// <summary>
		/// Gets or sets Group of context
		/// </summary>
		public IDbSet<Group> Groups { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public IDbSet<GroupPermission> GroupPermissions { get; set; }

		/// <summary>
		/// Gets or sets RolePermission of context
		/// </summary>
		public IDbSet<RolePermission> RolePermissions { get; set; }

		/// <summary>
		/// Gets or sets Permission of context
		/// </summary>
		public IDbSet<Permission> Permissions { get; set; }

		/// <summary>
		/// Gets or sets UserRole of context
		/// </summary>
		public IDbSet<UserRole> UserRoles { get; set; }

		/// <summary>
		/// Gets or sets Role of context
		/// </summary>
		public IDbSet<Role> Roles { get; set; }

		/// <summary>
		/// Gets or sets CountryCallingCode of context
		/// </summary>
		public IDbSet<CountryCallingCode> CountryCallingCodes { get; set; }

		/// <summary>
		/// Gets or sets Address of context
		/// </summary>
		public IDbSet<Address> Addresss { get; set; }

		/// <summary>
		/// Gets or sets ProductPrice of context
		/// </summary>
		public IDbSet<ProductPrice> ProductPrices { get; set; }

		/// <summary>
		/// Gets or sets Journal of context
		/// </summary>
		public IDbSet<Journal> Journals { get; set; }

		/// <summary>
		/// Gets or sets ExchangeBonds of context
		/// </summary>
		public IDbSet<ExchangeBonds> ExchangeBondss { get; set; }

		/// <summary>
		/// Gets or sets Receipts of context
		/// </summary>
		public IDbSet<Receipts> Receiptss { get; set; }

		/// <summary>
		/// Gets or sets SalesRebate of context
		/// </summary>
		public IDbSet<SalesRebate> SalesRebates { get; set; }

		/// <summary>
		/// Gets or sets PurchaseRebate of context
		/// </summary>
		public IDbSet<PurchaseRebate> PurchaseRebates { get; set; }

		/// <summary>
		/// Gets or sets PurchaseInvoice of context
		/// </summary>
		public IDbSet<PurchaseInvoice> PurchaseInvoices { get; set; }

		/// <summary>
		/// Gets or sets Transaction of context
		/// </summary>
		public IDbSet<Transaction> Transactions { get; set; }

		/// <summary>
		/// Gets or sets PaymentMethod of context
		/// </summary>
		public IDbSet<PaymentMethod> PaymentMethods { get; set; }

		/// <summary>
		/// Gets or sets Asset of context
		/// </summary>
		public IDbSet<Asset> Assets { get; set; }
		/// <summary>
		/// Gets or sets EfficiencyRaiseHistory of context
		/// </summary>
		public IDbSet<EfficiencyRaiseHistory> EfficiencyRaiseHistories { get; set; }

		/// <summary>
		/// Gets or sets AssetCategory of context
		/// </summary>
		public IDbSet<AssetCategory> AssetCategorys { get; set; }

		/// <summary>
		/// Gets or sets Inventory of context
		/// </summary>
		public IDbSet<Inventory> Inventorys { get; set; }

		/// <summary>
		/// Gets or sets Product of context
		/// </summary>
		public IDbSet<Product> Products { get; set; }

		/// <summary>
		/// Gets or sets ProductType of context
		/// </summary>
		public IDbSet<ProductType> ProductTypes { get; set; }

		/// <summary>
		/// Gets or sets StoreMeasurementUnit of context
		/// </summary>
		public IDbSet<StoreMeasurementUnit> StoreMeasurementUnits { get; set; }

		public IDbSet<MeasurementUnit> MeasurementUnits { get; set; }
		/// <summary>
		/// Gets or sets DelegateMan of context
		/// </summary>
		public IDbSet<DelegateMan> DelegateMans { get; set; }

		/// <summary>
		/// Gets or sets Case of context
		/// </summary>
		public IDbSet<Case> Cases { get; set; }

		/// <summary>
		/// Gets or sets CaseType of context
		/// </summary>
		public IDbSet<CaseType> CaseTypes { get; set; }

		/// <summary>
		/// Gets or sets CostCenter of context
		/// </summary>
		public IDbSet<CostCenter> CostCenters { get; set; }

		/// <summary>
		/// Gets or sets Bank of context
		/// </summary>
		public IDbSet<Bank> Banks { get; set; }

		/// <summary>
		/// Gets or sets Safe of context
		/// </summary>
		public IDbSet<Safe> Safes { get; set; }

		/// <summary>
		/// Gets or sets AccountChart of context
		/// </summary>
		public IDbSet<AccountChart> AccountCharts { get; set; }

		/// <summary>
		/// Gets or sets VendorType of context
		/// </summary>
		public IDbSet<VendorType> VendorTypes { get; set; }

		/// <summary>
		/// Gets or sets Vendor of context
		/// </summary>
		public IDbSet<Vendor> Vendors { get; set; }

		/// <summary>
		/// Gets or sets AccountType of context
		/// </summary>
		public IDbSet<AccountType> AccountTypes { get; set; }

		/// <summary>
		/// Gets or sets Branch of context
		/// </summary>
		public IDbSet<Branch> Branchs { get; set; }

		/// <summary>
		/// Gets or sets Donation of context
		/// </summary>
		public IDbSet<Donation> Donations { get; set; }
		public IDbSet<DonationProduct> DonationProducts { get; set; }
		public IDbSet<DonationCase> DonationCases { get; set; }
		public IDbSet<DonationInventory> DonationInventorys { get; set; }
		public IDbSet<DonationType> DonationTypes { get; set; }

		/// <summary>
		/// Gets or sets CurrencyRate of context
		/// </summary>
		public IDbSet<CurrencyRate> CurrencyRates { get; set; }

		/// <summary>
		/// Gets or sets Currency of context
		/// </summary>
		public IDbSet<Currency> Currencys { get; set; }

		/// <summary>
		/// Gets or sets User of context
		/// </summary>
		public IDbSet<User> Users { get; set; }

		/// <summary>
		/// Gets or sets Attachment of context
		/// </summary>
		public IDbSet<Attachment> Attachments { get; set; }

		/// <summary>
		/// Gets or sets Country of context
		/// </summary>
		public IDbSet<Country> Countrys { get; set; }

		/// <summary>
		/// Gets or sets City of context
		/// </summary>
		public IDbSet<City> Citys { get; set; }

		/// <summary>
		/// Gets or sets District of context
		/// </summary>
		public IDbSet<District> Districts { get; set; }

		/// <summary>
		/// Gets or sets StockAssessmentPolicy of context
		/// </summary>
		public IDbSet<StockAssessmentPolicy> StockAssessmentPolicys { get; set; }

		/// <summary>
		/// Gets or sets Mail of context
		/// </summary>
		public IDbSet<Mail> Mails { get; set; }

		/// <summary>
		/// Gets or sets Mobile of context
		/// </summary>
		public IDbSet<Mobile> Mobiles { get; set; }

		/// <summary>
		/// Gets or sets BankMovement of context
		/// </summary>
		public IDbSet<BankMovement> BankMovements { get; set; }

		/// <summary>
		/// Gets or sets Transfer of context
		/// </summary>
		public IDbSet<Transfer> Transfers { get; set; }

		/// <summary>
		/// Gets or sets InventoryTransfer of context
		/// </summary>
		public IDbSet<InventoryTransfer> InventoryTransfers { get; set; }

		/// <summary>
		/// Gets or sets InventoryMovement of context
		/// </summary>
		public IDbSet<InventoryMovement> InventoryMovements { get; set; }

		/// <summary>
		/// Gets or sets InventoryIn of context
		/// </summary>
		public IDbSet<InventoryIn> InventoryIns { get; set; }

		/// <summary>
		/// Gets or sets InventoryOut of context
		/// </summary>
		public IDbSet<InventoryOut> InventoryOuts { get; set; }

		/// <summary>
		/// Gets or sets InventoryDifference of context
		/// </summary>
		public IDbSet<InventoryDifference> InventoryDifferences { get; set; }

		/// <summary>
		/// Many To Many between costcenter and salesbill entity
		/// </summary>
		public IDbSet<CostCenterBill> CostCenterBills { get; set; }

		public IDbSet<ReceivingMethod> ReceivingMethods { get; set; }

		public IDbSet<PaymentMovment> PaymentMovments { get; set; }
		public IDbSet<PaymentMovmentCostCenter> PaymentMovmentCostCenters { get; set; }
		public IDbSet<PaymentMovmentInventory> PaymentMovmentInventories { get; set; }

		public IDbSet<AccountChartGroup> AccountChartGroups { get; set; }
		public IDbSet<AccountChartCategory> AccountChartCategories { get; set; }
		public IDbSet<Donator> Donators { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public IDbSet<Setting> Settings { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public IDbSet<JournalType> JournalTypes { get; set; }
		/// <summary>
		/// Gets or sets PurchaseInvoiceType of context
		/// </summary>
		public IDbSet<PurchaseInvoiceType> PurchaseInvoiceTypes { get; set; }

		/// <summary>
		/// Gets or sets PurchaseInvoiceCostCenter of context
		/// </summary>
		public IDbSet<PurchaseInvoiceCostCenter> PurchaseInvoiceCostCenters { get; set; }

		/// <summary>
		/// Gets or sets PurchaseRebateCostCenter of context
		/// </summary>
		public IDbSet<PurchaseRebateCostCenter> PurchaseRebateCostCenters { get; set; }

		/// <summary>
		/// Gets or sets AccountChartLevelSetting of context
		/// </summary>
		public IDbSet<AccountChartLevelSetting> AccountChartLevelSettings { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public IDbSet<Brand> Brands { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public IDbSet<StoreMovement> StoreMovements { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public IDbSet<JournalPosting> JournalPostings { get; set; }

		/// <summary>
		/// Gets or sets FiscalYear of context
		/// </summary>
		public IDbSet<FiscalYear> FiscalYears { get; set; }


		/// <summary>
		/// 
		/// </summary>
		public IDbSet<InventoryOpeningBalance> InventoryOpeningBalance { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public IDbSet<InventoryOpeningBalanceCostCenter> InventoryOpeningBalanceCostCenter { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public IDbSet<InventoryMovementCostCenter> InventoryMovementCostCenter { get; set; }


		/// <summary>
		/// 
		/// </summary>
		public IDbSet<InventoryTransferCostCenter> InventoryTransferCostCenter { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public IDbSet<InventoryMovementType> InventoryMovementType { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public IDbSet<InventoryProductHistory> InventoryProductHistory { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public IDbSet<UserPermission> UserPermissions { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public IDbSet<MenuItem> MenuItems { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public IDbSet<UserMenuItem> UserMenuItems { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public IDbSet<Location> Locations { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public IDbSet<DepreciationRate> DepreciationRates { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public IDbSet<DepreciationType> DepreciationTypes { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public IDbSet<Expense> Expenses { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public IDbSet<ExpensesType> ExpensesTypes { get; set; }

		public IDbSet<Depreciation> Depreciations { get; set; }

		public IDbSet<Exclude> Excludes { get; set; }


		public IDbSet<AssetInventory> AssetInventorys { get; set; }
		public IDbSet<AssetInventoryDetail> AssetInventoryDetails { get; set; }

		public IDbSet<Document> Documents { get; set; }

		public IDbSet<AccountChartDocument> AccountDocuments { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public IDbSet<DiscountPercentage> DiscountPercentages { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public IDbSet<CostCenterType> CostCenterTypes { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public IDbSet<ObjectCostCenter> ObjectCostCenters { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public IDbSet<ClosedMonth> ClosedMonths { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public IDbSet<AssetLocation> AssetLocations { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public IDbSet<ClosedReceipt> ClosedReceipts { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public IDbSet<ClosedCheque> ClosedCheques { get; set; }

		public IDbSet<UserBranch> UserBranches { get; set; }

		public IDbSet<SafeAccountChart> SafeAccountCharts { get; set; }

        public IDbSet<BankMovementCostCenters> BankMovementCostCenters { get; set; }

		public IDbSet<Testament> Testaments { get; set; }

        public IDbSet<AdvancesType> AdvancesTypes { get; set; }
        public IDbSet<TestamentExtraction> TestamentExtractions { get; set; }
		public IDbSet<Advance> Advances { get; set; }
        public IDbSet<Liquidation> Liquidations { get; set; }
        public IDbSet<LiquidationDetail> LiquidationDetails { get; set; }
        public IDbSet<DonationVendor> DonationVendors { get; set; }
        public ISet<DonationAccountChart> DonationAccountCharts { get; set; }
        public IDbSet<PaymentMovmentVendor> PaymentMovmentVendors { get; set; }
        public IDbSet<PaymentMovementDonator> paymentMovementDonators { get; set; }
        public IDbSet<PaymentMovmentAccountChart> paymentMovmentAccountCharts { get; set; }
        public IDbSet<PaymentMovmentNotificationDiscount> PaymentMovmentNotificationDiscounts { get; set; }




        #endregion
    }


}
