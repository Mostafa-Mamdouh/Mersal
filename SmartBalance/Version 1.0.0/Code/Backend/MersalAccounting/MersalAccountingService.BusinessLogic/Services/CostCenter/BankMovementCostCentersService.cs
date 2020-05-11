#region Using ...
using Framework.Common.Enums;
using Framework.Common.Exceptions;
using Framework.Core.Common;
using Framework.Core.Filters;
using Framework.Core.IRepositories;
using Framework.Core.Models.DTOs;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Common.Enums;
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
	/// <summary>
	/// Provides CostCenter service for 
	/// business functionality.
	/// </summary>
	public class BankMovementCostCentersService : IBankMovementBankMovementCostCentersService
    {
		#region Data Members
		private readonly IBankMovementCostCentersRepository _BankMovementCostCentersRepository;
		private readonly ILanguageService _languageService;
		private readonly IUnitOfWork _unitOfWork;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type BankMovementCostCentersService.
		/// </summary>
		/// <param name="BankMovementCostCentersRepository"></param>
		/// <param name="unitOfWork"></param>
		public BankMovementCostCentersService(
			IBankMovementCostCentersRepository BankMovementCostCentersRepository,
			ILanguageService languageService,
			IUnitOfWork unitOfWork)
		{
			this._BankMovementCostCentersRepository = BankMovementCostCentersRepository;
			this._languageService = languageService;
			this._unitOfWork = unitOfWork;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Throw an exception if name is exist.
		/// </summary>
		/// <param name="model">CostCenter view model</param>
		public void ThrowExceptionIfExist(BankMovementCostCentersViewModel model)
		{
            ConditionFilter<BankMovementCostCenters, long> condition = new ConditionFilter<BankMovementCostCenters, long>
            {
                Query = (entity =>
                    
                    entity.Id != model.Id)
            };
            var existEntity = this._BankMovementCostCentersRepository.Get(condition).FirstOrDefault();

            if (existEntity != null)
                throw new ItemAlreadyExistException((int)ErrorCodeEnum.CodeAlreadyExist);
        }



        /// <summary>
        /// Gets a GenericCollectionViewModel of BankMovementCostCentersViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<BankMovementCostCentersViewModel> Get(ConditionFilter<BankMovementCostCenters, long> condition)
		{
			var entityCollection = this._BankMovementCostCentersRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<BankMovementCostCentersViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of BankMovementCostCentersViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<BankMovementCostCentersViewModel> Get(int? pageIndex, int? pageSize)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<BankMovementCostCenters, long> condition = new ConditionFilter<BankMovementCostCenters, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				
			};
			var entityCollection = this._BankMovementCostCentersRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<BankMovementCostCentersViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}


        /// <summary>
        /// Gets a BankMovementCostCentersViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BankMovementCostCentersViewModel Get(long id)
		{
			var entity = this._BankMovementCostCentersRepository.Get(id);
			var model = entity.ToModel();

			return model;
		}

		/// <summary>
		/// Add entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		public IList<BankMovementCostCentersViewModel> Add(IEnumerable<BankMovementCostCentersViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._BankMovementCostCentersRepository.Add(entityCollection).ToList();

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion

			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			return modelCollection;
		}
		/// <summary>
		/// Add an entity.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public BankMovementCostCentersViewModel Add(BankMovementCostCentersViewModel model)
		{
			this.ThrowExceptionIfExist(model);

			var entity = model.ToEntity();
			entity = this._BankMovementCostCentersRepository.Add(entity);

          

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion

			model = entity.ToModel();
			return model;
		}

		/// <summary>
		/// Update entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		public IList<BankMovementCostCentersViewModel> Update(IEnumerable<BankMovementCostCentersViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._BankMovementCostCentersRepository.Update(entityCollection).ToList();

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion

			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			return modelCollection;
		}
		/// <summary>
		/// Update an entity.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public BankMovementCostCentersViewModel Update(BankMovementCostCentersViewModel model)
		{
            this.ThrowExceptionIfExist(model);

            var entity = model.ToEntity();
            entity = this._BankMovementCostCentersRepository.Update(entity);

            ConditionFilter<CostCenter, long> conditionFilter = new ConditionFilter<CostCenter, long>()
            {
                Query = (x =>
                        x.ParentKeyCostCenterId == entity.Id)
            };


            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion

            model = entity.ToModel();
            return model;
        }

		/// <summary>
		/// Delete entities.
		/// </summary>
		/// <param name="collection"></param>
		public void Delete(IEnumerable<BankMovementCostCentersViewModel> collection)
		{
			var entityCollection = collection.Select(model => model.ToEntity());
			this._BankMovementCostCentersRepository.Delete(entityCollection);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		public void Delete(IEnumerable<long> collection)
		{
			this._BankMovementCostCentersRepository.Delete(collection);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		public void Delete(BankMovementCostCentersViewModel model)
		{
			var entity = model.ToEntity();
			this._BankMovementCostCentersRepository.Delete(entity);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		public void Delete(long id)
		{
			var result = this._BankMovementCostCentersRepository.Delete(id);

			if (result == 0)
				throw new ItemNotFoundException();

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		#endregion
	}
}
