#region Using ...
using Framework.Core.Filters;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Core.IServices;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels.LightViewModels;
using MersalAccountingService.Entities.Entity;
using System.Collections.Generic;
using System.Web.Http;
#endregion

namespace MersalAccountingService.WebAPI.Controllers.API
{
    /// <summary>
    /// UserMenuItems Controller
    /// </summary>
    [RoutePrefix("api/UserMenuItems")]
    public class UserMenuItemsController : Base.BaseAPIController
    {
        #region Data Members
        private readonly IUserMenuItemsService _UserMenuItemsService;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type UserMenuItemController.
        /// </summary>
        /// <param name="UserMenuItemsService">The injected service.</param>
        public UserMenuItemsController(IUserMenuItemsService UserMenuItemsService)
        {
            this._UserMenuItemsService = UserMenuItemsService;
        }
        #endregion

        #region Actions

        /// <summary>
        /// Gets a GenericCollectionViewModel of UserMenuItemViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-by-condition")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserMenuItems/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserMenuItems/get-by-condition 
		 */
        public GenericCollectionViewModel<UserMenuItemViewModel> Get(ConditionFilter<UserMenuItem, long> condition)
        {
            var result = this._UserMenuItemsService.Get(condition);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of UserMenuItemViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-by-pagger/{pageIndex}/{pageSize}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserMenuItems/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserMenuItems/get-by-pagger/0/10 
		 */
        public GenericCollectionViewModel<UserMenuItemViewModel> Get(int? pageIndex, int? pageSize)
        {
            var result = this._UserMenuItemsService.Get(pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of UserMenuItemViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-light-by-condition")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserMenuItems/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserMenuItems/get-light-by-condition 
		 */
        public GenericCollectionViewModel<UserMenuItemLightViewModel> GetLightModel(ConditionFilter<UserMenuItem, long> condition)
        {
            var result = this._UserMenuItemsService.GetLightModel(condition);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of UserMenuItemViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserMenuItems/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserMenuItems/get-light-by-pagger/0/10 
		 */
        public GenericCollectionViewModel<UserMenuItemLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
        {
            var result = this._UserMenuItemsService.GetLightModel(pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// Gets a UserMenuItemViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("get/{id}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserMenuItems/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserMenuItems/get/1 
		 */
        public UserMenuItemViewModel Get(long id)
        {
            var result = this._UserMenuItemsService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserMenuItems/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserMenuItems/add-collection 
		 */
        public IList<UserMenuItemViewModel> Add([FromBody]IEnumerable<UserMenuItemViewModel> collection)
        {
            var result = this._UserMenuItemsService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserMenuItems/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserMenuItems/add 
		 */
        public UserMenuItemViewModel Add([FromBody]UserMenuItemViewModel model)
        {
            var result = this._UserMenuItemsService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserMenuItems/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserMenuItems/update-collection 
		 */
        public IList<UserMenuItemViewModel> Update([FromBody]IEnumerable<UserMenuItemViewModel> collection)
        {
            var result = this._UserMenuItemsService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserMenuItems/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserMenuItems/update 
		 */
        public UserMenuItemViewModel Update([FromBody]UserMenuItemViewModel model)
        {
            var result = this._UserMenuItemsService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserMenuItems/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserMenuItems/delete-collection 
		 */
        public void Delete([FromBody]IEnumerable<UserMenuItemViewModel> collection)
        {
            this._UserMenuItemsService.Delete(collection);
        }

        /// <summary>
        /// Delete entities by its id collection.
        /// </summary>
        /// <param name="collection"></param>
        [Route("delete-id-collection")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserMenuItems/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserMenuItems/delete-id-collection 
		 */
        public void Delete([FromBody]IEnumerable<long> collection)
        {
            this._UserMenuItemsService.Delete(collection);
        }

        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="model"></param>
        [Route("delete")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserMenuItems/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserMenuItems/delete 
		 */
        public void Delete([FromBody]UserMenuItemViewModel model)
        {
            this._UserMenuItemsService.Delete(model);
        }

        /// <summary>
        /// Delete an entity by id.
        /// </summary>
        /// <param name="id"></param>
        [Route("delete/{id}")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserMenuItems/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserMenuItems/delete/1 
		 */
        public void Delete(long id)
        {
            this._UserMenuItemsService.Delete(id);
        }

        #endregion
    }
}
