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
	/// Provides a Currency entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * العملة
	 */
	public class TestamentExtraction : IEntityIdentity<long>, IEntityDateTimeSignature
	{
        #region Data Members

        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type TestamentExtraction.
        /// تصفية العهدة
        /// </summary>
        public TestamentExtraction()
		{
			this.ChildTranslatedTestamentExtractions = new HashSet<TestamentExtraction>();
            this.LiquidationDetails = new HashSet<LiquidationDetail>();
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
		public string Description { get; set; }

        public virtual ICollection<LiquidationDetail> LiquidationDetails { get; set; }

        #region Translation Functionality
        public Language? Language { get; set; }

		public long? ParentKeyTestamentExtractionId { get; set; }
		public virtual TestamentExtraction ParentKeyTestamentExtraction { get; set; }
 
		public virtual ICollection<TestamentExtraction> ChildTranslatedTestamentExtractions { get; set; }
		#endregion

		#endregion
	}
}
