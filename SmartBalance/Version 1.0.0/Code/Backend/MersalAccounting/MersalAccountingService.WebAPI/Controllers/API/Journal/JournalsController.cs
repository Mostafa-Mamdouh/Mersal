#region Using ...
using Framework.Core.Filters;
using Framework.Core.Models.DTOs;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Core.IServices;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels.JournalEntries;
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
	/// Journals Controller
	/// </summary>
	[RoutePrefix("api/Journals")]
	public class JournalsController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IJournalsService _JournalsService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type JournalController.
		/// </summary>
		/// <param name="JournalsService">The injected service.</param>
		public JournalsController(IJournalsService JournalsService)
		{
			this._JournalsService = JournalsService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of JournalViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Journals/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Journals/get-by-condition 
		 */
		public GenericCollectionViewModel<JournalViewModel> Get(ConditionFilter<Journal, long> condition)
		{
			var result = this._JournalsService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of JournalViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Journals/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Journals/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<JournalViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._JournalsService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of JournalViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Journals/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Journals/get-light-by-condition 
		 */
		public GenericCollectionViewModel<JournalLightViewModel> GetLightModel(ConditionFilter<Journal, long> condition)
		{
			var result = this._JournalsService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of JournalViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Journals/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Journals/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<JournalLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._JournalsService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a JournalViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Journals/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Journals/get/1 
		 */
		public JournalViewModel Get(long id)
		{
			var result = this._JournalsService.Get(id);
			return result;
		}
        /// <summary>
		/// Gets a AddJournalEntriesViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("getJournalsDetails/{id}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Journals/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Journals/get/1 
		 */
        public AddJournalEntriesViewModel getJournalsDetails(long id)
        {
            var result = this._JournalsService.getJournalsDetails(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Journals/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Journals/add-collection 
		 */
		public IList<JournalViewModel> Add([FromBody]IEnumerable<JournalViewModel> collection)
		{
			var result = this._JournalsService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Journals/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Journals/add 
		 */
		public JournalViewModel Add([FromBody]JournalViewModel model)
		{
			var result = this._JournalsService.Add(model);
			return result;
		}

        /// <summary>
		/// Add an entity.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[Route("add-Journal")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Journals/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Journals/add 
		 */
        public AddJournalEntriesViewModel AddJournal([FromBody]AddJournalEntriesViewModel model)
        {
            var result = this._JournalsService.AddJournal(model);
            return result;
        }       


        [Route("get-with-filter")]
        [HttpPost]
        public GenericCollectionViewModel<AddJournalEntriesViewModel> GetByFilter([FromBody]FilterJournalEntriesViewModel collection)
        {
            var result = this._JournalsService.GetByFilter(collection);
            return result;
        }


        [Route("approve-and-reject-collection")]
        [HttpPost]
        public ApprovedRejectedCollectionViewModel ApproveAndRejectCollection(ApprovedRejectedCollectionViewModel model)
        {
            var result = this._JournalsService.ApproveAndRejectCollection(model);
            return result;
        }

        [Route("approve-collection")]
        [HttpPost]
        public IdCollectionViewModel<long> Approve(IdCollectionViewModel<long> model)
        {
            var result = this._JournalsService.Approve(model);
            return result;
        }

        [Route("approve-item")]
        [HttpPost]
        public AddJournalEntriesViewModel Approve(AddJournalEntriesViewModel model)
        {
            var result = this._JournalsService.Approve(model);
            return result;
        }


        [Route("reject-collection")]
        [HttpPost]
        public IdCollectionViewModel<long> Reject(IdCollectionViewModel<long> model)
        {
            var result = this._JournalsService.Reject(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Journals/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Journals/update-collection 
		 */
		public IList<JournalViewModel> Update([FromBody]IEnumerable<JournalViewModel> collection)
		{
			var result = this._JournalsService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Journals/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Journals/update 
		 */
		public AddJournalEntriesViewModel Update([FromBody]AddJournalEntriesViewModel model)
		{
			var result = this._JournalsService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Journals/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Journals/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<JournalViewModel> collection)
		{
			this._JournalsService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Journals/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Journals/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._JournalsService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Journals/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Journals/delete 
		 */
		public void Delete([FromBody]JournalViewModel model)
		{
			this._JournalsService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Journals/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Journals/delete/1 
		 */
		public void Delete(long id)
		{
			this._JournalsService.Delete(id);
		}

		#endregion
	}
}
