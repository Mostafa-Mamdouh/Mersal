#region Using ...
#endregion

namespace MersalAccountingService.Common.Enums
{
    /// <summary>
    /// 
    /// </summary>
    public enum InventoryMovementTypeEnum : byte
    {
        InventoryIn = 1,
        InventoryOut = 2,
        GiftsIn = 3,
        GiftsOut = 4,
        /// <summary>
        /// تالف او فاسد
        /// </summary>
        Consists = 5,
        Reservation = 6,
        ReservationRebate = 7,
        PositiveInventoryDifferences = 8,
        NegativeInventoryDifferences = 9
    }
}
