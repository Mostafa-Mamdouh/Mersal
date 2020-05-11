#region Using ...
using Framework.Core.Filters;
using Framework.Core.Models.DTOs;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Common.Enums;
using MersalAccountingService.Core.IServices;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels.AccountChart;
using MersalAccountingService.Core.Models.ViewModels.LightViewModels;
using MersalAccountingService.Entities.Entity;
using MersalAccountingService.WebAPI.Auth;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
#endregion

namespace MersalAccountingService.WebAPI.Controllers.API
{
	/// <summary>
	/// AccountCharts Controller
	/// </summary>
	[RoutePrefix("api/AccountCharts")]
	public class AccountChartsController : Base.BaseAPIController
	{
		#region Data Members
		private readonly IAccountChartsService _AccountChartsService;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type AccountChartController.
		/// </summary>
		/// <param name="AccountChartsService">The injected service.</param>
		public AccountChartsController(IAccountChartsService AccountChartsService)
		{
			this._AccountChartsService = AccountChartsService;
		}
        #endregion

        #region Actions

        [Route("upload")]
        [HttpPost]
        public HttpResponseMessage Upload()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string rootPath = HostingEnvironment.MapPath("~/Upload/Temp");
            var normalFiles = HttpContext.Current.Request.Files;
            List<string> fileNames = new List<string>();

            if (normalFiles != null)
            {
                foreach (var item in normalFiles)
                {
                    HttpPostedFile httpPostedFile = normalFiles.Get(item.ToString());
                    string fileName = $"{rootPath}/{httpPostedFile.FileName}";
                    fileNames.Add(fileName);
                    httpPostedFile.SaveAs(fileName);
                }

            }
            int addedEntities = 0; this._AccountChartsService.ReadExcelFileDOM(files: fileNames);

            try
            {
                foreach (var item in fileNames)
                {
                    File.Delete(item);
                }
            }
            catch
            {

            }


            ////var str = Request.Content.ReadAsStringAsync();
            //var formData = Request.Content.ReadAsFormDataAsync().Result;
            //var array = Request.Content.ReadAsByteArrayAsync().Result;
            //var stream = Request.Content.ReadAsStreamAsync().Result;

            //using (BinaryReader sr = new BinaryReader(stream))
            //{
            //    using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite))
            //    {
            //        using (BinaryWriter sw = new BinaryWriter(fs))
            //        {
            //            sw.Write(array);
            //        }
            //    }
            //}

            //var provider = new MultipartFormDataStreamProvider(HostingEnvironment.MapPath("~/App_Data"));

            //var files = Request.Content.ReadAsMultipartAsync(provider).Result;
            //if (files != null)
            //{

            //}
            //// Do something with the files if required, like saving in the DB the paths or whatever
            ////DoStuff(files);

