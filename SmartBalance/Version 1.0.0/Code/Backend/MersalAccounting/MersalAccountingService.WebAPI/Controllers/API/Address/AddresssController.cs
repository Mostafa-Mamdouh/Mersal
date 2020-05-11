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
	/// Addresss Controller
	/// </summary>
	[RoutePrefix("api/Addresss")]
	public class AddresssController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IAddresssService _AddresssService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type AddressController.
		/// </summary>
		/// <param name="AddresssService">The injected service.</param>
		public AddresssController(IAddresssService AddresssService)
		{
			this._AddresssService = AddresssService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of AddressViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Addresss/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Addresss/get-by-condition 
		 */
		public GenericCollectionViewModel<AddressViewModel> Get(ConditionFilter<Address, long> condition)
		{
			var result = this._AddresssService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of AddressViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Addresss/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Addresss/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<AddressViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._AddresssService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of AddressViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Addresss/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Addresss/get-light-by-condition 
		 */
		public GenericCollectionViewModel<AddressLightViewModel> GetLightModel(ConditionFilter<Address, long> condition)
		{
			var result = this._AddresssService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of AddressViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Addresss/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Addresss/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<AddressLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._AddresssService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a AddressViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Addresss/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Addresss/get/1 
		 */
		public AddressViewModel Get(long id)
		{
			var result = this._AddresssService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Addresss/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Addresss/add-collection 
		 */
		public IList<AddressViewModel> Add([FromBody]IEnumerable<AddressViewModel> collection)
		{
			var result = this._AddresssService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Addresss/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Addresss/add 
		 */
		public AddressViewModel Add([FromBody]AddressViewModel model)
		{
			var result = this._AddresssService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Addresss/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Addresss/update-collection 
		 */
		public IList<AddressViewModel> Update([FromBody]IEnumerable<AddressViewModel> collection)
		{
			var result = this._AddresssService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Addresss/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Addresss/update 
		 */
		public AddressViewModel Update([FromBody]AddressViewModel model)
		{
			var result = this._AddresssService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Addresss/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Addresss/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<AddressViewModel> collection)
		{
			this._AddresssService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Addresss/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Addresss/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._AddresssService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Addresss/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Addresss/delete 
		 */
		public void Delete([FromBody]AddressViewModel model)
		{
			this._AddresssService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Addresss/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Addresss/delete/1 
		 */
		public void Delete(long id)
		{
			this._AddresssService.Delete(id);
		}

		#endregion
	}
}
