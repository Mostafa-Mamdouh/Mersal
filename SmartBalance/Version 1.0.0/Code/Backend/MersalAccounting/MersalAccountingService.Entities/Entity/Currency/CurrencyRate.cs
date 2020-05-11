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
	/// Provides a CurrencyRate entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * اسعار العملة
	 */
	public class CurrencyRate : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type CurrencyRate.
		/// </summary>
		public CurrencyRate()
		{
            //this.Currency = new Currency();
            //this.ExchangeCurrency = new Currency();
			this.ChildTranslatedCurrencyRates = new HashSet<CurrencyRate>();
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

		//public string Name { get; set; }
        public DateTime? Date { get; set; }
		public decimal Price { get; set; }

		public long? CurrencyId { get; set; }
		public virtual Currency Currency { get; set; }


        public long? ExchangeCurrencyId { get; set; }
        public virtual Currency ExchangeCurrency { get; set; }


        #region Translation Functionality
        public Language? Language { get; set; }

		public long? ParentKeyCurrencyRateId { get; set; }
		public virtual CurrencyRate ParentKeyCurrencyRate { get; set; }

 
		public virtual ICollection<CurrencyRate> ChildTranslatedCurrencyRates { get; set; }
		#endregion

		#endregion
	}
}
