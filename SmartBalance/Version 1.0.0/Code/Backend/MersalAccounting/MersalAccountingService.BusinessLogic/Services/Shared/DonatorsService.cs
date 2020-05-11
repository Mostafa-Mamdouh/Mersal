#region Using ...
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Framework.Common.Enums;
using Framework.Common.Exceptions;
using Framework.Common.Extentions;
using Framework.Core.Common;
using Framework.Core.Filters;
using Framework.Core.IRepositories;
using Framework.Core.Models.DTOs;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Common.Enums;
using MersalAccountingService.Common.Exceptions;
using MersalAccountingService.Core.AutoMapperConfig;
using MersalAccountingService.Core.IRepositories;
using MersalAccountingService.Core.IServices;
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

namespace MersalAccountingService.BusinessLogic.Services
{
    /// <summary>
    /// Provides Donator service for 
    /// business functionality.
    /// </summary>
    public class DonatorsService : IDonatorsService
    {
        #region Data Members
        private readonly IDonatorRepository _DonatorsRepository;
        private readonly IMobilesRepository _MobilesRepository;
        private readonly IMailsRepository _MailsRepository;
        private readonly IAddresssRepository _AddresssRepository;
        private readonly ILanguageService _languageService;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type DonatorsService.
        /// </summary>
        /// <param name="DonatorsRepository"></param>
        /// <param name="unitOfWork"></param>
        public DonatorsService(
            IDonatorRepository DonatorsRepository,
            IMobilesRepository MobilesRepository,
            IMailsRepository MailsRepository,
            IAddresssRepository AddresssRepository,
            ILanguageService languageService,
            IUnitOfWork unitOfWork)
        {
            this._DonatorsRepository = DonatorsRepository;
            this._MobilesRepository = MobilesRepository;
            this._MailsRepository = MailsRepository;
            this._AddresssRepository = AddresssRepository;
            this._languageService = languageService;
            this._unitOfWork = unitOfWork;


            //string filePath = $"D:\\Ahmed Shaikoun\\TFS Projects\\MersalAccountingSystem\\Version 1.0.0\\Documents\\Initialization Data\\Donor form (1) - Copy.xlsx";
            //this.ReadExcelFileDOM(filePath);
        }
        #endregion

        #region Methods

        public int ReadExcelFileDOM(IEnumerable<string> files)
        {
            int addedEntities = 0;
            //List<DonorFormDTO> result = new List<DonorFormDTO>();

            if (files != null)
            {
                foreach (var file in files)
                {
                    addedEntities += this.ReadExcelFileDOM(file);
                }
            }

            return addedEntities;
        }

        public int ReadExcelFileDOM(string fileName)
        {
            int addedEntities = 0;
            //List<DonorFormDTO> result = new List<DonorFormDTO>();

            try
            {
                using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(fileName, false))
                {
                    addedEntities = this.ReadExcelFileDOM(spreadsheetDocument);
                }
            }
            catch(System.IO.FileFormatException ex)
            {
                throw new GeneralException((int)ErrorCodeEnum.InvalidDonatorExcelSheet);
            }
            catch (DocumentFormat.OpenXml.Packaging.OpenXmlPackageException ex)
            {
                throw new GeneralException((int)ErrorCodeEnum.InvalidDonatorExcelSheet);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return addedEntities;
        }

        public int ReadExcelFileDOM(Stream stream)
        {
            int addedEntities = 0;
            //List<DonorFormDTO> result = new List<DonorFormDTO>();

            try
            {
                using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(stream, false))
                {
                    addedEntities = this.ReadExcelFileDOM(spreadsheetDocument);
                }
            }
            catch (System.IO.FileFormatException ex)
            {
                throw new GeneralException((int)ErrorCodeEnum.InvalidDonatorExcelSheet);
            }
            catch (DocumentFormat.OpenXml.Packaging.OpenXmlPackageException ex)
            {
                throw new GeneralException((int)ErrorCodeEnum.InvalidDonatorExcelSheet);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return addedEntities;
        }

