#region Using ...
using Framework.Core.IRepositories;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Core.IServices;
using MersalAccountingService.Core.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
#endregion

namespace MersalAccountingService.BusinessLogic.Services
{
   public class ChartService : IChartService
    {
        #region Data Members
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type BanksService.
        /// </summary>
        /// <param name="BanksRepository"></param>
        /// <param name="unitOfWork"></param>
        public ChartService(
            IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }


        #endregion

        #region Methods
        public GenericCollectionViewModel<FinancialMovementsChartViewModel> GetFinancialMovementsChart()
        {
           var dtoCollection= _unitOfWork.SQLQuery<FinancialMovementsChartViewModel>("SP_GetFinancialMovementsChart", "").ToList();
            var result = new GenericCollectionViewModel<FinancialMovementsChartViewModel>
            {
                Collection = dtoCollection
            };
            return result;
        }

        public GenericCollectionViewModel<FinancialMovementsChartViewModel> GetPaymentAndReceiptChart()
        {
            var dtoCollection = _unitOfWork.SQLQuery<FinancialMovementsChartViewModel>("SP_GetPaymentAndReceiptChart", "").ToList();
            var result = new GenericCollectionViewModel<FinancialMovementsChartViewModel>
            {
                Collection = dtoCollection
            };
            return result;
        }
        #endregion
    }
}
