using System;
using System.Collections.Generic;
using System.Text;
using Medli.System.Framework;

namespace Medli.Apps
{
    /// <summary>
    /// Class definition for the 'help' command
    /// </summary>
    /// <seealso cref="Medli.Apps.Command" />
    public class HelpCommand : Command
	{
        /// <summary>
        /// Gets the name of the command.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public override string Name
		{
			get { return "help"; }
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="HelpCommand"/> class.
        /// </summary>
        /// <param name="commands">The commands.</param>
        public HelpCommand(List<Command> commands)
		{
			_commands = commands;
		}

        /// <summary>
        /// The commands
        /// </summary>
        private List<Command> _commands;

        /// <summary>
        /// Executes the specified parameter.
        /// </summary>
        /// <param name="param">The parameter.</param>
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

        /// <summary>
        /// Returns help about the specified command
        /// </summary>
        /// <param name="command">The command.</param>
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

        /// <summary>
        /// Displays the commands.
        /// </summary>
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

        /// <summary>
        /// Pauses output of the command to allow the user to catch all of the information, useful if not piping output to another file.
        /// </summary>
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
        /// <summary>
        /// Prints help for the 'help' command.
        /// </summary>
        public override void Help()
		{
			Console.WriteLine("help [command]");
			Console.WriteLine("  Gets help on a specific command.");
			Console.WriteLine("  [command]:The command to look up.");
		}

        /// <summary>
        /// Gets the summary for the command.
        /// </summary>
        public override string Summary
		{
			get { return "Gets help on a specific command."; }
		}
	}
}
