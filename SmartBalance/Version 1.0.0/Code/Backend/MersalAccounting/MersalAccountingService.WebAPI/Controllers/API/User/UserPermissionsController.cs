#region Using ...
using Framework.Core.Filters;
using Framework.Core.Models.DTOs;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Core.IServices;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels.LightViewModels;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
#endregion

namespace MersalAccountingService.WebAPI.Controllers.API
{
    /// <summary>
    /// UserPermissions Controller
    /// </summary>
    [RoutePrefix("api/UserPermissions")]
    public class UserPermissionsController : Base.BaseAPIController
    {
        #region Data Members
        private readonly IUserPermissionsService _UserPermissionsService;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type UserPermissionController.
        /// </summary>
        /// <param name="UserPermissionsService">The injected service.</param>
        public UserPermissionsController(IUserPermissionsService UserPermissionsService)
        {
            this._UserPermissionsService = UserPermissionsService;
        }
        #endregion

        #region Actions

        /// <summary>
        /// Gets a GenericCollectionViewModel of UserPermissionViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-by-condition")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserPermissions/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserPermissions/get-by-condition 
		 */
        public GenericCollectionViewModel<UserPermissionViewModel> Get(ConditionFilter<UserPermission, long> condition)
        {
            var result = this._UserPermissionsService.Get(condition);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of UserPermissionViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-by-pagger/{pageIndex}/{pageSize}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserPermissions/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserPermissions/get-by-pagger/0/10 
		 */
        public GenericCollectionViewModel<UserPermissionViewModel> Get(int? pageIndex, int? pageSize)
        {
            var result = this._UserPermissionsService.Get(pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of UserPermissionViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-light-by-condition")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserPermissions/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserPermissions/get-light-by-condition 
		 */
        public GenericCollectionViewModel<UserPermissionLightViewModel> GetLightModel(ConditionFilter<UserPermission, long> condition)
        {
            var result = this._UserPermissionsService.GetLightModel(condition);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of UserPermissionViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserPermissions/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserPermissions/get-light-by-pagger/0/10 
		 */
        public GenericCollectionViewModel<UserPermissionLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
        {
            var result = this._UserPermissionsService.GetLightModel(pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// Gets a UserPermissionViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("get/{id}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserPermissions/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserPermissions/get/1 
		 */
        public UserPermissionViewModel Get(long id)
        {
            var result = this._UserPermissionsService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserPermissions/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserPermissions/add-collection 
		 */
        public IList<UserPermissionViewModel> Add([FromBody]IEnumerable<UserPermissionViewModel> collection)
        {
            var result = this._UserPermissionsService.Add(collection);
            return result;
        }

        /// <summary>
        /// Add an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("add")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserPermissions/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserPermissions/add 
		 */
        public UserPermissionViewModel Add([FromBody]UserPermissionViewModel model)
        {
            var result = this._UserPermissionsService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserPermissions/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserPermissions/update-collection 
		 */
        public IList<UserPermissionViewModel> Update([FromBody]IEnumerable<UserPermissionViewModel> collection)
        {
            var result = this._UserPermissionsService.Update(collection);
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
		 * HttpVerb: PUT
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserPermissions/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserPermissions/update 
		 */
        public UserPermissionViewModel Update([FromBody]UserPermissionViewModel model)
        {
            var result = this._UserPermissionsService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserPermissions/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserPermissions/delete-collection 
		 */
        public void Delete([FromBody]IEnumerable<UserPermissionViewModel> collection)
        {
            this._UserPermissionsService.Delete(collection);
        }

        /// <summary>
        /// Delete entities by its id collection.
        /// </summary>
        /// <param name="collection"></param>
        [Route("delete-id-collection")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserPermissions/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserPermissions/delete-id-collection 
		 */
        public void Delete([FromBody]IEnumerable<long> collection)
        {
            this._UserPermissionsService.Delete(collection);
        }

        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="model"></param>
        [Route("delete")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserPermissions/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserPermissions/delete 
		 */
        public void Delete([FromBody]UserPermissionViewModel model)
        {
            this._UserPermissionsService.Delete(model);
        }

        /// <summary>
        /// Delete an entity by id.
        /// </summary>
        /// <param name="id"></param>
        [Route("delete/{id}")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserPermissions/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserPermissions/delete/1 
		 */
        public void Delete(long id)
        {
            this._UserPermissionsService.Delete(id);
        }

        #endregion
    }
}
