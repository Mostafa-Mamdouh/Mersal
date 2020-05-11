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
	[DebuggerDisplay("Id={Id}, Code={Code}, Title={Title}, Date={Date}")]
	public class LocationViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type LocationViewModel.
        /// </summary>
        public LocationViewModel()
        {

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


        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }


		public string TitleAr { get; set; }
		public string TitleEn { get; set; }
		public string DescriptionAr { get; set; }
		public string DescriptionEn { get; set; }

        public long? ParentLocationId { get; set; }

        public string ParentLocationName { get; set; }


        public virtual ICollection<LocationViewModel> ChildLocations { get; set; }



        #region Translation Functionality
        public Language? Language { get; set; }

		public long? ParentKeyLocationId { get; set; }
		public LocationViewModel ParentKeyLocation { get; set; }


		public IList<LocationViewModel> ChildTranslatedLocations { get; set; }
		#endregion

		#endregion
	}
}