        public int ReadExcelFileDOM(SpreadsheetDocument spreadsheetDocument)
        {
            List<DonorFormDTO> result = new List<DonorFormDTO>();
            bool thereIsValidSheet = false;

            if (spreadsheetDocument != null)
            {
                WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;

                SharedStringTablePart sstpart = workbookPart.GetPartsOfType<SharedStringTablePart>().First();
                SharedStringTable sst = sstpart.SharedStringTable;
                
                foreach (var worksheetPartItem in workbookPart.WorksheetParts)
                {
                    // iterate over Sheets
                    var sheets = worksheetPartItem.Worksheet.Elements<SheetData>();
                    for (int i = 0; i < sheets.Count(); i++)
                    {
                        var sheetDataitem = sheets.ElementAt(i);                      
                        var rows = sheetDataitem.Elements<Row>();
                        if (rows.Count() <= 1) continue;

                        for (int rowCounter = 0; rowCounter < rows.Count(); rowCounter++)
                        {
                            if (rowCounter == 0) continue;

                            var r = rows.ElementAt(rowCounter);

                            DonorFormDTO donorForm = new DonorFormDTO();                           
                            var cells = r.Elements<Cell>();
                            var count = cells.Count();
                            if (count == 30)
                                thereIsValidSheet = true;
                            else
                                continue;

                            for (int cellCounter = 0; cellCounter < count; cellCounter++)
                            {
                                var cell = cells.ElementAt(cellCounter);
                                string cellText = "";

                                if ((cell.DataType != null) && (cell.DataType == CellValues.SharedString))
                                {
                                    int ssid = int.Parse(cell.CellValue.Text);
                                    string str = sst.ChildElements[ssid].InnerText;
                                    cellText = str;                             
                                }
                                else if (cell.DataType != null && cell.DataType == CellValues.Date)
                                {
                                    int ssid = int.Parse(cell.CellValue.Text);
                                    string str = sst.ChildElements[ssid].InnerText;
                                    cellText = str;                                 
                                }
                                else
                                {
                                    cellText = cell?.CellValue?.Text;                                    
                                }

                                donorForm.Map(cellText, cellCounter);
                            }

                            result.Add(donorForm);                        
                        }                                               
                    }              
                }                 
            }

            if (thereIsValidSheet == false)
            {
                throw new GeneralException((int)ErrorCodeEnum.InvalidDonatorExcelSheet);
            }

            int addedEntities = this.Add(result);

            return addedEntities;
        }




        /// <summary>
        /// Throw an exception if name is exist.
        /// </summary>
        /// <param name="model">Donator view model</param>
        public void ThrowExceptionIfExist(DonatorViewModel model)
        {
            ConditionFilter<Donator, long> condition = new ConditionFilter<Donator, long>
            {
                Query = (entity =>
                    entity.Name == model.Name &&
                    entity.Id != model.Id)
            };
            var existEntity = this._DonatorsRepository.Get(condition).FirstOrDefault();

            if (existEntity != null)
                throw new ItemAlreadyExistException();
        }

        public GenericCollectionViewModel<ListDonatorLightViewModel> GetByFilter(DonatorFilterViewModel model)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<Donator, long> condition = new ConditionFilter<Donator, long>()
            {
                Order = Order.Descending
            };

            if (model.Sort?.Count > 0)
            {
                if (model.Sort[0].Dir != "desc") condition.Order = Order.Ascending;
            }

            //if (model.DateFrom.HasValue) model.DateFrom = model.DateFrom.SetTimeToNow();
            if (model.DateTo.HasValue) model.DateTo = model.DateTo.SetTimeToMax();

            // The IQueryable data to query.  
            IQueryable<Donator> queryableData = this._DonatorsRepository.Get(condition);

            //queryableData = queryableData.Where(x => x.Language == lang && x.ParentKeyBank != null);


            if (string.IsNullOrEmpty(model.Name) == false)
                queryableData = queryableData.Where(x => x.Name.Contains(model.Name));

            if (model.DateFrom.HasValue)
                queryableData = queryableData.Where(x => x.CreationDate >= model.DateFrom);

            if (model.DateTo.HasValue)
                queryableData = queryableData.Where(x => x.CreationDate <= model.DateTo);

            if (string.IsNullOrEmpty(model.Phone) == false)
            {
                IQueryable<long> mobiles = this._MobilesRepository.Get().Where(m => m.Number.Contains(model.Phone))
                    .Where(m => m.ObjectType == ObjectType.Donator).Select(m => m.ObjectId);
                queryableData = queryableData.Where(x => mobiles.Contains((long)x.Id));
            }

            if (string.IsNullOrEmpty(model.Email) == false)
            {
                IQueryable<long> mail = this._MailsRepository.Get().Where(m => m.Email.Contains(model.Email))
                    .Where(m => m.ObjectType == ObjectType.Donator).Select(m => m.ObjectId);
                queryableData = queryableData.Where(x => mail.Contains((long)x.Id));
            }


            var entityCollection = queryableData.ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToListModel()).ToList();

