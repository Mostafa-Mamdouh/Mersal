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
	public class MailViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type MailViewModel.
        /// </summary>
        public MailViewModel()
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
		public bool IsMain { get; set; }
		public string Description { get; set; }
		public bool IsActive { get; set; }
		public bool IsVerified { get; set; }



		#region Translation Functionality
		public Language? Language { get; set; }

        public long? ParentKeyMailId { get; set; }
        public MailViewModel ParentKeyMail { get; set; }


        public IList<MailViewModel> ChildTranslatedMails { get; set; }
        #endregion

        #endregion
    }
}
