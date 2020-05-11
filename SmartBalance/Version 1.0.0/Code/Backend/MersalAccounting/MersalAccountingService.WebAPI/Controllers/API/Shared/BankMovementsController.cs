#region Using ...
using Framework.Core.Filters;
using Framework.Core.Models.DTOs;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Common.Enums;
using MersalAccountingService.Core.IServices;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels.LightViewModels;
using MersalAccountingService.Entities.Entity;
using MersalAccountingService.WebAPI.Auth;
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
	/// BankMovements Controller
	/// </summary>
	[RoutePrefix("api/BankMovements")]
	public class BankMovementsController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IBankMovementsService _BankMovementsService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type BankMovementController.
		/// </summary>
		/// <param name="BankMovementsService">The injected service.</param>
		public BankMovementsController(IBankMovementsService BankMovementsService)
		{
			this._BankMovementsService = BankMovementsService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of BankMovementViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/BankMovements/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/BankMovements/get-by-condition 
		 */
		public GenericCollectionViewModel<BankMovementViewModel> Get(ConditionFilter<BankMovement, long> condition)
		{
			var result = this._BankMovementsService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of BankMovementViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/BankMovements/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/BankMovements/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<BankMovementViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._BankMovementsService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of BankMovementViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/BankMovements/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/BankMovements/get-light-by-condition 
		 */
		public GenericCollectionViewModel<BankMovementLightViewModel> GetLightModel(ConditionFilter<BankMovement, long> condition)
		{
			var result = this._BankMovementsService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of BankMovementViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/BankMovements/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/BankMovements/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<BankMovementLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._BankMovementsService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a BankMovementViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		[JwtAuthentication(Permissions.BankMovementsList)]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/BankMovements/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/BankMovements/get/1 
		 */
		public BankMovementViewModel Get(long id)
		{
			var result = this._BankMovementsService.Get(id);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of ListBankMovementsLightViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-with-filter")]
		[HttpPost]
		[JwtAuthentication(Permissions.BankMovementsList)]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/BankMovements/get-with-filter
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/BankMovements/get-with-filter 
		 */
		public GenericCollectionViewModel<ListBankMovementsLightViewModel> GetByFilter([FromBody]BankMovementFilterViewModel model)
		{
			var result = this._BankMovementsService.GetByFilter(model);
			return result;
		}

		/// <summary>
		/// Add entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		[Route("add-collection")]
		[HttpPost]
		[JwtAuthentication(Permissions.AddBankMovement)]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/BankMovements/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/BankMovements/add-collection 
		 */
		public IList<BankMovementViewModel> Add([FromBody]IEnumerable<BankMovementViewModel> collection)
		{
			var result = this._BankMovementsService.Add(collection);
			return result;
		}

		/// <summary>
		/// Add an entity.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[Route("add")]
		[HttpPost]
		[JwtAuthentication(Permissions.AddBankMovement)]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/BankMovements/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/BankMovements/add 
		 */
		public BankMovementViewModel Add([FromBody]BankMovementViewModel model)
		{
			var result = this._BankMovementsService.Add(model);
			return result;
		}


		/// <summary>
		/// Update entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		[Route("update-collection")]
		[HttpPost]
		[JwtAuthentication(Permissions.EditBankMovement)]
		/*
		 * HttpVerb: PUT
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/BankMovements/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/BankMovements/update-collection 
		 */
		public IList<BankMovementViewModel> Update([FromBody]IEnumerable<BankMovementViewModel> collection)
		{
			var result = this._BankMovementsService.Update(collection);
			return result;
		}

		/// <summary>
		/// Update an entity.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[Route("update")]
		[HttpPost]
		[JwtAuthentication(Permissions.EditBankMovement)]
		/*
		 * HttpVerb: PUT
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/BankMovements/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/BankMovements/update 
		 */
		public BankMovementViewModel Update([FromBody]BankMovementViewModel model)
		{
			var result = this._BankMovementsService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/BankMovements/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/BankMovements/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<BankMovementViewModel> collection)
		{
			this._BankMovementsService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/BankMovements/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/BankMovements/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._BankMovementsService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/BankMovements/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/BankMovements/delete 
		 */
		public void Delete([FromBody]BankMovementViewModel model)
		{
			this._BankMovementsService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/BankMovements/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/BankMovements/delete/1 
		 */
		public void Delete(long id)
		{
			this._BankMovementsService.Delete(id);
		}

		#endregion
	}
}
