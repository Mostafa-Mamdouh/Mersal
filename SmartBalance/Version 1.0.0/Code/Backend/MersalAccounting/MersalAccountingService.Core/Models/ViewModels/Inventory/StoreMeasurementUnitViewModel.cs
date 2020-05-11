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
	public class StoreMeasurementUnitViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type StoreMeasurementUnitViewModel.
        /// </summary>
        public StoreMeasurementUnitViewModel()
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



		#region Translation Functionality
		public Language? Language { get; set; }

        public long? ParentKeyStoreMeasurementUnitId { get; set; }
        public StoreMeasurementUnitViewModel ParentKeyStoreMeasurementUnit { get; set; }


        public IList<StoreMeasurementUnitViewModel> ChildTranslatedStoreMeasurementUnits { get; set; }
        #endregion

        #endregion
    }
}
