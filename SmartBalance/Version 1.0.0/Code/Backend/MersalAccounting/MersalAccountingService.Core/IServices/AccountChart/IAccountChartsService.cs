#region Using ...
using Framework.Core.Filters;
using Framework.Core.IServices.Base;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels.AccountChart;
using MersalAccountingService.Core.Models.ViewModels.LightViewModels;
using MersalAccountingService.Entities.Entity;
using System.Collections.Generic;
#endregion

namespace MersalAccountingService.Core.IServices
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAccountChartsService : IBaseService
    {
        #region Methods
        int ReadExcelFileDOM(IEnumerable<string> files);
        int ReadExcelFileDOM(string fileName);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void ThrowExceptionIfExist(AccountChartViewModel model);

        /// <summary>
        /// Gets a GenericCollectionViewModel of AccountChartViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<AccountChartViewModel> Get(ConditionFilter<AccountChart, long> condition);

        AddAccountChartViewModel GetDetails(long id);
        /// <summary>
        /// Gets a GenericCollectionViewModel of AccountChartViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<AccountChartLightViewModel> Get();
        GenericCollectionViewModel<AccountChartLightViewModel> GetByid(long id);

        /// <summary>
        /// Gets a GenericCollectionViewModel of AccountChartLightViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<AccountChartLightViewModel> GetLightModel(ConditionFilter<AccountChart, long> condition);

        /// <summary>
        /// Gets a GenericCollectionViewModel of AccountChartLightViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<AccountChartLightViewModel> GetLightModel(int? pageIndex, int? pageSize);

        /// <summary>
        /// Gets a AccountChartViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        /// <summary>
        /// Gets a AccountChartLightViewModel LookUp.
        /// </summary>
        /// <returns></returns>
        List<AccountChartLightViewModel> GetLookUp();

        IList<AccountChartLightViewModel> GetAllUnSelectedAccountChartsForSafe(long safeId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<AccountChartViewModel> Add(IEnumerable<AccountChartViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        AddAccountChartViewModel Add(AddAccountChartViewModel model, bool IsImported = false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<AccountChartViewModel> Update(IEnumerable<AccountChartViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        AddAccountChartViewModel Update(AddAccountChartViewModel model);     
        //long GetAccountChartId(string code);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<AccountChartViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<long> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void Delete(AccountChartViewModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);


        long CheckAccountCodeValidatyAndExsistanse(string code);
        long GetAccountChartId(string code);
        string GetLastCodePart(string code, bool throwException = false);
        long GetParentid(string code, bool throwException = false);
		void ThrowExceptionIfParentAccountNotIsSubAccount(long parentId);

		AccountChartLevelSettingViewModel GetAccountLevel(string code, AccountChartSettingViewModel accountChartSetting, bool throwLevelException = false);
        AccountChartLevelSettingViewModel GetAccountLevel(string code, bool throwLevelException);

        #endregion
    }
}
