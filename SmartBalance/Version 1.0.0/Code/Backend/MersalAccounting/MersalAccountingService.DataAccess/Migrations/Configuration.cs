#region Using ...
using Framework.Common.Enums;
using MersalAccountingService.DataAccess.Contexts;
using MersalAccountingService.Entities.Entity;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
#endregion

namespace MersalAccountingService.DataAccess.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<MersalAccountingContext>
	{
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
			AutomaticMigrationDataLossAllowed = true;
            ContextKey = "MersalAccountingService.DataAccess.Contexts.MersalAccountingContext";
        }	

		protected override void Seed(MersalAccountingService.DataAccess.Contexts.MersalAccountingContext context)
        {
			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
			//  to avoid creating duplicate seed data.

			/*			
			DateTime now = DateTime.Now;

			
			#region Add Some ExitPermissions

			#region ExitPermission1
			ExitPermission ExitPermission1 = new ExitPermission
			{
				Name = "ExitPermission 1",
				CreationDate = now
			};
			#endregion

			context.ExitPermissions.AddOrUpdate(entity => entity.Name,
				ExitPermission1);

			context.SaveChanges();
			#endregion

			#region Add ExitPermissions Translation

			#region ExitPermission1
			ExitPermission ExitPermission1_Ar = new ExitPermission
			{
				Name = "ExitPermission 1 ar",
				CreationDate = now,
				ParentKeyExitPermissionId = ExitPermission1.Id,
				Language = Language.Arabic
			};
			ExitPermission ExitPermission1_En = new ExitPermission
			{
				Name = "ExitPermission 1 en",
				CreationDate = now,
				ParentKeyExitPermissionId = ExitPermission1.Id,
				Language = Language.English
			};
			#endregion

			context.ExitPermissions.AddOrUpdate(entity => entity.Name,
				ExitPermission1_Ar,
				ExitPermission1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some EntrancePermissions

			#region EntrancePermission1
			EntrancePermission EntrancePermission1 = new EntrancePermission
			{
				Name = "EntrancePermission 1",
				CreationDate = now
			};
			#endregion

			context.EntrancePermissions.AddOrUpdate(entity => entity.Name,
				EntrancePermission1);

			context.SaveChanges();
			#endregion

			#region Add EntrancePermissions Translation

			#region EntrancePermission1
			EntrancePermission EntrancePermission1_Ar = new EntrancePermission
			{
				Name = "EntrancePermission 1 ar",
				CreationDate = now,
				ParentKeyEntrancePermissionId = EntrancePermission1.Id,
				Language = Language.Arabic
			};
			EntrancePermission EntrancePermission1_En = new EntrancePermission
			{
				Name = "EntrancePermission 1 en",
				CreationDate = now,
				ParentKeyEntrancePermissionId = EntrancePermission1.Id,
				Language = Language.English
			};
			#endregion

			context.EntrancePermissions.AddOrUpdate(entity => entity.Name,
				EntrancePermission1_Ar,
				EntrancePermission1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some PurchaseRebateProducts

			#region PurchaseRebateProduct1
			PurchaseRebateProduct PurchaseRebateProduct1 = new PurchaseRebateProduct
			{
				Name = "PurchaseRebateProduct 1",
				CreationDate = now
			};
			#endregion

			context.PurchaseRebateProducts.AddOrUpdate(entity => entity.Name,
				PurchaseRebateProduct1);

			context.SaveChanges();
			#endregion

			#region Add PurchaseRebateProducts Translation

			#region PurchaseRebateProduct1
			PurchaseRebateProduct PurchaseRebateProduct1_Ar = new PurchaseRebateProduct
			{
				Name = "PurchaseRebateProduct 1 ar",
				CreationDate = now,
				ParentKeyPurchaseRebateProductId = PurchaseRebateProduct1.Id,
				Language = Language.Arabic
			};
			PurchaseRebateProduct PurchaseRebateProduct1_En = new PurchaseRebateProduct
			{
				Name = "PurchaseRebateProduct 1 en",
				CreationDate = now,
				ParentKeyPurchaseRebateProductId = PurchaseRebateProduct1.Id,
				Language = Language.English
			};
			#endregion

			context.PurchaseRebateProducts.AddOrUpdate(entity => entity.Name,
				PurchaseRebateProduct1_Ar,
				PurchaseRebateProduct1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some SalesRebateProducts

			#region SalesRebateProduct1
			SalesRebateProduct SalesRebateProduct1 = new SalesRebateProduct
			{
				Name = "SalesRebateProduct 1",
				CreationDate = now
			};
			#endregion

			context.SalesRebateProducts.AddOrUpdate(entity => entity.Name,
				SalesRebateProduct1);

			context.SaveChanges();
			#endregion

			#region Add SalesRebateProducts Translation

			#region SalesRebateProduct1
			SalesRebateProduct SalesRebateProduct1_Ar = new SalesRebateProduct
			{
				Name = "SalesRebateProduct 1 ar",
				CreationDate = now,
				ParentKeySalesRebateProductId = SalesRebateProduct1.Id,
				Language = Language.Arabic
			};
			SalesRebateProduct SalesRebateProduct1_En = new SalesRebateProduct
			{
				Name = "SalesRebateProduct 1 en",
				CreationDate = now,
				ParentKeySalesRebateProductId = SalesRebateProduct1.Id,
				Language = Language.English
			};
			#endregion

			context.SalesRebateProducts.AddOrUpdate(entity => entity.Name,
				SalesRebateProduct1_Ar,
				SalesRebateProduct1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some AccountChartSettings

			#region AccountChartSetting1
			AccountChartSetting AccountChartSetting1 = new AccountChartSetting
			{
				Name = "AccountChartSetting 1",
				CreationDate = now
			};
			#endregion

			context.AccountChartSettings.AddOrUpdate(entity => entity.Name,
				AccountChartSetting1);

			context.SaveChanges();
			#endregion

			#region Add AccountChartSettings Translation

			#region AccountChartSetting1
			AccountChartSetting AccountChartSetting1_Ar = new AccountChartSetting
			{
				Name = "AccountChartSetting 1 ar",
				CreationDate = now,
				ParentKeyAccountChartSettingId = AccountChartSetting1.Id,
				Language = Language.Arabic
			};
			AccountChartSetting AccountChartSetting1_En = new AccountChartSetting
			{
				Name = "AccountChartSetting 1 en",
				CreationDate = now,
				ParentKeyAccountChartSettingId = AccountChartSetting1.Id,
				Language = Language.English
			};
			#endregion

			context.AccountChartSettings.AddOrUpdate(entity => entity.Name,
				AccountChartSetting1_Ar,
				AccountChartSetting1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some UserGroups

			#region UserGroup1
			UserGroup UserGroup1 = new UserGroup
			{
				Name = "UserGroup 1",
				CreationDate = now
			};
			#endregion

			context.UserGroups.AddOrUpdate(entity => entity.Name,
				UserGroup1);

			context.SaveChanges();
			#endregion

			#region Add UserGroups Translation

			#region UserGroup1
			UserGroup UserGroup1_Ar = new UserGroup
			{
				Name = "UserGroup 1 ar",
				CreationDate = now,
				ParentKeyUserGroupId = UserGroup1.Id,
				Language = Language.Arabic
			};
			UserGroup UserGroup1_En = new UserGroup
			{
				Name = "UserGroup 1 en",
				CreationDate = now,
				ParentKeyUserGroupId = UserGroup1.Id,
				Language = Language.English
			};
			#endregion

			context.UserGroups.AddOrUpdate(entity => entity.Name,
				UserGroup1_Ar,
				UserGroup1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some GroupRoles

			#region GroupRole1
			GroupRole GroupRole1 = new GroupRole
			{
				Name = "GroupRole 1",
				CreationDate = now
			};
			#endregion

			context.GroupRoles.AddOrUpdate(entity => entity.Name,
				GroupRole1);

			context.SaveChanges();
			#endregion

			#region Add GroupRoles Translation

			#region GroupRole1
			GroupRole GroupRole1_Ar = new GroupRole
			{
				Name = "GroupRole 1 ar",
				CreationDate = now,
				ParentKeyGroupRoleId = GroupRole1.Id,
				Language = Language.Arabic
			};
			GroupRole GroupRole1_En = new GroupRole
			{
				Name = "GroupRole 1 en",
				CreationDate = now,
				ParentKeyGroupRoleId = GroupRole1.Id,
				Language = Language.English
			};
			#endregion

			context.GroupRoles.AddOrUpdate(entity => entity.Name,
				GroupRole1_Ar,
				GroupRole1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some Groups

			#region Group1
			Group Group1 = new Group
			{
				Name = "Group 1",
				CreationDate = now
			};
			#endregion

			context.Groups.AddOrUpdate(entity => entity.Name,
				Group1);

			context.SaveChanges();
			#endregion

			#region Add Groups Translation

			#region Group1
			Group Group1_Ar = new Group
			{
				Name = "Group 1 ar",
				CreationDate = now,
				ParentKeyGroupId = Group1.Id,
				Language = Language.Arabic
			};
			Group Group1_En = new Group
			{
				Name = "Group 1 en",
				CreationDate = now,
				ParentKeyGroupId = Group1.Id,
				Language = Language.English
			};
			#endregion

			context.Groups.AddOrUpdate(entity => entity.Name,
				Group1_Ar,
				Group1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some RolePermissions

			#region RolePermission1
			RolePermission RolePermission1 = new RolePermission
			{
				Name = "RolePermission 1",
				CreationDate = now
			};
			#endregion

			context.RolePermissions.AddOrUpdate(entity => entity.Name,
				RolePermission1);

			context.SaveChanges();
			#endregion

			#region Add RolePermissions Translation

			#region RolePermission1
			RolePermission RolePermission1_Ar = new RolePermission
			{
				Name = "RolePermission 1 ar",
				CreationDate = now,
				ParentKeyRolePermissionId = RolePermission1.Id,
				Language = Language.Arabic
			};
			RolePermission RolePermission1_En = new RolePermission
			{
				Name = "RolePermission 1 en",
				CreationDate = now,
				ParentKeyRolePermissionId = RolePermission1.Id,
				Language = Language.English
			};
			#endregion

			context.RolePermissions.AddOrUpdate(entity => entity.Name,
				RolePermission1_Ar,
				RolePermission1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some Permissions

			#region Permission1
			Permission Permission1 = new Permission
			{
				Name = "Permission 1",
				CreationDate = now
			};
			#endregion

			context.Permissions.AddOrUpdate(entity => entity.Name,
				Permission1);

			context.SaveChanges();
			#endregion

			#region Add Permissions Translation

			#region Permission1
			Permission Permission1_Ar = new Permission
			{
				Name = "Permission 1 ar",
				CreationDate = now,
				ParentKeyPermissionId = Permission1.Id,
				Language = Language.Arabic
			};
			Permission Permission1_En = new Permission
			{
				Name = "Permission 1 en",
				CreationDate = now,
				ParentKeyPermissionId = Permission1.Id,
				Language = Language.English
			};
			#endregion

			context.Permissions.AddOrUpdate(entity => entity.Name,
				Permission1_Ar,
				Permission1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some UserRoles

			#region UserRole1
			UserRole UserRole1 = new UserRole
			{
				Name = "UserRole 1",
				CreationDate = now
			};
			#endregion

			context.UserRoles.AddOrUpdate(entity => entity.Name,
				UserRole1);

			context.SaveChanges();
			#endregion

			#region Add UserRoles Translation

			#region UserRole1
			UserRole UserRole1_Ar = new UserRole
			{
				Name = "UserRole 1 ar",
				CreationDate = now,
				ParentKeyUserRoleId = UserRole1.Id,
				Language = Language.Arabic
			};
			UserRole UserRole1_En = new UserRole
			{
				Name = "UserRole 1 en",
				CreationDate = now,
				ParentKeyUserRoleId = UserRole1.Id,
				Language = Language.English
			};
			#endregion

			context.UserRoles.AddOrUpdate(entity => entity.Name,
				UserRole1_Ar,
				UserRole1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some Roles

			#region Role1
			Role Role1 = new Role
			{
				Name = "Role 1",
				CreationDate = now
			};
			#endregion

			context.Roles.AddOrUpdate(entity => entity.Name,
				Role1);

			context.SaveChanges();
			#endregion

			#region Add Roles Translation

			#region Role1
			Role Role1_Ar = new Role
			{
				Name = "Role 1 ar",
				CreationDate = now,
				ParentKeyRoleId = Role1.Id,
				Language = Language.Arabic
			};
			Role Role1_En = new Role
			{
				Name = "Role 1 en",
				CreationDate = now,
				ParentKeyRoleId = Role1.Id,
				Language = Language.English
			};
			#endregion

			context.Roles.AddOrUpdate(entity => entity.Name,
				Role1_Ar,
				Role1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some CountryCallingCodes

			#region CountryCallingCode1
			CountryCallingCode CountryCallingCode1 = new CountryCallingCode
			{
				Name = "CountryCallingCode 1",
				CreationDate = now
			};
			#endregion

			context.CountryCallingCodes.AddOrUpdate(entity => entity.Name,
				CountryCallingCode1);

			context.SaveChanges();
			#endregion

			#region Add CountryCallingCodes Translation

			#region CountryCallingCode1
			CountryCallingCode CountryCallingCode1_Ar = new CountryCallingCode
			{
				Name = "CountryCallingCode 1 ar",
				CreationDate = now,
				ParentKeyCountryCallingCodeId = CountryCallingCode1.Id,
				Language = Language.Arabic
			};
			CountryCallingCode CountryCallingCode1_En = new CountryCallingCode
			{
				Name = "CountryCallingCode 1 en",
				CreationDate = now,
				ParentKeyCountryCallingCodeId = CountryCallingCode1.Id,
				Language = Language.English
			};
			#endregion

			context.CountryCallingCodes.AddOrUpdate(entity => entity.Name,
				CountryCallingCode1_Ar,
				CountryCallingCode1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some Addresss

			#region Address1
			Address Address1 = new Address
			{
				Name = "Address 1",
				CreationDate = now
			};
			#endregion

			context.Addresss.AddOrUpdate(entity => entity.Name,
				Address1);

			context.SaveChanges();
			#endregion

			#region Add Addresss Translation

			#region Address1
			Address Address1_Ar = new Address
			{
				Name = "Address 1 ar",
				CreationDate = now,
				ParentKeyAddressId = Address1.Id,
				Language = Language.Arabic
			};
			Address Address1_En = new Address
			{
				Name = "Address 1 en",
				CreationDate = now,
				ParentKeyAddressId = Address1.Id,
				Language = Language.English
			};
			#endregion

			context.Addresss.AddOrUpdate(entity => entity.Name,
				Address1_Ar,
				Address1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some ProductPrices

			#region ProductPrice1
			ProductPrice ProductPrice1 = new ProductPrice
			{
				Name = "ProductPrice 1",
				CreationDate = now
			};
			#endregion

			context.ProductPrices.AddOrUpdate(entity => entity.Name,
				ProductPrice1);

			context.SaveChanges();
			#endregion

			#region Add ProductPrices Translation

			#region ProductPrice1
			ProductPrice ProductPrice1_Ar = new ProductPrice
			{
				Name = "ProductPrice 1 ar",
				CreationDate = now,
				ParentKeyProductPriceId = ProductPrice1.Id,
				Language = Language.Arabic
			};
			ProductPrice ProductPrice1_En = new ProductPrice
			{
				Name = "ProductPrice 1 en",
				CreationDate = now,
				ParentKeyProductPriceId = ProductPrice1.Id,
				Language = Language.English
			};
			#endregion

			context.ProductPrices.AddOrUpdate(entity => entity.Name,
				ProductPrice1_Ar,
				ProductPrice1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some Journals

			#region Journal1
			Journal Journal1 = new Journal
			{
				Name = "Journal 1",
				CreationDate = now
			};
			#endregion

			context.Journals.AddOrUpdate(entity => entity.Name,
				Journal1);

			context.SaveChanges();
			#endregion

			#region Add Journals Translation

			#region Journal1
			Journal Journal1_Ar = new Journal
			{
				Name = "Journal 1 ar",
				CreationDate = now,
				ParentKeyJournalId = Journal1.Id,
				Language = Language.Arabic
			};
			Journal Journal1_En = new Journal
			{
				Name = "Journal 1 en",
				CreationDate = now,
				ParentKeyJournalId = Journal1.Id,
				Language = Language.English
			};
			#endregion

			context.Journals.AddOrUpdate(entity => entity.Name,
				Journal1_Ar,
				Journal1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some ExchangeBondss

			#region ExchangeBonds1
			ExchangeBonds ExchangeBonds1 = new ExchangeBonds
			{
				Name = "ExchangeBonds 1",
				CreationDate = now
			};
			#endregion

			context.ExchangeBondss.AddOrUpdate(entity => entity.Name,
				ExchangeBonds1);

			context.SaveChanges();
			#endregion

			#region Add ExchangeBondss Translation

			#region ExchangeBonds1
			ExchangeBonds ExchangeBonds1_Ar = new ExchangeBonds
			{
				Name = "ExchangeBonds 1 ar",
				CreationDate = now,
				ParentKeyExchangeBondsId = ExchangeBonds1.Id,
				Language = Language.Arabic
			};
			ExchangeBonds ExchangeBonds1_En = new ExchangeBonds
			{
				Name = "ExchangeBonds 1 en",
				CreationDate = now,
				ParentKeyExchangeBondsId = ExchangeBonds1.Id,
				Language = Language.English
			};
			#endregion

			context.ExchangeBondss.AddOrUpdate(entity => entity.Name,
				ExchangeBonds1_Ar,
				ExchangeBonds1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some Receiptss

			#region Receipts1
			Receipts Receipts1 = new Receipts
			{
				Name = "Receipts 1",
				CreationDate = now
			};
			#endregion

			context.Receiptss.AddOrUpdate(entity => entity.Name,
				Receipts1);

			context.SaveChanges();
			#endregion

			#region Add Receiptss Translation

			#region Receipts1
			Receipts Receipts1_Ar = new Receipts
			{
				Name = "Receipts 1 ar",
				CreationDate = now,
				ParentKeyReceiptsId = Receipts1.Id,
				Language = Language.Arabic
			};
			Receipts Receipts1_En = new Receipts
			{
				Name = "Receipts 1 en",
				CreationDate = now,
				ParentKeyReceiptsId = Receipts1.Id,
				Language = Language.English
			};
			#endregion

			context.Receiptss.AddOrUpdate(entity => entity.Name,
				Receipts1_Ar,
				Receipts1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some SalesRebates

			#region SalesRebate1
			SalesRebate SalesRebate1 = new SalesRebate
			{
				Name = "SalesRebate 1",
				CreationDate = now
			};
			#endregion

			context.SalesRebates.AddOrUpdate(entity => entity.Name,
				SalesRebate1);

			context.SaveChanges();
			#endregion

			#region Add SalesRebates Translation

			#region SalesRebate1
			SalesRebate SalesRebate1_Ar = new SalesRebate
			{
				Name = "SalesRebate 1 ar",
				CreationDate = now,
				ParentKeySalesRebateId = SalesRebate1.Id,
				Language = Language.Arabic
			};
			SalesRebate SalesRebate1_En = new SalesRebate
			{
				Name = "SalesRebate 1 en",
				CreationDate = now,
				ParentKeySalesRebateId = SalesRebate1.Id,
				Language = Language.English
			};
			#endregion

			context.SalesRebates.AddOrUpdate(entity => entity.Name,
				SalesRebate1_Ar,
				SalesRebate1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some PurchaseRebates

			#region PurchaseRebate1
			PurchaseRebate PurchaseRebate1 = new PurchaseRebate
			{
				Name = "PurchaseRebate 1",
				CreationDate = now
			};
			#endregion

			context.PurchaseRebates.AddOrUpdate(entity => entity.Name,
				PurchaseRebate1);

			context.SaveChanges();
			#endregion

			#region Add PurchaseRebates Translation

			#region PurchaseRebate1
			PurchaseRebate PurchaseRebate1_Ar = new PurchaseRebate
			{
				Name = "PurchaseRebate 1 ar",
				CreationDate = now,
				ParentKeyPurchaseRebateId = PurchaseRebate1.Id,
				Language = Language.Arabic
			};
			PurchaseRebate PurchaseRebate1_En = new PurchaseRebate
			{
				Name = "PurchaseRebate 1 en",
				CreationDate = now,
				ParentKeyPurchaseRebateId = PurchaseRebate1.Id,
				Language = Language.English
			};
			#endregion

			context.PurchaseRebates.AddOrUpdate(entity => entity.Name,
				PurchaseRebate1_Ar,
				PurchaseRebate1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some PurchaseInvoices

			#region PurchaseInvoice1
			PurchaseInvoice PurchaseInvoice1 = new PurchaseInvoice
			{
				Name = "PurchaseInvoice 1",
				CreationDate = now
			};
			#endregion

			context.PurchaseInvoices.AddOrUpdate(entity => entity.Name,
				PurchaseInvoice1);

			context.SaveChanges();
			#endregion

			#region Add PurchaseInvoices Translation

			#region PurchaseInvoice1
			PurchaseInvoice PurchaseInvoice1_Ar = new PurchaseInvoice
			{
				Name = "PurchaseInvoice 1 ar",
				CreationDate = now,
				ParentKeyPurchaseInvoiceId = PurchaseInvoice1.Id,
				Language = Language.Arabic
			};
			PurchaseInvoice PurchaseInvoice1_En = new PurchaseInvoice
			{
				Name = "PurchaseInvoice 1 en",
				CreationDate = now,
				ParentKeyPurchaseInvoiceId = PurchaseInvoice1.Id,
				Language = Language.English
			};
			#endregion

			context.PurchaseInvoices.AddOrUpdate(entity => entity.Name,
				PurchaseInvoice1_Ar,
				PurchaseInvoice1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some Transactions

			#region Transaction1
			Transaction Transaction1 = new Transaction
			{
				Name = "Transaction 1",
				CreationDate = now
			};
			#endregion

			context.Transactions.AddOrUpdate(entity => entity.Name,
				Transaction1);

			context.SaveChanges();
			#endregion

			#region Add Transactions Translation

			#region Transaction1
			Transaction Transaction1_Ar = new Transaction
			{
				Name = "Transaction 1 ar",
				CreationDate = now,
				ParentKeyTransactionId = Transaction1.Id,
				Language = Language.Arabic
			};
			Transaction Transaction1_En = new Transaction
			{
				Name = "Transaction 1 en",
				CreationDate = now,
				ParentKeyTransactionId = Transaction1.Id,
				Language = Language.English
			};
			#endregion

			context.Transactions.AddOrUpdate(entity => entity.Name,
				Transaction1_Ar,
				Transaction1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some PaymentMethods

			#region PaymentMethod1
			PaymentMethod PaymentMethod1 = new PaymentMethod
			{
				Name = "PaymentMethod 1",
				CreationDate = now
			};
			#endregion

			context.PaymentMethods.AddOrUpdate(entity => entity.Name,
				PaymentMethod1);

			context.SaveChanges();
			#endregion

			#region Add PaymentMethods Translation

			#region PaymentMethod1
			PaymentMethod PaymentMethod1_Ar = new PaymentMethod
			{
				Name = "PaymentMethod 1 ar",
				CreationDate = now,
				ParentKeyPaymentMethodId = PaymentMethod1.Id,
				Language = Language.Arabic
			};
			PaymentMethod PaymentMethod1_En = new PaymentMethod
			{
				Name = "PaymentMethod 1 en",
				CreationDate = now,
				ParentKeyPaymentMethodId = PaymentMethod1.Id,
				Language = Language.English
			};
			#endregion

			context.PaymentMethods.AddOrUpdate(entity => entity.Name,
				PaymentMethod1_Ar,
				PaymentMethod1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some Assets

			#region Asset1
			Asset Asset1 = new Asset
			{
				Name = "Asset 1",
				CreationDate = now
			};
			#endregion

			context.Assets.AddOrUpdate(entity => entity.Name,
				Asset1);

			context.SaveChanges();
			#endregion

			#region Add Assets Translation

			#region Asset1
			Asset Asset1_Ar = new Asset
			{
				Name = "Asset 1 ar",
				CreationDate = now,
				ParentKeyAssetId = Asset1.Id,
				Language = Language.Arabic
			};
			Asset Asset1_En = new Asset
			{
				Name = "Asset 1 en",
				CreationDate = now,
				ParentKeyAssetId = Asset1.Id,
				Language = Language.English
			};
			#endregion

			context.Assets.AddOrUpdate(entity => entity.Name,
				Asset1_Ar,
				Asset1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some AssetCategorys

			#region AssetCategory1
			AssetCategory AssetCategory1 = new AssetCategory
			{
				Name = "AssetCategory 1",
				CreationDate = now
			};
			#endregion

			context.AssetCategorys.AddOrUpdate(entity => entity.Name,
				AssetCategory1);

			context.SaveChanges();
			#endregion

			#region Add AssetCategorys Translation

			#region AssetCategory1
			AssetCategory AssetCategory1_Ar = new AssetCategory
			{
				Name = "AssetCategory 1 ar",
				CreationDate = now,
				ParentKeyAssetCategoryId = AssetCategory1.Id,
				Language = Language.Arabic
			};
			AssetCategory AssetCategory1_En = new AssetCategory
			{
				Name = "AssetCategory 1 en",
				CreationDate = now,
				ParentKeyAssetCategoryId = AssetCategory1.Id,
				Language = Language.English
			};
			#endregion

			context.AssetCategorys.AddOrUpdate(entity => entity.Name,
				AssetCategory1_Ar,
				AssetCategory1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some Inventorys

			#region Inventory1
			Inventory Inventory1 = new Inventory
			{
				Name = "Inventory 1",
				CreationDate = now
			};
			#endregion

			context.Inventorys.AddOrUpdate(entity => entity.Name,
				Inventory1);

			context.SaveChanges();
			#endregion

			#region Add Inventorys Translation

			#region Inventory1
			Inventory Inventory1_Ar = new Inventory
			{
				Name = "Inventory 1 ar",
				CreationDate = now,
				ParentKeyInventoryId = Inventory1.Id,
				Language = Language.Arabic
			};
			Inventory Inventory1_En = new Inventory
			{
				Name = "Inventory 1 en",
				CreationDate = now,
				ParentKeyInventoryId = Inventory1.Id,
				Language = Language.English
			};
			#endregion

			context.Inventorys.AddOrUpdate(entity => entity.Name,
				Inventory1_Ar,
				Inventory1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some Products

			#region Product1
			Product Product1 = new Product
			{
				Name = "Product 1",
				CreationDate = now
			};
			#endregion

			context.Products.AddOrUpdate(entity => entity.Name,
				Product1);

			context.SaveChanges();
			#endregion

			#region Add Products Translation

			#region Product1
			Product Product1_Ar = new Product
			{
				Name = "Product 1 ar",
				CreationDate = now,
				ParentKeyProductId = Product1.Id,
				Language = Language.Arabic
			};
			Product Product1_En = new Product
			{
				Name = "Product 1 en",
				CreationDate = now,
				ParentKeyProductId = Product1.Id,
				Language = Language.English
			};
			#endregion

			context.Products.AddOrUpdate(entity => entity.Name,
				Product1_Ar,
				Product1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some ProductTypes

			#region ProductType1
			ProductType ProductType1 = new ProductType
			{
				Name = "ProductType 1",
				CreationDate = now
			};
			#endregion

			context.ProductTypes.AddOrUpdate(entity => entity.Name,
				ProductType1);

			context.SaveChanges();
			#endregion

			#region Add ProductTypes Translation

			#region ProductType1
			ProductType ProductType1_Ar = new ProductType
			{
				Name = "ProductType 1 ar",
				CreationDate = now,
				ParentKeyProductTypeId = ProductType1.Id,
				Language = Language.Arabic
			};
			ProductType ProductType1_En = new ProductType
			{
				Name = "ProductType 1 en",
				CreationDate = now,
				ParentKeyProductTypeId = ProductType1.Id,
				Language = Language.English
			};
			#endregion

			context.ProductTypes.AddOrUpdate(entity => entity.Name,
				ProductType1_Ar,
				ProductType1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some StoreMeasurementUnits

			#region StoreMeasurementUnit1
			StoreMeasurementUnit StoreMeasurementUnit1 = new StoreMeasurementUnit
			{
				Name = "StoreMeasurementUnit 1",
				CreationDate = now
			};
			#endregion

			context.StoreMeasurementUnits.AddOrUpdate(entity => entity.Name,
				StoreMeasurementUnit1);

			context.SaveChanges();
			#endregion

			#region Add StoreMeasurementUnits Translation

			#region StoreMeasurementUnit1
			StoreMeasurementUnit StoreMeasurementUnit1_Ar = new StoreMeasurementUnit
			{
				Name = "StoreMeasurementUnit 1 ar",
				CreationDate = now,
				ParentKeyStoreMeasurementUnitId = StoreMeasurementUnit1.Id,
				Language = Language.Arabic
			};
			StoreMeasurementUnit StoreMeasurementUnit1_En = new StoreMeasurementUnit
			{
				Name = "StoreMeasurementUnit 1 en",
				CreationDate = now,
				ParentKeyStoreMeasurementUnitId = StoreMeasurementUnit1.Id,
				Language = Language.English
			};
			#endregion

			context.StoreMeasurementUnits.AddOrUpdate(entity => entity.Name,
				StoreMeasurementUnit1_Ar,
				StoreMeasurementUnit1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some DelegateMans

			#region DelegateMan1
			DelegateMan DelegateMan1 = new DelegateMan
			{
				Name = "DelegateMan 1",
				CreationDate = now
			};
			#endregion

			context.DelegateMans.AddOrUpdate(entity => entity.Name,
				DelegateMan1);

			context.SaveChanges();
			#endregion

			#region Add DelegateMans Translation

			#region DelegateMan1
			DelegateMan DelegateMan1_Ar = new DelegateMan
			{
				Name = "DelegateMan 1 ar",
				CreationDate = now,
				ParentKeyDelegateManId = DelegateMan1.Id,
				Language = Language.Arabic
			};
			DelegateMan DelegateMan1_En = new DelegateMan
			{
				Name = "DelegateMan 1 en",
				CreationDate = now,
				ParentKeyDelegateManId = DelegateMan1.Id,
				Language = Language.English
			};
			#endregion

			context.DelegateMans.AddOrUpdate(entity => entity.Name,
				DelegateMan1_Ar,
				DelegateMan1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some Cases

			#region Case1
			Case Case1 = new Case
			{
				Name = "Case 1",
				CreationDate = now
			};
			#endregion

			context.Cases.AddOrUpdate(entity => entity.Name,
				Case1);

			context.SaveChanges();
			#endregion

			#region Add Cases Translation

			#region Case1
			Case Case1_Ar = new Case
			{
				Name = "Case 1 ar",
				CreationDate = now,
				ParentKeyCaseId = Case1.Id,
				Language = Language.Arabic
			};
			Case Case1_En = new Case
			{
				Name = "Case 1 en",
				CreationDate = now,
				ParentKeyCaseId = Case1.Id,
				Language = Language.English
			};
			#endregion

			context.Cases.AddOrUpdate(entity => entity.Name,
				Case1_Ar,
				Case1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some CaseTypes

			#region CaseType1
			CaseType CaseType1 = new CaseType
			{
				Name = "CaseType 1",
				CreationDate = now
			};
			#endregion

			context.CaseTypes.AddOrUpdate(entity => entity.Name,
				CaseType1);

			context.SaveChanges();
			#endregion

			#region Add CaseTypes Translation

			#region CaseType1
			CaseType CaseType1_Ar = new CaseType
			{
				Name = "CaseType 1 ar",
				CreationDate = now,
				ParentKeyCaseTypeId = CaseType1.Id,
				Language = Language.Arabic
			};
			CaseType CaseType1_En = new CaseType
			{
				Name = "CaseType 1 en",
				CreationDate = now,
				ParentKeyCaseTypeId = CaseType1.Id,
				Language = Language.English
			};
			#endregion

			context.CaseTypes.AddOrUpdate(entity => entity.Name,
				CaseType1_Ar,
				CaseType1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some CostCenters

			#region CostCenter1
			CostCenter CostCenter1 = new CostCenter
			{
				Name = "CostCenter 1",
				CreationDate = now
			};
			#endregion

			context.CostCenters.AddOrUpdate(entity => entity.Name,
				CostCenter1);

			context.SaveChanges();
			#endregion

			#region Add CostCenters Translation

			#region CostCenter1
			CostCenter CostCenter1_Ar = new CostCenter
			{
				Name = "CostCenter 1 ar",
				CreationDate = now,
				ParentKeyCostCenterId = CostCenter1.Id,
				Language = Language.Arabic
			};
			CostCenter CostCenter1_En = new CostCenter
			{
				Name = "CostCenter 1 en",
				CreationDate = now,
				ParentKeyCostCenterId = CostCenter1.Id,
				Language = Language.English
			};
			#endregion

			context.CostCenters.AddOrUpdate(entity => entity.Name,
				CostCenter1_Ar,
				CostCenter1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some Banks

			#region Bank1
			Bank Bank1 = new Bank
			{
				Name = "Bank 1",
				CreationDate = now
			};
			#endregion

			context.Banks.AddOrUpdate(entity => entity.Name,
				Bank1);

			context.SaveChanges();
			#endregion

			#region Add Banks Translation

			#region Bank1
			Bank Bank1_Ar = new Bank
			{
				Name = "Bank 1 ar",
				CreationDate = now,
				ParentKeyBankId = Bank1.Id,
				Language = Language.Arabic
			};
			Bank Bank1_En = new Bank
			{
				Name = "Bank 1 en",
				CreationDate = now,
				ParentKeyBankId = Bank1.Id,
				Language = Language.English
			};
			#endregion

			context.Banks.AddOrUpdate(entity => entity.Name,
				Bank1_Ar,
				Bank1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some Safes

			#region Safe1
			Safe Safe1 = new Safe
			{
				Name = "Safe 1",
				CreationDate = now
			};
			#endregion

			context.Safes.AddOrUpdate(entity => entity.Name,
				Safe1);

			context.SaveChanges();
			#endregion

			#region Add Safes Translation

			#region Safe1
			Safe Safe1_Ar = new Safe
			{
				Name = "Safe 1 ar",
				CreationDate = now,
				ParentKeySafeId = Safe1.Id,
				Language = Language.Arabic
			};
			Safe Safe1_En = new Safe
			{
				Name = "Safe 1 en",
				CreationDate = now,
				ParentKeySafeId = Safe1.Id,
				Language = Language.English
			};
			#endregion

			context.Safes.AddOrUpdate(entity => entity.Name,
				Safe1_Ar,
				Safe1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some AccountCharts

			#region AccountChart1
			AccountChart AccountChart1 = new AccountChart
			{
				Name = "AccountChart 1",
				CreationDate = now
			};
			#endregion

			context.AccountCharts.AddOrUpdate(entity => entity.Name,
				AccountChart1);

			context.SaveChanges();
			#endregion

			#region Add AccountCharts Translation

			#region AccountChart1
			AccountChart AccountChart1_Ar = new AccountChart
			{
				Name = "AccountChart 1 ar",
				CreationDate = now,
				ParentKeyAccountChartId = AccountChart1.Id,
				Language = Language.Arabic
			};
			AccountChart AccountChart1_En = new AccountChart
			{
				Name = "AccountChart 1 en",
				CreationDate = now,
				ParentKeyAccountChartId = AccountChart1.Id,
				Language = Language.English
			};
			#endregion

			context.AccountCharts.AddOrUpdate(entity => entity.Name,
				AccountChart1_Ar,
				AccountChart1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some VendorTypes

			#region VendorType1
			VendorType VendorType1 = new VendorType
			{
				Name = "VendorType 1",
				CreationDate = now
			};
			#endregion

			context.VendorTypes.AddOrUpdate(entity => entity.Name,
				VendorType1);

			context.SaveChanges();
			#endregion

			#region Add VendorTypes Translation

			#region VendorType1
			VendorType VendorType1_Ar = new VendorType
			{
				Name = "VendorType 1 ar",
				CreationDate = now,
				ParentKeyVendorTypeId = VendorType1.Id,
				Language = Language.Arabic
			};
			VendorType VendorType1_En = new VendorType
			{
				Name = "VendorType 1 en",
				CreationDate = now,
				ParentKeyVendorTypeId = VendorType1.Id,
				Language = Language.English
			};
			#endregion

			context.VendorTypes.AddOrUpdate(entity => entity.Name,
				VendorType1_Ar,
				VendorType1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some Vendors

			#region Vendor1
			Vendor Vendor1 = new Vendor
			{
				Name = "Vendor 1",
				CreationDate = now
			};
			#endregion

			context.Vendors.AddOrUpdate(entity => entity.Name,
				Vendor1);

			context.SaveChanges();
			#endregion

			#region Add Vendors Translation

			#region Vendor1
			Vendor Vendor1_Ar = new Vendor
			{
				Name = "Vendor 1 ar",
				CreationDate = now,
				ParentKeyVendorId = Vendor1.Id,
				Language = Language.Arabic
			};
			Vendor Vendor1_En = new Vendor
			{
				Name = "Vendor 1 en",
				CreationDate = now,
				ParentKeyVendorId = Vendor1.Id,
				Language = Language.English
			};
			#endregion

			context.Vendors.AddOrUpdate(entity => entity.Name,
				Vendor1_Ar,
				Vendor1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some AccountTypes

			#region AccountType1
			AccountType AccountType1 = new AccountType
			{
				Name = "AccountType 1",
				CreationDate = now
			};
			#endregion

			context.AccountTypes.AddOrUpdate(entity => entity.Name,
				AccountType1);

			context.SaveChanges();
			#endregion

			#region Add AccountTypes Translation

			#region AccountType1
			AccountType AccountType1_Ar = new AccountType
			{
				Name = "AccountType 1 ar",
				CreationDate = now,
				ParentKeyAccountTypeId = AccountType1.Id,
				Language = Language.Arabic
			};
			AccountType AccountType1_En = new AccountType
			{
				Name = "AccountType 1 en",
				CreationDate = now,
				ParentKeyAccountTypeId = AccountType1.Id,
				Language = Language.English
			};
			#endregion

			context.AccountTypes.AddOrUpdate(entity => entity.Name,
				AccountType1_Ar,
				AccountType1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some Branchs

			#region Branch1
			Branch Branch1 = new Branch
			{
				Name = "Branch 1",
				CreationDate = now
			};
			#endregion

			context.Branchs.AddOrUpdate(entity => entity.Name,
				Branch1);

			context.SaveChanges();
			#endregion

			#region Add Branchs Translation

			#region Branch1
			Branch Branch1_Ar = new Branch
			{
				Name = "Branch 1 ar",
				CreationDate = now,
				ParentKeyBranchId = Branch1.Id,
				Language = Language.Arabic
			};
			Branch Branch1_En = new Branch
			{
				Name = "Branch 1 en",
				CreationDate = now,
				ParentKeyBranchId = Branch1.Id,
				Language = Language.English
			};
			#endregion

			context.Branchs.AddOrUpdate(entity => entity.Name,
				Branch1_Ar,
				Branch1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some Donations

			#region Donation1
			Donation Donation1 = new Donation
			{
				Name = "Donation 1",
				CreationDate = now
			};
			#endregion

			context.Donations.AddOrUpdate(entity => entity.Name,
				Donation1);

			context.SaveChanges();
			#endregion

			#region Add Donations Translation

			#region Donation1
			Donation Donation1_Ar = new Donation
			{
				Name = "Donation 1 ar",
				CreationDate = now,
				ParentKeyDonationId = Donation1.Id,
				Language = Language.Arabic
			};
			Donation Donation1_En = new Donation
			{
				Name = "Donation 1 en",
				CreationDate = now,
				ParentKeyDonationId = Donation1.Id,
				Language = Language.English
			};
			#endregion

			context.Donations.AddOrUpdate(entity => entity.Name,
				Donation1_Ar,
				Donation1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some CurrencyRates

			#region CurrencyRate1
			CurrencyRate CurrencyRate1 = new CurrencyRate
			{
				Name = "CurrencyRate 1",
				CreationDate = now
			};
			#endregion

			context.CurrencyRates.AddOrUpdate(entity => entity.Name,
				CurrencyRate1);

			context.SaveChanges();
			#endregion

			#region Add CurrencyRates Translation

			#region CurrencyRate1
			CurrencyRate CurrencyRate1_Ar = new CurrencyRate
			{
				Name = "CurrencyRate 1 ar",
				CreationDate = now,
				ParentKeyCurrencyRateId = CurrencyRate1.Id,
				Language = Language.Arabic
			};
			CurrencyRate CurrencyRate1_En = new CurrencyRate
			{
				Name = "CurrencyRate 1 en",
				CreationDate = now,
				ParentKeyCurrencyRateId = CurrencyRate1.Id,
				Language = Language.English
			};
			#endregion

			context.CurrencyRates.AddOrUpdate(entity => entity.Name,
				CurrencyRate1_Ar,
				CurrencyRate1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some Currencys

			#region Currency1
			Currency Currency1 = new Currency
			{
				Name = "Currency 1",
				CreationDate = now
			};
			#endregion

			context.Currencys.AddOrUpdate(entity => entity.Name,
				Currency1);

			context.SaveChanges();
			#endregion

			#region Add Currencys Translation

			#region Currency1
			Currency Currency1_Ar = new Currency
			{
				Name = "Currency 1 ar",
				CreationDate = now,
				ParentKeyCurrencyId = Currency1.Id,
				Language = Language.Arabic
			};
			Currency Currency1_En = new Currency
			{
				Name = "Currency 1 en",
				CreationDate = now,
				ParentKeyCurrencyId = Currency1.Id,
				Language = Language.English
			};
			#endregion

			context.Currencys.AddOrUpdate(entity => entity.Name,
				Currency1_Ar,
				Currency1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some Users

			#region User1
			User User1 = new User
			{
				Name = "User 1",
				CreationDate = now
			};
			#endregion

			context.Users.AddOrUpdate(entity => entity.Name,
				User1);

			context.SaveChanges();
			#endregion

			#region Add Users Translation

			#region User1
			User User1_Ar = new User
			{
				Name = "User 1 ar",
				CreationDate = now,
				ParentKeyUserId = User1.Id,
				Language = Language.Arabic
			};
			User User1_En = new User
			{
				Name = "User 1 en",
				CreationDate = now,
				ParentKeyUserId = User1.Id,
				Language = Language.English
			};
			#endregion

			context.Users.AddOrUpdate(entity => entity.Name,
				User1_Ar,
				User1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some Attachments

			#region Attachment1
			Attachment Attachment1 = new Attachment
			{
				Name = "Attachment 1",
				CreationDate = now
			};
			#endregion

			context.Attachments.AddOrUpdate(entity => entity.Name,
				Attachment1);

			context.SaveChanges();
			#endregion

			#region Add Attachments Translation

			#region Attachment1
			Attachment Attachment1_Ar = new Attachment
			{
				Name = "Attachment 1 ar",
				CreationDate = now,
				ParentKeyAttachmentId = Attachment1.Id,
				Language = Language.Arabic
			};
			Attachment Attachment1_En = new Attachment
			{
				Name = "Attachment 1 en",
				CreationDate = now,
				ParentKeyAttachmentId = Attachment1.Id,
				Language = Language.English
			};
			#endregion

			context.Attachments.AddOrUpdate(entity => entity.Name,
				Attachment1_Ar,
				Attachment1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some Countrys

			#region Country1
			Country Country1 = new Country
			{
				Name = "Country 1",
				CreationDate = now
			};
			#endregion

			context.Countrys.AddOrUpdate(entity => entity.Name,
				Country1);

			context.SaveChanges();
			#endregion

			#region Add Countrys Translation

			#region Country1
			Country Country1_Ar = new Country
			{
				Name = "Country 1 ar",
				CreationDate = now,
				ParentKeyCountryId = Country1.Id,
				Language = Language.Arabic
			};
			Country Country1_En = new Country
			{
				Name = "Country 1 en",
				CreationDate = now,
				ParentKeyCountryId = Country1.Id,
				Language = Language.English
			};
			#endregion

			context.Countrys.AddOrUpdate(entity => entity.Name,
				Country1_Ar,
				Country1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some Citys

			#region City1
			City City1 = new City
			{
				Name = "City 1",
				CreationDate = now
			};
			#endregion

			context.Citys.AddOrUpdate(entity => entity.Name,
				City1);

			context.SaveChanges();
			#endregion

			#region Add Citys Translation

			#region City1
			City City1_Ar = new City
			{
				Name = "City 1 ar",
				CreationDate = now,
				ParentKeyCityId = City1.Id,
				Language = Language.Arabic
			};
			City City1_En = new City
			{
				Name = "City 1 en",
				CreationDate = now,
				ParentKeyCityId = City1.Id,
				Language = Language.English
			};
			#endregion

			context.Citys.AddOrUpdate(entity => entity.Name,
				City1_Ar,
				City1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some Districts

			#region District1
			District District1 = new District
			{
				Name = "District 1",
				CreationDate = now
			};
			#endregion

			context.Districts.AddOrUpdate(entity => entity.Name,
				District1);

			context.SaveChanges();
			#endregion

			#region Add Districts Translation

			#region District1
			District District1_Ar = new District
			{
				Name = "District 1 ar",
				CreationDate = now,
				ParentKeyDistrictId = District1.Id,
				Language = Language.Arabic
			};
			District District1_En = new District
			{
				Name = "District 1 en",
				CreationDate = now,
				ParentKeyDistrictId = District1.Id,
				Language = Language.English
			};
			#endregion

			context.Districts.AddOrUpdate(entity => entity.Name,
				District1_Ar,
				District1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some StockAssessmentPolicys

			#region StockAssessmentPolicy1
			StockAssessmentPolicy StockAssessmentPolicy1 = new StockAssessmentPolicy
			{
				Name = "StockAssessmentPolicy 1",
				CreationDate = now
			};
			#endregion

			context.StockAssessmentPolicys.AddOrUpdate(entity => entity.Name,
				StockAssessmentPolicy1);

			context.SaveChanges();
			#endregion

			#region Add StockAssessmentPolicys Translation

			#region StockAssessmentPolicy1
			StockAssessmentPolicy StockAssessmentPolicy1_Ar = new StockAssessmentPolicy
			{
				Name = "StockAssessmentPolicy 1 ar",
				CreationDate = now,
				ParentKeyStockAssessmentPolicyId = StockAssessmentPolicy1.Id,
				Language = Language.Arabic
			};
			StockAssessmentPolicy StockAssessmentPolicy1_En = new StockAssessmentPolicy
			{
				Name = "StockAssessmentPolicy 1 en",
				CreationDate = now,
				ParentKeyStockAssessmentPolicyId = StockAssessmentPolicy1.Id,
				Language = Language.English
			};
			#endregion

			context.StockAssessmentPolicys.AddOrUpdate(entity => entity.Name,
				StockAssessmentPolicy1_Ar,
				StockAssessmentPolicy1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some Mails

			#region Mail1
			Mail Mail1 = new Mail
			{
				Name = "Mail 1",
				CreationDate = now
			};
			#endregion

			context.Mails.AddOrUpdate(entity => entity.Name,
				Mail1);

			context.SaveChanges();
			#endregion

			#region Add Mails Translation

			#region Mail1
			Mail Mail1_Ar = new Mail
			{
				Name = "Mail 1 ar",
				CreationDate = now,
				ParentKeyMailId = Mail1.Id,
				Language = Language.Arabic
			};
			Mail Mail1_En = new Mail
			{
				Name = "Mail 1 en",
				CreationDate = now,
				ParentKeyMailId = Mail1.Id,
				Language = Language.English
			};
			#endregion

			context.Mails.AddOrUpdate(entity => entity.Name,
				Mail1_Ar,
				Mail1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some Mobiles

			#region Mobile1
			Mobile Mobile1 = new Mobile
			{
				Name = "Mobile 1",
				CreationDate = now
			};
			#endregion

			context.Mobiles.AddOrUpdate(entity => entity.Name,
				Mobile1);

			context.SaveChanges();
			#endregion

			#region Add Mobiles Translation

			#region Mobile1
			Mobile Mobile1_Ar = new Mobile
			{
				Name = "Mobile 1 ar",
				CreationDate = now,
				ParentKeyMobileId = Mobile1.Id,
				Language = Language.Arabic
			};
			Mobile Mobile1_En = new Mobile
			{
				Name = "Mobile 1 en",
				CreationDate = now,
				ParentKeyMobileId = Mobile1.Id,
				Language = Language.English
			};
			#endregion

			context.Mobiles.AddOrUpdate(entity => entity.Name,
				Mobile1_Ar,
				Mobile1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some BankMovements

			#region BankMovement1
			BankMovement BankMovement1 = new BankMovement
			{
				Name = "BankMovement 1",
				CreationDate = now
			};
			#endregion

			context.BankMovements.AddOrUpdate(entity => entity.Name,
				BankMovement1);

			context.SaveChanges();
			#endregion

			#region Add BankMovements Translation

			#region BankMovement1
			BankMovement BankMovement1_Ar = new BankMovement
			{
				Name = "BankMovement 1 ar",
				CreationDate = now,
				ParentKeyBankMovementId = BankMovement1.Id,
				Language = Language.Arabic
			};
			BankMovement BankMovement1_En = new BankMovement
			{
				Name = "BankMovement 1 en",
				CreationDate = now,
				ParentKeyBankMovementId = BankMovement1.Id,
				Language = Language.English
			};
			#endregion

			context.BankMovements.AddOrUpdate(entity => entity.Name,
				BankMovement1_Ar,
				BankMovement1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some Transfers

			#region Transfer1
			Transfer Transfer1 = new Transfer
			{
				Name = "Transfer 1",
				CreationDate = now
			};
			#endregion

			context.Transfers.AddOrUpdate(entity => entity.Name,
				Transfer1);

			context.SaveChanges();
			#endregion

			#region Add Transfers Translation

			#region Transfer1
			Transfer Transfer1_Ar = new Transfer
			{
				Name = "Transfer 1 ar",
				CreationDate = now,
				ParentKeyTransferId = Transfer1.Id,
				Language = Language.Arabic
			};
			Transfer Transfer1_En = new Transfer
			{
				Name = "Transfer 1 en",
				CreationDate = now,
				ParentKeyTransferId = Transfer1.Id,
				Language = Language.English
			};
			#endregion

			context.Transfers.AddOrUpdate(entity => entity.Name,
				Transfer1_Ar,
				Transfer1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some InventoryTransfers

			#region InventoryTransfer1
			InventoryTransfer InventoryTransfer1 = new InventoryTransfer
			{
				Name = "InventoryTransfer 1",
				CreationDate = now
			};
			#endregion

			context.InventoryTransfers.AddOrUpdate(entity => entity.Name,
				InventoryTransfer1);

			context.SaveChanges();
			#endregion

			#region Add InventoryTransfers Translation

			#region InventoryTransfer1
			InventoryTransfer InventoryTransfer1_Ar = new InventoryTransfer
			{
				Name = "InventoryTransfer 1 ar",
				CreationDate = now,
				ParentKeyInventoryTransferId = InventoryTransfer1.Id,
				Language = Language.Arabic
			};
			InventoryTransfer InventoryTransfer1_En = new InventoryTransfer
			{
				Name = "InventoryTransfer 1 en",
				CreationDate = now,
				ParentKeyInventoryTransferId = InventoryTransfer1.Id,
				Language = Language.English
			};
			#endregion

			context.InventoryTransfers.AddOrUpdate(entity => entity.Name,
				InventoryTransfer1_Ar,
				InventoryTransfer1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some InventoryMovements

			#region InventoryMovement1
			InventoryMovement InventoryMovement1 = new InventoryMovement
			{
				Name = "InventoryMovement 1",
				CreationDate = now
			};
			#endregion

			context.InventoryMovements.AddOrUpdate(entity => entity.Name,
				InventoryMovement1);

			context.SaveChanges();
			#endregion

			#region Add InventoryMovements Translation

			#region InventoryMovement1
			InventoryMovement InventoryMovement1_Ar = new InventoryMovement
			{
				Name = "InventoryMovement 1 ar",
				CreationDate = now,
				ParentKeyInventoryMovementId = InventoryMovement1.Id,
				Language = Language.Arabic
			};
			InventoryMovement InventoryMovement1_En = new InventoryMovement
			{
				Name = "InventoryMovement 1 en",
				CreationDate = now,
				ParentKeyInventoryMovementId = InventoryMovement1.Id,
				Language = Language.English
			};
			#endregion

			context.InventoryMovements.AddOrUpdate(entity => entity.Name,
				InventoryMovement1_Ar,
				InventoryMovement1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some InventoryIns

			#region InventoryIn1
			InventoryIn InventoryIn1 = new InventoryIn
			{
				Name = "InventoryIn 1",
				CreationDate = now
			};
			#endregion

			context.InventoryIns.AddOrUpdate(entity => entity.Name,
				InventoryIn1);

			context.SaveChanges();
			#endregion

			#region Add InventoryIns Translation

			#region InventoryIn1
			InventoryIn InventoryIn1_Ar = new InventoryIn
			{
				Name = "InventoryIn 1 ar",
				CreationDate = now,
				ParentKeyInventoryInId = InventoryIn1.Id,
				Language = Language.Arabic
			};
			InventoryIn InventoryIn1_En = new InventoryIn
			{
				Name = "InventoryIn 1 en",
				CreationDate = now,
				ParentKeyInventoryInId = InventoryIn1.Id,
				Language = Language.English
			};
			#endregion

			context.InventoryIns.AddOrUpdate(entity => entity.Name,
				InventoryIn1_Ar,
				InventoryIn1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some InventoryOuts

			#region InventoryOut1
			InventoryOut InventoryOut1 = new InventoryOut
			{
				Name = "InventoryOut 1",
				CreationDate = now
			};
			#endregion

			context.InventoryOuts.AddOrUpdate(entity => entity.Name,
				InventoryOut1);

			context.SaveChanges();
			#endregion

			#region Add InventoryOuts Translation

			#region InventoryOut1
			InventoryOut InventoryOut1_Ar = new InventoryOut
			{
				Name = "InventoryOut 1 ar",
				CreationDate = now,
				ParentKeyInventoryOutId = InventoryOut1.Id,
				Language = Language.Arabic
			};
			InventoryOut InventoryOut1_En = new InventoryOut
			{
				Name = "InventoryOut 1 en",
				CreationDate = now,
				ParentKeyInventoryOutId = InventoryOut1.Id,
				Language = Language.English
			};
			#endregion

			context.InventoryOuts.AddOrUpdate(entity => entity.Name,
				InventoryOut1_Ar,
				InventoryOut1_En);

			context.SaveChanges();
			#endregion
			
			#region Add Some InventoryDifferences

			#region InventoryDifference1
			InventoryDifference InventoryDifference1 = new InventoryDifference
			{
				Name = "InventoryDifference 1",
				CreationDate = now
			};
			#endregion

			context.InventoryDifferences.AddOrUpdate(entity => entity.Name,
				InventoryDifference1);

			context.SaveChanges();
			#endregion

			#region Add InventoryDifferences Translation

			#region InventoryDifference1
			InventoryDifference InventoryDifference1_Ar = new InventoryDifference
			{
				Name = "InventoryDifference 1 ar",
				CreationDate = now,
				ParentKeyInventoryDifferenceId = InventoryDifference1.Id,
				Language = Language.Arabic
			};
			InventoryDifference InventoryDifference1_En = new InventoryDifference
			{
				Name = "InventoryDifference 1 en",
				CreationDate = now,
				ParentKeyInventoryDifferenceId = InventoryDifference1.Id,
				Language = Language.English
			};
			#endregion

			context.InventoryDifferences.AddOrUpdate(entity => entity.Name,
				InventoryDifference1_Ar,
				InventoryDifference1_En);

			context.SaveChanges();
			#endregion		
			*/
		}
	}
}
