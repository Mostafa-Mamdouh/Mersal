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
	/// Branchs Controller
	/// </summary>
	[RoutePrefix("api/Branchs")]
	public class BranchsController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IBranchsService _BranchsService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type BranchController.
		/// </summary>
		/// <param name="BranchsService">The injected service.</param>
		public BranchsController(IBranchsService BranchsService)
		{
			this._BranchsService = BranchsService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of BranchViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Branchs/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Branchs/get-by-condition 
		 */
		public GenericCollectionViewModel<BranchViewModel> Get(ConditionFilter<Branch, int> condition)
		{
			var result = this._BranchsService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of BranchViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Branchs/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Branchs/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<BranchViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._BranchsService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of BranchViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Branchs/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Branchs/get-light-by-condition 
		 */
		public GenericCollectionViewModel<BranchLightViewModel> GetLightModel(ConditionFilter<Branch, int> condition)
		{
			var result = this._BranchsService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of BranchViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Branchs/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Branchs/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<BranchLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._BranchsService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a BranchViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Branchs/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Branchs/get/1 
		 */
		public BranchViewModel Get(int id)
		{
			var result = this._BranchsService.Get(id);
			return result;
		}

        [Route("get-lookup")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Cases/get-lookup
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Cases/get-lookup
		 */
        public IList<BranchLightViewModel> GetLookup()
        {
            var result = this._BranchsService.GetLookUp();
            return result;
        }

		/// <summary>
		/// Gets a GenericCollectionViewModel of ListBranchsLightViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-with-filter")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Branchs/get-with-filter
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Branchs/get-with-filter 
		 */
		public GenericCollectionViewModel<ListBranchsLightViewModel> GetByFilter([FromBody]BranchFilterViewModel model)
		{
			var result = this._BranchsService.GetByFilter(model);
			return result;
		}

        [Route("get-all-un-selected-banchs-for-user/{userId}")]
        public IList<BranchLightViewModel> GetAllUnSelectedBranchForUser(long userId)
        {
            var result = this._BranchsService.GetAllUnSelectedBranchForUser(userId);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Branchs/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Branchs/add-collection 
		 */
		public IList<BranchViewModel> Add([FromBody]IEnumerable<BranchViewModel> collection)
		{
			var result = this._BranchsService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Branchs/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Branchs/add 
		 */
		public BranchViewModel Add([FromBody]BranchViewModel model)
		{
			var result = this._BranchsService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Branchs/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Branchs/update-collection 
		 */
		public IList<BranchViewModel> Update([FromBody]IEnumerable<BranchViewModel> collection)
		{
			var result = this._BranchsService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Branchs/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Branchs/update 
		 */
		public BranchViewModel Update([FromBody]BranchViewModel model)
		{
			var result = this._BranchsService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Branchs/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Branchs/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<BranchViewModel> collection)
		{
			this._BranchsService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Branchs/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Branchs/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<int> collection)
		{
			this._BranchsService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Branchs/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Branchs/delete 
		 */
		public void Delete([FromBody]BranchViewModel model)
		{
			this._BranchsService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Branchs/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Branchs/delete/1 
		 */
		public void Delete(int id)
		{
			this._BranchsService.Delete(id);
		}

		#endregion
	}
}
