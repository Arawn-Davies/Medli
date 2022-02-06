using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.HAL;

namespace Medli.Hardware
{
    /// <summary>
    /// Class definition for Medli-Hardware Clock
    /// </summary>
    public class Clock
	{
        /// <summary>
        /// Second
        /// </summary>
        /// <returns></returns>
        public static int Second()
		{
			return RTC.Second;
		}
        /// <summary>
        /// Minute
        /// </summary>
        /// <returns></returns>
        public static int Minute()
		{
			return RTC.Minute;
		}
        /// <summary>
        /// Hour
        /// </summary>
        /// <returns></returns>
        public static int Hour()
		{
			return RTC.Hour;
		}
        /// <summary>
        /// Day the of the week
        /// </summary>
        /// <returns></returns>
        public static int DayOfTheWeek()
		{
			return RTC.DayOfTheWeek;
		}
        /// <summary>
        /// Month
        /// </summary>
        /// <returns></returns>
        public static int Month()
		{
			return RTC.Month;
		}
        /// <summary>
        /// Year
        /// </summary>
        /// <returns></returns>
        public static int Year()
		{
			return RTC.Year;
		}
        /// <summary>
        /// Day the of the month
        /// </summary>
        /// <returns></returns>
        public static int DayOfTheMonth()
		{
			return RTC.DayOfTheMonth;
		}
        /// <summary>
        /// Century
        /// </summary>
        /// <returns></returns>
        public static int Century()
		{
			return RTC.Century;
		}
	}
}
