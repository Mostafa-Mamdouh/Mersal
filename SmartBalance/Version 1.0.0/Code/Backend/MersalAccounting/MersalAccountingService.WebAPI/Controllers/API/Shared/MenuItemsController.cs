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
    /// MenuItems Controller
    /// </summary>
    [RoutePrefix("api/MenuItems")]
    public class MenuItemsController : Base.BaseAPIController
    {
        #region Data Members
        private readonly IMenuItemsService _MenuItemsService;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type MenuItemController.
        /// </summary>
        /// <param name="MenuItemsService">The injected service.</param>
        public MenuItemsController(IMenuItemsService MenuItemsService)
        {
            this._MenuItemsService = MenuItemsService;
        }
        #endregion

        #region Actions

        [Route("get-all-un-selected-users-for-menu-item/{menuItemId}")]
        [HttpGet]
        public IList<UserLightViewModel> GetAllUnSelectedUsersForMenuItem(long menuItemId)
        {
            var result = this._MenuItemsService.GetAllUnSelectedUsersForMenuItem(menuItemId);
            return result;
        }
		[Route("get-menu-item-users/{menuItemId}")]
		[HttpGet]
		public MenuItemUsersListViewModel GetMenuItemUsers(long menuItemId)
		{
			var result = this._MenuItemsService.GetMenuItemUsers(menuItemId);
			return result;
		}
		[Route("update-menu-item-users")]
		[HttpPost]
		public MenuItemUsersListViewModel UpdateMenuItemUsers([FromBody]MenuItemUsersListViewModel model)
		{
			var result = this._MenuItemsService.UpdateMenuItemUsers(model);
			return result;
		}



		[Route("get-all-un-selected-menu-items-for-user/{userId}")]
		[HttpGet]
		public IList<MenuItemLightViewModel> GetAllUnSelectedMenuItemForUser(long userId)
		{
			var result = this._MenuItemsService.GetAllUnSelectedMenuItemsForUser(userId);
			return result;
		}
		[Route("get-user-menu-items/{userId}")]
		[HttpGet]
		public UserMenuItemsListViewModel GetUserMenuItem(long userId)
		{
			var result = this._MenuItemsService.GetUserMenuItems(userId);
			return result;
		}
		[Route("update-user-menu-items")]
		[HttpPost]
		public UserMenuItemsListViewModel UpdateMenuItemUsers([FromBody]UserMenuItemsListViewModel model)
		{
			var result = this._MenuItemsService.UpdateUserMenuItems(model);
			return result;
		}


		/// <summary>
		/// Gets a GenericCollectionViewModel of RoleViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		//[Route("get-by-condition")]
		//      [HttpPost]
		//      /*
		// * HttpVerb: POST
		// * URL Pattern: http[s]://IPAddress:PortNumber/api/Roles/get-by-condition
		// * Usage: http://localhost/MersalAccountingService.WebAPI/api/Roles/get-by-condition 
		// */
		//      public GenericCollectionViewModel<RoleViewModel> Get(ConditionFilter<Role, long> condition)
		//      {
		//          var result = this._RolesService.Get(condition);
		//          return result;
		//      }

		/// <summary>
		/// Gets a GenericCollectionViewModel of MenuItemViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/MenuItems/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/MenuItems/get-by-condition 
		 */
        public GenericCollectionViewModel<MenuItemViewModel> Get(ConditionFilter<MenuItem, long> condition)
        {
            var result = this._MenuItemsService.Get(condition);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of MenuItemViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-by-pagger/{pageIndex}/{pageSize}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/MenuItems/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/MenuItems/get-by-pagger/0/10 
		 */
        public GenericCollectionViewModel<MenuItemViewModel> Get(int? pageIndex, int? pageSize)
        {
            var result = this._MenuItemsService.Get(pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of MenuItemViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-light-by-condition")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/MenuItems/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/MenuItems/get-light-by-condition 
		 */
        public GenericCollectionViewModel<MenuItemLightViewModel> GetLightModel(ConditionFilter<MenuItem, long> condition)
        {
            var result = this._MenuItemsService.GetLightModel(condition);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of MenuItemViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/MenuItems/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/MenuItems/get-light-by-pagger/0/10 
		 */
        public GenericCollectionViewModel<MenuItemLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
        {
            var result = this._MenuItemsService.GetLightModel(pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// Gets a MenuItemViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("get/{id}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/MenuItems/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/MenuItems/get/1 
		 */
        public MenuItemViewModel Get(long id)
        {
            var result = this._MenuItemsService.Get(id);
            return result;
        }
      

        /// <summary>
        /// Gets a GenericCollectionViewModel of ListMenuItemsLightViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-with-filter")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/MenuItems/get-with-filter
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/MenuItems/get-with-filter 
		 */
        public GenericCollectionViewModel<ListMenuItemsLightViewModel> GetByFilter([FromBody]MenuItemFilterViewModel model)
        {
            var result = this._MenuItemsService.GetByFilter(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/MenuItems/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/MenuItems/add-collection 
		 */
        public IList<MenuItemViewModel> Add([FromBody]IEnumerable<MenuItemViewModel> collection)
        {
            var result = this._MenuItemsService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/MenuItems/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/MenuItems/add 
		 */
        public MenuItemViewModel Add([FromBody]MenuItemViewModel model)
        {
            var result = this._MenuItemsService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/MenuItems/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/MenuItems/update-collection 
		 */
        public IList<MenuItemViewModel> Update([FromBody]IEnumerable<MenuItemViewModel> collection)
        {
            var result = this._MenuItemsService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/MenuItems/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/MenuItems/update 
		 */
        public MenuItemViewModel Update([FromBody]MenuItemViewModel model)
        {
            var result = this._MenuItemsService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/MenuItems/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/MenuItems/delete-collection 
		 */
        public void Delete([FromBody]IEnumerable<MenuItemViewModel> collection)
        {
            this._MenuItemsService.Delete(collection);
        }

        /// <summary>
        /// Delete entities by its id collection.
        /// </summary>
        /// <param name="collection"></param>
        [Route("delete-id-collection")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/MenuItems/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/MenuItems/delete-id-collection 
		 */
        public void Delete([FromBody]IEnumerable<long> collection)
        {
            this._MenuItemsService.Delete(collection);
        }

        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="model"></param>
        [Route("delete")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/MenuItems/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/MenuItems/delete 
		 */
        public void Delete([FromBody]MenuItemViewModel model)
        {
            this._MenuItemsService.Delete(model);
        }

        /// <summary>
        /// Delete an entity by id.
        /// </summary>
        /// <param name="id"></param>
        [Route("delete/{id}")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/MenuItems/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/MenuItems/delete/1 
		 */
        public void Delete(long id)
        {
            this._MenuItemsService.Delete(id);
        }

        #endregion
    }
}
