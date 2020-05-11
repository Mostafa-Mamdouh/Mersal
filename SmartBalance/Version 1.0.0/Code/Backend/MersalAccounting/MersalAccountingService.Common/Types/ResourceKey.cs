#region Using ...
using MersalAccountingService.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
#endregion

namespace MersalAccountingService.Common.Types
{
    public class ResourceKey
    {
        public ResourceKey(ResourceKeyEnum key)
        {
            this.ResourceValues = new List<ResourceValue>();
            this.Key = key;
        }
        public ResourceKey()
        {
            this.ResourceValues = new List<ResourceValue>();
        }

        public ResourceKeyEnum Key { get; set; }
        public IList<ResourceValue> ResourceValues { get; set; }
    }
}
