#region Using ...
using Framework.Common.Enums;
using Framework.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Entities.Entity
{
	/// <summary>
	/// Provides a AccountChartGroup entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 
	 */
	public class AccountChartGroup : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type AccountChartGroup.
		/// </summary>
		public AccountChartGroup()
		{
            this.ChildTranslatedAccountChartGroups = new HashSet<AccountChartGroup>();
            this.AccountCharts = new HashSet<AccountChart>();
			//this.Safes = new HashSet<Safe>();
			//this.GeneralAccounts = new HashSet<GeneralAccount>();
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

		public string Name { get; set; }

        public virtual ICollection<AccountChart> AccountCharts  { get; set; }



        #region Translation Functionality
        public Language? Language { get; set; }

        public long? ParentKeyAccountChartGroupId { get; set; }
        public virtual AccountChartGroup ParentKeyAccountChartGroup { get; set; }

        public virtual ICollection<AccountChartGroup> ChildTranslatedAccountChartGroups { get; set; }
        #endregion

        #endregion
    }
}
