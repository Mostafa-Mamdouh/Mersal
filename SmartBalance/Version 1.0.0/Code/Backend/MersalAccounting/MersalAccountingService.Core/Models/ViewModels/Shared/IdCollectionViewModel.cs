using System.Collections.Generic;

namespace MersalAccountingService.Core.Models.ViewModels
{
    public class IdCollectionViewModel<T>
    {
        public IList<T> Collection { get; set; }
    }
}
