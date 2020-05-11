#region using...
using Framework.Common.Enums;
using Framework.Common.Exceptions;
using Framework.Core.Common;
using Framework.Core.Filters;
using Framework.Core.IRepositories;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Common.Enums;
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
    #region Data Members
    #endregion

    #region Constructors
    #endregion
    public class DocumentService : IDocumentService
    {

        #region Data Members
        private readonly IDocumentRepository _documentRepository;
        private readonly ILanguageService _languageService;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructors
        public DocumentService(
            IDocumentRepository documentRepository,
            ILanguageService languageService,
            IUnitOfWork unitOfWork
            )
        {
            this._documentRepository = documentRepository;
            this._languageService = languageService;
            this._unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods

        public void ThrowExceptionIfExist(DocumentViewModel model)
        {
            ConditionFilter<Document, long> condition = new ConditionFilter<Document, long>
            {
                Query = (entity =>
                    entity.Id != model.Id && 
                    entity.DocumentNumber == model.DocumentNumber)
            };
            var existEntity = this._documentRepository.Get(condition).FirstOrDefault();

            if (existEntity != null)
                throw new ItemAlreadyExistException((int)ErrorCodeEnum.DocomentNumberAlreadyExist);
        }

        public GenericCollectionViewModel<DocumentViewModel> Get(ConditionFilter<Document, long> condition)
        {
            var entityCollection = this._documentRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<DocumentViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        public GenericCollectionViewModel<DocumentViewModel> Get(int? pageIndex, int? pageSize)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<Document, long> condition = new ConditionFilter<Document, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var entityCollection = this._documentRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<DocumentViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        public DocumentViewModel Get(long id)
        {
            var entity = this._documentRepository.Get(id);
            var model = entity.ToModel();

            return model;
        }

        public GenericCollectionViewModel<ListDocumentsLightViewModel> GetByFilter(DocumentFilterViewModel model)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<Document, long> condition = new ConditionFilter<Document, long>()
            {
                Order = Order.Descending
            };

            if (model.Sort?.Count > 0)
            {
                if (model.Sort[0].Dir != "desc") condition.Order = Order.Ascending;
            }

            //if (model.DateFrom.HasValue) model.DateFrom = model.DateFrom.SetTimeToNow();
            //if (model.DateTo.HasValue) model.DateTo = model.DateTo.SetTimeToMax();

            // The IQueryable data to query.  
            IQueryable<Document> queryableData = this._documentRepository.Get(condition);

            //queryableData = queryableData.Where(x => x.Language == lang && x.ParentKeyVendor != null);

            if (string.IsNullOrEmpty(model.DocomentNumber) == false)
                queryableData = queryableData.Where(x => x.DocumentNumber.ToString().Contains(model.DocomentNumber));

            if (string.IsNullOrEmpty(model.CountReceipts) == false)
                queryableData = queryableData.Where(x => x.CountReceipts.ToString().Contains(model.CountReceipts));

            if (string.IsNullOrEmpty(model.FirstNumber) == false)
                queryableData = queryableData.Where(x => x.FirstNumber.ToString().Contains(model.FirstNumber));

            var entityCollection = queryableData.ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToListModel()).ToList();


            var total = dtoCollection.Count();
            dtoCollection = dtoCollection.Skip(model.PageIndex * model.PageSize).Take(model.PageSize).ToList();
            var result = new GenericCollectionViewModel<ListDocumentsLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = total,
                PageIndex = model.PageIndex,
                PageSize = model.PageSize
            };

            return result;
        }

        public GenericCollectionViewModel<DocumentLightViewModel> GetLightModel(ConditionFilter<Document, long> condition)
        {
            var entityCollection = this._documentRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            var result = new GenericCollectionViewModel<DocumentLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = dtoCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        public GenericCollectionViewModel<DocumentLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<Document, long> condition = new ConditionFilter<Document, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
            };
            var entityCollection = this._documentRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            var result = new GenericCollectionViewModel<DocumentLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = dtoCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        public List<DocumentLightViewModel> GetLookUp()
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<Document, long> condition = new ConditionFilter<Document, long>
            {
            };
            var entityCollection = this._documentRepository.Get(condition).ToList();
            var lookup = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            return lookup;
        }

        public IList<DocumentViewModel> Add(IEnumerable<DocumentViewModel> collection)
        {
            foreach (var model in collection)
            {
                this.ThrowExceptionIfExist(model);
            }

            var entityCollection = collection.Select(model => model.ToEntity());
            entityCollection = this._documentRepository.Add(entityCollection).ToList();

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion

            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            return modelCollection;
        }

        public DocumentViewModel Add(DocumentViewModel model)
        {
            this.ThrowExceptionIfExist(model);

            var entity = model.ToEntity();
            entity = this._documentRepository.Add(entity);


            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion

            model = entity.ToModel();
            return model;
        }

        public IList<DocumentViewModel> Update(IEnumerable<DocumentViewModel> collection)
        {
            foreach (var model in collection)
            {
                this.ThrowExceptionIfExist(model);
            }

            var entityCollection = collection.Select(model => model.ToEntity());
            entityCollection = this._documentRepository.Update(entityCollection).ToList();

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion

            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            return modelCollection;
        }

        public DocumentViewModel Update(DocumentViewModel model)
        {
            this.ThrowExceptionIfExist(model);

            var entity = model.ToEntity();
            entity = this._documentRepository.Update(entity);
            
            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
            
            model = entity.ToModel();
            return model;
        }

        public void Delete(IEnumerable<DocumentViewModel> collection)
        {
            var entityCollection = collection.Select(model => model.ToEntity());
            this._documentRepository.Delete(entityCollection);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }

        public void Delete(IEnumerable<long> collection)
        {
            this._documentRepository.Delete(collection);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }

        public void Delete(DocumentViewModel model)
        {
            var entity = model.ToEntity();
            this._documentRepository.Delete(entity);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }

        public void Delete(long id)
        {
            var result = this._documentRepository.Delete(id);

            if (result == 0)
                throw new ItemNotFoundException();

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }
        #endregion
    }
}
