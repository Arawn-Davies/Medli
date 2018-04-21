using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cosmos.Debug.Kernel;
using Medli.Hardware;
using Medli.System.ScanMaps;

using MyConsole = System.Console;

namespace Medli.System
{
    public static class KeyboardManager
    {
        public static bool NumLock
        {
            get;
            set;
        }

        public static bool CapsLock
        {
            get;
            set;
        }

        public static bool ScrollLock
        {
            get;
            set;
        }

        public static bool ControlPressed
        {
            get;
            set;
        }

        public static bool ShiftPressed
        {
            get;
            set;
        }

        public static bool AltPressed
        {
            get;
            set;
        }

        private static List<KeyboardBase> mKeyboardList = new List<KeyboardBase>();
        private static ScanMapBase mScanMap = new US_Standard();
        private static Queue<KeyEvent> mQueuedKeys = new Queue<KeyEvent>();

        static KeyboardManager()
        {
            AddKeyboard((PS2Keyboard)HAL.PS2Controller.FirstDevice);
        }

        private static void Enqueue(KeyEvent keyEvent)
        {
            mQueuedKeys.Enqueue(keyEvent);
        }

        /// <summary>
        /// Allow faking scancodes. Used for test kernels
        /// </summary>
        internal static void HandleFakeScanCode(byte aScancode, bool aReleased)
        {
            HandleScanCode(aScancode, aReleased);
        }

        private static void HandleScanCode(byte aScanCode, bool aReleased)
        {
            byte key = aScanCode;
            if (mScanMap.ScanCodeMatchesKey(key, ConsoleKeyEx.CapsLock) && !aReleased)
            {
                // caps lock
                CapsLock = !CapsLock;
                UpdateLeds();
            }
            else if (mScanMap.ScanCodeMatchesKey(key, ConsoleKeyEx.NumLock) && !aReleased)
            {
                // num lock
                NumLock = !NumLock;
                UpdateLeds();
            }
            else if (mScanMap.ScanCodeMatchesKey(key, ConsoleKeyEx.ScrollLock) && !aReleased)
            {
                // scroll lock
                ScrollLock = !ScrollLock;
                UpdateLeds();
            }
            else if (mScanMap.ScanCodeMatchesKey(key, ConsoleKeyEx.LCtrl) || mScanMap.ScanCodeMatchesKey(key, ConsoleKeyEx.RCtrl))
            {
                ControlPressed = !aReleased;
            }
            else if (mScanMap.ScanCodeMatchesKey(key, ConsoleKeyEx.LShift) || mScanMap.ScanCodeMatchesKey(key, ConsoleKeyEx.RShift))
            {
                ShiftPressed = !aReleased;
            }
            else if (mScanMap.ScanCodeMatchesKey(key, ConsoleKeyEx.LAlt) || mScanMap.ScanCodeMatchesKey(key, ConsoleKeyEx.RAlt))
            {
                AltPressed = !aReleased;
            }
            else
            {
                if (ControlPressed && AltPressed && mScanMap.ScanCodeMatchesKey(key, ConsoleKeyEx.Delete))
                {
                    MyConsole.WriteLine("Detected Ctrl-Alt-Delete!");
                    //Power.Reboot();
                    MyConsole.WriteLine("Not yet implemented!");
                }
				if (ControlPressed && AltPressed && mScanMap.ScanCodeMatchesKey(key, ConsoleKeyEx.F1))
				{
					SysConsole.WriteLine("");
				}
				if (ControlPressed && AltPressed && mScanMap.ScanCodeMatchesKey(key, ConsoleKeyEx.F2))
				{
					SysConsole.WriteLine("");
				}
				if (ControlPressed && AltPressed && mScanMap.ScanCodeMatchesKey(key, ConsoleKeyEx.F3))
				{
					SysConsole.WriteLine("");
				}
				if (ControlPressed && AltPressed && mScanMap.ScanCodeMatchesKey(key, ConsoleKeyEx.F4))
				{
					SysConsole.WriteLine("");
				}

				if (!aReleased)
                {
                    KeyEvent keyInfo;

                    if (GetKey(key, out keyInfo))
                    {
                        Enqueue(keyInfo);
                    }
                }
            }
        }

        private static void UpdateLeds()
        {
            foreach (KeyboardBase keyboard in mKeyboardList)
            {
                keyboard.UpdateLeds();
            }
        }

        public static bool GetKey(byte aScancode, out KeyEvent keyInfo)
        {
            if (mScanMap == null)
            {

            }

            keyInfo = mScanMap.ConvertScanCode(aScancode, ControlPressed, ShiftPressed, AltPressed, NumLock, CapsLock, ScrollLock);

            return keyInfo != null;
        }

        public static bool TryReadKey(out KeyEvent oKey)
        {
            if (mQueuedKeys.Count > 0)
            {
                oKey = mQueuedKeys.Dequeue();
                return true;
            }

            oKey = default(KeyEvent);

            return false;
        }

        public static KeyEvent ReadKey()
        {
            while (mQueuedKeys.Count == 0)
            {
                KeyboardBase.WaitForKey();
            }

            return mQueuedKeys.Dequeue();
        }

        public static ScanMapBase GetKeyLayout()
        {
            return mScanMap;
        }

        public static void SetKeyLayout(ScanMapBase aScanMap)
        {
            if (aScanMap != null)
            {
                mScanMap = aScanMap;
            }
        }

        public static void AddKeyboard(KeyboardBase aKeyboard)
        {
            aKeyboard.OnKeyPressed = HandleScanCode;
            mKeyboardList.Add(aKeyboard);
        }
    }
}