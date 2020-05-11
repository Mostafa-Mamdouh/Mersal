using Framework.Core.Models.ViewModels;
using MersalAccountingService.Core.IServices;
using MersalAccountingService.Core.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MersalAccountingService.WebAPI.Controllers.API
{
    [RoutePrefix("api/Dashboard")]
    public class DashboardController : Base.BaseAPIController
    {
        #region Data Members
        private readonly IChartService _ChartService;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type BankMovementController.
        /// </summary>
        /// <param name="BankMovementsService">The injected service.</param>
        public DashboardController(IChartService ChartService)
        {
            this._ChartService = ChartService;
        }
        #endregion

        #region Actions

        [Route("get-payment-movements-chart")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/BankMovements/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Dashboard/get-payment-movements-chart 
		 */
        public GenericCollectionViewModel<FinancialMovementsChartViewModel> GetPaymentMovementsChart()
        {
            var result = this._ChartService.GetFinancialMovementsChart();
            return result;
        }
        [Route("get-payment-receipt-chart")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/BankMovements/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Dashboard/get-payment-receipt-chart 
		 */
        public GenericCollectionViewModel<FinancialMovementsChartViewModel> GetPaymentAndReceiptChart()
        {
            var result = this._ChartService.GetPaymentAndReceiptChart();
            return result;
        }
        #endregion
    }
}
