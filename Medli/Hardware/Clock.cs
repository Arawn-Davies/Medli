using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.HAL;

namespace Medli.Hardware
{
	public class Clock
	{
		public static int Second()
		{
			return RTC.Second;
		}
		public static int Minute()
		{
			return RTC.Minute;
		}
		public static int Hour()
		{
			return RTC.Hour;
		}
		public static int DayOfTheWeek()
		{
			return RTC.DayOfTheWeek;
		}
		public static int Month()
		{
			return RTC.Month;
		}
		public static int Year()
		{
			return RTC.Year;
		}
		public static int DayOfTheMonth()
		{
			return RTC.DayOfTheMonth;
		}
		public static int Century()
		{
			return RTC.Century;
		}
	}
}
