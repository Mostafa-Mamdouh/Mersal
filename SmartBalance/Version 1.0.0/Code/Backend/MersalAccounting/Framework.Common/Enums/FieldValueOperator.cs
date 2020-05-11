#region Using ...
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Framework.Common.Enums
{
    /// <summary>
    /// 
    /// </summary>
    public enum FieldValueOperator : byte
    {
        /// <summary>
        /// 
        /// </summary>
        Equal = 0,
        /// <summary>
        /// 
        /// </summary>
        NotEqual,
        /// <summary>
        /// 
        /// </summary>
        Contain,
        /// <summary>
        /// 
        /// </summary>
        NotContain,
        /// <summary>
        /// 
        /// </summary>
        StartWith,
        /// <summary>
        /// 
        /// </summary>
        NotStartWith,
        /// <summary>
        /// 
        /// </summary>
        EndWith,
        /// <summary>
        /// 
        /// </summary>
        NotEndWith,
        /// <summary>
        /// 
        /// </summary>
        GreaterThan,
        /// <summary>
        /// 
        /// </summary>
        GreaterThanOrEqual,
        /// <summary>
        /// 
        /// </summary>
        LessThan,
        /// <summary>
        /// 
        /// </summary>
        LessThanOrEqual
    }
}
