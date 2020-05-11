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
	/// Mails Controller
	/// </summary>
	[RoutePrefix("api/Mails")]
	public class MailsController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IMailsService _MailsService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type MailController.
		/// </summary>
		/// <param name="MailsService">The injected service.</param>
		public MailsController(IMailsService MailsService)
		{
			this._MailsService = MailsService;
		}
		#endregion

		#region Actions

		/// <summary>
		/// Gets a GenericCollectionViewModel of MailViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Mails/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Mails/get-by-condition 
		 */
		public GenericCollectionViewModel<MailViewModel> Get(ConditionFilter<Mail, long> condition)
		{
			var result = this._MailsService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of MailViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Mails/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Mails/get-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<MailViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._MailsService.Get(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of MailViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Mails/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Mails/get-light-by-condition 
		 */
		public GenericCollectionViewModel<MailLightViewModel> GetLightModel(ConditionFilter<Mail, long> condition)
		{
			var result = this._MailsService.GetLightModel(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of MailViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Mails/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Mails/get-light-by-pagger/0/10 
		 */
		public GenericCollectionViewModel<MailLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var result = this._MailsService.GetLightModel(pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Gets a MailViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("get/{id}")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Mails/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Mails/get/1 
		 */
		public MailViewModel Get(long id)
		{
			var result = this._MailsService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Mails/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Mails/add-collection 
		 */
		public IList<MailViewModel> Add([FromBody]IEnumerable<MailViewModel> collection)
		{
			var result = this._MailsService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Mails/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Mails/add 
		 */
		public MailViewModel Add([FromBody]MailViewModel model)
		{
			var result = this._MailsService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Mails/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Mails/update-collection 
		 */
		public IList<MailViewModel> Update([FromBody]IEnumerable<MailViewModel> collection)
		{
			var result = this._MailsService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Mails/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Mails/update 
		 */
		public MailViewModel Update([FromBody]MailViewModel model)
		{
			var result = this._MailsService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Mails/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Mails/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<MailViewModel> collection)
		{
			this._MailsService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Mails/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Mails/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._MailsService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Mails/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Mails/delete 
		 */
		public void Delete([FromBody]MailViewModel model)
		{
			this._MailsService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Mails/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Mails/delete/1 
		 */
		public void Delete(long id)
		{
			this._MailsService.Delete(id);
		}

		#endregion
	}
}
