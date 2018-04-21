using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medli.Core;

namespace Medli.Hardware
{
    public static class SpeakerExtensions
    {
        public static uint MsToHz(this int ms)
        {
            return (uint)(1000 / ms);
        }
        public static uint MsToHz(this uint ms)
        {
            return (uint)(1000 / ms);
        }
    }
    public class PCSpeaker
    {
        protected static Core.IOGroups.PCSpeaker IO = CoreDevices.PCSpeaker;
        private static PIT SpeakerPIT = new PIT();

        private static void EnableSound()
        {
            IO.Gate.Byte = (byte)(IO.Gate.Byte | 0x03);
        }
        private static void DisableSound()
        {
            IO.Gate.Byte = (byte)(IO.Gate.Byte & ~3);
            //IO.Port61.Byte = (byte)(IO.Port61.Byte | 0xFC);
        }

        public static void Beep(uint frequency)
        {
            if (frequency < 37 || frequency > 32767)
            {
                throw new ArgumentOutOfRangeException("Frequency must be between 37 and 32767Hz");
            }

            uint divisor = 1193180 / frequency;
            byte temp;
            IO.CommandRegister.Byte = 0xB6;
            IO.Channel2Data.Byte = (byte)(divisor & 0xFF);
            IO.Channel2Data.Byte = (byte)((divisor >> 8) & 0xFF);
            temp = IO.Gate.Byte;
            if (temp != (temp | 3))
            {
                IO.Gate.Byte = (byte)(temp | 3);
            }
            EnableSound();
        }
        public static void Beep(uint frequency, uint duration)
        {
            if (duration <= 0)
            {
                throw new ArgumentOutOfRangeException("Duration must be more than 0");
            }

            Beep(frequency);
            SpeakerPIT.Wait(duration);
            DisableSound();
        }
    }
}
