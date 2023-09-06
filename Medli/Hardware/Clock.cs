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
			return RTC.Now.Second;
		}
        /// <summary>
        /// Minute
        /// </summary>
        /// <returns></returns>
        public static int Minute()
		{
			return RTC.Now.Minute;
		}
        /// <summary>
        /// Hour
        /// </summary>
        /// <returns></returns>
        public static int Hour()
		{
			return RTC.Now.Hour;
		}
        /// <summary>
        /// Day the of the week
        /// </summary>
        /// <returns></returns>
        public static int DayOfTheWeek()
		{
			return RTC.Now.DayOfTheWeek;
		}
        /// <summary>
        /// Month
        /// </summary>
        /// <returns></returns>
        public static int Month()
		{
			return RTC.Now.Month;
		}
        /// <summary>
        /// Year
        /// </summary>
        /// <returns></returns>
        public static int Year()
		{
			return RTC.Now.Year;
		}
        /// <summary>
        /// Day the of the month
        /// </summary>
        /// <returns></returns>
        public static int DayOfTheMonth()
		{
			return RTC.Now.DayOfTheMonth;
		}
        /// <summary>
        /// Century
        /// </summary>
        /// <returns></returns>
        public static int Century()
		{
			return RTC.Now.Century;
		}
	}
}
