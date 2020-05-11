#region Using ...
using Framework.Core.Models.ViewModels.Base;
using MersalAccountingService.Core.Models.ViewModels.Shared;
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
	public class ClosedMonthsFilterViewModel : BaseFilterViewModel
	{
        #region Properties

        #region IEntityIdentity<T>
        public long Id { get; set; }
        #endregion

        #region IEntityDateTimeSignature
        public DateTime CreationDate { get; set; }
        public DateTime? FirstModificationDate { get; set; }
        public DateTime? LastModificationDate { get; set; }
        #endregion

        public byte? Month { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public bool? IsClosed { get; set; }
        public long? ClosedByUserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }       
        #endregion
    }
}
