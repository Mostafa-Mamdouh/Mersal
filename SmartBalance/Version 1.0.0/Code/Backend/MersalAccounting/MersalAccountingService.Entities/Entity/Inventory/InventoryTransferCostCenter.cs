﻿#region Using ...
using Framework.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
#endregion

namespace MersalAccountingService.Entities.Entity
{
	/// <summary>
	/// 
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	public class InventoryTransferCostCenter : IEntityIdentity<long>, IEntityDateTimeSignature
    {
        #region Data Members

        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type PurchaseInvoiceCostCenter.
        /// </summary>
        public InventoryTransferCostCenter()
        {

        }
        #endregion

        #region Properties

        #region IEntityIdentity<T>
        public long Id { get; set; }
        #endregion

        #region IEntityDateTimeSignature
        public DateTime CreationDate { get; set; }
        public DateTime? FirstModificationDate { get; set; }
        public DateTime? LastModificationDate { get; set; }
        #endregion

        public Nullable<long> CostCenterId { get; set; }
        public virtual CostCenter CostCenter { get; set; }

        public Nullable<long> InventoryTransferId { get; set; }
        public virtual InventoryTransfer InventoryTransfer { get; set; }
        #endregion
    }
}