            return Request.CreateResponse<int>(HttpStatusCode.OK, addedEntities);
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of AccountChartViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountCharts/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountCharts/get-by-condition 
		 */
		public GenericCollectionViewModel<AccountChartViewModel> Get(ConditionFilter<AccountChart, long> condition)
		{
			var result = this._AccountChartsService.Get(condition);
			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of AccountChartViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		//[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		//[HttpGet]
		///*
		// * HttpVerb: Get
		// * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountCharts/get-by-pagger/{pageIndex}/{pageSize}
		// * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountCharts/get-by-pagger/0/10 
		// */
		//public GenericCollectionViewModel<AccountChartViewModel> Get(int? pageIndex, int? pageSize)
		//{
		//	var result = this._AccountChartsService.Get(pageIndex, pageSize);
		//	return result;
		//}

		/// <summary>
		/// Gets a GenericCollectionViewModel of AccountChartViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		[Route("get-light-by-condition")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountCharts/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountCharts/get-light-by-condition 
		 */
		public GenericCollectionViewModel<AccountChartLightViewModel> GetLightModel(ConditionFilter<AccountChart, long> condition)
		{
			var result = this._AccountChartsService.GetLightModel(condition);
			return result;
		}

        /// <summary>
        /// Gets a AccountChartViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [Route("get/{id}")]
		[HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountCharts/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountCharts/get/1 
		 */
        public GenericCollectionViewModel<AccountChartLightViewModel>  Get()
		{
			var result = this._AccountChartsService.Get();
			return result;
		}

        /// <summary>
        /// Gets a List of BankLightViewModel Lookup.
        /// </summary>
        /// <param ></param>
        /// <param ></param>
        /// <returns></returns>
        [Route("get-lookup")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/BankLightViewModel/get-lookup
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/BankLightViewModel/get-lookup
		 */
        public List<AccountChartLightViewModel> GetLookup()
        {
            var result = this._AccountChartsService.GetLookUp();
            return result;
        }


        /// <summary>
        /// Gets a List of AccountChartViewModel Lookup.
        /// </summary>
        /// <param ></param>
        /// <param ></param>
        /// <returns></returns>
        [Route("get")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountCharts/get-lookup
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountCharts/get
		 */
        public GenericCollectionViewModel<AccountChartLightViewModel> get()
        {
            var result = this._AccountChartsService.Get();
            return result;
        }

        /// <summary>
        /// Gets a List of AccountChartViewModel Lookup.
        /// </summary>
        /// <param ></param>
        /// <param ></param>
        /// <returns></returns>
        [Route("get/{id}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountCharts/get-lookup
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountCharts/get/12
		 */
        public GenericCollectionViewModel<AccountChartLightViewModel> get(long id)
        {
            var result = this._AccountChartsService.GetByid(id);
            return result;
        }

        [Route("GetDetails/{id}")]
        [HttpGet]
        public AddAccountChartViewModel getByid(long id)
        {
            var result = this._AccountChartsService.GetDetails(id);
            return result;
        }


        [Route("check-account-chart-code/{code}")]
        [HttpGet]
        public long getByid(string code)
        {
            long result = this._AccountChartsService.CheckAccountCodeValidatyAndExsistanse(code);
            return result;
        }
        /// <summary>
        /// Add entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>


        [Route("get-all-un-selected-accountCharts-for-safe/{safeId}")]
        public IList<AccountChartLightViewModel> GetAllUnSelectedAccountChartsForSafe(long safeId)
        {
            var result = this._AccountChartsService.GetAllUnSelectedAccountChartsForSafe(safeId);
            return result;
        }


        /// <summary>
        /// Add an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("add")]
		[HttpPost]
        [JwtAuthentication(Permissions.AddAccountChart)]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountCharts/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountCharts/add 
		 */
        public AddAccountChartViewModel Add([FromBody]AddAccountChartViewModel model)
		{
			var result = this._AccountChartsService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountCharts/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountCharts/update-collection 
		 */
		public IList<AccountChartViewModel> Update([FromBody]IEnumerable<AccountChartViewModel> collection)
		{
			var result = this._AccountChartsService.Update(collection);
			return result;
		}

		/// <summary>
		/// Update an entity.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[Route("update")]
		[HttpPost]
        [JwtAuthentication(Permissions.EditAccountChart)]
		/*
		 * HttpVerb: PUT
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountCharts/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountCharts/update 
		 */
		public AddAccountChartViewModel Update([FromBody]AddAccountChartViewModel model)
		{
			var result = this._AccountChartsService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountCharts/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountCharts/delete-collection 
		 */
		public void Delete([FromBody]IEnumerable<AccountChartViewModel> collection)
		{
			this._AccountChartsService.Delete(collection);
		}

		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		[Route("delete-id-collection")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountCharts/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountCharts/delete-id-collection 
		 */
		public void Delete([FromBody]IEnumerable<long> collection)
		{
			this._AccountChartsService.Delete(collection);
		}

		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		[Route("delete")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountCharts/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountCharts/delete 
		 */
		public void Delete([FromBody]AccountChartViewModel model)
		{
			this._AccountChartsService.Delete(model);
		}

		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		[Route("delete/{id}")]
		[HttpPost]
		/*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/AccountCharts/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/AccountCharts/delete/1 
		 */
		public void Delete(long id)
		{
			this._AccountChartsService.Delete(id);
		}

		#endregion
	}
}
