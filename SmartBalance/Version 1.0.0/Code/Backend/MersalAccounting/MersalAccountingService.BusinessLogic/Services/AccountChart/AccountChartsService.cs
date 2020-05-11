#region Using ...
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Framework.Common.Enums;
using Framework.Common.Exceptions;
using Framework.Core.Common;
using Framework.Core.Filters;
using Framework.Core.IRepositories;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Common.Enums;
using MersalAccountingService.Common.Exceptions;
using MersalAccountingService.Core.AutoMapperConfig;
using MersalAccountingService.Core.Common;
using MersalAccountingService.Core.IRepositories;
using MersalAccountingService.Core.IServices;
using MersalAccountingService.Core.Models.DTOs;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels.AccountChart;
using MersalAccountingService.Core.Models.ViewModels.LightViewModels;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
#endregion

namespace MersalAccountingService.BusinessLogic.Services
{
	/// <summary>
	/// Provides AccountChart service for 
	/// business functionality.
	/// </summary>
	public class AccountChartsService : IAccountChartsService
	{
		#region Data Members
		private readonly IAccountChartsRepository _AccountChartsRepository;
		private readonly IAccountChartSettingsRepository _AccountChartSettingRepository;
		private readonly ICurrencysRepository _currencysRepository;
		private readonly IBranchsRepository _branchsRepository;
        private readonly ISafeAccountChartsRepository _safeAccountChartsRepository;
        private readonly ISafesRepository _safesRepository;

