#region Using ...
using Framework.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
#endregion

namespace MersalAccountingService.Common.Types
{
    public class ResourceValue
    {
        public ResourceValue(Language lang, string value)
        {
            this.Language = lang;
            this.Value = value;
        }

        public ResourceKey Key { get; set; }
        public string Value { get; set; }
        public Language Language { get; set; }
    }
}
