using System;
using System.Collections.Generic;
using System.Text;
using Medli.System;
using Medli.Hardware;

namespace Medli
{
	public class Time
	{
		public static void printTime()
		{
			Console.WriteLine("The current time is " + SysClock.Hour().ToString() + ":" + SysClock.Minute().ToString() + ":" + SysClock.Second().ToString());
		}
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
		public static int Century()
		{
			return Clock.Century();
		}
	}
}
