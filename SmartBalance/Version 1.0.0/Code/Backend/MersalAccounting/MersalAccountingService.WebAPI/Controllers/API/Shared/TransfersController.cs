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
	/// Transfers Controller
	/// </summary>
	[RoutePrefix("api/Transfers")]
	public class TransfersController : Base.BaseAPIController
	{
		#region Data Members
		private readonly ITransfersService _TransfersService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type TransferController.
		/// </summary>
		/// <param name="TransfersService">The injected service.</param>
		public TransfersController(ITransfersService TransfersService)
		{
			this._TransfersService = TransfersService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of TransferViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Transfers/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Transfers/get-by-condition 
		 */
		public GenericCollectionViewModel<TransferViewModel> Get(ConditionFilter<Transfer, long> condition)
		{
			var result = this._TransfersService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of TransferViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Transfers/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Transfers/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<TransferViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._TransfersService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of TransferViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Transfers/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Transfers/get-light-by-condition 
		 */
		public GenericCollectionViewModel<TransferLightViewModel> GetLightModel(ConditionFilter<Transfer, long> condition)
		{
			var result = this._TransfersService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of TransferViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Transfers/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Transfers/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<TransferLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._TransfersService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a TransferViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Transfers/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Transfers/get/1 
		 */
		public TransferViewModel Get(long id)
		{
			var result = this._TransfersService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Transfers/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Transfers/add-collection 
		 */
		public IList<TransferViewModel> Add([FromBody]IEnumerable<TransferViewModel> collection)
		{
			var result = this._TransfersService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Transfers/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Transfers/add 
		 */
		public TransferViewModel Add([FromBody]TransferViewModel model)
		{
			var result = this._TransfersService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Transfers/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Transfers/update-collection 
		 */
		public IList<TransferViewModel> Update([FromBody]IEnumerable<TransferViewModel> collection)
		{
			var result = this._TransfersService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Transfers/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Transfers/update 
		 */
		public TransferViewModel Update([FromBody]TransferViewModel model)
		{
			var result = this._TransfersService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Transfers/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Transfers/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<TransferViewModel> collection)
		{
			this._TransfersService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Transfers/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Transfers/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._TransfersService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Transfers/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Transfers/delete 
		 */
		public void Delete([FromBody]TransferViewModel model)
		{
			this._TransfersService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Transfers/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Transfers/delete/1 
		 */
		public void Delete(long id)
		{
			this._TransfersService.Delete(id);
		}

		#endregion
	}
}
