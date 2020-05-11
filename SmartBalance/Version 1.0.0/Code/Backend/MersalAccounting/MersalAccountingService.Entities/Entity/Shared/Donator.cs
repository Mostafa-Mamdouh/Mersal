#region Using ...
using Framework.Common.Enums;
using Framework.Common.Interfaces;
using MersalAccountingService.Common.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Entities.Entity
{
	/// <summary>
	/// 
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	public class Donator : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		///  Donator.
		/// </summary>
		public Donator()
		{
			//this.DonatorProducts = new HashSet<DonatorProduct>();
			this.SalesBills = new HashSet<SalesBill>();
			this.PaymentMovments = new HashSet<PaymentMovment>();
            this.DonationDonators = new HashSet<DonationDonator>();
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
		//public virtual ICollection<DonatorProduct> DonatorProducts { get; set; }
		public virtual ICollection<SalesBill> SalesBills { get; set; }
		public virtual ICollection<PaymentMovment> PaymentMovments { get; set; }
        public virtual ICollection<DonationDonator> DonationDonators { get; set; }

        #endregion
    }
}
