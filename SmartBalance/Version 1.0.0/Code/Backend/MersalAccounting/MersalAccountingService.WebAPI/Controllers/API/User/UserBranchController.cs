#region Using ...
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
#endregion

namespace MersalAccountingService.WebAPI.Controllers.API
{
    [RoutePrefix("api/UserBranchs")]
    public class UserBranchController : Base.BaseAPIController
    {
        #region Data Members
        private readonly IUserBranchsService _userBranchsService;
        #endregion

        #region Constructors
        public UserBranchController(IUserBranchsService userBranchsService)
        {
            this._userBranchsService = userBranchsService;
        }
        #endregion

        #region Actions

        /// <summary>
        /// Gets a GenericCollectionViewModel of UserBranchViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-by-condition")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserBranchs/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserBranchs/get-by-condition 
		 */
        public GenericCollectionViewModel<UserBranchViewModel> Get(ConditionFilter<UserBranch, long> condition)
        {
            var result = this._userBranchsService.Get(condition);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of UserBranchViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-by-pagger/{pageIndex}/{pageSize}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserBranchs/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserBranchs/get-by-pagger/0/10 
		 */
        public GenericCollectionViewModel<UserBranchViewModel> Get(int? pageIndex, int? pageSize)
        {
            var result = this._userBranchsService.Get(pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of UserBranchViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-light-by-condition")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserBranchs/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserBranchs/get-light-by-condition 
		 */
        public GenericCollectionViewModel<UserBranchLightViewModel> GetLightModel(ConditionFilter<UserBranch, long> condition)
        {
            var result = this._userBranchsService.GetLightModel(condition);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of UserBranchViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserBranchs/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserBranchs/get-light-by-pagger/0/10 
		 */
        public GenericCollectionViewModel<UserBranchLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
        {
            var result = this._userBranchsService.GetLightModel(pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// Gets a UserBranchViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("get/{id}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserBranchs/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserBranchs/get/1 
		 */
        public UserBranchViewModel Get(long id)
        {
            var result = this._userBranchsService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserBranchs/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserBranchs/add-collection 
		 */
        public IList<UserBranchViewModel> Add([FromBody]IEnumerable<UserBranchViewModel> collection)
        {
            var result = this._userBranchsService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserBranchs/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserBranchs/add 
		 */
        public UserBranchViewModel Add([FromBody]UserBranchViewModel model)
        {
            var result = this._userBranchsService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserBranchs/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserBranchs/update-collection 
		 */
        public IList<UserBranchViewModel> Update([FromBody]IEnumerable<UserBranchViewModel> collection)
        {
            var result = this._userBranchsService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserBranchs/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserBranchs/update 
		 */
        public UserBranchViewModel Update([FromBody]UserBranchViewModel model)
        {
            var result = this._userBranchsService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserBranchs/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserBranchs/delete-collection 
		 */
        public void Delete([FromBody]IEnumerable<UserBranchViewModel> collection)
        {
            this._userBranchsService.Delete(collection);
        }

        /// <summary>
        /// Delete entities by its id collection.
        /// </summary>
        /// <param name="collection"></param>
        [Route("delete-id-collection")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserBranchs/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserBranchs/delete-id-collection 
		 */
        public void Delete([FromBody]IEnumerable<long> collection)
        {
            this._userBranchsService.Delete(collection);
        }

        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="model"></param>
        [Route("delete")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserBranchs/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserBranchs/delete 
		 */
        public void Delete([FromBody]UserBranchViewModel model)
        {
            this._userBranchsService.Delete(model);
        }

        /// <summary>
        /// Delete an entity by id.
        /// </summary>
        /// <param name="id"></param>
        [Route("delete/{id}")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/UserBranchs/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/UserBranchs/delete/1 
		 */
        public void Delete(long id)
        {
            this._userBranchsService.Delete(id);
        }

        #endregion
    }
}
