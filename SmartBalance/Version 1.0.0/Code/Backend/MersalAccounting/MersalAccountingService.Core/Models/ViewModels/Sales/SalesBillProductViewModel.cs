#region Uses
using Framework.Common.Enums;
using Framework.Core.Models.ViewModels.Base;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
#endregion


namespace MersalAccountingService.Core.Models.ViewModels
{
	[DebuggerDisplay("Id={Id}")]
	public class SalesBillProductViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type SalesBillProduct.
        /// </summary>
        public SalesBillProductViewModel()
        {

        }
        #endregion

        #region Properties
        
        public long ProductId { get; set; }
        public decimal Price { get; set; }
        public float Quantity { get; set; }

        #endregion

    }
}
