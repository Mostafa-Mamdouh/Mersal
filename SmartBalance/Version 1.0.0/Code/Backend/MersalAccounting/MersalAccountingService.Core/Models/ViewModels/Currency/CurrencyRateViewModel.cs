#region Using ...
using Framework.Common.Enums;
using Framework.Core.Models.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Core.Models.ViewModels
{
	/// <summary>
	/// 
	/// </summary>
	[DebuggerDisplay("Id={Id}")]
	public class CurrencyRateViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type CurrencyRateViewModel.
        /// </summary>
        public CurrencyRateViewModel()
        {

        }
        #endregion        

        #region Properties

        #region IEntityIdentity<T>
        public long Id { get; set; }
        #endregion

        #region IEntityDateTime
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreationDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? FirstModificationDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? LastModificationDate { get; set; }
        #endregion

        //public string Name { get; set; }
        public DateTime? Date { get; set; }
        public decimal Price { get; set; }

        public Nullable<long> CurrencyId { get; set; }
        public virtual CurrencyViewModel Currency { get; set; }


        public Nullable<long> ExchangeCurrencyId { get; set; }
        public virtual CurrencyViewModel ExchangeCurrency { get; set; }



        #region Translation Functionality
        public Language? Language { get; set; }

        public long? ParentKeyCurrencyRateId { get; set; }
        public CurrencyRateViewModel ParentKeyCurrencyRate { get; set; }


        public IList<CurrencyRateViewModel> ChildTranslatedCurrencyRates { get; set; }
        #endregion

        #endregion
    }
}
