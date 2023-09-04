/*
Copyright (c) 2012-2013, dewitcher Team
Copyright (c) 2019, Siaranite Solutions
Copyright (c) 2019, Cosmos

All rights reserved.

See in the /Licenses folder for the licenses for each respected project.
*/

using System;
using AIC.Main.Extensions;
using AIC.Hardware;

namespace Medli.System.Framework
{
    public static class RTC
    {
        /// <summary>
        /// NOT RECOMMENDED! Waits for a given amount of ticks. It depends on the CPU speed.
        /// </summary>
        /// <param name="ticks">Amount</param>
        public static void SleepTicks(int ticks)
        {
            for (int i = 0; i < ticks; i++) {; }
            return;
        }

        public static class Now
        {
            /// <summary>
            /// Returns the hour
            /// </summary>
            public static byte Hour
            {
                get
                {
                    return AIC.Hardware.RTC.Now.Hour;
                }
            }
            /// <summary>
            /// Returns the hour as string in format hh
            /// </summary>
            public static string HourString
            {
                get
                {
                    return Hour.TryAppend();
                }
            }

            /// <summary>
            /// Returns the minute
            /// </summary>
            public static byte Minute
            {
                get
                {
                    return AIC.Hardware.RTC.Now.Minute;
                }
            }
            /// <summary>
            /// Returns the minute as string in format mm
            /// </summary>
            public static string MinuteString
            {
                get
                {
                    return Minute.TryAppend();
                }
            }

            /// <summary>
            /// Returns the second
            /// </summary>
            public static byte Second
            {
                get
                {
                    return AIC.Hardware.RTC.Now.Second;
                }
            }
            /// /// <summary>
            /// Returns the second as string in format ss
            /// </summary>
            public static string SecondString
            {
                get
                {
                    return Second.TryAppend();
                }
            }

            /// <summary>
            /// Returns the century
            /// </summary>
            public static byte Century
            {
                get
                {
                    return AIC.Hardware.RTC.Now.Century;
                }
            }
            /// <summary>
            /// Returns the century as string in format xx ( x = any number )
            /// </summary>
            public static string CenturyString
            {
                get
                {
                    return Century.TryAppend();
                }
            }

            /// <summary>
            /// Returns the year (e.g. 2012)
            /// </summary>
            public static int Year
            {
                get
                {
                    return int.Parse(Century.ToString() + AIC.Hardware.RTC.Now.Year.ToString());
                }
            }
            /// <summary>
            /// Returns the year as string in format xxxx ( x = any number )
            /// </summary>
            public static string YearString = AIC.Hardware.RTC.Now.YearString;
            /// <summary>
            /// Returns the day of the month
            /// </summary>
            public static byte DayOfTheMonth
            {
                get
                {
                    return AIC.Hardware.RTC.Now.DayOfTheMonth;
                }
            }
            /// <summary>
            /// Returns the day of the month in format xx ( x = any number )
            /// </summary>
            public static string DayOfTheMonthString
            {
                get
                {
                    return DayOfTheMonth.TryAppend();
                }
            }

            /// <summary>
            /// Returns the day of the year
            /// </summary>
            public static byte DayOfTheYear
            {
                get
                {
                    return (byte)(DayOfTheMonth * Month);
                }
            }
            /// <summary>
            /// Returns the day of the year in format xxx ( x = any number )
            /// </summary>
            public static string DayOfTheYearString
            {
                get
                {
                    return DayOfTheYear.TryAppendYear();
                }
            }

            /// <summary>
            /// Returns the day of the week
            /// </summary>
            public static byte DayOfTheWeek
            {
                get
                {
                    return AIC.Hardware.RTC.Now.DayOfTheWeek;
                }
            }
            /// <summary>
            /// Returns the day of the week in format xx ( x = any number )
            /// </summary>
            public static string DayOfTheWeekString
            {
                get
                {
                    return DayOfTheWeek.TryAppend();
                }
            }

            /// <summary>
            /// Returns the month
            /// </summary>
            public static byte Month
            {
                get
                {
                    return AIC.Hardware.RTC.Now.Month;
                }
            }
            /// <summary>
            /// Returns the month in format xx ( x = any number )
            /// </summary>
            public static string MonthString
            {
                get
                {
                    return Month.TryAppend();
                }
            }

            /// <summary>
            /// DateFormat
            /// </summary>
            public enum DateFormat : byte
            {
                YYYY_MM_DD, DD_MM_YYYY, MM_DD_YYYY, YYYY_DD_MM
            }
            /// <summary>
            /// Returns the date in the specified date format
            /// </summary>
            /// <param name="format">Date Format</param>
            /// <returns>the date in the specified date format</returns>
            public static string GetDate(DateFormat format, char separator = '.')
            {
                if (format == DateFormat.DD_MM_YYYY)
                    return DayOfTheMonthString + separator + MonthString + separator + AIC.Hardware.RTC.Now.YearString;
                else if (format == DateFormat.YYYY_MM_DD)
                    return AIC.Hardware.RTC.Now.YearString + separator + MonthString + separator + DayOfTheMonthString;
                else if (format == DateFormat.YYYY_DD_MM)
                    return AIC.Hardware.RTC.Now.YearString + "." + DayOfTheMonthString + separator + MonthString;
                else if (format == DateFormat.MM_DD_YYYY)
                    return MonthString + "." + DayOfTheMonthString + separator + AIC.Hardware.RTC.Now.YearString;
                else
                    return "ERROR";
            }

            /// <summary>
            /// TimeFormat
            /// </summary>
            public enum TimeFormat : byte
            {
                hh_mm, hh_mm_ss, mm_ss
            }
            /// <summary>
            /// Returns the time in the specified time format
            /// </summary>
            /// <param name="format">Time Format</param>
            /// <returns>the time in the specified time format</returns>
            public static string GetTime(TimeFormat format)
            {
                if (format == TimeFormat.hh_mm)
                    return HourString + ":" + MinuteString;
                else if (format == TimeFormat.hh_mm_ss)
                    return HourString + ":" + MinuteString + ":" + SecondString;
                else if (format == TimeFormat.mm_ss)
                    return MinuteString + ":" + SecondString;
                else
                    return "ERROR";
            }
        }

        public static void Sleep(int secNum)
        {
            int StartSec = Now.Second;
            int EndSec;

            if (StartSec + secNum > 59)
                EndSec = 0;
            else
                EndSec = StartSec + secNum;

            // Loop round
            while (Now.Second != EndSec) ;
        }

        /// <summary>
        /// Function that tries to set the numbers length to 2
        /// </summary>
        /// <param name="value">byte</param>
        /// <returns>new value as string</returns>
        internal static string TryAppend(this byte value)
        {
            string val = value.ToString();
            if (val.Length < 2)
                return "0" + val;
            else
                return val;
        }
        /// <summary>
        /// Function that tries to set the numbers length to 3
        /// </summary>
        /// <param name="value">byte</param>
        /// <returns>new value as string</returns>
        internal static string TryAppendYear(this byte value)
        {
            string val = value.ToString();
            if (val.Length < 2)
                return "0" + val;
            else if (val.Length < 3)
                return "00" + val;
            else
                return val;
        }
    }
}
