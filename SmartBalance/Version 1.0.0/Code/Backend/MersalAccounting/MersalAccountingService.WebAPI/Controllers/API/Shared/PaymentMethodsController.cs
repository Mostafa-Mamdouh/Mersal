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
	/// PaymentMethods Controller
	/// </summary>
	[RoutePrefix("api/PaymentMethods")]
	public class PaymentMethodsController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IPaymentMethodsService _PaymentMethodsService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type PaymentMethodController.
		/// </summary>
		/// <param name="PaymentMethodsService">The injected service.</param>
		public PaymentMethodsController(IPaymentMethodsService PaymentMethodsService)
		{
			this._PaymentMethodsService = PaymentMethodsService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of PaymentMethodViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PaymentMethods/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PaymentMethods/get-by-condition 
		 */
		public GenericCollectionViewModel<PaymentMethodViewModel> Get(ConditionFilter<PaymentMethod, long> condition)
		{
			var result = this._PaymentMethodsService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of PaymentMethodViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PaymentMethods/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PaymentMethods/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<PaymentMethodViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._PaymentMethodsService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of PaymentMethodViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PaymentMethods/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PaymentMethods/get-light-by-condition 
		 */
		public GenericCollectionViewModel<PaymentMethodLightViewModel> GetLightModel(ConditionFilter<PaymentMethod, long> condition)
		{
			var result = this._PaymentMethodsService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of PaymentMethodViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PaymentMethods/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PaymentMethods/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<PaymentMethodLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._PaymentMethodsService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a PaymentMethodViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PaymentMethods/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PaymentMethods/get/1 
		 */
		public PaymentMethodViewModel Get(long id)
		{
			var result = this._PaymentMethodsService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PaymentMethods/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PaymentMethods/add-collection 
		 */
		public IList<PaymentMethodViewModel> Add([FromBody]IEnumerable<PaymentMethodViewModel> collection)
		{
			var result = this._PaymentMethodsService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PaymentMethods/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PaymentMethods/add 
		 */
		public PaymentMethodViewModel Add([FromBody]PaymentMethodViewModel model)
		{
			var result = this._PaymentMethodsService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PaymentMethods/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PaymentMethods/update-collection 
		 */
		public IList<PaymentMethodViewModel> Update([FromBody]IEnumerable<PaymentMethodViewModel> collection)
		{
			var result = this._PaymentMethodsService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PaymentMethods/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PaymentMethods/update 
		 */
		public PaymentMethodViewModel Update([FromBody]PaymentMethodViewModel model)
		{
			var result = this._PaymentMethodsService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PaymentMethods/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PaymentMethods/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<PaymentMethodViewModel> collection)
		{
			this._PaymentMethodsService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PaymentMethods/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PaymentMethods/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._PaymentMethodsService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PaymentMethods/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PaymentMethods/delete 
		 */
		public void Delete([FromBody]PaymentMethodViewModel model)
		{
			this._PaymentMethodsService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/PaymentMethods/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/PaymentMethods/delete/1 
		 */
		public void Delete(long id)
		{
			this._PaymentMethodsService.Delete(id);
		}

		#endregion
	}
}
