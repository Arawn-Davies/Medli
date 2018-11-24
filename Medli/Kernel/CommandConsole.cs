﻿using System;
using System.Collections.Generic;
using System.Text;
using Medli.Apps;
using Medli.System;

namespace Medli
{
    class CommandConsole
    {
		public CommandConsole()
		{
			Initialize();
		}

		private static List<Command> _commands = new List<Command>();

		private bool running = true;

		public void Stop()
		{
			running = false;
		}

		public void Initialize()
		{
			_commands.Add(new Clear());
			_commands.Add(new Dir());
			_commands.Add(new Echo());
			_commands.Add(new Exit(Stop));
			_commands.Add(new Panic());
			_commands.Add(new HelpCommand(_commands));
			_commands.Add(new Apps.Time());
			_commands.Add(new Date());
			_commands.Add(new Script());
			_commands.Add(new Apps.Version());
			_commands.Add(new Get());
			_commands.Add(new Reboot());
			_commands.Add(new Shutdown());
			_commands.Add(new mkdir());
			_commands.Add(new Multiscreen());
			_commands.Add(new Copy());
			_commands.Add(new Move());
			_commands.Add(new MIV());
			_commands.Add(new AppLauncher());
			_commands.Add(new MIDE());
			_commands.Add(new cd());
			_commands.Add(new Pause());
			_commands.Add(new Set());
			_commands.Add(new Cowsay());

			Console.Clear();
			Console.WriteLine("");

			while (running)
			{

				Console.Write(SystemFunctions.CurrentScreen + " /> ");
				string line = Console.ReadLine();
				if (string.IsNullOrEmpty(line)) { continue; }
				Parse(line);

			}
		}
		public static void Parse(string line)
		{
			int index = line.IndexOf(' ');
			string command;
			string param;
			if (index == -1)
			{
				command = line;
				param = "";
			}
			else
			{
				command = line.Substring(0, index);
				param = line.Substring(index + 1);
			}

			bool found = false;
			for (int i = 0; i < _commands.Count; i++)
			{
				if (_commands[i].Name == command)
				{
					found = true;
					_commands[i].Execute(param);
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
	}
}
