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
    /// gets the current language.
    /// </summary>
    public interface ILanguageService
    {
        #region Properties

        /// <summary>
        /// Gets the current language 
        /// that used by user.
        /// </summary>
        Language CurrentLanguage { get; }

        /// <summary>
        /// Gets the current language 
        /// code that used by user.
        /// </summary>
        string CurrentLanguageCode { get; }

        #endregion
    }
}
