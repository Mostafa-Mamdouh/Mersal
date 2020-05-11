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
    /// JournalPostings Controller
    /// </summary>
    [RoutePrefix("api/JournalPostings")]
    public class JournalPostingsController : Base.BaseAPIController
    {
        #region Data Members
        private readonly IJournalPostingsService _JournalPostingsService;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type JournalPostingController.
        /// </summary>
        /// <param name="JournalPostingsService">The injected service.</param>
        public JournalPostingsController(IJournalPostingsService JournalPostingsService)
        {
            this._JournalPostingsService = JournalPostingsService;
        }
        #endregion

        #region Actions

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("journal-posting")]
        [HttpPost]
        public JournalPostingViewModel PostJournal(JournalPostingViewModel model)
        {
            var result = this._JournalPostingsService.PostJournal(model);
            return result;
        }
       


        /// <summary>
        /// Gets a GenericCollectionViewModel of JournalPostingViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-by-condition")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/JournalPostings/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/JournalPostings/get-by-condition 
		 */
        public GenericCollectionViewModel<JournalPostingViewModel> Get(ConditionFilter<JournalPosting, long> condition)
        {
            var result = this._JournalPostingsService.Get(condition);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of JournalPostingViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-by-pagger/{pageIndex}/{pageSize}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/JournalPostings/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/JournalPostings/get-by-pagger/0/10 
		 */
        public GenericCollectionViewModel<JournalPostingViewModel> Get(int? pageIndex, int? pageSize)
        {
            var result = this._JournalPostingsService.Get(pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of JournalPostingViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-light-by-condition")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/JournalPostings/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/JournalPostings/get-light-by-condition 
		 */
        public GenericCollectionViewModel<JournalPostingLightViewModel> GetLightModel(ConditionFilter<JournalPosting, long> condition)
        {
            var result = this._JournalPostingsService.GetLightModel(condition);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of JournalPostingViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/JournalPostings/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/JournalPostings/get-light-by-pagger/0/10 
		 */
        public GenericCollectionViewModel<JournalPostingLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
        {
            var result = this._JournalPostingsService.GetLightModel(pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// Gets a JournalPostingViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("get/{id}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/JournalPostings/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/JournalPostings/get/1 
		 */
        public JournalPostingViewModel Get(long id)
        {
            var result = this._JournalPostingsService.Get(id);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("get-with-filter")]
        [HttpPost]
        public GenericCollectionViewModel<ListJournalPostingLightViewModel> GetByFilter(JournalPostingFilterViewModel model)
        {
            var result = this._JournalPostingsService.GetByFilter(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/JournalPostings/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/JournalPostings/add-collection 
		 */
        public IList<JournalPostingViewModel> Add([FromBody]IEnumerable<JournalPostingViewModel> collection)
        {
            var result = this._JournalPostingsService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/JournalPostings/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/JournalPostings/add 
		 */
        public JournalPostingViewModel Add([FromBody]JournalPostingViewModel model)
        {
            var result = this._JournalPostingsService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/JournalPostings/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/JournalPostings/update-collection 
		 */
        public IList<JournalPostingViewModel> Update([FromBody]IEnumerable<JournalPostingViewModel> collection)
        {
            var result = this._JournalPostingsService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/JournalPostings/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/JournalPostings/update 
		 */
        public JournalPostingViewModel Update([FromBody]JournalPostingViewModel model)
        {
            var result = this._JournalPostingsService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/JournalPostings/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/JournalPostings/delete-collection 
		 */
        public void Delete([FromBody]IEnumerable<JournalPostingViewModel> collection)
        {
            this._JournalPostingsService.Delete(collection);
        }

        /// <summary>
        /// Delete entities by its id collection.
        /// </summary>
        /// <param name="collection"></param>
        [Route("delete-id-collection")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/JournalPostings/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/JournalPostings/delete-id-collection 
		 */
        public void Delete([FromBody]IEnumerable<long> collection)
        {
            this._JournalPostingsService.Delete(collection);
        }

        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="model"></param>
        [Route("delete")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/JournalPostings/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/JournalPostings/delete 
		 */
        public void Delete([FromBody]JournalPostingViewModel model)
        {
            this._JournalPostingsService.Delete(model);
        }

        /// <summary>
        /// Delete an entity by id.
        /// </summary>
        /// <param name="id"></param>
        [Route("delete/{id}")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/JournalPostings/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/JournalPostings/delete/1 
		 */
        public void Delete(long id)
        {
            this._JournalPostingsService.Delete(id);
        }

        #endregion
    }
}
