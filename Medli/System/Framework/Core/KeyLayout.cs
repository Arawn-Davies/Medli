/*
Copyright (c) 2012-2013, dewitcher Team
Copyright (c) 2019, Siaranite Solutions
Copyright (c) 2019, Cosmos

All rights reserved.

See in the /Licenses folder for the licenses for each respected project.
*/

using System;
using System.Collections.Generic;
using Cosmos.HAL;

namespace Medli.System.Framework.Core
{
    // INFO: We recommend to set the keylayout in the BeforeRun() method to make sure that
    //       the arrow keys does not appear as a pretty fuckedup random unicode char..
    public static class KeyLayout
    {
        internal static List<Cosmos.System.KeyMapping> keys;
        public enum KeyLayouts : byte { QWERTY, QWERTZ, AZERTY };
        private static uint KeyCount;
        private static void ChangeKeyMap()
        {
            Medli.Hardware.KeyLayout.ChangeKeyMap("QWERTY");
        }
        public static void SwitchKeyLayout(KeyLayouts layout)
        {
            switch (layout)
            {
                case KeyLayouts.AZERTY:
                    AZERTY(); break;
                case KeyLayouts.QWERTY:
                    QWERTY(); break;
                case KeyLayouts.QWERTZ:
                    QWERTZ(); break;
            }
        }
        private static void AddKey(uint p, char p_2, ConsoleKey p_3)
        {
            throw new NotImplementedException();
            //keys.Add(new Cosmos.System.KeyMapping(p, p_2, p_3));
            //KeyCount += 1u;
        }
        private static void AddKeyWithShift(uint p, char p_2, ConsoleKey p_3)
        {
            AddKey(p, p_2, p_3);
            AddKey(p << 16, p_2, p_3);
        }
        private static void AddKey(uint p, ConsoleKey p_3)
        {
            AddKey(p, '\0', p_3);
        }
        private static void AddKeyWithShift(uint p, ConsoleKey p_3)
        {
            AddKeyWithShift(p, '\0', p_3);
        }
        public static void QWERTY()
        {
            Medli.Hardware.KeyLayout.QWERTY();
            ChangeKeyMap();
        }

        /// <summary>
        /// The QWERTZ-Implementation is not 100% finished.
        /// Most keys will work, some keys will still return QWERTY-Chars.
        /// </summary>
        public static void QWERTZ()
        {
            Medli.Hardware.KeyLayout.QWERTZ();
            ChangeKeyMap();
        }

        public static void AZERTY()
        {
            Medli.Hardware.KeyLayout.AZERTY();
            ChangeKeyMap();
        }
    }
}