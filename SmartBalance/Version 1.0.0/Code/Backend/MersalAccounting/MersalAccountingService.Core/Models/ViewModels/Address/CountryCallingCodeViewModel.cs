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
	public class CountryCallingCodeViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type CountryCallingCodeViewModel.
        /// </summary>
        public CountryCallingCodeViewModel()
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
		public Nullable<long> CountryId { get; set; }
		public virtual CountryViewModel Country { get; set; }
		public virtual IList<MobileViewModel> Mobiles { get; set; }
		public string Code { get; set; }



		#region Translation Functionality
		public Language? Language { get; set; }

        public long? ParentKeyCountryCallingCodeId { get; set; }
        public CountryCallingCodeViewModel ParentKeyCountryCallingCode { get; set; }


        public IList<CountryCallingCodeViewModel> ChildTranslatedCountryCallingCodes { get; set; }
        #endregion

        #endregion
    }
}
