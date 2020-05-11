#region Using ...
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Common.Enums
{
	/// <summary>
	/// 
	/// </summary>
	public enum ObjectType : Byte
	{
		Bank = 1,
		Safe,
		Vendor,
		AccountChart,
		CostCenter,
		Case,
		Donator,
		User,
		Delegate,
		Branch,
		BankMovement,
		PurchaseInvoice,
		PurchaseRebate,
		Donation,
		PaymentMovment,
		InventoryMovement,
		InventoryOpeningBalance,
		InventoryTransfer,
        Inventory,
		Asset,
        Translated,
        Liquidation
    }
}
