#region Using ...
using Framework.Common.Enums;
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
	/// Provides a Product entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * الصنف
	 */
	public class InventoryProductHistory : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type Product.
		/// </summary>
		public InventoryProductHistory()
		{

        }
        #endregion

        #region Properties

        #region IEntityIdentity<T>
        public long Id { get; set; }
		#endregion

		#region IEntityDateTime
		public DateTime CreationDate { get; set; }
		public DateTime? FirstModificationDate { get; set; }
		public DateTime? LastModificationDate { get; set; }
        #endregion

        public long? BrandId { get; set; }
        public Brand Brand { get; set; }
        public long? InventoryId { get; set; }
        public Inventory Inventory { get; set; }

        public string Code { get; set; }

        public decimal Price { get; set; }
        public double Quantity { get; set; }
       
        public decimal NetValue { get; set; }

       

        public virtual Nullable<long> MeasurementUnitId { get; set; }
        public virtual MeasurementUnit MeasurementUnit { get; set; }


        public virtual Nullable<long> InventoryMovementId { get; set; }
        public virtual InventoryMovement InventoryMovement { get; set; }

        public virtual Nullable<long> InventoryTransferId { get; set; }
        public virtual InventoryTransfer InventoryTransfer { get; set; }
        #endregion
    }
}
