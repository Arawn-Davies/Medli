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


namespace Medli.Hardware
{
    // INFO: We recommend to set the keylayout in the BeforeRun() method to make sure that
    //       the arrow keys does not appear as a pretty fuckedup random unicode char..
    public static class KeyLayout
    {

        internal static List<Cosmos.System.KeyMapping> keys;
        public enum KeyLayouts : byte { QWERTY, QWERTZ, AZERTY };
        private static uint KeyCount;
        public static void ChangeKeyMap(string layout)
        {
            if (layout == "qwerty")
            {
                QWERTY();
            }
            else if (layout == "qwertz")
            {
                QWERTZ();
            }
            else if (layout == "")
            {
                AZERTY();
            }
            
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
        private static void AddKey(uint p, char p_2, Cosmos.System.ConsoleKeyEx p_3)
        {
            //keys.Add(new Cosmos.System.KeyMapping(p, p_2, p_3));
            //KeyCount += 1u;
        }
        private static void AddKeyWithShift(uint p, char p_2, Cosmos.System.ConsoleKeyEx p_3)
        {
            AddKey(p, p_2, p_3);
            AddKey(p << 16, p_2, p_3);
        }
        private static void AddKey(uint p, Cosmos.System.ConsoleKeyEx p_3)
        {
            AddKey(p, '\0', p_3);
        }
        private static void AddKeyWithShift(uint p, Cosmos.System.ConsoleKeyEx p_3)
        {
            AddKeyWithShift(p, '\0', p_3);
        }
        public static void QWERTY()
        {
            keys = new List<Cosmos.System.KeyMapping>(164);
            #region Keys
            AddKey(16u, 'q', Cosmos.System.ConsoleKeyEx.Q);
            AddKey(1048576u, 'Q', Cosmos.System.ConsoleKeyEx.Q);
            AddKey(17u, 'w', Cosmos.System.ConsoleKeyEx.W);
            AddKey(1114112u, 'W', Cosmos.System.ConsoleKeyEx.W);
            AddKey(18u, 'e', Cosmos.System.ConsoleKeyEx.E);
            AddKey(1179648u, 'E', Cosmos.System.ConsoleKeyEx.E);
            AddKey(19u, 'r', Cosmos.System.ConsoleKeyEx.R);
            AddKey(1245184u, 'R', Cosmos.System.ConsoleKeyEx.R);
            AddKey(20u, 't', Cosmos.System.ConsoleKeyEx.T);
            AddKey(1310720u, 'T', Cosmos.System.ConsoleKeyEx.T);
            AddKey(21u, 'y', Cosmos.System.ConsoleKeyEx.Y);
            AddKey(1376256u, 'Y', Cosmos.System.ConsoleKeyEx.Y);
            AddKey(22u, 'u', Cosmos.System.ConsoleKeyEx.U);
            AddKey(1441792u, 'U', Cosmos.System.ConsoleKeyEx.U);
            AddKey(23u, 'i', Cosmos.System.ConsoleKeyEx.I);
            AddKey(1507328u, 'I', Cosmos.System.ConsoleKeyEx.I);
            AddKey(24u, 'o', Cosmos.System.ConsoleKeyEx.O);
            AddKey(1572864u, 'O', Cosmos.System.ConsoleKeyEx.O);
            AddKey(25u, 'p', Cosmos.System.ConsoleKeyEx.P);
            AddKey(1638400u, 'P', Cosmos.System.ConsoleKeyEx.P);
            AddKey(30u, 'a', Cosmos.System.ConsoleKeyEx.A);
            AddKey(1966080u, 'A', Cosmos.System.ConsoleKeyEx.A);
            AddKey(31u, 's', Cosmos.System.ConsoleKeyEx.S);
            AddKey(2031616u, 'S', Cosmos.System.ConsoleKeyEx.S);
            AddKey(32u, 'd', Cosmos.System.ConsoleKeyEx.D);
            AddKey(2097152u, 'D', Cosmos.System.ConsoleKeyEx.D);
            AddKey(33u, 'f', Cosmos.System.ConsoleKeyEx.F);
            AddKey(2162688u, 'F', Cosmos.System.ConsoleKeyEx.F);
            AddKey(34u, 'g', Cosmos.System.ConsoleKeyEx.G);
            AddKey(2228224u, 'G', Cosmos.System.ConsoleKeyEx.G);
            AddKey(35u, 'h', Cosmos.System.ConsoleKeyEx.H);
            AddKey(2293760u, 'H', Cosmos.System.ConsoleKeyEx.H);
            AddKey(36u, 'j', Cosmos.System.ConsoleKeyEx.J);
            AddKey(2359296u, 'J', Cosmos.System.ConsoleKeyEx.J);
            AddKey(37u, 'k', Cosmos.System.ConsoleKeyEx.K);
            AddKey(2424832u, 'K', Cosmos.System.ConsoleKeyEx.K);
            AddKey(38u, 'l', Cosmos.System.ConsoleKeyEx.L);
            AddKey(2490368u, 'L', Cosmos.System.ConsoleKeyEx.L);
            AddKey(44u, 'z', Cosmos.System.ConsoleKeyEx.Z);
            AddKey(2883584u, 'Z', Cosmos.System.ConsoleKeyEx.Z);
            AddKey(45u, 'x', Cosmos.System.ConsoleKeyEx.X);
            AddKey(2949120u, 'X', Cosmos.System.ConsoleKeyEx.X);
            AddKey(46u, 'c', Cosmos.System.ConsoleKeyEx.C);
            AddKey(3014656u, 'C', Cosmos.System.ConsoleKeyEx.C);
            AddKey(47u, 'v', Cosmos.System.ConsoleKeyEx.V);
            AddKey(3080192u, 'V', Cosmos.System.ConsoleKeyEx.V);
            AddKey(48u, 'b', Cosmos.System.ConsoleKeyEx.B);
            AddKey(3145728u, 'B', Cosmos.System.ConsoleKeyEx.B);
            AddKey(49u, 'n', Cosmos.System.ConsoleKeyEx.N);
            AddKey(3211264u, 'N', Cosmos.System.ConsoleKeyEx.N);
            AddKey(50u, 'm', Cosmos.System.ConsoleKeyEx.M);
            AddKey(3276800u, 'M', Cosmos.System.ConsoleKeyEx.M);
            AddKey(41u, '`', Cosmos.System.ConsoleKeyEx.NoName);
            AddKey(2686976u, '~', Cosmos.System.ConsoleKeyEx.NoName);
            AddKey(2u, '1', Cosmos.System.ConsoleKeyEx.D1);
            AddKey(131072u, '!', Cosmos.System.ConsoleKeyEx.D1);
            AddKey(3u, '2', Cosmos.System.ConsoleKeyEx.D2);
            AddKey(196608u, '@', Cosmos.System.ConsoleKeyEx.D2);
            AddKey(4u, '3', Cosmos.System.ConsoleKeyEx.D3);
            AddKey(262144u, '#', Cosmos.System.ConsoleKeyEx.D3);
            AddKey(5u, '4', Cosmos.System.ConsoleKeyEx.D4);
            AddKey(327680u, '$', Cosmos.System.ConsoleKeyEx.D5);
            AddKey(6u, '5', Cosmos.System.ConsoleKeyEx.D5);
            AddKey(393216u, '%', Cosmos.System.ConsoleKeyEx.D5);
            AddKey(7u, '6', Cosmos.System.ConsoleKeyEx.D6);
            AddKey(458752u, '^', Cosmos.System.ConsoleKeyEx.D6);
            AddKey(8u, '7', Cosmos.System.ConsoleKeyEx.D7);
            AddKey(524288u, '&', Cosmos.System.ConsoleKeyEx.D7);
            AddKey(9u, '8', Cosmos.System.ConsoleKeyEx.D8);
            AddKey(589824u, '*', Cosmos.System.ConsoleKeyEx.D8);
            AddKey(10u, '9', Cosmos.System.ConsoleKeyEx.D9);
            AddKey(655360u, '(', Cosmos.System.ConsoleKeyEx.D9);
            AddKey(11u, '0', Cosmos.System.ConsoleKeyEx.D0);
            AddKey(720896u, ')', Cosmos.System.ConsoleKeyEx.D0);
            AddKeyWithShift(14u, '\b', Cosmos.System.ConsoleKeyEx.Backspace);
            AddKeyWithShift(15u, '\t', Cosmos.System.ConsoleKeyEx.Tab);
            AddKeyWithShift(28u, '\n', Cosmos.System.ConsoleKeyEx.Enter);
            AddKeyWithShift(57u, ' ', Cosmos.System.ConsoleKeyEx.Spacebar);
            AddKeyWithShift(75u, '\0', Cosmos.System.ConsoleKeyEx.LeftArrow);
            AddKeyWithShift(72u, '\0', Cosmos.System.ConsoleKeyEx.UpArrow);
            AddKeyWithShift(77u, '\0', Cosmos.System.ConsoleKeyEx.RightArrow);
            AddKeyWithShift(80u, '\0', Cosmos.System.ConsoleKeyEx.DownArrow);
            AddKeyWithShift(91u, Cosmos.System.ConsoleKeyEx.LWin);
            AddKeyWithShift(92u, Cosmos.System.ConsoleKeyEx.RWin);
            AddKeyWithShift(82u, Cosmos.System.ConsoleKeyEx.Insert);
            AddKeyWithShift(71u, Cosmos.System.ConsoleKeyEx.Home);
            AddKeyWithShift(73u, Cosmos.System.ConsoleKeyEx.PageUp);
            AddKeyWithShift(83u, Cosmos.System.ConsoleKeyEx.Delete);
            AddKeyWithShift(79u, Cosmos.System.ConsoleKeyEx.End);
            AddKeyWithShift(81u, Cosmos.System.ConsoleKeyEx.PageDown);
            AddKeyWithShift(55u, Cosmos.System.ConsoleKeyEx.PrintScreen);
            AddKeyWithShift(69u, Cosmos.System.ConsoleKeyEx.PauseBreak);
            AddKeyWithShift(59u, Cosmos.System.ConsoleKeyEx.F1);
            AddKeyWithShift(60u, Cosmos.System.ConsoleKeyEx.F2);
            AddKeyWithShift(61u, Cosmos.System.ConsoleKeyEx.F3);
            AddKeyWithShift(62u, Cosmos.System.ConsoleKeyEx.F4);
            AddKeyWithShift(63u, Cosmos.System.ConsoleKeyEx.F5);
            AddKeyWithShift(64u, Cosmos.System.ConsoleKeyEx.F6);
            AddKeyWithShift(65u, Cosmos.System.ConsoleKeyEx.F7);
            AddKeyWithShift(66u, Cosmos.System.ConsoleKeyEx.F8);
            AddKeyWithShift(67u, Cosmos.System.ConsoleKeyEx.F9);
            AddKeyWithShift(68u, Cosmos.System.ConsoleKeyEx.F10);
            AddKeyWithShift(87u, Cosmos.System.ConsoleKeyEx.F11);
            AddKeyWithShift(88u, Cosmos.System.ConsoleKeyEx.F12);
            AddKeyWithShift(1u, Cosmos.System.ConsoleKeyEx.Escape);
            AddKey(39u, ';', Cosmos.System.ConsoleKeyEx.NoName);
            AddKey(2555904u, ':', Cosmos.System.ConsoleKeyEx.NoName);
            AddKey(40u, '\'', Cosmos.System.ConsoleKeyEx.NoName);
            AddKey(2621440u, '"', Cosmos.System.ConsoleKeyEx.NoName);
            AddKey(43u, '\\', Cosmos.System.ConsoleKeyEx.NoName);
            AddKey(2818048u, '|', Cosmos.System.ConsoleKeyEx.NoName);
            AddKey(51u, ',', Cosmos.System.ConsoleKeyEx.Comma);
            AddKey(3342336u, '<', Cosmos.System.ConsoleKeyEx.Comma);
            AddKey(52u, '.', Cosmos.System.ConsoleKeyEx.Period);
            AddKey(3407872u, '>', Cosmos.System.ConsoleKeyEx.Period);
            AddKey(53u, '/', Cosmos.System.ConsoleKeyEx.NumDivide);
            AddKey(3473408u, '?', Cosmos.System.ConsoleKeyEx.NumDivide);
            AddKey(12u, '-', Cosmos.System.ConsoleKeyEx.NumMinus);
            AddKey(786432u, '_', Cosmos.System.ConsoleKeyEx.NumMinus);
            AddKey(13u, '=', Cosmos.System.ConsoleKeyEx.NumPlus);
            AddKey(851968u, '+', Cosmos.System.ConsoleKeyEx.NumPlus);
            AddKey(26u, '[', Cosmos.System.ConsoleKeyEx.NoName);
            AddKey(1703936u, '{', Cosmos.System.ConsoleKeyEx.NoName);
            AddKey(27u, ']', Cosmos.System.ConsoleKeyEx.NoName);
            AddKey(1769472u, '}', Cosmos.System.ConsoleKeyEx.NoName);
            AddKeyWithShift(76u, '5', Cosmos.System.ConsoleKeyEx.Num5);
            AddKeyWithShift(74u, '-', Cosmos.System.ConsoleKeyEx.NumMinus);
            AddKeyWithShift(78u, '+', Cosmos.System.ConsoleKeyEx.NumPlus);
            AddKeyWithShift(55u, '*', Cosmos.System.ConsoleKeyEx.NumMultiply);
            #endregion
            //ChangeKeyMap();
        }

        /// <summary>
        /// The QWERTZ-Implementation is not 100% finished.
        /// Most keys will work, some keys will still return QWERTY-Chars.
        /// </summary>
        public static void QWERTZ()
        {
            keys = new List<Cosmos.System.KeyMapping>(164);
            #region Keys
            // Q W E R T Z U I O P
            AddKey(16u, 'q', Cosmos.System.ConsoleKeyEx.Q);
            AddKey(1048576u, 'Q', Cosmos.System.ConsoleKeyEx.Q);
            AddKey(17u, 'w', Cosmos.System.ConsoleKeyEx.W);
            AddKey(1114112u, 'W', Cosmos.System.ConsoleKeyEx.W);
            AddKey(18u, 'e', Cosmos.System.ConsoleKeyEx.E);
            AddKey(1179648u, 'E', Cosmos.System.ConsoleKeyEx.E);
            AddKey(19u, 'r', Cosmos.System.ConsoleKeyEx.R);
            AddKey(1245184u, 'R', Cosmos.System.ConsoleKeyEx.R);
            AddKey(20u, 't', Cosmos.System.ConsoleKeyEx.T);
            AddKey(1310720u, 'T', Cosmos.System.ConsoleKeyEx.T);
            AddKey(21u, 'z', Cosmos.System.ConsoleKeyEx.Z);
            AddKey(1376256u, 'Z', Cosmos.System.ConsoleKeyEx.Z);
            AddKey(22u, 'u', Cosmos.System.ConsoleKeyEx.U);
            AddKey(1441792u, 'U', Cosmos.System.ConsoleKeyEx.U);
            AddKey(23u, 'i', Cosmos.System.ConsoleKeyEx.I);
            AddKey(1507328u, 'I', Cosmos.System.ConsoleKeyEx.I);
            AddKey(24u, 'o', Cosmos.System.ConsoleKeyEx.O);
            AddKey(1572864u, 'O', Cosmos.System.ConsoleKeyEx.O);
            AddKey(25u, 'p', Cosmos.System.ConsoleKeyEx.P);
            AddKey(1638400u, 'P', Cosmos.System.ConsoleKeyEx.P);

            // A S D F G H J K L
            AddKey(30u, 'a', Cosmos.System.ConsoleKeyEx.A);
            AddKey(1966080u, 'A', Cosmos.System.ConsoleKeyEx.A);
            AddKey(31u, 's', Cosmos.System.ConsoleKeyEx.S);
            AddKey(2031616u, 'S', Cosmos.System.ConsoleKeyEx.S);
            AddKey(32u, 'd', Cosmos.System.ConsoleKeyEx.D);
            AddKey(2097152u, 'D', Cosmos.System.ConsoleKeyEx.D);
            AddKey(33u, 'f', Cosmos.System.ConsoleKeyEx.F);
            AddKey(2162688u, 'F', Cosmos.System.ConsoleKeyEx.F);
            AddKey(34u, 'g', Cosmos.System.ConsoleKeyEx.G);
            AddKey(2228224u, 'G', Cosmos.System.ConsoleKeyEx.G);
            AddKey(35u, 'h', Cosmos.System.ConsoleKeyEx.H);
            AddKey(2293760u, 'H', Cosmos.System.ConsoleKeyEx.H);
            AddKey(36u, 'j', Cosmos.System.ConsoleKeyEx.J);
            AddKey(2359296u, 'J', Cosmos.System.ConsoleKeyEx.J);
            AddKey(37u, 'k', Cosmos.System.ConsoleKeyEx.K);
            AddKey(2424832u, 'K', Cosmos.System.ConsoleKeyEx.K);
            AddKey(38u, 'l', Cosmos.System.ConsoleKeyEx.L);
            AddKey(2490368u, 'L', Cosmos.System.ConsoleKeyEx.L);

            // Y X C V B N M
            AddKey(44u, 'y', Cosmos.System.ConsoleKeyEx.Y);
            AddKey(2883584u, 'Y', Cosmos.System.ConsoleKeyEx.Y);
            AddKey(45u, 'x', Cosmos.System.ConsoleKeyEx.X);
            AddKey(2949120u, 'X', Cosmos.System.ConsoleKeyEx.X);
            AddKey(46u, 'c', Cosmos.System.ConsoleKeyEx.C);
            AddKey(3014656u, 'C', Cosmos.System.ConsoleKeyEx.C);
            AddKey(47u, 'v', Cosmos.System.ConsoleKeyEx.V);
            AddKey(3080192u, 'V', Cosmos.System.ConsoleKeyEx.V);
            AddKey(48u, 'b', Cosmos.System.ConsoleKeyEx.B);
            AddKey(3145728u, 'B', Cosmos.System.ConsoleKeyEx.B);
            AddKey(49u, 'n', Cosmos.System.ConsoleKeyEx.N);
            AddKey(3211264u, 'N', Cosmos.System.ConsoleKeyEx.N);
            AddKey(50u, 'm', Cosmos.System.ConsoleKeyEx.M);
            AddKey(3276800u, 'M', Cosmos.System.ConsoleKeyEx.M);

            // ÜÖÄ
            // -- Nothing yet

            // ^ 1 2 3 4 5 6 7 8 9 0
            // ° ! " § $ % & / ( ) =
            AddKey(41u, '^', Cosmos.System.ConsoleKeyEx.NoName);
            AddKey(2686976u, '\0', Cosmos.System.ConsoleKeyEx.NoName);
            AddKey(2u, '1', Cosmos.System.ConsoleKeyEx.D1);
            AddKey(131072u, '!', Cosmos.System.ConsoleKeyEx.D1);
            AddKey(3u, '2', Cosmos.System.ConsoleKeyEx.D2);
            AddKey(196608u, '\"', Cosmos.System.ConsoleKeyEx.D2);
            AddKey(4u, '3', Cosmos.System.ConsoleKeyEx.D3);
            AddKey(262144u, '$', Cosmos.System.ConsoleKeyEx.D3);
            AddKey(5u, '4', Cosmos.System.ConsoleKeyEx.D4);
            AddKey(327680u, '$', Cosmos.System.ConsoleKeyEx.D5);
            AddKey(6u, '5', Cosmos.System.ConsoleKeyEx.D5);
            AddKey(393216u, '%', Cosmos.System.ConsoleKeyEx.D5);
            AddKey(7u, '6', Cosmos.System.ConsoleKeyEx.D6);
            AddKey(458752u, '&', Cosmos.System.ConsoleKeyEx.D6);
            AddKey(8u, '7', Cosmos.System.ConsoleKeyEx.D7);
            AddKey(524288u, '/', Cosmos.System.ConsoleKeyEx.NumDivide);
            AddKey(9u, '8', Cosmos.System.ConsoleKeyEx.D8);
            AddKey(589824u, '(', Cosmos.System.ConsoleKeyEx.D8);
            AddKey(10u, '9', Cosmos.System.ConsoleKeyEx.D9);
            AddKey(655360u, ')', Cosmos.System.ConsoleKeyEx.D9);
            AddKey(11u, '0', Cosmos.System.ConsoleKeyEx.D0);
            AddKey(720896u, '=', Cosmos.System.ConsoleKeyEx.D0);

            // + * # ' - _
            AddKey(27u, '+', Cosmos.System.ConsoleKeyEx.NumPlus);
            AddKey(1769472u, '*', Cosmos.System.ConsoleKeyEx.NumMultiply);
            AddKey(43u, '#', Cosmos.System.ConsoleKeyEx.NoName);
            AddKey(2555904u, '\'', Cosmos.System.ConsoleKeyEx.NoName);
            AddKey(53u, '-', Cosmos.System.ConsoleKeyEx.NumMinus);
            AddKey(3473408u, '_', Cosmos.System.ConsoleKeyEx.NumMinus);

            // ; , : .
            AddKey(3342336u, ';', Cosmos.System.ConsoleKeyEx.Comma);
            AddKey(51u, ',', Cosmos.System.ConsoleKeyEx.Comma);
            AddKey(3407872u, ':', Cosmos.System.ConsoleKeyEx.Period);
            AddKey(52u, '.', Cosmos.System.ConsoleKeyEx.Period);

            // < > | ~
            // -- DOES NOT EXIST
            // -- DOES NOT EXIST
            // -- DOES NOT EXIST
            AddKey(27u, '~', Cosmos.System.ConsoleKeyEx.NumPlus);

            // Special keys
            AddKeyWithShift(14u, '\b', Cosmos.System.ConsoleKeyEx.Backspace);
            AddKeyWithShift(15u, '\t', Cosmos.System.ConsoleKeyEx.Tab);
            AddKeyWithShift(28u, '\n', Cosmos.System.ConsoleKeyEx.Enter);
            AddKeyWithShift(57u, ' ', Cosmos.System.ConsoleKeyEx.Spacebar);
            AddKeyWithShift(75u, '\0', Cosmos.System.ConsoleKeyEx.LeftArrow);
            AddKeyWithShift(72u, '\0', Cosmos.System.ConsoleKeyEx.UpArrow);
            AddKeyWithShift(77u, '\0', Cosmos.System.ConsoleKeyEx.RightArrow);
            AddKeyWithShift(80u, '\0', Cosmos.System.ConsoleKeyEx.DownArrow);
            AddKeyWithShift(91u, Cosmos.System.ConsoleKeyEx.LWin);
            AddKeyWithShift(92u, Cosmos.System.ConsoleKeyEx.RWin);
            AddKeyWithShift(82u, Cosmos.System.ConsoleKeyEx.Insert);
            AddKeyWithShift(71u, Cosmos.System.ConsoleKeyEx.Home);
            AddKeyWithShift(73u, Cosmos.System.ConsoleKeyEx.PageUp);
            AddKeyWithShift(83u, Cosmos.System.ConsoleKeyEx.Delete);
            AddKeyWithShift(79u, Cosmos.System.ConsoleKeyEx.End);
            AddKeyWithShift(81u, Cosmos.System.ConsoleKeyEx.PageDown);
            AddKeyWithShift(55u, Cosmos.System.ConsoleKeyEx.PrintScreen);
            AddKeyWithShift(69u, Cosmos.System.ConsoleKeyEx.PauseBreak);
            AddKeyWithShift(59u, Cosmos.System.ConsoleKeyEx.F1);
            AddKeyWithShift(60u, Cosmos.System.ConsoleKeyEx.F2);
            AddKeyWithShift(61u, Cosmos.System.ConsoleKeyEx.F3);
            AddKeyWithShift(62u, Cosmos.System.ConsoleKeyEx.F4);
            AddKeyWithShift(63u, Cosmos.System.ConsoleKeyEx.F5);
            AddKeyWithShift(64u, Cosmos.System.ConsoleKeyEx.F6);
            AddKeyWithShift(65u, Cosmos.System.ConsoleKeyEx.F7);
            AddKeyWithShift(66u, Cosmos.System.ConsoleKeyEx.F8);
            AddKeyWithShift(67u, Cosmos.System.ConsoleKeyEx.F9);
            AddKeyWithShift(68u, Cosmos.System.ConsoleKeyEx.F10);
            AddKeyWithShift(87u, Cosmos.System.ConsoleKeyEx.F11);
            AddKeyWithShift(88u, Cosmos.System.ConsoleKeyEx.F12);
            AddKeyWithShift(1u, Cosmos.System.ConsoleKeyEx.Escape);

            // ß ? \
            // -- Not yet implemented

            // Other keys
            AddKeyWithShift(76u, '5', Cosmos.System.ConsoleKeyEx.Num5);
            #endregion
            //ChangeKeyMap();
        }

        public static void AZERTY()
        {
            keys = new List<Cosmos.System.KeyMapping>(164);
            #region Keys
            // A Z E R T Y U I O P
            AddKey(16u, 'a', Cosmos.System.ConsoleKeyEx.A);
            AddKey(1048576u, 'A', Cosmos.System.ConsoleKeyEx.A);
            AddKey(17u, 'z', Cosmos.System.ConsoleKeyEx.Z);
            AddKey(1114112u, 'Z', Cosmos.System.ConsoleKeyEx.Z);
            AddKey(18u, 'e', Cosmos.System.ConsoleKeyEx.E);
            AddKey(1179648u, 'E', Cosmos.System.ConsoleKeyEx.E);
            AddKey(19u, 'r', Cosmos.System.ConsoleKeyEx.R);
            AddKey(1245184u, 'R', Cosmos.System.ConsoleKeyEx.R);
            AddKey(20u, 't', Cosmos.System.ConsoleKeyEx.T);
            AddKey(1310720u, 'T', Cosmos.System.ConsoleKeyEx.T);
            AddKey(21u, 'y', Cosmos.System.ConsoleKeyEx.Y);
            AddKey(1376256u, 'Y', Cosmos.System.ConsoleKeyEx.Y);
            AddKey(22u, 'u', Cosmos.System.ConsoleKeyEx.U);
            AddKey(1441792u, 'U', Cosmos.System.ConsoleKeyEx.U);
            AddKey(23u, 'i', Cosmos.System.ConsoleKeyEx.I);
            AddKey(1507328u, 'I', Cosmos.System.ConsoleKeyEx.I);
            AddKey(24u, 'o', Cosmos.System.ConsoleKeyEx.O);
            AddKey(1572864u, 'O', Cosmos.System.ConsoleKeyEx.O);
            AddKey(25u, 'p', Cosmos.System.ConsoleKeyEx.P);
            AddKey(1638400u, 'P', Cosmos.System.ConsoleKeyEx.P);

            // Q S D F G H J K L M
            AddKey(30u, 'q', Cosmos.System.ConsoleKeyEx.Q);
            AddKey(1966080u, 'Q', Cosmos.System.ConsoleKeyEx.Q);
            AddKey(31u, 's', Cosmos.System.ConsoleKeyEx.S);
            AddKey(2031616u, 'S', Cosmos.System.ConsoleKeyEx.S);
            AddKey(32u, 'd', Cosmos.System.ConsoleKeyEx.D);
            AddKey(2097152u, 'D', Cosmos.System.ConsoleKeyEx.D);
            AddKey(33u, 'f', Cosmos.System.ConsoleKeyEx.F);
            AddKey(2162688u, 'F', Cosmos.System.ConsoleKeyEx.F);
            AddKey(34u, 'g', Cosmos.System.ConsoleKeyEx.G);
            AddKey(2228224u, 'G', Cosmos.System.ConsoleKeyEx.G);
            AddKey(35u, 'h', Cosmos.System.ConsoleKeyEx.H);
            AddKey(2293760u, 'H', Cosmos.System.ConsoleKeyEx.H);
            AddKey(36u, 'j', Cosmos.System.ConsoleKeyEx.J);
            AddKey(2359296u, 'J', Cosmos.System.ConsoleKeyEx.J);
            AddKey(37u, 'k', Cosmos.System.ConsoleKeyEx.K);
            AddKey(2424832u, 'K', Cosmos.System.ConsoleKeyEx.K);
            AddKey(38u, 'l', Cosmos.System.ConsoleKeyEx.L);
            AddKey(2490368u, 'L', Cosmos.System.ConsoleKeyEx.L);
            AddKey(39u, 'm', Cosmos.System.ConsoleKeyEx.M);

            // W X C V B N
            AddKey(44u, 'w', Cosmos.System.ConsoleKeyEx.W);
            AddKey(2883584u, 'W', Cosmos.System.ConsoleKeyEx.W);
            AddKey(45u, 'x', Cosmos.System.ConsoleKeyEx.X);
            AddKey(2949120u, 'X', Cosmos.System.ConsoleKeyEx.X);
            AddKey(46u, 'c', Cosmos.System.ConsoleKeyEx.C);
            AddKey(3014656u, 'C', Cosmos.System.ConsoleKeyEx.C);
            AddKey(47u, 'v', Cosmos.System.ConsoleKeyEx.V);
            AddKey(3080192u, 'V', Cosmos.System.ConsoleKeyEx.V);
            AddKey(48u, 'b', Cosmos.System.ConsoleKeyEx.B);
            AddKey(3145728u, 'B', Cosmos.System.ConsoleKeyEx.B);
            AddKey(49u, 'n', Cosmos.System.ConsoleKeyEx.N);
            AddKey(3211264u, 'N', Cosmos.System.ConsoleKeyEx.N);


            // ���
            // -- Nothing yet

            // ^ 1 2 3 4 5 6 7 8 9 0
            // � ! " � $ % & / ( ) =
            AddKey(41u, '�', Cosmos.System.ConsoleKeyEx.NoName);
            //AddKey(2686976u, '�', Cosmos.System.ConsoleKeyEx.NoName);
            AddKey(2u, '&', Cosmos.System.ConsoleKeyEx.D1);
            AddKey(131072u, '1', Cosmos.System.ConsoleKeyEx.D1);
            AddKey(3u, '�', Cosmos.System.ConsoleKeyEx.D2);
            AddKey(196608u, '2', Cosmos.System.ConsoleKeyEx.D2);
            AddKey(4u, '"', Cosmos.System.ConsoleKeyEx.D3);
            AddKey(262144u, '3', Cosmos.System.ConsoleKeyEx.D3);
            AddKey(5u, '\'', Cosmos.System.ConsoleKeyEx.D4);
            AddKey(327680u, '4', Cosmos.System.ConsoleKeyEx.D5);
            AddKey(6u, '(', Cosmos.System.ConsoleKeyEx.D5);
            AddKey(393216u, '5', Cosmos.System.ConsoleKeyEx.D5);
            AddKey(7u, '-', Cosmos.System.ConsoleKeyEx.D6);
            AddKey(458752u, '6', Cosmos.System.ConsoleKeyEx.D6);
            AddKey(8u, '�', Cosmos.System.ConsoleKeyEx.D7);
            AddKey(524288u, '7', Cosmos.System.ConsoleKeyEx.NumDivide);
            AddKey(9u, '_', Cosmos.System.ConsoleKeyEx.D8);
            AddKey(589824u, '8', Cosmos.System.ConsoleKeyEx.D8);
            AddKey(10u, '�', Cosmos.System.ConsoleKeyEx.D9);
            AddKey(655360u, '9', Cosmos.System.ConsoleKeyEx.D9);
            AddKey(11u, '�', Cosmos.System.ConsoleKeyEx.D0);
            AddKey(720896u, '0', Cosmos.System.ConsoleKeyEx.D0);

            // + * # ' - _
            AddKey(27u, '$', Cosmos.System.ConsoleKeyEx.NumPlus);
            AddKey(1769472u, '�', Cosmos.System.ConsoleKeyEx.NumMultiply);
            AddKey(43u, '#', Cosmos.System.ConsoleKeyEx.NoName);
            AddKey(2555904u, '\'', Cosmos.System.ConsoleKeyEx.NoName);
            AddKey(53u, '-', Cosmos.System.ConsoleKeyEx.NumMinus);
            AddKey(3473408u, '_', Cosmos.System.ConsoleKeyEx.NumMinus);

            // ; , : .
            AddKey(50u, ',', Cosmos.System.ConsoleKeyEx.Comma);
            AddKey(3342336u, '.', Cosmos.System.ConsoleKeyEx.Comma);
            AddKey(51u, ';', Cosmos.System.ConsoleKeyEx.Comma);
            AddKey(3407872u, '/', Cosmos.System.ConsoleKeyEx.Period);
            AddKey(52u, ':', Cosmos.System.ConsoleKeyEx.Period);

            // < > | ~
            // -- DOES NOT EXIST
            // -- DOES NOT EXIST
            // -- DOES NOT EXIST
            AddKey(27u, '�', Cosmos.System.ConsoleKeyEx.NumPlus);

            // Special keys
            AddKeyWithShift(14u, '?', Cosmos.System.ConsoleKeyEx.Backspace);
            AddKeyWithShift(15u, '\t', Cosmos.System.ConsoleKeyEx.Tab);
            AddKeyWithShift(28u, '\n', Cosmos.System.ConsoleKeyEx.Enter);
            AddKeyWithShift(57u, ' ', Cosmos.System.ConsoleKeyEx.Spacebar);
            AddKeyWithShift(75u, '?', Cosmos.System.ConsoleKeyEx.LeftArrow);
            AddKeyWithShift(72u, '?', Cosmos.System.ConsoleKeyEx.UpArrow);
            AddKeyWithShift(77u, '?', Cosmos.System.ConsoleKeyEx.RightArrow);
            AddKeyWithShift(80u, '?', Cosmos.System.ConsoleKeyEx.DownArrow);
            AddKeyWithShift(91u, Cosmos.System.ConsoleKeyEx.LWin);
            AddKeyWithShift(92u, Cosmos.System.ConsoleKeyEx.RWin);
            AddKeyWithShift(82u, Cosmos.System.ConsoleKeyEx.Insert);
            AddKeyWithShift(71u, Cosmos.System.ConsoleKeyEx.Home);
            AddKeyWithShift(73u, Cosmos.System.ConsoleKeyEx.PageUp);
            AddKeyWithShift(83u, Cosmos.System.ConsoleKeyEx.Delete);
            AddKeyWithShift(79u, Cosmos.System.ConsoleKeyEx.End);
            AddKeyWithShift(81u, Cosmos.System.ConsoleKeyEx.PageDown);
            AddKeyWithShift(55u, Cosmos.System.ConsoleKeyEx.PrintScreen);
            AddKeyWithShift(69u, Cosmos.System.ConsoleKeyEx.PauseBreak);
            AddKeyWithShift(59u, Cosmos.System.ConsoleKeyEx.F1);
            AddKeyWithShift(60u, Cosmos.System.ConsoleKeyEx.F2);
            AddKeyWithShift(61u, Cosmos.System.ConsoleKeyEx.F3);
            AddKeyWithShift(62u, Cosmos.System.ConsoleKeyEx.F4);
            AddKeyWithShift(63u, Cosmos.System.ConsoleKeyEx.F5);
            AddKeyWithShift(64u, Cosmos.System.ConsoleKeyEx.F6);
            AddKeyWithShift(65u, Cosmos.System.ConsoleKeyEx.F7);
            AddKeyWithShift(66u, Cosmos.System.ConsoleKeyEx.F8);
            AddKeyWithShift(67u, Cosmos.System.ConsoleKeyEx.F9);
            AddKeyWithShift(68u, Cosmos.System.ConsoleKeyEx.F10);
            AddKeyWithShift(87u, Cosmos.System.ConsoleKeyEx.F11);
            AddKeyWithShift(88u, Cosmos.System.ConsoleKeyEx.F12);
            AddKeyWithShift(1u, Cosmos.System.ConsoleKeyEx.Escape);

            // � ? \
            // -- Not yet implemented

            // Other keys
            AddKeyWithShift(76u, '5', Cosmos.System.ConsoleKeyEx.Num5);
            #endregion
            //ChangeKeyMap();
        }
    }
}