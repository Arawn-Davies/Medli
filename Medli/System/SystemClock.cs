using System;
using System.Collections.Generic;
using System.Text;
using Medli.Hardware;

namespace Medli.System
{
	public class SysClock
	{
		public static int Second()
		{
			return Clock.Second();
		}
		public static int Minute()
		{
			return Clock.Minute();
		}
		public static int Hour()
		{
			return Clock.Hour();
		}
		public static int DayOfTheWeek()
		{
			return Clock.DayOfTheWeek();
		}
		public static int Month()
		{
			return Clock.Month();
		}
		public static int Year()
		{
			return Clock.Year();
		}
		public static int DayOfTheMonth()
		{
			return Clock.DayOfTheMonth();
		}
	}
}