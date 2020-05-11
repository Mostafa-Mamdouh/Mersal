#region Using ...
using AutoMapper;
using Framework.Common.Enums;
using Framework.Core.Common;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels.AccountChart;
using MersalAccountingService.Core.Models.ViewModels.Donation;
using MersalAccountingService.Core.Models.ViewModels.JournalEntries;
using MersalAccountingService.Core.Models.ViewModels.LightViewModels;
using MersalAccountingService.Core.Models.ViewModels.PaymentMovment;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace MersalAccountingService.Core.AutoMapperConfig
{
	/// <summary>
	/// 
	/// </summary>
	public class Configuration
	{
		private readonly ILanguageService _languageService;
		private static Language currentLanguage;

		public Configuration(
					ILanguageService languageService
				   )
		{
            this._languageService = languageService;
		}

		#region Methods
		/// <summary>
		/// Initializes an auto mapper 
		/// configuration and define 
		/// mapping between entities 
		/// and models.
		/// </summary>
		public static void Initialize()
		{
			AutoMapper.Mapper.Initialize(config =>
			{

				#region ExitPermission, ExitPermissionViewModel
				config.CreateMap<ExitPermission, ExitPermissionViewModel>();
				config.CreateMap<ExitPermissionViewModel, ExitPermission>();
				#endregion

				#region ExitPermission, ExitPermissionLightViewModel
				config.CreateMap<ExitPermission, ExitPermissionLightViewModel>();
				config.CreateMap<ExitPermissionLightViewModel, ExitPermission>();
				#endregion


				#region EntrancePermission, EntrancePermissionViewModel
				config.CreateMap<EntrancePermission, EntrancePermissionViewModel>();
				config.CreateMap<EntrancePermissionViewModel, EntrancePermission>();
				#endregion

				#region EntrancePermission, EntrancePermissionLightViewModel
				config.CreateMap<EntrancePermission, EntrancePermissionLightViewModel>();
				config.CreateMap<EntrancePermissionLightViewModel, EntrancePermission>();
				#endregion


				#region PurchaseRebateProduct, PurchaseRebateProductViewModel
				//config.CreateMap<PurchaseRebateProduct, PurchaseRebateProductViewModel>();
				config.CreateMap<PurchaseRebateProductViewModel, PurchaseRebateProduct>();
				#endregion

				#region PurchaseRebateProduct, PurchaseRebateProductLightViewModel
				config.CreateMap<PurchaseRebateProduct, PurchaseRebateProductLightViewModel>();
				config.CreateMap<PurchaseRebateProductLightViewModel, PurchaseRebateProduct>();
				#endregion


				#region SalesRebateProduct, SalesRebateProductViewModel
				config.CreateMap<SalesRebateProduct, SalesRebateProductViewModel>();
				config.CreateMap<SalesRebateProductViewModel, SalesRebateProduct>();
				#endregion

				#region SalesRebateProduct, SalesRebateProductLightViewModel
				config.CreateMap<SalesRebateProduct, SalesRebateProductLightViewModel>();
				config.CreateMap<SalesRebateProductLightViewModel, SalesRebateProduct>();
				#endregion


				#region SalesRebateProduct, SalesRebateProductViewModel
				config.CreateMap<SalesRebateProduct, SalesRebateProductViewModel>();
				config.CreateMap<SalesRebateProductViewModel, SalesRebateProduct>();
				#endregion


				#region MeasurementUnit, MeasurementUnitViewModel
				config.CreateMap<MeasurementUnit, MeasurementUnitViewModel>()
				.ForMember(x => x.Id, opt => opt.MapFrom(src => (src.ParentKeyMeasurementUnitId.HasValue ? src.ParentKeyMeasurementUnitId : src.Id)))
				.ForMember(x => x.Code, opt => opt.MapFrom(src => src.ParentKeyMeasurementUnitId.HasValue ? src.ParentKeyMeasurementUnit.Code : src.Code))
				.ForMember(x => x.Description, opt => opt.MapFrom(src => src.ParentKeyMeasurementUnitId.HasValue ? src.ParentKeyMeasurementUnit.Description : src.Description))
				.ForMember(x => x.Date, opt => opt.MapFrom(src => src.ParentKeyMeasurementUnitId.HasValue ? src.ParentKeyMeasurementUnit.Date : src.Date))
				.ForMember(x => x.NameAr, z => z.MapFrom(o => o.ParentKeyMeasurementUnit != null ? o.ParentKeyMeasurementUnit.ChildTranslatedMeasurementUnits.FirstOrDefault(item => item.Language == Language.Arabic).Name : o.ChildTranslatedMeasurementUnits.FirstOrDefault(item => item.Language == Language.Arabic).Name))
				.ForMember(x => x.NameEn, z => z.MapFrom(o => o.ParentKeyMeasurementUnit != null ? o.ParentKeyMeasurementUnit.ChildTranslatedMeasurementUnits.FirstOrDefault(item => item.Language == Language.English).Name : o.ChildTranslatedMeasurementUnits.FirstOrDefault(item => item.Language == Language.English).Name))
				.ForMember(x => x.DescriptionAr, z => z.MapFrom(o => o.ParentKeyMeasurementUnit != null ? o.ParentKeyMeasurementUnit.ChildTranslatedMeasurementUnits.FirstOrDefault(item => item.Language == Language.Arabic).Description : o.ChildTranslatedMeasurementUnits.FirstOrDefault(item => item.Language == Language.Arabic).Description))
				.ForMember(x => x.DescriptionEn, z => z.MapFrom(o => o.ParentKeyMeasurementUnit != null ? o.ParentKeyMeasurementUnit.ChildTranslatedMeasurementUnits.FirstOrDefault(item => item.Language == Language.English).Description : o.ChildTranslatedMeasurementUnits.FirstOrDefault(item => item.Language == Language.English).Description))
				;
				config.CreateMap<MeasurementUnitViewModel, MeasurementUnit>();
				#endregion

				#region MeasurementUnit, MeasurementUnitLightViewModel
				config.CreateMap<MeasurementUnit, MeasurementUnitLightViewModel>()
				.ForMember(x => x.Id, opt => opt.MapFrom(src => src.ParentKeyMeasurementUnitId))
				.ForMember(m => m.Code, opt => opt.MapFrom(src => src.ParentKeyMeasurementUnit.Code))
				.ForMember(m => m.DisplyedName, opt => opt.MapFrom(src => $"{src.ParentKeyMeasurementUnit.Code} - {src.Name}"))
				;
				config.CreateMap<MeasurementUnitLightViewModel, MeasurementUnit>();
				#endregion



				#region AccountChartSetting, AccountChartSettingViewModel
				config.CreateMap<AccountChartSetting, AccountChartSettingViewModel>();
				config.CreateMap<AccountChartSettingViewModel, AccountChartSetting>();
				#endregion

				#region AccountChartSetting, AccountChartSettingLightViewModel
				config.CreateMap<AccountChartSetting, AccountChartSettingLightViewModel>();
				config.CreateMap<AccountChartSettingLightViewModel, AccountChartSetting>();
				#endregion

				#region UserGroup, UserGroupViewModel
				config.CreateMap<UserGroup, UserGroupViewModel>();
				config.CreateMap<UserGroupViewModel, UserGroup>();
				#endregion

				#region UserGroup, UserGroupLightViewModel
				config.CreateMap<UserGroup, UserGroupLightViewModel>();
				config.CreateMap<UserGroupLightViewModel, UserGroup>();
				#endregion

				#region GroupRole, GroupRoleViewModel
				config.CreateMap<GroupRole, GroupRoleViewModel>();
				config.CreateMap<GroupRoleViewModel, GroupRole>();
				#endregion

				#region GroupRole, GroupRoleLightViewModel
				config.CreateMap<GroupRole, GroupRoleLightViewModel>();
				config.CreateMap<GroupRoleLightViewModel, GroupRole>();
				#endregion

				#region Group, GroupViewModel
				config.CreateMap<Group, GroupViewModel>()
				.ForMember(x => x.Id, opt => opt.MapFrom(src => (src.ParentKeyGroupId.HasValue ? src.ParentKeyGroupId : src.Id)))
				.ForMember(x => x.Code, opt => opt.MapFrom(src => src.ParentKeyGroupId.HasValue ? src.ParentKeyGroup.Code : src.Code))
				.ForMember(x => x.Description, opt => opt.MapFrom(src => src.ParentKeyGroupId.HasValue ? src.ParentKeyGroup.Description : src.Description))
				.ForMember(x => x.IsActive, opt => opt.MapFrom(src => src.ParentKeyGroupId.HasValue ? src.ParentKeyGroup.IsActive : src.IsActive))
				.ForMember(x => x.Date, opt => opt.MapFrom(src => src.ParentKeyGroupId.HasValue ? src.ParentKeyGroup.Date : src.Date))
				.ForMember(x => x.NameAr, z => z.MapFrom(o => o.ParentKeyGroup != null ? o.ParentKeyGroup.ChildTranslatedGroups.FirstOrDefault(item => item.Language == Language.Arabic).Name : o.ChildTranslatedGroups.FirstOrDefault(item => item.Language == Language.Arabic).Name))
				.ForMember(x => x.NameEn, z => z.MapFrom(o => o.ParentKeyGroup != null ? o.ParentKeyGroup.ChildTranslatedGroups.FirstOrDefault(item => item.Language == Language.English).Name : o.ChildTranslatedGroups.FirstOrDefault(item => item.Language == Language.English).Name))
				.ForMember(x => x.DescriptionAr, z => z.MapFrom(o => o.ParentKeyGroup != null ? o.ParentKeyGroup.ChildTranslatedGroups.FirstOrDefault(item => item.Language == Language.Arabic).Description : o.ChildTranslatedGroups.FirstOrDefault(item => item.Language == Language.Arabic).Description))
				.ForMember(x => x.DescriptionEn, z => z.MapFrom(o => o.ParentKeyGroup != null ? o.ParentKeyGroup.ChildTranslatedGroups.FirstOrDefault(item => item.Language == Language.English).Description : o.ChildTranslatedGroups.FirstOrDefault(item => item.Language == Language.English).Description))
				;
				config.CreateMap<GroupViewModel, Group>();
				#endregion

				#region Group, GroupLightViewModel
				config.CreateMap<Group, GroupLightViewModel>()
				.ForMember(mem => mem.Id, opt => opt.MapFrom(x => x.ParentKeyGroup.Id))
				.ForMember(mem => mem.Value, opt => opt.MapFrom(x => x.ParentKeyGroup.Id))
				.ForMember(mem => mem.Code, opt => opt.MapFrom(x => x.ParentKeyGroup.Code))
				;
				config.CreateMap<GroupLightViewModel, Group>();
				#endregion


				#region RolePermission, RolePermissionViewModel
				config.CreateMap<RolePermission, RolePermissionViewModel>();
				config.CreateMap<RolePermissionViewModel, RolePermission>();
				#endregion

				#region RolePermission, RolePermissionLightViewModel
				config.CreateMap<RolePermission, RolePermissionLightViewModel>();
				config.CreateMap<RolePermissionLightViewModel, RolePermission>();
				#endregion


				#region GroupPermission, GroupPermissionViewModel
				config.CreateMap<GroupPermission, GroupPermissionViewModel>();
				config.CreateMap<GroupPermissionViewModel, GroupPermission>();
				#endregion

				#region GroupPermission, GroupPermissionLightViewModel
				config.CreateMap<GroupPermission, GroupPermissionLightViewModel>();
				config.CreateMap<GroupPermissionLightViewModel, GroupPermission>();
				#endregion


				#region Permission, PermissionViewModel
				config.CreateMap<Permission, PermissionViewModel>()
				.ForMember(x => x.Id, opt => opt.MapFrom(src => (src.ParentKeyPermissionId.HasValue ? src.ParentKeyPermissionId : src.Id)))
				.ForMember(x => x.Code, opt => opt.MapFrom(src => src.ParentKeyPermissionId.HasValue ? src.ParentKeyPermission.Code : src.Code))
				.ForMember(x => x.Description, opt => opt.MapFrom(src => src.ParentKeyPermissionId.HasValue ? src.ParentKeyPermission.Description : src.Description))
				.ForMember(x => x.IsActive, opt => opt.MapFrom(src => src.ParentKeyPermissionId.HasValue ? src.ParentKeyPermission.IsActive : src.IsActive))
				.ForMember(x => x.NameAr, z => z.MapFrom(o => o.ParentKeyPermission != null ? o.ParentKeyPermission.ChildTranslatedPermissions.FirstOrDefault(item => item.Language == Language.Arabic).Name : o.ChildTranslatedPermissions.FirstOrDefault(item => item.Language == Language.Arabic).Name))
				.ForMember(x => x.NameEn, z => z.MapFrom(o => o.ParentKeyPermission != null ? o.ParentKeyPermission.ChildTranslatedPermissions.FirstOrDefault(item => item.Language == Language.English).Name : o.ChildTranslatedPermissions.FirstOrDefault(item => item.Language == Language.English).Name))
				.ForMember(x => x.DescriptionAr, z => z.MapFrom(o => o.ParentKeyPermission != null ? o.ParentKeyPermission.ChildTranslatedPermissions.FirstOrDefault(item => item.Language == Language.Arabic).Description : o.ChildTranslatedPermissions.FirstOrDefault(item => item.Language == Language.Arabic).Description))
				.ForMember(x => x.DescriptionEn, z => z.MapFrom(o => o.ParentKeyPermission != null ? o.ParentKeyPermission.ChildTranslatedPermissions.FirstOrDefault(item => item.Language == Language.English).Description : o.ChildTranslatedPermissions.FirstOrDefault(item => item.Language == Language.English).Description))
				;
				config.CreateMap<PermissionViewModel, Permission>();
				#endregion

				#region Permission, PermissionLightViewModel
				config.CreateMap<Permission, PermissionLightViewModel>()
				.ForMember(mem => mem.Id, opt => opt.MapFrom(x => x.ParentKeyPermission.Id))
				.ForMember(mem => mem.Value, opt => opt.MapFrom(x => x.ParentKeyPermission.Id))
				.ForMember(mem => mem.Code, opt => opt.MapFrom(x => x.ParentKeyPermission.Code))
				;
				config.CreateMap<PermissionLightViewModel, Permission>();
				#endregion


				#region UserRole, UserRoleViewModel
				config.CreateMap<UserRole, UserRoleViewModel>();
				config.CreateMap<UserRoleViewModel, UserRole>();
				#endregion

				#region UserRole, UserRoleLightViewModel
				config.CreateMap<UserRole, UserRoleLightViewModel>();
				config.CreateMap<UserRoleLightViewModel, UserRole>();
				#endregion


				#region UserPermission, UserPermissionViewModel
				config.CreateMap<UserPermission, UserPermissionViewModel>();
				config.CreateMap<UserPermissionViewModel, UserPermission>();
				#endregion

				#region UserPermission, UserPermissionLightViewModel
				config.CreateMap<UserPermission, UserPermissionLightViewModel>();
				config.CreateMap<UserPermissionLightViewModel, UserPermission>();
				#endregion


				#region Role, RoleViewModel
				config.CreateMap<Role, RoleViewModel>()
				.ForMember(x => x.Id, opt => opt.MapFrom(src => (src.ParentKeyRoleId.HasValue ? src.ParentKeyRoleId : src.Id)))
				.ForMember(x => x.Code, opt => opt.MapFrom(src => src.ParentKeyRoleId.HasValue ? src.ParentKeyRole.Code : src.Code))
				.ForMember(x => x.Description, opt => opt.MapFrom(src => src.ParentKeyRoleId.HasValue ? src.ParentKeyRole.Description : src.Description))
				.ForMember(x => x.IsActive, opt => opt.MapFrom(src => src.ParentKeyRoleId.HasValue ? src.ParentKeyRole.IsActive : src.IsActive))
				.ForMember(x => x.Date, opt => opt.MapFrom(src => src.ParentKeyRoleId.HasValue ? src.ParentKeyRole.Date : src.Date))
				.ForMember(x => x.NameAr, z => z.MapFrom(o => o.ParentKeyRole != null ? o.ParentKeyRole.ChildTranslatedRoles.FirstOrDefault(item => item.Language == Language.Arabic).Name : o.ChildTranslatedRoles.FirstOrDefault(item => item.Language == Language.Arabic).Name))
				.ForMember(x => x.NameEn, z => z.MapFrom(o => o.ParentKeyRole != null ? o.ParentKeyRole.ChildTranslatedRoles.FirstOrDefault(item => item.Language == Language.English).Name : o.ChildTranslatedRoles.FirstOrDefault(item => item.Language == Language.English).Name))
				.ForMember(x => x.DescriptionAr, z => z.MapFrom(o => o.ParentKeyRole != null ? o.ParentKeyRole.ChildTranslatedRoles.FirstOrDefault(item => item.Language == Language.Arabic).Description : o.ChildTranslatedRoles.FirstOrDefault(item => item.Language == Language.Arabic).Description))
				.ForMember(x => x.DescriptionEn, z => z.MapFrom(o => o.ParentKeyRole != null ? o.ParentKeyRole.ChildTranslatedRoles.FirstOrDefault(item => item.Language == Language.English).Description : o.ChildTranslatedRoles.FirstOrDefault(item => item.Language == Language.English).Description))
				;
				config.CreateMap<RoleViewModel, Role>();
				#endregion

				#region Role, RoleLightViewModel
				config.CreateMap<Role, RoleLightViewModel>()
				.ForMember(mem => mem.Id, opt => opt.MapFrom(x => x.ParentKeyRole.Id))
				.ForMember(mem => mem.Value, opt => opt.MapFrom(x => x.ParentKeyRole.Id))
				.ForMember(mem => mem.Code, opt => opt.MapFrom(x => x.ParentKeyRole.Code))
				;
				config.CreateMap<RoleLightViewModel, Role>();
				#endregion

				#region CountryCallingCode, CountryCallingCodeViewModel
				config.CreateMap<CountryCallingCode, CountryCallingCodeViewModel>();
				config.CreateMap<CountryCallingCodeViewModel, CountryCallingCode>();
				#endregion

				#region CountryCallingCode, CountryCallingCodeLightViewModel
				config.CreateMap<CountryCallingCode, CountryCallingCodeLightViewModel>();
				config.CreateMap<CountryCallingCodeLightViewModel, CountryCallingCode>();
				#endregion

				#region Address, AddressViewModel
				config.CreateMap<Address, AddressViewModel>();
				config.CreateMap<AddressViewModel, Address>();
				#endregion

				#region Address, AddressLightViewModel
				config.CreateMap<Address, AddressLightViewModel>();
				config.CreateMap<AddressLightViewModel, Address>();
				#endregion

				#region ProductPrice, ProductPriceViewModel
				config.CreateMap<ProductPrice, ProductPriceViewModel>();
				config.CreateMap<ProductPriceViewModel, ProductPrice>();
				#endregion

				#region ProductPrice, ProductPriceLightViewModel
				config.CreateMap<ProductPrice, ProductPriceLightViewModel>();
				config.CreateMap<ProductPriceLightViewModel, ProductPrice>();
				#endregion

				//Journal
				#region Journal, JournalViewModel
				config.CreateMap<Journal, JournalViewModel>()
				.ForMember(m => m.Id, opt => opt.MapFrom(x => (x.ParentKeyJournalId.HasValue ? x.ParentKeyJournalId.Value : x.Id)))
				.ForMember(m => m.Code, opt => opt.MapFrom(x => (x.ParentKeyJournalId.HasValue ? x.ParentKeyJournal.Code : x.Code)))
				.ForMember(m => m.MovementType, opt => opt.MapFrom(x => (x.ParentKeyJournalId.HasValue ? x.ParentKeyJournal.MovementType : x.MovementType)))
				.ForMember(m => m.PostingStatus, opt => opt.MapFrom(x => (x.ParentKeyJournalId.HasValue ? x.ParentKeyJournal.PostingStatus : x.PostingStatus)))
				;
				config.CreateMap<JournalViewModel, Journal>();
				#endregion

				#region Journal, AddJournalEntriesViewModel
				config.CreateMap<Journal, AddJournalEntriesViewModel>()
				.ForMember(x => x.DescriptionAr, z => z.MapFrom(o => o.ChildTranslatedJournals.FirstOrDefault(x => x.Language == Language.Arabic).Description))
				.ForMember(x => x.DescriptionEn, z => z.MapFrom(o => o.ChildTranslatedJournals.FirstOrDefault(x => x.Language == Language.English).Description))
				//.ForMember(x => x.Date, z => z.MapFrom(o => o.Date))
				.ForMember(x => x.DocumentNumber, z => z.MapFrom(o => (string.IsNullOrEmpty(o.Code) ? o.Id.ToString() : o.Code)))
				.ForMember(x => x.journalDetails, z => z.MapFrom(o => o.Transactions))
				.ForMember(x => x.DocId, z => z.MapFrom(o => o.Id))
				;

				config.CreateMap<AddJournalEntriesViewModel, Journal>()

				#region Ignore Translation
				.ForMember(x => x.ChildTranslatedJournals, opt => opt.Ignore())
				.ForMember(x => x.ParentKeyJournal, opt => opt.Ignore())
				.ForMember(x => x.ParentKeyJournalId, opt => opt.Ignore())
				.ForMember(x => x.Language, opt => opt.Ignore())
				#endregion
				#region IgnoreandSet TimeStamp
				  .ForMember(x => x.CreationDate, opt => opt.MapFrom(t => DateTime.Now))
				 .ForMember(x => x.LastModificationDate, opt => opt.Ignore())
				 .ForMember(x => x.FirstModificationDate, opt => opt.Ignore())
				#endregion
				 .ForMember(x => x.Transactions, z => z.MapFrom(o => o.journalDetails))
				;

                #region Transaction, JournalDetailsViewModel
                config.CreateMap<Transaction, JournalDetailsViewModel>()
				.ForMember(x => x.CostCenterId, z => z.MapFrom(o => o.CostCenterId))
				.ForMember(x => x.CostCenter, opt => opt.Ignore())
				.ForMember(x => x.AccountId, z => z.MapFrom(o => o.AccountChartId))
				.ForMember(x => x.AccountFullCode, z => z.MapFrom(o => o.AccountChart.FullCode))
				.ForMember(x => x.Account, z => z.Ignore())
				.ForMember(x => x.IsCreditor, z => z.MapFrom(o => o.IsCreditor))
				.ForMember(x => x.DescriptionAr, z => z.MapFrom(o => o.DescriptionAR))
				.ForMember(x => x.DescriptionEn, z => z.MapFrom(o => o.DescriptionEN))
				.ForMember(x => x.Amount, z => z.MapFrom(o => o.Amount))
				.ForMember(x => x.Id, z => z.MapFrom(o => o.Id))
				 ;

				config.CreateMap<JournalDetailsViewModel, Transaction>()
				#region IgnoreandSet TimeStamp
				 .ForMember(x => x.CreationDate, opt => opt.MapFrom(t => DateTime.Now))
				 .ForMember(x => x.LastModificationDate, opt => opt.Ignore())
				 .ForMember(x => x.FirstModificationDate, opt => opt.Ignore())
				#endregion
				 .ForMember(x => x.CostCenterId, z => z.MapFrom(o => o.CostCenterId))
				.ForMember(x => x.CostCenter, opt => opt.Ignore())
				.ForMember(x => x.AccountChartId, z => z.MapFrom(o => o.AccountId))
				.ForMember(x => x.AccountChart, opt => opt.Ignore())
				.ForMember(x => x.DescriptionAR, z => z.MapFrom(o => o.DescriptionAr))
				.ForMember(x => x.DescriptionEN, z => z.MapFrom(o => o.DescriptionEn))
				.ForMember(x => x.IsCreditor, z => z.MapFrom(o => o.IsCreditor))
				.ForMember(x => x.Amount, z => z.MapFrom(o => o.Amount))
				 ;
				#endregion
				#endregion

				#region Journal, JournalLightViewModel
				config.CreateMap<Journal, JournalLightViewModel>()
				.ForMember(m => m.Id, opt => opt.MapFrom(x => (x.ParentKeyJournalId.HasValue ? x.ParentKeyJournalId.Value : x.Id)))
				.ForMember(m => m.Code, opt => opt.MapFrom(x => (x.ParentKeyJournalId.HasValue ? x.ParentKeyJournal.Code : x.Code)))
				.ForMember(m => m.MovementType, opt => opt.MapFrom(x => (x.ParentKeyJournalId.HasValue ? x.ParentKeyJournal.MovementType : x.MovementType)))
				.ForMember(m => m.PostingStatus, opt => opt.MapFrom(x => (x.ParentKeyJournalId.HasValue ? x.ParentKeyJournal.PostingStatus : x.PostingStatus)))
				;

				config.CreateMap<JournalLightViewModel, Journal>();
				#endregion

				#region ExchangeBonds, ExchangeBondsViewModel
				config.CreateMap<ExchangeBonds, ExchangeBondsViewModel>();
				config.CreateMap<ExchangeBondsViewModel, ExchangeBonds>();
				#endregion

				#region ExchangeBonds, ExchangeBondsLightViewModel
				config.CreateMap<ExchangeBonds, ExchangeBondsLightViewModel>();
				config.CreateMap<ExchangeBondsLightViewModel, ExchangeBonds>();
				#endregion

				#region Receipts, ReceiptsViewModel
				config.CreateMap<Receipts, ReceiptsViewModel>();
				config.CreateMap<ReceiptsViewModel, Receipts>();
				#endregion

				#region Receipts, ReceiptsLightViewModel
				config.CreateMap<Receipts, ReceiptsLightViewModel>();
				config.CreateMap<ReceiptsLightViewModel, Receipts>();
				#endregion

				#region SalesRebate, SalesRebateViewModel
				config.CreateMap<SalesRebate, SalesRebateViewModel>();
				config.CreateMap<SalesRebateViewModel, SalesRebate>();
				#endregion

				#region SalesRebate, SalesRebateLightViewModel
				config.CreateMap<SalesRebate, SalesRebateLightViewModel>();
				config.CreateMap<SalesRebateLightViewModel, SalesRebate>();
				#endregion

				#region PurchaseRebate, PurchaseRebateViewModel
				config.CreateMap<PurchaseRebate, PurchaseRebateViewModel>()
				.ForMember(x => x.Vendor, z => z.Ignore())
				//.ForMember(x => x.Code, z => z.MapFrom(y => y.Code))
				.ForMember(x => x.Inventory, z => z.Ignore())
				.ForMember(x => x.PurchaseInvoiceType, z => z.Ignore())
				.ForMember(x => x.PurchaseRebateCostCenters, z => z.MapFrom(o => o.PurchaseRebateCostCenters))
				.ForMember(x => x.PurchaseRebateProducts, z => z.MapFrom(o => o.PurchaseRebateProducts))
				.ForMember(x => x.Safe, z => z.Ignore())
				;

				config.CreateMap<PurchaseRebateViewModel, PurchaseRebate>();
				#endregion

				#region PurchaseRebateCostCenter, PurchaseRebateCostCenter
				config.CreateMap<PurchaseRebateCostCenter, PurchaseRebateCostCenterViewModel>()
						   .ForMember(x => x.PurchaseRebate, z => z.Ignore())
						   .ForMember(x => x.CostCenter, z => z.Ignore())

				;
				#endregion
				#region PurchaseRebateProduct, PurchaseRebateCostCenter
				config.CreateMap<PurchaseRebateProduct, PurchaseRebateProductViewModel>()
						   .ForMember(x => x.PurchaseRebate, z => z.Ignore())
						   .ForMember(x => x.MeasurementUnit, z => z.Ignore())
						   .ForMember(x => x.SalesBillProducts, z => z.Ignore())
						   .ForMember(x => x.SalesRebateProducts, z => z.Ignore())
						   .ForMember(x => x.PurchaseInvoice, z => z.Ignore())
						   .ForMember(x => x.ProductType, z => z.Ignore())
						   .ForMember(x => x.Product, z => z.Ignore())
						   .ForMember(x => x.InventoryDifferences, z => z.Ignore())

						   .ForMember(x => x.Brand, z => z.Ignore())
						   .ForMember(x => x.AccountChart, z => z.Ignore());
				;
				#endregion


				#region PurchaseRebate, PurchaseRebateLightViewModel
				config.CreateMap<PurchaseRebate, PurchaseRebateLightViewModel>();
				config.CreateMap<PurchaseRebateLightViewModel, PurchaseRebate>();
				#endregion

				#region PurchaseInvoice, PurchaseInvoiceViewModel
				config.CreateMap<PurchaseInvoice, PurchaseInvoiceViewModel>()
				.ForMember(x => x.Vendor, z => z.Ignore())
				.ForMember(x => x.Safe, z => z.Ignore())
				.ForMember(x => x.Inventory, z => z.Ignore())
				//.ForMember(x => x.Products, z => z.Ignore())
				.ForMember(x => x.Products, z => z.MapFrom(o => o.Products))
				.ForMember(x => x.PurchaseInvoiceCostCenters, z => z.MapFrom(o => o.PurchaseInvoiceCostCenters))
				.ForMember(x => x.PurchaseInvoiceType, z => z.Ignore())
				;
				config.CreateMap<PurchaseInvoiceViewModel, PurchaseInvoice>();
				#endregion

				#region PurchaseRebateCostCenter, PurchaseRebateCostCenter
				config.CreateMap<PurchaseInvoiceCostCenter, PurchaseInvoiceCostCenterViewModel>()
						   .ForMember(x => x.PurchaseInvoice, z => z.Ignore())
						   .ForMember(x => x.CostCenter, z => z.Ignore())
				;
				#endregion

				#region PurchaseRebateProduct, PurchaseRebateCostCenter
				config.CreateMap<Product, ProductViewModel>()
						   //.ForMember(x => x.PurchaseRebate, z => z.Ignore())
						   .ForMember(x => x.MeasurementUnit, z => z.Ignore())
						   .ForMember(x => x.SalesBillProducts, z => z.Ignore())
						   .ForMember(x => x.SalesRebateProducts, z => z.Ignore())
						   .ForMember(x => x.PurchaseInvoice, z => z.Ignore())
						   .ForMember(x => x.ProductType, z => z.Ignore())
						   //.ForMember(x => x.Product, z => z.Ignore())
						   .ForMember(x => x.InventoryDifferences, z => z.Ignore())

						   .ForMember(x => x.Brand, z => z.Ignore())
						   .ForMember(x => x.AccountChart, z => z.Ignore());
				;
				#endregion

				#region PurchaseInvoice, PurchaseInvoiceLightViewModel
				config.CreateMap<PurchaseInvoice, PurchaseInvoiceLightViewModel>();
				config.CreateMap<PurchaseInvoiceLightViewModel, PurchaseInvoice>();
				#endregion

				#region PurchaseInvoice, PurchaseInvoiceLookupLightViewModel
				config.CreateMap<PurchaseInvoice, PurchaseInvoiceLookupLightViewModel>()
				.ForMember(x => x.DisplyedName, z => z.MapFrom(c => c.Code))
				;
				config.CreateMap<PurchaseInvoiceLookupLightViewModel, PurchaseInvoice>();
				#endregion


				#region Product, BrandLightViewModel
				config.CreateMap<Product, BrandLightViewModel>()
				.ForMember(x => x.Id, z => z.MapFrom(c => c.BrandId))
				.ForMember(x => x.Code, z => z.MapFrom(c => c.Brand.Code))

				;
				config.CreateMap<PurchaseInvoiceLookupLightViewModel, PurchaseInvoice>();
				#endregion



				#region PurchaseInvoice, PurchaseInvoiceLookupViewModel
				config.CreateMap<PurchaseInvoice, PurchaseInvoiceLookupViewModel>()
				.ForMember(x => x.DisplyedName, z => z.MapFrom(c => c.Code))
				;
				config.CreateMap<PurchaseInvoiceLookupViewModel, PurchaseInvoice>();
				#endregion


				#region Transaction, TransactionViewModel
				config.CreateMap<Transaction, TransactionViewModel>();
				config.CreateMap<TransactionViewModel, Transaction>();
				#endregion

				#region Transaction, TransactionLightViewModel
				config.CreateMap<Transaction, TransactionLightViewModel>();
				config.CreateMap<TransactionLightViewModel, Transaction>();
				#endregion


				#region PaymentMethod, PaymentMethodViewModel
				config.CreateMap<PaymentMethod, PaymentMethodViewModel>();
				config.CreateMap<PaymentMethodViewModel, PaymentMethod>();
				#endregion

				#region PaymentMethod, PaymentMethodLightViewModel
				config.CreateMap<PaymentMethod, PaymentMethodLightViewModel>();
				config.CreateMap<PaymentMethodLightViewModel, PaymentMethod>();
				#endregion


				#region Asset, AssetViewModel
				config.CreateMap<Asset, AssetViewModel>()
				.ForMember(x => x.Id, z => z.MapFrom(o => o.ParentKeyAsset != null ? o.ParentKeyAssetId : o.Id))
				.ForMember(x => x.AccountChartId, z => z.MapFrom(o => o.ParentKeyAsset != null ? o.ParentKeyAsset.AccountChartId : o.AccountChartId))
				.ForMember(x => x.AssetCategoryId, z => z.MapFrom(o => o.ParentKeyAsset != null ? o.ParentKeyAsset.AssetCategoryId : o.AssetCategoryId))
				.ForMember(x => x.BarCode, z => z.MapFrom(o => o.ParentKeyAsset != null ? o.ParentKeyAsset.BarCode : o.BarCode))
				.ForMember(x => x.BrandId, z => z.MapFrom(o => o.ParentKeyAsset != null ? o.ParentKeyAsset.BrandId : o.BrandId))
				.ForMember(x => x.DepreciationRateId, z => z.MapFrom(o => o.ParentKeyAsset != null ? o.ParentKeyAsset.DepreciationRateId : o.DepreciationRateId))
				.ForMember(x => x.DepreciationTypeId, z => z.MapFrom(o => o.ParentKeyAsset != null ? o.ParentKeyAsset.DepreciationTypeId : o.DepreciationTypeId))
				.ForMember(x => x.DepreciationValue, z => z.MapFrom(o => o.ParentKeyAsset != null ? o.ParentKeyAsset.DepreciationValue : o.DepreciationValue))
                .ForMember(x => x.StartDepreciationDate, z => z.MapFrom(o => o.ParentKeyAsset != null ? o.ParentKeyAsset.StartDepreciationDate : o.StartDepreciationDate))
				.ForMember(x => x.LocationId, z => z.MapFrom(o => o.ParentKeyAsset != null ? o.ParentKeyAsset.AssetLocations.OrderByDescending(x => x.Id).FirstOrDefault().LocationId : o.AssetLocations.OrderByDescending(x => x.Id).FirstOrDefault().LocationId))
				.ForMember(x => x.Properties, z => z.MapFrom(o => o.ParentKeyAsset != null ? o.ParentKeyAsset.Properties : o.Properties))
				.ForMember(x => x.PurchaseInvoiceId, z => z.MapFrom(o => o.ParentKeyAsset != null ? o.ParentKeyAsset.PurchaseInvoiceId : o.PurchaseInvoiceId))
				.ForMember(x => x.DescriptionAr, z => z.MapFrom(o => o.ParentKeyAsset != null ? o.ParentKeyAsset.ChildTranslatedAssets.FirstOrDefault(x => x.Language == Language.Arabic).Description : o.ChildTranslatedAssets.FirstOrDefault(x => x.Language == Language.Arabic).Description))
				.ForMember(x => x.DescriptionEn, z => z.MapFrom(o => o.ParentKeyAsset != null ? o.ParentKeyAsset.ChildTranslatedAssets.FirstOrDefault(x => x.Language == Language.English).Description : o.ChildTranslatedAssets.FirstOrDefault(x => x.Language == Language.English).Description))
				;
				config.CreateMap<AssetViewModel, Asset>()
                .ForMember(x => x.ChildTranslatedAssets, z => z.Ignore())
                .ForMember(x => x.AssetLocations, z => z.Ignore())
                ;
				#endregion

				#region Asset, AssetLightViewModel
				config.CreateMap<Asset, AssetLightViewModel>()
				.ForMember(x => x.Id, z => z.MapFrom(o => o.ParentKeyAsset != null ? o.ParentKeyAssetId : o.Id))
				.ForMember(x => x.AccountChartId, z => z.MapFrom(o => o.ParentKeyAsset != null ? o.ParentKeyAsset.AccountChartId : o.AccountChartId))
				.ForMember(x => x.AssetCategoryId, z => z.MapFrom(o => o.ParentKeyAsset != null ? o.ParentKeyAsset.AssetCategoryId : o.AssetCategoryId))
				.ForMember(x => x.BarCode, z => z.MapFrom(o => o.ParentKeyAsset != null ? o.ParentKeyAsset.BarCode : o.BarCode))
				.ForMember(x => x.BrandId, z => z.MapFrom(o => o.ParentKeyAsset != null ? o.ParentKeyAsset.BrandId : o.BrandId))
				.ForMember(x => x.Brand, z => z.MapFrom(o => o.ParentKeyAsset != null ? o.ParentKeyAsset.Brand : o.Brand))
				.ForMember(x => x.DepreciationRateId, z => z.MapFrom(o => o.ParentKeyAsset != null ? o.ParentKeyAsset.DepreciationRateId : o.DepreciationRateId))
				.ForMember(x => x.DepreciationTypeId, z => z.MapFrom(o => o.ParentKeyAsset != null ? o.ParentKeyAsset.DepreciationTypeId : o.DepreciationTypeId))
				.ForMember(x => x.DepreciationValue, z => z.MapFrom(o => o.ParentKeyAsset != null ? o.ParentKeyAsset.DepreciationValue : o.DepreciationValue))
				.ForMember(x => x.LocationId, z => z.MapFrom(o => o.ParentKeyAsset != null ? o.ParentKeyAsset.AssetLocations.OrderByDescending(x => x.Id).FirstOrDefault().LocationId : o.AssetLocations.OrderByDescending(x => x.Id).FirstOrDefault().LocationId))
				.ForMember(x => x.Properties, z => z.MapFrom(o => o.ParentKeyAsset != null ? o.ParentKeyAsset.Properties : o.Properties))
				.ForMember(x => x.PurchaseInvoiceId, z => z.MapFrom(o => o.ParentKeyAsset != null ? o.ParentKeyAsset.PurchaseInvoiceId : o.PurchaseInvoiceId))
				;
				config.CreateMap<AssetLightViewModel, Asset>();
				#endregion

				#region Asset, AssetLookupViewModel
				config.CreateMap<Asset, AssetLookupViewModel>()               
                .ForMember(x => x.AssetId, z => z.MapFrom(o => o.ParentKeyAsset != null ? o.ParentKeyAssetId : o.Id))
				.ForMember(x => x.BrandName, z => z.MapFrom(o => o.ParentKeyAsset != null ? $" {o.ParentKeyAssetId} - {o.ParentKeyAsset.Brand.ChildTranslatedBrands.FirstOrDefault(v => v.Language == o.Language).Name}" : $"{ o.ParentKeyAssetId} - { o.ParentKeyAsset.Brand.ChildTranslatedBrands.FirstOrDefault(v => v.Language == o.Language).Name}"))
;
				config.CreateMap<AssetLookupViewModel, Asset>();
				#endregion


				#region AssetCategory, AssetCategoryViewModel
				config.CreateMap<AssetCategory, AssetCategoryViewModel>();
				config.CreateMap<AssetCategoryViewModel, AssetCategory>();
				#endregion

				#region AssetCategory, AssetCategoryLightViewModel
				config.CreateMap<AssetCategory, AssetCategoryLightViewModel>();
				config.CreateMap<AssetCategoryLightViewModel, AssetCategory>();
				#endregion


				#region Expense, ExpenseViewModel
				config.CreateMap<Expense, ExpenseViewModel>()
				.ForMember(x => x.Id, z => z.MapFrom(o => o.ParentKeyExpense != null ? o.ParentKeyExpenseId : o.Id))
				.ForMember(x => x.AccountChartId, z => z.MapFrom(o => o.ParentKeyExpense != null ? o.ParentKeyExpense.AccountChartId : o.AccountChartId))
				.ForMember(x => x.Code, z => z.MapFrom(o => o.ParentKeyExpense != null ? o.ParentKeyExpense.Code : o.Code))
				.ForMember(x => x.Date, z => z.MapFrom(o => o.ParentKeyExpense != null ? o.ParentKeyExpense.Date : o.Date))
				.ForMember(x => x.Amount, z => z.MapFrom(o => o.ParentKeyExpense != null ? o.ParentKeyExpense.Amount : o.Amount))
				.ForMember(x => x.AssetId, z => z.MapFrom(o => o.ParentKeyExpense != null ? o.ParentKeyExpense.AssetId : o.AssetId))
				.ForMember(x => x.ExpensesTypeId, z => z.MapFrom(o => o.ParentKeyExpense != null ? o.ParentKeyExpense.ExpensesTypeId : o.ExpensesTypeId))
				.ForMember(x => x.DescriptionAr, z => z.MapFrom(o => o.ParentKeyExpense != null ? o.ParentKeyExpense.ChildTranslatedExpenses.FirstOrDefault(x => x.Language == Language.Arabic).Description : o.ChildTranslatedExpenses.FirstOrDefault(x => x.Language == Language.Arabic).Description))
				.ForMember(x => x.DescriptionEn, z => z.MapFrom(o => o.ParentKeyExpense != null ? o.ParentKeyExpense.ChildTranslatedExpenses.FirstOrDefault(x => x.Language == Language.English).Description : o.ChildTranslatedExpenses.FirstOrDefault(x => x.Language == Language.English).Description))
				.ForMember(x => x.ChildTranslatedExpenses, z => z.Ignore())
				;
				config.CreateMap<ExpenseViewModel, Expense>();
				#endregion

				#region Expense, ExpenseLightViewModel
				config.CreateMap<Expense, ExpenseLightViewModel>()
				.ForMember(x => x.Id, z => z.MapFrom(o => o.ParentKeyExpense != null ? o.ParentKeyExpenseId : o.Id))
				.ForMember(x => x.AccountChartId, z => z.MapFrom(o => o.ParentKeyExpense != null ? o.ParentKeyExpense.AccountChartId : o.AccountChartId))
				.ForMember(x => x.Code, z => z.MapFrom(o => o.ParentKeyExpense != null ? o.ParentKeyExpense.Code : o.Code))
				//.ForMember(x => x.Date, z => z.MapFrom(o => o.ParentKeyExpense != null ? o.ParentKeyExpense.Date : o.Date))
				.ForMember(x => x.Amount, z => z.MapFrom(o => o.ParentKeyExpense != null ? o.ParentKeyExpense.Amount : o.Amount))
				.ForMember(x => x.AssetId, z => z.MapFrom(o => o.ParentKeyExpense != null ? o.ParentKeyExpense.AssetId : o.AssetId))
				.ForMember(x => x.ExpensesTypeId, z => z.MapFrom(o => o.ParentKeyExpense != null ? o.ParentKeyExpense.ExpensesTypeId : o.ExpensesTypeId))
				;
				config.CreateMap<ExpenseLightViewModel, Expense>();
				#endregion



				#region Inventory, InventoryViewModel
				config.CreateMap<Inventory, InventoryViewModel>()
				.ForMember(x => x.Id, opt => opt.MapFrom(src => (src.ParentKeyInventoryId.HasValue ? src.ParentKeyInventoryId : src.Id)))
				.ForMember(m => m.Code, opt => opt.MapFrom(src => (src.ParentKeyInventory != null ? src.ParentKeyInventory.Code : src.Code)))
				.ForMember(m => m.Date, opt => opt.MapFrom(src => (src.ParentKeyInventory != null ? src.ParentKeyInventory.Date : src.Date)))
                .ForMember(m => m.LocationId, opt => opt.MapFrom(src => (src.ParentKeyInventory != null ? src.ParentKeyInventory.LocationId : src.LocationId)))
                .ForMember(x => x.NameAr, opt => opt.MapFrom(src => (src.ParentKeyInventoryId.HasValue ? src.ParentKeyInventory.ChildTranslatedInventorys.FirstOrDefault(x => x.Language == Language.Arabic).Name : src.ChildTranslatedInventorys.FirstOrDefault(x => x.Language == Language.Arabic).Name)))
				.ForMember(x => x.NameEn, opt => opt.MapFrom(src => (src.ParentKeyInventoryId.HasValue ? src.ParentKeyInventory.ChildTranslatedInventorys.FirstOrDefault(x => x.Language == Language.English).Name : src.ChildTranslatedInventorys.FirstOrDefault(x => x.Language == Language.English).Name)))
				.ForMember(x => x.DescriptionAr, opt => opt.MapFrom(src => (src.ParentKeyInventoryId.HasValue ? src.ParentKeyInventory.ChildTranslatedInventorys.FirstOrDefault(x => x.Language == Language.Arabic).Description : src.ChildTranslatedInventorys.FirstOrDefault(x => x.Language == Language.Arabic).Description)))
				.ForMember(x => x.DescriptionEn, opt => opt.MapFrom(src => (src.ParentKeyInventoryId.HasValue ? src.ParentKeyInventory.ChildTranslatedInventorys.FirstOrDefault(x => x.Language == Language.English).Description : src.ChildTranslatedInventorys.FirstOrDefault(x => x.Language == Language.English).Description)))

				;
				config.CreateMap<InventoryViewModel, Inventory>();
				#endregion

				#region Inventory, InventoryLightViewModel
				config.CreateMap<Inventory, InventoryLightViewModel>()
				.ForMember(x => x.Id, opt => opt.MapFrom(src => src.ParentKeyInventory.Id))
				.ForMember(m => m.Code, opt => opt.MapFrom(src => src.ParentKeyInventory.Code))
				.ForMember(m => m.DisplyedName, opt => opt.MapFrom(src => $"{src.ParentKeyInventory.Code} - {src.Name}"))
				;
				config.CreateMap<InventoryLightViewModel, Inventory>();
				#endregion


				#region Product, ProductViewModel
				//config.CreateMap<Product, ProductViewModel>();
				config.CreateMap<ProductViewModel, Product>();
				#endregion



				#region Product, ProductLightViewModel

				config.CreateMap<Product, ProductLightViewModel>();
				//  .ForMember(m => m.Price, opt => opt.MapFrom(src => src.ParentKeyProduct.ProductPrices.FirstOrDefault(x => x.IsOriginalPrice == true).Price))
				//.ForMember(m => m.Code, opt => opt.MapFrom(src => src.ParentKeyProduct.Code))
				//.ForMember(m => m.Id, opt => opt.MapFrom(src => src.ParentKeyProductId))
				//.ForMember(m => m.UnitId, opt => opt.MapFrom(src => src.ParentKeyProduct.MeasurementUnitId));
				config.CreateMap<ProductLightViewModel, Product>();
				#endregion

				#region ProductType, ProductTypeViewModel
				config.CreateMap<ProductType, ProductTypeViewModel>();
				config.CreateMap<ProductTypeViewModel, ProductType>();
				#endregion

				#region ProductType, ProductTypeLightViewModel
				config.CreateMap<ProductType, ProductTypeLightViewModel>();
				config.CreateMap<ProductTypeLightViewModel, ProductType>();
				#endregion

				#region StoreMeasurementUnit, StoreMeasurementUnitViewModel
				config.CreateMap<StoreMeasurementUnit, StoreMeasurementUnitViewModel>();
				config.CreateMap<StoreMeasurementUnitViewModel, StoreMeasurementUnit>();
				#endregion

				#region StoreMeasurementUnit, StoreMeasurementUnitLightViewModel
				config.CreateMap<StoreMeasurementUnit, StoreMeasurementUnitLightViewModel>();
				config.CreateMap<StoreMeasurementUnitLightViewModel, StoreMeasurementUnit>();
				#endregion



				#region SalesBillType, SalesBillTypeViewModel
				config.CreateMap<SalesBillType, SalesBillTypeViewModel>();
				config.CreateMap<SalesBillTypeViewModel, SalesBillType>();
				#endregion

				#region SalesBillType, SalesBillTypeLightViewModel
				config.CreateMap<SalesBillType, SalesBillTypeLightViewModel>()
				 .ForMember(m => m.Id, opt => opt.MapFrom(src => src.ParentKeySalesBillTypeId));
				config.CreateMap<SalesBillTypeLightViewModel, SalesBillType>();
				#endregion


				#region SalesBill, SalesBillViewModel
				config.CreateMap<SalesBill, SalesBillViewModel>();
				config.CreateMap<SalesBillViewModel, SalesBill>()
				.ForMember(x => x.CostCenterBills, opt => opt.Ignore())
				.ForMember(x => x.Donator, opt => opt.Ignore())
				.ForMember(x => x.DelegateMan, opt => opt.Ignore())
				.ForMember(x => x.Inventory, opt => opt.Ignore())
				.ForMember(x => x.SalesBillType, opt => opt.Ignore())
				.ForMember(x => x.HasCostCenter, opt => opt.Ignore())
				.ForMember(x => x.Id, opt => opt.Ignore())
				.ForMember(x => x.CreationDate, opt => opt.Ignore())
				.ForMember(x => x.FirstModificationDate, opt => opt.Ignore())
				 .ForMember(x => x.LastModificationDate, opt => opt.Ignore())
;
				#endregion

				//#region SalesBill, SalesBillLightViewModel
				//config.CreateMap<SalesBill, SalesBillLightViewModel>()
				// .ForMember(m => m.Id, opt => opt.MapFrom(src => src.ParentKeySalesBillId));
				//config.CreateMap<SalesBillLightViewModel, SalesBill>();
				//#endregion


				#region Case, CaseViewModel
				config.CreateMap<Case, CaseViewModel>()
				;
				config.CreateMap<CaseViewModel, Case>();
				#endregion

				#region Case, CaseLightViewModel
				config.CreateMap<Case, CaseLightViewModel>();
				config.CreateMap<CaseLightViewModel, Case>();
				#endregion

				#region CaseType, CaseTypeViewModel
				config.CreateMap<CaseType, CaseTypeViewModel>();
				config.CreateMap<CaseTypeViewModel, CaseType>();
				#endregion

				#region CaseType, CaseTypeLightViewModel
				config.CreateMap<CaseType, CaseTypeLightViewModel>();
				config.CreateMap<CaseTypeLightViewModel, CaseType>();
				#endregion

				#region CostCenter, CostCenterViewModel
				config.CreateMap<CostCenter, CostCenterViewModel>()
				.ForMember(x => x.Id, o => o.MapFrom(z => z.Id))
				.ForMember(x => x.Code, o => o.MapFrom(z => z.Code))
                .ForMember(x => x.Date, o => o.MapFrom(z => z.Date))
                .ForMember(x => x.OpeningCredit, o => o.MapFrom(z => z.OpeningCredit))
				.ForMember(x => x.IsDebt, o => o.MapFrom(z => z.IsDebt))
				.ForMember(x => x.NameAr, o => o.MapFrom(z => z.ChildTranslatedCostCenters.FirstOrDefault(w => w.Language == Language.Arabic).Name))
				.ForMember(x => x.NameEn, o => o.MapFrom(z => z.ChildTranslatedCostCenters.FirstOrDefault(w => w.Language == Language.English).Name))
				.ForMember(x => x.DescriptionAr, o => o.MapFrom(z => z.ChildTranslatedCostCenters.FirstOrDefault(w => w.Language == Language.Arabic).Description))
				.ForMember(x => x.DescriptionEn, o => o.MapFrom(z => z.ChildTranslatedCostCenters.FirstOrDefault(w => w.Language == Language.English).Description))
				;
				config.CreateMap<CostCenterViewModel, CostCenter>();

				#endregion



				#region CostCenter, CostCenterLightViewModel
				config.CreateMap<CostCenter, CostCenterLightViewModel>()
				.ForMember(m => m.Id, opt => opt.MapFrom(src => src.ParentKeyCostCenterId))
				.ForMember(m => m.Code, opt => opt.MapFrom(src => src.ParentKeyCostCenter.Code))
				.ForMember(m => m.DisplyedName, opt => opt.MapFrom(src => $"{src.ParentKeyCostCenter.Code} - {src.Name}"))
				;
				config.CreateMap<CostCenterLightViewModel, CostCenter>();
				#endregion



				#region Donator, DonatorViewModel
				config.CreateMap<Donator, DonatorViewModel>();
				config.CreateMap<DonatorViewModel, Donator>();

				#endregion


				#region Donator, DonatorLightViewModel
				config.CreateMap<Donator, DonatorLightViewModel>();
				//.ForMember(m => m.Id, opt => opt.MapFrom(src => src.ParentKeyDonatorId));
				config.CreateMap<DonatorLightViewModel, Donator>();
				#endregion


				//#region CostCenter, CostCenterViewModel
				//config.CreateMap<CostCenter, CostCenterViewModel>();
				//config.CreateMap<CostCenterViewModel, CostCenter>();

				//#endregion


				//#region CostCenter, CostCenterLightViewModel
				//config.CreateMap<CostCenter, CostCenterLightViewModel>()
				//.ForMember(m => m.Code, opt => opt.MapFrom(src => src.ParentKeyCostCenter.Code))
				//   .ForMember(m => m.Id, opt => opt.MapFrom(src => src.ParentKeyCostCenter.Id));

				//config.CreateMap<CostCenterLightViewModel, CostCenter>();
				//#endregion

				#region Bank, BankViewModel
				config.CreateMap<Bank, BankViewModel>()
				.ForMember(x => x.Id, z => z.MapFrom(o => o.ParentKeyBank != null ? o.ParentKeyBankId : o.Id))
				.ForMember(x => x.Code, z => z.MapFrom(o => (o.ParentKeyBankId == null) ? o.Code : o.ParentKeyBank.Code))
				.ForMember(x => x.DisplyedName, z => z.MapFrom(o => $"{o.ParentKeyBank.Code} - {o.Name}"))
				.ForMember(x => x.NameAr, z => z.MapFrom(o => o.ParentKeyBank != null ? o.ParentKeyBank.ChildTranslatedBanks.FirstOrDefault(item => item.Language == Language.Arabic).Name : o.ChildTranslatedBanks.FirstOrDefault(item => item.Language == Language.Arabic).Name))
				.ForMember(x => x.NameEn, z => z.MapFrom(o => o.ParentKeyBank != null ? o.ParentKeyBank.ChildTranslatedBanks.FirstOrDefault(item => item.Language == Language.English).Name : o.ChildTranslatedBanks.FirstOrDefault(item => item.Language == Language.English).Name))
				.ForMember(x => x.DescriptionAr, z => z.MapFrom(o => o.ParentKeyBank != null ? o.ParentKeyBank.ChildTranslatedBanks.FirstOrDefault(item => item.Language == Language.Arabic).Description : o.ChildTranslatedBanks.FirstOrDefault(item => item.Language == Language.Arabic).Description))
				.ForMember(x => x.DescriptionEn, z => z.MapFrom(o => o.ParentKeyBank != null ? o.ParentKeyBank.ChildTranslatedBanks.FirstOrDefault(item => item.Language == Language.English).Description : o.ChildTranslatedBanks.FirstOrDefault(item => item.Language == Language.English).Description))
				;
				config.CreateMap<BankViewModel, Bank>()
				.ForMember(x => x.ChildTranslatedBanks, opt => opt.Ignore())
				//.ForMember(x => x.AccountChart, opt => opt.Ignore())
				.ForMember(x => x.DonationsfromBanks, opt => opt.Ignore())
				.ForMember(x => x.DonationstoBanks, opt => opt.Ignore())
				.ForMember(x => x.PaymentMovments, opt => opt.Ignore())
				.ForMember(x => x.BankMovements, opt => opt.Ignore())
				.ForMember(x => x.ToBankMovement, opt => opt.Ignore())
				.ForMember(x => x.VisaBanks, opt => opt.Ignore())
				;
				#endregion

				#region Bank, BankLightViewModel
				config.CreateMap<Bank, BankLightViewModel>()
				.ForMember(x => x.Id, z => z.MapFrom(s => s.ParentKeyBankId))
				.ForMember(x => x.Code, z => z.MapFrom(s => s.ParentKeyBank.Code))
				.ForMember(x => x.DisplyedName, z => z.MapFrom(o => $"{o.ParentKeyBank.Code} - {o.Name}"))
				;
				config.CreateMap<BankLightViewModel, Bank>();
				#endregion


				#region Safe, SafeViewModel
				config.CreateMap<Safe, SafeViewModel>()
				.ForMember(x => x.Id, z => z.MapFrom(o => o.ParentKeySafe != null ? o.ParentKeySafeId : o.Id))
				.ForMember(x => x.Code, z => z.MapFrom(o => o.ParentKeySafeId != null ? o.ParentKeySafe.Code : o.Code))
				.ForMember(x => x.Date, z => z.MapFrom(o => o.ParentKeySafeId != null ? o.ParentKeySafe.Date : o.Date))
				//.ForMember(x => x.AccountChartId, z => z.MapFrom(o => o.ParentKeySafeId != null ? o.ParentKeySafe.AccountChartId : o.AccountChartId))
				.ForMember(x => x.BranchId, z => z.MapFrom(o => o.ParentKeySafeId != null ? o.ParentKeySafe.BranchId : o.BranchId))
				.ForMember(x => x.DisplyedName, z => z.MapFrom(o => $"{o.ParentKeySafe.Code} - {o.Name}"))
				.ForMember(x => x.NameAr, z => z.MapFrom(o => o.ParentKeySafe != null ? o.ParentKeySafe.ChildTranslatedSafes.FirstOrDefault(item => item.Language == Language.Arabic).Name : o.ChildTranslatedSafes.FirstOrDefault(item => item.Language == Language.Arabic).Name))
				.ForMember(x => x.NameEn, z => z.MapFrom(o => o.ParentKeySafe != null ? o.ParentKeySafe.ChildTranslatedSafes.FirstOrDefault(item => item.Language == Language.English).Name : o.ChildTranslatedSafes.FirstOrDefault(item => item.Language == Language.English).Name))
				.ForMember(x => x.DescriptionAr, z => z.MapFrom(o => o.ParentKeySafe != null ? o.ParentKeySafe.ChildTranslatedSafes.FirstOrDefault(item => item.Language == Language.Arabic).Description : o.ChildTranslatedSafes.FirstOrDefault(item => item.Language == Language.Arabic).Description))
				.ForMember(x => x.DescriptionEn, z => z.MapFrom(o => o.ParentKeySafe != null ? o.ParentKeySafe.ChildTranslatedSafes.FirstOrDefault(item => item.Language == Language.English).Description : o.ChildTranslatedSafes.FirstOrDefault(item => item.Language == Language.English).Description))
				;
				config.CreateMap<SafeViewModel, Safe>();
				#endregion

				#region Safe, SafeLightViewModel
				config.CreateMap<Safe, SafeLightViewModel>()
				.ForMember(x => x.Id, z => z.MapFrom(o => o.ParentKeySafe != null ? o.ParentKeySafeId : o.Id))
				.ForMember(x => x.Code, z => z.MapFrom(o => o.ParentKeySafeId != null ? o.ParentKeySafe.Code : o.Code))
				.ForMember(x => x.Date, z => z.MapFrom(o => o.ParentKeySafeId != null ? o.ParentKeySafe.Date : o.Date))
				//.ForMember(x => x.AccountChartId, z => z.MapFrom(o => o.ParentKeySafeId != null ? o.ParentKeySafe.AccountChartId : o.AccountChartId))
				.ForMember(x => x.DisplyedName, z => z.MapFrom(o => $"{o.ParentKeySafe.Code} - {o.Name}"))
				;
				config.CreateMap<SafeLightViewModel, Safe>();
				#endregion

				#region AccountChart, AccountChartViewModel
				config.CreateMap<AccountChart, AccountChartViewModel>()
				.ForMember(x => x.Id, z => z.MapFrom(o => o.ParentKeyAccountChartId))
				.ForMember(x => x.Code, z => z.MapFrom(o => o.ParentKeyAccountChart.Code))
				//.ForMember(x => x.DisplyedName, z => z.MapFrom(o => o.ParentKeyAccountChart != null ? $"{o.ParentKeyAccountChart.FullCode} - {o.Name}" : $"{o.FullCode} - {o.Name}"))
				.ForMember(x => x.FullCode, z => z.MapFrom(o => o.ParentKeyAccountChart.FullCode))
				.ForMember(x => x.ParentAccountChartId, z => z.MapFrom(o => o.ParentKeyAccountChart.ParentAccountChartId))
				.ForMember(x => x.isFinalNode, z => z.MapFrom(o => o.ParentKeyAccountChart.IsFinalNode))
				.ForMember(x => x.AccountLevel, z => z.MapFrom(o => o.ParentKeyAccountChart.AccountLevel))
				.ForMember(x => x.CurrencyId, z => z.MapFrom(o => o.ParentKeyAccountChart.CurrencyId))
				.ForMember(x => x.CurrentCreditBalance, z => z.MapFrom(o => o.ParentKeyAccountChart.CurrentCreditBalance))
				.ForMember(x => x.CurrentDebitBalance, z => z.MapFrom(o => o.ParentKeyAccountChart.CurrentDebitBalance))
                .ForMember(x => x.IsCreditAccount, z => z.MapFrom(o => o.ParentKeyAccountChart.IsCreditAccount))
                .ForMember(x => x.BranchId, z => z.MapFrom(o => o.ParentKeyAccountChart.BranchId))
                ;

                //.ForMember(x => x.Childs, z => z.MapFrom(o => o.ParentKeyAccountChart.ChildAccountCharts));

                config.CreateMap<AccountChartViewModel, AccountChart>();
				#endregion

				#region AccountChart, AddAccountChartViewModel
				config.CreateMap<AccountChart, AddAccountChartViewModel>()
				.ForMember(x => x.ParentAccountChartId, z => z.MapFrom(o => o.ParentAccountChartId))
				.ForMember(x => x.OpeningCredit, z => z.MapFrom(o => o.OpeningCredit))

				.ForMember(x => x.NameEN, z => z.MapFrom(o => o.ChildTranslatedAccountCharts.FirstOrDefault(l => l.Language == Language.English).Name))
				.ForMember(x => x.NameAR, z => z.MapFrom(o => o.ChildTranslatedAccountCharts.FirstOrDefault(l => l.Language == Language.Arabic).Name))
				.ForMember(x => x.DescriptionEn, z => z.MapFrom(o => o.ChildTranslatedAccountCharts.FirstOrDefault(l => l.Language == Language.English).Description))
				.ForMember(x => x.DescriptionAr, z => z.MapFrom(o => o.ChildTranslatedAccountCharts.FirstOrDefault(l => l.Language == Language.Arabic).Description))

				.ForMember(x => x.IsDebt, z => z.MapFrom(o => o.IsDebt))
				.ForMember(x => x.IsFinalNode, z => z.MapFrom(o => o.IsFinalNode))
				.ForMember(x => x.Id, z => z.MapFrom(o => o.Id))
				.ForMember(x => x.GroupId, z => z.MapFrom(o => o.AccountChartGroupId))
				.ForMember(x => x.Date, z => z.MapFrom(o => o.Date))
				.ForMember(x => x.CategoryId, z => z.MapFrom(o => o.AccountChartCategoryId))
				.ForMember(x => x.AccountTypeId, z => z.MapFrom(o => o.AccountTypeId))
				.ForMember(x => x.Code, z => z.MapFrom(o => o.Code));

				config.CreateMap<AddAccountChartViewModel, AccountChart>()
				.ForMember(x => x.AccountChartCategory, z => z.Ignore())
				.ForMember(x => x.AccountChartCategoryId, z => z.MapFrom(o => o.CategoryId))
				.ForMember(x => x.AccountChartGroup, z => z.Ignore())
				.ForMember(x => x.AccountChartGroupId, z => z.MapFrom(o => o.GroupId))
				.ForMember(x => x.AccountType, z => z.Ignore())
				.ForMember(x => x.ParentAccountChart, z => z.Ignore())
				.ForMember(x => x.ChildAccountCharts, z => z.Ignore())
				.ForMember(x => x.CostCenters, z => z.Ignore())
				.ForMember(x => x.Donators, z => z.Ignore())
				.ForMember(x => x.Inventories, z => z.Ignore())
				.ForMember(x => x.Products, z => z.Ignore())
				.ForMember(x => x.Vendors, z => z.Ignore())
				.ForMember(x => x.PaymentMovments, z => z.Ignore())
				#region IgnoreTranslation
				.ForMember(x => x.ParentKeyAccountChart, z => z.Ignore())
				.ForMember(x => x.ChildTranslatedAccountCharts, z => z.Ignore())
				.ForMember(x => x.Language, opt => opt.Ignore())
				#endregion
				#region  CreationAndUpdate Datetime
				   .ForMember(x => x.CreationDate, z => z.MapFrom(o => DateTime.Now))
				   .ForMember(x => x.LastModificationDate, z => z.Ignore())
				   .ForMember(x => x.FirstModificationDate, z => z.Ignore())
				#endregion
				;
				#endregion

				#region AccountChart, AccountChartLightViewModel
				config.CreateMap<AccountChart, AccountChartLightViewModel>()
				.ForMember(x => x.Name, z => z.MapFrom(o => o.Name))
				.ForMember(x => x.Id, z => z.MapFrom(o => o.ParentKeyAccountChartId != null ? o.ParentKeyAccountChartId : o.Id))
				.ForMember(x => x.Code, z => z.MapFrom(o => o.ParentKeyAccountChart != null ? o.ParentKeyAccountChart.Code : o.Code))
				.ForMember(x => x.FullCode, z => z.MapFrom(o => o.ParentKeyAccountChart != null ? o.ParentKeyAccountChart.FullCode : o.FullCode))
				.ForMember(x => x.AccountLevel, z => z.MapFrom(o => o.ParentKeyAccountChart != null ? o.ParentKeyAccountChart.AccountLevel : o.AccountLevel))
				.ForMember(x => x.DisplyedName, z => z.MapFrom(o => o.ParentKeyAccountChart != null ? $"{o.ParentKeyAccountChart.FullCode} - {o.Name}" : $"{o.FullCode} - {o.Name}"))
				.ForMember(x => x.IsFinalNode, z => z.MapFrom(o => o.ParentKeyAccountChart != null ? o.ParentKeyAccountChart.IsFinalNode : o.IsFinalNode))
				.ForMember(x => x.CurrencyId, z => z.MapFrom(o => o.ParentKeyAccountChart != null ? o.ParentKeyAccountChart.CurrencyId : o.CurrencyId))
                .ForMember(x => x.IsCreditAccount, z => z.MapFrom(o => o.ParentKeyAccountChart != null ? o.ParentKeyAccountChart.IsCreditAccount : o.IsCreditAccount))
                .ForMember(x => x.BranchId, z => z.MapFrom(o => o.ParentKeyAccountChart != null ? o.ParentKeyAccountChart.BranchId : o.BranchId))
                .ForMember(x => x.Value, z => z.MapFrom(o => o.ParentKeyAccountChartId != null ? o.ParentKeyAccountChartId : o.Id))
                ;

                config.CreateMap<AccountChartLightViewModel, AccountChart>();
				#endregion

				#region AccountChartGroup, AccountChartGroupViewModel
				config.CreateMap<AccountChartGroup, AccountChartGroupViewModel>();
				config.CreateMap<AccountChartGroupViewModel, AccountChartGroup>();
				#endregion

				#region AccountChartGroup, AccountChartGroupLightViewModel
				config.CreateMap<AccountChartGroup, AccountChartGroupLightViewModel>()
				.ForMember(x => x.Id, z => z.MapFrom(o => o.ParentKeyAccountChartGroupId))
				;

				config.CreateMap<AccountChartGroupLightViewModel, AccountChartGroup>();
				#endregion

				#region AccountChartCategory, AccountChartCategoryLightViewModel
				config.CreateMap<AccountChartCategory, AccountChartCategoryLightViewModel>()
				.ForMember(x => x.Id, z => z.MapFrom(o => o.ParentKeyAccountChartCategoryId));
				config.CreateMap<AccountChartCategoryLightViewModel, AccountChartCategory>();
				#endregion


				#region ReceivingMethod, ReceivingMethodViewModel
				config.CreateMap<ReceivingMethod, ReceivingMethodViewModel>();
				config.CreateMap<ReceivingMethodViewModel, ReceivingMethod>();
				#endregion

				#region ReceivingMethod, ReceivingMethodLightViewModel
				config.CreateMap<ReceivingMethod, ReceivingMethodLightViewModel>()
				.ForMember(dist => dist.Id, z => z.MapFrom(so => so.ParentKeyReceivingMethod.Id))
				.ForMember(dist => dist.Code, z => z.MapFrom(so => so.ParentKeyReceivingMethod.Code))
				;
				config.CreateMap<ReceivingMethodLightViewModel, ReceivingMethod>();
				#endregion


				#region VendorType, VendorTypeViewModel
				config.CreateMap<VendorType, VendorTypeViewModel>();
				config.CreateMap<VendorTypeViewModel, VendorType>();
				#endregion

				#region VendorType, VendorTypeLightViewModel
				config.CreateMap<VendorType, VendorTypeLightViewModel>();
				config.CreateMap<VendorTypeLightViewModel, VendorType>();
				#endregion


				#region Vendor, VendorViewModel
				config.CreateMap<Vendor, VendorViewModel>()
				.ForMember(x => x.Id, z => z.MapFrom(o => o.ParentKeyVendor != null ? o.ParentKeyVendorId : o.Id))
				.ForMember(x => x.Code, z => z.MapFrom(o => (o.ParentKeyVendorId == null) ? o.Code : o.ParentKeyVendor.Code))
				.ForMember(x => x.DisplyedName, z => z.MapFrom(o => $"{o.ParentKeyVendor.Code} - {o.Name}"))
				.ForMember(x => x.NameAr, z => z.MapFrom(o => o.ParentKeyVendor != null ? o.ParentKeyVendor.ChildTranslatedVendors.FirstOrDefault(item => item.Language == Language.Arabic).Name : o.ChildTranslatedVendors.FirstOrDefault(item => item.Language == Language.Arabic).Name))
				.ForMember(x => x.NameEn, z => z.MapFrom(o => o.ParentKeyVendor != null ? o.ParentKeyVendor.ChildTranslatedVendors.FirstOrDefault(item => item.Language == Language.English).Name : o.ChildTranslatedVendors.FirstOrDefault(item => item.Language == Language.English).Name))
				.ForMember(x => x.DescriptionAr, z => z.MapFrom(o => o.ParentKeyVendor != null ? o.ParentKeyVendor.ChildTranslatedVendors.FirstOrDefault(item => item.Language == Language.Arabic).Description : o.ChildTranslatedVendors.FirstOrDefault(item => item.Language == Language.Arabic).Description))
				.ForMember(x => x.DescriptionEn, z => z.MapFrom(o => o.ParentKeyVendor != null ? o.ParentKeyVendor.ChildTranslatedVendors.FirstOrDefault(item => item.Language == Language.English).Description : o.ChildTranslatedVendors.FirstOrDefault(item => item.Language == Language.English).Description))
                
                .ForMember(x => x.CommercialRegister, z => z.MapFrom(o => o.CommercialRegister))
                .ForMember(x => x.PayeeName, z => z.MapFrom(o => o.PayeeName))
                .ForMember(x => x.TaxCard, z => z.MapFrom(o => o.TaxCard))
                .ForMember(x => x.ExemptFromTax, z => z.MapFrom(o => o.ExemptFromTax))
                .ForMember(x => x.VATRegistrationCertificate, z => z.MapFrom(o => o.VATRegistrationCertificate))
                
                ;

				config.CreateMap<VendorViewModel, Vendor>()
				.ForMember(x => x.PurchaseInvoices, opt => opt.Ignore())
				.ForMember(x => x.AccountChart, opt => opt.Ignore())
				.ForMember(x => x.VendorType, opt => opt.Ignore())
				.ForMember(x => x.PurchaseRebates, opt => opt.Ignore())
				.ForMember(x => x.PaymentMovments, opt => opt.Ignore())
				.ForMember(x => x.ChildTranslatedVendors, opt => opt.Ignore())
				;
				#endregion

				#region Vendor, VendorLightViewModel
				config.CreateMap<Vendor, VendorLightViewModel>()
				//.ForMember(x => x.Id, z => z.MapFrom(o => o.ParentKeyVendorId))
				.ForMember(x => x.Id, opt => opt.MapFrom(src => (src.ParentKeyVendorId.HasValue ? src.ParentKeyVendorId : src.Id)))
				.ForMember(x => x.Code, opt => opt.MapFrom(src => (src.ParentKeyVendor != null ? src.ParentKeyVendor.Code : src.Code)))
				.ForMember(x => x.DisplyedName, opt => opt.MapFrom(src => $"{src.ParentKeyVendor.Code} - {src.Name}"))
				;
				config.CreateMap<VendorLightViewModel, Vendor>();
				#endregion


				#region AccountType, AccountTypeViewModel
				config.CreateMap<AccountType, AccountTypeViewModel>()
				.ForMember(x => x.Code, z => z.MapFrom(o => o.ParentKeyAccountType.Code));

				config.CreateMap<AccountTypeViewModel, AccountType>();
				#endregion

				#region AccountType, AccountTypeLightViewModel
				config.CreateMap<AccountType, AccountTypeLightViewModel>()
				.ForMember(x => x.Id, z => z.MapFrom(o => o.ParentKeyAccountTypeId))
								.ForMember(x => x.Code, z => z.MapFrom(o => o.ParentKeyAccountType.Code))

				;
				config.CreateMap<AccountTypeLightViewModel, AccountType>();
				#endregion


				#region Branch, BranchViewModel
				config.CreateMap<Branch, BranchViewModel>()
				.ForMember(x => x.Id, opt => opt.MapFrom(src => src.ParentKeyBranchId.HasValue ? src.ParentKeyBranchId : src.Id))
				.ForMember(x => x.Code, opt => opt.MapFrom(src => src.ParentKeyBranchId.HasValue ? src.ParentKeyBranch.Code : src.Code))
				.ForMember(x => x.Description, opt => opt.MapFrom(src => src.ParentKeyBranchId.HasValue ? src.ParentKeyBranch.Description : src.Description))
				.ForMember(x => x.Date, opt => opt.MapFrom(src => src.ParentKeyBranchId.HasValue ? src.ParentKeyBranch.Date : src.Date))
				.ForMember(x => x.NameAr, z => z.MapFrom(o => o.ParentKeyBranch != null ? o.ParentKeyBranch.ChildTranslatedBranchs.FirstOrDefault(item => item.Language == Language.Arabic).Name : o.ChildTranslatedBranchs.FirstOrDefault(item => item.Language == Language.Arabic).Name))
				.ForMember(x => x.NameEn, z => z.MapFrom(o => o.ParentKeyBranch != null ? o.ParentKeyBranch.ChildTranslatedBranchs.FirstOrDefault(item => item.Language == Language.English).Name : o.ChildTranslatedBranchs.FirstOrDefault(item => item.Language == Language.English).Name))
				.ForMember(x => x.DescriptionAr, z => z.MapFrom(o => o.ParentKeyBranch != null ? o.ParentKeyBranch.ChildTranslatedBranchs.FirstOrDefault(item => item.Language == Language.Arabic).Description : o.ChildTranslatedBranchs.FirstOrDefault(item => item.Language == Language.Arabic).Description))
				.ForMember(x => x.DescriptionEn, z => z.MapFrom(o => o.ParentKeyBranch != null ? o.ParentKeyBranch.ChildTranslatedBranchs.FirstOrDefault(item => item.Language == Language.English).Description : o.ChildTranslatedBranchs.FirstOrDefault(item => item.Language == Language.English).Description))
				;

				config.CreateMap<BranchViewModel, Branch>();
				#endregion

				#region Branch, BranchLightViewModel
				config.CreateMap<Branch, BranchLightViewModel>()
				.ForMember(x => x.Id, opt => opt.MapFrom(src => src.ParentKeyBranchId.HasValue ? src.ParentKeyBranchId : src.Id))
				.ForMember(x => x.Code, opt => opt.MapFrom(src => src.ParentKeyBranchId.HasValue ? src.ParentKeyBranch.Code : src.Code))
				.ForMember(x => x.DisplyedName, opt => opt.MapFrom(src => $"{src.ParentKeyBranch.Code} - {src.Name}"))
                .ForMember(x => x.Value, opt => opt.MapFrom(src => src.ParentKeyBranchId.HasValue ? src.ParentKeyBranchId : src.Id))
				;
				config.CreateMap<BranchLightViewModel, Branch>();
				#endregion


				#region Donation, DonationViewModel
				config.CreateMap<Donation, DonationViewModel>()
				.ForMember(x => x.DescriptionAR, opt => opt.MapFrom(o => o.ChildTranslatedDonations.FirstOrDefault(x => x.Language == Language.Arabic).Description))
				.ForMember(x => x.DescriptionEN, opt => opt.MapFrom(o => o.ChildTranslatedDonations.FirstOrDefault(x => x.Language == Language.English).Description))
				.ForMember(x => x.CostCenters, opt => opt.MapFrom(o => o.DonationCostCenters))
				.ForMember(x => x.FromBankId, opt => opt.MapFrom(o => o.BankId))
				.ForMember(x => x.ToBankId, opt => opt.MapFrom(o => o.ChequeToBankId))
				.ForMember(x => x.Cases, opt => opt.MapFrom(o => o.DonationCases))
				.ForMember(x => x.Donator, opt => opt.Ignore())

                .ForMember(x => x.ReciptDate, opt => opt.MapFrom(o => o.ReciptDate))
                .ForMember(x => x.AccountChartId, opt => opt.MapFrom(o => o.DonationAccountCharts.Select(s => s.AccountChartId)))
                .ForMember(x => x.VendorId, opt => opt.MapFrom(o => o.DonationVendors.Select(s => s.VendorId)))
                .ForMember(x => x.DonatorId, opt => opt.MapFrom(o => o.DonationDonators.Select(s => s.DonatorId)))
                ;
				config.CreateMap<DonationViewModel, Donation>();
				#endregion

				#region Donation, DonationLightViewModel
				config.CreateMap<Donation, DonationLightViewModel>();
				config.CreateMap<DonationLightViewModel, Donation>();
				#endregion

				//add and list donation View Model Configrations
				#region Donation, AddDonationViewModel

				#region Get DetailsWith Add Model Donation
				config.CreateMap<Donation, AddDonationViewModel>()
			   //payment
			   .ForMember(x => x.ReceivingMethodId, opt => opt.MapFrom(x => x.ReceivingMethodId))
			   .ForMember(x => x.ToBankId, opt => opt.MapFrom(x => x.ChequeToBankId))

			   //collection
			   .ForMember(x => x.Inventorys, opt => opt.MapFrom(o => o.DonationInventorys))
			   .ForMember(x => x.CostCenters, opt => opt.MapFrom(o => o.DonationCostCenters))
			   .ForMember(x => x.Products, opt => opt.MapFrom(o => o.DonationProducts))
			   .ForMember(x => x.Cases, opt => opt.MapFrom(o => o.DonationCases))

               .ForMember(x => x.ReciptDate, opt => opt.MapFrom(o => o.ReciptDate))

			  ;
				#endregion
				#region add Donation
				config.CreateMap<AddDonationViewModel, Donation>()

				#region Ignore Translation
				.ForMember(x => x.ChildTranslatedDonations, opt => opt.Ignore())
				.ForMember(x => x.ParentKeyDonation, opt => opt.Ignore())
				.ForMember(x => x.ParentKeyDonationId, opt => opt.Ignore())
				.ForMember(x => x.Language, opt => opt.Ignore())
				#endregion
				#region IgnoreandSet TimeStamp
				  .ForMember(x => x.CreationDate, opt => opt.MapFrom(t => DateTime.Now))
				 .ForMember(x => x.LastModificationDate, opt => opt.Ignore())
				 .ForMember(x => x.FirstModificationDate, opt => opt.Ignore())
				#endregion
				 .ForMember(x => x.Date, z => z.MapFrom(o => o.Date))
			   //.ForMember(x => x.DonationInventorys, opt => opt.Ignore())
			   .ForMember(x => x.DonationInventorys, opt => opt.MapFrom(o => o.Inventorys))
			  // .ForMember(x => x.DonationCostCenters, opt => opt.Ignore())
			  .ForMember(x => x.DonationCostCenters, opt => opt.MapFrom(o => o.CostCenters))
			   // .ForMember(x => x.DonationProducts, opt => opt.Ignore())
			   .ForMember(x => x.DonationProducts, opt => opt.MapFrom(o => o.Products))
			   //.ForMember(x => x.DonationCases, opt => opt.Ignore())
			   //.ForMember(x => x.DonationCases, opt => opt.MapFrom(o=>o.Cases))
			   .ForMember(x => x.DonationCases, opt => opt.Ignore())

				 //.ForMember(x => x.Vendor, opt => opt.Ignore())
				 //.ForMember(x => x.Donator, opt => opt.Ignore())
				 .ForMember(x => x.Branch, opt => opt.Ignore())
				 .ForMember(x => x.BranchId, z => z.MapFrom(o => o.BranchId))
				 .ForMember(x => x.GeneralAccount, opt => opt.Ignore())
				 //.ForMember(x => x.AccountChart, opt => opt.Ignore())
				 .ForMember(x => x.Currency, opt => opt.Ignore())
				 .ForMember(x => x.ReceivingMethodId, opt => opt.MapFrom(x => x.ReceivingMethodId))

				 .ForMember(x => x.ReceivingMethod, opt => opt.Ignore())
				 .ForMember(x => x.Bank, opt => opt.Ignore())
				 .ForMember(x => x.ChequeToBank, opt => opt.Ignore())
				 .ForMember(x => x.Safe, opt => opt.Ignore())
				 .ForMember(x => x.DelegateMan, opt => opt.Ignore())

                 .ForMember(x => x.ReciptDate, opt => opt.MapFrom(o => o.ReciptDate))
				;
				#endregion
				#endregion

				//Donation Details


				#region Donation, ListDonationLightViewModel
				config.CreateMap<Donation, ListDonationLightViewModel>()
				.ForMember(x => x.Id, z => z.MapFrom(src => src.ParentKeyDonationId))
				.ForMember(x => x.Date, z => z.MapFrom(src => src.ParentKeyDonation.Date))
				.ForMember(x => x.Amount, z => z.MapFrom(src => src.ParentKeyDonation.Amount))
				.ForMember(x => x.code, z => z.MapFrom(src => src.ParentKeyDonation.Code))
				.ForMember(x => x.DelegateManReciptNumber, z => z.MapFrom(src => src.ParentKeyDonation.DelegateManReciptNumber))
				.ForMember(x => x.Branch, z => z.MapFrom(src => src.ParentKeyDonation.Branch.ChildTranslatedBranchs.FirstOrDefault(dest => dest.Language == src.Language).Name))
				;

				#endregion

				#region DonationCase, AddDonationCaseViewModel
				config.CreateMap<DonationCase, AddDonationCaseViewModel>()
				.ForMember(x => x.CaseId, z => z.MapFrom(o => o.Case.ExternalId))
				.ForMember(x => x.Amount, z => z.MapFrom(o => o.Amount))
				.ForMember(x => x.Name, z => z.MapFrom(o => o.Case.Name))
				;
				config.CreateMap<AddDonationCaseViewModel, DonationCase>()
				#region IgnoreandSet TimeStamp
				  .ForMember(x => x.CreationDate, opt => opt.MapFrom(t => DateTime.Now))
				 .ForMember(x => x.LastModificationDate, opt => opt.Ignore())
				 .ForMember(x => x.FirstModificationDate, opt => opt.Ignore())
				#endregion
				.ForMember(x => x.Case, opt => opt.Ignore())
				.ForMember(x => x.Case, opt => opt.Ignore())
				.ForMember(x => x.DonationId, opt => opt.Ignore())
				 .ForMember(x => x.Donation, opt => opt.Ignore())
				 .ForMember(x => x.Id, opt => opt.Ignore())
				;
				#endregion

				#region DonationProduct, AddDonationProducts
				config.CreateMap<DonationProduct, AddDonationProducts>()
				.ForMember(x => x.ProductId, z => z.MapFrom(o => o.ProductId))
				.ForMember(x => x.Amount, z => z.MapFrom(o => o.Amount))
				.ForMember(x => x.Quantity, z => z.MapFrom(o => o.Quantity))
				;
				config.CreateMap<AddDonationProducts, DonationProduct>()
				#region IgnoreandSet TimeStamp
				  .ForMember(x => x.CreationDate, opt => opt.MapFrom(t => DateTime.Now))
				 .ForMember(x => x.LastModificationDate, opt => opt.Ignore())
				 .ForMember(x => x.FirstModificationDate, opt => opt.Ignore())
				#endregion
				 .ForMember(x => x.Product, opt => opt.Ignore())
				 .ForMember(x => x.DonationId, opt => opt.Ignore())
				 .ForMember(x => x.Donation, opt => opt.Ignore())
				 .ForMember(x => x.Id, opt => opt.Ignore())
				;
				#endregion

				#region DonationCostCenter, AddDonationCostCenter
				config.CreateMap<DonationCostCenter, AddDonationCostCenter>()
				.ForMember(x => x.CostCenterId, z => z.MapFrom(o => o.CostCenterId))
				.ForMember(x => x.Amount, z => z.MapFrom(o => o.Amount))
				;
				config.CreateMap<AddDonationCostCenter, DonationCostCenter>()
				#region IgnoreandSet TimeStamp
				  .ForMember(x => x.CreationDate, opt => opt.MapFrom(t => DateTime.Now))
				 .ForMember(x => x.LastModificationDate, opt => opt.Ignore())
				 .ForMember(x => x.FirstModificationDate, opt => opt.Ignore())
				#endregion
				 .ForMember(x => x.CostCenter, opt => opt.Ignore())
				 .ForMember(x => x.DonationId, opt => opt.Ignore())
				 .ForMember(x => x.Donation, opt => opt.Ignore())
				 .ForMember(x => x.Id, opt => opt.Ignore())
				;
				#endregion


				#region DonationInventory, AddDonationInventoryViewModel
				config.CreateMap<DonationInventory, AddDonationInventoryViewModel>()
				.ForMember(x => x.Amount, z => z.MapFrom(o => o.Amount))
				.ForMember(x => x.InventoryId, z => z.MapFrom(o => o.InventoryId))

				;
				config.CreateMap<AddDonationInventoryViewModel, DonationInventory>()
				#region IgnoreandSet TimeStamp
				  .ForMember(x => x.CreationDate, opt => opt.MapFrom(t => DateTime.Now))
				 .ForMember(x => x.LastModificationDate, opt => opt.Ignore())
				 .ForMember(x => x.FirstModificationDate, opt => opt.Ignore())
				#endregion
				 .ForMember(x => x.Inventory, opt => opt.Ignore())
				 .ForMember(x => x.DonationId, opt => opt.Ignore())
				 .ForMember(x => x.Donation, opt => opt.Ignore())
				 .ForMember(x => x.Id, opt => opt.Ignore())
				;
				#endregion


				#region Donation, DetailsDonationViewModel
				config.CreateMap<Donation, DetailsDonationViewModel>()
			  .ForMember(x => x.Branch, z => z.MapFrom(o => o.Branch.Name))
					.ForMember(x => x.GeneralAccountAmount, z => z.MapFrom(o => o.GeneralAccount.Amount))
					.ForMember(x => x.TotalAmount, z => z.MapFrom(o => o.Amount))
			 //.ForMember(x => x.DonatorName, z => z.MapFrom(o => o.Donator.Name))
			 //.ForMember(x => x.DonatorAccountNumber, z => z.MapFrom(o => o.Donator.AccountChart.Code))

			 //.ForMember(x => x.AccountNumber, z => z.MapFrom(o => o.AccountChart.Code))
			 .ForMember(x => x.Cases, z => z.MapFrom(o => o.DonationCases))

				//payment
				.ForMember(x => x.ReceivingMethodId, z => z.MapFrom(o => o.ReceivingMethod.Code))
			  .ForMember(x => x.SafeName, z => z.MapFrom(o => o.Safe.Name))
			  .ForMember(x => x.SafeCode, z => z.MapFrom(o => o.Safe.Code))

			   .ForMember(x => x.ChequeDuedate, z => z.MapFrom(o => o.Duedate))
			   .ForMember(x => x.VisaNumber, z => z.MapFrom(o => o.VisaNumber))
			   .ForMember(x => x.Products, z => z.Ignore())
				.ForMember(x => x.CostCenters, z => z.Ignore())
				.ForMember(x => x.Inventorys, z => z.Ignore())

				;

				#endregion

				#region DonationCase, DetailsDonationCaseViewModel
				config.CreateMap<DonationCase, DetailsDonationCaseViewModel>()
				.ForMember(x => x.Name, z => z.MapFrom(o => o.Case.Name))
				;
				#endregion


				//end

				//add and list PaymentMovemnt View Model Configrations
				#region PaymentMovment, AddPaymentMovmentViewModel
				config.CreateMap<PaymentMovment, AddPaymentMovmentViewModel>()
			   .ForMember(x => x.DescriptionAR, z => z.MapFrom(o => o.ChildTranslatedPaymentMovments.FirstOrDefault(x => x.Language == Framework.Common.Enums.Language.Arabic).Description))
			   .ForMember(x => x.DescriptionEN, z => z.MapFrom(o => o.ChildTranslatedPaymentMovments.FirstOrDefault(x => x.Language == Framework.Common.Enums.Language.English).Description))
			   .ForMember(x => x.Inventorys, z => z.MapFrom(o => o.PaymentMovmentInventorys))
			   .ForMember(x => x.CostCenters, z => z.MapFrom(o => o.PaymentMovmentCostCenters))
			   .ForMember(x => x.ToBankId, z => z.MapFrom(o => o.ChequeToBankId))
			   .ForMember(x => x.VisaBankId, z => z.MapFrom(o => o.BankId))
			   .ForMember(x => x.FromBankId, z => z.MapFrom(o => o.BankId))
               .ForMember(x => x.ExpensesTypeId, z => z.MapFrom(o => o.ExpensesTypeId))
               //.ForMember(x => x.Duedate, z => z.MapFrom(o => o.Duedate))
               .ForMember(x => x.PaymentDueDate, z => z.MapFrom(o => o.PaymentDueDate))
               .ForMember(x => x.Cases, z => z.MapFrom(o => o.PaymentCases))
               .ForMember(x => x.Donator, z => z.Ignore())
                .ForMember(x => x.AccountChartId, opt => opt.MapFrom(o => o.PaymentMovmentAccountCharts.Select(s => s.AccountChartId)))
                .ForMember(x => x.VendorId, opt => opt.MapFrom(o => o.PaymentMovmentVendors.Select(s => s.VendorId)))
                .ForMember(x => x.DonatorId, opt => opt.MapFrom(o => o.PaymentMovementDonators.Select(s => s.DonatorId)))
                .ForMember(x => x.NotificationsDiscount, opt => opt.MapFrom(o => o.PaymentMovmentNotificationDiscounts))

                ;

                config.CreateMap<AddPaymentMovmentViewModel, PaymentMovment>()


                #region Ignore Translation
                .ForMember(x => x.ChildTranslatedPaymentMovments, opt => opt.Ignore())
                .ForMember(x => x.ParentKeyPaymentMovment, opt => opt.Ignore())
                .ForMember(x => x.ParentKeyPaymentMovmentId, opt => opt.Ignore())
                .ForMember(x => x.Language, opt => opt.Ignore())
                #endregion
                #region IgnoreandSet TimeStamp
                  .ForMember(x => x.CreationDate, opt => opt.MapFrom(t => DateTime.Now))
                 .ForMember(x => x.LastModificationDate, opt => opt.Ignore())
                 .ForMember(x => x.FirstModificationDate, opt => opt.Ignore())
                #endregion
                 .ForMember(x => x.Date, z => z.MapFrom(o => o.Date))
               //.ForMember(x => x.DonationInventorys, opt => opt.Ignore())
               .ForMember(x => x.PaymentMovmentInventorys, opt => opt.MapFrom(o => o.Inventorys))
              // .ForMember(x => x.DonationCostCenters, opt => opt.Ignore())
              .ForMember(x => x.PaymentMovmentCostCenters, opt => opt.MapFrom(o => o.CostCenters))



                 .ForMember(x => x.Branch, opt => opt.Ignore())
                 .ForMember(x => x.BranchId, z => z.MapFrom(o => o.BranchId))
                // .ForMember(x => x.AccountChart, opt => opt.Ignore())
                 .ForMember(x => x.ReceivingMethodId, opt => opt.MapFrom(x => x.ReceivingMethodId))
                 .ForMember(x => x.ReceivingMethod, opt => opt.Ignore())

                 .ForMember(x => x.Bank, opt => opt.Ignore())
                 .ForMember(x => x.Safe, opt => opt.Ignore())
                 .ForMember(x => x.DelegateMan, opt => opt.Ignore())

                 .ForMember(x => x.PaymentDueDate, opt => opt.MapFrom(o => o.PaymentDueDate))
                // .ForMember(x => x.Donator, opt => opt.Ignore())
                 
				;
                #endregion

                #region PaymentCase, PaymentCaseViewModel
                config.CreateMap<PaymentCase, PaymentCaseViewModel>()
                .ForMember(x => x.CaseId, z => z.MapFrom(o => o.Case.ExternalId))
                .ForMember(x => x.Amount, z => z.MapFrom(o => o.Amount))
                ;
                config.CreateMap<PaymentCaseViewModel, PaymentCase>()
                #region IgnoreandSet TimeStamp
                  .ForMember(x => x.CreationDate, opt => opt.MapFrom(t => DateTime.Now))
                 .ForMember(x => x.LastModificationDate, opt => opt.Ignore())
                 .ForMember(x => x.FirstModificationDate, opt => opt.Ignore())
                #endregion
                .ForMember(x => x.Case, opt => opt.Ignore())
                .ForMember(x => x.Case, opt => opt.Ignore())
                .ForMember(x => x.PaymentId, opt => opt.Ignore())
                 .ForMember(x => x.Payment, opt => opt.Ignore())
                 .ForMember(x => x.Id, opt => opt.Ignore())
                ;
                #endregion

                #region PaymentMovmentCostCenter, AddPaymentMovmentCostCenterViewModel
                config.CreateMap<PaymentMovmentCostCenter, AddPaymentMovmentCostCenterViewModel>()
				.ForMember(x => x.Amount, z => z.MapFrom(o => o.Amount))
				.ForMember(x => x.CostCenterId, z => z.MapFrom(o => o.CostCenterId));

				config.CreateMap<AddPaymentMovmentCostCenterViewModel, PaymentMovmentCostCenter>()
				#region IgnoreandSet TimeStamp
				  .ForMember(x => x.CreationDate, opt => opt.MapFrom(t => DateTime.Now))
				 .ForMember(x => x.LastModificationDate, opt => opt.Ignore())
				 .ForMember(x => x.FirstModificationDate, opt => opt.Ignore())
				#endregion
				 .ForMember(x => x.CostCenter, opt => opt.Ignore())
				 .ForMember(x => x.PaymentMovmentId, opt => opt.Ignore())
				 .ForMember(x => x.PaymentMovment, opt => opt.Ignore())
				 .ForMember(x => x.Id, opt => opt.Ignore());
				#endregion

				#region PaymentMovmentInventory, AddPaymentMovmentInventoryViewModel
				config.CreateMap<PaymentMovmentInventory, AddPaymentMovmentInventoryViewModel>()
				 .ForMember(x => x.Amount, o => o.MapFrom(z => z.Amount))
				 .ForMember(x => x.InventoryId, o => o.MapFrom(z => z.InventoryId))
				;
				config.CreateMap<AddPaymentMovmentInventoryViewModel, PaymentMovmentInventory>()
				#region IgnoreandSet TimeStamp
				  .ForMember(x => x.CreationDate, opt => opt.MapFrom(t => DateTime.Now))
				 .ForMember(x => x.LastModificationDate, opt => opt.Ignore())
				 .ForMember(x => x.FirstModificationDate, opt => opt.Ignore())
				#endregion
				 .ForMember(x => x.Inventory, opt => opt.Ignore())
				 .ForMember(x => x.PaymentMovmentId, opt => opt.Ignore())
				 .ForMember(x => x.PaymentMovment, opt => opt.Ignore())
				 .ForMember(x => x.Id, opt => opt.Ignore())
				;
				#endregion
				#region PaymentMovment, ListPaymentMovmentLightViewModel

				config.CreateMap<PaymentMovment, ListPaymentMovmentLightViewModel>()
			  .ForMember(x => x.Branch, z => z.MapFrom(o => o.Branch.Name))
							.ForMember(x => x.Amount, z => z.Ignore())

				;

				#endregion

				//PaymentMovment Details
				#region PaymentMovment, DetailsPaymentMovmentViewModel
				config.CreateMap<PaymentMovment, DetailsPaymentMovmentViewModel>()
			  .ForMember(x => x.Branch, z => z.MapFrom(o => o.Branch.Name))
					.ForMember(x => x.TotalAmount, z => z.MapFrom(o => o.Amount))
					.ForMember(x => x.DelegateManReceiptNumber, z => z.MapFrom(o => o.DelegateManReciptNumber))
			 //.ForMember(x => x.AccountNumber, z => z.MapFrom(o => o.AccountChart.Code))
			  //payment
			  .ForMember(x => x.SafeName, z => z.MapFrom(o => o.Safe.Name))
			  .ForMember(x => x.SafeCode, z => z.MapFrom(o => o.Safe.Code))

			   .ForMember(x => x.ChequeDuedate, z => z.MapFrom(o => o.Duedate))
			   .ForMember(x => x.VisaNumber, z => z.MapFrom(o => o.VisaNumber))
				.ForMember(x => x.CostCenters, z => z.Ignore())
				.ForMember(x => x.Inventorys, z => z.Ignore())

				;

				#endregion

				//end

				#region CurrencyRate, CurrencyRateViewModel
				config.CreateMap<CurrencyRate, CurrencyRateViewModel>()

				;
				config.CreateMap<CurrencyRateViewModel, CurrencyRate>();
				#endregion

				#region CurrencyRate, CurrencyRateLightViewModel
				config.CreateMap<CurrencyRate, CurrencyRateLightViewModel>()
				.ForMember(x => x.Id, z => z.MapFrom(o => o.Id))
				;
				config.CreateMap<CurrencyRateLightViewModel, CurrencyRate>();
				#endregion

				#region Currency, CurrencyViewModel
				config.CreateMap<Currency, CurrencyViewModel>()
				.ForMember(x => x.Id, z => z.MapFrom(o => o.Id))
				.ForMember(x => x.Code, z => z.MapFrom(o => o.Code))
				.ForMember(x => x.Symbol, z => z.MapFrom(o => o.Symbol))
				.ForMember(x => x.Date, z => z.MapFrom(o => o.Date))
				.ForMember(x => x.NameAr, z => z.MapFrom(o => o.ChildTranslatedCurrencys.FirstOrDefault(x => x.Language == Language.Arabic).Name))
				.ForMember(x => x.NameEn, z => z.MapFrom(o => o.ChildTranslatedCurrencys.FirstOrDefault(x => x.Language == Language.English).Name))
				.ForMember(x => x.DescriptionAr, z => z.MapFrom(o => o.ChildTranslatedCurrencys.FirstOrDefault(x => x.Language == Language.Arabic).Description))
				.ForMember(x => x.DescriptionEn, z => z.MapFrom(o => o.ChildTranslatedCurrencys.FirstOrDefault(x => x.Language == Language.English).Description))
                .ForMember(x => x.Price, z => z.MapFrom(o => o.CurrencyRates.OrderByDescending(x => x.Id).FirstOrDefault().Price))
                .ForMember(x => x.ExchangeCurrencyId, z => z.MapFrom(o => o.CurrencyRates.OrderByDescending(x => x.Id).FirstOrDefault().ExchangeCurrencyId))
				;
				config.CreateMap<CurrencyViewModel, Currency>();
				#endregion

				#region Currency, CurrencyLightViewModel
				config.CreateMap<Currency, CurrencyLightViewModel>()
				.ForMember(x => x.Id, z => z.MapFrom(o => o.ParentKeyCurrencyId))
				.ForMember(x => x.Code, z => z.MapFrom(o => o.ParentKeyCurrency.Code))
				.ForMember(x => x.DisplyedName, opt => opt.MapFrom(src => $"{src.ParentKeyCurrency.Code} - {src.Name}"))

				;

				config.CreateMap<CurrencyLightViewModel, Currency>();
				#endregion

				#region User, UserViewModel
				config.CreateMap<User, UserViewModel>()
				.ForMember(x => x.Id, opt => opt.MapFrom(src => (src.ParentKeyUserId.HasValue ? src.ParentKeyUserId : src.Id)))
				.ForMember(x => x.UserName, opt => opt.MapFrom(src => src.ParentKeyUserId.HasValue ? src.ParentKeyUser.UserName : src.UserName))
				.ForMember(x => x.IsActive, opt => opt.MapFrom(src => src.ParentKeyUserId.HasValue ? src.ParentKeyUser.IsActive : src.IsActive))
				.ForMember(x => x.BirthDate, opt => opt.MapFrom(src => src.ParentKeyUserId.HasValue ? src.ParentKeyUser.BirthDate : src.BirthDate))
				.ForMember(x => x.NameAr, z => z.MapFrom(o => o.ParentKeyUser != null ? o.ParentKeyUser.ChildTranslatedUsers.FirstOrDefault(item => item.Language == Language.Arabic).Name : o.ChildTranslatedUsers.FirstOrDefault(item => item.Language == Language.Arabic).Name))
				.ForMember(x => x.NameEn, z => z.MapFrom(o => o.ParentKeyUser != null ? o.ParentKeyUser.ChildTranslatedUsers.FirstOrDefault(item => item.Language == Language.English).Name : o.ChildTranslatedUsers.FirstOrDefault(item => item.Language == Language.English).Name))
				.ForMember(x => x.CreationDate, opt => opt.MapFrom(src => src.ParentKeyUserId.HasValue ? src.ParentKeyUser.CreationDate : src.CreationDate))
				.ForMember(x => x.DefaultPageUrl, opt => opt.MapFrom(src => src.ParentKeyUserId.HasValue ? src.ParentKeyUser.DefaultPageUrl : src.DefaultPageUrl))
				.ForMember(x => x.Gender, opt => opt.MapFrom(src => src.ParentKeyUserId.HasValue ? src.ParentKeyUser.Gender : src.Gender))
				.ForMember(x => x.IsTopAdmin, opt => opt.MapFrom(src => src.ParentKeyUserId.HasValue ? src.ParentKeyUser.IsTopAdmin : src.IsTopAdmin))
				.ForMember(x => x.MaxPaymentLimit, opt => opt.MapFrom(src => src.ParentKeyUserId.HasValue ? src.ParentKeyUser.MaxPaymentLimit : src.MaxPaymentLimit))
				//.ForMember(x => x.BranchId, opt => opt.MapFrom(src => src.ParentKeyUserId.HasValue ? src.ParentKeyUser.BranchId : src.BranchId))
				;
				config.CreateMap<UserViewModel, User>();
				#endregion

				#region User, UserLightViewModel
				config.CreateMap<User, UserLightViewModel>()
				.ForMember(mem => mem.Id, opt => opt.MapFrom(x => x.ParentKeyUser.Id))
				.ForMember(mem => mem.Value, opt => opt.MapFrom(x => x.ParentKeyUser.Id))
				//.ForMember(mem => mem.Code, opt => opt.MapFrom(x => x.ParentKeyUser.Code))
				;
				config.CreateMap<UserLightViewModel, User>();
				#endregion


				#region Attachment, AttachmentViewModel
				config.CreateMap<Attachment, AttachmentViewModel>();
				config.CreateMap<AttachmentViewModel, Attachment>();
				#endregion

				#region Attachment, AttachmentLightViewModel
				config.CreateMap<Attachment, AttachmentLightViewModel>();
				config.CreateMap<AttachmentLightViewModel, Attachment>();
				#endregion


				#region Country, CountryViewModel
				config.CreateMap<Country, CountryViewModel>();
				config.CreateMap<CountryViewModel, Country>();
				#endregion

				#region Country, CountryLightViewModel
				config.CreateMap<Country, CountryLightViewModel>();
				config.CreateMap<CountryLightViewModel, Country>();
				#endregion


				#region City, CityViewModel
				config.CreateMap<City, CityViewModel>();
				config.CreateMap<CityViewModel, City>();
				#endregion

				#region City, CityLightViewModel
				config.CreateMap<City, CityLightViewModel>();
				config.CreateMap<CityLightViewModel, City>();
				#endregion


				#region District, DistrictViewModel
				config.CreateMap<District, DistrictViewModel>();
				config.CreateMap<DistrictViewModel, District>();
				#endregion

				#region District, DistrictLightViewModel
				config.CreateMap<District, DistrictLightViewModel>();
				config.CreateMap<DistrictLightViewModel, District>();
				#endregion


				#region StockAssessmentPolicy, StockAssessmentPolicyViewModel
				config.CreateMap<StockAssessmentPolicy, StockAssessmentPolicyViewModel>();
				config.CreateMap<StockAssessmentPolicyViewModel, StockAssessmentPolicy>();
				#endregion

				#region StockAssessmentPolicy, StockAssessmentPolicyLightViewModel
				config.CreateMap<StockAssessmentPolicy, StockAssessmentPolicyLightViewModel>();
				config.CreateMap<StockAssessmentPolicyLightViewModel, StockAssessmentPolicy>();
				#endregion


				#region Mail, MailViewModel
				config.CreateMap<Mail, MailViewModel>();
				config.CreateMap<MailViewModel, Mail>();
				#endregion

				#region Mail, MailLightViewModel
				config.CreateMap<Mail, MailLightViewModel>();
				config.CreateMap<MailLightViewModel, Mail>();
				#endregion


				#region Mobile, MobileViewModel
				config.CreateMap<Mobile, MobileViewModel>();
				config.CreateMap<MobileViewModel, Mobile>();
				#endregion

				#region Mobile, MobileLightViewModel
				config.CreateMap<Mobile, MobileLightViewModel>();
				config.CreateMap<MobileLightViewModel, Mobile>();
				#endregion


				#region BankMovement, BankMovementViewModel
				config.CreateMap<BankMovement, BankMovementViewModel>();
				//.ForMember(x => x.Id, z => z.MapFrom(o => o.ParentKeyBankMovementId))
				//.ForMember(x => x.Code, z => z.MapFrom(o => o.ParentKeyBankMovement.Code))
				//.ForMember(x => x.AccountChartId, z => z.MapFrom(o => o.ParentKeyBankMovement.AccountChartId))
				//.ForMember(x => x.Amount, z => z.MapFrom(o => o.ParentKeyBankMovement.Amount))
				//.ForMember(x => x.BankId, z => z.MapFrom(o => o.ParentKeyBankMovement.BankId))
				//.ForMember(x => x.CreatedByUserId, z => z.MapFrom(o => o.ParentKeyBankMovement.CreatedByUserId))
				//.ForMember(x => x.CreationDate, z => z.MapFrom(o => o.ParentKeyBankMovement.CreationDate))
				//.ForMember(x => x.Date, z => z.MapFrom(o => o.ParentKeyBankMovement.Date))
				//.ForMember(x => x.JournalTypeId, z => z.MapFrom(o => o.ParentKeyBankMovement.JournalTypeId))
				//.ForMember(x => x.FirstModificationDate, z => z.MapFrom(o => o.ParentKeyBankMovement.FirstModificationDate))
				//.ForMember(x => x.FirstModifiedByUserId, z => z.MapFrom(o => o.ParentKeyBankMovement.FirstModifiedByUserId))
				//.ForMember(x => x.LastModificationDate, z => z.MapFrom(o => o.ParentKeyBankMovement.LastModificationDate))
				//.ForMember(x => x.LastModifiedByUserId, z => z.MapFrom(o => o.ParentKeyBankMovement.LastModifiedByUserId))
				//.ForMember(x => x.SafeId, z => z.MapFrom(o => o.ParentKeyBankMovement.SafeId))
				//.ForMember(x => x.ToBankId, z => z.MapFrom(o => o.ParentKeyBankMovement.ToBankId));
				config.CreateMap<BankMovementViewModel, BankMovement>();
				#endregion

				#region BankMovement, BankMovementLightViewModel
				config.CreateMap<BankMovement, BankMovementLightViewModel>();
				//.ForMember(x => x.Id, z => z.MapFrom(o => o.ParentKeyBankMovementId))
				//.ForMember(x => x.Code, z => z.MapFrom(o => o.ParentKeyBankMovement.Code))
				//.ForMember(x => x.AccountChartId, z => z.MapFrom(o => o.ParentKeyBankMovement.AccountChartId))
				//.ForMember(x => x.Amount, z => z.MapFrom(o => o.ParentKeyBankMovement.Amount))
				//.ForMember(x => x.BankId, z => z.MapFrom(o => o.ParentKeyBankMovement.BankId))
				//.ForMember(x => x.CreatedByUserId, z => z.MapFrom(o => o.ParentKeyBankMovement.CreatedByUserId))
				//.ForMember(x => x.CreationDate, z => z.MapFrom(o => o.ParentKeyBankMovement.CreationDate))
				//.ForMember(x => x.Date, z => z.MapFrom(o => o.ParentKeyBankMovement.Date))
				//.ForMember(x => x.JournalTypeId, z => z.MapFrom(o => o.ParentKeyBankMovement.JournalTypeId))
				//.ForMember(x => x.FirstModificationDate, z => z.MapFrom(o => o.ParentKeyBankMovement.FirstModificationDate))
				//.ForMember(x => x.FirstModifiedByUserId, z => z.MapFrom(o => o.ParentKeyBankMovement.FirstModifiedByUserId))
				//.ForMember(x => x.LastModificationDate, z => z.MapFrom(o => o.ParentKeyBankMovement.LastModificationDate))
				//.ForMember(x => x.LastModifiedByUserId, z => z.MapFrom(o => o.ParentKeyBankMovement.LastModifiedByUserId))
				//.ForMember(x => x.SafeId, z => z.MapFrom(o => o.ParentKeyBankMovement.SafeId))
				//.ForMember(x => x.ToBankId, z => z.MapFrom(o => o.ParentKeyBankMovement.ToBankId));
				config.CreateMap<BankMovementLightViewModel, BankMovement>();
				#endregion

				#region BankMovement, ListBankMovementsLightViewModel
				config.CreateMap<BankMovement, ListBankMovementsLightViewModel>()
				.ForMember(x => x.Id, z => z.MapFrom(o => o.ParentKeyBankMovementId))
				.ForMember(x => x.Code, z => z.MapFrom(o => o.ParentKeyBankMovement.Code))
				//.ForMember(x => x.AccountChartId, z => z.MapFrom(o => o.ParentKeyBankMovement.AccountChartId))
				.ForMember(x => x.Amount, z => z.MapFrom(o => o.ParentKeyBankMovement.Amount))
				.ForMember(x => x.BankName, z => z.MapFrom(o => o.ParentKeyBankMovement.BankId))
				//.ForMember(x => x.CreatedByUserId, z => z.MapFrom(o => o.ParentKeyBankMovement.CreatedByUserId))
				//.ForMember(x => x.CreationDate, z => z.MapFrom(o => o.ParentKeyBankMovement.CreationDate))
				.ForMember(x => x.Date, z => z.MapFrom(o => o.ParentKeyBankMovement.Date))
				.ForMember(x => x.JournalTypeName, z => z.MapFrom(o => o.ParentKeyBankMovement.JournalTypeId));
				//.ForMember(x => x.FirstModificationDate, z => z.MapFrom(o => o.ParentKeyBankMovement.FirstModificationDate))
				//.ForMember(x => x.FirstModifiedByUserId, z => z.MapFrom(o => o.ParentKeyBankMovement.FirstModifiedByUserId))
				//.ForMember(x => x.LastModificationDate, z => z.MapFrom(o => o.ParentKeyBankMovement.LastModificationDate))
				//.ForMember(x => x.LastModifiedByUserId, z => z.MapFrom(o => o.ParentKeyBankMovement.LastModifiedByUserId))
				//.ForMember(x => x.SafeId, z => z.MapFrom(o => o.ParentKeyBankMovement.SafeId))
				//.ForMember(x => x.ToBankId, z => z.MapFrom(o => o.ParentKeyBankMovement.ToBankId));
				config.CreateMap<ListBankMovementsLightViewModel, BankMovement>();
				#endregion


				#region Transfer, TransferViewModel
				config.CreateMap<Transfer, TransferViewModel>();
				config.CreateMap<TransferViewModel, Transfer>();
				#endregion

				#region Transfer, TransferLightViewModel
				config.CreateMap<Transfer, TransferLightViewModel>();
				config.CreateMap<TransferLightViewModel, Transfer>();
				#endregion


				#region InventoryTransfer, InventoryTransferViewModel
				config.CreateMap<InventoryTransfer, InventoryTransferViewModel>();
				config.CreateMap<InventoryTransferViewModel, InventoryTransfer>();
				#endregion


				#region InventoryTransfer, InventoryTransferAddViewModel
				config.CreateMap<InventoryTransfer, InventoryTransferAddViewModel>()
				.ForMember(x => x.DescriptionAr, z => z.MapFrom(o => o.ChildTranslatedInventoryTransfers.FirstOrDefault(x => x.Language == Language.Arabic).Description))
				.ForMember(x => x.DescriptionEn, z => z.MapFrom(o => o.ChildTranslatedInventoryTransfers.FirstOrDefault(x => x.Language == Language.English).Description))
				.ForMember(x => x.Date, z => z.MapFrom(o => o.Date))
				.ForMember(x => x.Code, z => z.MapFrom(o => (string.IsNullOrEmpty(o.Code) ? o.Id.ToString() : o.Code)))
				.ForMember(x => x.Products, z => z.MapFrom(o => o.InventoryProductHistorys))
				.ForMember(x => x.InventoryTransferCostCenter, z => z.MapFrom(o => o.InventoryTransferCostCenter));

				config.CreateMap<InventoryTransferAddViewModel, InventoryTransfer>()
				#region Ignore Translation
				.ForMember(x => x.ChildTranslatedInventoryTransfers, opt => opt.Ignore())
				.ForMember(x => x.ParentKeyInventoryTransfer, opt => opt.Ignore())
				.ForMember(x => x.ParentKeyInventoryTransferId, opt => opt.Ignore())
				.ForMember(x => x.Language, opt => opt.Ignore())
				#endregion
				#region IgnoreandSet TimeStamp
				 .ForMember(x => x.CreationDate, opt => opt.MapFrom(t => DateTime.Now))
				 .ForMember(x => x.LastModificationDate, opt => opt.Ignore())
				 .ForMember(x => x.FirstModificationDate, opt => opt.Ignore())
				#endregion
				  .ForMember(x => x.InventoryProductHistorys, z => z.MapFrom(o => o.Products))
				;

				#region PurchaseRebateProduct, PurchaseRebateCostCenter
				config.CreateMap<InventoryTransferCostCenter, InventoryCostCentersViewModel>()
						   //.ForMember(x => x.PurchaseRebate, z => z.Ignore())
						   .ForMember(x => x.InventoryOpeningBalanceId, z => z.Ignore())
				;

				config.CreateMap<InventoryCostCentersViewModel, InventoryTransferCostCenter>()
				#region IgnoreandSet TimeStamp
				 .ForMember(x => x.CreationDate, opt => opt.MapFrom(t => DateTime.Now))
				 .ForMember(x => x.LastModificationDate, opt => opt.Ignore())
				 .ForMember(x => x.FirstModificationDate, opt => opt.Ignore())
				#endregion
				.ForMember(x => x.CostCenterId, z => z.MapFrom(o => o.CostCenterId))
				.ForMember(x => x.InventoryTransferId, z => z.MapFrom(o => o.InventoryOpeningBalanceId))

				 ;
				#endregion
				#endregion

				#region InventoryTransferCostCenter, InventoryTransferCostCenterViewModel
				config.CreateMap<InventoryTransferCostCenterViewModel, InventoryTransferCostCenter>();
				#endregion

				#region InventoryTransferCostCenter, InventoryTransferCostCenterViewModel
				config.CreateMap<InventoryTransferCostCenter, InventoryTransferCostCenterViewModel>();
				config.CreateMap<InventoryTransferCostCenterViewModel, InventoryTransferCostCenter>();
				#endregion


				//#region InventoryTransfer, InventoryTransferLightViewModel
				//config.CreateMap<InventoryTransfer, InventoryTransferLightViewModel>();
				//config.CreateMap<InventoryTransferLightViewModel, InventoryTransfer>();
				//            #endregion

				#region PurchaseInvoice, PurchaseInvoiceLightViewModel
				config.CreateMap<InventoryTransfer, InventoryTransferLightViewModel>()
				.ForMember(x => x.InventoryFrom, z => z.MapFrom(o => o.InventoryFrom.Name))
				.ForMember(x => x.InventoryTo, z => z.MapFrom(o => o.InventoryTo.Name))
				 .ForMember(x => x.Description, z => z.MapFrom(o => o.Description))
				//.ForMember(x => x.Description, z => z.MapFrom(o => o.ChildTranslatedInventoryTransfers.FirstOrDefault(x => x.Language == Framework.Common.Enums.Language.Arabic).Description))
				//.ForMember(x => x.Description, z => z.MapFrom(o => o.ChildTranslatedInventoryTransfers.FirstOrDefault(x => x.Language == Framework.Common.Enums.Language.English).Description))
				;
				config.CreateMap<InventoryTransferLightViewModel, InventoryTransfer>();
				#endregion

				//#region InventoryOpeningBalanceCostCenter, InventoryOpeningBalanceCostCenterViewModel
				//config.CreateMap<InventoryOpeningBalanceCostCenterViewModel, InventoryOpeningBalanceCostCenter>();
				//#endregion

				#region InventoryOpeningBalanceCostCenter, InventoryOpeningBalanceCostCenterViewModel
				config.CreateMap<InventoryOpeningBalanceCostCenter, InventoryOpeningBalanceCostCenterViewModel>();
				config.CreateMap<InventoryOpeningBalanceCostCenterViewModel, InventoryOpeningBalanceCostCenter>();
				#endregion


				#region PurchaseInvoice, PurchaseInvoiceLightViewModel
				config.CreateMap<InventoryOpeningBalance, InventoryOpeningBalanceLightViewModel>()
				.ForMember(x => x.Inventory, z => z.MapFrom(o => o.Inventory.Name))

				.ForMember(x => x.Description, z => z.MapFrom(o => o.Description))

				;
				config.CreateMap<InventoryOpeningBalanceLightViewModel, InventoryOpeningBalance>();
				#endregion


				#region InventoryOpeningBalance, InventoryOpeningBalanceViewModel
				config.CreateMap<InventoryOpeningBalance, InventoryOpeningBalanceViewModel>()
				.ForMember(x => x.Inventory, z => z.Ignore())
				//.ForMember(x => x.Products, z => z.Ignore())
				.ForMember(x => x.Products, z => z.MapFrom(o => o.Products))
				.ForMember(x => x.InventoryOpeningBalanceCostCenter, z => z.MapFrom(o => o.InventoryOpeningBalanceCostCenter))

				;
				config.CreateMap<InventoryOpeningBalanceViewModel, InventoryOpeningBalance>();
				#endregion

				#region InventoryOpeningBalanceCostCenter, InventoryOpeningBalanceCostCenterViewModel
				config.CreateMap<InventoryOpeningBalanceCostCenter, InventoryOpeningBalanceCostCenterViewModel>()
						   .ForMember(x => x.InventoryOpeningBalance, z => z.Ignore())
						   .ForMember(x => x.CostCenter, z => z.Ignore())
				;
				#endregion

				#region InventoryOpeningBalance, InventoryOpeningBalanceAddViewModel
				config.CreateMap<InventoryOpeningBalance, InventoryOpeningBalanceAddViewModel>()
				.ForMember(x => x.DescriptionAr, z => z.MapFrom(o => o.ChildTranslatedInventoryOpeningBalance.FirstOrDefault(x => x.Language == Language.Arabic).Description))
				.ForMember(x => x.DescriptionEn, z => z.MapFrom(o => o.ChildTranslatedInventoryOpeningBalance.FirstOrDefault(x => x.Language == Language.English).Description))
				.ForMember(x => x.Date, z => z.MapFrom(o => o.CreationDate))
				.ForMember(x => x.Code, z => z.MapFrom(o => (string.IsNullOrEmpty(o.Code) ? o.Id.ToString() : o.Code)))
				.ForMember(x => x.Products, z => z.MapFrom(o => o.Products))
				 .ForMember(x => x.InventoryOpeningBalanceCostCenter, z => z.MapFrom(o => o.InventoryOpeningBalanceCostCenter))
				;

				config.CreateMap<InventoryOpeningBalanceAddViewModel, InventoryOpeningBalance>()

				#region Ignore Translation
				.ForMember(x => x.ChildTranslatedInventoryOpeningBalance, opt => opt.Ignore())
				.ForMember(x => x.ParentKeyInventoryOpeningBalance, opt => opt.Ignore())
				.ForMember(x => x.ParentKeyInventoryOpeningBalanceId, opt => opt.Ignore())
				.ForMember(x => x.Language, opt => opt.Ignore())
				#endregion
				#region IgnoreandSet TimeStamp
				  .ForMember(x => x.CreationDate, opt => opt.MapFrom(t => DateTime.Now))
				 .ForMember(x => x.LastModificationDate, opt => opt.Ignore())
				 .ForMember(x => x.FirstModificationDate, opt => opt.Ignore())
				#endregion
				 .ForMember(x => x.Products, z => z.MapFrom(o => o.Products))
				;

                #region Product, InventoryOpeningBalanceProductViewModel
                config.CreateMap<Product, InventoryOpeningBalanceProductViewModel>()
						   //.ForMember(x => x.PurchaseRebate, z => z.Ignore())
						   .ForMember(x => x.MeasurementUnit, z => z.Ignore())
						   .ForMember(x => x.ProductType, z => z.Ignore())
						   .ForMember(x => x.Brand, z => z.Ignore())
						   .ForMember(x => x.AccountChart, z => z.Ignore());
				;

				config.CreateMap<InventoryOpeningBalanceProductViewModel, Product>()
				#region IgnoreandSet TimeStamp
				 .ForMember(x => x.CreationDate, opt => opt.MapFrom(t => DateTime.Now))
				 .ForMember(x => x.LastModificationDate, opt => opt.Ignore())
				 .ForMember(x => x.FirstModificationDate, opt => opt.Ignore())
				#endregion
				.ForMember(x => x.AccountChartId, z => z.MapFrom(o => o.AccountChartId))
				.ForMember(x => x.BrandId, z => z.MapFrom(o => o.BrandId))
				.ForMember(x => x.MeasurementUnitId, z => z.MapFrom(o => o.MeasurementUnitId))
				.ForMember(x => x.Price, z => z.MapFrom(o => o.Price))
				.ForMember(x => x.Quantity, z => z.MapFrom(o => o.Quantity))
				.ForMember(x => x.AccountChart, opt => opt.Ignore())

				 ;
                #endregion


                #region InventoryOpeningBalanceCostCenter, InventoryCostCentersViewModel
                config.CreateMap<InventoryOpeningBalanceCostCenter, InventoryCostCentersViewModel>()
						   //.ForMember(x => x.PurchaseRebate, z => z.Ignore())
						   .ForMember(x => x.InventoryOpeningBalanceId, z => z.Ignore())
				;

				config.CreateMap<InventoryCostCentersViewModel, InventoryOpeningBalanceCostCenter>()
				#region IgnoreandSet TimeStamp
				 .ForMember(x => x.CreationDate, opt => opt.MapFrom(t => DateTime.Now))
				 .ForMember(x => x.LastModificationDate, opt => opt.Ignore())
				 .ForMember(x => x.FirstModificationDate, opt => opt.Ignore())
				#endregion
				.ForMember(x => x.CostCenterId, z => z.MapFrom(o => o.CostCenterId))
				.ForMember(x => x.InventoryOpeningBalanceId, z => z.MapFrom(o => o.InventoryOpeningBalanceId))


				 ;
				#endregion
				#endregion

				#region InventoryMovement, InventoryMovementViewModel
				config.CreateMap<InventoryMovement, InventoryMovementViewModel>();
				config.CreateMap<InventoryMovementViewModel, InventoryMovement>();
				#endregion

				#region InventoryMovement, InventoryMovementAddViewModel
				config.CreateMap<InventoryMovement, InventoryMovementAddViewModel>()
				.ForMember(x => x.DescriptionAr, z => z.MapFrom(o => o.ChildTranslatedInventoryMovements.FirstOrDefault(x => x.Language == Language.Arabic).Description))
				.ForMember(x => x.DescriptionEn, z => z.MapFrom(o => o.ChildTranslatedInventoryMovements.FirstOrDefault(x => x.Language == Language.English).Description))
				.ForMember(x => x.Date, z => z.MapFrom(o => o.Date))
				.ForMember(x => x.Products, z => z.MapFrom(o => o.InventoryProductHistorys))
				.ForMember(x => x.Code, z => z.MapFrom(o => (string.IsNullOrEmpty(o.Code) ? o.Id.ToString() : o.Code)))
				.ForMember(x => x.InventoryMovementCostCenter, z => z.MapFrom(o => o.InventoryMovementCostCenter));

				config.CreateMap<InventoryMovementAddViewModel, InventoryMovement>()
				#region Ignore Translation
				.ForMember(x => x.ChildTranslatedInventoryMovements, opt => opt.Ignore())
				.ForMember(x => x.ParentKeyInventoryMovement, opt => opt.Ignore())
				.ForMember(x => x.ParentKeyInventoryMovementId, opt => opt.Ignore())
				.ForMember(x => x.Language, opt => opt.Ignore())
				#endregion
				#region IgnoreandSet TimeStamp
				 .ForMember(x => x.CreationDate, opt => opt.MapFrom(t => DateTime.Now))
				 .ForMember(x => x.LastModificationDate, opt => opt.Ignore())
				 .ForMember(x => x.FirstModificationDate, opt => opt.Ignore())
				#endregion
				  .ForMember(x => x.InventoryProductHistorys, z => z.MapFrom(o => o.Products))
				;

				#region InventoryCostCentersViewModel, InventoryMovementCostCenter
				config.CreateMap<InventoryMovementCostCenter, InventoryCostCentersViewModel>()
						   //.ForMember(x => x.PurchaseRebate, z => z.Ignore())
						   .ForMember(x => x.InventoryOpeningBalanceId, z => z.Ignore())
				;

				config.CreateMap<InventoryCostCentersViewModel, InventoryMovementCostCenter>()
				#region IgnoreandSet TimeStamp
				 .ForMember(x => x.CreationDate, opt => opt.MapFrom(t => DateTime.Now))
				 .ForMember(x => x.LastModificationDate, opt => opt.Ignore())
				 .ForMember(x => x.FirstModificationDate, opt => opt.Ignore())
				#endregion
				.ForMember(x => x.CostCenterId, z => z.MapFrom(o => o.CostCenterId))
				.ForMember(x => x.InventoryMovementId, z => z.MapFrom(o => o.InventoryOpeningBalanceId))

				 ;
                #endregion
                #endregion

                #region InventoryProductHistory, InventoryOpeningBalanceProductViewModel
                config.CreateMap<InventoryProductHistory, InventoryOpeningBalanceProductViewModel>()
						   //.ForMember(x => x.PurchaseRebate, z => z.Ignore())
						   .ForMember(x => x.MeasurementUnit, z => z.Ignore())
						   .ForMember(x => x.ProductType, z => z.Ignore())
						   .ForMember(x => x.Brand, z => z.Ignore())
						   .ForMember(x => x.AccountChart, z => z.Ignore())
                           ;				

				config.CreateMap<InventoryOpeningBalanceProductViewModel, InventoryProductHistory>()
				#region IgnoreandSet TimeStamp
				 .ForMember(x => x.CreationDate, opt => opt.MapFrom(t => DateTime.Now))
				 .ForMember(x => x.LastModificationDate, opt => opt.Ignore())
				 .ForMember(x => x.FirstModificationDate, opt => opt.Ignore())
				#endregion
				.ForMember(x => x.BrandId, z => z.MapFrom(o => o.BrandId))
				.ForMember(x => x.MeasurementUnitId, z => z.MapFrom(o => o.MeasurementUnitId))
				.ForMember(x => x.Price, z => z.MapFrom(o => o.Price))
				.ForMember(x => x.Quantity, z => z.MapFrom(o => o.Quantity))
				;
				#endregion

				#region InventoryMovement, InventoryMovementLightViewModel
				config.CreateMap<InventoryMovement, InventoryMovementLightViewModel>()
				.ForMember(x => x.Inventory, z => z.MapFrom(o => o.Inventory.Name))
				.ForMember(x => x.Description, z => z.MapFrom(o => o.Description))
				 .ForMember(x => x.InventoryMovementType, z => z.MapFrom(o => o.InventoryMovementType.Name))
				//.ForMember(x => x.Description, z => z.MapFrom(o => o.ChildTranslatedInventoryMovements.FirstOrDefault(x => x.Language == Framework.Common.Enums.Language.Arabic).Description))
				//.ForMember(x => x.Description, z => z.MapFrom(o => o.ChildTranslatedInventoryMovements.FirstOrDefault(x => x.Language == Framework.Common.Enums.Language.English).Description))
				;
				config.CreateMap<InventoryMovementLightViewModel, InventoryMovement>();
				#endregion



				#region InventoryMovementType, InventoryMovementTypeLightViewModel
				config.CreateMap<InventoryMovementType, InventoryMovementTypeLightViewModel>()
			   .ForMember(x => x.Id, opt => opt.MapFrom(src => src.ParentKeyInventoryMovementTypeId))
               .ForMember(x => x.ParentInventoryMovementTypeId, opt => opt.MapFrom(src => src.ParentKeyInventoryMovementType.ParentInventoryMovementTypeId))
				;
				config.CreateMap<InventoryMovementTypeLightViewModel, InventoryMovementType>();
				#endregion

				//#region InventoryMovementCostCenter, InventoryMovementCostCenterViewModel
				//config.CreateMap<InventoryMovementCostCenterViewModel, InventoryMovementCostCenter>();
    //            #endregion

                #region InventoryMovementCostCenter, InventoryMovementCostCenterViewModel
                config.CreateMap<InventoryMovementCostCenter, InventoryMovementCostCenterViewModel>();
                config.CreateMap<InventoryMovementCostCenterViewModel, InventoryMovementCostCenter>();
                #endregion

                #region InventoryMovementType, InventoryMovementTypeViewModel
                config.CreateMap<InventoryMovementType, InventoryMovementTypeViewModel>();
				config.CreateMap<InventoryMovementTypeViewModel, InventoryMovementType>();
				#endregion

				//#region InventoryMovementType, InventoryMovementTypeViewModel
				//config.CreateMap<InventoryMovementType, InventoryMovementTypeViewModel>();
				//config.CreateMap<InventoryMovementTypeViewModel, InventoryMovementType>();
				//#endregion

				#region InventoryIn, InventoryInViewModel
				config.CreateMap<InventoryIn, InventoryInViewModel>();
				config.CreateMap<InventoryInViewModel, InventoryIn>();
				#endregion

				#region InventoryIn, InventoryInLightViewModel
				config.CreateMap<InventoryIn, InventoryInLightViewModel>();
				config.CreateMap<InventoryInLightViewModel, InventoryIn>();
				#endregion

				#region InventoryOut, InventoryOutViewModel
				config.CreateMap<InventoryOut, InventoryOutViewModel>();
				config.CreateMap<InventoryOutViewModel, InventoryOut>();
				#endregion

				#region InventoryOut, InventoryOutLightViewModel
				config.CreateMap<InventoryOut, InventoryOutLightViewModel>();
				config.CreateMap<InventoryOutLightViewModel, InventoryOut>();
				#endregion

				#region InventoryDifference, InventoryDifferenceViewModel
				config.CreateMap<InventoryDifference, InventoryDifferenceViewModel>();
				config.CreateMap<InventoryDifferenceViewModel, InventoryDifference>();
				#endregion

				#region InventoryDifference, InventoryDifferenceLightViewModel
				config.CreateMap<InventoryDifference, InventoryDifferenceLightViewModel>();
				config.CreateMap<InventoryDifferenceLightViewModel, InventoryDifference>();
				#endregion


				#region PaymentMovment, PaymentMovmentViewModel
				config.CreateMap<PaymentMovment, PaymentMovmentViewModel>();
				config.CreateMap<PaymentMovmentViewModel, PaymentMovment>();
				#endregion

				#region PaymentMovment, PaymentMovmentLightViewModel
				config.CreateMap<PaymentMovment, PaymentMovmentLightViewModel>();
				config.CreateMap<PaymentMovmentLightViewModel, PaymentMovment>();
				#endregion


				#region DonationType, DonationTypeViewModel
				config.CreateMap<DonationType, DonationTypeViewModel>();
				config.CreateMap<DonationTypeViewModel, DonationType>();
				#endregion

				#region DonationType, DonationTypeLightViewModel
				config.CreateMap<DonationType, DonationTypeLightViewModel>()
				.ForMember(x => x.Id, z => z.MapFrom(o => o.ParentKeyDonationTypeId))
                .ForMember(x => x.ParentId, z => z.MapFrom(o => o.ParentKeyDonationType.ParentId))
				;
				config.CreateMap<DonationTypeLightViewModel, DonationType>();
				#endregion


				#region Setting, SettingViewModel
				config.CreateMap<Setting, SettingViewModel>();
				config.CreateMap<SettingViewModel, Setting>();
				#endregion

				#region Setting, SettingLightViewModel
				config.CreateMap<Setting, SettingLightViewModel>();
				config.CreateMap<SettingLightViewModel, Setting>();
				#endregion


				#region JournalType, JournalTypeViewModel
				config.CreateMap<JournalType, JournalTypeViewModel>()
				.ForMember(x => x.Id, opt => opt.MapFrom(src => (src.ParentKeyJournalTypeId.HasValue ? src.ParentKeyJournalTypeId.Value : src.Id)))
				.ForMember(x => x.Code, opt => opt.MapFrom(src => (src.ParentKeyJournalTypeId.HasValue ? src.ParentKeyJournalType.Code : src.Code)));

				config.CreateMap<JournalTypeViewModel, JournalType>();
				#endregion

				#region JournalType, JournalTypeLightViewModel
				config.CreateMap<JournalType, JournalTypeLightViewModel>()
				.ForMember(x => x.Id, opt => opt.MapFrom(src => (src.ParentKeyJournalTypeId.HasValue ? src.ParentKeyJournalTypeId.Value : src.Id)))
				.ForMember(x => x.Code, opt => opt.MapFrom(src => (src.ParentKeyJournalTypeId.HasValue ? src.ParentKeyJournalType.Code : src.Code)));

				config.CreateMap<JournalTypeLightViewModel, JournalType>();
				#endregion


				#region PurchaseInvoiceType, PurchaseInvoiceTypeViewModel
				config.CreateMap<PurchaseInvoiceType, PurchaseInvoiceTypeViewModel>()
				.ForMember(x => x.Id, opt => opt.MapFrom(src => (src.ParentKeyPurchaseInvoiceTypeId.HasValue ? src.ParentKeyPurchaseInvoiceTypeId.Value : src.Id)));

				config.CreateMap<PurchaseInvoiceTypeViewModel, PurchaseInvoiceType>();
				#endregion

				#region PurchaseInvoiceType, PurchaseInvoiceTypeLightViewModel
				config.CreateMap<PurchaseInvoiceType, PurchaseInvoiceTypeLightViewModel>()
				.ForMember(x => x.Id, opt => opt.MapFrom(src => (src.ParentKeyPurchaseInvoiceTypeId.HasValue ? src.ParentKeyPurchaseInvoiceTypeId.Value : src.Id)));

				config.CreateMap<PurchaseInvoiceTypeLightViewModel, PurchaseInvoiceType>();
				#endregion


				#region PurchaseInvoiceCostCenter, PurchaseInvoiceCostCenterViewModel
				//config.CreateMap<PurchaseInvoiceCostCenter, PurchaseInvoiceCostCenterViewModel>();
				config.CreateMap<PurchaseInvoiceCostCenterViewModel, PurchaseInvoiceCostCenter>();
				#endregion

				#region PurchaseInvoiceCostCenter, PurchaseInvoiceCostCenterLightViewModel
				config.CreateMap<PurchaseInvoiceCostCenter, PurchaseInvoiceCostCenterLightViewModel>();
				config.CreateMap<PurchaseInvoiceCostCenterLightViewModel, PurchaseInvoiceCostCenter>();
				#endregion


				#region PurchaseRebateCostCenter, PurchaseRebateCostCenterViewModel
				config.CreateMap<PurchaseRebateCostCenter, PurchaseRebateCostCenterViewModel>();
				config.CreateMap<PurchaseRebateCostCenterViewModel, PurchaseRebateCostCenter>();
				#endregion

				#region PurchaseRebateCostCenter, PurchaseRebateCostCenterLightViewModel
				config.CreateMap<PurchaseRebateCostCenter, PurchaseRebateCostCenterLightViewModel>();
				config.CreateMap<PurchaseRebateCostCenterLightViewModel, PurchaseRebateCostCenter>();
				#endregion


				#region AccountChartLevelSetting, AccountChartLevelSettingViewModel
				config.CreateMap<AccountChartLevelSetting, AccountChartLevelSettingViewModel>();
				config.CreateMap<AccountChartLevelSettingViewModel, AccountChartLevelSetting>();
				#endregion

				#region AccountChartLevelSetting, AccountChartLevelSettingLightViewModel
				config.CreateMap<AccountChartLevelSetting, AccountChartLevelSettingLightViewModel>();
				config.CreateMap<AccountChartLevelSettingLightViewModel, AccountChartLevelSetting>();
				#endregion


				#region Brand, BrandViewModel
				config.CreateMap<Brand, BrandViewModel>()
				.ForMember(x => x.Id, opt => opt.MapFrom(src => (src.ParentKeyBrandId.HasValue ? src.ParentKeyBrandId : src.Id)))
				.ForMember(x => x.Code, opt => opt.MapFrom(src => src.ParentKeyBrandId.HasValue ? src.ParentKeyBrand.Code : src.Code))
				.ForMember(x => x.Description, opt => opt.MapFrom(src => src.ParentKeyBrandId.HasValue ? src.ParentKeyBrand.Description : src.Description))
				.ForMember(x => x.Date, opt => opt.MapFrom(src => src.ParentKeyBrandId.HasValue ? src.ParentKeyBrand.Date : src.Date))
				.ForMember(x => x.NameAr, z => z.MapFrom(o => o.ParentKeyBrand != null ? o.ParentKeyBrand.ChildTranslatedBrands.FirstOrDefault(item => item.Language == Language.Arabic).Name : o.ChildTranslatedBrands.FirstOrDefault(item => item.Language == Language.Arabic).Name))
				.ForMember(x => x.NameEn, z => z.MapFrom(o => o.ParentKeyBrand != null ? o.ParentKeyBrand.ChildTranslatedBrands.FirstOrDefault(item => item.Language == Language.English).Name : o.ChildTranslatedBrands.FirstOrDefault(item => item.Language == Language.English).Name))
				.ForMember(x => x.DescriptionAr, z => z.MapFrom(o => o.ParentKeyBrand != null ? o.ParentKeyBrand.ChildTranslatedBrands.FirstOrDefault(item => item.Language == Language.Arabic).Description : o.ChildTranslatedBrands.FirstOrDefault(item => item.Language == Language.Arabic).Description))
				.ForMember(x => x.DescriptionEn, z => z.MapFrom(o => o.ParentKeyBrand != null ? o.ParentKeyBrand.ChildTranslatedBrands.FirstOrDefault(item => item.Language == Language.English).Description : o.ChildTranslatedBrands.FirstOrDefault(item => item.Language == Language.English).Description))
                .ForMember(x => x.ParentBrandId, opt => opt.MapFrom(src => src.ParentKeyBrandId.HasValue ? src.ParentKeyBrand.ParentBrandId : src.ParentBrandId))
				;

				config.CreateMap<BrandViewModel, Brand>();
				#endregion

				#region Brand, BrandLightViewModel
				config.CreateMap<Brand, BrandLightViewModel>()
				.ForMember(x => x.Id, opt => opt.MapFrom(src => (src.ParentKeyBrandId.HasValue ? src.ParentKeyBrandId : src.Id)))
				.ForMember(m => m.Code, opt => opt.MapFrom(src => (src.ParentKeyBrand != null ? src.ParentKeyBrand.Code : src.Code)))
				.ForMember(m => m.DisplyedName, opt => opt.MapFrom(src => $"{src.ParentKeyBrand.Code} - {src.Name}"))
                .ForMember(x => x.ChildBrands, opt => opt.MapFrom(src => src.ParentKeyBrand.ChildBrands))
				;

				config.CreateMap<BrandLightViewModel, Brand>();
				#endregion


				#region StoreMovement, StoreMovementViewModel
				config.CreateMap<StoreMovement, StoreMovementViewModel>()
				.ForMember(m => m.Id, opt => opt.MapFrom(s => s.ParentKeyStoreMovement != null ? s.ParentKeyStoreMovementId : s.Id))
				.ForMember(m => m.Code, opt => opt.MapFrom(s => s.ParentKeyStoreMovement != null ? s.ParentKeyStoreMovement.Code : s.Code));

				config.CreateMap<StoreMovementViewModel, StoreMovement>();
				#endregion

				#region StoreMovement, StoreMovementLightViewModel
				config.CreateMap<StoreMovement, StoreMovementLightViewModel>()
				.ForMember(m => m.Id, opt => opt.MapFrom(s => s.ParentKeyStoreMovement != null ? s.ParentKeyStoreMovementId : s.Id))
				.ForMember(m => m.Code, opt => opt.MapFrom(s => s.ParentKeyStoreMovement != null ? s.ParentKeyStoreMovement.Code : s.Code));

				config.CreateMap<StoreMovementLightViewModel, StoreMovement>();
				#endregion


				#region JournalPosting, JournalPostingViewModel
				config.CreateMap<JournalPosting, JournalPostingViewModel>();
				//.ForMember(m => m.Id, opt => opt.MapFrom(s => s.ParentKeyJournalPosting != null ? s.ParentKeyJournalPostingId : s.Id))
				//.ForMember(m => m.Code, opt => opt.MapFrom(s => s.ParentKeyJournalPosting != null ? s.ParentKeyJournalPosting.Code : s.Code));

				config.CreateMap<JournalPostingViewModel, JournalPosting>();
				#endregion

				#region JournalPosting, JournalPostingLightViewModel
				config.CreateMap<JournalPosting, JournalPostingLightViewModel>();
				//.ForMember(m => m.Id, opt => opt.MapFrom(s => s.ParentKeyJournalPosting != null ? s.ParentKeyJournalPostingId : s.Id))
				//.ForMember(m => m.Code, opt => opt.MapFrom(s => s.ParentKeyJournalPosting != null ? s.ParentKeyJournalPosting.Code : s.Code));

				config.CreateMap<JournalPostingLightViewModel, JournalPosting>();
				#endregion


				#region FiscalYear, FiscalYearViewModel
				config.CreateMap<FiscalYear, FiscalYearViewModel>()
				.ForMember(m => m.Id, opt => opt.MapFrom(src => src.ParentKeyFiscalYearId.HasValue ? src.ParentKeyFiscalYearId.Value : src.Id))
				.ForMember(m => m.From, opt => opt.MapFrom(src => src.ParentKeyFiscalYearId.HasValue ? src.ParentKeyFiscalYear.From : src.From))
				.ForMember(m => m.To, opt => opt.MapFrom(src => src.ParentKeyFiscalYearId.HasValue ? src.ParentKeyFiscalYear.To : src.To));

				config.CreateMap<FiscalYearViewModel, FiscalYear>();
				#endregion

				#region FiscalYear, FiscalYearLightViewModel
				config.CreateMap<FiscalYear, FiscalYearLightViewModel>()
				.ForMember(m => m.Id, opt => opt.MapFrom(src => src.ParentKeyFiscalYearId.HasValue ? src.ParentKeyFiscalYearId.Value : src.Id))
				.ForMember(m => m.From, opt => opt.MapFrom(src => src.ParentKeyFiscalYearId.HasValue ? src.ParentKeyFiscalYear.From : src.From))
				.ForMember(m => m.To, opt => opt.MapFrom(src => src.ParentKeyFiscalYearId.HasValue ? src.ParentKeyFiscalYear.To : src.To));

				config.CreateMap<FiscalYearLightViewModel, FiscalYear>();
				#endregion



				#region UserMenuItem, UserMenuItemViewModel
				config.CreateMap<UserMenuItem, UserMenuItemViewModel>();
				config.CreateMap<UserMenuItemViewModel, UserMenuItem>();
				#endregion

				#region UserMenuItem, UserMenuItemLightViewModel
				config.CreateMap<UserMenuItem, UserMenuItemLightViewModel>();
				config.CreateMap<UserMenuItemLightViewModel, UserMenuItem>();
				#endregion


				#region MenuItem, MenuItemViewModel
				config.CreateMap<MenuItem, MenuItemViewModel>()
				.ForMember(x => x.Id, opt => opt.MapFrom(src => (src.ParentKeyMenuItemId.HasValue ? src.ParentKeyMenuItemId : src.Id)))
				.ForMember(x => x.Code, opt => opt.MapFrom(src => src.ParentKeyMenuItem != null ? src.ParentKeyMenuItem.Code : src.Code))
				.ForMember(x => x.IsActive, opt => opt.MapFrom(src => src.ParentKeyMenuItem != null ? src.ParentKeyMenuItem.IsActive : src.IsActive))
				.ForMember(x => x.ResourceKey, opt => opt.MapFrom(src => src.ParentKeyMenuItem != null ? src.ParentKeyMenuItem.ResourceKey : src.ResourceKey))

				.ForMember(x => x.AreaName, opt => opt.MapFrom(src => src.ParentKeyMenuItem != null ? src.ParentKeyMenuItem.AreaName : src.AreaName))
				.ForMember(x => x.ActionName, opt => opt.MapFrom(src => src.ParentKeyMenuItem != null ? src.ParentKeyMenuItem.ActionName : src.ActionName))
				.ForMember(x => x.ControllerName, opt => opt.MapFrom(src => src.ParentKeyMenuItem != null ? src.ParentKeyMenuItem.ControllerName : src.ControllerName))
				.ForMember(x => x.URL, opt => opt.MapFrom(src => src.ParentKeyMenuItem != null ? src.ParentKeyMenuItem.URL : src.URL))
				.ForMember(x => x.RootUrl, opt => opt.MapFrom(src => src.ParentKeyMenuItem != null ? src.ParentKeyMenuItem.RootUrl : src.RootUrl))
				.ForMember(x => x.OnErrorGoToURL, opt => opt.MapFrom(src => src.ParentKeyMenuItem != null ? src.ParentKeyMenuItem.OnErrorGoToURL : src.OnErrorGoToURL))
				.ForMember(x => x.ApplicationId, opt => opt.MapFrom(src => src.ParentKeyMenuItem != null ? src.ParentKeyMenuItem.ApplicationId : src.ApplicationId))
				.ForMember(x => x.Icon, opt => opt.MapFrom(src => src.ParentKeyMenuItem != null ? src.ParentKeyMenuItem.Icon : src.Icon))
				.ForMember(x => x.ItemOrder, opt => opt.MapFrom(src => src.ParentKeyMenuItem != null ? src.ParentKeyMenuItem.ItemOrder : src.ItemOrder))
				.ForMember(x => x.AllowAnonymous, opt => opt.MapFrom(src => src.ParentKeyMenuItem != null ? src.ParentKeyMenuItem.AllowAnonymous : src.AllowAnonymous))
				.ForMember(x => x.ParentMenuItemId, opt => opt.MapFrom(src => src.ParentKeyMenuItem != null ? src.ParentKeyMenuItem.ParentMenuItemId : src.ParentMenuItemId))
				.ForMember(x => x.ChildMenuItems, opt => opt.MapFrom(src => src.ParentKeyMenuItem != null ? src.ParentKeyMenuItem.ChildMenuItems : src.ChildMenuItems))

				//.ForMember(x => x.Date, opt => opt.MapFrom(src => src.ParentKeyMenuItemId.HasValue ? src.ParentKeyMenuItem.Date : src.Date))
				.ForMember(x => x.NameAr, z => z.MapFrom(o => o.ParentKeyMenuItem != null ? o.ParentKeyMenuItem.ChildTranslatedMenuItems.FirstOrDefault(item => item.Language == Language.Arabic).Name : o.ChildTranslatedMenuItems.FirstOrDefault(item => item.Language == Language.Arabic).Name))
				.ForMember(x => x.NameEn, z => z.MapFrom(o => o.ParentKeyMenuItem != null ? o.ParentKeyMenuItem.ChildTranslatedMenuItems.FirstOrDefault(item => item.Language == Language.English).Name : o.ChildTranslatedMenuItems.FirstOrDefault(item => item.Language == Language.English).Name))
				.ForMember(x => x.DescriptionAr, z => z.MapFrom(o => o.ParentKeyMenuItem != null ? o.ParentKeyMenuItem.ChildTranslatedMenuItems.FirstOrDefault(item => item.Language == Language.Arabic).Description : o.ChildTranslatedMenuItems.FirstOrDefault(item => item.Language == Language.Arabic).Description))
				.ForMember(x => x.DescriptionEn, z => z.MapFrom(o => o.ParentKeyMenuItem != null ? o.ParentKeyMenuItem.ChildTranslatedMenuItems.FirstOrDefault(item => item.Language == Language.English).Description : o.ChildTranslatedMenuItems.FirstOrDefault(item => item.Language == Language.English).Description))
				.ForMember(x => x.TitleAr, z => z.MapFrom(o => o.ParentKeyMenuItem != null ? o.ParentKeyMenuItem.ChildTranslatedMenuItems.FirstOrDefault(item => item.Language == Language.Arabic).Title : o.ChildTranslatedMenuItems.FirstOrDefault(item => item.Language == Language.Arabic).Title))
				.ForMember(x => x.TitleEn, z => z.MapFrom(o => o.ParentKeyMenuItem != null ? o.ParentKeyMenuItem.ChildTranslatedMenuItems.FirstOrDefault(item => item.Language == Language.English).Title : o.ChildTranslatedMenuItems.FirstOrDefault(item => item.Language == Language.English).Title))
				;
				config.CreateMap<MenuItemViewModel, MenuItem>();
				#endregion

				#region MenuItem, MenuItemLightViewModel
				config.CreateMap<MenuItem, MenuItemLightViewModel>()
				.ForMember(x => x.Id, opt => opt.MapFrom(src => (src.ParentKeyMenuItemId.HasValue ? src.ParentKeyMenuItemId : src.Id)))
				.ForMember(x => x.Code, opt => opt.MapFrom(src => src.ParentKeyMenuItemId.HasValue ? src.ParentKeyMenuItem.Code : src.Code))
				.ForMember(x => x.IsActive, opt => opt.MapFrom(src => src.ParentKeyMenuItemId.HasValue ? src.ParentKeyMenuItem.IsActive : src.IsActive))
				.ForMember(x => x.ResourceKey, opt => opt.MapFrom(src => src.ParentKeyMenuItemId.HasValue ? src.ParentKeyMenuItem.ResourceKey : src.ResourceKey))
				.ForMember(x => x.DisplyedName, z => z.MapFrom(o => $"{o.ParentKeyMenuItem.Code} - {o.Name}"))

				.ForMember(x => x.AreaName, opt => opt.MapFrom(src => src.ParentKeyMenuItemId.HasValue ? src.ParentKeyMenuItem.AreaName : src.AreaName))
				.ForMember(x => x.ActionName, opt => opt.MapFrom(src => src.ParentKeyMenuItemId.HasValue ? src.ParentKeyMenuItem.ActionName : src.ActionName))
				.ForMember(x => x.ControllerName, opt => opt.MapFrom(src => src.ParentKeyMenuItemId.HasValue ? src.ParentKeyMenuItem.ControllerName : src.ControllerName))
				.ForMember(x => x.URL, opt => opt.MapFrom(src => src.ParentKeyMenuItemId.HasValue ? src.ParentKeyMenuItem.URL : src.URL))
				.ForMember(x => x.RootUrl, opt => opt.MapFrom(src => src.ParentKeyMenuItemId.HasValue ? src.ParentKeyMenuItem.RootUrl : src.RootUrl))
				.ForMember(x => x.OnErrorGoToURL, opt => opt.MapFrom(src => src.ParentKeyMenuItemId.HasValue ? src.ParentKeyMenuItem.OnErrorGoToURL : src.OnErrorGoToURL))
				.ForMember(x => x.ApplicationId, opt => opt.MapFrom(src => src.ParentKeyMenuItemId.HasValue ? src.ParentKeyMenuItem.ApplicationId : src.ApplicationId))
				.ForMember(x => x.Icon, opt => opt.MapFrom(src => src.ParentKeyMenuItemId.HasValue ? src.ParentKeyMenuItem.Icon : src.Icon))
				.ForMember(x => x.ItemOrder, opt => opt.MapFrom(src => src.ParentKeyMenuItemId.HasValue ? src.ParentKeyMenuItem.ItemOrder : src.ItemOrder))
				.ForMember(x => x.AllowAnonymous, opt => opt.MapFrom(src => src.ParentKeyMenuItemId.HasValue ? src.ParentKeyMenuItem.AllowAnonymous : src.AllowAnonymous))
				.ForMember(x => x.ParentMenuItemId, opt => opt.MapFrom(src => src.ParentKeyMenuItemId.HasValue ? src.ParentKeyMenuItem.ParentMenuItemId : src.ParentMenuItemId))

				.ForMember(mem => mem.Value, opt => opt.MapFrom(x => x.ParentKeyMenuItem.Id))

				//.ForMember(x => x.Date, opt => opt.MapFrom(src => src.ParentKeyMenuItemId.HasValue ? src.ParentKeyMenuItem.Date : src.Date))
				//.ForMember(x => x.NameAr, z => z.MapFrom(o => o.ParentKeyMenuItem != null ? o.ParentKeyMenuItem.ChildTranslatedMenuItems.FirstOrDefault(item => item.Language == Language.Arabic).Name : o.ChildTranslatedMenuItems.FirstOrDefault(item => item.Language == Language.Arabic).Name))
				//.ForMember(x => x.NameEn, z => z.MapFrom(o => o.ParentKeyMenuItem != null ? o.ParentKeyMenuItem.ChildTranslatedMenuItems.FirstOrDefault(item => item.Language == Language.English).Name : o.ChildTranslatedMenuItems.FirstOrDefault(item => item.Language == Language.English).Name))
				//.ForMember(x => x.DescriptionAr, z => z.MapFrom(o => o.ParentKeyMenuItem != null ? o.ParentKeyMenuItem.ChildTranslatedMenuItems.FirstOrDefault(item => item.Language == Language.Arabic).Description : o.ChildTranslatedMenuItems.FirstOrDefault(item => item.Language == Language.Arabic).Description))
				//.ForMember(x => x.DescriptionEn, z => z.MapFrom(o => o.ParentKeyMenuItem != null ? o.ParentKeyMenuItem.ChildTranslatedMenuItems.FirstOrDefault(item => item.Language == Language.English).Description : o.ChildTranslatedMenuItems.FirstOrDefault(item => item.Language == Language.English).Description))
				//.ForMember(x => x.TitleAr, z => z.MapFrom(o => o.ParentKeyMenuItem != null ? o.ParentKeyMenuItem.ChildTranslatedMenuItems.FirstOrDefault(item => item.Language == Language.Arabic).Title : o.ChildTranslatedMenuItems.FirstOrDefault(item => item.Language == Language.Arabic).Title))
				//.ForMember(x => x.TitleEn, z => z.MapFrom(o => o.ParentKeyMenuItem != null ? o.ParentKeyMenuItem.ChildTranslatedMenuItems.FirstOrDefault(item => item.Language == Language.English).Title : o.ChildTranslatedMenuItems.FirstOrDefault(item => item.Language == Language.English).Title))
				;
				config.CreateMap<MenuItemLightViewModel, MenuItem>();
				#endregion

				#region MenuItem, SidebarMenuItemLightViewModel
				config.CreateMap<MenuItem, SidebarMenuItemLightViewModel>()
				.ForMember(x => x.Id, opt => opt.MapFrom(src => (src.ParentKeyMenuItemId.HasValue ? src.ParentKeyMenuItemId : src.Id)))
				.ForMember(x => x.Code, opt => opt.MapFrom(src => src.ParentKeyMenuItem != null ? src.ParentKeyMenuItem.Code : src.Code))
				.ForMember(x => x.IsActive, opt => opt.MapFrom(src => src.ParentKeyMenuItem != null ? src.ParentKeyMenuItem.IsActive : src.IsActive))
				.ForMember(x => x.ResourceKey, opt => opt.MapFrom(src => src.ParentKeyMenuItem != null ? src.ParentKeyMenuItem.ResourceKey : src.ResourceKey))

				.ForMember(x => x.AreaName, opt => opt.MapFrom(src => src.ParentKeyMenuItem != null ? src.ParentKeyMenuItem.AreaName : src.AreaName))
				.ForMember(x => x.ActionName, opt => opt.MapFrom(src => src.ParentKeyMenuItem != null ? src.ParentKeyMenuItem.ActionName : src.ActionName))
				.ForMember(x => x.ControllerName, opt => opt.MapFrom(src => src.ParentKeyMenuItem != null ? src.ParentKeyMenuItem.ControllerName : src.ControllerName))
				.ForMember(x => x.URL, opt => opt.MapFrom(src => src.ParentKeyMenuItem != null ? src.ParentKeyMenuItem.URL : src.URL))
				.ForMember(x => x.RootUrl, opt => opt.MapFrom(src => src.ParentKeyMenuItem != null ? src.ParentKeyMenuItem.RootUrl : src.RootUrl))
				.ForMember(x => x.OnErrorGoToURL, opt => opt.MapFrom(src => src.ParentKeyMenuItem != null ? src.ParentKeyMenuItem.OnErrorGoToURL : src.OnErrorGoToURL))
				.ForMember(x => x.ApplicationId, opt => opt.MapFrom(src => src.ParentKeyMenuItem != null ? src.ParentKeyMenuItem.ApplicationId : src.ApplicationId))
				.ForMember(x => x.Icon, opt => opt.MapFrom(src => src.ParentKeyMenuItem != null ? src.ParentKeyMenuItem.Icon : src.Icon))
				.ForMember(x => x.ItemOrder, opt => opt.MapFrom(src => src.ParentKeyMenuItem != null ? src.ParentKeyMenuItem.ItemOrder : src.ItemOrder))
				.ForMember(x => x.AllowAnonymous, opt => opt.MapFrom(src => src.ParentKeyMenuItem != null ? src.ParentKeyMenuItem.AllowAnonymous : src.AllowAnonymous))
				.ForMember(x => x.ParentMenuItemId, opt => opt.MapFrom(src => src.ParentKeyMenuItem != null ? src.ParentKeyMenuItem.ParentMenuItemId : src.ParentMenuItemId))
                //.ForMember(x => x.ChildMenuItems, opt => opt.MapFrom(src => src.ParentKeyMenuItem != null ? src.ParentKeyMenuItem.ChildMenuItems : src.ChildMenuItems))
                .ForMember(x => x.ChildMenuItems, opt => opt.MapFrom(src => new List<SidebarMenuItemLightViewModel>()))

                //.ForMember(x => x.Date, opt => opt.MapFrom(src => src.ParentKeyMenuItemId.HasValue ? src.ParentKeyMenuItem.Date : src.Date))
                .ForMember(x => x.NameAr, z => z.MapFrom(o => o.ParentKeyMenuItem != null ? o.ParentKeyMenuItem.ChildTranslatedMenuItems.FirstOrDefault(item => item.Language == Language.Arabic).Name : o.ChildTranslatedMenuItems.FirstOrDefault(item => item.Language == Language.Arabic).Name))
				.ForMember(x => x.NameEn, z => z.MapFrom(o => o.ParentKeyMenuItem != null ? o.ParentKeyMenuItem.ChildTranslatedMenuItems.FirstOrDefault(item => item.Language == Language.English).Name : o.ChildTranslatedMenuItems.FirstOrDefault(item => item.Language == Language.English).Name))
				.ForMember(x => x.DescriptionAr, z => z.MapFrom(o => o.ParentKeyMenuItem != null ? o.ParentKeyMenuItem.ChildTranslatedMenuItems.FirstOrDefault(item => item.Language == Language.Arabic).Description : o.ChildTranslatedMenuItems.FirstOrDefault(item => item.Language == Language.Arabic).Description))
				.ForMember(x => x.DescriptionEn, z => z.MapFrom(o => o.ParentKeyMenuItem != null ? o.ParentKeyMenuItem.ChildTranslatedMenuItems.FirstOrDefault(item => item.Language == Language.English).Description : o.ChildTranslatedMenuItems.FirstOrDefault(item => item.Language == Language.English).Description))
				.ForMember(x => x.TitleAr, z => z.MapFrom(o => o.ParentKeyMenuItem != null ? o.ParentKeyMenuItem.ChildTranslatedMenuItems.FirstOrDefault(item => item.Language == Language.Arabic).Title : o.ChildTranslatedMenuItems.FirstOrDefault(item => item.Language == Language.Arabic).Title))
				.ForMember(x => x.TitleEn, z => z.MapFrom(o => o.ParentKeyMenuItem != null ? o.ParentKeyMenuItem.ChildTranslatedMenuItems.FirstOrDefault(item => item.Language == Language.English).Title : o.ChildTranslatedMenuItems.FirstOrDefault(item => item.Language == Language.English).Title))
				;
				config.CreateMap<SidebarMenuItemLightViewModel, MenuItem>();
				#endregion


				#region Location, LocationViewModel
				config.CreateMap<Location, LocationViewModel>()
				.ForMember(x => x.Id, opt => opt.MapFrom(src => src.ParentKeyLocationId.HasValue ? src.ParentKeyLocationId : src.Id))
				.ForMember(x => x.Code, opt => opt.MapFrom(src => src.ParentKeyLocation != null ? src.ParentKeyLocation.Code : src.Code))
				.ForMember(x => x.Description, opt => opt.MapFrom(src => src.Description))
				.ForMember(x => x.Date, opt => opt.MapFrom(src => src.ParentKeyLocation != null ? src.ParentKeyLocation.Date : src.Date))
				.ForMember(x => x.TitleAr, z => z.MapFrom(o => o.ParentKeyLocation != null ? o.ParentKeyLocation.ChildTranslatedLocations.FirstOrDefault(item => item.Language == Language.Arabic).Title : o.ChildTranslatedLocations.FirstOrDefault(item => item.Language == Language.Arabic).Title))
				.ForMember(x => x.TitleEn, z => z.MapFrom(o => o.ParentKeyLocation != null ? o.ParentKeyLocation.ChildTranslatedLocations.FirstOrDefault(item => item.Language == Language.English).Title : o.ChildTranslatedLocations.FirstOrDefault(item => item.Language == Language.English).Title))
				.ForMember(x => x.DescriptionAr, z => z.MapFrom(o => o.ParentKeyLocation != null ? o.ParentKeyLocation.ChildTranslatedLocations.FirstOrDefault(item => item.Language == Language.Arabic).Description : o.ChildTranslatedLocations.FirstOrDefault(item => item.Language == Language.Arabic).Description))
				.ForMember(x => x.DescriptionEn, z => z.MapFrom(o => o.ParentKeyLocation != null ? o.ParentKeyLocation.ChildTranslatedLocations.FirstOrDefault(item => item.Language == Language.English).Description : o.ChildTranslatedLocations.FirstOrDefault(item => item.Language == Language.English).Description))
				;

				config.CreateMap<LocationViewModel, Location>()
                ;
				#endregion

				#region Location, LocationLightViewModel
				config.CreateMap<Location, LocationLightViewModel>()
				.ForMember(x => x.Id, opt => opt.MapFrom(src => ((src.ParentKeyLocationId != null)?src.ParentKeyLocationId: src.Id)))
				.ForMember(x => x.Code, opt => opt.MapFrom(src => ((src.ParentKeyLocationId != null) ? src.ParentKeyLocation.Code : src.Code)))
				.ForMember(x => x.Date, opt => opt.MapFrom(src => ((src.ParentKeyLocationId != null) ? src.ParentKeyLocation.Date : src.Date)))
				.ForMember(x => x.Title, opt => opt.MapFrom(src => ((src.ParentKeyLocationId != null) ? src.ParentKeyLocation.Title : src.Title)))
				.ForMember(x => x.Description, opt => opt.MapFrom(src => ((src.ParentKeyLocationId != null) ? src.ParentKeyLocation.Description : src.Description)))
				.ForMember(x => x.DisplyedName, opt => opt.MapFrom(src => $"{((src.ParentKeyLocationId != null)?src.ParentKeyLocation.Code : src.Code)} - {((src.ParentKeyLocationId != null)?src.Title: src.ParentKeyLocation.Title)}"))
                .ForMember(x => x.ChildLocations, opt => opt.MapFrom(src => src.ParentKeyLocation.ChildLocations))
				;
				config.CreateMap<LocationLightViewModel, Location>();
				#endregion


				#region DepreciationRate, DepreciationRateViewModel
				config.CreateMap<DepreciationRate, DepreciationRateViewModel>()
				.ForMember(x => x.Id, opt => opt.MapFrom(src => src.ParentKeyDepreciationRateId.HasValue ? src.ParentKeyDepreciationRateId : src.Id))
				.ForMember(x => x.Code, opt => opt.MapFrom(src => src.ParentKeyDepreciationRateId.HasValue ? src.ParentKeyDepreciationRate.Code : src.Code))
				.ForMember(x => x.Description, opt => opt.MapFrom(src => src.ParentKeyDepreciationRateId.HasValue ? src.ParentKeyDepreciationRate.Description : src.Description))
				.ForMember(x => x.DepreciationRateCode, opt => opt.MapFrom(src => src.ParentKeyDepreciationRateId.HasValue ? src.ParentKeyDepreciationRate.DepreciationRateCode : src.DepreciationRateCode))
				//.ForMember(x => x.Date, opt => opt.MapFrom(src => src.ParentKeyDepreciationRateId.HasValue ? src.ParentKeyDepreciationRate.Date : src.Date))
				.ForMember(x => x.NameAr, z => z.MapFrom(o => o.ParentKeyDepreciationRate != null ? o.ParentKeyDepreciationRate.ChildTranslatedDepreciationRates.FirstOrDefault(item => item.Language == Language.Arabic).Name : o.ChildTranslatedDepreciationRates.FirstOrDefault(item => item.Language == Language.Arabic).Name))
				.ForMember(x => x.NameEn, z => z.MapFrom(o => o.ParentKeyDepreciationRate != null ? o.ParentKeyDepreciationRate.ChildTranslatedDepreciationRates.FirstOrDefault(item => item.Language == Language.English).Name : o.ChildTranslatedDepreciationRates.FirstOrDefault(item => item.Language == Language.English).Name))
				.ForMember(x => x.DescriptionAr, z => z.MapFrom(o => o.ParentKeyDepreciationRate != null ? o.ParentKeyDepreciationRate.ChildTranslatedDepreciationRates.FirstOrDefault(item => item.Language == Language.Arabic).Description : o.ChildTranslatedDepreciationRates.FirstOrDefault(item => item.Language == Language.Arabic).Description))
				.ForMember(x => x.DescriptionEn, z => z.MapFrom(o => o.ParentKeyDepreciationRate != null ? o.ParentKeyDepreciationRate.ChildTranslatedDepreciationRates.FirstOrDefault(item => item.Language == Language.English).Description : o.ChildTranslatedDepreciationRates.FirstOrDefault(item => item.Language == Language.English).Description))
				;

				config.CreateMap<DepreciationRateViewModel, DepreciationRate>();
				#endregion

				#region DepreciationRate, DepreciationRateLightViewModel
				config.CreateMap<DepreciationRate, DepreciationRateLightViewModel>()
				.ForMember(x => x.Id, opt => opt.MapFrom(src => src.ParentKeyDepreciationRateId.HasValue ? src.ParentKeyDepreciationRateId : src.Id))
				.ForMember(x => x.Code, opt => opt.MapFrom(src => src.ParentKeyDepreciationRateId.HasValue ? src.ParentKeyDepreciationRate.Code : src.Code))
				.ForMember(x => x.DepreciationRateCode, opt => opt.MapFrom(src => src.ParentKeyDepreciationRateId.HasValue ? src.ParentKeyDepreciationRate.DepreciationRateCode : src.DepreciationRateCode))
				.ForMember(x => x.DisplyedName, opt => opt.MapFrom(src => $"{src.ParentKeyDepreciationRate.Code} - {src.Name}"))
				;
				config.CreateMap<DepreciationRateLightViewModel, DepreciationRate>();
				#endregion


				#region DepreciationType, DepreciationTypeViewModel
				config.CreateMap<DepreciationType, DepreciationTypeViewModel>()
				.ForMember(x => x.Id, opt => opt.MapFrom(src => src.ParentKeyDepreciationTypeId.HasValue ? src.ParentKeyDepreciationTypeId : src.Id))
				.ForMember(x => x.Code, opt => opt.MapFrom(src => src.ParentKeyDepreciationTypeId.HasValue ? src.ParentKeyDepreciationType.Code : src.Code))
				.ForMember(x => x.Description, opt => opt.MapFrom(src => src.ParentKeyDepreciationTypeId.HasValue ? src.ParentKeyDepreciationType.Description : src.Description))
				.ForMember(x => x.DepreciationTypeCode, opt => opt.MapFrom(src => src.ParentKeyDepreciationTypeId.HasValue ? src.ParentKeyDepreciationType.DepreciationTypeCode : src.DepreciationTypeCode))
				//.ForMember(x => x.Date, opt => opt.MapFrom(src => src.ParentKeyDepreciationTypeId.HasValue ? src.ParentKeyDepreciationType.Date : src.Date))
				.ForMember(x => x.NameAr, z => z.MapFrom(o => o.ParentKeyDepreciationType != null ? o.ParentKeyDepreciationType.ChildTranslatedDepreciationTypes.FirstOrDefault(item => item.Language == Language.Arabic).Name : o.ChildTranslatedDepreciationTypes.FirstOrDefault(item => item.Language == Language.Arabic).Name))
				.ForMember(x => x.NameEn, z => z.MapFrom(o => o.ParentKeyDepreciationType != null ? o.ParentKeyDepreciationType.ChildTranslatedDepreciationTypes.FirstOrDefault(item => item.Language == Language.English).Name : o.ChildTranslatedDepreciationTypes.FirstOrDefault(item => item.Language == Language.English).Name))
				.ForMember(x => x.DescriptionAr, z => z.MapFrom(o => o.ParentKeyDepreciationType != null ? o.ParentKeyDepreciationType.ChildTranslatedDepreciationTypes.FirstOrDefault(item => item.Language == Language.Arabic).Description : o.ChildTranslatedDepreciationTypes.FirstOrDefault(item => item.Language == Language.Arabic).Description))
				.ForMember(x => x.DescriptionEn, z => z.MapFrom(o => o.ParentKeyDepreciationType != null ? o.ParentKeyDepreciationType.ChildTranslatedDepreciationTypes.FirstOrDefault(item => item.Language == Language.English).Description : o.ChildTranslatedDepreciationTypes.FirstOrDefault(item => item.Language == Language.English).Description))
				;

				config.CreateMap<DepreciationTypeViewModel, DepreciationType>();
				#endregion

				#region DepreciationType, DepreciationTypeLightViewModel
				config.CreateMap<DepreciationType, DepreciationTypeLightViewModel>()
				.ForMember(x => x.Id, opt => opt.MapFrom(src => src.ParentKeyDepreciationTypeId.HasValue ? src.ParentKeyDepreciationTypeId : src.Id))
				.ForMember(x => x.Code, opt => opt.MapFrom(src => src.ParentKeyDepreciationTypeId.HasValue ? src.ParentKeyDepreciationType.Code : src.Code))
				.ForMember(x => x.DepreciationTypeCode, opt => opt.MapFrom(src => src.ParentKeyDepreciationTypeId.HasValue ? src.ParentKeyDepreciationType.DepreciationTypeCode : src.DepreciationTypeCode))
				.ForMember(x => x.DisplyedName, opt => opt.MapFrom(src => $"{src.ParentKeyDepreciationType.Code} - {src.Name}"))
				;
				config.CreateMap<DepreciationTypeLightViewModel, DepreciationType>();
				#endregion


				#region ExpensesType, ExpensesTypeViewModel
				config.CreateMap<ExpensesType, ExpensesTypeViewModel>()
				.ForMember(x => x.Id, opt => opt.MapFrom(src => src.ParentKeyExpensesTypeId.HasValue ? src.ParentKeyExpensesTypeId : src.Id))
				.ForMember(x => x.Code, opt => opt.MapFrom(src => src.ParentKeyExpensesTypeId.HasValue ? src.ParentKeyExpensesType.Code : src.Code))
				.ForMember(x => x.NameAr, z => z.MapFrom(o => o.ParentKeyExpensesType != null ? o.ParentKeyExpensesType.ChildTranslatedExpensesTypes.FirstOrDefault(item => item.Language == Language.Arabic).Name : o.ChildTranslatedExpensesTypes.FirstOrDefault(item => item.Language == Language.Arabic).Name))
				.ForMember(x => x.NameEn, z => z.MapFrom(o => o.ParentKeyExpensesType != null ? o.ParentKeyExpensesType.ChildTranslatedExpensesTypes.FirstOrDefault(item => item.Language == Language.English).Name : o.ChildTranslatedExpensesTypes.FirstOrDefault(item => item.Language == Language.English).Name))
				.ForMember(x => x.DescriptionAr, z => z.MapFrom(o => o.ParentKeyExpensesType != null ? o.ParentKeyExpensesType.ChildTranslatedExpensesTypes.FirstOrDefault(item => item.Language == Language.Arabic).Description : o.ChildTranslatedExpensesTypes.FirstOrDefault(item => item.Language == Language.Arabic).Description))
				.ForMember(x => x.DescriptionEn, z => z.MapFrom(o => o.ParentKeyExpensesType != null ? o.ParentKeyExpensesType.ChildTranslatedExpensesTypes.FirstOrDefault(item => item.Language == Language.English).Description : o.ChildTranslatedExpensesTypes.FirstOrDefault(item => item.Language == Language.English).Description))
				;

				config.CreateMap<ExpensesTypeViewModel, ExpensesType>();
				#endregion

				#region ExpensesType, ExpensesTypeLightViewModel
				config.CreateMap<ExpensesType, ExpensesTypeLightViewModel>()
				.ForMember(x => x.Id, opt => opt.MapFrom(src => src.ParentKeyExpensesTypeId.HasValue ? src.ParentKeyExpensesTypeId : src.Id))
				.ForMember(x => x.Code, opt => opt.MapFrom(src => src.ParentKeyExpensesTypeId.HasValue ? src.ParentKeyExpensesType.Code : src.Code))
				.ForMember(x => x.DisplyedName, opt => opt.MapFrom(src => $"{src.ParentKeyExpensesType.Code} - {src.Name}"))
				;
				config.CreateMap<ExpensesTypeLightViewModel, ExpensesType>();
                #endregion


                #region AssetInventory, AssetInventoryViewModel
                config.CreateMap<AssetInventory, AssetInventoryViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(src => (src.ParentKeyAssetInventoryId.HasValue ? src.ParentKeyAssetInventoryId : src.Id)))
                .ForMember(x => x.Date, opt => opt.MapFrom(src => src.ParentKeyAssetInventory != null? src.ParentKeyAssetInventory.Date : src.Date))
                .ForMember(x => x.Description, opt => opt.MapFrom(src => src.ParentKeyAssetInventory != null ? src.ParentKeyAssetInventory.Description : src.Description))
                .ForMember(x => x.LocationId, opt => opt.MapFrom(src => src.ParentKeyAssetInventory != null ? src.ParentKeyAssetInventory.LocationId : src.LocationId))
                .ForMember(x => x.DescriptionAr, z => z.MapFrom(o => o.ParentKeyAssetInventory != null ? o.ParentKeyAssetInventory.ChildTranslatedAssetInventorys.FirstOrDefault(item => item.Language == Language.Arabic).Description : o.ChildTranslatedAssetInventorys.FirstOrDefault(item => item.Language == Language.Arabic).Description))
                .ForMember(x => x.DescriptionEn, z => z.MapFrom(o => o.ParentKeyAssetInventory != null ? o.ParentKeyAssetInventory.ChildTranslatedAssetInventorys.FirstOrDefault(item => item.Language == Language.English).Description : o.ChildTranslatedAssetInventorys.FirstOrDefault(item => item.Language == Language.English).Description))
                ;
                config.CreateMap<AssetInventoryViewModel, AssetInventory>();
                #endregion

                #region AssetInventory, AssetInventoryLightViewModel
                config.CreateMap<AssetInventory, AssetInventoryLightViewModel>()
                .ForMember(mem => mem.Id, opt => opt.MapFrom(x => x.ParentKeyAssetInventory.Id))
                .ForMember(mem => mem.Date, opt => opt.MapFrom(x => x.ParentKeyAssetInventory.Date))
                .ForMember(mem => mem.LocationId, opt => opt.MapFrom(x => x.ParentKeyAssetInventory.LocationId))
                ;
                config.CreateMap<AssetInventoryLightViewModel, AssetInventory>();
                #endregion



                #region AssetInventoryDetail, AssetInventoryDetailViewModel
                config.CreateMap<AssetInventoryDetail, AssetInventoryDetailViewModel>()
                //.ForMember(x => x.Id, opt => opt.MapFrom(src => (src.ParentKeyRoleId.HasValue ? src.ParentKeyRoleId : src.Id)))
                //.ForMember(x => x.Code, opt => opt.MapFrom(src => src.ParentKeyRoleId.HasValue ? src.ParentKeyRole.Code : src.Code))
                //.ForMember(x => x.Description, opt => opt.MapFrom(src => src.ParentKeyRoleId.HasValue ? src.ParentKeyRole.Description : src.Description))
                //.ForMember(x => x.IsActive, opt => opt.MapFrom(src => src.ParentKeyRoleId.HasValue ? src.ParentKeyRole.IsActive : src.IsActive))
                //.ForMember(x => x.Date, opt => opt.MapFrom(src => src.ParentKeyRoleId.HasValue ? src.ParentKeyRole.Date : src.Date))
                //.ForMember(x => x.NameAr, z => z.MapFrom(o => o.ParentKeyRole != null ? o.ParentKeyRole.ChildTranslatedRoles.FirstOrDefault(item => item.Language == Language.Arabic).Name : o.ChildTranslatedRoles.FirstOrDefault(item => item.Language == Language.Arabic).Name))
                //.ForMember(x => x.NameEn, z => z.MapFrom(o => o.ParentKeyRole != null ? o.ParentKeyRole.ChildTranslatedRoles.FirstOrDefault(item => item.Language == Language.English).Name : o.ChildTranslatedRoles.FirstOrDefault(item => item.Language == Language.English).Name))
                //.ForMember(x => x.DescriptionAr, z => z.MapFrom(o => o.ParentKeyRole != null ? o.ParentKeyRole.ChildTranslatedRoles.FirstOrDefault(item => item.Language == Language.Arabic).Description : o.ChildTranslatedRoles.FirstOrDefault(item => item.Language == Language.Arabic).Description))
                //.ForMember(x => x.DescriptionEn, z => z.MapFrom(o => o.ParentKeyRole != null ? o.ParentKeyRole.ChildTranslatedRoles.FirstOrDefault(item => item.Language == Language.English).Description : o.ChildTranslatedRoles.FirstOrDefault(item => item.Language == Language.English).Description)
                ;
                config.CreateMap<AssetInventoryDetailViewModel, AssetInventoryDetail>();
                #endregion

                #region AssetInventoryDetail, AssetInventoryDetailLightViewModel
                config.CreateMap<AssetInventoryDetail, AssetInventoryDetailLightViewModel>()
                //.ForMember(mem => mem.Id, opt => opt.MapFrom(x => x.ParentKeyRole.Id))
                //.ForMember(mem => mem.Value, opt => opt.MapFrom(x => x.ParentKeyRole.Id))
                //.ForMember(mem => mem.Code, opt => opt.MapFrom(x => x.ParentKeyRole.Code))
                ;
                config.CreateMap<AssetInventoryDetailLightViewModel, AssetInventoryDetail>();
                #endregion




                #region Donation, ChecksUnderCollectionViewModel
                config.CreateMap<Donation, ChecksUnderCollectionViewModel>();
				//.ForMember(x => x.Id, opt => opt.MapFrom(src => src.ParentKeyDonationId))
				//.ForMember(m => m.Code, opt => opt.MapFrom(src => src.ParentKeyDonation.Code));
				config.CreateMap<ChecksUnderCollectionViewModel, Donation>();
				#endregion


				#region Bank, ListBankLightViewModel
				config.CreateMap<Bank, ListBankLightViewModel>()
				.ForMember(x => x.Id, z => z.MapFrom(o => o.ParentKeyBankId))
				.ForMember(x => x.Code, z => z.MapFrom(o => o.ParentKeyBank.Code))
				.ForMember(x => x.OpeningCredit, z => z.MapFrom(o => o.ParentKeyBank.OpeningCredit))
				.ForMember(x => x.Name, z => z.MapFrom(o => o.Name))
				.ForMember(x => x.Description, z => z.MapFrom(o => o.Description))
				//.ForMember(x => x.AccountChartId, z => z.MapFrom(o => o.ParentKeyBankMovement.AccountChartId))               
				//.ForMember(x => x.CreatedByUserId, z => z.MapFrom(o => o.ParentKeyBankMovement.CreatedByUserId))
				//.ForMember(x => x.CreationDate, z => z.MapFrom(o => o.ParentKeyBankMovement.CreationDate))
				.ForMember(x => x.Date, z => z.MapFrom(o => o.ParentKeyBank.Date))
				//.ForMember(x => x.FirstModificationDate, z => z.MapFrom(o => o.ParentKeyBankMovement.FirstModificationDate))
				//.ForMember(x => x.FirstModifiedByUserId, z => z.MapFrom(o => o.ParentKeyBankMovement.FirstModifiedByUserId))
				//.ForMember(x => x.LastModificationDate, z => z.MapFrom(o => o.ParentKeyBankMovement.LastModificationDate))
				//.ForMember(x => x.LastModifiedByUserId, z => z.MapFrom(o => o.ParentKeyBankMovement.LastModifiedByUserId))
				//.ForMember(x => x.SafeId, z => z.MapFrom(o => o.ParentKeyBankMovement.SafeId))
				//.ForMember(x => x.ToBankId, z => z.MapFrom(o => o.ParentKeyBankMovement.ToBankId));
				;
				config.CreateMap<ListBankLightViewModel, Bank>();
				#endregion

				#region Vendor, ListVendorsLightViewModel
				config.CreateMap<Vendor, ListVendorsLightViewModel>()
				.ForMember(x => x.Id, z => z.MapFrom(o => o.ParentKeyVendorId))
				.ForMember(x => x.Code, z => z.MapFrom(o => o.ParentKeyVendor.Code))
				//.ForMember(x => x.AccountChartId, z => z.MapFrom(o => o.ParentKeyBankMovement.AccountChartId))
				.ForMember(x => x.OpeningCredit, z => z.MapFrom(o => o.ParentKeyVendor.OpeningCredit))
				.ForMember(x => x.Name, z => z.MapFrom(o => o.Name))
				//.ForMember(x => x.CreatedByUserId, z => z.MapFrom(o => o.ParentKeyBankMovement.CreatedByUserId))
				//.ForMember(x => x.CreationDate, z => z.MapFrom(o => o.ParentKeyBankMovement.CreationDate))
				.ForMember(x => x.Date, z => z.MapFrom(o => o.ParentKeyVendor.Date))
				//.ForMember(x => x., z => z.MapFrom(o => o.ParentKeyBankMovement.JournalTypeId));
				//.ForMember(x => x.FirstModificationDate, z => z.MapFrom(o => o.ParentKeyBankMovement.FirstModificationDate))
				//.ForMember(x => x.FirstModifiedByUserId, z => z.MapFrom(o => o.ParentKeyBankMovement.FirstModifiedByUserId))
				//.ForMember(x => x.LastModificationDate, z => z.MapFrom(o => o.ParentKeyBankMovement.LastModificationDate))
				//.ForMember(x => x.LastModifiedByUserId, z => z.MapFrom(o => o.ParentKeyBankMovement.LastModifiedByUserId))
				//.ForMember(x => x.SafeId, z => z.MapFrom(o => o.ParentKeyBankMovement.SafeId))
				//.ForMember(x => x.ToBankId, z => z.MapFrom(o => o.ParentKeyBankMovement.ToBankId));
				;
				config.CreateMap<ListVendorsLightViewModel, Vendor>();
				#endregion

				#region CurrencyRate, ListCurrencyRateLightViewModel
				config.CreateMap<CurrencyRate, ListCurrencyRateLightViewModel>()
				////.ForMember(x => x.Id, z => z.MapFrom(o => o.ParentKeyCurrencyRateId.Value))

				////.ForMember(x => x.Price, z => z.MapFrom(o => o.ParentKeyCurrencyRate.Price))
				////.ForMember(x => x.Date, z => z.MapFrom(o => o.ParentKeyCurrencyRate.Date))
				////.ForMember(x => x.CurrencyId, z => z.MapFrom(o => o.ParentKeyCurrencyRate.CurrencyId))
				////.ForMember(x => x.ExchangeCurrencyId, z => z.MapFrom(o => o.ParentKeyCurrencyRate.ExchangeCurrencyId))

				//.ForMember(x => x.Currency, z => z.MapFrom(o => o.Currency.ChildTranslatedCurrencys.FirstOrDefault(x => x.Language == ).Name))

				//.ForMember(x => x.ExchangeCurrency, z => z.MapFrom(o => o.ExchangeCurrency.ChildTranslatedCurrencys.FirstOrDefault(x => x.Language == Language.Arabic).Name))

				;
				config.CreateMap<ListCurrencyRateLightViewModel, CurrencyRate>();
				#endregion

				#region Currency, ListCurrencyLightViewModel

				config.CreateMap<Currency, ListCurrencyLightViewModel>()
				.ForMember(x => x.Id, z => z.MapFrom(o => (o.ParentKeyCurrency != null
				) ? o.ParentKeyCurrencyId : o.Id))
				.ForMember(x => x.Code, z => z.MapFrom(o => (o.ParentKeyCurrency != null) ? o.ParentKeyCurrency.Code : o.Code))
				.ForMember(x => x.Symbol, z => z.MapFrom(o => (o.ParentKeyCurrency != null) ? o.ParentKeyCurrency.Symbol : o.Symbol))
				.ForMember(x => x.NameAr, z => z.MapFrom(o => o.ChildTranslatedCurrencys.FirstOrDefault(y => y.Language == Language.Arabic).Name))
				.ForMember(x => x.NameEn, z => z.MapFrom(o => o.ChildTranslatedCurrencys.FirstOrDefault(y => y.Language == Language.English).Name))
				.ForMember(x => x.DescriptionAr, z => z.MapFrom(o => o.ChildTranslatedCurrencys.FirstOrDefault(y => y.Language == Language.Arabic).Description))
				.ForMember(x => x.DescriptionEn, z => z.MapFrom(o => o.ChildTranslatedCurrencys.FirstOrDefault(y => y.Language == Language.English).Description))
                .ForMember(x => x.Price, z => z.MapFrom(o => o.CurrencyRates.OrderByDescending(x => x.Id).FirstOrDefault().Price))
                ;

				config.CreateMap<ListCurrencyLightViewModel, Currency>()
				;
				#endregion

				#region CostCenter, CostCenterLightViewModel
				config.CreateMap<CostCenter, ListCostCenterLightViewModel>()
				.ForMember(x => x.Id, z => z.MapFrom(o => o.ParentKeyCostCenterId))
				.ForMember(x => x.Code, z => z.MapFrom(o => o.ParentKeyCostCenter.Code))
				.ForMember(x => x.OpeningCredit, z => z.MapFrom(o => o.ParentKeyCostCenter.OpeningCredit))
				.ForMember(x => x.Name, z => z.MapFrom(o => o.Name))
				.ForMember(x => x.CostCenterTypeName, z => z.MapFrom(o => o.ParentKeyCostCenter.CostCenterType.ChildTranslatedCostCenterTypes.FirstOrDefault(l => l.Language == o.Language).Name))
				;
				config.CreateMap<ListCostCenterLightViewModel, CostCenter>();
				#endregion

				#region Branch, ListBranchsLightViewModel
				config.CreateMap<Branch, ListBranchsLightViewModel>()
				.ForMember(x => x.Id, z => z.MapFrom(o => o.ParentKeyBranchId))
				.ForMember(x => x.Code, z => z.MapFrom(o => o.ParentKeyBranch.Code))
				.ForMember(x => x.Date, z => z.MapFrom(o => o.ParentKeyBranch.Date))
				;
				config.CreateMap<ListBranchsLightViewModel, Branch>();
				#endregion

				#region Brand, ListBrandsLightViewModel
				config.CreateMap<Brand, ListBrandsLightViewModel>()
				.ForMember(x => x.Id, z => z.MapFrom(o => o.ParentKeyBrandId))
				.ForMember(x => x.Code, z => z.MapFrom(o => o.ParentKeyBrand.Code))
				.ForMember(x => x.Date, z => z.MapFrom(o => o.ParentKeyBrand.Date))
				;
				config.CreateMap<ListBrandsLightViewModel, Brand>();
				#endregion

				#region MeasurementUnit, ListMeasurementUnitsLightViewModel
				config.CreateMap<MeasurementUnit, ListMeasurementUnitsLightViewModel>()
				.ForMember(x => x.Id, z => z.MapFrom(o => o.ParentKeyMeasurementUnitId))
				.ForMember(x => x.Code, z => z.MapFrom(o => o.ParentKeyMeasurementUnit.Code))
				.ForMember(x => x.Date, z => z.MapFrom(o => o.ParentKeyMeasurementUnit.Date))
				;
				config.CreateMap<ListMeasurementUnitsLightViewModel, MeasurementUnit>();
				#endregion

				#region Safe, ListSafesLightViewModel
				config.CreateMap<Safe, ListSafesLightViewModel>()
				.ForMember(x => x.Id, z => z.MapFrom(o => o.ParentKeySafeId))
				.ForMember(x => x.Code, z => z.MapFrom(o => o.ParentKeySafe.Code))
				.ForMember(x => x.Date, z => z.MapFrom(o => o.ParentKeySafe.Date))
				.ForMember(x => x.OpeningCredit, z => z.MapFrom(o => o.ParentKeySafe.OpeningCredit))
				;
				config.CreateMap<ListSafesLightViewModel, Safe>();
				#endregion

				#region DelegateMan, ListDelegateMansLightViewModel
				config.CreateMap<DelegateMan, ListDelegateMensLightViewModel>()
				.ForMember(x => x.Id, z => z.MapFrom(o => o.ParentKeyDelegateManId))
				.ForMember(x => x.Code, z => z.MapFrom(o => o.ParentKeyDelegateMan.Code))
				.ForMember(x => x.Date, z => z.MapFrom(o => o.ParentKeyDelegateMan.Date))
				;
				config.CreateMap<ListDelegateMensLightViewModel, DelegateMan>();
				#endregion

				#region Permission, ListPermissionsLightViewModel
				config.CreateMap<Permission, ListPermissionsLightViewModel>()
				.ForMember(x => x.Id, z => z.MapFrom(o => o.ParentKeyPermissionId))
				.ForMember(x => x.Code, z => z.MapFrom(o => o.ParentKeyPermission.Code))
				.ForMember(x => x.IsActive, z => z.MapFrom(o => o.ParentKeyPermission.IsActive))
				;
				config.CreateMap<ListPermissionsLightViewModel, Permission>();
				#endregion

				#region Role, ListRolesLightViewModel
				config.CreateMap<Role, ListRolesLightViewModel>()
				.ForMember(x => x.Id, z => z.MapFrom(o => o.ParentKeyRoleId))
				.ForMember(x => x.Code, z => z.MapFrom(o => o.ParentKeyRole.Code))
				.ForMember(x => x.IsActive, z => z.MapFrom(o => o.ParentKeyRole.IsActive))
				.ForMember(x => x.Date, z => z.MapFrom(o => o.ParentKeyRole.Date))
				;
				config.CreateMap<ListRolesLightViewModel, Role>();
				#endregion

				#region Group, ListGroupsLightViewModel
				config.CreateMap<Group, ListGroupsLightViewModel>()
				.ForMember(x => x.Id, z => z.MapFrom(o => o.ParentKeyGroupId))
				.ForMember(x => x.Code, z => z.MapFrom(o => o.ParentKeyGroup.Code))
				.ForMember(x => x.Date, z => z.MapFrom(o => o.ParentKeyGroup.Date))
				.ForMember(x => x.IsActive, z => z.MapFrom(o => o.ParentKeyGroup.IsActive))
				;
				config.CreateMap<ListGroupsLightViewModel, Group>();
				#endregion

				#region DelegateMan, DelegateManViewModel
				config.CreateMap<DelegateMan, DelegateManViewModel>()
				.ForMember(x => x.Id, z => z.MapFrom(o => o.ParentKeyDelegateMan != null ? o.ParentKeyDelegateManId : o.Id))
				.ForMember(x => x.Code, z => z.MapFrom(o => o.ParentKeyDelegateMan != null ? o.ParentKeyDelegateMan.Code : o.Code))
				.ForMember(x => x.DisplyedName, z => z.MapFrom(o => $"{o.ParentKeyDelegateMan.Code} - {o.Name}"))
				.ForMember(x => x.NameAr, z => z.MapFrom(o => o.ParentKeyDelegateMan != null ? o.ParentKeyDelegateMan.ChildTranslatedDelegateMans.FirstOrDefault(item => item.Language == Language.Arabic).Name : o.ChildTranslatedDelegateMans.FirstOrDefault(item => item.Language == Language.Arabic).Name))
				.ForMember(x => x.NameEn, z => z.MapFrom(o => o.ParentKeyDelegateMan != null ? o.ParentKeyDelegateMan.ChildTranslatedDelegateMans.FirstOrDefault(item => item.Language == Language.English).Name : o.ChildTranslatedDelegateMans.FirstOrDefault(item => item.Language == Language.English).Name))
				.ForMember(x => x.DescriptionAr, z => z.MapFrom(o => o.ParentKeyDelegateMan != null ? o.ParentKeyDelegateMan.ChildTranslatedDelegateMans.FirstOrDefault(item => item.Language == Language.Arabic).Description : o.ChildTranslatedDelegateMans.FirstOrDefault(item => item.Language == Language.Arabic).Description))
				.ForMember(x => x.DescriptionEn, z => z.MapFrom(o => o.ParentKeyDelegateMan != null ? o.ParentKeyDelegateMan.ChildTranslatedDelegateMans.FirstOrDefault(item => item.Language == Language.English).Description : o.ChildTranslatedDelegateMans.FirstOrDefault(item => item.Language == Language.English).Description))
				;
				config.CreateMap<DelegateManViewModel, DelegateMan>()
				.ForMember(x => x.ChildTranslatedDelegateMans, opt => opt.Ignore())
				.ForMember(x => x.PaymentMovments, opt => opt.Ignore())
				;
				#endregion

				#region DelegateMan, DelegateManLightViewModel
				config.CreateMap<DelegateMan, DelegateManLightViewModel>();
				//.ForMember(m => m.Id, opt => opt.MapFrom(src => src.ParentKeyDelegateManId));
				config.CreateMap<DelegateManLightViewModel, DelegateMan>();
                #endregion

                #region MenuItem, ListMenuItemsLightViewModel
                _ = config.CreateMap<MenuItem, ListMenuItemsLightViewModel>()
                .ForMember(x => x.Id, z => z.MapFrom(o => o.ParentKeyMenuItemId))
                .ForMember(x => x.Code, z => z.MapFrom(o => o.ParentKeyMenuItem.Code))
                .ForMember(x => x.Url, z => z.MapFrom(o => o.ParentKeyMenuItem.URL))
                .ForMember(x => x.ItemOrder, z => z.MapFrom(o => o.ParentKeyMenuItem.ItemOrder))
                .ForMember(x => x.IsActive, z => z.MapFrom(o => o.ParentKeyMenuItem.IsActive))
                .ForMember(x => x.HasParent, z => z.MapFrom(o => o.ParentKeyMenuItem.ParentMenuItemId.HasValue))
                .ForMember(x => x.ParentMenuItemName, z => z.MapFrom(o => $"{o.ParentKeyMenuItem.ParentMenuItem.Code} - {o.ParentKeyMenuItem.ParentMenuItem.ChildTranslatedMenuItems.Where(e => e.Language == o.Language).FirstOrDefault().Name}"))
                ;
				config.CreateMap<ListMenuItemsLightViewModel, MenuItem>();
				#endregion

				#region User, ListUsersLightViewModel
				config.CreateMap<User, ListUsersLightViewModel>()
				.ForMember(x => x.Id, z => z.MapFrom(o => o.ParentKeyUserId))
				.ForMember(x => x.UserName, z => z.MapFrom(o => o.ParentKeyUser.UserName))
				.ForMember(x => x.IsActive, z => z.MapFrom(o => o.ParentKeyUser.IsActive))
				.ForMember(x => x.BirthDate, z => z.MapFrom(o => o.ParentKeyUser.BirthDate))
				.ForMember(x => x.MaxPaymentLimit, z => z.MapFrom(o => o.ParentKeyUser.MaxPaymentLimit))
				.ForMember(x => x.Gender, z => z.MapFrom(o => o.ParentKeyUser.Gender))
				;
				config.CreateMap<ListUsersLightViewModel, User>();
				#endregion



				#region Donator, ListDonatorLightViewModel
				config.CreateMap<Donator, ListDonatorLightViewModel>();
				config.CreateMap<ListDonatorLightViewModel, Donator>();
				#endregion

				#region Inventory, ListInventoryLightViewModel
				config.CreateMap<Inventory, ListInventoryLightViewModel>()
				.ForMember(x => x.Id, z => z.MapFrom(o => o.Id))
				.ForMember(x => x.Code, z => z.MapFrom(o => o.Code))
				.ForMember(x => x.NameAr, z => z.MapFrom(o => o.ChildTranslatedInventorys.FirstOrDefault(x => x.Language == Language.Arabic).Name))
				.ForMember(x => x.NameEn, z => z.MapFrom(o => o.ChildTranslatedInventorys.FirstOrDefault(x => x.Language == Language.English).Name))
				//.ForMember(x => x.Description, z => z.MapFrom(o => o.Description))
				//.ForMember(x => x.AccountChartId, z => z.MapFrom(o => o.ParentKeyBankMovement.AccountChartId))               
				//.ForMember(x => x.CreatedByUserId, z => z.MapFrom(o => o.ParentKeyBankMovement.CreatedByUserId))
				//.ForMember(x => x.CreationDate, z => z.MapFrom(o => o.ParentKeyBankMovement.CreationDate))
				.ForMember(x => x.Date, z => z.MapFrom(o => o.Date))
				//.ForMember(x => x.FirstModificationDate, z => z.MapFrom(o => o.ParentKeyBankMovement.FirstModificationDate))
				//.ForMember(x => x.FirstModifiedByUserId, z => z.MapFrom(o => o.ParentKeyBankMovement.FirstModifiedByUserId))
				//.ForMember(x => x.LastModificationDate, z => z.MapFrom(o => o.ParentKeyBankMovement.LastModificationDate))
				//.ForMember(x => x.LastModifiedByUserId, z => z.MapFrom(o => o.ParentKeyBankMovement.LastModifiedByUserId))
				//.ForMember(x => x.SafeId, z => z.MapFrom(o => o.ParentKeyBankMovement.SafeId))
				//.ForMember(x => x.ToBankId, z => z.MapFrom(o => o.ParentKeyBankMovement.ToBankId));
				;
				config.CreateMap<ListInventoryLightViewModel, Inventory>();
				#endregion

				#region Asset, ListAssetLightViewModel
				config.CreateMap<Asset, ListAssetLightViewModel>()
				.ForMember(x => x.Id, z => z.MapFrom(o => o.ParentKeyAssetId))
				.ForMember(x => x.AccountChartName, z => z.MapFrom(o => o.ParentKeyAsset.AccountChart.ChildTranslatedAccountCharts.FirstOrDefault(ch => ch.Language == o.Language).Name))
				.ForMember(x => x.BrandName, z => z.MapFrom(o => o.ParentKeyAsset.Brand.ChildTranslatedBrands.FirstOrDefault(ch => ch.Language == o.Language).Name))
				.ForMember(x => x.LocationName, z => z.MapFrom(o => o.ParentKeyAsset.AssetLocations.OrderByDescending(x => x.Id).FirstOrDefault().Location.ChildTranslatedLocations.FirstOrDefault(x => x.Language == o.Language).Title))
				.ForMember(x => x.DepreciationRateName, z => z.MapFrom(o => o.ParentKeyAsset.DepreciationRate.ChildTranslatedDepreciationRates.FirstOrDefault(ch => ch.Language == o.Language).Name))
				.ForMember(x => x.DepreciationTypeName, z => z.MapFrom(o => o.ParentKeyAsset.DepreciationType.ChildTranslatedDepreciationTypes.FirstOrDefault(ch => ch.Language == o.Language).Name))
				.ForMember(x => x.DepreciationValue, z => z.MapFrom(o => o.ParentKeyAsset.DepreciationValue))
				.ForMember(x => x.PurchaseInvoiceCode, z => z.MapFrom(o => o.ParentKeyAsset.PurchaseInvoice.Id))
				.ForMember(x => x.Amount, z => z.MapFrom(o => o.ParentKeyAsset.Amount))
				.ForMember(x => x.Date, z => z.MapFrom(o => o.ParentKeyAsset.PurchaseDate))
				.ForMember(x => x.CurrentValue, z => z.MapFrom(o => o.ParentKeyAsset.CurrentValue))
				;
				config.CreateMap<ListAssetLightViewModel, Asset>();
				#endregion

				#region Expense, ListExpenseLightViewModel
				config.CreateMap<Expense, ListExpenseLightViewModel>()
				.ForMember(x => x.Id, z => z.MapFrom(o => o.ParentKeyExpenseId))
				.ForMember(x => x.AccountChartName, z => z.MapFrom(o => o.ParentKeyExpense.AccountChart.ChildTranslatedAccountCharts.FirstOrDefault(ch => ch.Language == o.Language).Name))
				.ForMember(x => x.Amount, z => z.MapFrom(o => o.ParentKeyExpense.Amount))
				.ForMember(x => x.Code, z => z.MapFrom(o => o.ParentKeyExpense.Code))
				.ForMember(x => x.Date, z => z.MapFrom(o => o.ParentKeyExpense.Date))
				.ForMember(x => x.ExpensesTypeName, z => z.MapFrom(o => o.ParentKeyExpense.ExpensesType.ChildTranslatedExpensesTypes.FirstOrDefault(ch => ch.Language == o.Language).Name))
				;
				config.CreateMap<ListExpenseLightViewModel, Expense>();
				#endregion

				#region Depreciation, ListDepreciationViewModel
				config.CreateMap<Depreciation, ListDepreciationViewModel>()
				;
				config.CreateMap<ListDepreciationViewModel, Depreciation>();
				#endregion

                #region Depreciation, DepreciationLightViewModel
                config.CreateMap<Depreciation, DepreciationLightViewModel>()
                ;
                config.CreateMap<DepreciationLightViewModel, Depreciation>()
                ;
                #endregion

                #region Exclude, ExcludeViewModel
                config.CreateMap<Exclude, ExcludeViewModel>()
                ;
                config.CreateMap<ExcludeViewModel, Exclude>();
                #endregion

                #region Exclude, ListExcludeViewModel
                config.CreateMap<Exclude, ListExcludeLightViewModel>()
                ;
                config.CreateMap<ListExcludeLightViewModel, Exclude>();
                #endregion

                #region Excludes, ExcludeLightViewModel
                config.CreateMap<Exclude, ExcludeLightViewModel>()
                ;
                config.CreateMap<ExcludeLightViewModel, Exclude>()
                ;
                #endregion

                #region Asset, ListExcludeLightViewModel
                config.CreateMap<Asset, ListExcludeLightViewModel>()
                .ForMember(x => x.Id, z => z.MapFrom(o => o.ParentKeyAssetId))
                .ForMember(x => x.AccountChartName, z => z.MapFrom(o => o.ParentKeyAsset.AccountChart.ChildTranslatedAccountCharts.FirstOrDefault(ch => ch.Language == o.Language).Name))
                .ForMember(x => x.BrandCode, z => z.MapFrom(o => o.ParentKeyAsset.Brand.Code))
                .ForMember(x => x.BrandName, z => z.MapFrom(o => o.ParentKeyAsset.Brand.ChildTranslatedBrands.FirstOrDefault(ch => ch.Language == o.Language).Name))
                .ForMember(x => x.DepreciationValue, z => z.MapFrom(o => o.ParentKeyAsset.DepreciationValue))
                .ForMember(x => x.CurrentValue, z => z.MapFrom(o => o.ParentKeyAsset.CurrentValue))
                ;
                config.CreateMap<ExcludeLightViewModel, Asset>()
                ;
                #endregion

                #region AssetInventory, ListAssetInventorysLightViewModel
                config.CreateMap<AssetInventory, ListAssetInventorysLightViewModel>()
                .ForMember(x => x.Id, z => z.MapFrom(o => o.ParentKeyAssetInventoryId))
                .ForMember(x => x.LocationName, z => z.MapFrom(o => o.ParentKeyAssetInventory.Location.ChildTranslatedLocations.FirstOrDefault(x => x.Language == o.Language).Title))
                .ForMember(x => x.Date, z => z.MapFrom(o => o.ParentKeyAssetInventory.Date))
                ;
                config.CreateMap<ListAssetInventorysLightViewModel, AssetInventory>();
                #endregion

                #region Asset, AssetInventoryDetail
                config.CreateMap<Asset, AssetInventoryDetailLightViewModel>()
                //.ForMember(x => x, z => z.MapFrom(o => o.ParentKeyAssetId))
                .ForMember(x => x.BrandId, z => z.MapFrom(o => o.BrandId))
                .ForMember(x => x.ExpectedQuantity, z => z.MapFrom(o => o.Quantity))
                .ForMember(x => x.ActualQuantity, z => z.MapFrom(o => o.Quantity))
                ;
                config.CreateMap<AssetInventoryDetailLightViewModel, Asset>();
                #endregion

                #region Location, ListLocationsLightViewModel
                config.CreateMap<Location, ListLocationsLightViewModel>()
                .ForMember(x => x.Id, z => z.MapFrom(o => o.ParentKeyLocationId))
                .ForMember(x => x.Code, z => z.MapFrom(o => o.ParentKeyLocation.Code))
                .ForMember(x => x.Date, z => z.MapFrom(o => o.ParentKeyLocation.Date))
				.ForMember(x => x.Title, z => z.MapFrom(o => o.Title))
				;
				config.CreateMap<ListLocationsLightViewModel, Location>();
                #endregion

                #region ExpensesTypes, ListExpensesTypesLightViewModel
                config.CreateMap<ExpensesType, ListExpensesTypesLightViewModel>()
                .ForMember(x => x.Id, z => z.MapFrom(o => o.ParentKeyExpensesTypeId))
                .ForMember(x => x.Code, z => z.MapFrom(o => o.ParentKeyExpensesType.Code))
                .ForMember(x => x.Name, z => z.MapFrom(o => o.Name))
                ;

                config.CreateMap<ListExpensesTypesLightViewModel, ExpensesType>();
				#endregion

				#region BankAccountChart, BankAccountChartViewModel
				config.CreateMap<BankAccountChart, BankAccountChartViewModel>()
				;
				config.CreateMap<BankAccountChartViewModel, BankAccountChart>();
				#endregion

				#region BankAccountChart, BankAccountChartLightViewModel
				config.CreateMap<BankAccountChart, BankAccountChartLightViewModel>()
				;
				config.CreateMap<BankAccountChartLightViewModel, BankAccountChart>();
				#endregion

				#region Document, DocumentViewModel
				config.CreateMap<Document, DocumentViewModel>();
                config.CreateMap<DocumentViewModel, Document>();
                #endregion

                #region Document, ListDocumentLightViewModel
                config.CreateMap<Document, ListDocumentsLightViewModel>()
                ;
                config.CreateMap<ListDocumentsLightViewModel, Document>();
                #endregion

                #region Document, DocumentLightViewModel
                config.CreateMap<Document, DocumentLightViewModel>()
                ;
                config.CreateMap<DocumentLightViewModel, Document>();
                #endregion

                #region AccountDocument, AccountDocumentViewModel
                config.CreateMap<AccountChartDocument, AccountChartDocumentViewModel>()
                .ForMember(x => x.AccountChartId, z => z.MapFrom(o => o.AccountChartId))
                .ForMember(x => x.DocumentId, z => z.MapFrom(o => o.DocumentId))

                .ForMember(x => x.CreationDate, z => z.Ignore())
                .ForMember(x => x.FirstModificationDate, z => z.Ignore())
                .ForMember(x => x.LastModificationDate, z => z.Ignore())
                ;
                config.CreateMap<AccountChartDocumentViewModel, AccountChartDocument>();
                #endregion

                #region AccountDocument, ListAccountDocumentLightViewModel
                config.CreateMap<AccountChartDocument, ListAccountChartDocumentLightViewModel>()
                ;
                config.CreateMap<ListAccountChartDocumentLightViewModel, AccountChartDocument>();
                #endregion


                #region DiscountPercentage, DiscountPercentageViewModel
                config.CreateMap<DiscountPercentage, DiscountPercentageViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(src => (src.ParentKeyDiscountPercentageId.HasValue ? src.ParentKeyDiscountPercentageId.Value : src.Id)))
				.ForMember(x => x.Name, opt => opt.MapFrom(src => src.ChildTranslatedDiscountPercentages.FirstOrDefault(v => v.Language == Language.Arabic).Name))
				.ForMember(x => x.DescriptionAr, opt => opt.MapFrom(src => src.ChildTranslatedDiscountPercentages.FirstOrDefault(v => v.Language == Language.Arabic).Description))
				.ForMember(x => x.DescriptionEn, opt => opt.MapFrom(src => src.ChildTranslatedDiscountPercentages.FirstOrDefault(v => v.Language == Language.English).Description))
				;
                config.CreateMap<DiscountPercentageViewModel, DiscountPercentage>();
                #endregion

                #region DiscountPercentage, DiscountPercentageLightViewModel
                config.CreateMap<DiscountPercentage, DiscountPercentageLightViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(src => (src.ParentKeyDiscountPercentageId.HasValue ? src.ParentKeyDiscountPercentageId.Value : src.Id)))
				.ForMember(x => x.Percentage, opt => opt.MapFrom(src => (src.ParentKeyDiscountPercentageId.HasValue ? src.ParentKeyDiscountPercentage.Percentage : src.Percentage)))
				;
				config.CreateMap<DiscountPercentageLightViewModel, DiscountPercentage>();
                #endregion


                #region CostCenterType, CostCenterTypeViewModel
                config.CreateMap<CostCenterType, CostCenterTypeViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.ParentKeyCostCenterTypeId.HasValue ? src.ParentKeyCostCenterTypeId : src.Id))
                .ForMember(x => x.Code, opt => opt.MapFrom(src => src.ParentKeyCostCenterTypeId.HasValue ? src.ParentKeyCostCenterType.Code : src.Code))
                .ForMember(x => x.NameAr, z => z.MapFrom(o => o.ParentKeyCostCenterType != null ? o.ParentKeyCostCenterType.ChildTranslatedCostCenterTypes.FirstOrDefault(item => item.Language == Language.Arabic).Name : o.ChildTranslatedCostCenterTypes.FirstOrDefault(item => item.Language == Language.Arabic).Name))
                .ForMember(x => x.NameEn, z => z.MapFrom(o => o.ParentKeyCostCenterType != null ? o.ParentKeyCostCenterType.ChildTranslatedCostCenterTypes.FirstOrDefault(item => item.Language == Language.English).Name : o.ChildTranslatedCostCenterTypes.FirstOrDefault(item => item.Language == Language.English).Name))
                .ForMember(x => x.DescriptionAr, z => z.MapFrom(o => o.ParentKeyCostCenterType != null ? o.ParentKeyCostCenterType.ChildTranslatedCostCenterTypes.FirstOrDefault(item => item.Language == Language.Arabic).Description : o.ChildTranslatedCostCenterTypes.FirstOrDefault(item => item.Language == Language.Arabic).Description))
                .ForMember(x => x.DescriptionEn, z => z.MapFrom(o => o.ParentKeyCostCenterType != null ? o.ParentKeyCostCenterType.ChildTranslatedCostCenterTypes.FirstOrDefault(item => item.Language == Language.English).Description : o.ChildTranslatedCostCenterTypes.FirstOrDefault(item => item.Language == Language.English).Description))
                ;

                config.CreateMap<CostCenterTypeViewModel, CostCenterType>();
                #endregion

                #region CostCenterType, CostCenterTypeLightViewModel
                config.CreateMap<CostCenterType, CostCenterTypeLightViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.ParentKeyCostCenterTypeId.HasValue ? src.ParentKeyCostCenterTypeId : src.Id))
                .ForMember(x => x.Code, opt => opt.MapFrom(src => src.ParentKeyCostCenterTypeId.HasValue ? src.ParentKeyCostCenterType.Code : src.Code))
                .ForMember(x => x.DisplyedName, opt => opt.MapFrom(src => $"{src.ParentKeyCostCenterType.Code} - {src.Name}"))
                ;
                config.CreateMap<CostCenterTypeLightViewModel, CostCenterType>();
                #endregion


                #region CostCenterTypes, ListCostCenterTypesLightViewModel
                config.CreateMap<CostCenterType, ListCostCenterTypesLightViewModel>()
                .ForMember(x => x.Id, z => z.MapFrom(o => o.ParentKeyCostCenterTypeId))
                .ForMember(x => x.Code, z => z.MapFrom(o => o.ParentKeyCostCenterType.Code))
                .ForMember(x => x.Name, z => z.MapFrom(o => o.Name))
                ;

                config.CreateMap<ListCostCenterTypesLightViewModel, CostCenterType>();
                #endregion

                #region CostCenterType, CostCenterTypeViewModel
                config.CreateMap<ObjectCostCenter, ObjectCostCenterViewModel>();

                config.CreateMap<ObjectCostCenterViewModel, ObjectCostCenter>();
                #endregion

                #region ObjectCostCenter, ObjectCostCenter
                config.CreateMap<ObjectCostCenter, ListObjectCostCenterLightViewModel>()
                ;

                config.CreateMap<ListObjectCostCenterLightViewModel, ObjectCostCenter>();
                #endregion


                #region ClosedMonth, ClosedMonthViewModel
                config.CreateMap<ClosedMonth, ClosedMonthViewModel>()
                .ForMember(m => m.Id, opt => opt.MapFrom(src => src.ParentKeyClosedMonthId.HasValue ? src.ParentKeyClosedMonthId.Value : src.Id))
                .ForMember(m => m.From, opt => opt.MapFrom(src => src.ParentKeyClosedMonthId.HasValue ? src.ParentKeyClosedMonth.From : src.From))
                .ForMember(m => m.To, opt => opt.MapFrom(src => src.ParentKeyClosedMonthId.HasValue ? src.ParentKeyClosedMonth.To : src.To))
                .ForMember(m => m.IsClosed, opt => opt.MapFrom(src => src.ParentKeyClosedMonthId.HasValue ? src.ParentKeyClosedMonth.IsClosed : src.IsClosed))
                .ForMember(m => m.ClosedByUserId, opt => opt.MapFrom(src => src.ParentKeyClosedMonthId.HasValue ? src.ParentKeyClosedMonth.ClosedByUserId : src.ClosedByUserId))
                .ForMember(m => m.Month, opt => opt.MapFrom(src => src.ParentKeyClosedMonthId.HasValue ? src.ParentKeyClosedMonth.Month : src.Month))
                .ForMember(x => x.NameAr, z => z.MapFrom(o => o.ParentKeyClosedMonth != null ? o.ParentKeyClosedMonth.ChildTranslatedClosedMonths.FirstOrDefault(item => item.Language == Language.Arabic).Name : o.ChildTranslatedClosedMonths.FirstOrDefault(item => item.Language == Language.Arabic).Name))
                .ForMember(x => x.NameEn, z => z.MapFrom(o => o.ParentKeyClosedMonth != null ? o.ParentKeyClosedMonth.ChildTranslatedClosedMonths.FirstOrDefault(item => item.Language == Language.English).Name : o.ChildTranslatedClosedMonths.FirstOrDefault(item => item.Language == Language.English).Name))
                .ForMember(x => x.DescriptionAr, z => z.MapFrom(o => o.ParentKeyClosedMonth != null ? o.ParentKeyClosedMonth.ChildTranslatedClosedMonths.FirstOrDefault(item => item.Language == Language.Arabic).Description : o.ChildTranslatedClosedMonths.FirstOrDefault(item => item.Language == Language.Arabic).Description))
                .ForMember(x => x.DescriptionEn, z => z.MapFrom(o => o.ParentKeyClosedMonth != null ? o.ParentKeyClosedMonth.ChildTranslatedClosedMonths.FirstOrDefault(item => item.Language == Language.English).Description : o.ChildTranslatedClosedMonths.FirstOrDefault(item => item.Language == Language.English).Description))
                ;

                config.CreateMap<ClosedMonthViewModel, ClosedMonth>();
                #endregion

                #region ClosedMonth, ClosedMonthLightViewModel
                config.CreateMap<ClosedMonth, ClosedMonthLightViewModel>()
                .ForMember(m => m.Id, opt => opt.MapFrom(src => src.ParentKeyClosedMonthId.HasValue ? src.ParentKeyClosedMonthId.Value : src.Id))
                .ForMember(m => m.From, opt => opt.MapFrom(src => src.ParentKeyClosedMonthId.HasValue ? src.ParentKeyClosedMonth.From : src.From))
                .ForMember(m => m.To, opt => opt.MapFrom(src => src.ParentKeyClosedMonthId.HasValue ? src.ParentKeyClosedMonth.To : src.To))
                .ForMember(m => m.IsClosed, opt => opt.MapFrom(src => src.ParentKeyClosedMonthId.HasValue ? src.ParentKeyClosedMonth.IsClosed : src.IsClosed))
                .ForMember(m => m.ClosedByUserId, opt => opt.MapFrom(src => src.ParentKeyClosedMonthId.HasValue ? src.ParentKeyClosedMonth.ClosedByUserId : src.ClosedByUserId))
                .ForMember(m => m.Month, opt => opt.MapFrom(src => src.ParentKeyClosedMonthId.HasValue ? src.ParentKeyClosedMonth.Month : src.Month))
                ;

                config.CreateMap<ClosedMonthLightViewModel, ClosedMonth>();
                #endregion

                #region ClosedMonth, ListClosedMonthsLightViewModel
                config.CreateMap<ClosedMonth, ListClosedMonthsLightViewModel>()
                .ForMember(x => x.Id, z => z.MapFrom(o => o.ParentKeyClosedMonthId))
                .ForMember(x => x.From, z => z.MapFrom(o => o.ParentKeyClosedMonth.From))
                .ForMember(x => x.To, z => z.MapFrom(o => o.ParentKeyClosedMonth.To))
                .ForMember(x => x.IsClosed, z => z.MapFrom(o => o.ParentKeyClosedMonth.IsClosed))
                .ForMember(x => x.ClosedByUserId, z => z.MapFrom(o => o.ParentKeyClosedMonth.ClosedByUserId))
                .ForMember(x => x.Month, z => z.MapFrom(o => o.ParentKeyClosedMonth.Month))
                ;

                config.CreateMap<ListClosedMonthsLightViewModel, ClosedMonth>();
                #endregion



                #region AssetLocation, AssetLocationViewModel
                config.CreateMap<AssetLocation, AssetLocationViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.ParentKeyAssetLocationId.HasValue ? src.ParentKeyAssetLocationId : src.Id))
                .ForMember(x => x.AssetId, opt => opt.MapFrom(src => src.ParentKeyAssetLocationId.HasValue ? src.ParentKeyAssetLocation.AssetId : src.AssetId))
                .ForMember(x => x.LocationId, opt => opt.MapFrom(src => src.ParentKeyAssetLocationId.HasValue ? src.ParentKeyAssetLocation.LocationId : src.LocationId))
                .ForMember(x => x.Date, opt => opt.MapFrom(src => src.ParentKeyAssetLocationId.HasValue ? src.ParentKeyAssetLocation.Date : src.Date))
                //.ForMember(x => x.NameAr, z => z.MapFrom(o => o.ParentKeyAssetLocation != null ? o.ParentKeyAssetLocation.ChildTranslatedAssetLocations.FirstOrDefault(item => item.Language == Language.Arabic).Name : o.ChildTranslatedAssetLocations.FirstOrDefault(item => item.Language == Language.Arabic).Name))
                //.ForMember(x => x.NameEn, z => z.MapFrom(o => o.ParentKeyAssetLocation != null ? o.ParentKeyAssetLocation.ChildTranslatedAssetLocations.FirstOrDefault(item => item.Language == Language.English).Name : o.ChildTranslatedAssetLocations.FirstOrDefault(item => item.Language == Language.English).Name))
                .ForMember(x => x.DescriptionAr, z => z.MapFrom(o => o.ParentKeyAssetLocation != null ? o.ParentKeyAssetLocation.ChildTranslatedAssetLocations.FirstOrDefault(item => item.Language == Language.Arabic).Description : o.ChildTranslatedAssetLocations.FirstOrDefault(item => item.Language == Language.Arabic).Description))
                .ForMember(x => x.DescriptionEn, z => z.MapFrom(o => o.ParentKeyAssetLocation != null ? o.ParentKeyAssetLocation.ChildTranslatedAssetLocations.FirstOrDefault(item => item.Language == Language.English).Description : o.ChildTranslatedAssetLocations.FirstOrDefault(item => item.Language == Language.English).Description))
                ;

                config.CreateMap<AssetLocationViewModel, AssetLocation>();
                #endregion

                #region AssetLocation, AssetLocationLightViewModel
                config.CreateMap<AssetLocation, AssetLocationLightViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.ParentKeyAssetLocationId.HasValue ? src.ParentKeyAssetLocationId : src.Id))
                .ForMember(x => x.AssetId, opt => opt.MapFrom(src => src.ParentKeyAssetLocationId.HasValue ? src.ParentKeyAssetLocation.AssetId : src.AssetId))
                .ForMember(x => x.LocationId, opt => opt.MapFrom(src => src.ParentKeyAssetLocationId.HasValue ? src.ParentKeyAssetLocation.LocationId : src.LocationId))
                //.ForMember(x => x.DisplyedName, opt => opt.MapFrom(src => $"{src.ParentKeyAssetLocation.Code} - {src.Name}"))
                ;
                config.CreateMap<AssetLocationLightViewModel, AssetLocation>();
                #endregion


                #region AssetLocations, ListAssetLocationsLightViewModel
                config.CreateMap<AssetLocation, ListAssetLocationsLightViewModel>()
                .ForMember(x => x.Id, z => z.MapFrom(o => o.ParentKeyAssetLocationId))
                .ForMember(x => x.AssetId, opt => opt.MapFrom(src => src.ParentKeyAssetLocationId.HasValue ? src.ParentKeyAssetLocation.AssetId : src.AssetId))
                .ForMember(x => x.LocationId, opt => opt.MapFrom(src => src.ParentKeyAssetLocationId.HasValue ? src.ParentKeyAssetLocation.LocationId : src.LocationId))
                //.ForMember(x => x.AssetId, z => z.MapFrom(o => o.ParentKeyAssetLocation.AssetId))
                //.ForMember(x => x.Asset, z => z.MapFrom(o => o.ParentKeyAssetLocation.Asset.Brand.Code))
                //.ForMember(x => x.LocationId, z => z.MapFrom(o => o.ParentKeyAssetLocation.LocationId))
                //.ForMember(x => x.Location, z => z.MapFrom(o => o.ParentKeyAssetLocation.Location.Code))
                .ForMember(x => x.Asset, opt => opt.MapFrom(src => src.ParentKeyAssetLocationId.HasValue ? $"{src.ParentKeyAssetLocation.AssetId} {src.ParentKeyAssetLocation.Asset.Brand.ChildTranslatedBrands.FirstOrDefault(item => item.Language == src.Language).Name}" : $"{src.AssetId} {src.Asset.Brand.ChildTranslatedBrands.FirstOrDefault().Name}"))
                .ForMember(x => x.Location, opt => opt.MapFrom(src => src.ParentKeyAssetLocationId.HasValue ? $"{src.ParentKeyAssetLocation.LocationId} - {src.ParentKeyAssetLocation.Location.ChildTranslatedLocations.FirstOrDefault(item => item.Language == src.Language).Title}" : $"{src.LocationId} {src.Location.ChildTranslatedLocations.FirstOrDefault().Title}"))

                .ForMember(x => x.Date, z => z.MapFrom(o => o.ParentKeyAssetLocation.Date))              
                ;

                config.CreateMap<ListAssetLocationsLightViewModel, AssetLocation>();
                #endregion

                #region AssetLocation, AssetLocationViewModel
                config.CreateMap<ClosedReceipt, ClosedReceiptViewModel>()
                
                ;

                config.CreateMap<ClosedReceiptViewModel, ClosedReceipt>();
                #endregion

                #region UserBranch, UserBranchViewModel
                config.CreateMap<UserBranch, UserBranchViewModel>();
                config.CreateMap<UserBranchViewModel, UserBranch>();
                #endregion

                #region UserBranch, UserBranchLightViewModel
                config.CreateMap<UserBranch, UserBranchLightViewModel>();
                config.CreateMap<UserBranchLightViewModel, UserBranch>();
                #endregion

                #region SafeAccountChart, SafeAccountChartViewModel
                config.CreateMap<SafeAccountChart, SafeAccountChartViewModel>();
                config.CreateMap<SafeAccountChartViewModel, SafeAccountChart>();
                #endregion

                #region SafeAccountChart, SafeAccountChartLightViewModel
                config.CreateMap<SafeAccountChart, SafeAccountChartLightViewModel>();
                config.CreateMap<SafeAccountChartLightViewModel, SafeAccountChart>();
				#endregion

				#region DiscountPercentage, ListDiscountPercentegesLightViewModel
				config.CreateMap<DiscountPercentage, ListDiscountPercentegesLightViewModel>()
				.ForMember(x => x.Id, z => z.MapFrom(o => o.ParentKeyDiscountPercentageId))
				.ForMember(x => x.Percentage, z => z.MapFrom(o => o.ParentKeyDiscountPercentage.Percentage))
				.ForMember(x => x.Name, z => z.MapFrom(o => o.Name))
				//.ForMember(x => x.CreatedByUserId, z => z.MapFrom(o => o.ParentKeyBankMovement.CreatedByUserId))
				//.ForMember(x => x.CreationDate, z => z.MapFrom(o => o.ParentKeyBankMovement.CreationDate))
				//.ForMember(x => x., z => z.MapFrom(o => o.ParentKeyBankMovement.JournalTypeId));
				//.ForMember(x => x.FirstModificationDate, z => z.MapFrom(o => o.ParentKeyBankMovement.FirstModificationDate))
				//.ForMember(x => x.FirstModifiedByUserId, z => z.MapFrom(o => o.ParentKeyBankMovement.FirstModifiedByUserId))
				//.ForMember(x => x.LastModificationDate, z => z.MapFrom(o => o.ParentKeyBankMovement.LastModificationDate))
				//.ForMember(x => x.LastModifiedByUserId, z => z.MapFrom(o => o.ParentKeyBankMovement.LastModifiedByUserId))
				//.ForMember(x => x.SafeId, z => z.MapFrom(o => o.ParentKeyBankMovement.SafeId))
				//.ForMember(x => x.ToBankId, z => z.MapFrom(o => o.ParentKeyBankMovement.ToBankId));
				;
				config.CreateMap<ListDiscountPercentegesLightViewModel, DiscountPercentage>();
				#endregion

				#region Testament, TestamentViewModel
				config.CreateMap<Testament, TestamentViewModel>()
				.ForMember(x => x.DescriptionAr, z => z.MapFrom(o => o.ChildTranslatedCustodies.FirstOrDefault(y => y.Language == Language.Arabic).Description))
				.ForMember(x => x.DescriptionEn, z => z.MapFrom(o => o.ChildTranslatedCustodies.FirstOrDefault(y => y.Language == Language.English).Description))
				;
				config.CreateMap<TestamentViewModel, Testament>()
                .ForMember(x => x.Advances, z => z.Ignore())
                ;
				#endregion

				#region Testament, TestamentLightViewModel
				config.CreateMap<Testament, TestamentLightViewModel>()
				.ForMember(x => x.Id, z => z.MapFrom(o => o.Id))
				;
				config.CreateMap<TestamentLightViewModel, Testament>();
				#endregion

				#region Testament, ListTestamentLightViewModel
				config.CreateMap<Testament, ListTestamentLightViewModel>()
				.ForMember(x => x.Id, z => z.MapFrom(o => o.ParentKeyTestamentId.Value))
                .ForMember(x => x.Code, z => z.MapFrom(o => o.ParentKeyTestament.Code))
                .ForMember(x => x.AdvancesTypeName, z => z.MapFrom(o => o.ParentKeyTestament.AdvancesType.ChildTranslatedAdvancesTypes.FirstOrDefault(c => c.Language == o.Language).Name))
                .ForMember(x => x.Date, z => z.MapFrom(o => o.ParentKeyTestament.Date))
                .ForMember(x => x.TotalValue, z => z.MapFrom(o => o.ParentKeyTestament.TotalValue))
				.ForMember(x => x.Description, z => z.MapFrom(o => o.Description))

				////.ForMember(x => x.Price, z => z.MapFrom(o => o.ParentKeyCurrencyRate.Price))
				////.ForMember(x => x.Date, z => z.MapFrom(o => o.ParentKeyCurrencyRate.Date))
				////.ForMember(x => x.CurrencyId, z => z.MapFrom(o => o.ParentKeyCurrencyRate.CurrencyId))
				////.ForMember(x => x.ExchangeCurrencyId, z => z.MapFrom(o => o.ParentKeyCurrencyRate.ExchangeCurrencyId))

				//.ForMember(x => x.Currency, z => z.MapFrom(o => o.Currency.ChildTranslatedCurrencys.FirstOrDefault(x => x.Language == ).Name))

				//.ForMember(x => x.ExchangeCurrency, z => z.MapFrom(o => o.ExchangeCurrency.ChildTranslatedCurrencys.FirstOrDefault(x => x.Language == Language.Arabic).Name))

				;
				config.CreateMap<ListTestamentLightViewModel, Testament>();
                #endregion


                #region BankMovementCostCenters, BankMovementCostCentersViewModel
                config.CreateMap<BankMovementCostCenters, BankMovementCostCentersViewModel>();
                config.CreateMap<BankMovementCostCentersViewModel, BankMovementCostCenters>();
				#endregion

				#region AdvancesType, AdvancesTypeViewModel
				config.CreateMap<AdvancesType, AdvancesTypeViewModel>()
				.ForMember(x => x.NameAr, z => z.MapFrom(o => o.ChildTranslatedAdvancesTypes.FirstOrDefault(y => y.Language == Language.Arabic).Name))
				.ForMember(x => x.NameEn, z => z.MapFrom(o => o.ChildTranslatedAdvancesTypes.FirstOrDefault(y => y.Language == Language.English).Name))
				;
				config.CreateMap<AdvancesTypeViewModel, AdvancesType>();
				#endregion

				#region AdvancesType, AdvancesTypeLightViewModel
				config.CreateMap<AdvancesType, AdvancesTypeLightViewModel>()
				.ForMember(x => x.Id, z => z.MapFrom(o => o.ParentKeyAdvancesTypeId))
				;
				config.CreateMap<AdvancesTypeLightViewModel, AdvancesType>();
				#endregion

                #region TestamentExtraction, TestamentExtractionViewModel
                config.CreateMap<TestamentExtraction, TestamentExtractionViewModel>()
                .ForMember(x => x.Id, z => z.MapFrom(o => o.ParentKeyTestamentExtractionId))
                .ForMember(x => x.NameAr, z => z.MapFrom(o => o.ChildTranslatedTestamentExtractions.FirstOrDefault(x => x.Language == Language.Arabic).Name))
                .ForMember(x => x.NameEn, z => z.MapFrom(o => o.ChildTranslatedTestamentExtractions.FirstOrDefault(x => x.Language == Language.English).Name))
                .ForMember(x => x.DescriptionAr, z => z.MapFrom(o => o.ChildTranslatedTestamentExtractions.FirstOrDefault(x => x.Language == Language.Arabic).Description))
                .ForMember(x => x.DescriptionEn, z => z.MapFrom(o => o.ChildTranslatedTestamentExtractions.FirstOrDefault(x => x.Language == Language.English).Description))
                ;
                config.CreateMap<TestamentExtractionViewModel, TestamentExtraction>();
				#endregion

				#region Advance, AdvanceViewModel
				config.CreateMap<Advance, AdvanceViewModel>()
				.ForMember(x => x.DescriptionAr, z => z.MapFrom(o => o.ChildTranslatedAdvances.FirstOrDefault(y => y.Language == Language.Arabic).Description))
				.ForMember(x => x.DescriptionEn, z => z.MapFrom(o => o.ChildTranslatedAdvances.FirstOrDefault(y => y.Language == Language.English).Description))
				;
				config.CreateMap<AdvanceViewModel, Advance>();
                #endregion

                #region Liquidation, LiquidationViewModel
                config.CreateMap<Liquidation, LiquidationViewModel>();
                config.CreateMap<LiquidationViewModel, Liquidation>();
                #endregion

                #region LiquidationDetail, LiquidationDetailViewModel
                config.CreateMap<LiquidationDetail, LiquidationDetailViewModel>();
                config.CreateMap<LiquidationDetailViewModel, LiquidationDetail>();
                #endregion

                #region Advance, LiquidationDetailViewModel
                config.CreateMap<Advance, LiquidationDetailViewModel>()
                .ForMember(x => x.Amount, z => z.MapFrom(opt => opt.Amount))
                .ForMember(x => x.AdvanceId, z => z.MapFrom(opt => opt.Id))
                ;
                config.CreateMap<LiquidationDetailViewModel, Advance>();
                #endregion


            });
		}
		#endregion

		private static Language GetLangMethod(AccountChart Acc)
		{
			return (Language)Acc.Language;
		}
	}
	public class LanguageResolver : IValueResolver<AccountChart, AccountChartViewModel, List<AccountChart>>
	{
		List<AccountChart> IValueResolver<AccountChart, AccountChartViewModel, List<AccountChart>>.Resolve(AccountChart source, AccountChartViewModel destination, List<AccountChart> destMember, ResolutionContext context)
		{
			var lang = source.Language;

			var list = source.ParentKeyAccountChart.ChildTranslatedAccountCharts.Where(x => x.Language == lang).ToList();
			return list;
		}
	}
}
