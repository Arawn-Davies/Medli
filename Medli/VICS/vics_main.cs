using static System.Net.Mime.MediaTypeNames;
using System;

namespace Medli
{
    public partial class vics
    {
        /// <summary>
        /// Open VICS using specified filename
        /// </summary>
        /// <param name="preText"></param>
        /// <returns></returns>
        public static String VICS(String start)
        {
            Boolean editMode = false;
            _openNextFile = false;
            _fileNeedsToBeSaved = false;

            int pos = 0;
            char[] chars = new char[2000];
            String infoBar = String.Empty;
            _text = String.Empty;

            if (start == null)
            {
                VICSStartScreen();
            }
            else
            {
                pos = start.Length;

                for (int i = 0; i < start.Length; i++)
                {
                    chars[i] = start[i];
                }
                RefreshScreen(chars, pos, infoBar, editMode);
            }

            ConsoleKeyInfo keyInfo;

            while (true)
            {
                keyInfo = Console.ReadKey(true);

                if (isForbiddenKey(keyInfo.Key)) continue;

                #region MenuMode
                else if (!editMode && keyInfo.KeyChar == ':')
                {
                    infoBar = ":";
                    RefreshScreen(chars, pos, infoBar, editMode);
                    while (keyInfo.Key != ConsoleKey.Escape)
                    {
                        keyInfo = Console.ReadKey(true);
                        if (keyInfo.Key == ConsoleKey.Enter)
                        {
                            if (infoBar == ":wq" || infoBar == ":save" || infoBar == ":s")
                            {
                                _fileNeedsToBeSaved = true;
                                _text = String.Empty;
                                for (int i = 0; i < pos; i++)
                                {
                                    _text += chars[i];
                                }
                                return _text;

                            }
                            else if (infoBar == ":q" || infoBar == ":quit" || infoBar == ":exit" || infoBar == ":e")
                            {
                                _fileNeedsToBeSaved = false;
                                return _text;

                            }
                            else if (infoBar == ":help" || infoBar == ":h")
                            {
                                VICSStartScreen();
                                break;
                            }
                            else if (infoBar == ":o" || infoBar == ":open")
                            {

                                // Close this file (and instance), and set the 'open' flag to true, to enable opening of next file
                                _openNextFile = true;

                                return _text;
                            }

                            else
                            {
                                infoBar = "ERROR: No such command";
                                RefreshScreen(chars, pos, infoBar, editMode);
                                break;
                            }
                        }
                        else if (keyInfo.Key == ConsoleKey.Backspace)
                        {
                            infoBar = stringCopy(infoBar);
                            RefreshScreen(chars, pos, infoBar, editMode);
                        }

                        #region HandleMenuChars
                        else if (keyInfo.KeyChar == 'a')
                        {
                            infoBar += 'a';
                        }
                        else if (keyInfo.KeyChar == 'e')
                        {
                            infoBar += "e";
                        }
                        else if (keyInfo.KeyChar == 'h')
                        {
                            infoBar += "h";
                        }
                        else if (keyInfo.KeyChar == 'i')
                        {
                            infoBar += 'i';
                        }
                        else if (keyInfo.KeyChar == 'l')
                        {
                            infoBar += "l";
                        }
                        else if (keyInfo.KeyChar == 'n')
                        {
                            infoBar += 'n';
                        }
                        else if (keyInfo.KeyChar == 'o')
                        {
                            infoBar += "o";
                        }
                        else if (keyInfo.KeyChar == 'p')
                        {
                            infoBar += "p";
                        }
                        else if (keyInfo.KeyChar == 'q')
                        {
                            infoBar += "q";
                        }
                        else if (keyInfo.KeyChar == 's')
                        {
                            infoBar += 's';
                        }
                        else if (keyInfo.KeyChar == 't')
                        {
                            infoBar += 't';
                        }
                        else if (keyInfo.KeyChar == 'u')
                        {
                            infoBar += 'u';
                        }

                        else if (keyInfo.KeyChar == 'v')
                        {
                            infoBar += 'v';
                        }
                        else if (keyInfo.KeyChar == 'w')
                        {
                            infoBar += "w";
                        }
                        else if (keyInfo.KeyChar == 'x')
                        {
                            infoBar += 'x';
                        }
                        else if (keyInfo.KeyChar == ':')
                        {
                            infoBar += ":";
                        }
                        #endregion

                        else
                        {
                            continue;
                        }
                        RefreshScreen(chars, pos, infoBar, editMode);



                    }
                }

                #endregion

                #region SwitchMode
                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    editMode = false;
                    infoBar = String.Empty;
                    RefreshScreen(chars, pos, infoBar, editMode);
                    continue;
                }
                else if (keyInfo.Key == ConsoleKey.I && !editMode)
                {
                    editMode = true;
                    infoBar = "-- INSERT --";
                    RefreshScreen(chars, pos, infoBar, editMode);
                    continue;
                }
                #endregion

                #region EditMode
                // Newline
                else if (keyInfo.Key == ConsoleKey.Enter && editMode && pos >= 0)
                {
                    chars[pos++] = '\n';
                    RefreshScreen(chars, pos, infoBar, editMode);
                    continue;
                }
                // Backspace
                else if (keyInfo.Key == ConsoleKey.Backspace && editMode && pos >= 0)
                {
                    if (pos > 0) pos--;

                    chars[pos] = '\0';

                    RefreshScreen(chars, pos, infoBar, editMode);
                    continue;
                }

                // If in edit mode, add typed character to screen
                if (editMode && pos >= 0)
                {
                    chars[pos++] = keyInfo.KeyChar;
                    RefreshScreen(chars, pos, infoBar, editMode);
                }
                #endregion

            }
        }
    }
}