		private readonly ILanguageService _languageService;
		private readonly IUnitOfWork _unitOfWork;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type AccountChartsService.
		/// </summary>
		/// <param name="AccountChartsRepository"></param>
		/// <param name="unitOfWork"></param>
		public AccountChartsService(
			IAccountChartsRepository AccountChartsRepository,
			ILanguageService languageService,
			IAccountChartSettingsRepository AccountChartSettingRepository,
			ICurrencysRepository currencysRepository,
			IBranchsRepository branchsRepository,
            ISafeAccountChartsRepository safeAccountChartsRepository,
            ISafesRepository safesRepository,
			IUnitOfWork unitOfWork)
		{
			this._AccountChartsRepository = AccountChartsRepository;
			this._languageService = languageService;
			this._AccountChartSettingRepository = AccountChartSettingRepository;
			this._currencysRepository = currencysRepository;
			this._branchsRepository = branchsRepository;
            this._safeAccountChartsRepository = safeAccountChartsRepository;
            this._safesRepository = safesRepository;
			this._unitOfWork = unitOfWork;


			string fileName = "mersalAccounts.xlsx"; //"mersal_Charts of Accounts.xlsx";
													 //this.ReadExcelFileDOM($"D:\\Ahmed Shaikoun\\TFS Projects\\MersalAccountingSystem\\Version 1.0.0\\Documents\\Initialization Data\\{fileName}");


			//string fileName = "Book1.xlsx";
			//this.ReadExcelFileDOM($"D:\\{fileName}");
			//this.x($"D:\\{fileName}");
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
			List<AccountChartFormDTO> result = new List<AccountChartFormDTO>();
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
					int sheetsCount = sheets.Count();

					for (int i = 0; i < sheetsCount; i++)
					{
						var sheetDataitem = sheets.ElementAt(i);
						var rows = sheetDataitem.Elements<Row>();
						int rowsCount = rows.Count();

						if (rowsCount <= 1) continue;

						for (int rowCounter = 0; rowCounter < rowsCount; rowCounter++)
						{
							if (rowCounter == 0) continue;

							var r = rows.ElementAt(rowCounter);

							AccountChartFormDTO accountChartFormForm = new AccountChartFormDTO();
							var cells = r.Elements<Cell>();
							var count = cells.Count();
							if (count == 6)
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

								accountChartFormForm.Map(cellText, cellCounter);
							}

							result.Add(accountChartFormForm);
						}
					}
				}
			}

			if (thereIsValidSheet == false)
			{
				throw new GeneralException((int)ErrorCodeEnum.InvalidDonatorExcelSheet);
			}

			int addedEntities = this.Add(result); //this.Add(result);	
			return addedEntities;
		}


		public void x(string fileName)
		{
			using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
			{
				using (SpreadsheetDocument doc = SpreadsheetDocument.Open(fs, false))
				{
					WorkbookPart workbookPart = doc.WorkbookPart;
					SharedStringTablePart sstpart = workbookPart.GetPartsOfType<SharedStringTablePart>().First();
					SharedStringTable sst = sstpart.SharedStringTable;

					WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
					Worksheet sheet = worksheetPart.Worksheet;

					var cells = sheet.Descendants<Cell>();
					var rows = sheet.Descendants<Row>();

					Console.WriteLine("Row count = {0}", rows.LongCount());
					Console.WriteLine("Cell count = {0}", cells.LongCount());

					// One way: go through each cell in the sheet
					foreach (Cell cell in cells)
					{
						if ((cell.DataType != null) && (cell.DataType == CellValues.SharedString))
						{
							int ssid = int.Parse(cell.CellValue.Text);
							string str = sst.ChildElements[ssid].InnerText;
							Console.WriteLine("Shared string {0}: {1}", ssid, str);
						}
						else if (cell.CellValue != null)
						{
							Console.WriteLine("Cell contents: {0}", cell.CellValue.Text);
						}
					}

					List<string> rowsList = new List<string>();
					// Or... via each row
					foreach (Row row in rows)
					{
						string rowItem = "";
						foreach (Cell c in row.Elements<Cell>())
						{
							if ((c.DataType != null) && (c.DataType == CellValues.SharedString))
							{
								int ssid = int.Parse(c.CellValue.Text);
								string str = sst.ChildElements[ssid].InnerText;

								rowItem += str + " ";
								//Console.WriteLine("Shared string {0}: {1}", ssid, str);
							}
							else if (c.CellValue != null)
							{
								rowItem += c.CellValue.Text;
								Console.WriteLine("Cell contents: {0}", c.CellValue.Text);
							}
						}
						rowsList.Add(rowItem);
					}


				}
			}
		}

		//public void ReadExcelFileDOM(string fileName)
		//{
		//    List<AccountChartLevelSettingViewModel> levels = new List<AccountChartLevelSettingViewModel>();
		//    levels.Add(new AccountChartLevelSettingViewModel(1, 1));
		//    levels.Add(new AccountChartLevelSettingViewModel(2, 1));
		//    levels.Add(new AccountChartLevelSettingViewModel(3, 2));
		//    levels.Add(new AccountChartLevelSettingViewModel(4, 1));
		//    levels.Add(new AccountChartLevelSettingViewModel(5, 1));
		//    levels.Add(new AccountChartLevelSettingViewModel(6, 2));


		//    for (int i = 0; i < levels.Count; i++)
		//    {
		//        if (i > 0)
		//            levels[i].TotalLength = levels[i - 1].TotalLength + levels[i].Length;
		//        else
		//            levels[i].TotalLength = levels[i].Length;
		//    }

		//    List<string> excluded = new List<string>();

		//    using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(fileName, false))
		//    {
		//        WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;

		//        SharedStringTablePart sstpart = workbookPart.GetPartsOfType<SharedStringTablePart>().First();
		//        SharedStringTable sst = sstpart.SharedStringTable;

		//        List<List<List<string>>> listsRoot = new List<List<List<string>>>();
		//        foreach (var worksheetPartItem in workbookPart.WorksheetParts)
		//        {
		//            List<List<string>> lists = new List<List<string>>();
		//            foreach (var sheetDataitem in worksheetPartItem.Worksheet.Elements<SheetData>())
		//            {
		//                List<string> rowsList = new List<string>();
		//                var rows = sheetDataitem.Elements<Row>();
		//                foreach (Row r in rows)
		//                {
		//                    string row = "";
		//                    var cells = r.Elements<Cell>();
		//                    var count = cells.Count();
		//                    string excludedRow = "";

		//                    for (int cellCounter = 0; cellCounter < count; cellCounter++)
		//                    {
		//                        var cell = cells.ElementAt(cellCounter);
		//                        string cellText = "";

		//                        if ((cell.DataType != null) && (cell.DataType == CellValues.SharedString))
		//                        {
		//                            int ssid = int.Parse(cell.CellValue.Text);
		//                            string str = sst.ChildElements[ssid].InnerText;
		//                            cellText = str;

		//                            row += str + ", ";
		//                            Console.WriteLine("Shared string {0}: {1}", ssid, str);
		//                        }
		//                        else
		//                        {
		//                            cellText = cell?.CellValue?.Text;
		//                            row += cell?.CellValue?.Text + ", ";
		//                        }

		//                        if (cellCounter == 0 && cellText != null)
		//                        {
		//                            var levl = levels.FirstOrDefault(x => x.TotalLength == cellText.Length);

		//                            if (levl == null)
		//                            {
		//                                excludedRow = cellText;
		//                            }
		//                        }

		//                        if (cellCounter > 0 && string.IsNullOrEmpty(excludedRow) == false)
		//                        {
		//                            excludedRow += " - " + cellText;
		//                        }
		//                    }

		//                    if (string.IsNullOrEmpty(excludedRow) == false)
		//                    {
		//                        excluded.Add($"[{excluded.Count + 1}] - " + excludedRow);
		//                    }
		//                    rowsList.Add(row);
		//                }
		//                lists.Add(rowsList);
		//            }
		//            listsRoot.Add(lists);
		//        }

		//        string logPath = $"D:\\Ahmed Shaikoun\\TFS Projects\\MersalAccountingSystem\\Version 1.0.0\\Documents\\Initialization Data\\log.txt";

		//        using (FileStream fs = new FileStream(logPath, FileMode.Create, FileAccess.ReadWrite))
		//        {
		//            using (StreamWriter sw = new StreamWriter(fs))
		//            {
		//                sw.WriteLine("excluded:");
		//                sw.WriteLine("---------");
		//                for (int i = 0; i < excluded.Count; i++)
		//                {
		//                    sw.WriteLine(excluded[i]);
		//                }
		//                sw.WriteLine();
		//                sw.WriteLine();
		//                sw.WriteLine("Whole File");
		//                sw.WriteLine("-----------");
		//                for (int i = 0; i < listsRoot[0][0].Count; i++)
		//                {
		//                    sw.WriteLine(listsRoot[0][0][i]);
		//                }

		//            }
		//        }
		//        WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
		//        SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();
		//        List<string> rows = new List<string>();
		//        foreach (Row r in sheetData.Elements<Row>())
		//        {
		//            var x = r.Elements<Cell>().Count();
		//            string row = "";
		//            foreach (Cell c in r.Elements<Cell>())
		//            {
		//                row += c?.CellValue?.Text + " ";
		//                //Console.Write(text + " ");
		//            }
		//            rows.Add(row);

		//        }
		//        Console.WriteLine();
		//        Console.ReadKey();
		//    }
		//}







		public AccountChartLevelSettingViewModel GetAccountLevel(string code, AccountChartSettingViewModel accountChartSetting, bool throwLevelException = false)
		{
			var level = accountChartSetting.AccountChartLevelSettings.FirstOrDefault(x => x.TotalLength == code.Length);

			if (level == null && throwLevelException)
				throw new GeneralException((int)ErrorCodeEnum.InvalidAccountLevel);

			return level;
		}

		public AccountChartLevelSettingViewModel GetAccountLevel(string code, bool throwLevelException)
		{
			var setting = this._AccountChartSettingRepository.Get(null).FirstOrDefault().ToModel();
			return this.GetAccountLevel(code, setting, throwLevelException);
		}

		//Validate Account Code And Get Account Id
		public long CheckAccountCodeValidatyAndExsistanse(string code)
		{
			ConditionFilter<AccountChart, long> conditionFilter = new ConditionFilter<AccountChart, long>
			{
				Query = (x => x.FullCode == code)
			};
			var existEntity = this._AccountChartsRepository.Get(conditionFilter).FirstOrDefault();

			if (existEntity != null)
			{
				return existEntity.Id;
			}
			else
			{
				var level = this.GetAccountLevel(code, true);
				var parentId = this.GetParentid(code, true);

				this.ThrowExceptionIfParentAccountNotIsSubAccount(parentId);

				return 0;
			}
		}
		public void ThrowExceptionIfParentAccountNotIsSubAccount(long parentId)
		{
			if (parentId != 0)
			{
				var parentAccount = this._AccountChartsRepository.Get(parentId);
				if (parentAccount?.AccountTypeId != null && parentAccount?.AccountTypeId.Value == (int)AccountTypeEnum.Sub)
				{
					throw new GeneralException((int)ErrorCodeEnum.ParentAccountNotIsSubAccount);
				}
			}
		}
		public long GetAccountChartId(string code)
		{
			ConditionFilter<AccountChart, long> condition = new ConditionFilter<AccountChart, long>
			{
				Query = x => x.Code == code
			};
			var AccountChart = _AccountChartsRepository.Get(condition).FirstOrDefault();

			if (AccountChart == null)
				return 0;
			else
				return AccountChart.Id;
		}

		//used for get last child account code from parent to create
		public string GetLastCodePart(string code, bool throwException = false)
		{
			var accountChartSetting = _AccountChartSettingRepository.Get().FirstOrDefault().ToModel();
			var level = this.GetAccountLevel(code, accountChartSetting, throwException);
			string result = code;

			if (level != null)
			{
				if (level.Level > 1)
				{
					var previousLevel = accountChartSetting.AccountChartLevelSettings.FirstOrDefault(x => x.Level == (level.Level - 1));
					result = code.Substring(previousLevel.TotalLength);
				}
			}
			else if (throwException)
			{
				throw new GeneralException((int)ErrorCodeEnum.InvalidAccountLevel);
			}

			return result;
		}

		public long GetParentid(string code, bool throwLevelException = false)
		{
			var accountChartSetting = _AccountChartSettingRepository.Get().FirstOrDefault().ToModel();
			var level = this.GetAccountLevel(code, accountChartSetting, throwLevelException);
			long accountId = 0;

			if (level != null)
			{
				string parentAccountFullCode = code;
				if (level.Level > 1)
				{
					var previousLevel = accountChartSetting.AccountChartLevelSettings.FirstOrDefault(x => x.Level == (level.Level - 1));
					parentAccountFullCode = code.Substring(0, previousLevel.TotalLength);

					ConditionFilter<AccountChart, long> condition = new ConditionFilter<AccountChart, long>
					{
						Query = (x => x.FullCode == parentAccountFullCode)
					};
					var account = this._AccountChartsRepository.Get(condition).FirstOrDefault();

					if (account != null)
					{
						accountId = account.Id;
					}
					else if (throwLevelException)
					{
						throw new GeneralException((int)ErrorCodeEnum.ParentAccountNotExist);
					}
				}
			}
			else if (throwLevelException)
			{
				throw new GeneralException((int)ErrorCodeEnum.InvalidAccountLevel);
			}

			return accountId;


			#region By Ahmed Amer - invalid code
			//int startIndex = 0;
			//int lastlength = 0;
			//var AccountChartSetting = _AccountChartSettingRepository.Get().FirstOrDefault();
			//var AccountChartLevels = AccountChartSetting.AccountChartLevelSettings.OrderBy(x => x.Level);
			//string subCode = "";
			//int Codelevels = 0;
			////check code validaty
			//foreach (AccountChartLevelSetting level in AccountChartLevels)
			//{
			//    try
			//    {
			//        subCode = code.Substring(startIndex, level.Length);
			//        lastlength = level.Length;
			//        Codelevels++;
			//    }
			//    catch (Exception ex)
			//    {
			//        break;
			//    };
			//    if (subCode.Length != AccountChartLevels.FirstOrDefault(x => x.Level == level.Level).Length)
			//    {
			//        //invalid Account Code
			//        throw new GeneralException(403);
			//    }
			//    startIndex += level.Length;
			//    //startIndex = code.LastIndexOf(subCode.Last());
			//    //startIndex = code.LastIndexOf(subCode.Last()) + 1;

			//}
			//if (Codelevels > 1)
			//{
			//    var parentlevel = Codelevels - 1; //
			//    var beforeparentLevelLength = AccountChartLevels.Where(x => x.Level < parentlevel).Sum(x => x.Length);
			//    var Trimedparentandchildcode = code.Remove(0, beforeparentLevelLength);
			//    var parentlevelLength = AccountChartLevels.FirstOrDefault(x => x.Level == parentlevel).Length;
			//    var parentCode = Trimedparentandchildcode.Substring(0, parentlevelLength);
			//    return GetAccountChartId(parentCode);

			//}
			//return 0; 
			#endregion
		}







		/// <summary>
		/// Throw an exception if name is exist.
		/// </summary>
		/// <param name="model">AccountChart view model</param>
		public void ThrowExceptionIfExist(AccountChartViewModel model)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<AccountChart, long> condition = new ConditionFilter<AccountChart, long>
			{
				Query = (entity =>
					entity.AccountType.Name == model.Name &&
					entity.Id != model.Id && entity.Language == lang)
			};
			var existEntity = this._AccountChartsRepository.Get(condition).FirstOrDefault();

			if (existEntity != null)
				throw new ItemAlreadyExistException(112);
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of AccountChartViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<AccountChartViewModel> Get(ConditionFilter<AccountChart, long> condition)
		{
			if (condition == null)
			{
				var lang = this._languageService.CurrentLanguage;
				condition = new ConditionFilter<AccountChart, long>();
				condition.Query = x => x.ParentKeyAccountChart.ParentAccountChartId == null && x.Language == lang;
			}

			var entityCollection = this._AccountChartsRepository.Get(condition).ToList();
			entityCollection.Sort(new GenericComparer<AccountChart>());

			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<AccountChartViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of AccountChartViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<AccountChartLightViewModel> GetLightModel(ConditionFilter<AccountChart, long> condition)
		{
			var entityCollection = this._AccountChartsRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<AccountChartLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of AccountChartViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<AccountChartLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<AccountChart, long> condition = new ConditionFilter<AccountChart, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				Query = (item =>
					item.Language == lang)
			};
			var entityCollection = this._AccountChartsRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<AccountChartLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of AccountChartViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<AccountChartLightViewModel> Get()
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<AccountChart, long> condition = new ConditionFilter<AccountChart, long>
			{
				Query = (item =>
					item.Language == lang && item.ParentKeyAccountChart.ParentAccountChart == null)
			};
			var entityCollection = this._AccountChartsRepository.Get(condition).ToList();

			var modifiedCollection = new List<AccountChart>();

			var modelCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			foreach (var acc in modelCollection)
			{
				acc.Code = acc.FullCode;// GetAccountChartFullCode(acc.Id);
				acc.Name = $"{acc.Code} - {acc.Name}";
			}
			modelCollection.Sort(new GenericComparer<AccountChartLightViewModel>());

			var result = new GenericCollectionViewModel<AccountChartLightViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
			};

			return result;
		}

		/// <summary>
		/// Gets a AccountChartViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<AccountChartLightViewModel> GetByid(long id)
		{
			var lang = this._languageService.CurrentLanguage;

			ConditionFilter<AccountChart, long> condition = new ConditionFilter<AccountChart, long>
			{
				Query = (item => item.Language == lang && item.ParentKeyAccountChart.ParentAccountChartId == id)
			};
			var entityCollection = this._AccountChartsRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();

			dtoCollection.Sort(new GenericComparer<AccountChartLightViewModel>());
			foreach (var acc in dtoCollection)
			{
				acc.Code = acc.FullCode;// GetAccountChartFullCode(acc.Id);
				acc.Name = $"{acc.Code} - {acc.Name}";
			}
			var result = new GenericCollectionViewModel<AccountChartLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
			};

			return result;
		}


		/// <summary>
		/// Gets a AccountChartViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public AddAccountChartViewModel GetDetails(long id)
		{

			ConditionFilter<AccountChart, long> condition = new ConditionFilter<AccountChart, long>
			{
				Query = (x => x.Id == id)
			};
			AccountChart entity = this._AccountChartsRepository.Get(condition).FirstOrDefault();
			AddAccountChartViewModel dto = entity.ToAddModel();

			dto.Code = dto.FullCode;// GetAccountChartFullCode(dto.Id);
			return dto;
		}

		/// <summary>
		/// Gets a AccChart Light ViewModel Lookup .
		/// </summary>
		/// <returns></returns>
		public List<AccountChartLightViewModel> GetLookUp()
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<AccountChart, long> condition = new ConditionFilter<AccountChart, long>
			{
				Query = (item =>
					item.Language == lang &&
					item.ParentKeyAccountChartId.HasValue &&
					item.ParentKeyAccountChart.AccountTypeId.Value == (int)AccountTypeEnum.Sub)
			};
			var list = this._AccountChartsRepository.Get(condition).ToList();
			var result = list.Select(item => item.ToLightModel()).ToList();
			return result;

			//var lang = this._languageService.CurrentLanguage;
			//ConditionFilter<AccountChart, long> condition = new ConditionFilter<AccountChart, long>
			//{
			//    Query = (item =>
			//        item.Language == lang)
			//};
			//List<AccountChart> ChildsAccountChartsList = new List<AccountChart>();
			//var entity = this._AccountChartsRepository.Get(condition).ToList();
			//foreach (var accountChart in entity.ToList())
			//{
			//    if (accountChart.ParentKeyAccountChart.ChildAccountCharts != null && accountChart.ParentKeyAccountChart.ChildAccountCharts.Count != 0)
			//    {
			//        ChildsAccountChartsList.AddRange(GetChilds(accountChart.Id));
			//    }
			//    else
			//    {
			//        if (accountChart.ParentKeyAccountChart.ParentAccountChart == null)
			//        {
			//            ChildsAccountChartsList.Add(accountChart);
			//        }
			//    }
			//}

			////var model = entity.ToModel();
			//var modelCollection = ChildsAccountChartsList.Select(e => e.ToLightModel()).ToList();

			////this section itrate over mapped collection to assign Full Code assigning Full Code With Name
			//foreach (var model in modelCollection)
			//{
			//    model.Name = model.Name + "-" + GetAccountChartFullCode(model.Id);
			//}
			//return modelCollection;
		}

		//recursion Method for Going in depth of nodes to get childs
		public List<AccountChart> GetChilds(long id)
		{
			List<AccountChart> ListNodeChild = new List<AccountChart>();
			ConditionFilter<AccountChart, long> condition = new ConditionFilter<AccountChart, long>
			{
				Query = (item =>
					item.Id == id)
			};
			var Accounchart = _AccountChartsRepository.Get(condition).FirstOrDefault();
			foreach (var Acc in Accounchart.ParentKeyAccountChart.ChildAccountCharts)
			{

				if (Acc.ChildAccountCharts != null && Acc.ChildAccountCharts.Count != 0)
				{
					GetChilds(Acc.ChildTranslatedAccountCharts.FirstOrDefault().Id);
				}
				else
				{
					var lang = this._languageService.CurrentLanguage;

					Acc.Name = Acc.ChildTranslatedAccountCharts.FirstOrDefault(x => x.Language == lang).Name;
					ListNodeChild.Add(Acc);
				}
			}
			var ListNodesChilds = ListNodeChild;
			//ListNodeChild.Clear();
			return ListNodesChilds;
		}

        public IList<AccountChartLightViewModel> GetAllUnSelectedAccountChartsForSafe(long safeId)
        {
            var lang = this._languageService.CurrentLanguage;
            IList<AccountChartLightViewModel> result = null;
            var list = this._safeAccountChartsRepository.Get(null).Where(x => x.SafeId == safeId);

            if (list.Count() > 0)
            {
                var entityColection = this._AccountChartsRepository.Get().Where(x =>
                  x.Language == lang &&
                  x.ParentKeyAccountChartId.HasValue &&
                  x.ParentKeyAccountChart.SafeAccountCharts.FirstOrDefault(y => y.SafeId == safeId) == null
                  //list.Any(item => x.ParentKeyPermissionId != item.PermissionId)
                  ).ToList();

                var modelCollection = entityColection.Select(x => x.ToLightModel()).ToList();
                result = modelCollection;
            }
            else
            {
                var entityColection = this._AccountChartsRepository.Get().Where(x =>
                    x.Language == lang &&
                    x.ParentKeyAccountChartId.HasValue).ToList();

                var modelCollection = entityColection.Select(x => x.ToLightModel()).ToList();
                result = modelCollection;
            }

            return result;
        }

        /// <summary>
        /// Add entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public IList<AccountChartViewModel> Add(IEnumerable<AccountChartViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._AccountChartsRepository.Add(entityCollection).ToList();

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
		public AddAccountChartViewModel Add(AddAccountChartViewModel model, bool isImported = false)
		{
			AccountChart entity = model.ToEntity();
			entity.FullCode = entity.Code;
			if (isImported)
				entity.AccountTypeId = (int)AccountTypeEnum.Sub;
			//entity = this._AccountChartsRepository.Add(entity);
			var existAccount = this._AccountChartsRepository.Get().Where(x => x.FullCode == entity.FullCode).FirstOrDefault();
			if (existAccount != null && isImported == false)
			{
				throw new GeneralException((int)ErrorCodeEnum.CodeAlreadyExist);
			}
			entity.AccountLevel = this.GetAccountLevel(code: entity.Code, throwLevelException: !isImported).Level;
			var parentId = GetParentid(model.Code, true);
			if (isImported == false)
			{
				this.ThrowExceptionIfParentAccountNotIsSubAccount(parentId);
			}
			else
			{
				var acc = this._AccountChartsRepository.Get().FirstOrDefault(x => x.Id == parentId);
				if (acc != null)
				{
					if (acc.AccountTypeId == (int)AccountTypeEnum.Sub)
					{
						acc.AccountTypeId = (int)AccountTypeEnum.Main;
						this._AccountChartsRepository.Update(acc);
						//  this._unitOfWork.Commit();
					}
				}

			}
			//call method to generate Account Code and determine Account Level
			entity.Code = GetLastCodePart(model.Code, true);
			if (parentId != 0)
			{
				entity.ParentAccountChartId = parentId;

			}

			if (entity.IsDebt.HasValue)
			{
				if (entity.IsDebt == false)
					entity.CurrentCreditBalance = entity.OpeningCredit;
				else
					entity.CurrentDebitBalance = entity.OpeningCredit;
			}

			#region By Ahmed Amer - invalid code
			//GetLevel(entity.ParentAccountChartId);
			//entity.AccountLevel = level + 1;

			//entity.Language = 0; 
			#endregion

			#region translation 
			AccountChart AccChartAR = new AccountChart();
			AccChartAR.Language = Framework.Common.Enums.Language.Arabic;
			AccChartAR.CreationDate = DateTime.Now;
			AccChartAR.Name = model.NameAR;
			AccChartAR.Description = model.DescriptionAr;

			AccountChart AccCharEn = new AccountChart();
			AccCharEn.Language = Framework.Common.Enums.Language.English;
			AccCharEn.CreationDate = DateTime.Now;
			AccCharEn.Name = model.NameEN;
			AccCharEn.Description = model.DescriptionEn;

			entity.ChildTranslatedAccountCharts.Add(AccChartAR);
			entity.ChildTranslatedAccountCharts.Add(AccCharEn);
			#endregion

			this._AccountChartsRepository.Add(entity);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion

			model.Id = entity.Id;
			model.Code = entity.FullCode; //GetAccountChartFullCode(entity.Id);
			return model;
		}


		public int Add(IList<AccountChartFormDTO> atos)
		{
			int addedEntities = 0;
			List<AccountChartViewModel> accountChartViewModel = new List<AccountChartViewModel>();
			List<Currency> currencies = new List<Currency>();

			foreach (var viewModel in atos)
			{
				AddAccountChartViewModel model = new AddAccountChartViewModel
				{
					Code = viewModel.FullCode,
					FullCode = viewModel.FullCode,
					NameAR = viewModel.NameAr,
					NameEN = viewModel.NamrEn,
					DescriptionAr = viewModel.DescriptionAr,
					DescriptionEn = viewModel.DescriptionEn,
                    CategoryId = 4,
                    GroupId = 1
                };

				Currency currency = currencies.Where(x => x.Name == viewModel.Currency).FirstOrDefault();
				if (currency == null)
				{
					currency = this._currencysRepository.Get(null).Where(x =>
										x.Name == viewModel.Currency)
										.FirstOrDefault();

					currencies.Add(currency);
				}

				model.CurrencyId = currency.ParentKeyCurrency.Id;

				this.Add(model, true);

				addedEntities++;
			}

			return addedEntities;


			#region Bu Sherif
			//int addedEntities = 0;

			//if (atos != null)
			//{
			//	//bool needCommit = false;
			//	IList<AccountChart> accountChartList = new List<AccountChart>();

			//	for (int i = 0; i < atos.Count; i++)
			//	{
			//		var accountChart = atos[i];
			//		var existCurrency = this._currencysRepository.Get(null).Where(x =>
			//			x.Name == accountChart.Currency)
			//			.FirstOrDefault();

			//		var existBranch = this._branchsRepository.Get(null).Where(x =>
			//			x.Name == accountChart.Branch)
			//			.FirstOrDefault();

			//		if (existCurrency == null || existBranch == null)
			//		{
			//			// Do nothing for now;
			//		}
			//		else
			//		{
			//			AccountChart existAccountChart = this._AccountChartsRepository.Get().FirstOrDefault(x => x.FullCode == accountChart.FullCode);
			//			if (existAccountChart == null)
			//			{
			//				AccountChart entity = new AccountChart
			//				{
			//					CurrencyId = existCurrency.ParentKeyCurrency.Id,
			//					//BranchId = existBranch.ParentKeyBranch.Id,
			//					FullCode = accountChart.FullCode
			//				};
			//				entity = this._AccountChartsRepository.Add(entity);
			//				AccountChart entityAr = new AccountChart
			//				{
			//					Name = accountChart.NameAr,
			//					Description = accountChart.DescriptionAr,
			//					Language = Language.Arabic,
			//					ParentKeyAccountChart = entity
			//				};
			//				entityAr = this._AccountChartsRepository.Add(entityAr);
			//				entity.ChildTranslatedAccountCharts.Add(entityAr);

			//				AccountChart entityEn = new AccountChart
			//				{
			//					Name = accountChart.NamrEn,
			//					Description = accountChart.DescriptionEn,
			//					Language = Language.English,
			//					ParentKeyAccountChart = entity
			//				};
			//				entityEn = this._AccountChartsRepository.Add(entityEn);
			//				entity.ChildAccountCharts.Add(entityEn);

			//				accountChartList.Add(entity);
			//			}
			//			else
			//			{
			//				existAccountChart.CurrencyId = existCurrency.ParentKeyCurrency.Id;
			//				existAccountChart.BranchId = existBranch.ParentKeyBranch.Id;
			//				existAccountChart.FullCode = accountChart.FullCode;

			//				existAccountChart = this._AccountChartsRepository.Update(existAccountChart);
			//				AccountChart entityAr = existAccountChart.ChildTranslatedAccountCharts.FirstOrDefault(x => x.Language == Language.Arabic);

			//				entityAr.Name = accountChart.NameAr;
			//				entityAr.Description = accountChart.DescriptionAr;
			//				entityAr.Language = Language.Arabic;
			//				entityAr.ParentKeyAccountChart = existAccountChart;

			//				entityAr = this._AccountChartsRepository.Update(entityAr);


			//				AccountChart entityEn = existAccountChart.ChildTranslatedAccountCharts.FirstOrDefault(x => x.Language == Language.English);

			//				entityEn.Name = accountChart.NamrEn;
			//				entityEn.Description = accountChart.DescriptionEn;
			//				entityEn.Language = Language.English;

			//				entityEn = this._AccountChartsRepository.Update(entityEn);
			//				//entity.ChildAccountCharts.Add(entityEn);

			//				accountChartList.Add(existAccountChart);
			//			}

			//			#region Commit Changes
			//			this._unitOfWork.Commit();
			//			#endregion


			//			addedEntities++;
			//		}
			//	}

			//	if (accountChartList.Count > 0)
			//	{

			//	}
			//}

			//return addedEntities; 
			#endregion
		}

		/// <summary>
		/// Update entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		public IList<AccountChartViewModel> Update(IEnumerable<AccountChartViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._AccountChartsRepository.Update(entityCollection).ToList();

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
		public AddAccountChartViewModel Update(AddAccountChartViewModel model)
		{
			//this.ThrowExceptionIfExist(model);

			var entity = this._AccountChartsRepository.Get(model.Id);

			entity.IsDebt = model.IsDebt;
			entity.OpeningCredit = model.OpeningCredit;
            entity.CurrencyId = model.CurrencyId;

			entity = this._AccountChartsRepository.Update(entity);

			var childs = this._AccountChartsRepository.Get(null).Where(x => x.ParentKeyAccountChartId == model.Id);

			if (childs.Count() > 0)
			{
				var ar = childs.FirstOrDefault(x => x.Language == Language.Arabic);
				ar.Name = model.NameAR;
				ar.Description = model.DescriptionAr;
				this._AccountChartsRepository.Update(ar);

				var en = childs.FirstOrDefault(x => x.Language == Language.English);
				en.Name = model.NameEN;
				en.Description = model.DescriptionEn;
				this._AccountChartsRepository.Update(en);
			}

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion

			model = entity.ToAddModel();
			return model;
		}

		/// <summary>
		/// Delete entities.
		/// </summary>
		/// <param name="collection"></param>
		public void Delete(IEnumerable<AccountChartViewModel> collection)
		{
			var entityCollection = collection.Select(model => model.ToEntity());
			this._AccountChartsRepository.Delete(entityCollection);

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
			this._AccountChartsRepository.Delete(collection);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		public void Delete(AccountChartViewModel model)
		{
			var entity = model.ToEntity();
			this._AccountChartsRepository.Delete(entity);

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
			var result = this._AccountChartsRepository.Delete(id);

			if (result == 0)
				throw new ItemNotFoundException();

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		#endregion
	}
}
