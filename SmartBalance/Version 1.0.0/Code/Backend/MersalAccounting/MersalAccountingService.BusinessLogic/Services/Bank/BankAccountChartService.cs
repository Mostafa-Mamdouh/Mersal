#region using ...
using Framework.Common.Exceptions;
using Framework.Core.Common;
using Framework.Core.Filters;
using Framework.Core.IRepositories;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Core.AutoMapperConfig;
using MersalAccountingService.Core.IRepositories;
using MersalAccountingService.Core.IServices;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels.LightViewModels;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.BusinessLogic.Services
{
	public class BankAccountChartService : IBankAccountChartService
	{
		#region Data Members
		private readonly IBankAccountChartRepository _BankAccountChartRepository;
        private readonly IAccountChartsRepository _accountChartsRepository;
		private readonly IUnitOfWork _unitOfWork;
		private readonly ILanguageService _languageService;
		#endregion

		#region Constructors
		public BankAccountChartService(IBankAccountChartRepository BankAccountChartRepository,IAccountChartsRepository accountChartsRepository ,IUnitOfWork UnitOfWork, ILanguageService languageService)
		{
			this._BankAccountChartRepository = BankAccountChartRepository;
            this._accountChartsRepository = accountChartsRepository;
			this._unitOfWork = UnitOfWork;
            this._languageService = languageService;
		}
		#endregion

		#region Methods
		public void ThrowExceptionIfExist(BankAccountChartViewModel model)
		{
			//////ConditionFilter<BankAccountChart, long> condition = new ConditionFilter<BankAccountChart, long>
			//////{
			//////    Query = (entity =>
			//////        entity.BankId == model.BankId &&
			//////        entity.AccocunChartId == model.AccountChartId)
			//////};
			//////var existEntity = this._BankAccountChartRepository.Get(condition).FirstOrDefault();

			//////if (existEntity != null)
			//////    throw new ItemAlreadyExistException();
		}

		public GenericCollectionViewModel<BankAccountChartLightViewModel> GetLightModel(ConditionFilter<BankAccountChart, long> condition)
		{
			var entityCollection = this._BankAccountChartRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<BankAccountChartLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}
		public GenericCollectionViewModel<BankAccountChartLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			//var lang = this._languageService.CurrentLanguage;
			ConditionFilter<BankAccountChart, long> condition = new ConditionFilter<BankAccountChart, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				//Query = (item =>
				//    item.Language == lang)
			};
			var entityCollection = this._BankAccountChartRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<BankAccountChartLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		public GenericCollectionViewModel<BankAccountChartViewModel> Get(ConditionFilter<BankAccountChart, long> condition)
		{
			var entityCollection = this._BankAccountChartRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<BankAccountChartViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		public GenericCollectionViewModel<BankAccountChartViewModel> Get(int? pageIndex, int? pageSize)
		{
			ConditionFilter<BankAccountChart, long> condition = new ConditionFilter<BankAccountChart, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize
			};
			var entityCollection = this._BankAccountChartRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<BankAccountChartViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		public List<BankAccountChartViewModel> Get(long bankId)
		{
            //return null;
            List<BankAccountChart> bankAccountChart = _BankAccountChartRepository.Get().Where(x => x.BankId == bankId).ToList();
            return bankAccountChart.Select(e => e.ToModel()).ToList();
		}

        public List<AccountChartLightViewModel> GetAccountCharts(long bankId)
        {
            ConditionFilter<BankAccountChart, long> condition = new ConditionFilter<BankAccountChart, long>
            {
                Query = (item => item.BankId == bankId)
            };
            var enity =  this._BankAccountChartRepository.Get(condition).Select(x => x.AccountChart).ToList();
            var result = enity.Select(x => x.ToLightModel()).ToList();
            foreach (var item in result)
            {
                item.DisplyedName = $"{item.DisplyedName}{enity.FirstOrDefault(x => x.Id == item.Id).ChildTranslatedAccountCharts.FirstOrDefault(x => x.Language == this._languageService.CurrentLanguage).Name}";
            }
            return result;
        }


        public BankAccountChartViewModel Get(long bankId, long accountChartId)
		{
			// return null;
			return this._BankAccountChartRepository.Get().FirstOrDefault(e => e.BankId == bankId && e.AccountChartId == accountChartId).ToModel();
		}


		public IList<BankAccountChartViewModel> Add(IEnumerable<BankAccountChartViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._BankAccountChartRepository.Add(entityCollection).ToList();

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion

			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			return modelCollection;
		}

		public BankAccountChartViewModel Add(BankAccountChartViewModel model)
		{
			this.ThrowExceptionIfExist(model);

			var entity = model.ToEntity();
			entity = this._BankAccountChartRepository.Add(entity);


			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion

			model = entity.ToModel();
			return model;
		}

		public IList<BankAccountChartViewModel> Update(IEnumerable<BankAccountChartViewModel> collection)
		{
            IEnumerable<BankAccountChartViewModel> bankAccountsDelete = collection.Where(x => x.ModelStatus == MersalAccountingService.Common.Enums.ModelStatus.Delete);
            if (bankAccountsDelete != null && bankAccountsDelete.Count() > 0)
            {
                foreach (var bankAccountDelete in bankAccountsDelete)
                {
                    BankAccountChart bankAccount = this._BankAccountChartRepository.Get().FirstOrDefault(x => x.AccountChartId == bankAccountDelete.AccountChartId && x.BankId == bankAccountDelete.BankId);
                    if (bankAccount != null)
                        this._BankAccountChartRepository.Delete(bankAccount);
                }
            }
            IEnumerable<BankAccountChartViewModel> bankAccountsAdd = collection.Where(x => x.ModelStatus == MersalAccountingService.Common.Enums.ModelStatus.Add);
            if (bankAccountsAdd != null && bankAccountsAdd.Count() > 0)
            {
                foreach (var bankAccountAdd in bankAccountsAdd)
                {
                    try
                    {
                        ThrowExceptionIfExist(bankAccountAdd);
                        this._BankAccountChartRepository.Add(bankAccountAdd.ToEntity());
                    }
                    catch (ItemAlreadyExistException)
                    {
                        continue;
                    }
                }
            }



            //var entityCollection = collection.Select(model => model.ToEntity());
            var modelCollection = bankAccountsDelete.Union(bankAccountsAdd); //this._accountDocumentRepository.Update(entityCollection).ToList();

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion

            //var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            return modelCollection.ToList();
        }

		public BankAccountChartViewModel Update(BankAccountChartViewModel model)
		{
			this.ThrowExceptionIfExist(model);

			var entity = model.ToEntity();
			entity = this._BankAccountChartRepository.Update(entity);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion

			model = entity.ToModel();
			return model;
		}

		public void Delete(IEnumerable<BankAccountChartViewModel> collection)
		{
			var entityCollection = collection.Select(model => model.ToEntity());
			this._BankAccountChartRepository.Delete(entityCollection);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}

		public void Delete(IEnumerable<long> collection)
		{
			this._BankAccountChartRepository.Delete(collection);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}

		public void Delete(BankAccountChartViewModel model)
		{
			var entity = model.ToEntity();
			this._BankAccountChartRepository.Delete(entity);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}

		public void Delete(long id)
		{
			var result = this._BankAccountChartRepository.Delete(id);

			if (result == 0)
				throw new ItemNotFoundException();

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}

		#endregion
	}
}
