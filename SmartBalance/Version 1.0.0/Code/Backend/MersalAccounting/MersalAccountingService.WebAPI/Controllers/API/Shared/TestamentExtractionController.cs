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
	/// TestamentExtractions Controller
	/// </summary>
	[RoutePrefix("api/TestamentExtractions")]
	public class TestamentExtractionController : Base.BaseAPIController
	{
		#region Data Members
		private readonly ITestamentExtractionService _TestamentExtractionService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type TestamentExtractionController.
		/// </summary>
		/// <param name="TestamentExtractionsService">The injected service.</param>
		public TestamentExtractionController(ITestamentExtractionService TestamentExtractionService)
		{
			this._TestamentExtractionService = TestamentExtractionService;
		}
        #endregion

        #region Actions

        [Route("get-with-filter")]
        [HttpPost]
        public GenericCollectionViewModel<TestamentExtractionViewModel> GetByFilter([FromBody]TestamentExtractionFilterViewModel model)
        {
            var result = this._TestamentExtractionService.GetByFilter(model);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of TestamentExtractionViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/TestamentExtractions/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/TestamentExtractions/get-by-condition 
		 */
		public GenericCollectionViewModel<TestamentExtractionViewModel> Get(ConditionFilter<TestamentExtraction, long> condition)
		{
			var result = this._TestamentExtractionService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of TestamentExtractionViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/TestamentExtractions/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/TestamentExtractions/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<TestamentExtractionViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._TestamentExtractionService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of TestamentExtractionViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/TestamentExtractions/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/TestamentExtractions/get-light-by-condition 
		 */
		public GenericCollectionViewModel<TestamentExtractionViewModel> GetLightModel(ConditionFilter<TestamentExtraction, long> condition)
		{
			var result = this._TestamentExtractionService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of TestamentExtractionViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/TestamentExtractions/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/TestamentExtractions/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<TestamentExtractionViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._TestamentExtractionService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a TestamentExtractionViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/TestamentExtractions/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/TestamentExtractions/get/1 
		 */
		public TestamentExtractionViewModel Get(long id)
		{
			var result = this._TestamentExtractionService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/TestamentExtractions/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/TestamentExtractions/add-collection 
		 */
		public IList<TestamentExtractionViewModel> Add([FromBody]IEnumerable<TestamentExtractionViewModel> collection)
		{
			var result = this._TestamentExtractionService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/TestamentExtractions/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/TestamentExtractions/add 
		 */
		public TestamentExtractionViewModel Add([FromBody]TestamentExtractionViewModel model)
		{
			var result = this._TestamentExtractionService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/TestamentExtractions/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/TestamentExtractions/update-collection 
		 */
		public IList<TestamentExtractionViewModel> Update([FromBody]IEnumerable<TestamentExtractionViewModel> collection)
		{
			var result = this._TestamentExtractionService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/TestamentExtractions/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/TestamentExtractions/update 
		 */
		public TestamentExtractionViewModel Update([FromBody]TestamentExtractionViewModel model)
		{
			var result = this._TestamentExtractionService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/TestamentExtractions/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/TestamentExtractions/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<TestamentExtractionViewModel> collection)
		{
			this._TestamentExtractionService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/TestamentExtractions/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/TestamentExtractions/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._TestamentExtractionService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/TestamentExtractions/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/TestamentExtractions/delete 
		 */
		public void Delete([FromBody]TestamentExtractionViewModel model)
		{
			this._TestamentExtractionService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/TestamentExtractions/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/TestamentExtractions/delete/1 
		 */
		public void Delete(long id)
		{
			this._TestamentExtractionService.Delete(id);
		}

		#endregion
	}
}