            foreach (var item in entityCollection)
            {
                var ViewModel = dtoCollection.Find(x => x.Id == item.Id);
                ViewModel.Date = item.CreationDate;

                Mobile mobile = this._MobilesRepository.Get().FirstOrDefault(x => x.ObjectId == item.Id && x.ObjectType == ObjectType.Donator);

                if(mobile != null)
                {
                    ViewModel.Phone = mobile.Number;
                }

                Mail mail = this._MailsRepository.Get().FirstOrDefault(x => x.ObjectId == item.Id && x.ObjectType == ObjectType.Donator);

                if(mail != null)
                {
                    ViewModel.Email = mail.Email;
                }

                

                //if (item.ParentKeyBank != null)
                //{
                //    ViewModel.BankName = item.ParentKeyBank.ChildTranslatedBanks.First(x => x.Language == lang).Name;
                //}              
            }
            //if (model.Filters != null)
            //{
            //    foreach (var item in model.Filters)
            //    {
            //        switch (item.Field)
            //        {
            //            case "source":
            //                dtoCollection = dtoCollection.Where(x => x.Source.Contains(item.Value)).ToList();
            //                break;
            //            case "amount":
            //                dtoCollection = dtoCollection.Where(x => x.Amount.Equals(Convert.ToDecimal(item.Value))).ToList();
            //                break;
            //            default:
            //                break;
            //        }
            //    }
            //}
            var total = dtoCollection.Count();
            dtoCollection = dtoCollection.Skip(model.PageIndex * model.PageSize).Take(model.PageSize).ToList();
            var result = new GenericCollectionViewModel<ListDonatorLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = total,
                PageIndex = model.PageIndex,
                PageSize = model.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of DonatorViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<DonatorViewModel> Get(ConditionFilter<Donator, long> condition)
        {
            var entityCollection = this._DonatorsRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<DonatorViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of DonatorViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<DonatorViewModel> Get(int? pageIndex, int? pageSize)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<Donator, long> condition = new ConditionFilter<Donator, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                //Query = (item =>
                //	item.Language == lang)
            };
            var entityCollection = this._DonatorsRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<DonatorViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of DonatorViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<DonatorLightViewModel> GetLightModel(ConditionFilter<Donator, long> condition)
        {
            var entityCollection = this._DonatorsRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            var result = new GenericCollectionViewModel<DonatorLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = dtoCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of DonatorViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<DonatorLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<Donator, long> condition = new ConditionFilter<Donator, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                //Query = (item =>
                //	item.Language == lang)
            };
            var entityCollection = this._DonatorsRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            var result = new GenericCollectionViewModel<DonatorLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = dtoCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a ProductLookUpViewModel.
        /// </summary>
        /// <param>no params </param>
        /// <returns> a list of ProductLookUpViewModel </returns>
        public List<DonatorLightViewModel> GetLookUp()
        {
            var lang = this._languageService.CurrentLanguage;

            //ConditionFilter<Donator, long> condition = new ConditionFilter<Donator, long>
            //{
            //    Query = (item =>
            //    item.Language == lang )
            //};
            var entityCollection = this._DonatorsRepository.Get().ToList();
            var lookup = entityCollection.Select(entity => entity.ToLightModel()).ToList();

            return lookup;
        }

        /// <summary>
        /// Gets a DonatorViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DonatorViewModel Get(long id)
        {
            var entity = this._DonatorsRepository.Get(id);
            var model = entity.ToModel();

            model.Email = this._MailsRepository.Get().FirstOrDefault(x => x.ObjectId == entity.Id && x.ObjectType == ObjectType.Donator).Email;
            model.Phone = this._MobilesRepository.Get().FirstOrDefault(x => x.ObjectId == entity.Id && x.ObjectType == ObjectType.Donator).Number;
            Address address = this._AddresssRepository.Get().FirstOrDefault(x => x.ObjectId == entity.Id && x.ObjectType == ObjectType.Donator);
            if (address != null) model.Address = address.Description;

            return model;
        }

