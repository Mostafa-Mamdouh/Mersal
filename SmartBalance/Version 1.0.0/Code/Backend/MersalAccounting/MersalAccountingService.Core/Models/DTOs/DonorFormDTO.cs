#region Using ...
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Core.Models.DTOs
{
    public class DonorFormDTO : IDTO
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
                                this.Timestamp = DateTime.Parse(propertyValue);
                            }
                            break;
                        case 1:
                            {
                                this.Email = propertyValue;
                            }
                            break;
                        case 2:
                            {
                                this.Agent = propertyValue;
                            }
                            break;
                        case 3:
                            {
                                this.CallType = propertyValue;
                            }
                            break;
                        case 4:
                            {
                                this.IsDonor = bool.Parse(propertyValue);
                            }
                            break;
                        case 5:
                            {
                                this.Type = (propertyValue);
                            }
                            break;
                        case 6:
                            {
                                this.Name = (propertyValue);
                            }
                            break;
                        case 7:
                            {
                                this.Phone1 = (propertyValue);
                            }
                            break;
                        case 8:
                            {
                                this.Phone2 = (propertyValue);
                            }
                            break;
                        case 9:
                            {
                                this.Phone3 = (propertyValue);
                            }
                            break;
                        case 10:
                            {
                                this.AgeArea = (propertyValue);
                            }
                            break;
                        case 11:
                            {
                                this.City = (propertyValue);
                            }
                            break;
                        case 12:
                            {
                                this.Address1 = (propertyValue);
                            }
                            break;
                        case 13:
                            {
                                this.Address2 = (propertyValue);
                            }
                            break;
                        case 14:
                            {
                                this.Address3 = (propertyValue);
                            }
                            break;
                        case 15:
                            {
                                this.AddressType = (propertyValue);
                            }
                            break;
                        case 16:
                            {
                                this.NeedCar = bool.Parse(propertyValue);
                            }
                            break;
                        case 17:
                            {
                                this.Area = (propertyValue);
                            }
                            break;
                        case 18:
                            {
                                this.Amount = decimal.Parse(propertyValue);
                            }
                            break;
                        case 19:
                            {
                                this.Currency = (propertyValue);
                            }
                            break;
                        case 20:
                            {
                                this.IsObjectDonation = bool.Parse(propertyValue);
                            }
                            break;
                        case 21:
                            {
                                this.DonationType = (propertyValue);
                            }
                            break;
                        case 22:
                            {
                                this.DonationSpecification = (propertyValue);
                            }
                            break;
                        case 23:
                            {
                                this.Comment = (propertyValue);
                            }
                            break;
                        case 24:
                            {
                                this.NeedCall = bool.Parse(propertyValue);
                            }
                            break;
                        case 25:
                            {
                                this.DonationDate = DateTime.Parse(propertyValue);
                            }
                            break;
                        case 26:
                            {
                                this.DonationTime = TimeSpan.Parse(propertyValue);
                            }
                            break;
                        case 27:
                            {
                                this.DonationPerioud = TimeSpan.Parse(propertyValue);
                            }
                            break;
                        case 28:
                            {
                                this.HowKnowsMersal = (propertyValue);
                            }
                            break;
                        case 29:
                            {
                                this.NeedReconnectionToKnowMore = bool.Parse(propertyValue);
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
        public DateTime? Timestamp { get; set; }
        public string Email { get; set; }
        public string Agent { get; set; }
        public string CallType { get; set; }
        public bool? IsDonor { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        public string AgeArea { get; set; }
        public string City { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string AddressType { get; set; }
        public bool? NeedCar { get; set; }
        public string Area { get; set; }
        public decimal? Amount { get; set; }
        public string Currency { get; set; }
        public bool? IsObjectDonation { get; set; }
        public string DonationType { get; set; }
        public string DonationSpecification { get; set; }
        public string Comment { get; set; }
        public bool? NeedCall { get; set; }
        public DateTime? DonationDate { get; set; }
        public TimeSpan? DonationTime { get; set; }
        public TimeSpan? DonationPerioud { get; set; }
        public string HowKnowsMersal { get; set; }
        public bool? NeedReconnectionToKnowMore { get; set; }
        public int PropertyCont { get => 30; }
        #endregion
    }
}
