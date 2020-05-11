#region using...
using Framework.Common.Exceptions;
using Framework.Core.Filters;
using Framework.Core.IRepositories;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Common.Enums;
using MersalAccountingService.Common.Exceptions;
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
    public class ClosedReceiptService : IClosedReceiptService
    {
        #region Data Members
        private readonly IClosedReceiptRepository _closedReceiptRepository;
        private readonly IDocumentRepository _documentRepository;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructors
        public ClosedReceiptService(
            IClosedReceiptRepository closedReceiptRepository,
            IDocumentRepository documentRepository,
            IUnitOfWork unitOfWork
            )
        {
            this._closedReceiptRepository = closedReceiptRepository;
            this._documentRepository = documentRepository;
            this._unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        public void ThrowExceptionIfExist(ClosedReceiptViewModel model)
        {
            ConditionFilter<ClosedReceipt, long> condition = new ConditionFilter<ClosedReceipt, long>()
            {
                Query = (entity => entity.DocumentId == model.DocumentId &&
                entity.ReceiptNumber == model.ReceiptNumber)
            };
            var existEntity = this._closedReceiptRepository.Get(condition).FirstOrDefault();
            if(existEntity != null)
            {
                throw new ItemAlreadyExistException((int)ErrorCodeEnum.ThisReceiptNumberClosed);
            }
        }

        public GenericCollectionViewModel<ClosedReceiptViewModel> Get(ConditionFilter<ClosedReceipt, long> condition)
        {
            throw new NotImplementedException();
        }

        public GenericCollectionViewModel<ClosedReceiptViewModel> Get(int? pageIndex, int? pageSize)
        {
            throw new NotImplementedException();
        }

        public ClosedReceiptViewModel Get(long id)
        {
            throw new NotImplementedException();
        }

        public int GetMax(int documentId)
        {
            return this._closedReceiptRepository.Get().Where(x => x.DocumentId == documentId).Select(x => x.ReceiptNumber).Max();
        }

        public IList<ClosedReceiptViewModel> Add(IEnumerable<ClosedReceiptViewModel> collection)
        {
            throw new NotImplementedException();
        }

        public ClosedReceiptViewModel Add(ClosedReceiptViewModel model)
        {
            this.ThrowExceptionIfExist(model);

            Document document = this._documentRepository.Get(model.DocumentId);
            int maxReceiptNumber = document.FirstNumber + (document.CountReceipts - 1);
            if (model.ReceiptNumber> maxReceiptNumber || model.ReceiptNumber < document.FirstNumber)
            {
                throw new GeneralException((int)ErrorCodeEnum.ThisReceiptNumberOutOfRange);
            }

            var entity = model.ToEntity();
            entity = this._closedReceiptRepository.Add(entity);
            this._unitOfWork.Commit();
            return entity.ToModel();
        }

        public IList<ClosedReceiptViewModel> Update(IEnumerable<ClosedReceiptViewModel> collection)
        {
            throw new NotImplementedException();
        }

        public ClosedReceiptViewModel Update(ClosedReceiptViewModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<ClosedReceiptViewModel> collection)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<long> collection)
        {
            throw new NotImplementedException();
        }

        public void Delete(ClosedReceiptViewModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
