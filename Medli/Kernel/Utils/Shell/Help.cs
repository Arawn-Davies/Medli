using System;
using System.Collections.Generic;
using System.Text;
using AIC.Main.Extensions;

namespace Medli.Apps
{
	public class HelpCommand : Command
	{
		public override string Name
		{
			get { return "help"; }
		}

		public HelpCommand(List<Command> commands)
		{
			_commands = commands;
		}

		private List<Command> _commands;

		public override void Execute(string param)
		{
			if (param.CompareTo("") == 0)
				DisplayCommands();
			else if (param == "pause")
            {
				DisplayPage_Pause();
            }
			else
				CommandHelp(param);
		}

		private void CommandHelp(string command)
		{
			bool found = false;
			for (int i = 0; i < _commands.Count; i++)
			{
				if (_commands[i].Name.CompareTo(command) == 0)
				{
					found = true;
					_commands[i].Help();
					Console.WriteLine();
					break;
				}
			}

			if (!found)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.Write("The command ");
				Console.Write(command);
				Console.WriteLine(" is not supported. Please type help for more information.");
				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine();
			}
		}

		private void DisplayCommands()
		{
			Console.WriteLine("Supported Commands:");
			for (int i = 0; i < _commands.Count; i++)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.Write("  ");
				Console.Write(_commands[i].Name);
				Console.Write(":  ");
				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine(_commands[i].Summary);
			}
			Console.WriteLine("Please type help [command] for more information.");
			Console.WriteLine();

		}

        private void DisplayPage_Pause()
        {
			int lines = 0;
            for (int i = 0; i < _commands.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("  ");
                Console.Write(_commands[i].Name);
                Console.Write(":  ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(_commands[i].Summary);
				lines++;
				if (lines == 15)
                {
					KernelExtensions.PressAnyKey();
					lines = 0;
					Console.Clear();
                }
            }
        }

        public override void Help()
		{
			Console.WriteLine("help [command]");
			Console.WriteLine("  Gets help on a specific command.");
			Console.WriteLine("  [command]:The command to look up.");
		}

		public override string Summary
		{
			get { return "Gets help on a specific command."; }
		}
	}
}
