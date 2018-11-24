using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Sys = Cosmos.System;
using Cosmos.System.FileSystem.VFS;
using Medli.Common;
using Medli.System;
using Medli.Applications;
using Medli.Apps;

namespace Medli
{
    public class Shell
    {
        public static void Prompt(string cmdline)
        {
            // String variables of the parameters for shell loop:
            var cmd = cmdline.ToLower();
            var cmdCI = cmdline;
            // String arrays from the splitting of the shell loop parameter:
            string[] cmd_args = cmd.Split(' ');
            string[] cmdCI_args = cmdCI.Split(' ');      

            #region Filesystem
            if (cmd == "list_vols")
            {
                FS.ListVols();
            }
            else if (cmd == "list_vol")
            {
                FS.ListVol();
            }
            #endregion

            #region User Variables
            else if (cmd.StartsWith("echo $"))
            {
                Console.WriteLine(usr_vars.Retrieve(cmd_args[1].Substring(1)));
            }
            else if (cmd == "save$")
            {
                usr_vars.SaveVars();
            }
            else if (cmd == "load$")
            {
                usr_vars.ReadVars();
            }
            else if (cmd == "print$")
            {
                usr_vars.PrintVars();
            }

            #endregion

            #region System Utilities
            else if (cmd == "fdisk")
            {
                FS.MFSU();
            }
            else if (cmd == "test_serial")
            {
                //Hardware.HAL.COM2.WriteLine("Hello, World!");
            }
            else if (cmd == "licence")
            {
                Console.WriteLine("");
            }

            #endregion

            #region User Utilities
            else if (cmd.StartsWith("cedit "))
            {
                
            }
            else if (cmd.StartsWith("devenv "))
            {
                
            }
            else if (cmd == "cview")
            {
                Console.WriteLine("cview Usage: cview <file>");
            }
            else if (cmd.StartsWith("cview "))
            {
                
            }
            else if (cmd.StartsWith("run "))
            {
                if (!File.Exists(Paths.CurrentDirectory + @"\" + cmd_args[1]))
                {
                    InvalidCommand(cmd.Remove(0, 4), 2);
                }
                else
                {
                    Mdscript.Execute(Paths.CurrentDirectory + @"\" + cmd_args[1]);
                }
            }
            
            #endregion

			else
            {
                InvalidCommand(cmdCI, 1);
            }

        }

        public static void InvalidCommand(string args, int errorlvl)
        {
            if (errorlvl == 1)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(args);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" is not a valid command, see 'help' for a list of commands");
            }
            else if (errorlvl == 2)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("The file ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(args);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" could not be found!");

            }
            else if (errorlvl == 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (errorlvl == 4)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }
        }
    }
}
			/*
			else if (command == "tui")
			{
				TUI.TUI.Run();
				Console.Clear();
				Console.WriteLine("TUI Session closed. Press any key to continue...");
				Console.ReadKey(true);
			}
			
			
			else if (command == "umc")
			{
				Internals.UserManagementConsole.Run();
			}
			else if (command.StartsWith("edit "))
			{
				Apps.TextEditor.Run(cmdCI_args[1]);
			}
			else if (command == "edit")
			{
				Console.WriteLine("Usage: edit <filename>");
				Console.WriteLine("Launches the text editor using the filename specified");
			}
			
			else if (command.StartsWith("cv "))
			{
				Apps.TextViewer.Run(cmdCI_args[1]);
			}
			else if (command == "help")
			{
				Apps.Help.Run();
			}
			
			else if (command.StartsWith("help "))
			{
				Apps.Help.Specific(cmd_args[1]);
			}


			*/
