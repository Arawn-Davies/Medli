using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Sys = Cosmos.System;
using Cosmos.System.FileSystem.VFS;
using Medli.Common;
using Medli.System;

namespace Medli.Kernel
{
    class Shell
    {
		public static void prompt(string cmdline)
		{
			var command = cmdline.ToLower();
			var cmdCI = cmdline;
			string[] cmdCI_args = cmdline.Split(' ');
			string[] cmd_args = command.Split(' ');
			if (command == "clear")
			{
				Console.Clear();
			}
			else if (command.StartsWith("echo $"))
			{
				//Console.WriteLine(usr_vars.Retrieve(cmdCI.Remove(0, 6)));
			}
			else if (cmdline.StartsWith("echo "))
			{
				Console.WriteLine(cmdCI_args[1]);
			}
			else if (command == "panic")
			{
				var xCtx = new Cosmos.Core.INTs.IRQContext();
				Core.INTs.HandleInterrupt_00(ref xCtx);
				//int a = 10 / 2;
				//int b = a / 0;
				Console.WriteLine("This shouldn't print!");
			}
			/*else if (command.StartsWith("mv"))
			{
				fsfunc.mv(KernelVariables.currentdir + cmdCI_args[1], cmdCI_args[2]);
			}
			else if (command == "tui")
			{
				TUI.TUI.Run();
				Console.Clear();
				Console.WriteLine("TUI Session closed. Press any key to continue...");
				Console.ReadKey(true);
			}
			else if (command == "cowsay")
			{
				Apps.Cowsay.Cow("Say something using 'Cowsay <message>'");
				Console.WriteLine(@"You can also use 'cowsay -f' tux for penguin, cow for cow and 
sodomized-sheep for, you guessed it, a sodomized-sheep");
			}
			else if (command.StartsWith("cowsay"))
			{
				Apps.Cowsay.Run(cmdCI_args);
			}
			else if (command == "print vars")
			{

			}
			else if (command == "umc")
			{
				Internals.UserManagementConsole.Run();
			}
			else if (command.StartsWith("$"))
			{
				//Console.WriteLine("Dictionaries not yet implemented!");
				usr_vars.Store(cmdCI_args[0].Remove(0, 1), cmdCI_args[1]);
			}
			else if (command.StartsWith("run "))
			{
				if (!File.Exists(KernelVariables.currentdir + cmdCI_args[1]))
				{
					Console.WriteLine("File doesn't exist!");
				}
				else
				{
					Apps.ApolloScript.Run(KernelVariables.currentdir + cmdCI_args[1]);
				}
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
			else if (command.StartsWith("mkdir"))
			{
				fsfunc.mkdir(KernelVariables.currentdir + cmdCI_args[1], false);
			}
			else if (command.StartsWith("cv "))
			{
				Apps.TextViewer.Run(cmdCI_args[1]);
			}
			else if (command == "miv")
			{
				Apps.MIV.Run();
			}
			else if (command.StartsWith("miv "))
			{
				Apps.MIV.Run(cmdCI.Remove(0, 4));
			}
			else if (command.StartsWith("copy "))
			{
				if (File.Exists(cmdCI_args[1]))
				{
					File.Copy(KernelVariables.currentdir + cmdCI_args[1], cmdCI_args[2]);
				}
				else
				{
					Console.WriteLine("File does not exist");
				}
			}
			else if (command == "cd ..")
			{
				fsfunc.CDP();
			}
			else if (command.StartsWith("cd "))
			{
				fsfunc.cd(cmdCI.Remove(0, 3));
			}
			else if (command == "dir")
			{
				fsfunc.dir();
			}
			else if (command.StartsWith("dir "))
			{
				fsfunc.dir(cmdCI_args[1]);
			}
			else if (command == "help")
			{
				Apps.Help.Run();
			}
			*/
			else if (command == "shutdown")
			{
				//Console.WriteLine("Dictionaries not yet implemented!");
				//usr_vars.SaveVars();
				Sys.Power.Shutdown();
			}
			
			else if (command == "reboot")
			{
				//Console.WriteLine("Dictionaries not yet implemented!");
				//usr_vars.SaveVars();
				Sys.Power.Reboot();
			}
			/*
			else if (command == "savevars")
			{
				//Console.WriteLine("Dictionaries not yet implemented!");
				usr_vars.SaveVars();
			}
			else if (command == "loadvars")
			{
				//Console.WriteLine("Dictionaries not yet implemented!");
				usr_vars.ReadVars();
			}
			else if (command.StartsWith("help "))
			{
				Apps.Help.Specific(cmd_args[1]);
			}
			else if (command == "pause")
			{
				Environment_variables.PressAnyKey();
			}
			else if (command.StartsWith("rm "))
			{
				if (cmd_args[1] == "-r")
				{
					fsfunc.del(cmdCI.Remove(0, 6), true);
				}
				else
				{
					fsfunc.del(cmdCI.Remove(0, 3), false);
				}
			}
			*/
			else if (command == "meminfo")
			{
				CoreInfo.PrintTotalRAM();
			}
			else if (command == "licence")
			{
				Console.WriteLine("");
			}
			else if (command == "time")
			{
				MedliTime.printTime();
			}
			else if (command == "date")
			{
				MedliTime.printDate();
			}
			else if (command == "host")
			{
				Console.WriteLine(KernelProperties.Host);
			}
			else if (command == "")
			{

			}
			else
			{
				Console.WriteLine("Invalid command: " + cmdCI);
			}
		}
	}
}
