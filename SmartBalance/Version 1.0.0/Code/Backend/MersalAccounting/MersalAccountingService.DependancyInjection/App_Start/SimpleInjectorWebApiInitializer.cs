//[assembly: WebActivator.PostApplicationStartMethod(typeof(MersalAccountingService.DependancyInjection.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

#region Using ...
using System.Web.Http;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using Framework.Core.Common;
using MersalAccountingService.BusinessLogic.Common;
using MersalAccountingService.Core.IServices;
using MersalAccountingService.Core.IRepositories;
using MersalAccountingService.DataAccess.Repositories;
using MersalAccountingService.BusinessLogic.Services;
using MersalAccountingService.DataAccess.Contexts;
using Framework.DataAccess.Repositories;
using Framework.Core.IRepositories;
using System.Data.Entity;
using MersalAccountingService.Core.Common;
using System.Data.Entity.Migrations;
#endregion

namespace MersalAccountingService.DependancyInjection.App_Start
{
	/// <summary>
	/// 
	/// </summary>
	public static class SimpleInjectorWebApiInitializer
	{
		#region Data Members
		private static Container _Container;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type 
		/// SimpleInjectorWebApiInitializer.
		/// </summary>
		static SimpleInjectorWebApiInitializer()
		{
			_Container = new Container();
		}
		#endregion

		#region Methods

