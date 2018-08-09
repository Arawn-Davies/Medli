using System;
using System.Collections.Generic;
using System.Text;
using Medli.System;
using Medli.Hardware;

namespace Medli
{
	public class Time
	{
		public static string GetDay()
		{
			if (SysClock.DayOfTheWeek() == 1)
			{
				return "Thursday";
			}
			else if (SysClock.DayOfTheWeek() == 2)
			{
				return "Friday";
			}
			else if (SysClock.DayOfTheWeek() == 3)
			{
				return "Saturday";
			}
			else if (SysClock.DayOfTheWeek() == 4)
			{

				return "Sunday";
			}
			else if (SysClock.DayOfTheWeek() == 5)
			{
				return "Monday";
			}
			else if (SysClock.DayOfTheWeek() == 6)
			{
				return "Tuesday";
			}
			else if (SysClock.DayOfTheWeek() == 7)
			{
				return "Wednesday";
			}
			else
			{
				return "Invalid DayOfTheWeek";
			}
		}

		public static string GetMonth()
		{
			if (SysClock.Month() == 1)
			{
				return "January";
			}
			else if (SysClock.Month() == 2)
			{
				return "February";
			}
			else if (SysClock.Month() == 3)
			{
				return "March";
			}
			else if (SysClock.Month() == 4)
			{
				return "April";
			}
			else if (SysClock.Month() == 5)
			{
				return "May";
			}
			else if (SysClock.Month() == 6)
			{
				return "June";
			}
			else if (SysClock.Month() == 7)
			{
				return "July";
			}
			else if (SysClock.Month() == 8)
			{
				return "August";
			}
			else if (SysClock.Month() == 9)
			{
				return "September";
			}
			else if (SysClock.Month() == 10)
			{
				return "October";
			}
			else if (SysClock.Month() == 11)
			{
				return "November";
			}
			else if (SysClock.Month() == 12)
			{
				return "December";
			}
			else
			{
				return "Invalid Month";
			}
		}

		public static void printTime()
		{
			Console.WriteLine("The current time is " + SysClock.Hour().ToString() + ":" + SysClock.Minute().ToString() + ":" + SysClock.Second().ToString());
		}
		public static void printDate()
		{
			Console.WriteLine("The current date is " + GetDay() + " " + SysClock.DayOfTheMonth().ToString() + " of " + GetMonth() + ", " + SysClock.Century().ToString() + SysClock.Year().ToString());
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
