using Framework.Common.Enums;
using Framework.Common.Interfaces;
using MersalAccountingService.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MersalAccountingService.Entities.Entity
{
   public class Customer : IEntityIdentity<long>, IEntityDateTime
    {
        #region Data Members

        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        ///  Customer.
        /// </summary>
        public Customer()
        {

            this.CustomerProducts = new HashSet<CustomerProduct>();
            this.SalesBills = new HashSet<SalesBill>();
            this.Donations = new HashSet<Donation>();
        }
        #endregion
        #region Properties

        #region IEntityIdentity<T>
        public long Id { get; set; }
        #endregion

        #region IEntityDateTime
        public DateTime CreationDate { get; set; }
        public DateTime? FirstModificationDate { get; set; }
        public DateTime? LastModificationDate { get; set; }
        #endregion

        public string Name { get; set; }
        public string Description { get; set; }
        public string NationalId { get; set; }
        //public string Phone { get; set; }
        public long? AccountChartId { get; set; }
        public virtual AccountChart AccountChart { get; set; }
        public ICollection<CustomerProduct> CustomerProducts { get; set; }
        public ICollection<SalesBill> SalesBills { get; set; }
        public ICollection<Donation> Donations { get; set; }

        #endregion
    }
}
