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
	/// Mobiles Controller
	/// </summary>
	[RoutePrefix("api/Mobiles")]
	public class MobilesController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IMobilesService _MobilesService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type MobileController.
		/// </summary>
		/// <param name="MobilesService">The injected service.</param>
		public MobilesController(IMobilesService MobilesService)
		{
			this._MobilesService = MobilesService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of MobileViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Mobiles/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Mobiles/get-by-condition 
		 */
		public GenericCollectionViewModel<MobileViewModel> Get(ConditionFilter<Mobile, long> condition)
		{
			var result = this._MobilesService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of MobileViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Mobiles/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Mobiles/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<MobileViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._MobilesService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of MobileViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Mobiles/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Mobiles/get-light-by-condition 
		 */
		public GenericCollectionViewModel<MobileLightViewModel> GetLightModel(ConditionFilter<Mobile, long> condition)
		{
			var result = this._MobilesService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of MobileViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Mobiles/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Mobiles/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<MobileLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._MobilesService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a MobileViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Mobiles/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Mobiles/get/1 
		 */
		public MobileViewModel Get(long id)
		{
			var result = this._MobilesService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Mobiles/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Mobiles/add-collection 
		 */
		public IList<MobileViewModel> Add([FromBody]IEnumerable<MobileViewModel> collection)
		{
			var result = this._MobilesService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Mobiles/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Mobiles/add 
		 */
		public MobileViewModel Add([FromBody]MobileViewModel model)
		{
			var result = this._MobilesService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Mobiles/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Mobiles/update-collection 
		 */
		public IList<MobileViewModel> Update([FromBody]IEnumerable<MobileViewModel> collection)
		{
			var result = this._MobilesService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Mobiles/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Mobiles/update 
		 */
		public MobileViewModel Update([FromBody]MobileViewModel model)
		{
			var result = this._MobilesService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Mobiles/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Mobiles/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<MobileViewModel> collection)
		{
			this._MobilesService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Mobiles/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Mobiles/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._MobilesService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Mobiles/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Mobiles/delete 
		 */
		public void Delete([FromBody]MobileViewModel model)
		{
			this._MobilesService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Mobiles/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Mobiles/delete/1 
		 */
		public void Delete(long id)
		{
			this._MobilesService.Delete(id);
		}

		#endregion
	}
}
