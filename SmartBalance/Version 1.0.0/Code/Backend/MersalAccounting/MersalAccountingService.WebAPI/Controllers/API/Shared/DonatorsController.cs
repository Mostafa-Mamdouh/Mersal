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
    /// Donators Controller
    /// </summary>
    [RoutePrefix("api/Donators")]
    public class DonatorsController : Base.BaseAPIController
    {
        #region Data Members
        private readonly IDonatorsService _DonatorsService;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type DonatorController.
        /// </summary>
        /// <param name="DonatorsService">The injected service.</param>
        public DonatorsController(IDonatorsService DonatorsService)
        {
            this._DonatorsService = DonatorsService;
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
            int addedEntities = this._DonatorsService.ReadExcelFileDOM(files: fileNames);

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

        [Route("get-with-filter")]
        [HttpPost]
        public GenericCollectionViewModel<ListDonatorLightViewModel> GetByFilter([FromBody]DonatorFilterViewModel model)
        {
            var result = this._DonatorsService.GetByFilter(model);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of DonatorViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-by-condition")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Donators/get-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Donators/get-by-condition 
		 */
        public GenericCollectionViewModel<DonatorViewModel> Get(ConditionFilter<Donator, long> condition)
        {
            var result = this._DonatorsService.Get(condition);
            return result;
        }
        [Route("get-lookup")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Products/get-lookup
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Products/get-lookup
		 */
        public List<DonatorLightViewModel> GetLookup()
        {
            var result = this._DonatorsService.GetLookUp();
            return result;
        }
        /// <summary>
        /// Gets a GenericCollectionViewModel of DonatorViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-by-pagger/{pageIndex}/{pageSize}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Donators/get-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Donators/get-by-pagger/0/10 
		 */
        public GenericCollectionViewModel<DonatorViewModel> Get(int? pageIndex, int? pageSize)
        {
            var result = this._DonatorsService.Get(pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of DonatorViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route("get-light-by-condition")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Donators/get-light-by-condition
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Donators/get-light-by-condition 
		 */
        public GenericCollectionViewModel<DonatorLightViewModel> GetLightModel(ConditionFilter<Donator, long> condition)
        {
            var result = this._DonatorsService.GetLightModel(condition);
            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of DonatorViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("get-light-by-pagger/{pageIndex}/{pageSize}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Donators/get-light-by-pagger/{pageIndex}/{pageSize}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Donators/get-light-by-pagger/0/10 
		 */
        public GenericCollectionViewModel<DonatorLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
        {
            var result = this._DonatorsService.GetLightModel(pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// Gets a DonatorViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("get/{id}")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Donators/get/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Donators/get/1 
		 */
        public DonatorViewModel Get(long id)
        {
            var result = this._DonatorsService.Get(id);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Donators/add-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Donators/add-collection 
		 */
        public IList<DonatorViewModel> Add([FromBody]IEnumerable<DonatorViewModel> collection)
        {
            var result = this._DonatorsService.Add(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Donators/add
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Donators/add 
		 */
        public DonatorViewModel Add([FromBody]DonatorViewModel model)
        {
            var result = this._DonatorsService.Add(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Donators/update-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Donators/update-collection 
		 */
        public IList<DonatorViewModel> Update([FromBody]IEnumerable<DonatorViewModel> collection)
        {
            var result = this._DonatorsService.Update(collection);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Donators/update
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Donators/update 
		 */
        public DonatorViewModel Update([FromBody]DonatorViewModel model)
        {
            var result = this._DonatorsService.Update(model);
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
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Donators/delete-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Donators/delete-collection 
		 */
        public void Delete([FromBody]IEnumerable<DonatorViewModel> collection)
        {
            this._DonatorsService.Delete(collection);
        }

        /// <summary>
        /// Delete entities by its id collection.
        /// </summary>
        /// <param name="collection"></param>
        [Route("delete-id-collection")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Donators/delete-id-collection
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Donators/delete-id-collection 
		 */
        public void Delete([FromBody]IEnumerable<long> collection)
        {
            this._DonatorsService.Delete(collection);
        }

        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="model"></param>
        [Route("delete")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Donators/delete
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Donators/delete 
		 */
        public void Delete([FromBody]DonatorViewModel model)
        {
            this._DonatorsService.Delete(model);
        }

        /// <summary>
        /// Delete an entity by id.
        /// </summary>
        /// <param name="id"></param>
        [Route("delete/{id}")]
        [HttpPost]
        /*
		 * HttpVerb: POST
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Donators/delete/{id}
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Donators/delete/1 
		 */
        public void Delete(long id)
        {
            this._DonatorsService.Delete(id);
        }

        #endregion
    }
}
