using Framework.Core.Filters;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Core.IServices;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MersalAccountingService.WebAPI.Controllers.API
{
    [RoutePrefix("api/Liquidations")]
    public class LiquidationController : ApiController
    {
        #region Data Members
        private readonly ILiquidationService _LiquidationService;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type LiquidationController.
        /// </summary>
        /// <param name="LiquidationService">The injected service.</param>
        public LiquidationController(ILiquidationService LiquidationService)
        {
            this._LiquidationService = LiquidationService;
        }
        #endregion

        #region Actions

        //[Route("get-with-filter")]
        //[HttpPost]
        ////[JwtAuthentication(Permissions.LiquidationList)]
        //public GenericCollectionViewModel<ListDiscountPercentegesLightViewModel> GetByFilter([FromBody]LiquidationFilterViewModel model)
        //{
        //    var result = this._LiquidationService.GetByFilter(model);
        //    return result;
        //}

        /// <summary>
        /// Gets a GenericCollectionViewModel of LiquidationViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-by-condition")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Liquidation/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Liquidation/get-by-condition 
		 */
        public GenericCollectionViewModel<LiquidationViewModel> Get(ConditionFilter<Liquidation, long> condition)
        {
            var result = this._LiquidationService.Get(condition);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of LiquidationViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
   //     [Route("get-by-pagger/{pageIndex}/{pageSize}")]
   //     [HttpGet]
   //     /*
		 //* HttpVerb: Get
		 //* URL Pattern: http[s]://IPAddress:PortNumber/api/Liquidation/get-by-pagger/{pageIndex}/{pageSize}
		 //* Usage: http://localhost/MersalAccountingService.WebAPI/api/Liquidation/get-by-pagger/0/10 
		 //*/
   //     public GenericCollectionViewModel<LiquidationViewModel> Get(long? pageIndex, long? pageSize)
   //     {
   //         var result = this._LiquidationService.Get(pageIndex, pageSize);
   //         return result;
   //     }

        /// <summary>
        /// Gets a GenericCollectionViewModel of LiquidationViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
   //     [Route("get-light-by-condition")]
   //     [HttpPost]
   //     /*
		 //* HttpVerb: POST
		 //* URL Pattern: http[s]://IPAddress:PortNumber/api/Liquidation/get-light-by-condition
		 //* Usage: http://localhost/MersalAccountingService.WebAPI/api/Liquidation/get-light-by-condition 
		 //*/
   //     public GenericCollectionViewModel<LiquidationLightViewModel> GetLightModel(ConditionFilter<Liquidation, long> condition)
   //     {
   //         var result = this._LiquidationService.GetLightModel(condition);
   //         return result;
   //     }

        /// <summary>
        /// Gets a GenericCollectionViewModel of LiquidationViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
   //     [Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
   //     [HttpGet]
   //     /*
		 //* HttpVerb: Get
		 //* URL Pattern: http[s]://IPAddress:PortNumber/api/Liquidation/get-light-by-pagger/{pageIndex}/{pageSize}
		 //* Usage: http://localhost/MersalAccountingService.WebAPI/api/Liquidation/get-light-by-pagger/0/10 
		 //*/
   //     public GenericCollectionViewModel<LiquidationLightViewModel> GetLightModel(long? pageIndex, long? pageSize)
   //     {
   //         var result = this._LiquidationService.GetLightModel(pageIndex, pageSize);
   //         return result;
   //     }

        /// <summary>
        /// Gets a LiquidationViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("get/{id}")]
        [HttpGet]
        //[JwtAuthentication(Permissions.LiquidationList)]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Liquidation/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Liquidation/get/1 
		 */
        public LiquidationViewModel Get(long id)
        {
            var result = this._LiquidationService.Get(id);
            return result;
        }

        [Route("get-unliquidation/{costCenterId}/{liquidationType}/{isClosed}")]
        [HttpGet]
        public List<LiquidationDetailViewModel> GetUnliquidation(long costCenterId, long? liquidationType, bool? isClosed)
        {
            var result = this._LiquidationService.GetUnliquidation(costCenterId, liquidationType, isClosed);
            return result;
        }

        [Route("generate-new-code/{lastCode}")]
        [HttpGet]
        public string GenerateNewCode(string lastCode)
        {
            var result = this._LiquidationService.GenerateNewCode(lastCode);
            return result;
        }


        /// <summary>
        /// Add entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [Route("add-collection")]
        [HttpPost]
        //[JwtAuthentication(Permissions.AddLiquidation)]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Liquidation/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Liquidation/add-collection 
		 */
        public IList<LiquidationViewModel> Add([FromBody]IEnumerable<LiquidationViewModel> collection)
        {
            var result = this._LiquidationService.Add(collection);
            return result;
        }

        /// <summary>
        /// Add an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("add")]
        [HttpPost]
        //[JwtAuthentication(Permissions.AddLiquidation)]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Liquidation/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Liquidation/add 
		 */
        public LiquidationViewModel Add([FromBody]LiquidationViewModel model)
        {
            var result = this._LiquidationService.Add(model);
            return result;
        }


        /// <summary>
        /// Update entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [Route("update-collection")]
        [HttpPost]
        //[JwtAuthentication(Permissions.EditLiquidation)]
        /*
		 * HttpVerb: PUT
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Liquidation/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Liquidation/update-collection 
		 */
        public IList<LiquidationViewModel> Update([FromBody]IEnumerable<LiquidationViewModel> collection)
        {
            var result = this._LiquidationService.Update(collection);
            return result;
        }

        /// <summary>
        /// Update an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("update")]
        [HttpPost]
        //[JwtAuthentication(Permissions.EditLiquidation)]
        /*
		 * HttpVerb: PUT
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Liquidation/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Liquidation/update 
		 */
        public LiquidationViewModel Update([FromBody]LiquidationViewModel model)
        {
            var result = this._LiquidationService.Update(model);
            return result;
        }


        /// <summary>
        /// Delete entities.
        /// </summary>
        /// <param name="collection"></param>
        [Route("delete-collection")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Liquidation/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Liquidation/delete-collection 
		 */
        public void Delete([FromBody]IEnumerable<LiquidationViewModel> collection)
        {
            this._LiquidationService.Delete(collection);
        }

        /// <summary>
        /// Delete entities by its id collection.
        /// </summary>
        /// <param name="collection"></param>
        [Route("delete-id-collection")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Liquidation/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Liquidation/delete-id-collection 
		 */
        public void Delete([FromBody]IEnumerable<long> collection)
        {
            this._LiquidationService.Delete(collection);
        }

        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="model"></param>
        [Route("delete")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Liquidation/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Liquidation/delete 
		 */
        public void Delete([FromBody]LiquidationViewModel model)
        {
            this._LiquidationService.Delete(model);
        }

        /// <summary>
        /// Delete an entity by id.
        /// </summary>
        /// <param name="id"></param>
        [Route("delete/{id}")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Liquidation/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Liquidation/delete/1 
		 */
        public void Delete(long id)
        {
            this._LiquidationService.Delete(id);
        }

        #endregion
    }
}
