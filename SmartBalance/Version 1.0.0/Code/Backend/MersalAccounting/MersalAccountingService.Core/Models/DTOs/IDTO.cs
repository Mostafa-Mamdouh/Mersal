using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MersalAccountingService.Core.Models.DTOs
{
    public interface IDTO
    {
        #region Properties
         int PropertyCont { get; }
        #endregion
        #region Methods
        void Map(string propertyValue, int propertyIndex);
        #endregion
    }
}
