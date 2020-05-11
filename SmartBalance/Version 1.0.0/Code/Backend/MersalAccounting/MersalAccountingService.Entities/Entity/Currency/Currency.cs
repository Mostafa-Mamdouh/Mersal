#region Using ...
using Framework.Common.Enums;
using Framework.Common.Interfaces;
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
	/// Provides a Currency entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * العملة
	 */
	public class Currency : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type Currency.
		/// </summary>
		public Currency()
		{
			this.ChildTranslatedCurrencys = new HashSet<Currency>();
            this.Donations = new HashSet<Donation>();
            this.PaymentMovments = new HashSet<PaymentMovment>();
            this.CurrencyRates = new HashSet<CurrencyRate>();
            this.AccountCharts = new HashSet<AccountChart>();
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
		public string Code { get; set; }
		public string Description { get; set; }
		public string Symbol { get; set; }

        public DateTime? Date { get; set; }

        public virtual ICollection<Donation> Donations { get; set; }
        public virtual ICollection<PaymentMovment> PaymentMovments { get; set; }
        public virtual ICollection<CurrencyRate> CurrencyRates { get; set; }        
        public virtual ICollection<AccountChart> AccountCharts { get; set; }


        #region Translation Functionality
        public Language? Language { get; set; }

		public long? ParentKeyCurrencyId { get; set; }
		public virtual Currency ParentKeyCurrency { get; set; }

 
		public virtual ICollection<Currency> ChildTranslatedCurrencys { get; set; }
		#endregion

		#endregion
	}
}
