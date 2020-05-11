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
	public class CountryViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type CountryViewModel.
        /// </summary>
        public CountryViewModel()
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

		public string Name { get; set; }
		public virtual IList<CityViewModel> Cities { get; set; }
		public string Code { get; set; }
		public virtual IList<CountryCallingCodeViewModel> CountryCallingCodes { get; set; }



		#region Translation Functionality
		public Language? Language { get; set; }

        public long? ParentKeyCountryId { get; set; }
        public CountryViewModel ParentKeyCountry { get; set; }


        public IList<CountryViewModel> ChildTranslatedCountrys { get; set; }
        #endregion

        #endregion
    }
}
