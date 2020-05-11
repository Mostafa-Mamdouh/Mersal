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
    public class FixedAssetReportsService : IFixedAssetReportsService
    {
        #region Data Members
        private readonly IResourcesService _resourcesService;
        private readonly IAssetsRepository _assetsRepository;
        private readonly IInventorysRepository _inventorysRepository;
        private readonly IInventoryMovementsRepository _inventoryMovementsRepository;
        private readonly IBrandsRepository _brandsRepository;
        private readonly IMeasurementUnitsRepository _measurementUnitsRepository;
        private readonly IDepreciationRatesRepository _depreciationRatesRepository;
        private readonly IDepreciationTypesRepository _depreciationTypesRepository;
        private readonly ILocationsRepository _locationsRepository;
        private readonly IVendorsRepository _vendorsRepository;
        private readonly IAssetInventorysRepository _assetInventorysRepository;
        private readonly IAssetInventoryDetailsRepository _assetInventoryDetailsRepository;
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
        public FixedAssetReportsService(
            IResourcesService resourcesService,
            IAssetsRepository assetsRepository,
            IInventorysRepository inventorysRepository,
            ICurrentUserService currentUserService,
            IInventoryMovementsRepository inventoryMovementsRepository,
            IBrandsRepository brandsRepository,
            IMeasurementUnitsRepository measurementUnitsRepository,
            IDepreciationRatesRepository depreciationRatesRepository,
            IDepreciationTypesRepository depreciationTypesRepository,
            ILocationsRepository locationsRepository,
            IVendorsRepository vendorsRepository,
            IAssetInventorysRepository assetInventorysRepository,
            IAssetInventoryDetailsRepository assetInventoryDetailsRepository,
            ISettingsService settingsService,
            ILanguageService languageService,
            IUnitOfWork unitOfWork)
        {
            this._resourcesService = resourcesService;
            this._assetsRepository = assetsRepository;
            this._inventorysRepository = inventorysRepository;
            this._currentUserService = currentUserService;
            this._inventoryMovementsRepository = inventoryMovementsRepository;
            this._brandsRepository = brandsRepository;
            this._measurementUnitsRepository = measurementUnitsRepository;
            this._depreciationRatesRepository = depreciationRatesRepository;
            this._depreciationTypesRepository = depreciationTypesRepository;
            this._locationsRepository = locationsRepository;
            this._vendorsRepository = vendorsRepository;
            this._assetInventorysRepository = assetInventorysRepository;
            this._assetInventoryDetailsRepository = assetInventoryDetailsRepository;
            this._settingsService = settingsService;

            this._languageService = languageService;
            this._unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods		
        public IList<FixedAssetDepreciationReportViewModel> GetFixedAssetsDepreciationReport(DateTime? dateFrom, DateTime? dateTo)
        {
            //DateFrom = DateFrom.SetTimeToNow();
            dateTo = dateTo.SetTimeToMax();
            var lang = this._languageService.CurrentLanguage;
            var userId = this._currentUserService.CurrentUserId;


            List<FixedAssetDepreciationReportViewModel> reportList = new List<FixedAssetDepreciationReportViewModel>();
            var entityCollection = this._assetsRepository.Get(null).Where(x =>
                x.ParentKeyAssetId.HasValue == false &&
                x.IsExcluded.HasValue == false &&
                x.IsSaled.HasValue == false &&
                //(x.IsSaled.HasValue == false || (x.IsSaled.HasValue && x.IsSaled.Value == false)) &&
                //(x.IsExcluded.HasValue == false || (x.IsExcluded.HasValue && x.IsExcluded.Value == false)) &&
                x.LastDepreciationDate.HasValue &&
                x.LastDepreciationDate >= dateFrom &&
                x.LastDepreciationDate <= dateTo
                );

            if (entityCollection.Count() > 0)
            {
                List<Vendor> vendorList = new List<Vendor>();
                List<Brand> brandList = new List<Brand>();
                List<Location> locationList = new List<Location>();
                List<DepreciationRate> depreciationRateList = new List<DepreciationRate>();

                foreach (var item in entityCollection)
                {
                    FixedAssetDepreciationReportViewModel row = new FixedAssetDepreciationReportViewModel
                    {
                        Amount = item.Amount,
                        CurrentValue = item.CurrentValue,
                        Date = item.PurchaseDate,
                        DepreciationValue = item.DepreciationValue,
                        LastDepreciationDate = item.LastDepreciationDate,
                        Quantity = item.Quantity,
                    };

                    #region Set Vendor
                    var vendor = vendorList.FirstOrDefault(x => x.Id == item.Vendor);
                    if (vendor == null)
                    {
                        vendor = this._vendorsRepository.Get(item.Vendor.Value);
                    }

                    row.VendorName = vendor.ChildTranslatedVendors.FirstOrDefault(x => x.Language == lang)?.Name;
                    #endregion

                    #region Set Brand
                    var brand = brandList.FirstOrDefault(x => x.Id == item.BrandId);
                    if (brand == null)
                    {
                        brand = this._brandsRepository.Get(item.BrandId.Value);
                    }

                    row.Code = brand.Code;
                    row.BrandCode = brand.Code;
                    row.BrandName = brand.ChildTranslatedBrands.FirstOrDefault(x => x.Language == lang)?.Name;
                    #endregion

                    #region Set DepreciationRate
                    var depreciationRate = depreciationRateList.FirstOrDefault(x => x.Id == item.DepreciationRateId);
                    if (depreciationRate == null)
                    {
                        depreciationRate = this._depreciationRatesRepository.Get(item.DepreciationRateId.Value);
                    }

                    row.DepreciationRateName = depreciationRate.ChildTranslatedDepreciationRates.FirstOrDefault(x => x.Language == lang)?.Name;
                    #endregion

                    #region Set Location
                    Location location = null; // item.AssetLocations.OrderByDescending(x => x.Id).FirstOrDefault()?.Location;
                    //var location = locationList.FirstOrDefault(x => x.AssetLocations.Where(y => y.LocationId == x.Id));
                    if (location == null)
                    {
                        location = this._locationsRepository.Get(item.AssetLocations.OrderByDescending(x => x.Id).FirstOrDefault().LocationId.Value);
                    }

                    row.LocationName = location.ChildTranslatedLocations.FirstOrDefault(x => x.Language == lang).Description;
                    #endregion

                    reportList.Add(row);
                }
            }
            //else
            //{

            //}

            return reportList;
        }

        public IList<FixedAssetLocationReportViewModel> GetFixedAssetsLocationReport(long? locationId, DateTime? dateFrom, DateTime? dateTo)
        {
            //DateFrom = DateFrom.SetTimeToNow();
            dateTo = dateTo.SetTimeToMax();
            var lang = this._languageService.CurrentLanguage;
            var userId = this._currentUserService.CurrentUserId;


            List<FixedAssetLocationReportViewModel> reportList = new List<FixedAssetLocationReportViewModel>();

            var entityCollection = this._assetsRepository.Get(null).Where(x =>
                x.ParentKeyAssetId.HasValue == false &&
                //(x.IsSaled.HasValue == false || (x.IsSaled.HasValue && x.IsSaled == false)) &&
                //(x.IsExcluded.HasValue == false || (x.IsExcluded.HasValue && x.IsExcluded == false)) &&
                x.PurchaseDate >= dateFrom &&
                x.PurchaseDate <= dateTo);

            if (locationId.HasValue)
                entityCollection = entityCollection.Where(x => x.AssetLocations.Where(y=>y.LocationId == locationId).Count() > 0);

            if (entityCollection.Count() > 0)
            {
                List<Vendor> vendorList = new List<Vendor>();
                List<Brand> brandList = new List<Brand>();
                List<Location> locationList = new List<Location>();
                //List<DepreciationRate> depreciationRateList = new List<DepreciationRate>();

                foreach (var item in entityCollection)
                {
                    FixedAssetLocationReportViewModel row = new FixedAssetLocationReportViewModel
                    {
                        Amount = item.Amount,
                        CurrentValue = item.CurrentValue,
                        Date = item.PurchaseDate,
                        Quantity = item.Quantity,
                        Description = item.ChildTranslatedAssets.FirstOrDefault(x => x.Language == lang)?.Description
                    };

                    #region Set Vendor
                    var vendor = vendorList.FirstOrDefault(x => x.Id == item.Vendor);
                    if (vendor == null)
                    {
                        vendor = this._vendorsRepository.Get(item.Vendor.Value);
                    }

                    row.VendorName = vendor.ChildTranslatedVendors.FirstOrDefault(x => x.Language == lang)?.Name;
                    #endregion

                    #region Set Brand
                    var brand = brandList.FirstOrDefault(x => x.Id == item.BrandId);
                    if (brand == null)
                    {
                        brand = this._brandsRepository.Get(item.BrandId.Value);
                    }

                    row.Code = brand.Code;
                    row.BrandCode = brand.Code;
                    row.BrandName = brand.ChildTranslatedBrands.FirstOrDefault(x => x.Language == lang)?.Name;
                    #endregion

                    #region Set Location
                    Location location = null;// locationList.FirstOrDefault(x => x.Id == item.LocationId);
                    if (location == null)
                    {
                        location = this._locationsRepository.Get(item.AssetLocations.OrderByDescending(x => x.Id).FirstOrDefault().LocationId.Value);
                    }

                    row.LocationName = location.ChildTranslatedLocations.FirstOrDefault(x => x.Language == lang).Description;
                    #endregion

                    reportList.Add(row);
                }
            }
            //else
            //{

            //}

            return reportList;

        }

        public IList<FixedAssetExcludedReportViewModel> GetFixedAssetsExcludedReport(DateTime? dateFrom, DateTime? dateTo)
        {
            //DateFrom = DateFrom.SetTimeToNow();
            dateTo = dateTo.SetTimeToMax();
            var lang = this._languageService.CurrentLanguage;
            var userId = this._currentUserService.CurrentUserId;


            List<FixedAssetExcludedReportViewModel> reportList = new List<FixedAssetExcludedReportViewModel>();

            var entityCollection = this._assetsRepository.Get(null).Where(x =>
                x.ParentKeyAssetId.HasValue == false &&
                (x.IsExcluded.HasValue == true && x.ExcludedDate >= dateFrom && x.ExcludedDate <= dateTo) ||				
				(x.IsSaled.HasValue == true && x.SaleDate >= dateFrom && x.SaleDate <= dateTo));


            if (entityCollection.Count() > 0)
            {
                List<Vendor> vendorList = new List<Vendor>();
                List<Brand> brandList = new List<Brand>();
                List<Location> locationList = new List<Location>();
                List<DepreciationRate> depreciationRateList = new List<DepreciationRate>();

                foreach (var item in entityCollection)
                {
                    FixedAssetExcludedReportViewModel row = new FixedAssetExcludedReportViewModel
                    {
                        Amount = item.Amount,
                        CurrentValue = item.CurrentValue,
                        Date = item.PurchaseDate,
                        DepreciationValue = item.DepreciationValue,
                        ExcludedDate = item.ExcludedDate,
                        IsExcluded = item.IsExcluded,
                        IsSaled = item.IsSaled,
                        LastDepreciationDate = item.LastDepreciationDate,
                        Quantity = item.Quantity,
                        SaleAmount = item.SaleAmount,
                        SaleDate = item.SaleDate
                    };

                    #region Set Vendor
                    var vendor = vendorList.FirstOrDefault(x => x.Id == item.Vendor);
                    if (vendor == null)
                    {
                        vendor = this._vendorsRepository.Get(item.Vendor.Value);
                    }

                    row.VendorName = vendor.ChildTranslatedVendors.FirstOrDefault(x => x.Language == lang)?.Name;
                    #endregion

                    #region Set Brand
                    var brand = brandList.FirstOrDefault(x => x.Id == item.BrandId);
                    if (brand == null)
                    {
                        brand = this._brandsRepository.Get(item.BrandId.Value);
                    }

                    row.Code = brand.Code;
                    row.BrandCode = brand.Code;
                    row.BrandName = brand.ChildTranslatedBrands.FirstOrDefault(x => x.Language == lang)?.Name;
                    #endregion

                    #region Set DepreciationRate
                    var depreciationRate = depreciationRateList.FirstOrDefault(x => x.Id == item.DepreciationRateId);
                    if (depreciationRate == null)
                    {
                        depreciationRate = this._depreciationRatesRepository.Get(item.DepreciationRateId.Value);
                    }

                    row.DepreciationRateName = depreciationRate.ChildTranslatedDepreciationRates.FirstOrDefault(x => x.Language == lang)?.Name;
                    #endregion

                    #region Set Location
                    Location location = null;// locationList.FirstOrDefault(x => x.Id == item.LocationId);
                    if (location == null)
                    {
                        location = this._locationsRepository.Get(item.AssetLocations.OrderByDescending(x => x.Id).FirstOrDefault().LocationId.Value);
                    }

                    row.LocationName = location.ChildTranslatedLocations.FirstOrDefault(x => x.Language == lang).Description;
                    #endregion

                    reportList.Add(row);
                }
            }
            //else
            //{

            //}

            return reportList;

        }

        public IList<FixedAssetInventoryReportViewModel> GetFixedAssetsInventoryReport(long? locationId, DateTime? dateFrom, DateTime? dateTo)
        {
            //DateFrom = DateFrom.SetTimeToNow();
            dateTo = dateTo.SetTimeToMax();
            var lang = this._languageService.CurrentLanguage;
            var userId = this._currentUserService.CurrentUserId;


            List<FixedAssetInventoryReportViewModel> reportList = new List<FixedAssetInventoryReportViewModel>();

            var entityCollection = this._assetInventoryDetailsRepository.Get(null).Where(x =>                 
              x.AssetInventory.Date >= dateFrom &&
              x.AssetInventory.Date <= dateTo);

            if (locationId.HasValue)
                entityCollection = entityCollection.Where(x => x.AssetInventory.LocationId == locationId);


            if (entityCollection.Count() > 0)
            {                
                List<Brand> brandList = new List<Brand>();
                List<Location> locationList = new List<Location>();

                foreach (var item in entityCollection)
                {
                    FixedAssetInventoryReportViewModel row = new FixedAssetInventoryReportViewModel
                    {
                        Date = item.AssetInventory.Date,
                        ActualQuantity = item.ActualQuantity,
                        Difference = item.Difference,
                        ExpectedQuantity = item.ExpectedQuantity
                    };                    

                    #region Set Brand
                    var brand = brandList.FirstOrDefault(x => x.Id == item.BrandId);
                    if (brand == null)
                    {
                        brand = this._brandsRepository.Get(item.BrandId.Value);
                    }
                    
                    row.BrandCode = brand.Code;
                    row.BrandName = brand.ChildTranslatedBrands.FirstOrDefault(x => x.Language == lang)?.Name;
                    #endregion

                    #region Set Location
                    var location = locationList.FirstOrDefault(x => x.Id == item.AssetInventory.LocationId);
                    if (location == null)
                    {
                        location = this._locationsRepository.Get(item.AssetInventory.LocationId.Value);
                    }

                    row.LocationName = location.ChildTranslatedLocations.FirstOrDefault(x => x.Language == lang).Description;
                    #endregion

                    reportList.Add(row);
                }
            }

            return reportList;
        }

        public IList<FixedAssetLostReportViewModel> GetFixedAssetsLostReport(long? locationId, DateTime? dateFrom, DateTime? dateTo)
        {
            //DateFrom = DateFrom.SetTimeToNow();
            dateTo = dateTo.SetTimeToMax();
            var lang = this._languageService.CurrentLanguage;
            var userId = this._currentUserService.CurrentUserId;


            List<FixedAssetLostReportViewModel> reportList = new List<FixedAssetLostReportViewModel>();

            var entityCollection = this._assetInventoryDetailsRepository.Get(null).Where(x =>
                x.ActualQuantity < x.ExpectedQuantity &&
                x.AssetInventory.Date >= dateFrom &&
                x.AssetInventory.Date <= dateTo);

            if (locationId.HasValue)
                entityCollection = entityCollection.Where(x => x.AssetInventory.LocationId == locationId);


            if (entityCollection.Count() > 0)
            {
                List<Brand> brandList = new List<Brand>();
                List<Location> locationList = new List<Location>();

                foreach (var item in entityCollection)
                {
                    FixedAssetLostReportViewModel row = new FixedAssetLostReportViewModel
                    {
                        Date = item.AssetInventory.Date,
                        ActualQuantity = item.ActualQuantity,
                        Difference = item.Difference,
                        ExpectedQuantity = item.ExpectedQuantity
                    };

                    #region Set Brand
                    var brand = brandList.FirstOrDefault(x => x.Id == item.BrandId);
                    if (brand == null)
                    {
                        brand = this._brandsRepository.Get(item.BrandId.Value);
                    }

                    row.BrandCode = brand.Code;
                    row.BrandName = brand.ChildTranslatedBrands.FirstOrDefault(x => x.Language == lang)?.Name;
                    #endregion

                    #region Set Location
                    var location = locationList.FirstOrDefault(x => x.Id == item.AssetInventory.LocationId);
                    if (location == null)
                    {
                        location = this._locationsRepository.Get(item.AssetInventory.LocationId.Value);
                    }

                    row.LocationName = location.ChildTranslatedLocations.FirstOrDefault(x => x.Language == lang).Description;
                    #endregion

                    reportList.Add(row);
                }
            }


            return reportList;
        }

        #endregion
    }
}
