#region Using ...
using System;
#endregion

namespace Framework.Common.Extentions
{
    /// <summary>
    /// 
    /// </summary>
    public static class DateTimeExtention
    {
        //     /// <summary>
        //     /// Return a new instance of date time after setting it's time to now.
        //     /// </summary>
        //     /// <param name="dateTime"></param>
        //     /// <returns></returns>
        //     public static DateTime? SetTimeToNow(this DateTime? dateTime)
        //     {
        //         var time = DateTime.Now;

        //if (dateTime.HasValue)
        //{
        //	dateTime = new DateTime(dateTime.Value.Year, dateTime.Value.Month, dateTime.Value.Day,
        //		time.Hour, time.Minute, time.Second, time.Millisecond);

        //	dateTime = new DateTime(dateTime.Value.Year, dateTime.Value.Month, dateTime.Value.Day,
        //		23, 59, 59, 999);
        //}

        //return dateTime;
        //     }

        //     /// <summary>
        //     /// Return a new instance of date time after setting it's time to now.
        //     /// </summary>
        //     /// <param name="dateTime"></param>
        //     /// <returns></returns>
        //     public static DateTime SetTimeToNow(this DateTime dateTime)
        //     {
        //         var time = DateTime.Now;

        //         dateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day,
        //             time.Hour, time.Minute, time.Second, time.Millisecond);

        //         return dateTime;
        //     }

        /// <summary>
        /// Return a new instance of date time after setting it's time to now.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime? SetTimeToMax(this DateTime? dateTime)
        {
            var time = DateTime.Now;

            if (dateTime.HasValue)
            {
                DateTime date = dateTime.Value;
                dateTime = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999);
            }

            return dateTime;
        }

        /// <summary>
        /// Return a new instance of date time after setting it's time to now.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime SetTimeToMax(this DateTime dateTime)
        {
            var time = DateTime.Now;

            dateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59, 999);

            return dateTime;
        }


        public static bool IsLastDayInMonth(this DateTime dateTime)
        {
            bool result = false;

            if (dateTime.Month == 1 ||
                dateTime.Month == 3 ||
                dateTime.Month == 5 ||
                dateTime.Month == 7 ||
                dateTime.Month == 8 ||
                dateTime.Month == 10 ||
                dateTime.Month == 12)
            {
                result = (dateTime.Day == 31);
            }
            else if (dateTime.Month == 4 ||
                dateTime.Month == 6 ||
                dateTime.Month == 9 ||
                dateTime.Month == 11)
            {
                result = (dateTime.Day == 30);
            }
            else
            {
                result = (dateTime.Day == 28);
            }

            return result;
        }
    }
}
