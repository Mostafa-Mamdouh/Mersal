#region Using ...
using Framework.Common.Enums;
using Framework.Common.Interfaces;
using MersalAccountingService.Common.Interfaces;
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
	/// 
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	public class Testament : IEntityIdentity<long>, IEntityDateTimeSignature, IPostingSignature
    {
        #region Constructors
		/// <summary>
		/// 
		/// </summary>
        public Testament()
        {
            this.ChildTranslatedCustodies = new HashSet<Testament>();
            this.Advances = new HashSet<Advance>();
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

        #region IPostingSignature
        public bool IsPosted { get; set; }
        public DateTime? PostingDate { get; set; }
        public long? PostedByUserId { get; set; }
        #endregion

        public string Code { get; set; }

        public DateTime? Date { get; set; }

        public decimal? TotalValue { get; set; }

        public string Description { get; set; }

        public int? AdvancesTypeId { get; set; }
        public virtual AdvancesType AdvancesType { get; set; }

        public long? VendorId { get; set; }
        public virtual Vendor Vendor { get; set; }

        public virtual ICollection<Advance> Advances { get; set; }

        #region Translation Functionality
        public Language? Language { get; set; }

        public long? ParentKeyTestamentId { get; set; }
        public virtual Testament ParentKeyTestament { get; set; }


        public virtual ICollection<Testament> ChildTranslatedCustodies { get; set; }
        #endregion

        #endregion
    }
}
