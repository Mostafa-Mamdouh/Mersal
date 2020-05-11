#region Using ...
using Framework.Core.Filters;
using Framework.Core.IServices.Base;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels.LightViewModels;
using MersalAccountingService.Entities.Entity;
using System.Collections.Generic;
#endregion

namespace MersalAccountingService.Core.IServices
{
    /// <summary>
    /// 
    /// </summary>
    public interface IExpensesService : IBaseService
    {
        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void ThrowExceptionIfExist(ExpenseViewModel model);

        /// <summary>
        /// Gets a GenericCollectionViewModel of ExpenseViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<ExpenseViewModel> Get(ConditionFilter<Expense, long> condition);

        /// <summary>
        /// Gets a GenericCollectionViewModel of ExpenseViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<ExpenseViewModel> Get(int? pageIndex, int? pageSize);

        /// <summary>
        /// Gets a GenericCollectionViewModel of ExpenseLightViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<ExpenseLightViewModel> GetLightModel(ConditionFilter<Expense, long> condition);

        /// <summary>
        /// Gets a GenericCollectionViewModel of ExpenseLightViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<ExpenseLightViewModel> GetLightModel(int? pageIndex, int? pageSize);

        /// <summary>
        /// Gets a ExpenseViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ExpenseViewModel Get(long id);

		GenericCollectionViewModel<ListExpenseLightViewModel> GetByFilter(ExpenseFilterViewModel model);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		IList<ExpenseViewModel> Add(IEnumerable<ExpenseViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ExpenseViewModel Add(ExpenseViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<ExpenseViewModel> Update(IEnumerable<ExpenseViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ExpenseViewModel Update(ExpenseViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<ExpenseViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<long> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void Delete(ExpenseViewModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);
        #endregion
    }
}
