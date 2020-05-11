#region Using ...
using Framework.Core.Models.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Framework.Core.Models.DTOs
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TDTO"></typeparam>
    public class GenericCollectionDTO<TDTO> where TDTO : BaseDTO
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type GenericCollectionDTO.
        /// </summary>
        public GenericCollectionDTO()
        {

        }
        /// <summary>
        /// Initializes a new instance of 
        /// type GenericCollectionDTO.
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="totalCount"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        public GenericCollectionDTO(IList<TDTO> collection, long totalCount, int? pageIndex, int? pageSize)
        {
            this.Collection = collection;
            this.TotalCount = totalCount;
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
        }
        #endregion        

        #region Properties
        public IList<TDTO> Collection { get; set; }
        public long TotalCount { get; set; }
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
        #endregion
    }
}
