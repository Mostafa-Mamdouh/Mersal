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

namespace MersalAccountingService.Core.Models.ViewModels.LightViewModels
{
	/// <summary>
	/// Provides a lite model for entity 
	/// User, and this lite model 
	/// do not contains a children 
	/// relations for speeding up the 
	/// retrivement process.
	/// </summary>
	[DebuggerDisplay("Id={Id}")]
	public class UserLightViewModel : BaseViewModel
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type UserLightViewModel.
		/// </summary>
		public UserLightViewModel()
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

        public long Value { get; set; }
        public string Name { get; set; }
		public string UserName { get; set; }
		public bool IsActive { get; set; }
		//public string Password { get; set; }
        public GenderEnum? Gender { get; set; }
        public Nullable<DateTime> BirthDate { get; set; }
        public bool IsTopAdmin { get; set; }
        public decimal? MaxPaymentLimit { get; set; }
        public string DefaultPageUrl { get; set; }
        public int? BranchId { get; set; }



        #region Translation Functionality
        public Language? Language { get; set; }

		public long? ParentKeyUserId { get; set; }
		public UserLightViewModel ParentKeyUser { get; set; }		
		#endregion

		#endregion
	}
}
