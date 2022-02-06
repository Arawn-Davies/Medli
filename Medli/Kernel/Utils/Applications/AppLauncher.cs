using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Medli.Apps
{
    /// <summary>
    /// Class definition for AppLauncher
    /// </summary>
    /// <seealso cref="Medli.Apps.Command" />
    class AppLauncher : Command
    {
        /// <summary>
        /// Gets the name of the command.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public override string Name
		{
			get
			{
				return "launch";
			}
		}

        /// <summary>
        /// Gets the summary for the command.
        /// </summary>
        public override string Summary
		{
			get
			{
				return "Launches an .ma Medli Application";
			}
		}

        /// <summary>
        /// Executes the specified parameter.
        /// </summary>
        /// <param name="param">The parameter.</param>
        public override void Execute(string param)
		{
			Console.Clear();
			PreExecute(param);
		}

        /// <summary>
        /// The application title
        /// </summary>
        public static string AppTitle;

        /// <summary>
        /// The application description
        /// </summary>
        public static string AppDesc;

        /// <summary>
        /// The application author
        /// </summary>
        public static string AppAuthor;

        /// <summary>
        /// the application information.
        /// </summary>
        /// <param name="file">The file.</param>
        public static void AppInfo(string file)
        {
            title(file);
            desc(file);
            author(file);
        }

        /// <summary>
        /// the author of the application.
        /// </summary>
        /// <param name="file">The file.</param>
        private static void author(string file)
        {
            string[] readlines = File.ReadAllLines(file);
            Console.WriteLine("Application Author:");
            AppAuthor = readlines[2].Substring(7);
            Console.WriteLine(AppAuthor);
        }

        /// <summary>
        /// the description of the application.
        /// </summary>
        /// <param name="file">The file.</param>
        private static void desc(string file)
        {
            string[] readlines = File.ReadAllLines(file);
            Console.WriteLine("Application Description:");
            AppDesc = readlines[1].Substring(5);
            Console.WriteLine(AppDesc);
        }
        /// <summary>
        /// the application title.
        /// </summary>
        /// <param name="file">The file.</param>
        private static void title(string file)
        {
            string[] readlines = File.ReadAllLines(file);
            Console.WriteLine("Application Title:");
            AppTitle = readlines[0].Substring(6);
            Console.WriteLine(AppTitle);
        }
        /// <summary>
        /// CHecks that the file is a valid Medli Application .ma file
        /// </summary>
        /// <param name="file">The file.</param>
        public static void PreExecute(string file)
        {
            if (file.EndsWith(".ma"))
            {
                Verify(file);
            }
            else
            {
                Console.WriteLine("Not a valid Medli Application!");
                Console.WriteLine("Medli Application filenames end in .ma");
            }
        }

        /// <summary>
        /// Verifies the specified file.
        /// </summary>
        /// <param name="file">The file.</param>
        private static void Verify(string file)
        {
            List<string> readlines = new List<string>();
            var lines = File.ReadAllLines(file);
            foreach (var line in lines) readlines.Add(line);
            if (readlines[0].StartsWith("Title="))
            {
                if (readlines[1].StartsWith("Desc="))
                {
                    if (readlines[2].StartsWith("Author="))
                    {
                        if (readlines[readlines.Count - 1].StartsWith("EOF"))
                        {
                            ExecuteApp(file);
                        }
                        else
                        {
                            Console.WriteLine("EOF expected: Valid Medli Applications finish with EOF");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Author expected: No author information on line 3");
                    }
                }
                else
                {
                    Console.WriteLine("Description expected: No application description on line 2");
                }
            }
            else
            {
                Console.WriteLine("Title expected: No application title on line 1");
            }
        }

        /// <summary>
        /// Draws a clear window
        /// </summary>
        private static void ClearDraw()
        {
            Console.CursorTop = 1;
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.WriteLine(AppTitle);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorTop = 3;
        }
        /// <summary>
        /// Executes the application.
        /// </summary>
        /// <param name="file">The file.</param>
        private static void ExecuteApp(string file)
        {
            string[] readlines = File.ReadAllLines(file);
            AppTitle = readlines[0].Substring(6);
            AppDesc = readlines[1].Substring(5);
            AppAuthor = readlines[2].Substring(7);
            ClearDraw();
            foreach (string line in readlines)
            {
                if (line.StartsWith("Title="))
                {
                    AppTitle = line.Remove(0, 6);
                }
                else if (line.StartsWith("Desc="))
                {
                    AppDesc = line.Remove(0, 5);
                }
                else if (line.StartsWith("Author="))
                {
                    AppAuthor = line.Remove(0, 7);
                }
                else if (line == "clear")
                {
                    ClearDraw();
                }
                else if (line == "EOF")
                {

                }
                else
                {
                    if (Console.CursorTop == 23)
                    {
                        ClearDraw();
                    }
                    CommandConsole.Parse(line);
                }
            }
        }
    }
}
