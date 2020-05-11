#region using...
using Framework.Core.Models.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Core.Models.ViewModels
{
    public class DocumentViewModel : BaseViewModel
    {
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

        public int DocumentNumber { get; set; }

        public int CountReceipts { get; set; }

        public int FirstNumber { get; set; }

        #endregion
    }
}
