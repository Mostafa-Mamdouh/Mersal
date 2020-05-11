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
	public class AssetCategoryViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type AssetCategoryViewModel.
        /// </summary>
        public AssetCategoryViewModel()
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
		public string Description { get; set; }
		public virtual IList<AssetViewModel> Assets { get; set; }



		#region Translation Functionality
		public Language? Language { get; set; }

        public long? ParentKeyAssetCategoryId { get; set; }
        public AssetCategoryViewModel ParentKeyAssetCategory { get; set; }


        public IList<AssetCategoryViewModel> ChildTranslatedAssetCategorys { get; set; }
        #endregion

        #endregion
    }
}
