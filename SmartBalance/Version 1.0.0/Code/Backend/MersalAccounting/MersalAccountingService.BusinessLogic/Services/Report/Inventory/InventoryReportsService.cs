#region Using ...
using Framework.Common.Extentions;
using Framework.Core.Common;
using Framework.Core.IRepositories;
using MersalAccountingService.Core.Common;
using MersalAccountingService.Core.IRepositories;
using MersalAccountingService.Core.IServices;
using MersalAccountingService.Core.Models.ViewModels.Reports;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace MersalAccountingService.BusinessLogic.Services
{
    public class InventoryReportsService : IInventoryReportsService
    {
        #region Data Members
        private readonly IResourcesService _resourcesService;
        private readonly IInventorysRepository _inventorysRepository;
        private readonly IInventoryMovementsRepository _inventoryMovementsRepository;
        private readonly IBrandsRepository _brandsRepository;
        private readonly IMeasurementUnitsRepository _measurementUnitsRepository;
        private readonly IProductsRepository _productsRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly ISettingsService _settingsService;

        private readonly ILanguageService _languageService;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type TransactionsService.
        /// </summary>
        /// <param name="TransactionsRepository"></param>
        /// <param name="unitOfWork"></param>
        public InventoryReportsService(
            IResourcesService resourcesService,
            IInventorysRepository inventorysRepository,
            ICurrentUserService currentUserService,
            IInventoryMovementsRepository inventoryMovementsRepository,
            IBrandsRepository brandsRepository,
            IMeasurementUnitsRepository measurementUnitsRepository,
            IProductsRepository productsRepository,
            ISettingsService settingsService,
            ILanguageService languageService,
            IUnitOfWork unitOfWork)
        {
            this._resourcesService = resourcesService;
            this._inventorysRepository = inventorysRepository;
            this._currentUserService = currentUserService;
            this._inventoryMovementsRepository = inventoryMovementsRepository;
            this._brandsRepository = brandsRepository;
            this._measurementUnitsRepository = measurementUnitsRepository;
            this._productsRepository = productsRepository;
            this._settingsService = settingsService;

            this._languageService = languageService;
            this._unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods

        public IList<InventoryBalanceReportViewModel> GetInventoryBalanceReport(long? inventoryId, DateTime? dateFrom, DateTime? dateTo)
        {
            //DateFrom = DateFrom.SetTimeToNow();
            dateTo = dateTo.SetTimeToMax();
            var lang = this._languageService.CurrentLanguage;
            var userId = this._currentUserService.CurrentUserId;


            List<InventoryBalanceReportViewModel> reportList = new List<InventoryBalanceReportViewModel>();
            var inventory = this._inventorysRepository.Get(inventoryId.Value);
            var inventoryName = inventory.ChildTranslatedInventorys.FirstOrDefault(x => x.Language == lang)?.Name;

            var entityCollection = this._productsRepository.Get(null).Where(x => 
                x.InventoryId == inventoryId               
                );

            if(dateFrom.HasValue)            
                entityCollection = entityCollection.Where(x => x.CreationDate >= dateFrom);
            
            if(dateTo.HasValue)
                entityCollection = entityCollection.Where(x => x.CreationDate <= dateTo);

            if (entityCollection.Count() > 0)
            {
                List<Brand> brandList = new List<Brand>();
                List<MeasurementUnit> measurementUnitList = new List<MeasurementUnit>();


                foreach (var item in entityCollection)
                {
                    InventoryBalanceReportViewModel row = new InventoryBalanceReportViewModel
                    {     
                        Date = item.CreationDate,
                        //Date = item.LastModificationDate.HasValue ? item.LastModificationDate : (item.FirstModificationDate.HasValue ? item.FirstModificationDate : item.CreationDate),
                        InventoryCode = inventory.Code,
                        InventoryName = inventoryName,
                        NetValue = item.NetValue,
                        Price = item.Price,
                        Quantity = item.Quantity,
                        Discount = item.Discount
                    };

                    if (item.BrandId.HasValue)
                    {
                        var brand = brandList.FirstOrDefault(x => x.Id == item.BrandId.Value);
                        if (brand == null)
                        {
                            brand = this._brandsRepository.Get(item.BrandId.Value);
                            brandList.Add(brand);                        
                        }

                        row.BrandCode = brand.Code;
                        row.BrandName = brand.ChildTranslatedBrands.FirstOrDefault(x => x.Language == lang)?.Name;
                    }

                    if (item.MeasurementUnitId.HasValue)
                    {
                        var measurementUnit = measurementUnitList.FirstOrDefault(x => x.Id == item.MeasurementUnitId.Value);
                        if (measurementUnit == null)
                        {
                            measurementUnit = this._measurementUnitsRepository.Get(item.MeasurementUnitId.Value);
                            measurementUnitList.Add(measurementUnit);
                        }

                        row.MeasurementUnitName = measurementUnit.ChildTranslatedMeasurementUnits.FirstOrDefault(x => x.Language == lang)?.Name;
                    }

                    reportList.Add(row);
                }
            }
            else
            {
                InventoryBalanceReportViewModel row = new InventoryBalanceReportViewModel
                {
                    InventoryCode = inventory.Code,
                    InventoryName = inventoryName
                };
                reportList.Add(row);
            }

            return reportList;
        }

        //public InventoryBalanceReportViewModel mapToReportModel(InventoryMovement item, Language lang)
        //{
        //    InventoryBalanceReportViewModel result = new InventoryBalanceReportViewModel();


        //    return result;
        //}

        #endregion
    }
}
