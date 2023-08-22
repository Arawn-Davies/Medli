using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Medli.System
{
	/*
	
	Directory Information class
	Methods created by Alexy DA CRUZ <dacruzalexy@gmail.com & Valentin Charbonnier <valentInBreiz@gmail.com>
	This code is released under the BSD-3 Clause Licence as part of the Aura Operating System project
	https://github.com/aura-systems/Aura-Operating-System/

	*/
    class DirectoryInformation
    {
		public static void ShowDirectories(string path)
		{
			foreach (string dir in Directory.GetDirectories(path))
			{
				if (!dir.StartsWith("."))
				{
					Console.WriteLine("<DIR>\t" + dir);
				}
			}
		}

		public static void ShowFiles(string path)
		{
			foreach (string file in Directory.GetFiles(path))
			{
				Char dot = '.';
				string[] exts = file.Split(dot);
				string lastext = exts[exts.Length - 1];
				//FileInfo info = new FileInfo(file);
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("<" + lastext + ">\t" + file);
				//((file.Length / 1024) / 1024) + "MBs")
				Console.ForegroundColor = ConsoleColor.White;
			}
		}
    }
}
