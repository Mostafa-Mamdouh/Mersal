using Framework.Core.Filters;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Common.Enums;
using MersalAccountingService.Core.IServices;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Entities.Entity;
using MersalAccountingService.WebAPI.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MersalAccountingService.WebAPI.Controllers.API
{
    public class ObjectCostCentersController : Base.BaseAPIController
    {
        #region Data Members
        private readonly IObjectCostCentersService _objectCostCentersService;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type CostCenterController.
        /// </summary>
        /// <param name="objectCostCentersService">The injected service.</param>
        public ObjectCostCentersController(IObjectCostCentersService objectCostCentersService)
        {
            this._objectCostCentersService = objectCostCentersService;
        }
        #endregion

        #region Actions

        //[Route("get-with-filter")]
        //[HttpPost]
        //public GenericCollectionViewModel<ListCostCenterLightViewModel> GetByFilter([FromBody]CostCenterFilterViewModel model)
        //{
        //    var result = this._objectCostCentersService.GetByFilter(model);
        //    return result;
        //}

        /// <summary>
        /// Gets a GenericCollectionViewModel of CostCenterViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-by-condition")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/CostCenters/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/CostCenters/get-by-condition 
		 */
        public GenericCollectionViewModel<ObjectCostCenterViewModel> Get(ConditionFilter<ObjectCostCenter, long> condition)
        {
            var result = this._objectCostCentersService.Get(condition);
            return result;
        }
   //     [Route("get-lookup")]
   //     [HttpGet]
   //     /*
		 //* HttpVerb: Get
		 //* URL Pattern: http[s]://IPAddress:PortNumber/api/CostCenters/get-lookup
		 //* Usage: http://localhost/MersalAccountingService.WebAPI/api/ObjectCostCenters/get-lookup
		 //*/
   //     public List<ObjectCostCenterLightViewModel> GetLookup()
   //     {
   //         var result = this._objectCostCentersService.GetLookUp();
   //         return result;
   //     }
        /// <summary>
        /// Gets a GenericCollectionViewModel of ObjectCostCenterViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-by-pagger/{pageIndex}/{pageSize}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ObjectCostCenters/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ObjectCostCenters/get-by-pagger/0/10 
		 */
        public GenericCollectionViewModel<ObjectCostCenterViewModel> Get(int? pageIndex, int? pageSize)
        {
            var result = this._objectCostCentersService.Get(pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of ObjectCostCenterViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
   //     [Route("get-light-by-condition")]
   //     [HttpPost]
   //     /*
		 //* HttpVerb: POST
		 //* URL Pattern: http[s]://IPAddress:PortNumber/api/ObjectCostCenters/get-light-by-condition
		 //* Usage: http://localhost/MersalAccountingService.WebAPI/api/ObjectCostCenters/get-light-by-condition 
		 //*/
   //     public GenericCollectionViewModel<ObjectCostCenterLightViewModel> GetLightModel(ConditionFilter<ObjectCostCenter, long> condition)
   //     {
   //         var result = this._objectCostCentersService.GetLightModel(condition);
   //         return result;
   //     }

        /// <summary>
        /// Gets a GenericCollectionViewModel of ObjectCostCenterViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
   //     [Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
   //     [HttpGet]
   //     /*
		 //* HttpVerb: Get
		 //* URL Pattern: http[s]://IPAddress:PortNumber/api/ObjectCostCenters/get-light-by-pagger/{pageIndex}/{pageSize}
		 //* Usage: http://localhost/MersalAccountingService.WebAPI/api/ObjectCostCenters/get-light-by-pagger/0/10 
		 //*/
   //     public GenericCollectionViewModel<ObjectCostCenterLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
   //     {
   //         var result = this._objectCostCentersService.GetLightModel(pageIndex, pageSize);
   //         return result;
   //     }

        /// <summary>
        /// Gets a CostCenterViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("get/{id}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ObjectCostCenters/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ObjectCostCenters/get/1 
		 */
        public ObjectCostCenterViewModel Get(long id)
        {
            var result = this._objectCostCentersService.Get(id);
            return result;
        }


        /// <summary>
        /// Add entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [Route("add-collection")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ObjectCostCenters/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ObjectCostCenters/add-collection 
		 */
        public IList<ObjectCostCenterViewModel> Add([FromBody]IEnumerable<ObjectCostCenterViewModel> collection)
        {
            var result = this._objectCostCentersService.Add(collection);
            return result;
        }

        /// <summary>
        /// Add an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("add")]
        [HttpPost]
        //[JwtAuthentication(Permissions.AddObjectCostCenter)]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ObjectCostCenters/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ObjectCostCenters/add 
		 */
        public ObjectCostCenterViewModel Add([FromBody]ObjectCostCenterViewModel model)
        {
            var result = this._objectCostCentersService.Add(model);
            return result;
        }


        /// <summary>
        /// Update entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [Route("update-collection")]
        [HttpPost]
        /*
		 * HttpVerb: PUT
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ObjectCostCenters/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ObjectCostCenters/update-collection 
		 */
        public IList<ObjectCostCenterViewModel> Update([FromBody]IEnumerable<ObjectCostCenterViewModel> collection)
        {
            var result = this._objectCostCentersService.Update(collection);
            return result;
        }

        /// <summary>
        /// Update an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("update")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ObjectCostCenters/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ObjectCostCenters/update 
		 */
        public ObjectCostCenterViewModel Update([FromBody]ObjectCostCenterViewModel model)
        {
            var result = this._objectCostCentersService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ObjectCostCenters/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ObjectCostCenters/delete-collection 
		 */
        public void Delete([FromBody]IEnumerable<ObjectCostCenterViewModel> collection)
        {
            this._objectCostCentersService.Delete(collection);
        }

        /// <summary>
        /// Delete entities by its id collection.
        /// </summary>
        /// <param name="collection"></param>
        [Route("delete-id-collection")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ObjectCostCenters/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ObjectCostCenters/delete-id-collection 
		 */
        public void Delete([FromBody]IEnumerable<long> collection)
        {
            this._objectCostCentersService.Delete(collection);
        }

        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="model"></param>
        [Route("delete")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ObjectCostCenters/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ObjectCostCenters/delete 
		 */
        public void Delete([FromBody]ObjectCostCenterViewModel model)
        {
            this._objectCostCentersService.Delete(model);
        }

        /// <summary>
        /// Delete an entity by id.
        /// </summary>
        /// <param name="id"></param>
        [Route("delete/{id}")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/ObjectCostCenters/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/ObjectCostCenters/delete/1 
		 */
        public void Delete(long id)
        {
            this._objectCostCentersService.Delete(id);
        }

        #endregion
    }
}
