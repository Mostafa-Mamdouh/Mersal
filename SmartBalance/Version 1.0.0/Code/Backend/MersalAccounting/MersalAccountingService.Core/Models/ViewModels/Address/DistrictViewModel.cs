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
	public class DistrictViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type DistrictViewModel.
        /// </summary>
        public DistrictViewModel()
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
		public virtual IList<AddressViewModel> Addresses { get; set; }
		public Nullable<long> CityId { get; set; }
		public virtual CityViewModel City { get; set; }
		public string Description { get; set; }



		#region Translation Functionality
		public Language? Language { get; set; }

        public long? ParentKeyDistrictId { get; set; }
        public DistrictViewModel ParentKeyDistrict { get; set; }


        public IList<DistrictViewModel> ChildTranslatedDistricts { get; set; }
        #endregion

        #endregion
    }
}
