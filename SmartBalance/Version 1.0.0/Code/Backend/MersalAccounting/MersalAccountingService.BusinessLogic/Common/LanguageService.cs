#region Using ...
using Framework.Common.Enums;
using Framework.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
#endregion

namespace MersalAccountingService.BusinessLogic.Common
{
    /// <summary>
    /// Specify a functionality to 
    /// gets the current language.
    /// </summary>
    public class LanguageService : ILanguageService
    {
        #region ILanguageService

        #region Properties
        
        /// <summary>
        /// Gets the current language that used by user.
        /// </summary>
        public Language CurrentLanguage
        {
            get
            {
                Language result = Language.Arabic;
				string langCode = this.CurrentLanguageCode;

                if (string.IsNullOrEmpty(langCode) == false)
                {
                    if (langCode.ToLower() == "en" ||
                        langCode.ToLower().StartsWith("en-"))
                    {
                        result = Language.English;
                    }
                    else if (langCode.ToLower() == "ar" ||
                        langCode.ToLower().StartsWith("ar-"))
                    {
                        result = Language.Arabic;
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// Gets the current language code that used by user.
        /// </summary>
        public string CurrentLanguageCode
        {
            get
            {
                string result = HttpContext.Current.Request.Headers["language-code"];

                return result;
            }
        }
        
        #endregion

        #endregion
    }
}
