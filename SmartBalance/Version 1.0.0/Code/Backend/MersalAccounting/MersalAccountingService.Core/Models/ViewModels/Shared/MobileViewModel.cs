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
	public class MobileViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type MobileViewModel.
        /// </summary>
        public MobileViewModel()
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
		public string Number { get; set; }
		public bool IsMain { get; set; }
		public string ObjectType { get; set; }
		public long ObjectId { get; set; }
		public bool IsActive { get; set; }
		public Nullable<long> CountryCallingCodeId { get; set; }
		public virtual CountryCallingCodeViewModel CountryCallingCode { get; set; }



		#region Translation Functionality
		public Language? Language { get; set; }

        public long? ParentKeyMobileId { get; set; }
        public MobileViewModel ParentKeyMobile { get; set; }


        public IList<MobileViewModel> ChildTranslatedMobiles { get; set; }
        #endregion

        #endregion
    }
}
