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
	public class AddressViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type AddressViewModel.
        /// </summary>
        public AddressViewModel()
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
		public long ObjectId { get; set; }
		public string ObjectType { get; set; }
		public Nullable<long> DistrictId { get; set; }
		public virtual DistrictViewModel District { get; set; }
		public string Street { get; set; }
		public string BuildingNo { get; set; }
		public string Floor { get; set; }
		public string LandMark { get; set; }
		public string Description { get; set; }



		#region Translation Functionality
		public Language? Language { get; set; }

        public long? ParentKeyAddressId { get; set; }
        public AddressViewModel ParentKeyAddress { get; set; }


        public IList<AddressViewModel> ChildTranslatedAddresss { get; set; }
        #endregion

        #endregion
    }
}
