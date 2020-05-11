#region Using ...
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
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Core.AutoMapperConfig
{
    /// <summary>
    /// Provides an extention methods for 
    /// converting between entities and models.
    /// </summary>
    public static class Extentions
    {

        #region ExitPermission, ExitPermissionViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ExitPermissionViewModel ToModel(this ExitPermission entity)
        {
            var result = AutoMapper.Mapper.Map<ExitPermission, ExitPermissionViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static ExitPermission ToEntity(this ExitPermissionViewModel model)
        {
            var result = AutoMapper.Mapper.Map<ExitPermissionViewModel, ExitPermission>(model);
            return result;
        }
        #endregion

        #region ExitPermission, ExitPermissionLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ExitPermissionLightViewModel ToLightModel(this ExitPermission entity)
        {
            var result = AutoMapper.Mapper.Map<ExitPermission, ExitPermissionLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static ExitPermission ToEntity(this ExitPermissionLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<ExitPermissionLightViewModel, ExitPermission>(model);
            return result;
        }
        #endregion


        #region EntrancePermission, EntrancePermissionViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static EntrancePermissionViewModel ToModel(this EntrancePermission entity)
        {
            var result = AutoMapper.Mapper.Map<EntrancePermission, EntrancePermissionViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static EntrancePermission ToEntity(this EntrancePermissionViewModel model)
        {
            var result = AutoMapper.Mapper.Map<EntrancePermissionViewModel, EntrancePermission>(model);
            return result;
        }
        #endregion

        #region EntrancePermission, EntrancePermissionLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static EntrancePermissionLightViewModel ToLightModel(this EntrancePermission entity)
        {
            var result = AutoMapper.Mapper.Map<EntrancePermission, EntrancePermissionLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static EntrancePermission ToEntity(this EntrancePermissionLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<EntrancePermissionLightViewModel, EntrancePermission>(model);
            return result;
        }
        #endregion


        #region PurchaseRebateProduct, PurchaseRebateProductViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static PurchaseRebateProductViewModel ToModel(this PurchaseRebateProduct entity)
        {
            var result = AutoMapper.Mapper.Map<PurchaseRebateProduct, PurchaseRebateProductViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static PurchaseRebateProduct ToEntity(this PurchaseRebateProductViewModel model)
        {
            var result = AutoMapper.Mapper.Map<PurchaseRebateProductViewModel, PurchaseRebateProduct>(model);
            return result;
        }
        #endregion



        #region PurchaseRebateProduct, PurchaseRebateProductLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static PurchaseRebateProductLightViewModel ToLightModel(this PurchaseRebateProduct entity)
        {
            var result = AutoMapper.Mapper.Map<PurchaseRebateProduct, PurchaseRebateProductLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static PurchaseRebateProduct ToEntity(this PurchaseRebateProductLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<PurchaseRebateProductLightViewModel, PurchaseRebateProduct>(model);
            return result;
        }
        #endregion


        #region SalesRebateProduct, SalesRebateProductViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static SalesRebateProductViewModel ToModel(this SalesRebateProduct entity)
        {
            var result = AutoMapper.Mapper.Map<SalesRebateProduct, SalesRebateProductViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static SalesRebateProduct ToEntity(this SalesRebateProductViewModel model)
        {
            var result = AutoMapper.Mapper.Map<SalesRebateProductViewModel, SalesRebateProduct>(model);
            return result;
        }
        #endregion

        #region SalesRebateProduct, SalesRebateProductLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static SalesRebateProductLightViewModel ToLightModel(this SalesRebateProduct entity)
        {
            var result = AutoMapper.Mapper.Map<SalesRebateProduct, SalesRebateProductLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static SalesRebateProduct ToEntity(this SalesRebateProductLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<SalesRebateProductLightViewModel, SalesRebateProduct>(model);
            return result;
        }
        #endregion


        #region AccountChartSetting, AccountChartSettingViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static AccountChartSettingViewModel ToModel(this AccountChartSetting entity)
        {
            var result = AutoMapper.Mapper.Map<AccountChartSetting, AccountChartSettingViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static AccountChartSetting ToEntity(this AccountChartSettingViewModel model)
        {
            var result = AutoMapper.Mapper.Map<AccountChartSettingViewModel, AccountChartSetting>(model);
            return result;
        }
        #endregion

        #region AccountChartSetting, AccountChartSettingLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static AccountChartSettingLightViewModel ToLightModel(this AccountChartSetting entity)
        {
            var result = AutoMapper.Mapper.Map<AccountChartSetting, AccountChartSettingLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static AccountChartSetting ToEntity(this AccountChartSettingLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<AccountChartSettingLightViewModel, AccountChartSetting>(model);
            return result;
        }
        #endregion


        #region UserGroup, UserGroupViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static UserGroupViewModel ToModel(this UserGroup entity)
        {
            var result = AutoMapper.Mapper.Map<UserGroup, UserGroupViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static UserGroup ToEntity(this UserGroupViewModel model)
        {
            var result = AutoMapper.Mapper.Map<UserGroupViewModel, UserGroup>(model);
            return result;
        }
        #endregion

        #region UserGroup, UserGroupLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static UserGroupLightViewModel ToLightModel(this UserGroup entity)
        {
            var result = AutoMapper.Mapper.Map<UserGroup, UserGroupLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static UserGroup ToEntity(this UserGroupLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<UserGroupLightViewModel, UserGroup>(model);
            return result;
        }
        #endregion


        #region GroupRole, GroupRoleViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static GroupRoleViewModel ToModel(this GroupRole entity)
        {
            var result = AutoMapper.Mapper.Map<GroupRole, GroupRoleViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static GroupRole ToEntity(this GroupRoleViewModel model)
        {
            var result = AutoMapper.Mapper.Map<GroupRoleViewModel, GroupRole>(model);
            return result;
        }
        #endregion

        #region GroupRole, GroupRoleLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static GroupRoleLightViewModel ToLightModel(this GroupRole entity)
        {
            var result = AutoMapper.Mapper.Map<GroupRole, GroupRoleLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static GroupRole ToEntity(this GroupRoleLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<GroupRoleLightViewModel, GroupRole>(model);
            return result;
        }
        #endregion


        #region Group, GroupViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static GroupViewModel ToModel(this Group entity)
        {
            var result = AutoMapper.Mapper.Map<Group, GroupViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Group ToEntity(this GroupViewModel model)
        {
            var result = AutoMapper.Mapper.Map<GroupViewModel, Group>(model);
            return result;
        }
        #endregion

        #region Group, GroupLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static GroupLightViewModel ToLightModel(this Group entity)
        {
            var result = AutoMapper.Mapper.Map<Group, GroupLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Group ToEntity(this GroupLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<GroupLightViewModel, Group>(model);
            return result;
        }
        #endregion


        #region GroupPermission, GroupPermissionViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static GroupPermissionViewModel ToModel(this GroupPermission entity)
        {
            var result = AutoMapper.Mapper.Map<GroupPermission, GroupPermissionViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static GroupPermission ToEntity(this GroupPermissionViewModel model)
        {
            var result = AutoMapper.Mapper.Map<GroupPermissionViewModel, GroupPermission>(model);
            return result;
        }
        #endregion

        #region GroupPermission, GroupPermissionLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static GroupPermissionLightViewModel ToLightModel(this GroupPermission entity)
        {
            var result = AutoMapper.Mapper.Map<GroupPermission, GroupPermissionLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static GroupPermission ToEntity(this GroupPermissionLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<GroupPermissionLightViewModel, GroupPermission>(model);
            return result;
        }
        #endregion


        #region RolePermission, RolePermissionViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static RolePermissionViewModel ToModel(this RolePermission entity)
        {
            var result = AutoMapper.Mapper.Map<RolePermission, RolePermissionViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static RolePermission ToEntity(this RolePermissionViewModel model)
        {
            var result = AutoMapper.Mapper.Map<RolePermissionViewModel, RolePermission>(model);
            return result;
        }
        #endregion

        #region RolePermission, RolePermissionLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static RolePermissionLightViewModel ToLightModel(this RolePermission entity)
        {
            var result = AutoMapper.Mapper.Map<RolePermission, RolePermissionLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static RolePermission ToEntity(this RolePermissionLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<RolePermissionLightViewModel, RolePermission>(model);
            return result;
        }
        #endregion


        #region Permission, PermissionViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static PermissionViewModel ToModel(this Permission entity)
        {
            var result = AutoMapper.Mapper.Map<Permission, PermissionViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Permission ToEntity(this PermissionViewModel model)
        {
            var result = AutoMapper.Mapper.Map<PermissionViewModel, Permission>(model);
            return result;
        }
        #endregion

        #region Permission, PermissionLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static PermissionLightViewModel ToLightModel(this Permission entity)
        {
            var result = AutoMapper.Mapper.Map<Permission, PermissionLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Permission ToEntity(this PermissionLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<PermissionLightViewModel, Permission>(model);
            return result;
        }
        #endregion


        #region UserRole, UserRoleViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static UserRoleViewModel ToModel(this UserRole entity)
        {
            var result = AutoMapper.Mapper.Map<UserRole, UserRoleViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static UserRole ToEntity(this UserRoleViewModel model)
        {
            var result = AutoMapper.Mapper.Map<UserRoleViewModel, UserRole>(model);
            return result;
        }
        #endregion

        #region UserRole, UserRoleLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static UserRoleLightViewModel ToLightModel(this UserRole entity)
        {
            var result = AutoMapper.Mapper.Map<UserRole, UserRoleLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static UserRole ToEntity(this UserRoleLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<UserRoleLightViewModel, UserRole>(model);
            return result;
        }
        #endregion


        #region UserPermission, UserPermissionViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static UserPermissionViewModel ToModel(this UserPermission entity)
        {
            var result = AutoMapper.Mapper.Map<UserPermission, UserPermissionViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static UserPermission ToEntity(this UserPermissionViewModel model)
        {
            var result = AutoMapper.Mapper.Map<UserPermissionViewModel, UserPermission>(model);
            return result;
        }
        #endregion

        #region UserPermission, UserPermissionLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static UserPermissionLightViewModel ToLightModel(this UserPermission entity)
        {
            var result = AutoMapper.Mapper.Map<UserPermission, UserPermissionLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static UserPermission ToEntity(this UserPermissionLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<UserPermissionLightViewModel, UserPermission>(model);
            return result;
        }
        #endregion



        #region Role, RoleViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static RoleViewModel ToModel(this Role entity)
        {
            var result = AutoMapper.Mapper.Map<Role, RoleViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Role ToEntity(this RoleViewModel model)
        {
            var result = AutoMapper.Mapper.Map<RoleViewModel, Role>(model);
            return result;
        }
        #endregion

        #region Role, RoleLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static RoleLightViewModel ToLightModel(this Role entity)
        {
            var result = AutoMapper.Mapper.Map<Role, RoleLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Role ToEntity(this RoleLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<RoleLightViewModel, Role>(model);
            return result;
        }
        #endregion



        #region UserMenuItem, UserMenuItemViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static UserMenuItemViewModel ToModel(this UserMenuItem entity)
        {
            var result = AutoMapper.Mapper.Map<UserMenuItem, UserMenuItemViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static UserMenuItem ToEntity(this UserMenuItemViewModel model)
        {
            var result = AutoMapper.Mapper.Map<UserMenuItemViewModel, UserMenuItem>(model);
            return result;
        }
        #endregion

        #region UserMenuItem, UserMenuItemLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static UserMenuItemLightViewModel ToLightModel(this UserMenuItem entity)
        {
            var result = AutoMapper.Mapper.Map<UserMenuItem, UserMenuItemLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static UserMenuItem ToEntity(this UserMenuItemLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<UserMenuItemLightViewModel, UserMenuItem>(model);
            return result;
        }
        #endregion



        #region MenuItem, MenuItemViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static MenuItemViewModel ToModel(this MenuItem entity)
        {
            var result = AutoMapper.Mapper.Map<MenuItem, MenuItemViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static MenuItem ToEntity(this MenuItemViewModel model)
        {
            var result = AutoMapper.Mapper.Map<MenuItemViewModel, MenuItem>(model);
            return result;
        }
        #endregion

        #region MenuItem, MenuItemLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static MenuItemLightViewModel ToLightModel(this MenuItem entity)
        {
            var result = AutoMapper.Mapper.Map<MenuItem, MenuItemLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static MenuItem ToEntity(this MenuItemLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<MenuItemLightViewModel, MenuItem>(model);
            return result;
        }
        #endregion

        #region MenuItem, SidebarMenuItemLightViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static SidebarMenuItemLightViewModel ToSidebarLightModel(this MenuItem entity)
        {
            var result = AutoMapper.Mapper.Map<MenuItem, SidebarMenuItemLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static MenuItem ToEntity(this SidebarMenuItemLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<SidebarMenuItemLightViewModel, MenuItem>(model);
            return result;
        }
        #endregion

        #region CountryCallingCode, CountryCallingCodeViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static CountryCallingCodeViewModel ToModel(this CountryCallingCode entity)
        {
            var result = AutoMapper.Mapper.Map<CountryCallingCode, CountryCallingCodeViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static CountryCallingCode ToEntity(this CountryCallingCodeViewModel model)
        {
            var result = AutoMapper.Mapper.Map<CountryCallingCodeViewModel, CountryCallingCode>(model);
            return result;
        }
        #endregion

        #region CountryCallingCode, CountryCallingCodeLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static CountryCallingCodeLightViewModel ToLightModel(this CountryCallingCode entity)
        {
            var result = AutoMapper.Mapper.Map<CountryCallingCode, CountryCallingCodeLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static CountryCallingCode ToEntity(this CountryCallingCodeLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<CountryCallingCodeLightViewModel, CountryCallingCode>(model);
            return result;
        }
        #endregion


        #region Address, AddressViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static AddressViewModel ToModel(this Address entity)
        {
            var result = AutoMapper.Mapper.Map<Address, AddressViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Address ToEntity(this AddressViewModel model)
        {
            var result = AutoMapper.Mapper.Map<AddressViewModel, Address>(model);
            return result;
        }
        #endregion

        #region Address, AddressLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static AddressLightViewModel ToLightModel(this Address entity)
        {
            var result = AutoMapper.Mapper.Map<Address, AddressLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Address ToEntity(this AddressLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<AddressLightViewModel, Address>(model);
            return result;
        }
        #endregion


        #region ProductPrice, ProductPriceViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ProductPriceViewModel ToModel(this ProductPrice entity)
        {
            var result = AutoMapper.Mapper.Map<ProductPrice, ProductPriceViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static ProductPrice ToEntity(this ProductPriceViewModel model)
        {
            var result = AutoMapper.Mapper.Map<ProductPriceViewModel, ProductPrice>(model);
            return result;
        }
        #endregion

        #region ProductPrice, ProductPriceLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ProductPriceLightViewModel ToLightModel(this ProductPrice entity)
        {
            var result = AutoMapper.Mapper.Map<ProductPrice, ProductPriceLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static ProductPrice ToEntity(this ProductPriceLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<ProductPriceLightViewModel, ProductPrice>(model);
            return result;
        }
        #endregion


        #region Journal, JournalViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static JournalViewModel ToModel(this Journal entity)
        {
            var result = AutoMapper.Mapper.Map<Journal, JournalViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Journal ToEntity(this JournalViewModel model)
        {
            var result = AutoMapper.Mapper.Map<JournalViewModel, Journal>(model);
            return result;
        }
        #endregion

        #region Journal, JournalLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static JournalLightViewModel ToLightModel(this Journal entity)
        {
            var result = AutoMapper.Mapper.Map<Journal, JournalLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Journal ToEntity(this JournalLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<JournalLightViewModel, Journal>(model);
            return result;
        }
        #endregion

        #region Journal, AddJournalEntriesViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static AddJournalEntriesViewModel ToAddModel(this Journal entity)
        {
            var result = AutoMapper.Mapper.Map<Journal, AddJournalEntriesViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Journal ToEntity(this AddJournalEntriesViewModel model)
        {
            var result = AutoMapper.Mapper.Map<AddJournalEntriesViewModel, Journal>(model);
            return result;
        }
        #endregion


        #region ExchangeBonds, ExchangeBondsViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ExchangeBondsViewModel ToModel(this ExchangeBonds entity)
        {
            var result = AutoMapper.Mapper.Map<ExchangeBonds, ExchangeBondsViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static ExchangeBonds ToEntity(this ExchangeBondsViewModel model)
        {
            var result = AutoMapper.Mapper.Map<ExchangeBondsViewModel, ExchangeBonds>(model);
            return result;
        }
        #endregion

        #region ExchangeBonds, ExchangeBondsLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ExchangeBondsLightViewModel ToLightModel(this ExchangeBonds entity)
        {
            var result = AutoMapper.Mapper.Map<ExchangeBonds, ExchangeBondsLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static ExchangeBonds ToEntity(this ExchangeBondsLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<ExchangeBondsLightViewModel, ExchangeBonds>(model);
            return result;
        }
        #endregion


        #region Receipts, ReceiptsViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ReceiptsViewModel ToModel(this Receipts entity)
        {
            var result = AutoMapper.Mapper.Map<Receipts, ReceiptsViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Receipts ToEntity(this ReceiptsViewModel model)
        {
            var result = AutoMapper.Mapper.Map<ReceiptsViewModel, Receipts>(model);
            return result;
        }
        #endregion

        #region Receipts, ReceiptsLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ReceiptsLightViewModel ToLightModel(this Receipts entity)
        {
            var result = AutoMapper.Mapper.Map<Receipts, ReceiptsLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Receipts ToEntity(this ReceiptsLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<ReceiptsLightViewModel, Receipts>(model);
            return result;
        }
        #endregion


        #region SalesRebate, SalesRebateViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static SalesRebateViewModel ToModel(this SalesRebate entity)
        {
            var result = AutoMapper.Mapper.Map<SalesRebate, SalesRebateViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static SalesRebate ToEntity(this SalesRebateViewModel model)
        {
            var result = AutoMapper.Mapper.Map<SalesRebateViewModel, SalesRebate>(model);
            return result;
        }
        #endregion

        #region SalesRebate, SalesRebateLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static SalesRebateLightViewModel ToLightModel(this SalesRebate entity)
        {
            var result = AutoMapper.Mapper.Map<SalesRebate, SalesRebateLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static SalesRebate ToEntity(this SalesRebateLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<SalesRebateLightViewModel, SalesRebate>(model);
            return result;
        }
        #endregion


        #region PurchaseRebate, PurchaseRebateViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static PurchaseRebateViewModel ToModel(this PurchaseRebate entity)
        {
            var result = AutoMapper.Mapper.Map<PurchaseRebate, PurchaseRebateViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static PurchaseRebate ToEntity(this PurchaseRebateViewModel model)
        {
            //var result = AutoMapper.Mapper.Map<PurchaseRebateViewModel, PurchaseRebate>(model);
            var result = new PurchaseRebate
            {
                IsPosted = model.IsPosted,
                PostingDate = model.PostingDate,
                PostedByUserId = model.PostedByUserId,
                Code = model.Code,
                Date = model.Date,
                VendorId = model.VendorId,
                InventoryId = model.InventoryId,
                PurchaseInvoiceTypeId = model.PurchaseInvoiceTypeId,
                SafeId = model.SafeId,
                TotalAmount = model.TotalAmount,
                TaxAmount = model.TaxAmount,
                TotalExpenses = model.TotalExpenses,
                TotalDiscount = model.TotalDiscount,
                NetAmount = model.NetAmount,
            };

            if (model.PurchaseRebateCostCenters != null)
            {
                result.PurchaseRebateCostCenters = model.PurchaseRebateCostCenters.Select(item => item.ToEntity()).ToList();
            }

            foreach (var item in model.PurchaseRebateProducts)
            {
                result.PurchaseRebateProducts.Add(new PurchaseRebateProduct
                {
                    ProductId = item.ProductId,
                    AccountChartId = item.AccountChartId,
                    BrandId = item.BrandId,
                    Code = item.Code,
                    Discount = item.Discount,
                    Expenses = item.Expenses,
                    MeasurementUnitId = item.MeasurementUnitId,
                    NetValue = item.NetValue,
                    Price = item.Price,
                    ProductTypeId = item.ProductTypeId,
                    PurchaseInvoiceId = item.PurchaseInvoiceId,
                    Quantity = item.Quantity,
                    TotalDiscount = item.TotalDiscount
                });
            }

            if (model.FromBankId.HasValue)
                result.FromBankId = model.FromBankId;
            if (model.ToBankId.HasValue)
                result.ToBankId = model.ToBankId;
            if (string.IsNullOrEmpty(model.ChequeNumber) == false)
                result.ChequeNumber = model.ChequeNumber;
            if (model.DueDate.HasValue)
                result.DueDate = model.DueDate;

            return result;
        }
        #endregion

        #region PurchaseRebate, PurchaseRebateLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static PurchaseRebateLightViewModel ToLightModel(this PurchaseRebate entity)
        {
            var result = AutoMapper.Mapper.Map<PurchaseRebate, PurchaseRebateLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static PurchaseRebate ToEntity(this PurchaseRebateLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<PurchaseRebateLightViewModel, PurchaseRebate>(model);
            return result;
        }
        #endregion

        #region PurchaseRebate, ListPurchasLightViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ListPurchasLightViewModel ToListModel(this PurchaseRebate entity)
        {
            var result = AutoMapper.Mapper.Map<PurchaseRebate, ListPurchasLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static PurchaseRebate ToRebateEntity(this ListPurchasLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<ListPurchasLightViewModel, PurchaseRebate>(model);
            return result;
        }
        #endregion


        #region PurchaseInvoice, PurchaseInvoiceViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static PurchaseInvoiceViewModel ToModel(this PurchaseInvoice entity)
        {
            var result = AutoMapper.Mapper.Map<PurchaseInvoice, PurchaseInvoiceViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static PurchaseInvoice ToEntity(this PurchaseInvoiceViewModel model)
        {
            //var result = AutoMapper.Mapper.Map<PurchaseInvoiceViewModel, PurchaseInvoice>(model);
            var result = new PurchaseInvoice
            {
                AdditionalExpensesAmount = model.AdditionalExpensesAmount,
                Code = model.Code,
                Date = model.Date,
                DiscountAmount = model.DiscountAmount,
                HasAdditionalExpenses = model.HasAdditionalExpenses,
                HasDiscount = model.HasDiscount,
                InventoryId = model.InventoryId,
                NetAmount = model.NetAmount,
                PurchaseInvoiceTypeId = model.PurchaseInvoiceTypeId,
                SafeId = model.SafeId,
                TaxAmount = model.TaxAmount,
                TotalAmountAfterTax = model.TotalAmountAfterTax,
                TotalAmountBeforeTax = model.TotalAmountBeforeTax,
                TotalDiscount = model.TotalDiscount,
                TotalExpenses = model.TotalExpenses,
                VendorId = model.VendorId,
                VendorInvoiceCode = model.VendorInvoiceCode,
                VisaBankId = model.VisaBankId,
                VisaNumber = model.VisaNumber,

                FromBankId = model.FromBankId,
                ToBankId = model.ToBankId,
                ChequeNumber = model.ChequeNumber,
                Duedate = model.DueDate
            };

            if (model.PurchaseInvoiceCostCenters != null)
            {
                result.PurchaseInvoiceCostCenters = model.PurchaseInvoiceCostCenters.Select(item => item.ToEntity()).ToList();
            }

            foreach (var item in model.Products)
            {
                result.Products.Add(new Product
                {
                    AccountChartId = item.AccountChartId,
                    BrandId = item.BrandId,
                    Code = item.Code,
                    Discount = item.Discount,
                    Expenses = item.Expenses,
                    MeasurementUnitId = item.MeasurementUnitId,
                    NetValue = item.NetValue,
                    Price = item.Price,
                    ProductTypeId = item.ProductTypeId,
                    PurchaseInvoiceId = item.PurchaseInvoiceId,
                    Quantity = item.Quantity,
                    TotalDiscount = item.TotalDiscount,
                    Description=item.Description
                });
            }

            return result;
        }
        #endregion

        #region PurchaseInvoice, PurchaseInvoiceLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static PurchaseInvoiceLightViewModel ToLightModel(this PurchaseInvoice entity)
        {
            var result = AutoMapper.Mapper.Map<PurchaseInvoice, PurchaseInvoiceLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static PurchaseInvoice ToEntity(this PurchaseInvoiceLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<PurchaseInvoiceLightViewModel, PurchaseInvoice>(model);
            return result;
        }
        #endregion

        #region PurchaseInvoice, PurchaseInvoiceLookupLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static PurchaseInvoiceLookupLightViewModel ToLookupLightModel(this PurchaseInvoice entity)
        {
            var result = AutoMapper.Mapper.Map<PurchaseInvoice, PurchaseInvoiceLookupLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static PurchaseInvoice ToEntity(this PurchaseInvoiceLookupLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<PurchaseInvoiceLookupLightViewModel, PurchaseInvoice>(model);
            return result;
        }
        #endregion

        #region PurchaseInvoice, PurchaseInvoiceLookupViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static PurchaseInvoiceLookupViewModel ToLookupModel(this PurchaseInvoice entity)
        {
            var result = AutoMapper.Mapper.Map<PurchaseInvoice, PurchaseInvoiceLookupViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static PurchaseInvoice ToEntity(this PurchaseInvoiceLookupViewModel model)
        {
            var result = AutoMapper.Mapper.Map<PurchaseInvoiceLookupViewModel, PurchaseInvoice>(model);
            return result;
        }
        #endregion

        #region PurchaseInvoice, ListPurchasLightViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ListPurchasLightViewModel ToListModel(this PurchaseInvoice entity)
        {
            var result = AutoMapper.Mapper.Map<PurchaseInvoice, ListPurchasLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static PurchaseInvoice ToEntity(this ListPurchasLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<ListPurchasLightViewModel, PurchaseInvoice>(model);
            return result;
        }
        #endregion


        #region Transaction, TransactionViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static TransactionViewModel ToModel(this Transaction entity)
        {
            var result = AutoMapper.Mapper.Map<Transaction, TransactionViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Transaction ToEntity(this TransactionViewModel model)
        {
            var result = AutoMapper.Mapper.Map<TransactionViewModel, Transaction>(model);
            return result;
        }
        #endregion

        #region Transaction, TransactionLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static TransactionLightViewModel ToLightModel(this Transaction entity)
        {
            var result = AutoMapper.Mapper.Map<Transaction, TransactionLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Transaction ToEntity(this TransactionLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<TransactionLightViewModel, Transaction>(model);
            return result;
        }
        #endregion


        #region PaymentMethod, PaymentMethodViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static PaymentMethodViewModel ToModel(this PaymentMethod entity)
        {
            var result = AutoMapper.Mapper.Map<PaymentMethod, PaymentMethodViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static PaymentMethod ToEntity(this PaymentMethodViewModel model)
        {
            var result = AutoMapper.Mapper.Map<PaymentMethodViewModel, PaymentMethod>(model);
            return result;
        }
        #endregion

        #region PaymentMethod, PaymentMethodLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static PaymentMethodLightViewModel ToLightModel(this PaymentMethod entity)
        {
            var result = AutoMapper.Mapper.Map<PaymentMethod, PaymentMethodLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static PaymentMethod ToEntity(this PaymentMethodLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<PaymentMethodLightViewModel, PaymentMethod>(model);
            return result;
        }
        #endregion


        #region Asset, AssetViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static AssetViewModel ToModel(this Asset entity)
        {
            var result = AutoMapper.Mapper.Map<Asset, AssetViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Asset ToEntity(this AssetViewModel model)
        {
            var result = AutoMapper.Mapper.Map<AssetViewModel, Asset>(model);
            return result;
        }
        #endregion

        #region EffiencyRaiseHistory, EffiencyRaiseHistoryViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static EffiencyRaiseHistoryViewModel ToModel(this EfficiencyRaiseHistory entity)
        {
            var result = AutoMapper.Mapper.Map<EfficiencyRaiseHistory, EffiencyRaiseHistoryViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static EfficiencyRaiseHistory ToEntity(this EffiencyRaiseHistoryViewModel model)
        {
            var result = AutoMapper.Mapper.Map<EffiencyRaiseHistoryViewModel, EfficiencyRaiseHistory>(model);
            return result;
        }

        #endregion

        #region Asset, AssetLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static AssetLightViewModel ToLightModel(this Asset entity)
        {
            var result = AutoMapper.Mapper.Map<Asset, AssetLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Asset ToEntity(this AssetLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<AssetLightViewModel, Asset>(model);
            return result;
        }

        public static AssetLookupViewModel ToLookup(this Asset model)
        {
            var result = AutoMapper.Mapper.Map<Asset, AssetLookupViewModel>(model);
            return result;
        }

        #endregion


        #region AssetCategory, AssetCategoryViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static AssetCategoryViewModel ToModel(this AssetCategory entity)
        {
            var result = AutoMapper.Mapper.Map<AssetCategory, AssetCategoryViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static AssetCategory ToEntity(this AssetCategoryViewModel model)
        {
            var result = AutoMapper.Mapper.Map<AssetCategoryViewModel, AssetCategory>(model);
            return result;
        }
        #endregion

        #region AssetCategory, AssetCategoryLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static AssetCategoryLightViewModel ToLightModel(this AssetCategory entity)
        {
            var result = AutoMapper.Mapper.Map<AssetCategory, AssetCategoryLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static AssetCategory ToEntity(this AssetCategoryLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<AssetCategoryLightViewModel, AssetCategory>(model);
            return result;
        }
        #endregion

        #region Inventory, ListInventoryLightViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ListInventoryLightViewModel ToListModel(this Inventory entity)
        {
            var result = AutoMapper.Mapper.Map<Inventory, ListInventoryLightViewModel>(entity);
            return result;
        }

        #endregion

        #region Inventory, InventoryViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static InventoryViewModel ToModel(this Inventory entity)
        {
            var result = AutoMapper.Mapper.Map<Inventory, InventoryViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Inventory ToEntity(this InventoryViewModel model)
        {
            var result = AutoMapper.Mapper.Map<InventoryViewModel, Inventory>(model);
            return result;
        }
        #endregion

        #region Inventory, InventoryLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static InventoryLightViewModel ToLightModel(this Inventory entity)
        {
            var result = AutoMapper.Mapper.Map<Inventory, InventoryLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Inventory ToEntity(this InventoryLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<InventoryLightViewModel, Inventory>(model);
            return result;
        }
        #endregion

        #region InventoryOpeningBalanceCostCenter, InventoryOpeningBalanceCostCenterViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static InventoryOpeningBalanceCostCenterViewModel ToModel(this InventoryOpeningBalanceCostCenter entity)
        {
            var result = AutoMapper.Mapper.Map<InventoryOpeningBalanceCostCenter, InventoryOpeningBalanceCostCenterViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static InventoryOpeningBalanceCostCenter ToEntity(this InventoryOpeningBalanceCostCenterViewModel model)
        {
            var result = AutoMapper.Mapper.Map<InventoryOpeningBalanceCostCenterViewModel, InventoryOpeningBalanceCostCenter>(model);
            return result;
        }
        #endregion

        #region InventoryOpeningBalance, InventoryOpeningBalanceViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static InventoryOpeningBalanceViewModel ToModel(this InventoryOpeningBalance entity)
        {
            var result = AutoMapper.Mapper.Map<InventoryOpeningBalance, InventoryOpeningBalanceViewModel>(entity);
            return result;
        }
        #region InventoryOpeningBalance, InventoryOpeningBalanceLookupViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static InventoryOpeningBalanceLookupViewModel ToLookupModel(this InventoryOpeningBalance entity)
        {
            var result = AutoMapper.Mapper.Map<InventoryOpeningBalance, InventoryOpeningBalanceLookupViewModel>(entity);
            return result;
        }
        #endregion
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static InventoryOpeningBalance ToEntity(this InventoryOpeningBalanceViewModel model)
        {
            //var result = AutoMapper.Mapper.Map<InventoryOpeningBalanceViewModel, InventoryOpeningBalance>(model);
            var result = new InventoryOpeningBalance
            {
                Code = model.Code,
                Description = model.Description,
                InventoryId = model.InventoryId,
            };
            foreach (var item in model.InventoryOpeningBalanceCostCenter)
            {
                result.InventoryOpeningBalanceCostCenter.Add(new InventoryOpeningBalanceCostCenter
                {
                    CostCenterId = item.CostCenterId,
                    InventoryOpeningBalanceId = item.InventoryOpeningBalanceId
                });
            }

            foreach (var item in model.Products)
            {
                result.Products.Add(new Product
                {
                    AccountChartId = item.AccountChartId,
                    BrandId = item.BrandId,
                    Code = item.Code,
                    Discount = item.Discount,
                    Expenses = item.Expenses,
                    MeasurementUnitId = item.MeasurementUnitId,
                    NetValue = item.NetValue,
                    Price = item.Price,
                    ProductTypeId = item.ProductTypeId,
                    PurchaseInvoiceId = item.PurchaseInvoiceId,
                    Quantity = item.Quantity,
                    TotalDiscount = item.TotalDiscount
                });
            }
            return result;
        }
        #endregion

        #region InventoryOpeningBalance, InventoryOpeningBalanceLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static InventoryOpeningBalanceLightViewModel ToLightModel(this InventoryOpeningBalance entity)
        {
            var result = AutoMapper.Mapper.Map<InventoryOpeningBalance, InventoryOpeningBalanceLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static InventoryOpeningBalance ToEntity(this InventoryOpeningBalanceLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<InventoryOpeningBalanceLightViewModel, InventoryOpeningBalance>(model);
            return result;
        }
        #endregion

        public static InventoryOpeningBalance ToEntity(this InventoryOpeningBalanceAddViewModel model)
        {
            var result = AutoMapper.Mapper.Map<InventoryOpeningBalanceAddViewModel, InventoryOpeningBalance>(model);
            return result;
        }
        public static InventoryOpeningBalanceAddViewModel ToFromModel(this InventoryOpeningBalance entity)
        {
            var result = AutoMapper.Mapper.Map<InventoryOpeningBalance, InventoryOpeningBalanceAddViewModel>(entity);
            return result;
        }

        public static InventoryTransfer ToEntity(this InventoryTransferAddViewModel model)
        {
            var result = AutoMapper.Mapper.Map<InventoryTransferAddViewModel, InventoryTransfer>(model);
            return result;
        }
        public static InventoryTransferAddViewModel ToFromModel(this InventoryTransfer entity)
        {
            var result = AutoMapper.Mapper.Map<InventoryTransfer, InventoryTransferAddViewModel>(entity);
            return result;
        }

        public static InventoryMovement ToEntity(this InventoryMovementAddViewModel model)
        {
            var result = AutoMapper.Mapper.Map<InventoryMovementAddViewModel, InventoryMovement>(model);
            return result;
        }
        public static InventoryMovementAddViewModel ToFromModel(this InventoryMovement entity)
        {
            var result = AutoMapper.Mapper.Map<InventoryMovement, InventoryMovementAddViewModel>(entity);
            return result;
        }


        #region Product, ProductViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ProductViewModel ToModel(this Product entity)
        {
            var result = AutoMapper.Mapper.Map<Product, ProductViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Product ToEntity(this ProductViewModel model)
        {
            var result = AutoMapper.Mapper.Map<ProductViewModel, Product>(model);
            return result;
        }
        #endregion

        #region Product, InventoryOpeningBalanceProductViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static InventoryOpeningBalanceProductViewModel ToInventoryModel(this Product entity)
        {
            var result = AutoMapper.Mapper.Map<Product, InventoryOpeningBalanceProductViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Product ToEntity(this InventoryOpeningBalanceProductViewModel model)
        {
            var result = AutoMapper.Mapper.Map<InventoryOpeningBalanceProductViewModel, Product>(model);
            return result;
        }
        #endregion

        #region Product, ProductLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ProductLightViewModel ToLightModel(this Product entity)
        {
            var result = AutoMapper.Mapper.Map<Product, ProductLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Product ToEntity(this ProductLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<ProductLightViewModel, Product>(model);
            return result;
        }
        #endregion


        #region ProductType, ProductTypeViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ProductTypeViewModel ToModel(this ProductType entity)
        {
            var result = AutoMapper.Mapper.Map<ProductType, ProductTypeViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static ProductType ToEntity(this ProductTypeViewModel model)
        {
            var result = AutoMapper.Mapper.Map<ProductTypeViewModel, ProductType>(model);
            return result;
        }
        #endregion

        #region ProductType, ProductTypeLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ProductTypeLightViewModel ToLightModel(this ProductType entity)
        {
            var result = AutoMapper.Mapper.Map<ProductType, ProductTypeLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static ProductType ToEntity(this ProductTypeLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<ProductTypeLightViewModel, ProductType>(model);
            return result;
        }
        #endregion


        #region StoreMeasurementUnit, StoreMeasurementUnitViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static StoreMeasurementUnitViewModel ToModel(this StoreMeasurementUnit entity)
        {
            var result = AutoMapper.Mapper.Map<StoreMeasurementUnit, StoreMeasurementUnitViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static StoreMeasurementUnit ToEntity(this StoreMeasurementUnitViewModel model)
        {
            var result = AutoMapper.Mapper.Map<StoreMeasurementUnitViewModel, StoreMeasurementUnit>(model);
            return result;
        }
        #endregion

        #region StoreMeasurementUnit, StoreMeasurementUnitLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static StoreMeasurementUnitLightViewModel ToLightModel(this StoreMeasurementUnit entity)
        {
            var result = AutoMapper.Mapper.Map<StoreMeasurementUnit, StoreMeasurementUnitLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static StoreMeasurementUnit ToEntity(this StoreMeasurementUnitLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<StoreMeasurementUnitLightViewModel, StoreMeasurementUnit>(model);
            return result;
        }
        #endregion


        #region DelegateMan, DelegateManViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static DelegateManViewModel ToModel(this DelegateMan entity)
        {
            var result = AutoMapper.Mapper.Map<DelegateMan, DelegateManViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static DelegateMan ToEntity(this DelegateManViewModel model)
        {
            var result = AutoMapper.Mapper.Map<DelegateManViewModel, DelegateMan>(model);
            return result;
        }
        #endregion

        #region DelegateMan, DelegateManLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static DelegateManLightViewModel ToLightModel(this DelegateMan entity)
        {
            var result = AutoMapper.Mapper.Map<DelegateMan, DelegateManLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static DelegateMan ToEntity(this DelegateManLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<DelegateManLightViewModel, DelegateMan>(model);
            return result;
        }
        #endregion


        #region Case, CaseViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static CaseViewModel ToModel(this Case entity)
        {
            var result = AutoMapper.Mapper.Map<Case, CaseViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Case ToEntity(this CaseViewModel model)
        {
            var result = AutoMapper.Mapper.Map<CaseViewModel, Case>(model);
            return result;
        }
        #endregion

        #region Case, CaseLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static CaseLightViewModel ToLightModel(this Case entity)
        {
            var result = AutoMapper.Mapper.Map<Case, CaseLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Case ToEntity(this CaseLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<CaseLightViewModel, Case>(model);
            return result;
        }
        #endregion


        #region CaseType, CaseTypeViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static CaseTypeViewModel ToModel(this CaseType entity)
        {
            var result = AutoMapper.Mapper.Map<CaseType, CaseTypeViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static CaseType ToEntity(this CaseTypeViewModel model)
        {
            var result = AutoMapper.Mapper.Map<CaseTypeViewModel, CaseType>(model);
            return result;
        }
        #endregion

        #region CaseType, CaseTypeLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static CaseTypeLightViewModel ToLightModel(this CaseType entity)
        {
            var result = AutoMapper.Mapper.Map<CaseType, CaseTypeLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static CaseType ToEntity(this CaseTypeLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<CaseTypeLightViewModel, CaseType>(model);
            return result;
        }
        #endregion


        #region CostCenter, CostCenterViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static CostCenterViewModel ToModel(this CostCenter entity)
        {
            var result = AutoMapper.Mapper.Map<CostCenter, CostCenterViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static CostCenter ToEntity(this CostCenterViewModel model)
        {
            var result = AutoMapper.Mapper.Map<CostCenterViewModel, CostCenter>(model);
            return result;
        }
        #endregion

        #region CostCenter, CostCenterLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static CostCenterLightViewModel ToLightModel(this CostCenter entity)
        {
            var result = AutoMapper.Mapper.Map<CostCenter, CostCenterLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static CostCenter ToEntity(this CostCenterLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<CostCenterLightViewModel, CostCenter>(model);
            return result;
        }
        #endregion


        #region Donator, DonatorViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static DonatorViewModel ToModel(this Donator entity)
        {
            var result = AutoMapper.Mapper.Map<Donator, DonatorViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Donator ToEntity(this DonatorViewModel model)
        {
            var result = AutoMapper.Mapper.Map<DonatorViewModel, Donator>(model);
            return result;
        }
        #endregion

        #region Donator, DonatorLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static DonatorLightViewModel ToLightModel(this Donator entity)
        {
            var result = AutoMapper.Mapper.Map<Donator, DonatorLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Donator ToEntity(this DonatorLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<DonatorLightViewModel, Donator>(model);
            return result;
        }

        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static ListDonatorLightViewModel ToListModel(this Donator entity)
        {
            var result = AutoMapper.Mapper.Map<Donator, ListDonatorLightViewModel>(entity);
            return result;
        }
        #endregion


        #region SalesBillType, SalesBillTypeViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static SalesBillTypeViewModel ToModel(this SalesBillType entity)
        {
            var result = AutoMapper.Mapper.Map<SalesBillType, SalesBillTypeViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static SalesBillType ToEntity(this SalesBillTypeViewModel model)
        {
            var result = AutoMapper.Mapper.Map<SalesBillTypeViewModel, SalesBillType>(model);
            return result;
        }
        #endregion

        #region SalesBillType, SalesBillTypeLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static SalesBillTypeLightViewModel ToLightModel(this SalesBillType entity)
        {
            var result = AutoMapper.Mapper.Map<SalesBillType, SalesBillTypeLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static SalesBillType ToEntity(this SalesBillTypeLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<SalesBillTypeLightViewModel, SalesBillType>(model);
            return result;
        }
        #endregion


        #region SalesBillProduct, SalesBillProductViewModel
        /// <summary>
        /// Converts an entity to  view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static SalesBillProductViewModel ToModel(this SalesBillProduct entity)
        {
            var result = AutoMapper.Mapper.Map<SalesBillProduct, SalesBillProductViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a  view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static SalesBillProduct ToEntity(this SalesBillProductViewModel model)
        {
            var result = AutoMapper.Mapper.Map<SalesBillProductViewModel, SalesBillProduct>(model);
            return result;
        }
        #endregion


        #region SalesBill,SalesBillViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static SalesBillViewModel ToModel(this SalesBill entity)
        {
            var result = AutoMapper.Mapper.Map<SalesBill, SalesBillViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static SalesBill ToEntity(this SalesBillViewModel model)
        {
            var result = AutoMapper.Mapper.Map<SalesBillViewModel, SalesBill>(model);
            return result;
        }
        #endregion


        #region Bank, BankViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static BankViewModel ToModel(this Bank entity)
        {
            var result = AutoMapper.Mapper.Map<Bank, BankViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Bank ToEntity(this BankViewModel model)
        {
            var result = AutoMapper.Mapper.Map<BankViewModel, Bank>(model);
            return result;
        }
        #endregion

        #region Bank, BankLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static BankLightViewModel ToLightModel(this Bank entity)
        {
            var result = AutoMapper.Mapper.Map<Bank, BankLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Bank ToEntity(this BankLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<BankLightViewModel, Bank>(model);
            return result;
        }
        #endregion


        #region Safe, SafeViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static SafeViewModel ToModel(this Safe entity)
        {
            var result = AutoMapper.Mapper.Map<Safe, SafeViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Safe ToEntity(this SafeViewModel model)
        {
            var result = AutoMapper.Mapper.Map<SafeViewModel, Safe>(model);
            return result;
        }
        #endregion

        #region Safe, SafeLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static SafeLightViewModel ToLightModel(this Safe entity)
        {
            var result = AutoMapper.Mapper.Map<Safe, SafeLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Safe ToEntity(this SafeLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<SafeLightViewModel, Safe>(model);
            return result;
        }
        #endregion


        #region AccountChart, AccountChartViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static AccountChartViewModel ToModel(this AccountChart entity)
        {
            var result = AutoMapper.Mapper.Map<AccountChart, AccountChartViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static AccountChart ToEntity(this AccountChartViewModel model)
        {
            var result = AutoMapper.Mapper.Map<AccountChartViewModel, AccountChart>(model);
            return result;
        }
        #endregion

        #region AccountChart, AccountChartViewModel

        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static AccountChart ToEntity(this AddAccountChartViewModel model)
        {
            var result = AutoMapper.Mapper.Map<AddAccountChartViewModel, AccountChart>(model);
            return result;
        }

        public static AddAccountChartViewModel ToAddModel(this AccountChart model)
        {
            var result = AutoMapper.Mapper.Map<AccountChart, AddAccountChartViewModel>(model);
            return result;
        }


        #endregion

        #region AccountChart, AccountChartLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static AccountChartLightViewModel ToLightModel(this AccountChart entity)
        {
            var result = AutoMapper.Mapper.Map<AccountChart, AccountChartLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static AccountChart ToEntity(this AccountChartLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<AccountChartLightViewModel, AccountChart>(model);
            return result;
        }
        #endregion


        #region AccountChartGroup, AccountChartGroupViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static AccountChartGroupViewModel ToModel(this AccountChartGroup entity)
        {
            var result = AutoMapper.Mapper.Map<AccountChartGroup, AccountChartGroupViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static AccountChartGroup ToEntity(this AccountChartGroupViewModel model)
        {
            var result = AutoMapper.Mapper.Map<AccountChartGroupViewModel, AccountChartGroup>(model);
            return result;
        }
        #endregion

        #region AccountChartGroup, AccountChartGroupLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static AccountChartGroupLightViewModel ToLightModel(this AccountChartGroup entity)
        {
            var result = AutoMapper.Mapper.Map<AccountChartGroup, AccountChartGroupLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        #endregion

        #region AccountChartGroup, AccountChartGroupViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static AccountChartCategoryViewModel ToModel(this AccountChartCategory entity)
        {
            var result = AutoMapper.Mapper.Map<AccountChartCategory, AccountChartCategoryViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static AccountChartCategory ToEntity(this AccountChartCategoryViewModel model)
        {
            var result = AutoMapper.Mapper.Map<AccountChartCategoryViewModel, AccountChartCategory>(model);
            return result;
        }
        #endregion

        #region AccountChartGroup, AccountChartGroupLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static AccountChartCategoryLightViewModel ToLightModel(this AccountChartCategory entity)
        {
            var result = AutoMapper.Mapper.Map<AccountChartCategory, AccountChartCategoryLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        #endregion


        #region VendorType, VendorTypeViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static VendorTypeViewModel ToModel(this VendorType entity)
        {
            var result = AutoMapper.Mapper.Map<VendorType, VendorTypeViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static VendorType ToEntity(this VendorTypeViewModel model)
        {
            var result = AutoMapper.Mapper.Map<VendorTypeViewModel, VendorType>(model);
            return result;
        }
        #endregion

        #region VendorType, VendorTypeLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static VendorTypeLightViewModel ToLightModel(this VendorType entity)
        {
            var result = AutoMapper.Mapper.Map<VendorType, VendorTypeLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static VendorType ToEntity(this VendorTypeLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<VendorTypeLightViewModel, VendorType>(model);
            return result;
        }
        #endregion


        #region Vendor, VendorViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static VendorViewModel ToModel(this Vendor entity)
        {
            var result = AutoMapper.Mapper.Map<Vendor, VendorViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Vendor ToEntity(this VendorViewModel model)
        {
            var result = AutoMapper.Mapper.Map<VendorViewModel, Vendor>(model);
            return result;
        }
        #endregion

        #region Vendor, VendorLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static VendorLightViewModel ToLightModel(this Vendor entity)
        {
            var result = AutoMapper.Mapper.Map<Vendor, VendorLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Vendor ToEntity(this VendorLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<VendorLightViewModel, Vendor>(model);
            return result;
        }
        #endregion


        #region ReceivingMethod, ReceivingMethodViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ReceivingMethodViewModel ToModel(this ReceivingMethod entity)
        {
            var result = AutoMapper.Mapper.Map<ReceivingMethod, ReceivingMethodViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static ReceivingMethod ToEntity(this ReceivingMethodViewModel model)
        {
            var result = AutoMapper.Mapper.Map<ReceivingMethodViewModel, ReceivingMethod>(model);
            return result;
        }
        #endregion

        #region ReceivingMethod, ReceivingMethodLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ReceivingMethodLightViewModel ToLightModel(this ReceivingMethod entity)
        {
            var result = AutoMapper.Mapper.Map<ReceivingMethod, ReceivingMethodLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static ReceivingMethod ToEntity(this ReceivingMethodLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<ReceivingMethodLightViewModel, ReceivingMethod>(model);
            return result;
        }
        #endregion


        #region AccountType, AccountTypeViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static AccountTypeViewModel ToModel(this AccountType entity)
        {
            var result = AutoMapper.Mapper.Map<AccountType, AccountTypeViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static AccountType ToEntity(this AccountTypeViewModel model)
        {
            var result = AutoMapper.Mapper.Map<AccountTypeViewModel, AccountType>(model);
            return result;
        }
        #endregion

        #region AccountType, AccountTypeLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static AccountTypeLightViewModel ToLightModel(this AccountType entity)
        {
            var result = AutoMapper.Mapper.Map<AccountType, AccountTypeLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static AccountType ToEntity(this AccountTypeLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<AccountTypeLightViewModel, AccountType>(model);
            return result;
        }
        #endregion


        #region Branch, BranchViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static BranchViewModel ToModel(this Branch entity)
        {
            var result = AutoMapper.Mapper.Map<Branch, BranchViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Branch ToEntity(this BranchViewModel model)
        {
            var result = AutoMapper.Mapper.Map<BranchViewModel, Branch>(model);
            return result;
        }
        #endregion

        #region Branch, BranchLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static BranchLightViewModel ToLightModel(this Branch entity)
        {
            var result = AutoMapper.Mapper.Map<Branch, BranchLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Branch ToEntity(this BranchLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<BranchLightViewModel, Branch>(model);
            return result;
        }
        #endregion


        #region Donation, DonationViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static DonationViewModel ToModel(this Donation entity)
        {
            var result = AutoMapper.Mapper.Map<Donation, DonationViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Donation ToEntity(this DonationViewModel model)
        {
            var result = AutoMapper.Mapper.Map<DonationViewModel, Donation>(model);
            return result;
        }
        #endregion

        #region Donation, DonationLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static DonationLightViewModel ToLightModel(this Donation entity)
        {
            var result = AutoMapper.Mapper.Map<Donation, DonationLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Donation ToEntity(this DonationLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<DonationLightViewModel, Donation>(model);
            return result;
        }
        #endregion

        #region Donation, AddDonationViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static AddDonationViewModel ToAddModel(this Donation entity)
        {
            var result = AutoMapper.Mapper.Map<Donation, AddDonationViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Donation ToEntity(this AddDonationViewModel model)
        {
            var result = AutoMapper.Mapper.Map<AddDonationViewModel, Donation>(model);
            return result;
        }
        #endregion

        #region Donation, ListDonationLightViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ListDonationLightViewModel ToListModel(this Donation entity)
        {
            var result = AutoMapper.Mapper.Map<Donation, ListDonationLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Donation ToEntity(this ListDonationLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<ListDonationLightViewModel, Donation>(model);
            return result;
        }
        #endregion

        #region Donation, DetailsDonationViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static DetailsDonationViewModel ToDetailsModel(this Donation entity)
        {
            var result = AutoMapper.Mapper.Map<Donation, DetailsDonationViewModel>(entity);
            return result;
        }

        /// <summary>
        /// Converts an entity to DetailsAddmodel.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static AddDonationViewModel ToDetailsAddModel(this Donation entity)
        {
            var result = AutoMapper.Mapper.Map<Donation, AddDonationViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Donation ToEntity(this DetailsDonationViewModel model)
        {
            var result = AutoMapper.Mapper.Map<DetailsDonationViewModel, Donation>(model);
            return result;
        }
        #endregion


        #region PaymentMovment, AddPaymentMovmentViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static AddPaymentMovmentViewModel ToAddModel(this PaymentMovment entity)
        {
            var result = AutoMapper.Mapper.Map<PaymentMovment, AddPaymentMovmentViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static PaymentMovment ToEntity(this AddPaymentMovmentViewModel model)
        {
            var result = AutoMapper.Mapper.Map<AddPaymentMovmentViewModel, PaymentMovment>(model);
            return result;
        }
        #endregion

        #region PaymentMovment, LisPaymentMovmentLightViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ListPaymentMovmentLightViewModel ToListModel(this PaymentMovment entity)
        {
            var result = AutoMapper.Mapper.Map<PaymentMovment, ListPaymentMovmentLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static PaymentMovment ToEntity(this ListPaymentMovmentLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<ListPaymentMovmentLightViewModel, PaymentMovment>(model);
            return result;
        }
        #endregion

        #region PaymentMovment, DetailsPaymentMovmentViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static DetailsPaymentMovmentViewModel ToDetailsModel(this PaymentMovment entity)
        {
            var result = AutoMapper.Mapper.Map<PaymentMovment, DetailsPaymentMovmentViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static PaymentMovment ToEntity(this DetailsPaymentMovmentViewModel model)
        {
            var result = AutoMapper.Mapper.Map<DetailsPaymentMovmentViewModel, PaymentMovment>(model);
            return result;
        }
        #endregion


        #region CurrencyRate, CurrencyRateViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static CurrencyRateViewModel ToModel(this CurrencyRate entity)
        {
            var result = AutoMapper.Mapper.Map<CurrencyRate, CurrencyRateViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static CurrencyRate ToEntity(this CurrencyRateViewModel model)
        {
            var result = AutoMapper.Mapper.Map<CurrencyRateViewModel, CurrencyRate>(model);
            return result;
        }
        #endregion

        #region CurrencyRate, CurrencyRateLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static CurrencyRateLightViewModel ToLightModel(this CurrencyRate entity)
        {
            var result = AutoMapper.Mapper.Map<CurrencyRate, CurrencyRateLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static CurrencyRate ToEntity(this CurrencyRateLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<CurrencyRateLightViewModel, CurrencyRate>(model);
            return result;
        }
        #endregion


        #region Currency, CurrencyViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static CurrencyViewModel ToModel(this Currency entity)
        {
            var result = AutoMapper.Mapper.Map<Currency, CurrencyViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Currency ToEntity(this CurrencyViewModel model)
        {
            var result = AutoMapper.Mapper.Map<CurrencyViewModel, Currency>(model);
            return result;
        }
        #endregion

        #region Currency, CurrencyLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static CurrencyLightViewModel ToLightModel(this Currency entity)
        {
            var result = AutoMapper.Mapper.Map<Currency, CurrencyLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Currency ToEntity(this CurrencyLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<CurrencyLightViewModel, Currency>(model);
            return result;
        }
        #endregion


        #region User, UserViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static UserViewModel ToModel(this User entity)
        {
            var result = AutoMapper.Mapper.Map<User, UserViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static User ToEntity(this UserViewModel model)
        {
            var result = AutoMapper.Mapper.Map<UserViewModel, User>(model);
            return result;
        }
        #endregion

        #region User, UserLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static UserLightViewModel ToLightModel(this User entity)
        {
            var result = AutoMapper.Mapper.Map<User, UserLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static User ToEntity(this UserLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<UserLightViewModel, User>(model);
            return result;
        }
        #endregion


        #region Attachment, AttachmentViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static AttachmentViewModel ToModel(this Attachment entity)
        {
            var result = AutoMapper.Mapper.Map<Attachment, AttachmentViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Attachment ToEntity(this AttachmentViewModel model)
        {
            var result = AutoMapper.Mapper.Map<AttachmentViewModel, Attachment>(model);
            return result;
        }
        #endregion

        #region Attachment, AttachmentLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static AttachmentLightViewModel ToLightModel(this Attachment entity)
        {
            var result = AutoMapper.Mapper.Map<Attachment, AttachmentLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Attachment ToEntity(this AttachmentLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<AttachmentLightViewModel, Attachment>(model);
            return result;
        }
        #endregion


        #region Country, CountryViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static CountryViewModel ToModel(this Country entity)
        {
            var result = AutoMapper.Mapper.Map<Country, CountryViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Country ToEntity(this CountryViewModel model)
        {
            var result = AutoMapper.Mapper.Map<CountryViewModel, Country>(model);
            return result;
        }
        #endregion

        #region Country, CountryLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static CountryLightViewModel ToLightModel(this Country entity)
        {
            var result = AutoMapper.Mapper.Map<Country, CountryLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Country ToEntity(this CountryLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<CountryLightViewModel, Country>(model);
            return result;
        }
        #endregion


        #region City, CityViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static CityViewModel ToModel(this City entity)
        {
            var result = AutoMapper.Mapper.Map<City, CityViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static City ToEntity(this CityViewModel model)
        {
            var result = AutoMapper.Mapper.Map<CityViewModel, City>(model);
            return result;
        }
        #endregion

        #region City, CityLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static CityLightViewModel ToLightModel(this City entity)
        {
            var result = AutoMapper.Mapper.Map<City, CityLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static City ToEntity(this CityLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<CityLightViewModel, City>(model);
            return result;
        }
        #endregion


        #region District, DistrictViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static DistrictViewModel ToModel(this District entity)
        {
            var result = AutoMapper.Mapper.Map<District, DistrictViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static District ToEntity(this DistrictViewModel model)
        {
            var result = AutoMapper.Mapper.Map<DistrictViewModel, District>(model);
            return result;
        }
        #endregion

        #region District, DistrictLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static DistrictLightViewModel ToLightModel(this District entity)
        {
            var result = AutoMapper.Mapper.Map<District, DistrictLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static District ToEntity(this DistrictLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<DistrictLightViewModel, District>(model);
            return result;
        }
        #endregion


        #region StockAssessmentPolicy, StockAssessmentPolicyViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static StockAssessmentPolicyViewModel ToModel(this StockAssessmentPolicy entity)
        {
            var result = AutoMapper.Mapper.Map<StockAssessmentPolicy, StockAssessmentPolicyViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static StockAssessmentPolicy ToEntity(this StockAssessmentPolicyViewModel model)
        {
            var result = AutoMapper.Mapper.Map<StockAssessmentPolicyViewModel, StockAssessmentPolicy>(model);
            return result;
        }
        #endregion

        #region StockAssessmentPolicy, StockAssessmentPolicyLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static StockAssessmentPolicyLightViewModel ToLightModel(this StockAssessmentPolicy entity)
        {
            var result = AutoMapper.Mapper.Map<StockAssessmentPolicy, StockAssessmentPolicyLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static StockAssessmentPolicy ToEntity(this StockAssessmentPolicyLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<StockAssessmentPolicyLightViewModel, StockAssessmentPolicy>(model);
            return result;
        }
        #endregion


        #region Mail, MailViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static MailViewModel ToModel(this Mail entity)
        {
            var result = AutoMapper.Mapper.Map<Mail, MailViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Mail ToEntity(this MailViewModel model)
        {
            var result = AutoMapper.Mapper.Map<MailViewModel, Mail>(model);
            return result;
        }
        #endregion

        #region Mail, MailLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static MailLightViewModel ToLightModel(this Mail entity)
        {
            var result = AutoMapper.Mapper.Map<Mail, MailLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Mail ToEntity(this MailLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<MailLightViewModel, Mail>(model);
            return result;
        }
        #endregion


        #region Mobile, MobileViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static MobileViewModel ToModel(this Mobile entity)
        {
            var result = AutoMapper.Mapper.Map<Mobile, MobileViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Mobile ToEntity(this MobileViewModel model)
        {
            var result = AutoMapper.Mapper.Map<MobileViewModel, Mobile>(model);
            return result;
        }
        #endregion

        #region Mobile, MobileLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static MobileLightViewModel ToLightModel(this Mobile entity)
        {
            var result = AutoMapper.Mapper.Map<Mobile, MobileLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Mobile ToEntity(this MobileLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<MobileLightViewModel, Mobile>(model);
            return result;
        }
        #endregion


        #region BankMovement, BankMovementViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static BankMovementViewModel ToModel(this BankMovement entity)
        {
            var result = AutoMapper.Mapper.Map<BankMovement, BankMovementViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static BankMovement ToEntity(this BankMovementViewModel model)
        {
            var result = AutoMapper.Mapper.Map<BankMovementViewModel, BankMovement>(model);
            return result;
        }
        #endregion

        #region BankMovement, BankMovementLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static BankMovementLightViewModel ToLightModel(this BankMovement entity)
        {
            var result = AutoMapper.Mapper.Map<BankMovement, BankMovementLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static BankMovement ToEntity(this BankMovementLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<BankMovementLightViewModel, BankMovement>(model);
            return result;
        }
        #endregion

        #region BankMovement, ListBankMovementsLightViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ListBankMovementsLightViewModel ToListModel(this BankMovement entity)
        {
            var result = AutoMapper.Mapper.Map<BankMovement, ListBankMovementsLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static BankMovement ToEntity(this ListBankMovementsLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<ListBankMovementsLightViewModel, BankMovement>(model);
            return result;
        }
        #endregion


        #region Transfer, TransferViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static TransferViewModel ToModel(this Transfer entity)
        {
            var result = AutoMapper.Mapper.Map<Transfer, TransferViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Transfer ToEntity(this TransferViewModel model)
        {
            var result = AutoMapper.Mapper.Map<TransferViewModel, Transfer>(model);
            return result;
        }
        #endregion

        #region Transfer, TransferLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static TransferLightViewModel ToLightModel(this Transfer entity)
        {
            var result = AutoMapper.Mapper.Map<Transfer, TransferLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Transfer ToEntity(this TransferLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<TransferLightViewModel, Transfer>(model);
            return result;
        }
        #endregion


        #region MeasurementUnit, MeasurementUnitViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static MeasurementUnitViewModel ToModel(this MeasurementUnit entity)
        {
            var result = AutoMapper.Mapper.Map<MeasurementUnit, MeasurementUnitViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static MeasurementUnit ToEntity(this MeasurementUnitViewModel model)
        {
            var result = AutoMapper.Mapper.Map<MeasurementUnitViewModel, MeasurementUnit>(model);
            return result;
        }
        #endregion

        #region MeasurementUnit, MeasurementUnitLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static MeasurementUnitLightViewModel ToLightModel(this MeasurementUnit entity)
        {
            var result = AutoMapper.Mapper.Map<MeasurementUnit, MeasurementUnitLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static MeasurementUnit ToEntity(this MeasurementUnitLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<MeasurementUnitLightViewModel, MeasurementUnit>(model);
            return result;
        }
        #endregion


        #region InventoryTransfer, InventoryTransferViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static InventoryTransferViewModel ToModel(this InventoryTransfer entity)
        {
            var result = AutoMapper.Mapper.Map<InventoryTransfer, InventoryTransferViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static InventoryTransfer ToEntity(this InventoryTransferViewModel model)
        {
            var result = AutoMapper.Mapper.Map<InventoryTransferViewModel, InventoryTransfer>(model);
            return result;
        }
        #endregion

        #region InventoryTransfer, InventoryTransferLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static InventoryTransferLightViewModel ToLightModel(this InventoryTransfer entity)
        {
            var result = AutoMapper.Mapper.Map<InventoryTransfer, InventoryTransferLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static InventoryTransfer ToEntity(this InventoryTransferLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<InventoryTransferLightViewModel, InventoryTransfer>(model);
            return result;
        }
        #endregion

        #region InventoryTransferCostCenter, InventoryTransferCostCenterViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static InventoryTransferCostCenterViewModel ToModel(this InventoryTransferCostCenter entity)
        {
            var result = AutoMapper.Mapper.Map<InventoryTransferCostCenter, InventoryTransferCostCenterViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static InventoryTransferCostCenter ToEntity(this InventoryTransferCostCenterViewModel model)
        {
            var result = AutoMapper.Mapper.Map<InventoryTransferCostCenterViewModel, InventoryTransferCostCenter>(model);
            return result;
        }
        #endregion

        #region InventoryMovement, InventoryMovementViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static InventoryMovementViewModel ToModel(this InventoryMovement entity)
        {
            var result = AutoMapper.Mapper.Map<InventoryMovement, InventoryMovementViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static InventoryMovement ToEntity(this InventoryMovementViewModel model)
        {
            var result = AutoMapper.Mapper.Map<InventoryMovementViewModel, InventoryMovement>(model);
            return result;
        }
        #endregion

        #region InventoryMovement, InventoryMovementLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static InventoryMovementLightViewModel ToLightModel(this InventoryMovement entity)
        {
            var result = AutoMapper.Mapper.Map<InventoryMovement, InventoryMovementLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static InventoryMovement ToEntity(this InventoryMovementLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<InventoryMovementLightViewModel, InventoryMovement>(model);
            return result;
        }
        #endregion

        #region InventoryMovementCostCenter, InventoryMovementCostCenterViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static InventoryMovementCostCenterViewModel ToModel(this InventoryMovementCostCenter entity)
        {
            var result = AutoMapper.Mapper.Map<InventoryMovementCostCenter, InventoryMovementCostCenterViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static InventoryMovementCostCenter ToEntity(this InventoryMovementCostCenterViewModel model)
        {
            var result = AutoMapper.Mapper.Map<InventoryMovementCostCenterViewModel, InventoryMovementCostCenter>(model);
            return result;
        }
        #endregion


        #region InventoryMovementType, InventoryMovementTypeViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static InventoryMovementTypeViewModel ToModel(this InventoryMovementType entity)
        {
            var result = AutoMapper.Mapper.Map<InventoryMovementType, InventoryMovementTypeViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static InventoryMovementType ToEntity(this InventoryMovementTypeViewModel model)
        {
            var result = AutoMapper.Mapper.Map<InventoryMovementTypeViewModel, InventoryMovementType>(model);
            return result;
        }
        #endregion

        #region InventoryMovementType,InventoryMovementTypeLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static InventoryMovementTypeLightViewModel ToLightModel(this InventoryMovementType entity)
        {
            var result = AutoMapper.Mapper.Map<InventoryMovementType, InventoryMovementTypeLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static InventoryMovementType ToEntity(this InventoryMovementTypeLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<InventoryMovementTypeLightViewModel, InventoryMovementType>(model);
            return result;
        }
        #endregion

        #region InventoryIn, InventoryInViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static InventoryInViewModel ToModel(this InventoryIn entity)
        {
            var result = AutoMapper.Mapper.Map<InventoryIn, InventoryInViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static InventoryIn ToEntity(this InventoryInViewModel model)
        {
            var result = AutoMapper.Mapper.Map<InventoryInViewModel, InventoryIn>(model);
            return result;
        }
        #endregion

        #region InventoryIn, InventoryInLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static InventoryInLightViewModel ToLightModel(this InventoryIn entity)
        {
            var result = AutoMapper.Mapper.Map<InventoryIn, InventoryInLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static InventoryIn ToEntity(this InventoryInLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<InventoryInLightViewModel, InventoryIn>(model);
            return result;
        }
        #endregion


        #region InventoryOut, InventoryOutViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static InventoryOutViewModel ToModel(this InventoryOut entity)
        {
            var result = AutoMapper.Mapper.Map<InventoryOut, InventoryOutViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static InventoryOut ToEntity(this InventoryOutViewModel model)
        {
            var result = AutoMapper.Mapper.Map<InventoryOutViewModel, InventoryOut>(model);
            return result;
        }
        #endregion

        #region InventoryOut, InventoryOutLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static InventoryOutLightViewModel ToLightModel(this InventoryOut entity)
        {
            var result = AutoMapper.Mapper.Map<InventoryOut, InventoryOutLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static InventoryOut ToEntity(this InventoryOutLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<InventoryOutLightViewModel, InventoryOut>(model);
            return result;
        }
        #endregion


        #region InventoryDifference, InventoryDifferenceViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static InventoryDifferenceViewModel ToModel(this InventoryDifference entity)
        {
            var result = AutoMapper.Mapper.Map<InventoryDifference, InventoryDifferenceViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static InventoryDifference ToEntity(this InventoryDifferenceViewModel model)
        {
            var result = AutoMapper.Mapper.Map<InventoryDifferenceViewModel, InventoryDifference>(model);
            return result;
        }
        #endregion

        #region InventoryDifference, InventoryDifferenceLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static InventoryDifferenceLightViewModel ToLightModel(this InventoryDifference entity)
        {
            var result = AutoMapper.Mapper.Map<InventoryDifference, InventoryDifferenceLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static InventoryDifference ToEntity(this InventoryDifferenceLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<InventoryDifferenceLightViewModel, InventoryDifference>(model);
            return result;
        }
        #endregion


        #region PaymentMovment, PaymentMovmentViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static PaymentMovmentViewModel ToModel(this PaymentMovment entity)
        {
            var result = AutoMapper.Mapper.Map<PaymentMovment, PaymentMovmentViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static PaymentMovment ToEntity(this PaymentMovmentViewModel model)
        {
            var result = AutoMapper.Mapper.Map<PaymentMovmentViewModel, PaymentMovment>(model);
            return result;
        }
        #endregion

        #region PaymentMovment, PaymentMovmentLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static PaymentMovmentLightViewModel ToLightModel(this PaymentMovment entity)
        {
            var result = AutoMapper.Mapper.Map<PaymentMovment, PaymentMovmentLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static PaymentMovment ToEntity(this PaymentMovmentLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<PaymentMovmentLightViewModel, PaymentMovment>(model);
            return result;
        }
        #endregion


        #region DonationType, DonationTypeViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static DonationTypeViewModel ToModel(this DonationType entity)
        {
            var result = AutoMapper.Mapper.Map<DonationType, DonationTypeViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static DonationType ToEntity(this DonationTypeViewModel model)
        {
            var result = AutoMapper.Mapper.Map<DonationTypeViewModel, DonationType>(model);
            return result;
        }
        #endregion

        #region DonationType, DonationTypeLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static DonationTypeLightViewModel ToLightModel(this DonationType entity)
        {
            var result = AutoMapper.Mapper.Map<DonationType, DonationTypeLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static DonationType ToEntity(this DonationTypeLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<DonationTypeLightViewModel, DonationType>(model);
            return result;
        }
        #endregion


        #region Setting, SettingViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static SettingViewModel ToModel(this Setting entity)
        {
            var result = AutoMapper.Mapper.Map<Setting, SettingViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Setting ToEntity(this SettingViewModel model)
        {
            var result = AutoMapper.Mapper.Map<SettingViewModel, Setting>(model);
            return result;
        }
        #endregion

        #region Setting, SettingLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static SettingLightViewModel ToLightModel(this Setting entity)
        {
            var result = AutoMapper.Mapper.Map<Setting, SettingLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Setting ToEntity(this SettingLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<SettingLightViewModel, Setting>(model);
            return result;
        }
        #endregion


        #region JournalType, JournalTypeViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static JournalTypeViewModel ToModel(this JournalType entity)
        {
            var result = AutoMapper.Mapper.Map<JournalType, JournalTypeViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static JournalType ToEntity(this JournalTypeViewModel model)
        {
            var result = AutoMapper.Mapper.Map<JournalTypeViewModel, JournalType>(model);
            return result;
        }
        #endregion

        #region JournalType, JournalTypeLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static JournalTypeLightViewModel ToLightModel(this JournalType entity)
        {
            var result = AutoMapper.Mapper.Map<JournalType, JournalTypeLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static JournalType ToEntity(this JournalTypeLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<JournalTypeLightViewModel, JournalType>(model);
            return result;
        }
        #endregion


        #region PurchaseInvoiceType, PurchaseInvoiceTypeViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static PurchaseInvoiceTypeViewModel ToModel(this PurchaseInvoiceType entity)
        {
            var result = AutoMapper.Mapper.Map<PurchaseInvoiceType, PurchaseInvoiceTypeViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static PurchaseInvoiceType ToEntity(this PurchaseInvoiceTypeViewModel model)
        {
            var result = AutoMapper.Mapper.Map<PurchaseInvoiceTypeViewModel, PurchaseInvoiceType>(model);
            return result;
        }
        #endregion

        #region PurchaseInvoiceType, PurchaseInvoiceTypeLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static PurchaseInvoiceTypeLightViewModel ToLightModel(this PurchaseInvoiceType entity)
        {
            var result = AutoMapper.Mapper.Map<PurchaseInvoiceType, PurchaseInvoiceTypeLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static PurchaseInvoiceType ToEntity(this PurchaseInvoiceTypeLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<PurchaseInvoiceTypeLightViewModel, PurchaseInvoiceType>(model);
            return result;
        }
        #endregion


        #region PurchaseInvoiceCostCenter, PurchaseInvoiceCostCenterViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static PurchaseInvoiceCostCenterViewModel ToModel(this PurchaseInvoiceCostCenter entity)
        {
            var result = AutoMapper.Mapper.Map<PurchaseInvoiceCostCenter, PurchaseInvoiceCostCenterViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static PurchaseInvoiceCostCenter ToEntity(this PurchaseInvoiceCostCenterViewModel model)
        {
            var result = AutoMapper.Mapper.Map<PurchaseInvoiceCostCenterViewModel, PurchaseInvoiceCostCenter>(model);
            return result;
        }
        #endregion

        #region PurchaseInvoiceCostCenter, PurchaseInvoiceCostCenterLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static PurchaseInvoiceCostCenterLightViewModel ToLightModel(this PurchaseInvoiceCostCenter entity)
        {
            var result = AutoMapper.Mapper.Map<PurchaseInvoiceCostCenter, PurchaseInvoiceCostCenterLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static PurchaseInvoiceCostCenter ToEntity(this PurchaseInvoiceCostCenterLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<PurchaseInvoiceCostCenterLightViewModel, PurchaseInvoiceCostCenter>(model);
            return result;
        }
        #endregion


        #region PurchaseRebateCostCenter, PurchaseRebateCostCenterViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static PurchaseRebateCostCenterViewModel ToModel(this PurchaseRebateCostCenter entity)
        {
            var result = AutoMapper.Mapper.Map<PurchaseRebateCostCenter, PurchaseRebateCostCenterViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static PurchaseRebateCostCenter ToEntity(this PurchaseRebateCostCenterViewModel model)
        {
            var result = AutoMapper.Mapper.Map<PurchaseRebateCostCenterViewModel, PurchaseRebateCostCenter>(model);
            return result;
        }
        #endregion

        #region PurchaseRebateCostCenter, PurchaseRebateCostCenterLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static PurchaseRebateCostCenterLightViewModel ToLightModel(this PurchaseRebateCostCenter entity)
        {
            var result = AutoMapper.Mapper.Map<PurchaseRebateCostCenter, PurchaseRebateCostCenterLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static PurchaseRebateCostCenter ToEntity(this PurchaseRebateCostCenterLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<PurchaseRebateCostCenterLightViewModel, PurchaseRebateCostCenter>(model);
            return result;
        }
        #endregion


        #region AccountChartLevelSetting, AccountChartLevelSettingViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static AccountChartLevelSettingViewModel ToModel(this AccountChartLevelSetting entity)
        {
            var result = AutoMapper.Mapper.Map<AccountChartLevelSetting, AccountChartLevelSettingViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static AccountChartLevelSetting ToEntity(this AccountChartLevelSettingViewModel model)
        {
            var result = AutoMapper.Mapper.Map<AccountChartLevelSettingViewModel, AccountChartLevelSetting>(model);
            return result;
        }
        #endregion

        #region AccountChartLevelSetting, AccountChartLevelSettingLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static AccountChartLevelSettingLightViewModel ToLightModel(this AccountChartLevelSetting entity)
        {
            var result = AutoMapper.Mapper.Map<AccountChartLevelSetting, AccountChartLevelSettingLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static AccountChartLevelSetting ToEntity(this AccountChartLevelSettingLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<AccountChartLevelSettingLightViewModel, AccountChartLevelSetting>(model);
            return result;
        }
        #endregion


        #region Brand, BrandViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static BrandViewModel ToModel(this Brand entity)
        {
            var result = AutoMapper.Mapper.Map<Brand, BrandViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Brand ToEntity(this BrandViewModel model)
        {
            var result = AutoMapper.Mapper.Map<BrandViewModel, Brand>(model);
            return result;
        }
        #endregion

        #region Brand, BrandLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static BrandLightViewModel ToLightModel(this Brand entity)
        {
            var result = AutoMapper.Mapper.Map<Brand, BrandLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Brand ToEntity(this BrandLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<BrandLightViewModel, Brand>(model);
            return result;
        }
        #endregion





        #region StoreMovement, StoreMovementViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static StoreMovementViewModel ToModel(this StoreMovement entity)
        {
            var result = AutoMapper.Mapper.Map<StoreMovement, StoreMovementViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static StoreMovement ToEntity(this StoreMovementViewModel model)
        {
            var result = AutoMapper.Mapper.Map<StoreMovementViewModel, StoreMovement>(model);
            return result;
        }
        #endregion

        #region StoreMovement, StoreMovementLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static StoreMovementLightViewModel ToLightModel(this StoreMovement entity)
        {
            var result = AutoMapper.Mapper.Map<StoreMovement, StoreMovementLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static StoreMovement ToEntity(this StoreMovementLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<StoreMovementLightViewModel, StoreMovement>(model);
            return result;
        }
        #endregion


        #region JournalPosting, JournalPostingViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static JournalPostingViewModel ToModel(this JournalPosting entity)
        {
            var result = AutoMapper.Mapper.Map<JournalPosting, JournalPostingViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static JournalPosting ToEntity(this JournalPostingViewModel model)
        {
            var result = AutoMapper.Mapper.Map<JournalPostingViewModel, JournalPosting>(model);
            return result;
        }
        #endregion

        #region JournalPosting, JournalPostingLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static JournalPostingLightViewModel ToLightModel(this JournalPosting entity)
        {
            var result = AutoMapper.Mapper.Map<JournalPosting, JournalPostingLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static JournalPosting ToEntity(this JournalPostingLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<JournalPostingLightViewModel, JournalPosting>(model);
            return result;
        }
        #endregion

        #region JournalPosting, ListJournalPostingLightViewModel
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ListJournalPostingLightViewModel ToListModel(this JournalPosting entity)
        {
            var result = AutoMapper.Mapper.Map<JournalPosting, ListJournalPostingLightViewModel>(entity);
            return result;
        }
        #endregion


        #region FiscalYear, FiscalYearViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static FiscalYearViewModel ToModel(this FiscalYear entity)
        {
            var result = AutoMapper.Mapper.Map<FiscalYear, FiscalYearViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static FiscalYear ToEntity(this FiscalYearViewModel model)
        {
            var result = AutoMapper.Mapper.Map<FiscalYearViewModel, FiscalYear>(model);
            return result;
        }
        #endregion

        #region FiscalYear, FiscalYearLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static FiscalYearLightViewModel ToLightModel(this FiscalYear entity)
        {
            var result = AutoMapper.Mapper.Map<FiscalYear, FiscalYearLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static FiscalYear ToEntity(this FiscalYearLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<FiscalYearLightViewModel, FiscalYear>(model);
            return result;
        }
        #endregion


        #region Location, LocationViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static LocationViewModel ToModel(this Location entity)
        {
            var result = AutoMapper.Mapper.Map<Location, LocationViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Location ToEntity(this LocationViewModel model)
        {
            var result = AutoMapper.Mapper.Map<LocationViewModel, Location>(model);
            return result;
        }
        #endregion

        #region Location, LocationLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static LocationLightViewModel ToLightModel(this Location entity)
        {
            var result = AutoMapper.Mapper.Map<Location, LocationLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Location ToEntity(this LocationLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<LocationLightViewModel, Location>(model);
            return result;
        }
        #endregion


        #region DepreciationRate, DepreciationRateViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static DepreciationRateViewModel ToModel(this DepreciationRate entity)
        {
            var result = AutoMapper.Mapper.Map<DepreciationRate, DepreciationRateViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static DepreciationRate ToEntity(this DepreciationRateViewModel model)
        {
            var result = AutoMapper.Mapper.Map<DepreciationRateViewModel, DepreciationRate>(model);
            return result;
        }
        #endregion

        #region DepreciationRate, DepreciationRateLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static DepreciationRateLightViewModel ToLightModel(this DepreciationRate entity)
        {
            var result = AutoMapper.Mapper.Map<DepreciationRate, DepreciationRateLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static DepreciationRate ToEntity(this DepreciationRateLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<DepreciationRateLightViewModel, DepreciationRate>(model);
            return result;
        }
        #endregion


        #region DepreciationType, DepreciationTypeViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static DepreciationTypeViewModel ToModel(this DepreciationType entity)
        {
            var result = AutoMapper.Mapper.Map<DepreciationType, DepreciationTypeViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static DepreciationType ToEntity(this DepreciationTypeViewModel model)
        {
            var result = AutoMapper.Mapper.Map<DepreciationTypeViewModel, DepreciationType>(model);
            return result;
        }
        #endregion

        #region DepreciationType, DepreciationTypeLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static DepreciationTypeLightViewModel ToLightModel(this DepreciationType entity)
        {
            var result = AutoMapper.Mapper.Map<DepreciationType, DepreciationTypeLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static DepreciationType ToEntity(this DepreciationTypeLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<DepreciationTypeLightViewModel, DepreciationType>(model);
            return result;
        }
        #endregion


        #region ExpensesType, ExpensesTypeViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ExpensesTypeViewModel ToModel(this ExpensesType entity)
        {
            var result = AutoMapper.Mapper.Map<ExpensesType, ExpensesTypeViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static ExpensesType ToEntity(this ExpensesTypeViewModel model)
        {
            var result = AutoMapper.Mapper.Map<ExpensesTypeViewModel, ExpensesType>(model);
            return result;
        }
        #endregion

        #region ExpensesType, ExpensesTypeLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ExpensesTypeLightViewModel ToLightModel(this ExpensesType entity)
        {
            var result = AutoMapper.Mapper.Map<ExpensesType, ExpensesTypeLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static ExpensesType ToEntity(this ExpensesTypeLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<ExpensesTypeLightViewModel, ExpensesType>(model);
            return result;
        }
        #endregion


        #region Expense, ExpenseViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ExpenseViewModel ToModel(this Expense entity)
        {
            var result = AutoMapper.Mapper.Map<Expense, ExpenseViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Expense ToEntity(this ExpenseViewModel model)
        {
            var result = AutoMapper.Mapper.Map<ExpenseViewModel, Expense>(model);
            return result;
        }
        #endregion

        #region Expense, ExpenseLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ExpenseLightViewModel ToLightModel(this Expense entity)
        {
            var result = AutoMapper.Mapper.Map<Expense, ExpenseLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Expense ToEntity(this ExpenseLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<ExpenseLightViewModel, Expense>(model);
            return result;
        }
        #endregion


        #region AssetInventory, AssetInventoryViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static AssetInventoryViewModel ToModel(this AssetInventory entity)
        {
            var result = AutoMapper.Mapper.Map<AssetInventory, AssetInventoryViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static AssetInventory ToEntity(this AssetInventoryViewModel model)
        {
            var result = AutoMapper.Mapper.Map<AssetInventoryViewModel, AssetInventory>(model);
            return result;
        }
        #endregion

        #region AssetInventory, AssetInventoryLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static AssetInventoryLightViewModel ToLightModel(this AssetInventory entity)
        {
            var result = AutoMapper.Mapper.Map<AssetInventory, AssetInventoryLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static AssetInventory ToEntity(this AssetInventoryLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<AssetInventoryLightViewModel, AssetInventory>(model);
            return result;
        }
        #endregion



        #region AssetInventoryDetail, AssetInventoryDetailViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static AssetInventoryDetailViewModel ToModel(this AssetInventoryDetail entity)
        {
            var result = AutoMapper.Mapper.Map<AssetInventoryDetail, AssetInventoryDetailViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static AssetInventoryDetail ToEntity(this AssetInventoryDetailViewModel model)
        {
            var result = AutoMapper.Mapper.Map<AssetInventoryDetailViewModel, AssetInventoryDetail>(model);
            return result;
        }
        #endregion

        #region AssetInventoryDetail, AssetInventoryDetailLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static AssetInventoryDetailLightViewModel ToLightModel(this AssetInventoryDetail entity)
        {
            var result = AutoMapper.Mapper.Map<AssetInventoryDetail, AssetInventoryDetailLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static AssetInventoryDetail ToEntity(this AssetInventoryDetailLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<AssetInventoryDetailLightViewModel, AssetInventoryDetail>(model);
            return result;
        }
        #endregion




        #region Donation, ChecksUnderCollectionViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ChecksUnderCollectionViewModel ToChecksUnderCollectionModel(this Donation entity)
        {
            var result = AutoMapper.Mapper.Map<Donation, ChecksUnderCollectionViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Donation ToEntity(this ChecksUnderCollectionViewModel model)
        {
            var result = AutoMapper.Mapper.Map<ChecksUnderCollectionViewModel, Donation>(model);
            return result;
        }
        #endregion


        #region Bank, ListBankLightViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ListBankLightViewModel ToListModel(this Bank entity)
        {
            var result = AutoMapper.Mapper.Map<Bank, ListBankLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Bank ToEntity(this ListBankLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<ListBankLightViewModel, Bank>(model);
            return result;
        }
        #endregion

        #region Vendor, ListVendorsLightViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ListVendorsLightViewModel ToListModel(this Vendor entity)
        {
            var result = AutoMapper.Mapper.Map<Vendor, ListVendorsLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Vendor ToEntity(this ListVendorsLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<ListVendorsLightViewModel, Vendor>(model);
            return result;
        }
        #endregion

        #region CurrencyRate, ListCurrencyRateLightViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ListCurrencyRateLightViewModel ToListModel(this CurrencyRate entity)
        {
            var result = AutoMapper.Mapper.Map<CurrencyRate, ListCurrencyRateLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static CurrencyRate ToEntity(this ListCurrencyRateLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<ListCurrencyRateLightViewModel, CurrencyRate>(model);
            return result;
        }
        #endregion

        #region Currency, ListCurrencyLightViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ListCurrencyLightViewModel ToListModel(this Currency entity)
        {
            var result = AutoMapper.Mapper.Map<Currency, ListCurrencyLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Currency ToEntity(this ListCurrencyLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<ListCurrencyLightViewModel, Currency>(model);
            return result;
        }
        #endregion

        #region CostCenter
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ListCostCenterLightViewModel ToListModel(this CostCenter entity)
        {
            var result = AutoMapper.Mapper.Map<CostCenter, ListCostCenterLightViewModel>(entity);
            return result;
        }
        #endregion

        #region Branch, ListBranchsLightViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ListBranchsLightViewModel ToListModel(this Branch entity)
        {
            var result = AutoMapper.Mapper.Map<Branch, ListBranchsLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Branch ToEntity(this ListBranchsLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<ListBranchsLightViewModel, Branch>(model);
            return result;
        }
        #endregion

        #region Brand, ListBrandsLightViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ListBrandsLightViewModel ToListModel(this Brand entity)
        {
            var result = AutoMapper.Mapper.Map<Brand, ListBrandsLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Brand ToEntity(this ListBrandsLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<ListBrandsLightViewModel, Brand>(model);
            return result;
        }
        #endregion

        #region MeasurementUnit, ListMeasurementUnitsLightViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ListMeasurementUnitsLightViewModel ToListModel(this MeasurementUnit entity)
        {
            var result = AutoMapper.Mapper.Map<MeasurementUnit, ListMeasurementUnitsLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static MeasurementUnit ToEntity(this ListMeasurementUnitsLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<ListMeasurementUnitsLightViewModel, MeasurementUnit>(model);
            return result;
        }
        #endregion

        #region Safe, ListSafesLightViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ListSafesLightViewModel ToListModel(this Safe entity)
        {
            var result = AutoMapper.Mapper.Map<Safe, ListSafesLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Safe ToEntity(this ListSafesLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<ListSafesLightViewModel, Safe>(model);
            return result;
        }
        #endregion

        #region DelegateMan, ListDelegateMansLightViewModel
        ///// <summary>
        ///// Converts an entity to model.
        ///// </summary>
        ///// <param name="entity"></param>
        ///// <returns></returns>
        public static ListDelegateMensLightViewModel ToListModel(this DelegateMan entity)
        {
            var result = AutoMapper.Mapper.Map<DelegateMan, ListDelegateMensLightViewModel>(entity);
            return result;
        }
        ///// <summary>
        ///// Converts a model to an entity.
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        public static DelegateMan ToEntity(this ListDelegateMensLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<ListDelegateMensLightViewModel, DelegateMan>(model);
            return result;
        }
        #endregion

        #region Permission, ListPermissionsLightViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ListPermissionsLightViewModel ToListModel(this Permission entity)
        {
            var result = AutoMapper.Mapper.Map<Permission, ListPermissionsLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Permission ToEntity(this ListPermissionsLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<ListPermissionsLightViewModel, Permission>(model);
            return result;
        }
        #endregion

        #region MenuItem, ListMenuItemsLightViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ListMenuItemsLightViewModel ToListModel(this MenuItem entity)
        {
            var result = AutoMapper.Mapper.Map<MenuItem, ListMenuItemsLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static MenuItem ToEntity(this ListMenuItemsLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<ListMenuItemsLightViewModel, MenuItem>(model);
            return result;
        }
        #endregion

        #region Role, ListRolesLightViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ListRolesLightViewModel ToListModel(this Role entity)
        {
            var result = AutoMapper.Mapper.Map<Role, ListRolesLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Role ToEntity(this ListRolesLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<ListRolesLightViewModel, Role>(model);
            return result;
        }
        #endregion

        #region Group, ListGroupsLightViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ListGroupsLightViewModel ToListModel(this Group entity)
        {
            var result = AutoMapper.Mapper.Map<Group, ListGroupsLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Group ToEntity(this ListGroupsLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<ListGroupsLightViewModel, Group>(model);
            return result;
        }
        #endregion

        #region User, ListUsersLightViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ListUsersLightViewModel ToListModel(this User entity)
        {
            var result = AutoMapper.Mapper.Map<User, ListUsersLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static User ToEntity(this ListUsersLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<ListUsersLightViewModel, User>(model);
            return result;
        }
        #endregion

        #region Asset, ListAssetLightViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ListAssetLightViewModel ToListModel(this Asset entity)
        {
            var result = AutoMapper.Mapper.Map<Asset, ListAssetLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Asset ToEntity(this ListAssetLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<ListAssetLightViewModel, Asset>(model);
            return result;
        }
        #endregion

        #region Expense, ListExpenseLightViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ListExpenseLightViewModel ToListModel(this Expense entity)
        {
            var result = AutoMapper.Mapper.Map<Expense, ListExpenseLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Expense ToEntity(this ListExpenseLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<ListExpenseLightViewModel, Expense>(model);
            return result;
        }
        #endregion

        #region Depreciation, ListDepreciationtViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ListDepreciationViewModel ToListModel(this Depreciation entity)
        {
            var result = AutoMapper.Mapper.Map<Depreciation, ListDepreciationViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Depreciation ToEntity(this ListDepreciationViewModel model)
        {
            var result = AutoMapper.Mapper.Map<ListDepreciationViewModel, Depreciation>(model);
            return result;
        }

        public static DepreciationLightViewModel ToLightModel(this Depreciation entity)
        {
            var result = AutoMapper.Mapper.Map<Depreciation, DepreciationLightViewModel>(entity);
            return result;
        }
        #endregion

        #region Depreciation, DepreciationViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static DepreciationViewModel ToModel(this Depreciation entity)
        {
            var result = AutoMapper.Mapper.Map<Depreciation, DepreciationViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Depreciation ToEntity(this DepreciationViewModel model)
        {
            var result = AutoMapper.Mapper.Map<DepreciationViewModel, Depreciation>(model);
            return result;
        }
        #endregion

        #region Exclude, ListExcludeViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ListExcludeLightViewModel ToListModel(this Exclude entity)
        {
            var result = AutoMapper.Mapper.Map<Exclude, ListExcludeLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Exclude ToEntity(this ListExcludeLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<ListExcludeLightViewModel, Exclude>(model);
            return result;
        }

        public static ExcludeLightViewModel ToLightModel(this Exclude entity)
        {
            var result = AutoMapper.Mapper.Map<Exclude, ExcludeLightViewModel>(entity);
            return result;
        }
        #endregion

        #region Exclude, ExcludeViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ExcludeViewModel ToModel(this Exclude entity)
        {
            var result = AutoMapper.Mapper.Map<Exclude, ExcludeViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Exclude ToEntity(this ExcludeViewModel model)
        {
            var result = AutoMapper.Mapper.Map<ExcludeViewModel, Exclude>(model);
            return result;
        }
        #endregion

        #region Exclude, ListExcludeViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ListExcludeLightViewModel ToExcludeListModel(this Asset entity)
        {
            var result = AutoMapper.Mapper.Map<Asset, ListExcludeLightViewModel>(entity);
            return result;
        }
        #endregion

        #region AssetInventory, ListAssetInventorysLightViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ListAssetInventorysLightViewModel ToListModel(this AssetInventory entity)
        {
            var result = AutoMapper.Mapper.Map<AssetInventory, ListAssetInventorysLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static AssetInventory ToEntity(this ListAssetInventorysLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<ListAssetInventorysLightViewModel, AssetInventory>(model);
            return result;
        }

        public static AssetInventoryDetailLightViewModel ToAssetInventoryDetail(this Asset entity)
        {
            var result = AutoMapper.Mapper.Map<Asset, AssetInventoryDetailLightViewModel>(entity);
            return result;
        }
        #endregion

        #region Location, ListLocationsLightViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ListLocationsLightViewModel ToListModel(this Location entity)
        {
            var result = AutoMapper.Mapper.Map<Location, ListLocationsLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Location ToEntity(this ListLocationsLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<ListLocationsLightViewModel, Location>(model);
            return result;
        }
        #endregion

        #region ExpensesType, ListExpensesTypesLightViewModel
        public static ListExpensesTypesLightViewModel ToListModel(this ExpensesType entity)
        {
            var result = AutoMapper.Mapper.Map<ExpensesType, ListExpensesTypesLightViewModel>(entity);
            return result;
        }
		#endregion


		#region BankAccountChar, BankAccountCharViewModel
		/// <summary>
		/// Converts an entity to model.
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		public static BankAccountChartViewModel ToModel(this BankAccountChart entity)
		{
			var result = AutoMapper.Mapper.Map<BankAccountChart, BankAccountChartViewModel>(entity);
			return result;
		}

		public static BankAccountChart ToEntity(this BankAccountChartViewModel model)
		{
			var result = AutoMapper.Mapper.Map<BankAccountChartViewModel, BankAccountChart>(model);
			return result;
		}
		#endregion

		#region BankAccountChar, BankAccountChartLightViewModel
		/// <summary>
		/// Converts an entity to model.
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		public static BankAccountChartLightViewModel ToLightModel(this BankAccountChart entity)
		{
			var result = AutoMapper.Mapper.Map<BankAccountChart, BankAccountChartLightViewModel>(entity);
			return result;
		}

		public static BankAccountChart ToEntity(this BankAccountChartLightViewModel model)
		{
			var result = AutoMapper.Mapper.Map<BankAccountChartLightViewModel, BankAccountChart>(model);
			return result;
		}
		#endregion


		#region Document, DocumentViewModel
		public static DocumentViewModel ToModel(this Document entity)
        {
            var result = AutoMapper.Mapper.Map<Document, DocumentViewModel>(entity);
            return result;
        }

        public static DocumentLightViewModel ToLightModel(this Document entity)
        {
            var result = AutoMapper.Mapper.Map<Document, DocumentLightViewModel>(entity);
            return result;
        }

        public static Document ToEntity(this DocumentViewModel model)
        {
            var result = AutoMapper.Mapper.Map<DocumentViewModel, Document>(model);
            return result;
        }
        #endregion

        #region Document, ListDocumentsLightViewModel
        public static ListDocumentsLightViewModel ToListModel(this Document entity)
        {
            var result = AutoMapper.Mapper.Map<Document, ListDocumentsLightViewModel>(entity);
            return result;
        }
        #endregion

        #region AccountDocument, AccountDocumentViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static AccountChartDocumentViewModel ToModel(this AccountChartDocument entity)
        {
            var result = AutoMapper.Mapper.Map<AccountChartDocument, AccountChartDocumentViewModel>(entity);
            return result;
        }

        public static AccountChartDocument ToEntity(this AccountChartDocumentViewModel model)
        {
            var result = AutoMapper.Mapper.Map<AccountChartDocumentViewModel, AccountChartDocument>(model);
            return result;
        }
        #endregion

        #region AccountDocument, ListAccountDocumentLightViewModel
        public static ListAccountChartDocumentLightViewModel ToListModel(this AccountChartDocument entity)
        {
            var result = AutoMapper.Mapper.Map<AccountChartDocument, ListAccountChartDocumentLightViewModel>(entity);
            return result;
        }
        #endregion


        #region DiscountPercentage, DiscountPercentageViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static DiscountPercentageViewModel ToModel(this DiscountPercentage entity)
        {
            var result = AutoMapper.Mapper.Map<DiscountPercentage, DiscountPercentageViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static DiscountPercentage ToEntity(this DiscountPercentageViewModel model)
        {
            var result = AutoMapper.Mapper.Map<DiscountPercentageViewModel, DiscountPercentage>(model);
            return result;
        }
        #endregion

        #region DiscountPercentage, DiscountPercentageLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static DiscountPercentageLightViewModel ToLightModel(this DiscountPercentage entity)
        {
            var result = AutoMapper.Mapper.Map<DiscountPercentage, DiscountPercentageLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static DiscountPercentage ToEntity(this DiscountPercentageLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<DiscountPercentageLightViewModel, DiscountPercentage>(model);
            return result;
        }
        #endregion


        #region CostCenterType, CostCenterTypeViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static CostCenterTypeViewModel ToModel(this CostCenterType entity)
        {
            var result = AutoMapper.Mapper.Map<CostCenterType, CostCenterTypeViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static CostCenterType ToEntity(this CostCenterTypeViewModel model)
        {
            var result = AutoMapper.Mapper.Map<CostCenterTypeViewModel, CostCenterType>(model);
            return result;
        }
        #endregion

        #region CostCenterType, CostCenterTypeLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static CostCenterTypeLightViewModel ToLightModel(this CostCenterType entity)
        {
            var result = AutoMapper.Mapper.Map<CostCenterType, CostCenterTypeLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static CostCenterType ToEntity(this CostCenterTypeLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<CostCenterTypeLightViewModel, CostCenterType>(model);
            return result;
        }
        #endregion


        #region CostCenterType, ListCostCenterTypesLightViewModel
        public static ListCostCenterTypesLightViewModel ToListModel(this CostCenterType entity)
        {
            var result = AutoMapper.Mapper.Map<CostCenterType, ListCostCenterTypesLightViewModel>(entity);
            return result;
        }
        #endregion

        #region ObjectCostCenter, ObjectCostCenterViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ObjectCostCenterViewModel ToModel(this ObjectCostCenter entity)
        {
            var result = AutoMapper.Mapper.Map<ObjectCostCenter, ObjectCostCenterViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static ObjectCostCenter ToEntity(this ObjectCostCenterViewModel model)
        {
            var result = AutoMapper.Mapper.Map<ObjectCostCenterViewModel, ObjectCostCenter>(model);
            return result;
        }
        #endregion

        #region CostCenterType, ListCostCenterTypesLightViewModel
        public static ListObjectCostCenterLightViewModel ToListModel(this ObjectCostCenter entity)
        {
            var result = AutoMapper.Mapper.Map<ObjectCostCenter, ListObjectCostCenterLightViewModel>(entity);
            return result;
        }
        #endregion



        #region ClosedMonth, ClosedMonthViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ClosedMonthViewModel ToModel(this ClosedMonth entity)
        {
            var result = AutoMapper.Mapper.Map<ClosedMonth, ClosedMonthViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static ClosedMonth ToEntity(this ClosedMonthViewModel model)
        {
            var result = AutoMapper.Mapper.Map<ClosedMonthViewModel, ClosedMonth>(model);
            return result;
        }
        #endregion

        #region ClosedMonth, ClosedMonthLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ClosedMonthLightViewModel ToLightModel(this ClosedMonth entity)
        {
            var result = AutoMapper.Mapper.Map<ClosedMonth, ClosedMonthLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static ClosedMonth ToEntity(this ClosedMonthLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<ClosedMonthLightViewModel, ClosedMonth>(model);
            return result;
        }
        #endregion

        #region ClosedMonth, ListClosedMonthsLightViewModel
        public static ListClosedMonthsLightViewModel ToListModel(this ClosedMonth entity)
        {
            var result = AutoMapper.Mapper.Map<ClosedMonth, ListClosedMonthsLightViewModel>(entity);
            return result;
        }
        #endregion



        #region AssetLocation, AssetLocationViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static AssetLocationViewModel ToModel(this AssetLocation entity)
        {
            var result = AutoMapper.Mapper.Map<AssetLocation, AssetLocationViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static AssetLocation ToEntity(this AssetLocationViewModel model)
        {
            var result = AutoMapper.Mapper.Map<AssetLocationViewModel, AssetLocation>(model);
            return result;
        }
        #endregion

        #region AssetLocation, AssetLocationLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static AssetLocationLightViewModel ToLightModel(this AssetLocation entity)
        {
            var result = AutoMapper.Mapper.Map<AssetLocation, AssetLocationLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static AssetLocation ToEntity(this AssetLocationLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<AssetLocationLightViewModel, AssetLocation>(model);
            return result;
        }
        #endregion

        #region AssetLocation, ListAssetLocationsLightViewModel
        public static ListAssetLocationsLightViewModel ToListModel(this AssetLocation entity)
        {
            var result = AutoMapper.Mapper.Map<AssetLocation, ListAssetLocationsLightViewModel>(entity);
            return result;
        }
        #endregion

        #region ClosedReceipt, ClosedReceiptViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ClosedReceiptViewModel ToModel(this ClosedReceipt entity)
        {
            var result = AutoMapper.Mapper.Map<ClosedReceipt, ClosedReceiptViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static ClosedReceipt ToEntity(this ClosedReceiptViewModel model)
        {
            var result = AutoMapper.Mapper.Map<ClosedReceiptViewModel, ClosedReceipt>(model);
            return result;
        }
        #endregion

        #region UserBranch, UserBranchViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static UserBranchViewModel ToModel(this UserBranch entity)
        {
            var result = AutoMapper.Mapper.Map<UserBranch, UserBranchViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static UserBranch ToEntity(this UserBranchViewModel model)
        {
            var result = AutoMapper.Mapper.Map<UserBranchViewModel, UserBranch>(model);
            return result;
        }
        #endregion

        #region UserBranch, UserBranchLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static UserBranchLightViewModel ToLightModel(this UserBranch entity)
        {
            var result = AutoMapper.Mapper.Map<UserBranch, UserBranchLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static UserBranch ToEntity(this UserBranchLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<UserBranchLightViewModel, UserBranch>(model);
            return result;
        }
        #endregion

        #region SafeAccountChart, SafeAccountChartViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static SafeAccountChartViewModel ToModel(this SafeAccountChart entity)
        {
            var result = AutoMapper.Mapper.Map<SafeAccountChart, SafeAccountChartViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static SafeAccountChart ToEntity(this SafeAccountChartViewModel model)
        {
            var result = AutoMapper.Mapper.Map<SafeAccountChartViewModel, SafeAccountChart>(model);
            return result;
        }
        #endregion

        #region SafeAccountChart, SafeAccountChartLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static SafeAccountChartLightViewModel ToLightModel(this SafeAccountChart entity)
        {
            var result = AutoMapper.Mapper.Map<SafeAccountChart, SafeAccountChartLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static SafeAccountChart ToEntity(this SafeAccountChartLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<SafeAccountChartLightViewModel, SafeAccountChart>(model);
            return result;
        }
        #endregion

        #region DiscountPercentage, ListDiscountPercentagesLightViewModel
        public static ListDiscountPercentegesLightViewModel ToListModel(this DiscountPercentage entity)
        {
            var result = AutoMapper.Mapper.Map<DiscountPercentage, ListDiscountPercentegesLightViewModel>(entity);
            return result;
        }
        #endregion

        #region Testament, TestamentViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static TestamentViewModel ToModel(this Testament entity)
        {
            var result = AutoMapper.Mapper.Map<Testament, TestamentViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Testament ToEntity(this TestamentViewModel model)
        {
            var result = AutoMapper.Mapper.Map<TestamentViewModel, Testament>(model);
            return result;
        }
        #endregion

        #region Testament, TestamentLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static TestamentLightViewModel ToLightModel(this Testament entity)
        {
            var result = AutoMapper.Mapper.Map<Testament, TestamentLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Testament ToEntity(this TestamentLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<TestamentLightViewModel, Testament>(model);
            return result;
        }
        #endregion

        #region Testament, ListTestamentLightViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ListTestamentLightViewModel ToListModel(this Testament entity)
        {
            var result = AutoMapper.Mapper.Map<Testament, ListTestamentLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Testament ToEntity(this ListTestamentLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<ListTestamentLightViewModel, Testament>(model);
            return result;
        }
        #endregion


        
		#region BankMovementCostCenters, BankMovementCostCentersViewModel
		/// <summary>
		/// Converts an entity to model.
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		public static BankMovementCostCentersViewModel ToModel(this BankMovementCostCenters entity)
		{
			var result = AutoMapper.Mapper.Map<BankMovementCostCenters, BankMovementCostCentersViewModel>(entity);
			return result;
		}

		public static BankMovementCostCenters ToEntity(this BankMovementCostCentersViewModel model)
		{
			var result = AutoMapper.Mapper.Map<BankMovementCostCentersViewModel, BankMovementCostCenters>(model);
			return result;
		}
        #endregion

        #region AdvancesType, AdvancesTypeViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static AdvancesTypeViewModel ToModel(this AdvancesType entity)
        {
            var result = AutoMapper.Mapper.Map<AdvancesType, AdvancesTypeViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static AdvancesType ToEntity(this AdvancesTypeViewModel model)
        {
            var result = AutoMapper.Mapper.Map<AdvancesTypeViewModel, AdvancesType>(model);
            return result;
        }
        #endregion

        #region AdvancesType, AdvancesTypeLightViewModel
        /// <summary>
        /// Converts an entity to light view model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static AdvancesTypeLightViewModel ToLightModel(this AdvancesType entity)
        {
            var result = AutoMapper.Mapper.Map<AdvancesType, AdvancesTypeLightViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a light view model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static AdvancesType ToEntity(this AdvancesTypeLightViewModel model)
        {
            var result = AutoMapper.Mapper.Map<AdvancesTypeLightViewModel, AdvancesType>(model);
            return result;
        }
        #endregion


        #region TestamentExtraction, TestamentExtractionViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static TestamentExtractionViewModel ToModel(this TestamentExtraction entity)
        {
            var result = AutoMapper.Mapper.Map<TestamentExtraction, TestamentExtractionViewModel>(entity);
            return result;
        }

        public static TestamentExtraction ToEntity(this TestamentExtractionViewModel model)
        {
            var result = AutoMapper.Mapper.Map<TestamentExtractionViewModel, TestamentExtraction>(model);
            return result;
        }
        #endregion


        #region Advance, AdvanceViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static AdvanceViewModel ToModel(this Advance entity)
        {
            var result = AutoMapper.Mapper.Map<Advance, AdvanceViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Advance ToEntity(this AdvanceViewModel model)
        {
            var result = AutoMapper.Mapper.Map<AdvanceViewModel, Advance>(model);
            return result;
        }
        #endregion

        #region Liquidation, LiquidationViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static LiquidationViewModel ToModel(this Liquidation entity)
        {
            var result = AutoMapper.Mapper.Map<Liquidation, LiquidationViewModel>(entity);
            return result;
        }
        /// <summary>
        /// Converts a model to an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Liquidation ToEntity(this LiquidationViewModel model)
        {
            var result = AutoMapper.Mapper.Map<LiquidationViewModel, Liquidation>(model);
            return result;
        }
        #endregion

        #region Advance, LiquidationDetailViewModel
        /// <summary>
        /// Converts an entity to model.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static LiquidationDetailViewModel ToLiquidationDetailModel(this Advance entity)
        {
            var result = AutoMapper.Mapper.Map<Advance, LiquidationDetailViewModel>(entity);
            return result;
        }
        #endregion

    }
}
