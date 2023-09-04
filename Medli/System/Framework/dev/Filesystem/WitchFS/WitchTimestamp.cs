/*
Copyright (c) 2012-2013, dewitcher Team
All rights reserved.

Redistribution and use in source and binary forms, with or without modification,
are permitted provided that the following conditions are met:

* Redistributions of source code must retain the above copyright notice
   this list of conditions and the following disclaimer.

* Redistributions in binary form must reproduce the above copyright notice,
  this list of conditions and the following disclaimer in the documentation
  and/or other materials provided with the distribution.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR
IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR
CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER
IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF
THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medli.System.Framework;

namespace Medli.System.Framework.dev.Filesystem.WitchFS
{
    public static class WitchTimestamp
    {
        // Calculate timestamp
        public static string GetCurrentTimestamp()
        {
            // strings
            string Y = RTC.Now.Year.ToString();
            Y = Y[2].ToString() + Y[3].ToString();
            string M = RTC.Now.Month.ToString();
            string d = RTC.Now.DayOfTheYear.ToString();
            string h = RTC.Now.Hour.ToString();
            string m = RTC.Now.Minute.ToString();
            string s = RTC.Now.Second.ToString();

            // seed
            float seed = int.Parse(s) / 100f;

            // calculate and return
            int tmp = int.Parse(Y + M + d + h + m + s);
            int final = tmp >> (int)seed;
            return final.ToString();
        }
        public static string GetTimestamp(int Year, int Month, int DayOfYear, int Hour, int Minute, int Second, int Seed)
        {
            // strings
            string Y = Year.ToString();
            Y = Y[2].ToString() + Y[3].ToString();
            string M = Month.ToString();
            string d = DayOfYear.ToString();
            string h = Hour.ToString();
            string m = Minute.ToString();
            string s = Second.ToString();

            // seed
            float seed = Second / 100f;

            // calculate and return
            int tmp = int.Parse(Y + M + d + h + m + s);
            int final = tmp >> (int)seed;
            return final.ToString();
        }
    }
}
