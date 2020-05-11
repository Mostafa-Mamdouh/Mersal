#region Using ...
using Framework.Common.Enums;
using Framework.Common.Exceptions;
using Framework.Core.Common;
using Framework.Core.Filters;
using Framework.Core.IRepositories;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Core.AutoMapperConfig;
using MersalAccountingService.Core.IRepositories;
using MersalAccountingService.Core.IServices;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.BusinessLogic.Services
{
    public class EffiencyRaiseHistoryService : IEffiencyRaiseHistoryService
    {
        #region Data Members
        private readonly IEffiencyRaiseHistoryRepository _IEffiencyRaiseHistory;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILanguageService _languageService;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type EffiencyRaiseHistoryService.
        /// </summary>
        /// <param name="EffiencyRaiseHistoryRepository"></param>
        /// <param name="unitOfWork"></param>
        public EffiencyRaiseHistoryService(
            IEffiencyRaiseHistoryRepository EffiencyRaiseHistory,
            ILanguageService languageService,
            IUnitOfWork unitOfWork)
        {
            this._IEffiencyRaiseHistory = EffiencyRaiseHistory;
            this._unitOfWork = unitOfWork;
            this._languageService = languageService;
        }
        #endregion

        #region Methods
        #endregion
        public IList<EffiencyRaiseHistoryViewModel> Add(IEnumerable<EffiencyRaiseHistoryViewModel> collection)
        {
            foreach (var model in collection)
            {
                this.ThrowExceptionIfExist(model);
            }

            var entityCollection = collection.Select(model => model.ToEntity());
            entityCollection = this._IEffiencyRaiseHistory.Add(entityCollection).ToList();

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion

            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            return modelCollection;
        }

        public EffiencyRaiseHistoryViewModel Add(EffiencyRaiseHistoryViewModel model)
        {

            //this.ThrowExceptionIfExist(model);
            var entity = model.ToEntity();
            entity = this._IEffiencyRaiseHistory.Add(entity);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion

            model = entity.ToModel();
            return model;
        }

        public void Delete(IEnumerable<EffiencyRaiseHistoryViewModel> collection)
        {
            var entityCollection = collection.Select(model => model.ToEntity());
            this._IEffiencyRaiseHistory.Delete(entityCollection);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }

        public void Delete(IEnumerable<long> collection)
        {
            this._IEffiencyRaiseHistory.Delete(collection);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }

        public void Delete(EffiencyRaiseHistoryViewModel model)
        {
            var entity = model.ToEntity();
            this._IEffiencyRaiseHistory.Delete(entity);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }

        public void Delete(long id)
        {
            var result = this._IEffiencyRaiseHistory.Delete(id);

            if (result == 0)
                throw new ItemNotFoundException();

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }

        public GenericCollectionViewModel<EffiencyRaiseHistoryViewModel> Get(ConditionFilter<EfficiencyRaiseHistory, long> condition)
        {
            var entityCollection = this._IEffiencyRaiseHistory.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<EffiencyRaiseHistoryViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        public GenericCollectionViewModel<EffiencyRaiseHistoryViewModel> Get(int? pageIndex, int? pageSize)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<EfficiencyRaiseHistory, long> condition = new ConditionFilter<EfficiencyRaiseHistory, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var entityCollection = this._IEffiencyRaiseHistory.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<EffiencyRaiseHistoryViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        public EffiencyRaiseHistoryViewModel Get(long id)
        {
            var entity = this._IEffiencyRaiseHistory.Get(id);
            var model = entity.ToModel();

            return model;
        }

        public void ThrowExceptionIfExist(Core.Models.ViewModels.EffiencyRaiseHistoryViewModel model)
        {
            throw new NotImplementedException();
        }

        public IList<EffiencyRaiseHistoryViewModel> Update(IEnumerable<EffiencyRaiseHistoryViewModel> collection)
        {
            foreach (var model in collection)
            {
                this.ThrowExceptionIfExist(model);
            }

            var entityCollection = collection.Select(model => model.ToEntity());
            entityCollection = this._IEffiencyRaiseHistory.Update(entityCollection).ToList();

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion

            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            return modelCollection;
        }

        public EffiencyRaiseHistoryViewModel Update(EffiencyRaiseHistoryViewModel model)
        {
            //this.ThrowExceptionIfExist(model);

            var entity = this._IEffiencyRaiseHistory.Get(model.Id);

            //entity.LocationId = model.LocationId;
            //entity.AccountChartId = model.AccountChartId;

            entity = this._IEffiencyRaiseHistory.Update(entity);


            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion

            model = entity.ToModel();
            return model;
        }
    }
}
