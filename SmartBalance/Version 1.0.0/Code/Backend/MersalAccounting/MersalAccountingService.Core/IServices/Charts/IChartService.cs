using Framework.Core.IServices.Base;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MersalAccountingService.Core.IServices
{
   public interface IChartService : IBaseService
    {
        GenericCollectionViewModel<FinancialMovementsChartViewModel> GetFinancialMovementsChart();
        GenericCollectionViewModel<FinancialMovementsChartViewModel> GetPaymentAndReceiptChart();

    }
}
