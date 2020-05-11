#region Using ...
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using MersalAccountingService.Common.Enums;
using MersalAccountingService.Common.Exceptions;
using MersalAccountingService.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
#endregion

namespace MersalAccountingService.BusinessLogic.Services
{
    public class ExcelService
    {
        #region Data Members
        private readonly IDTO _dTO;
        #endregion

        #region Constructors
        public ExcelService(IDTO dTO)
        {
            _dTO = dTO;
        }
        #endregion

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
            List<IDTO> result = new List<IDTO>();
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

                            IDTO form = _dTO;
                            var cells = r.Elements<Cell>();
                            var count = cells.Count();
                            if (count == form.PropertyCont)
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

                                form.Map(cellText, cellCounter);
                            }

                            result.Add(form);
                        }
                    }
                }
            }

            if (thereIsValidSheet == false)
            {
                throw new GeneralException((int)ErrorCodeEnum.InvalidDonatorExcelSheet);
            }

            //int addedEntities = this.Add(result);

            return 0;//addedEntities;
        }
    }
}
