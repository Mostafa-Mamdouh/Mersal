using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MersalAccountingService.Core.Models.DTOs
{
    public class AccountChartFormDTO
    {
        #region Methods
        public void Map(string propertyValue, int propertyIndex)
        {
            try
            {
                if (string.IsNullOrEmpty(propertyValue) == false && propertyIndex >= 0 && propertyIndex <= 29)
                {
                    switch (propertyIndex)
                    {
                        case 0:
                            {
                                this.FullCode = propertyValue;
                            }
                            break;
                        case 1:
                            {
                                this.NameAr = propertyValue;
                            }
                            break;
                        case 2:
                            {
                                this.NamrEn = propertyValue;
                            }
                            break;
                        case 3:
                            {
                                this.DescriptionAr = propertyValue;
                            }
                            break;
                        case 4:
                            {
                                this.DescriptionEn = propertyValue;
                            }
                            break;
                        case 5:
                            {
                                this.Currency = propertyValue;
                            }
                            break;
                        case 6:
                            {
                                this.Branch = propertyValue;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region Properties
        public string FullCode { get; set; }

        public string NameAr { get; set; }

        public string NamrEn { get; set; }

        public string DescriptionAr { get; set; }

        public string DescriptionEn { get; set; }

        public string Currency { get; set; }

        public string Branch { get; set; }
        #endregion
    }
}
