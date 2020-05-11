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
	/// Vendors Controller
	/// </summary>
	[RoutePrefix("api/Vendors")]
	public class VendorsController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IVendorsService _VendorsService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type VendorController.
		/// </summary>
		/// <param name="VendorsService">The injected service.</param>
		public VendorsController(IVendorsService VendorsService)
		{
			this._VendorsService = VendorsService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of VendorViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Vendors/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Vendors/get-by-condition 
		 */
		public GenericCollectionViewModel<VendorViewModel> Get(ConditionFilter<Vendor, long> condition)
		{
			var result = this._VendorsService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of VendorViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Vendors/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Vendors/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<VendorViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._VendorsService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of VendorViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Vendors/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Vendors/get-light-by-condition 
		 */
		public GenericCollectionViewModel<VendorLightViewModel> GetLightModel(ConditionFilter<Vendor, long> condition)
		{
			var result = this._VendorsService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of VendorViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Vendors/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Vendors/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<VendorLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._VendorsService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a VendorViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Vendors/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Vendors/get/1 
		 */
		public VendorViewModel Get(long id)
		{
			var result = this._VendorsService.Get(id);
			return result;
		}
        [Route("get-lookup")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/DelegateMans/get-lookup
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/DelegateMans/get-lookup
		 */
        public List<VendorLightViewModel> GetLookup()
        {
            var result = this._VendorsService.GetLookUp();
            return result;
        }

		/// <summary>
		/// Gets a GenericCollectionViewModel of ListVendorsLightViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-with-filter")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Vendors/get-with-filter
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Vendors/get-with-filter 
		 */
		public GenericCollectionViewModel<ListVendorsLightViewModel> GetByFilter([FromBody]VendorFilterViewModel model)
		{
			var result = this._VendorsService.GetByFilter(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Vendors/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Vendors/add-collection 
		 */
		public IList<VendorViewModel> Add([FromBody]IEnumerable<VendorViewModel> collection)
		{
			var result = this._VendorsService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Vendors/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Vendors/add 
		 */
		public VendorViewModel Add([FromBody]VendorViewModel model)
		{
			var result = this._VendorsService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Vendors/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Vendors/update-collection 
		 */
		public IList<VendorViewModel> Update([FromBody]IEnumerable<VendorViewModel> collection)
		{
			var result = this._VendorsService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Vendors/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Vendors/update 
		 */
		public VendorViewModel Update([FromBody]VendorViewModel model)
		{
			var result = this._VendorsService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Vendors/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Vendors/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<VendorViewModel> collection)
		{
			this._VendorsService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Vendors/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Vendors/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._VendorsService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Vendors/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Vendors/delete 
		 */
		public void Delete([FromBody]VendorViewModel model)
		{
			this._VendorsService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Vendors/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Vendors/delete/1 
		 */
		public void Delete(long id)
		{
			this._VendorsService.Delete(id);
		}

		#endregion
	}
}
