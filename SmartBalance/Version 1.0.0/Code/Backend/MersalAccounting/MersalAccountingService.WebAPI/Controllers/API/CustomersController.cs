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
	/// Customers Controller
	/// </summary>
	[RoutePrefix("api/Customers")]
	public class CustomersController : Base.BaseAPIController
	{
		#region Data Members
		private readonly ICustomersService _CustomersService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type CustomerController.
		/// </summary>
		/// <param name="CustomersService">The injected service.</param>
		public CustomersController(ICustomersService CustomersService)
		{
			this._CustomersService = CustomersService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of CustomerViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Customers/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Customers/get-by-condition 
		 */
		public GenericCollectionViewModel<CustomerViewModel> Get(ConditionFilter<Customer, long> condition)
		{
			var result = this._CustomersService.Get(condition);
			return result;
		}
        [Route("get-lookup")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Products/get-lookup
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Products/get-lookup
		 */
        public List<CustomerLightViewModel> GetLookup()
        {
            var result = this._CustomersService.GetLookUp();
            return result;
        }
        /// <summary>
        /// Gets a GenericCollectionViewModel of CustomerViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Customers/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Customers/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<CustomerViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._CustomersService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of CustomerViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Customers/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Customers/get-light-by-condition 
		 */
		public GenericCollectionViewModel<CustomerLightViewModel> GetLightModel(ConditionFilter<Customer, long> condition)
		{
			var result = this._CustomersService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of CustomerViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Customers/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Customers/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<CustomerLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._CustomersService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a CustomerViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Customers/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Customers/get/1 
		 */
		public CustomerViewModel Get(long id)
		{
			var result = this._CustomersService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Customers/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Customers/add-collection 
		 */
		public IList<CustomerViewModel> Add([FromBody]IEnumerable<CustomerViewModel> collection)
		{
			var result = this._CustomersService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Customers/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Customers/add 
		 */
		public CustomerViewModel Add([FromBody]CustomerViewModel model)
		{
			var result = this._CustomersService.Add(model);
			return result;
		}


		/// <summary>
		/// Update entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		[Route("update-collection")]
		[HttpPut]
		/*
		 * HttpVerb: PUT
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Customers/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Customers/update-collection 
		 */
		public IList<CustomerViewModel> Update([FromBody]IEnumerable<CustomerViewModel> collection)
		{
			var result = this._CustomersService.Update(collection);
			return result;
		}

		/// <summary>
		/// Update an entity.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[Route("update")]
		[HttpPut]
		/*
		 * HttpVerb: PUT
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Customers/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Customers/update 
		 */
		public CustomerViewModel Update([FromBody]CustomerViewModel model)
		{
			var result = this._CustomersService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Customers/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Customers/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<CustomerViewModel> collection)
		{
			this._CustomersService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Customers/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Customers/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._CustomersService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Customers/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Customers/delete 
		 */
		public void Delete([FromBody]CustomerViewModel model)
		{
			this._CustomersService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Customers/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Customers/delete/1 
		 */
		public void Delete(long id)
		{
			this._CustomersService.Delete(id);
		}

		#endregion
	}
}
