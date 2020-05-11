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
	[RoutePrefix("api/Testaments")]
	public class TestamentController : Base.BaseAPIController
    {
		#region Data Members
		private readonly ITestamentService _testamentService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type TestamentController.
		/// </summary>
		/// <param name="TestamentsService">The injected service.</param>
		public TestamentController(ITestamentService testamentService)
		{
			this._testamentService = testamentService;
		}
		#endregion

		#region Actions

		[Route("get-with-filter")]
		[HttpPost]
		[JwtAuthentication(Permissions.TestamentList)]
		public GenericCollectionViewModel<ListTestamentLightViewModel> GetByFilter([FromBody]TestamentFilterViewModel model)
		{
			var result = this._testamentService.GetByFilter(model);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of TestamentViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Testaments/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Testaments/get-by-condition 
		 */
		public GenericCollectionViewModel<TestamentViewModel> Get(ConditionFilter<Testament, long> condition)
		{
			var result = this._testamentService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of TestamentViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Testaments/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Testaments/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<TestamentViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._testamentService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of TestamentViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Testaments/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Testaments/get-light-by-condition 
		 */
		public GenericCollectionViewModel<TestamentLightViewModel> GetLightModel(ConditionFilter<Testament, long> condition)
		{
			var result = this._testamentService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of TestamentViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Testaments/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Testaments/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<TestamentLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._testamentService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a TestamentViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		[JwtAuthentication(Permissions.TestamentList)]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Testaments/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Testaments/get/1 
		 */
		public TestamentViewModel Get(long id)
		{
			var result = this._testamentService.Get(id);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of ProductViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-lookup")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Products/get-lookup
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Products/get-lookup
		 */
		public List<TestamentLightViewModel> GetLookup()
		{
			var result = this._testamentService.GetLookUp();
			return result;
		}

        [Route("get-codes/{advancesTypeId}")]
        [HttpGet]
        public List<string> GetCodes(int advancesTypeId)
        {
            var result = this._testamentService.GetCodes(advancesTypeId);
            return result;
        }

        [Route("generate-new-code")]
        [HttpGet]
        public string GenerateNewCode()
        {
            var result = this._testamentService.GenerateNewCode();
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Testaments/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Testaments/add-collection 
		 */
		public IList<TestamentViewModel> Add([FromBody]IEnumerable<TestamentViewModel> collection)
		{
			var result = this._testamentService.Add(collection);
			return result;
		}

		/// <summary>
		/// Add an entity.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[Route("add")]
		[HttpPost]
		[JwtAuthentication(Permissions.AddTestament)]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Testaments/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Testaments/add 
		 */
		public TestamentViewModel Add([FromBody]TestamentViewModel model)
		{
			var result = this._testamentService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Testaments/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Testaments/update-collection 
		 */
		public IList<TestamentViewModel> Update([FromBody]IEnumerable<TestamentViewModel> collection)
		{
			var result = this._testamentService.Update(collection);
			return result;
		}

		/// <summary>
		/// Update an entity.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[Route("update")]
		[HttpPost]
		[JwtAuthentication(Permissions.EditTestament)]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Testaments/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Testaments/update 
		 */
		public TestamentViewModel Update([FromBody]TestamentViewModel model)
		{
			var result = this._testamentService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Testaments/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Testaments/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<TestamentViewModel> collection)
		{
			this._testamentService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Testaments/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Testaments/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._testamentService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Testaments/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Testaments/delete 
		 */
		public void Delete([FromBody]TestamentViewModel model)
		{
			this._testamentService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Testaments/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Testaments/delete/1 
		 */
		public void Delete(long id)
		{
			this._testamentService.Delete(id);
		}

		#endregion
	}
}