		/// <summary>
		/// Initialize the container and register it as Web API Dependency Resolver.
		/// </summary>
		/// <param name="configuration"></param>
		public static void Initialize(HttpConfiguration configuration)
		{
			_Container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

			InitializeContainer(_Container);

			_Container.RegisterWebApiControllers(configuration);

			_Container.Verify();

			configuration.DependencyResolver =
				new SimpleInjectorWebApiDependencyResolver(_Container);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="container"></param>
		private static void InitializeContainer(Container container)
		{
			#region Register Context
			container.Register<MersalAccountingContext, MersalAccountingContext>(Lifestyle.Scoped);
			container.Register<DbMigrationsConfiguration, MersalAccountingService.DataAccess.Migrations.Configuration>(Lifestyle.Singleton);
			#endregion

			#region Register Repository           
			container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);

			container.Register<ISalesBillRepository, SalesBillRepository>(Lifestyle.Scoped);

			container.Register<IExitPermissionsRepository, ExitPermissionsRepository>(Lifestyle.Scoped);

			container.Register<IEntrancePermissionsRepository, EntrancePermissionsRepository>(Lifestyle.Scoped);

			container.Register<IPurchaseRebateProductsRepository, PurchaseRebateProductsRepository>(Lifestyle.Scoped);

			container.Register<ISalesRebateProductsRepository, SalesRebateProductsRepository>(Lifestyle.Scoped);

			container.Register<IAccountChartSettingsRepository, AccountChartSettingsRepository>(Lifestyle.Scoped);

			container.Register<IAccountChartGroupsRepository, AccountChartGroupsRepository>(Lifestyle.Scoped);

			container.Register<IUserGroupsRepository, UserGroupsRepository>(Lifestyle.Scoped);

			container.Register<IGroupRolesRepository, GroupRolesRepository>(Lifestyle.Scoped);

			container.Register<IGroupsRepository, GroupsRepository>(Lifestyle.Scoped);

			container.Register<IGroupPermissionsRepository, GroupPermissionsRepository>(Lifestyle.Scoped);

			container.Register<IRolePermissionsRepository, RolePermissionsRepository>(Lifestyle.Scoped);

			container.Register<IPermissionsRepository, PermissionsRepository>(Lifestyle.Scoped);

			container.Register<IUserRolesRepository, UserRolesRepository>(Lifestyle.Scoped);

            container.Register<IUserPermissionsRepository, UserPermissionsRepository>(Lifestyle.Scoped);

            container.Register<IRolesRepository, RolesRepository>(Lifestyle.Scoped);

			container.Register<ICountryCallingCodesRepository, CountryCallingCodesRepository>(Lifestyle.Scoped);

			container.Register<IAddresssRepository, AddresssRepository>(Lifestyle.Scoped);

			container.Register<IProductPricesRepository, ProductPricesRepository>(Lifestyle.Scoped);

			container.Register<IJournalsRepository, JournalsRepository>(Lifestyle.Scoped);

			container.Register<IExchangeBondssRepository, ExchangeBondssRepository>(Lifestyle.Scoped);

			container.Register<IReceiptssRepository, ReceiptssRepository>(Lifestyle.Scoped);

			container.Register<ISalesRebatesRepository, SalesRebatesRepository>(Lifestyle.Scoped);

			container.Register<IPurchaseRebatesRepository, PurchaseRebatesRepository>(Lifestyle.Scoped);

			container.Register<IPurchaseInvoicesRepository, PurchaseInvoicesRepository>(Lifestyle.Scoped);

			container.Register<ITransactionsRepository, TransactionsRepository>(Lifestyle.Scoped);

			container.Register<IPaymentMethodsRepository, PaymentMethodsRepository>(Lifestyle.Scoped);

			container.Register<IAssetsRepository, AssetsRepository>(Lifestyle.Scoped);

            container.Register<IEffiencyRaiseHistoryRepository, EffiencyRaiseHistoryRepository>(Lifestyle.Scoped);

            container.Register<IAssetCategorysRepository, AssetCategorysRepository>(Lifestyle.Scoped);

			container.Register<IInventorysRepository, InventorysRepository>(Lifestyle.Scoped);

			container.Register<IProductsRepository, ProductsRepository>(Lifestyle.Scoped);

            container.Register<IInventoryProductHistoryRepository, InventoryProductHistoryRepository>(Lifestyle.Scoped);

            container.Register<IProductTypesRepository, ProductTypesRepository>(Lifestyle.Scoped);

			container.Register<IStoreMeasurementUnitsRepository, StoreMeasurementUnitsRepository>(Lifestyle.Scoped);

			container.Register<IDelegateMansRepository, DelegateMansRepository>(Lifestyle.Scoped);

			container.Register<ICasesRepository, CasesRepository>(Lifestyle.Scoped);

			container.Register<ICaseTypesRepository, CaseTypesRepository>(Lifestyle.Scoped);

			container.Register<ICostCentersRepository, CostCentersRepository>(Lifestyle.Scoped);

			container.Register<IBanksRepository, BanksRepository>(Lifestyle.Scoped);

			container.Register<ISafesRepository, SafesRepository>(Lifestyle.Scoped);

			container.Register<IAccountChartsRepository, AccountChartsRepository>(Lifestyle.Scoped);

			container.Register<IVendorTypesRepository, VendorTypesRepository>(Lifestyle.Scoped);

			container.Register<IVendorsRepository, VendorsRepository>(Lifestyle.Scoped);

			container.Register<IAccountTypesRepository, AccountTypesRepository>(Lifestyle.Scoped);

			container.Register<IBranchsRepository, BranchsRepository>(Lifestyle.Scoped);

			container.Register<IDonationsRepository, DonationsRepository>(Lifestyle.Scoped);

			container.Register<ICurrencyRatesRepository, CurrencyRatesRepository>(Lifestyle.Scoped);

			container.Register<ICurrencysRepository, CurrencysRepository>(Lifestyle.Scoped);

			container.Register<IUsersRepository, UsersRepository>(Lifestyle.Scoped);

			container.Register<IAttachmentsRepository, AttachmentsRepository>(Lifestyle.Scoped);

			container.Register<ICountrysRepository, CountrysRepository>(Lifestyle.Scoped);

			container.Register<ICitysRepository, CitysRepository>(Lifestyle.Scoped);

			container.Register<IDistrictsRepository, DistrictsRepository>(Lifestyle.Scoped);

			container.Register<IStockAssessmentPolicysRepository, StockAssessmentPolicysRepository>(Lifestyle.Scoped);

			container.Register<IMailsRepository, MailsRepository>(Lifestyle.Scoped);

			container.Register<IMobilesRepository, MobilesRepository>(Lifestyle.Scoped);

			container.Register<IBankMovementsRepository, BankMovementsRepository>(Lifestyle.Scoped);

			container.Register<ITransfersRepository, TransfersRepository>(Lifestyle.Scoped);

            container.Register<IInventoryOpeningBalanceCostCenterRepository, InventoryOpeningBalanceCostCenterRepository>(Lifestyle.Scoped);

            container.Register<IInventoryOpeningBalanceRepository, InventoryOpeningBalanceRepository>(Lifestyle.Scoped);

            container.Register<IInventoryTransfersRepository, InventoryTransfersRepository>(Lifestyle.Scoped);

            container.Register<IInventoryTransferCostCenterRepository, InventoryTransferCostCenterRepository>(Lifestyle.Scoped);

            container.Register<IInventoryMovementsRepository, InventoryMovementsRepository>(Lifestyle.Scoped);

            container.Register<IInventoryMovementCostCenterRepository, InventoryMovementCostCenterRepository>(Lifestyle.Scoped);

            container.Register<IInventoryMovementTypeRepository, InventoryMovementTypeRepository>(Lifestyle.Scoped);

            container.Register<IInventoryInsRepository, InventoryInsRepository>(Lifestyle.Scoped);

			container.Register<IInventoryOutsRepository, InventoryOutsRepository>(Lifestyle.Scoped);

			container.Register<IInventoryDifferencesRepository, InventoryDifferencesRepository>(Lifestyle.Scoped);

			container.Register<IDonatorRepository, DonatorsRepository>(Lifestyle.Scoped);

			container.Register<IMeasurementUnitsRepository, MeasurementUnitsRepository>(Lifestyle.Scoped);

			container.Register<ISalesBillTypesRepository, SalesBillTypeRepository>(Lifestyle.Scoped);

			container.Register<IReceivingMehtodsRepository, ReceivingMethodsRepository>(Lifestyle.Scoped);

			container.Register<ITransactionsDetailsRepository, TransactionsDetailsRepository>(Lifestyle.Scoped);
			container.Register<IPaymentMovmentsRepository, PaymentMovmentsRepository>(Lifestyle.Scoped);
			container.Register<IGeneralAccountsRepository, GeneralAccountRepository>(Lifestyle.Scoped);

			container.Register<IDonationTypesRepository, DonationTypesRepository>(Lifestyle.Scoped);

			container.Register<IAccountChartCategoriesRepository, AccountChartCategoriesRepository>(Lifestyle.Scoped);

			container.Register<ISettingsRepository, SettingsRepository>(Lifestyle.Scoped);

			container.Register<IJournalTypesRepository, JournalTypesRepository>(Lifestyle.Scoped);

			container.Register<IPurchaseInvoiceTypesRepository, PurchaseInvoiceTypesRepository>(Lifestyle.Scoped);

			container.Register<IPurchaseInvoiceCostCentersRepository, PurchaseInvoiceCostCentersRepository>(Lifestyle.Scoped);

			container.Register<IPurchaseRebateCostCentersRepository, PurchaseRebateCostCentersRepository>(Lifestyle.Scoped);

			container.Register<IAccountChartLevelSettingsRepository, AccountChartLevelSettingsRepository>(Lifestyle.Scoped);

			container.Register<IBrandsRepository, BrandsRepository>(Lifestyle.Scoped);

			container.Register<IStoreMovementsRepository, StoreMovementsRepository>(Lifestyle.Scoped);

			container.Register<IJournalPostingsRepository, JournalPostingsRepository>(Lifestyle.Scoped);

			container.Register<IFiscalYearsRepository, FiscalYearsRepository>(Lifestyle.Scoped);

            container.Register<IMenuItemsRepository, MenuItemsRepository>(Lifestyle.Scoped);

            container.Register<IUserMenuItemsRepository, UserMenuItemsRepository>(Lifestyle.Scoped);

            container.Register<ILocationsRepository, LocationsRepository>(Lifestyle.Scoped);

            container.Register<IDepreciationRatesRepository, DepreciationRatesRepository>(Lifestyle.Scoped);

            container.Register<IDepreciationTypesRepository, DepreciationTypesRepository>(Lifestyle.Scoped);

            container.Register<IExpensesRepository, ExpensesRepository>(Lifestyle.Scoped);

            container.Register<IExpensesTypesRepository, ExpensesTypesRepository>(Lifestyle.Scoped);

            container.Register<IDepreciationsRepository, DepreciationsRepository>(Lifestyle.Scoped);

            container.Register<IExcludesRepository, ExcludesRepository>(Lifestyle.Scoped);

            container.Register<IAssetInventorysRepository, AssetInventorysRepository>(Lifestyle.Scoped);
            container.Register<IAssetInventoryDetailsRepository, AssetInventoryDetailsRepository>(Lifestyle.Scoped);

            container.Register<IBankAccountChartRepository, BankAccountChartRepository>(Lifestyle.Scoped);

            container.Register<IDonationCasesRepository, DonationCasesRepository>(Lifestyle.Scoped);
            container.Register<IPaymentCaseRepository, PaymentCaseRepository>(Lifestyle.Scoped);

            container.Register<IDocumentRepository, DocumentRepository>(Lifestyle.Scoped);
            container.Register<IAccountChartDocumentRepository, AccountChartDocumentRepository>(Lifestyle.Scoped);

            container.Register<IDiscountPercentagesRepository, DiscountPercentagesRepository>(Lifestyle.Scoped);

            container.Register<ICostCenterTypesRepository, CostCenterTypesRepository>(Lifestyle.Scoped);
            container.Register<IObjectCostCentersRepository, ObjectCostCentersRepository>(Lifestyle.Scoped);

            container.Register<IClosedMonthsRepository, ClosedMonthsRepository>(Lifestyle.Scoped);

            container.Register<IAssetLocationsRepository, AssetLocationsRepository>(Lifestyle.Scoped);
            container.Register<IClosedReceiptRepository, ClosedReceiptRepository>(Lifestyle.Scoped);

            container.Register<IClosedChequeRepository, ClosedChequeRepository>(Lifestyle.Scoped);

            container.Register<IUserBranchsRepository, UserBranchsRepository>(Lifestyle.Scoped);

            container.Register<ISafeAccountChartsRepository, SafeAccountChartsRepository>(Lifestyle.Scoped);

            container.Register<IBankMovementCostCentersRepository, BankMovementCostCentersRepository>(Lifestyle.Scoped);

			container.Register<ITestamentRepository, TestamentRepository>(Lifestyle.Scoped);
            container.Register<IAdvancesTypeRepository, AdvancesTypeRepository>(Lifestyle.Scoped);

            container.Register<ITestamentExtractionRepository, TestamentExtractionRepository>(Lifestyle.Scoped);
			container.Register<IAdvancesRepository, AdvancesRepository>(Lifestyle.Scoped);

            container.Register<ILiquidationRepository, LiquidationRepository>(Lifestyle.Scoped);

            container.Register<ILiquidationDetailRepository, LiquidationDetailRepository>(Lifestyle.Scoped);

            #endregion

            #region Register Service         

            container.Register<IExitPermissionsService, ExitPermissionsService>(Lifestyle.Scoped);

			container.Register<IEntrancePermissionsService, EntrancePermissionsService>(Lifestyle.Scoped);

			container.Register<IPurchaseRebateProductsService, PurchaseRebateProductsService>(Lifestyle.Scoped);

			container.Register<ISalesRebateProductsService, SalesRebateProductsService>(Lifestyle.Scoped);

			container.Register<IAccountChartSettingsService, AccountChartSettingsService>(Lifestyle.Scoped);

			container.Register<IUserGroupsService, UserGroupsService>(Lifestyle.Scoped);

			container.Register<IGroupRolesService, GroupRolesService>(Lifestyle.Scoped);

			container.Register<IGroupsService, GroupsService>(Lifestyle.Scoped);

			container.Register<IGroupPermissionsService, GroupPermissionsService>(Lifestyle.Scoped);

			container.Register<IRolePermissionsService, RolePermissionsService>(Lifestyle.Scoped);

			container.Register<IPermissionsService, PermissionsService>(Lifestyle.Scoped);

			container.Register<IUserRolesService, UserRolesService>(Lifestyle.Scoped);

            container.Register<IUserPermissionsService, UserPermissionsService>(Lifestyle.Scoped);

            container.Register<IRolesService, RolesService>(Lifestyle.Scoped);

			container.Register<ICountryCallingCodesService, CountryCallingCodesService>(Lifestyle.Scoped);

			container.Register<IAddresssService, AddresssService>(Lifestyle.Scoped);

			container.Register<IProductPricesService, ProductPricesService>(Lifestyle.Scoped);

			container.Register<IJournalsService, JournalsService>(Lifestyle.Scoped);

			container.Register<IExchangeBondssService, ExchangeBondssService>(Lifestyle.Scoped);

			container.Register<IReceiptssService, ReceiptssService>(Lifestyle.Scoped);

			container.Register<ISalesRebatesService, SalesRebatesService>(Lifestyle.Scoped);

			container.Register<IPurchaseRebatesService, PurchaseRebatesService>(Lifestyle.Scoped);

			container.Register<IPurchaseInvoicesService, PurchaseInvoicesService>(Lifestyle.Scoped);

			container.Register<ITransactionsService, TransactionsService>(Lifestyle.Scoped);

			container.Register<IPaymentMethodsService, PaymentMethodsService>(Lifestyle.Scoped);

			container.Register<IAssetsService, AssetsService>(Lifestyle.Scoped);

            container.Register<IEffiencyRaiseHistoryService, EffiencyRaiseHistoryService>(Lifestyle.Scoped);


            container.Register<IAssetCategorysService, AssetCategorysService>(Lifestyle.Scoped);

			container.Register<IInventorysService, InventorysService>(Lifestyle.Scoped);

			container.Register<IProductsService, ProductsService>(Lifestyle.Scoped);

			container.Register<IProductTypesService, ProductTypesService>(Lifestyle.Scoped);

			container.Register<IStoreMeasurementUnitsService, StoreMeasurementUnitsService>(Lifestyle.Scoped);

			container.Register<IDelegateMansService, DelegateMansService>(Lifestyle.Scoped);

			container.Register<ICasesService, CasesService>(Lifestyle.Scoped);

			container.Register<ICaseTypesService, CaseTypesService>(Lifestyle.Scoped);

            container.Register<IInventoryMovementTypeService, InventoryMovementTypeService>(Lifestyle.Scoped);

            container.Register<ICostCentersService, CostCentersService>(Lifestyle.Scoped);

			container.Register<IBanksService, BanksService>(Lifestyle.Scoped);

			container.Register<ISafesService, SafesService>(Lifestyle.Scoped);

			container.Register<IAccountChartsService, AccountChartsService>(Lifestyle.Scoped);
			container.Register<IAccountChartCategoriesService, AccountChartCategoriesService>(Lifestyle.Scoped);

			container.Register<IAccountChartGroupsService, AccountChartGroupsService>(Lifestyle.Scoped);


			container.Register<IVendorTypesService, VendorTypesService>(Lifestyle.Scoped);

			container.Register<IVendorsService, VendorsService>(Lifestyle.Scoped);

			container.Register<IAccountTypesService, AccountTypesService>(Lifestyle.Scoped);

			container.Register<IBranchsService, BranchsService>(Lifestyle.Scoped);

			container.Register<IDonationsService, DonationsService>(Lifestyle.Scoped);

			container.Register<ICurrencyRatesService, CurrencyRatesService>(Lifestyle.Scoped);

			container.Register<ICurrencysService, CurrencysService>(Lifestyle.Scoped);

			container.Register<IUsersService, UsersService>(Lifestyle.Scoped);

			container.Register<IAttachmentsService, AttachmentsService>(Lifestyle.Scoped);

			container.Register<ICountrysService, CountrysService>(Lifestyle.Scoped);

			container.Register<ICitysService, CitysService>(Lifestyle.Scoped);

			container.Register<IDistrictsService, DistrictsService>(Lifestyle.Scoped);

			container.Register<IStockAssessmentPolicysService, StockAssessmentPolicysService>(Lifestyle.Scoped);

			container.Register<IMailsService, MailsService>(Lifestyle.Scoped);

			container.Register<IMobilesService, MobilesService>(Lifestyle.Scoped);

			container.Register<IBankMovementsService, BankMovementsService>(Lifestyle.Scoped);

			container.Register<ITransfersService, TransfersService>(Lifestyle.Scoped);

			container.Register<IInventoryTransfersService, InventoryTransfersService>(Lifestyle.Scoped);

            container.Register<IInventoryTransferCostCentersService, InventoryTransferCostCentersService>(Lifestyle.Scoped);

            container.Register<IInventoryMovementsService, InventoryMovementsService>(Lifestyle.Scoped);

            container.Register<IInventoryMovementCostCentersService, InventoryMovementCostCentersService>(Lifestyle.Scoped);

            container.Register<IInventoryInsService, InventoryInsService>(Lifestyle.Scoped);

			container.Register<IInventoryOutsService, InventoryOutsService>(Lifestyle.Scoped);

			container.Register<IInventoryDifferencesService, InventoryDifferencesService>(Lifestyle.Scoped);

            container.Register<IInventoryOpeningBalanceCostCentersService, InventoryOpeningBalanceCostCentersService>(Lifestyle.Scoped);

            container.Register<IInventoryOpeningBalanceService, InventoryOpeningBalanceService>(Lifestyle.Scoped);


            container.Register<IDonatorsService, DonatorsService>(Lifestyle.Scoped);

			container.Register<IMeasurementUnitsService, MeasurementUnitsService>(Lifestyle.Scoped);

			container.Register<ISalesBillTypesService, SalesBillTypesService>(Lifestyle.Scoped);

			container.Register<ISalesBillService, SalesBillService>(Lifestyle.Scoped);
			container.Register<IReceivingMethodsService, ReceivingMethodsService>(Lifestyle.Scoped);
			container.Register<IPaymentMovmentsService, PaymentMovmentsService>(Lifestyle.Scoped);
			//container.Register<ITransactionsDetailsService, TransactionsService>(Lifestyle.Scoped);

			container.Register<IDonationTypesService, DonationTypesService>(Lifestyle.Scoped);

			container.Register<ISettingsService, SettingsService>(Lifestyle.Scoped);

			container.Register<IJournalTypesService, JournalTypesService>(Lifestyle.Scoped);

			container.Register<IPurchaseInvoiceTypesService, PurchaseInvoiceTypesService>(Lifestyle.Scoped);

			container.Register<IPurchaseInvoiceCostCentersService, PurchaseInvoiceCostCentersService>(Lifestyle.Scoped);

			container.Register<IPurchaseRebateCostCentersService, PurchaseRebateCostCentersService>(Lifestyle.Scoped);

			container.Register<IAccountChartLevelSettingsService, AccountChartLevelSettingsService>(Lifestyle.Scoped);

			container.Register<IBrandsService, BrandService>(Lifestyle.Scoped);

			container.Register<IStoreMovementsService, StoreMovementsService>(Lifestyle.Scoped);

			container.Register<IJournalPostingsService, JournalPostingsService>(Lifestyle.Scoped);

			container.Register<IFiscalYearsService, FiscalYearsService>(Lifestyle.Scoped);

            container.Register<IMenuItemsService, MenuItemsService>(Lifestyle.Scoped);

            container.Register<IUserMenuItemsService, UserMenuItemsService>(Lifestyle.Scoped);

            container.Register<ILocationsService, LocationsService>(Lifestyle.Scoped);

            container.Register<IDepreciationRatesService, DepreciationRatesService>(Lifestyle.Scoped);

            container.Register<IDepreciationTypesService, DepreciationTypesService>(Lifestyle.Scoped);

            container.Register<IExpensesService, ExpensesService>(Lifestyle.Scoped);

            container.Register<IExpensesTypesService, ExpensesTypesService>(Lifestyle.Scoped);


			container.Register<IInventoryReportsService, InventoryReportsService>(Lifestyle.Scoped);
			container.Register<IFixedAssetReportsService, FixedAssetReportsService>(Lifestyle.Scoped);
            container.Register<IAccountReportsService, AccountReportsService>(Lifestyle.Scoped);
			container.Register<IVendorReportsService, VendorReportsService>(Lifestyle.Scoped);
			container.Register<IReportsService, ReportsService>(Lifestyle.Scoped);
			container.Register<ISafeReportsService, SafeReportsService>(Lifestyle.Scoped);
			container.Register<IBankReportsService, BankReportsService>(Lifestyle.Scoped);
            container.Register<ICostCenterReportsService, CostCenterReportsService>(Lifestyle.Scoped);
            container.Register<IDonationCaseReportsService, DonationCaseReportsService>(Lifestyle.Scoped);


            container.Register<IDepreciationsService, DepreciationsService>(Lifestyle.Scoped);
            container.Register<IExcludesService, ExcludesService>(Lifestyle.Scoped);
            container.Register<IAssetInventorysService, AssetInventorysService>(Lifestyle.Scoped);
            container.Register<IAssetInventoryDetailsService, AssetInventoryDetailsService>(Lifestyle.Scoped);
            container.Register<IBankAccountChartService, BankAccountChartService>(Lifestyle.Scoped);

            container.Register<IDocumentService, DocumentService>(Lifestyle.Scoped);
            container.Register<IAccountChartDocumentService, AccountChartDocumentService>(Lifestyle.Scoped);

            container.Register<IDiscountPercentagesService, DiscountPercentagesService>(Lifestyle.Scoped);

            container.Register<ICostCenterTypesService, CostCenterTypesService>(Lifestyle.Scoped);

            container.Register<IObjectCostCentersService, ObjectCostCentersService>(Lifestyle.Scoped);

            container.Register<IClosedMonthsService, ClosedMonthsService>(Lifestyle.Scoped);

            container.Register<IAssetLocationsService, AssetLocationsService>(Lifestyle.Scoped);
            container.Register<IClosedReceiptService, ClosedReceiptService>(Lifestyle.Scoped);

            container.Register<IUserBranchsService, UserBranchsService>(Lifestyle.Scoped);
            container.Register<IChartService, ChartService>(Lifestyle.Scoped);


            container.Register<ISafeAccountChartsService, SafeAccountChartsService>(Lifestyle.Scoped);

            container.Register<IBankMovementBankMovementCostCentersService, BankMovementCostCentersService>(Lifestyle.Scoped);


			container.Register<ITestamentService, TestamentService>(Lifestyle.Scoped);
            container.Register<IAdvancesTypeService, AdvancesTypeService>(Lifestyle.Scoped);

            container.Register<ITestamentExtractionService, TestamentExtractionService>(Lifestyle.Scoped);

            container.Register<ILiquidationService, LiquidationService>(Lifestyle.Scoped);

            #endregion


            #region Register Common Service
            container.Register<ILanguageService, LanguageService>(Lifestyle.Scoped);
			container.Register<ILoggerService, LoggerService>(Lifestyle.Singleton);
			container.Register<ICurrentUserService, CurrentUserService>(Lifestyle.Singleton);
			container.Register<IResourcesService, ResourcesService>(Lifestyle.Scoped);
			#endregion
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static T Resolve<T>() where T : class
		{
			return _Container.GetInstance<T>();
		}
		#endregion
	}
}