using Framework.Core.IServices.Base;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MersalAccountingService.Core.IServices
{
    public interface ISalesBillService : IBaseService
    {
        #region validation
        //void CodeValidation(string code);
        void ThrowValidationException(SalesBillViewModel model);
        void DateValidation(SalesBillViewModel model);
        void CostCenterIdsValidation(SalesBillViewModel CostCenterId);
        void DelegateManValidation(SalesBillViewModel model);
        void SalesBillTypeValidation(SalesBillViewModel model);
        void InventoryIdValidation(SalesBillViewModel model);
        void DonatorIdValidation(SalesBillViewModel model);
        void ProductsAndCostValidation(SalesBillViewModel model);
        #endregion

        #region Methods
        //void ThrowExceptionIfExist(SalesBill model);
        SalesBillViewModel Add(SalesBillViewModel model);
        #endregion
    }
}
