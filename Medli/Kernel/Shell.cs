using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Sys = Cosmos.System;
using Cosmos.System.FileSystem.VFS;
using Medli.Common;
using Medli.System;
using Medli.Applications;

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
            
            if (cmd == "")
            {

            }

            #region Shell Specifics
            else if (cmd.StartsWith("echo "))
            {
                //Applications.echo.Main(args);
                Console.WriteLine(cmdCI_args[1]);
            }
            else if (cmd == "pause")
            {
                Extensions.PressAnyKey();
            }
            else if (cmd.StartsWith("pause"))
            {
                Extensions.PressAnyKey(cmdCI_args[1]);
            }
            else if (cmd == "cls")
            {
                Console.Clear();
            }
            else if (cmd == "newshell")
            {
                Console.Clear();
                CommandConsole newConsole = new CommandConsole();
                newConsole.Initialize();
            }
            #endregion

            #region Filesystem
            else if (cmd == "cd ..")
            {
                FS.CDP();
            }
            else if (cmd == "list_vols")
            {
                FS.ListVols();
            }
            else if (cmd == "list_vol")
            {
                FS.ListVol();
            }
            else if (cmd.StartsWith("cd "))
            {
                FS.cd(cmdCI.Remove(0, 3));
            }
            else if (cmd == "dir")
            {
                FS.Dir();
            }
            else if (cmd.StartsWith("dir "))
            {
                FS.Dir(cmdCI_args[1]);
            }
            else if (cmd.StartsWith("copy "))
            {
                if (File.Exists(cmdCI_args[1]))
                {
                    File.Copy(Paths.CurrentDirectory + cmdCI_args[1], cmdCI_args[2]);
                }
                else
                {
                    Console.WriteLine("File does not exist");
                }
            }
            else if (cmd.StartsWith("mv"))
            {
                FS.mv(Paths.CurrentDirectory + cmdCI_args[1], cmdCI_args[2]);
            }
            else if (cmd.StartsWith("rm "))
            {
                if (cmd_args[1] == "-r")
                {
                    FS.del(cmdCI.Remove(0, 6), true);
                }
                else
                {
                    FS.del(cmdCI.Remove(0, 3), false);
                }
            }
            else if (cmd.StartsWith("mkdir"))
            {
                FS.Makedir(Directory.GetCurrentDirectory() + cmdCI_args[1]);
            }
            #endregion

            #region User Variables
            else if (cmd.StartsWith("echo $"))
            {
                Console.WriteLine(usr_vars.Retrieve(cmdCI.Remove(0, 6)));
            }
            else if (cmd == "savevars")
            {
                //Console.WriteLine("Dictionaries not yet implemented!");
                usr_vars.SaveVars();
            }
            else if (cmd == "loadvars")
            {
                //Console.WriteLine("Dictionaries not yet implemented!");
                usr_vars.ReadVars();
            }
            else if (cmd.StartsWith("$"))
            {
                //Console.WriteLine("Dictionaries not yet implemented!");
                usr_vars.Store(cmdCI_args[0].Remove(0, 1), cmdCI_args[1]);
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
            else if (cmd == "panic")
            {

                new Medli.Apps.Panic().Execute("");
            }
            else if (cmd == "shutdown")
            {
                usr_vars.SaveVars();
                Sys.Power.Shutdown();
            }
            else if (cmd == "cpu_flags")
            {
                //CPUInfo.ListFlags();
            }
            else if (cmd == "cpu_info")
            {
                //CPUInfo.LSCPU();
            }
            else if (cmd == "reboot")
            {
                usr_vars.SaveVars();
                Sys.Power.Reboot();
            }
            else if (cmd == "meminfo")
            {
                SystemFunctions.PrintTotalRAM();
            }
            else if (cmd == "licence")
            {
                Console.WriteLine("");
            }
            else if (cmd == "time")
            {
                Time.printTime();
            }
            else if (cmd == "date")
            {
                Time.printDate();
            }
            else if (cmd == "host")
            {
                Console.WriteLine(Kernel.Host);
            }
            else if (cmd == "lspci")
            {
                SystemFunctions.lspci();
            }
            else if (cmd == "ram_info")
            {
                SystemFunctions.PrintInfo();
            }
            else if (cmd == "ram_used")
            {
                SystemFunctions.PrintUsedRAM();
            }
            else if (cmd == "ram_free")
            {
                SystemFunctions.PrintFreeRAM();
            }
            else if (cmd == "ram_total")
            {
                SystemFunctions.PrintTotalRAM();
            }
            #endregion

            #region User Utilities
            else if (cmd == "help help")
            {
                //Applications.help.RunHelp();
            }
            else if (cmd == "cowsay")
            {
                Cowsay.Cow("Say something using 'Cowsay <message>'");
                Console.WriteLine(@"You can also use 'cowsay -f' tux for penguin, cow for cow and 
sodomized-sheep for, you guessed it, a sodomized-sheep");
            }
            else if (cmd.StartsWith("cowsay"))
            {
                if (cmd_args[1] == "-f")
                {
                    if (cmd_args[2] == "cow")
                    {
                        Cowsay.Cow(cmd.Remove(0, cmd_args[0].Length + cmd_args[1].Length + cmd_args[2].Length + 3));
                    }
                    else if (cmd_args[2] == "tux")
                    {
                        Cowsay.Tux(cmd.Remove(0, cmd_args[0].Length + cmd_args[1].Length + cmd_args[2].Length + 3));
                    }
                    else if (cmd_args[2] == "sodomized-sheep")
                    {
                        Cowsay.SodomizedSheep(cmd.Remove(0, cmd_args[0].Length + cmd_args[1].Length + cmd_args[2].Length + 3));
                    }
                }
                else
                {
                    Cowsay.Cow(cmd.Substring(7));
                }
            }
            else if (cmd.StartsWith("cedit "))
            {
                Cpedit.Run(cmd_args[1]);
            }
            else if (cmd.StartsWith("devenv "))
            {
                if (cmd.EndsWith(".ma"))
                {
                    MIDE.Run(cmd_args[1]);
                }
                else
                {
                    Console.WriteLine("The IDE may only be used to create (.ma) Medli application files.");
                }
            }
            else if (cmd == "cview")
            {
                Console.WriteLine("cview Usage: cview <file>");
            }
            else if (cmd.StartsWith("cview "))
            {
                Cpview.ViewFile(cmd_args[1]);
            }
            else if (cmd.StartsWith("launch "))
            {
                Console.Clear();
                AppLauncher.PreExecute(cmd_args[1]);
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
            else if (cmd.StartsWith("miv "))
            {
                MIV.StartMIV(cmd_args[1]);
            }
            else if (cmd == "miv")
            {
                MIV.StartMIV();
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
			
			else if (command == "print vars")
			{

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
