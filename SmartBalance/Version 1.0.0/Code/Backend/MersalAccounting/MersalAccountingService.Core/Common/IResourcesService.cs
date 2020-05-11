#region Using ...
using Framework.Common.Enums;
using MersalAccountingService.Common.Enums;
using MersalAccountingService.Common.Types; 
#endregion

namespace MersalAccountingService.Core.Common
{
    public interface IResourcesService
    {
        ResourceKey GetResourceKey(ResourceKeyEnum resourceKeyEnum);
        ResourceValue GetResourceValue(ResourceKeyEnum resourceKeyEnum, Language language);

        string GetMovementTypeName(MovementType? movementType, Language lang);

        #region Indexers
        ResourceKey this[ResourceKeyEnum resourceKeyEnum] { get; }
        ResourceValue this[ResourceKeyEnum resourceKeyEnum, Language language] { get; } 
        #endregion
    }
}
