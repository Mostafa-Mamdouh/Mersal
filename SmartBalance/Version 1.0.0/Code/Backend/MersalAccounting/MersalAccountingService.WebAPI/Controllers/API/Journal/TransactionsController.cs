#region Using ...
using Framework.Core.Filters;
using Framework.Core.Models.DTOs;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Core.IServices;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels.LightViewModels;
using MersalAccountingService.Core.Models.ViewModels.Reports;
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
	/// Transactions Controller
	/// </summary>
	[RoutePrefix("api/Transactions")]
	public class TransactionsController : Base.BaseAPIController
	{
		#region Data Members
		private readonly ITransactionsService _TransactionsService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type TransactionController.
		/// </summary>
		/// <param name="TransactionsService">The injected service.</param>
		public TransactionsController(ITransactionsService TransactionsService)
		{
			this._TransactionsService = TransactionsService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of TransactionViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Transactions/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Transactions/get-by-condition 
		 */
		public GenericCollectionViewModel<TransactionViewModel> Get(ConditionFilter<Transaction, long> condition)
		{
			var result = this._TransactionsService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of TransactionViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Transactions/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Transactions/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<TransactionViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._TransactionsService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of TransactionViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Transactions/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Transactions/get-light-by-condition 
		 */
		public GenericCollectionViewModel<TransactionLightViewModel> GetLightModel(ConditionFilter<Transaction, long> condition)
		{
			var result = this._TransactionsService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of TransactionViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Transactions/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Transactions/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<TransactionLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._TransactionsService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a TransactionViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Transactions/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Transactions/get/1 
		 */
		public TransactionViewModel Get(long id)
		{
			var result = this._TransactionsService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Transactions/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Transactions/add-collection 
		 */
		public IList<TransactionViewModel> Add([FromBody]IEnumerable<TransactionViewModel> collection)
		{
			var result = this._TransactionsService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Transactions/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Transactions/add 
		 */
		public TransactionViewModel Add([FromBody]TransactionViewModel model)
		{
			var result = this._TransactionsService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Transactions/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Transactions/update-collection 
		 */
		public IList<TransactionViewModel> Update([FromBody]IEnumerable<TransactionViewModel> collection)
		{
			var result = this._TransactionsService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Transactions/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Transactions/update 
		 */
		public TransactionViewModel Update([FromBody]TransactionViewModel model)
		{
			var result = this._TransactionsService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Transactions/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Transactions/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<TransactionViewModel> collection)
		{
			this._TransactionsService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Transactions/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Transactions/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._TransactionsService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Transactions/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Transactions/delete 
		 */
		public void Delete([FromBody]TransactionViewModel model)
		{
			this._TransactionsService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Transactions/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Transactions/delete/1 
		 */
		public void Delete(long id)
		{
			this._TransactionsService.Delete(id);
		}
      
        #endregion
    }
}
