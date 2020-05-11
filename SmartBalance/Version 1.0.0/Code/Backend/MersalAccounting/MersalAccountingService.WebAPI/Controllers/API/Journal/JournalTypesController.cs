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
	/// JournalTypes Controller
	/// </summary>
	[RoutePrefix("api/JournalTypes")]
	public class JournalTypesController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IJournalTypesService _JournalTypesService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type JournalTypeController.
		/// </summary>
		/// <param name="JournalTypesService">The injected service.</param>
		public JournalTypesController(IJournalTypesService JournalTypesService)
		{
			this._JournalTypesService = JournalTypesService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of JournalTypeViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/JournalTypes/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/JournalTypes/get-by-condition 
		 */
		public GenericCollectionViewModel<JournalTypeViewModel> Get(ConditionFilter<JournalType, long> condition)
		{
			var result = this._JournalTypesService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of JournalTypeViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/JournalTypes/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/JournalTypes/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<JournalTypeViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._JournalTypesService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of JournalTypeViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/JournalTypes/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/JournalTypes/get-light-by-condition 
		 */
		public GenericCollectionViewModel<JournalTypeLightViewModel> GetLightModel(ConditionFilter<JournalType, long> condition)
		{
			var result = this._JournalTypesService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of JournalTypeViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/JournalTypes/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/JournalTypes/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<JournalTypeLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._JournalTypesService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a JournalTypeViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/JournalTypes/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/JournalTypes/get/1 
		 */
		public JournalTypeViewModel Get(long id)
		{
			var result = this._JournalTypesService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/JournalTypes/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/JournalTypes/add-collection 
		 */
		public IList<JournalTypeViewModel> Add([FromBody]IEnumerable<JournalTypeViewModel> collection)
		{
			var result = this._JournalTypesService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/JournalTypes/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/JournalTypes/add 
		 */
		public JournalTypeViewModel Add([FromBody]JournalTypeViewModel model)
		{
			var result = this._JournalTypesService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/JournalTypes/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/JournalTypes/update-collection 
		 */
		public IList<JournalTypeViewModel> Update([FromBody]IEnumerable<JournalTypeViewModel> collection)
		{
			var result = this._JournalTypesService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/JournalTypes/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/JournalTypes/update 
		 */
		public JournalTypeViewModel Update([FromBody]JournalTypeViewModel model)
		{
			var result = this._JournalTypesService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/JournalTypes/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/JournalTypes/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<JournalTypeViewModel> collection)
		{
			this._JournalTypesService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/JournalTypes/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/JournalTypes/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._JournalTypesService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/JournalTypes/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/JournalTypes/delete 
		 */
		public void Delete([FromBody]JournalTypeViewModel model)
		{
			this._JournalTypesService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/JournalTypes/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/JournalTypes/delete/1 
		 */
		public void Delete(long id)
		{
			this._JournalTypesService.Delete(id);
		}

		#endregion
	}
}