        /// <summary>
        /// Add entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public IList<DonatorViewModel> Add(IEnumerable<DonatorViewModel> collection)
        {
            foreach (var model in collection)
            {
                this.ThrowExceptionIfExist(model);
            }

            var entityCollection = collection.Select(model => model.ToEntity());
            entityCollection = this._DonatorsRepository.Add(entityCollection).ToList();

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
        public DonatorViewModel Add(DonatorViewModel model)
        {
            this.ThrowExceptionIfExist(model);

            var entity = model.ToEntity();
            entity = this._DonatorsRepository.Add(entity);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion

            this._AddresssRepository.Add(new Address { ObjectId = entity.Id, ObjectType = ObjectType.Donator, IsActive = true, IsMain = true, Description = model.Address });

            this._MailsRepository.Add(new Mail { ObjectId = entity.Id, ObjectType = ObjectType.Donator, IsActive = true, IsMain = true, Email = model.Email });

            this._MobilesRepository.Add(new Mobile { ObjectId = entity.Id, ObjectType = ObjectType.Donator, IsActive = true, IsMain = true, Number = model.Phone });

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion

            model = entity.ToModel();
            return model;
        }

        public int Add(IList<DonorFormDTO> dtos)
        {
            int addedEntities = 0;

            if (dtos != null)
            {
                //bool needCommit = false;
                IList<Donator> donatorList = new List<Donator>();

                for (int i = 0; i < dtos.Count; i++)
                {
                    var donator = dtos[i];
                    var existEmail = this._MailsRepository.Get(null).Where(x =>
                        x.ObjectType == ObjectType.Donator &&
                        x.Email == donator.Email)
                        .FirstOrDefault();

                    var existPhone = this._MobilesRepository.Get(null).Where(x =>
                        x.ObjectType == ObjectType.Donator &&
                        (x.Number == donator.Phone1 || x.Number == donator.Phone2 || x.Number == donator.Phone1))
                        .FirstOrDefault();

                    if (existEmail != null || existPhone != null)
                    {
                        // Do nothing for now;
                    }
                    else
                    {
                        Donator entity = new Donator
                        {
                            Name = donator.Name,
                            Description = donator.Comment
                        };
                        entity = this._DonatorsRepository.Add(entity);

                        donatorList.Add(entity);

                        #region Commit Changes
                        this._unitOfWork.Commit();
                        #endregion

                        var address = new Address { ObjectId = entity.Id, ObjectType = ObjectType.Donator, IsActive = true, IsMain = true, Description = donator.Address1 };
                        var mail = new Mail { ObjectId = entity.Id, ObjectType = ObjectType.Donator, IsActive = true, IsMain = true, Email = donator.Email };
                        var mobile = new Mobile { ObjectId = entity.Id, ObjectType = ObjectType.Donator, IsActive = true, IsMain = true, Number = donator.Phone1 };

                        if (string.IsNullOrEmpty(donator.Address1))
                            address.Description = donator.Address2;

                        if (string.IsNullOrEmpty(donator.Address2))
                            address.Description = donator.Address3;


                        if (string.IsNullOrEmpty(donator.Phone1))
                            address.Description = donator.Phone2;

                        if (string.IsNullOrEmpty(donator.Phone2))
                            address.Description = donator.Phone3;

                        this._AddresssRepository.Add(address);
                        this._MailsRepository.Add(mail);
                        this._MobilesRepository.Add(mobile);

                        #region Commit Changes
                        this._unitOfWork.Commit();
                        #endregion

                        addedEntities++;
                    }
                }

                if (donatorList.Count > 0)
                {

                }
            }

            return addedEntities;
        }

        /// <summary>
        /// Update entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public IList<DonatorViewModel> Update(IEnumerable<DonatorViewModel> collection)
        {
            foreach (var model in collection)
            {
                this.ThrowExceptionIfExist(model);
            }

            var entityCollection = collection.Select(model => model.ToEntity());
            entityCollection = this._DonatorsRepository.Update(entityCollection).ToList();

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
        public DonatorViewModel Update(DonatorViewModel model)
        {
            this.ThrowExceptionIfExist(model);

            var entity = model.ToEntity();
            entity = this._DonatorsRepository.Update(entity);

            Mobile mobile = this._MobilesRepository.Get().FirstOrDefault(x => x.ObjectId == entity.Id && x.ObjectType == ObjectType.Donator);
            mobile.Number = model.Phone;
            this._MobilesRepository.Update(mobile);

            Mail mail = this._MailsRepository.Get().FirstOrDefault(x => x.ObjectId == entity.Id && x.ObjectType == ObjectType.Donator);
            mail.Email = model.Email;
            this._MailsRepository.Update(mail);

            Address address = this._AddresssRepository.Get().FirstOrDefault(x => x.ObjectId == entity.Id && x.ObjectType == ObjectType.Donator);
            if (address == null)
            {
                address = new Address
                {
                    ObjectId = entity.Id,
                    ObjectType = ObjectType.Donator,
                    Description = model.Address,
                    IsActive = true,
                    IsMain = true
                };
                this._AddresssRepository.Add(address);
            }
            else
            {
                address.Description = model.Address;
                this._AddresssRepository.Update(address);
            }

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
        public void Delete(IEnumerable<DonatorViewModel> collection)
        {
            var entityCollection = collection.Select(model => model.ToEntity());
            this._DonatorsRepository.Delete(entityCollection);

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
            this._DonatorsRepository.Delete(collection);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }
        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="model"></param>
        public void Delete(DonatorViewModel model)
        {
            var entity = model.ToEntity();
            this._DonatorsRepository.Delete(entity);

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
            var result = this._DonatorsRepository.Delete(id);

            if (result == 0)
                throw new ItemNotFoundException();

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }
        #endregion
    }
}
