#region Using ...
using DocumentFormat.OpenXml.Packaging;
using Framework.Core.Filters;
using Framework.Core.IServices.Base;
using Framework.Core.Models.DTOs;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.DTOs;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels.LightViewModels;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Core.IServices
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDonatorsService : IBaseService
    {
        #region Methods
        int ReadExcelFileDOM(IEnumerable<string> files);
        int ReadExcelFileDOM(string fileName);
        int ReadExcelFileDOM(Stream stream);
        int ReadExcelFileDOM(SpreadsheetDocument spreadsheetDocument);

        int Add(IList<DonorFormDTO> dtos);




        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void ThrowExceptionIfExist(DonatorViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        GenericCollectionViewModel<ListDonatorLightViewModel> GetByFilter(DonatorFilterViewModel model);

        /// <summary>
        /// Gets a GenericCollectionViewModel of CutomerViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<DonatorViewModel> Get(ConditionFilter<Donator, long> condition);
        
        /// <summary>
        /// Gets a GenericCollectionViewModel of DonatorViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<DonatorViewModel> Get(int? pageIndex, int? pageSize);

		/// <summary>
		/// Gets a GenericCollectionViewModel of DonatorLightViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		GenericCollectionViewModel<DonatorLightViewModel> GetLightModel(ConditionFilter<Donator, long> condition);

		/// <summary>
		/// Gets a GenericCollectionViewModel of DonatorLightViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		GenericCollectionViewModel<DonatorLightViewModel> GetLightModel(int? pageIndex, int? pageSize);

        List<DonatorLightViewModel> GetLookUp();

        /// <summary>
        /// Gets a DonatorViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DonatorViewModel Get(long id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<DonatorViewModel> Add(IEnumerable<DonatorViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        DonatorViewModel Add(DonatorViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<DonatorViewModel> Update(IEnumerable<DonatorViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        DonatorViewModel Update(DonatorViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<DonatorViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<long> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void Delete(DonatorViewModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);
        #endregion
    }
}
      