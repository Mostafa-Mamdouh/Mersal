#region Using ...
using Framework.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Framework.Core.Common
{
    /// <summary>
    /// Specify a functionality to 
    /// log any thing in a log.
    /// </summary>
    public interface ILoggerService
    {
        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="type"></param>
        void Log(string content, LogType type);
        #endregion
    }
}
