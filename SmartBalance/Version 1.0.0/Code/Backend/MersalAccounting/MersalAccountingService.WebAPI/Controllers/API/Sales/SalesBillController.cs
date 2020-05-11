using MersalAccountingService.Core.IServices;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.WebAPI.Controllers.API.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MersalAccountingService.WebAPI.Controllers.API
{
    [RoutePrefix("api/SalesBills")]
    public class SalesBillController : Base.BaseAPIController
    {
        #region Data Members
		private readonly ISalesBillService _salesBillService;
        #endregion

        #region Constructors
        public SalesBillController(ISalesBillService salesBillService)
        {
            this._salesBillService = salesBillService;
        }
        #endregion

        #region Actions
        /// <summary>
        /// Add SalesBill 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [Route("add-salesBill")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/SalesBillCenters/add-salesBill
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/SalesBillCenters/add-salesBill 
		 */
        public SalesBillViewModel Add([FromBody]SalesBillViewModel collection)
        {
            var result = this._salesBillService.Add(collection);
            return result;
        }
        #endregion

    }
}