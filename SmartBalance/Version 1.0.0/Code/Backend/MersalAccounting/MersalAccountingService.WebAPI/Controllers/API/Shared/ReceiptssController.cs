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
	/// Receiptss Controller
	/// </summary>
	[RoutePrefix("api/Receiptss")]
	public class ReceiptssController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IReceiptssService _ReceiptssService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type ReceiptsController.
		/// </summary>
		/// <param name="ReceiptssService">The injected service.</param>
		public ReceiptssController(IReceiptssService ReceiptssService)
		{
			this._ReceiptssService = ReceiptssService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of ReceiptsViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Receiptss/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Receiptss/get-by-condition 
		 */
		public GenericCollectionViewModel<ReceiptsViewModel> Get(ConditionFilter<Receipts, long> condition)
		{
			var result = this._ReceiptssService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of ReceiptsViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Receiptss/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Receiptss/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<ReceiptsViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._ReceiptssService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of ReceiptsViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Receiptss/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Receiptss/get-light-by-condition 
		 */
		public GenericCollectionViewModel<ReceiptsLightViewModel> GetLightModel(ConditionFilter<Receipts, long> condition)
		{
			var result = this._ReceiptssService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of ReceiptsViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Receiptss/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Receiptss/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<ReceiptsLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._ReceiptssService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a ReceiptsViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Receiptss/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Receiptss/get/1 
		 */
		public ReceiptsViewModel Get(long id)
		{
			var result = this._ReceiptssService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Receiptss/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Receiptss/add-collection 
		 */
		public IList<ReceiptsViewModel> Add([FromBody]IEnumerable<ReceiptsViewModel> collection)
		{
			var result = this._ReceiptssService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Receiptss/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Receiptss/add 
		 */
		public ReceiptsViewModel Add([FromBody]ReceiptsViewModel model)
		{
			var result = this._ReceiptssService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Receiptss/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Receiptss/update-collection 
		 */
		public IList<ReceiptsViewModel> Update([FromBody]IEnumerable<ReceiptsViewModel> collection)
		{
			var result = this._ReceiptssService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Receiptss/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Receiptss/update 
		 */
		public ReceiptsViewModel Update([FromBody]ReceiptsViewModel model)
		{
			var result = this._ReceiptssService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Receiptss/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Receiptss/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<ReceiptsViewModel> collection)
		{
			this._ReceiptssService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Receiptss/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Receiptss/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._ReceiptssService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Receiptss/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Receiptss/delete 
		 */
		public void Delete([FromBody]ReceiptsViewModel model)
		{
			this._ReceiptssService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Receiptss/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Receiptss/delete/1 
		 */
		public void Delete(long id)
		{
			this._ReceiptssService.Delete(id);
		}

		#endregion
	}
}
