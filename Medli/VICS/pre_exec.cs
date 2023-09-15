using System;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using Medli.Common;
using Medli.System.Framework;


namespace Medli
{
	public partial class vics
    {
        private static String? _text = String.Empty;

        private static string _filename = String.Empty;

        public static string Filename { get { return _filename; } set { _filename = value; } }

        private static bool _running = true;

        private static bool _fileNeedsToBeSaved = false;

        private static bool _fileIsOpen;

        private static bool _openNextFile;

        public static void VICSStartScreen()
        {
            Console.Clear();
            Console.WriteLine("~");
            Console.WriteLine("~");
            Console.WriteLine("~");
            Console.WriteLine("~");
            Console.WriteLine("~");
            Console.WriteLine("~");
            Console.WriteLine("~");
            Console.WriteLine("~                              Vics - Vi for C Sharp");
            Console.WriteLine("~");
            Console.WriteLine("~                                  version 1.5");
            Console.WriteLine("~                                by Arawn Davies");
            Console.WriteLine("~");
            Console.WriteLine("~                     VICS is open source and freely distributable");
            Console.WriteLine("~");
            Console.WriteLine("~                     type :help                 for information");
            Console.WriteLine("~                     type :o or open            to open a text file");
            Console.WriteLine("~                     type :q or quit            to exit");
            Console.WriteLine("~                     type :wq                   save to file and exit");
            Console.WriteLine("~                     press i                    to write");
            Console.WriteLine("~");
            Console.WriteLine("~");
            Console.WriteLine("~");
            Console.WriteLine("~");
            Console.WriteLine("~");
            Console.Write("~");
        }

        /// <summary>
        /// Start VICS editor with specified filename
        /// The file will be created if it doesn't exist.
        /// </summary>
        /// <param name="filename"></param>
        public static void StartVICS(string filename)
        {
            Console.Clear();
            try
            {
                if (!File.Exists(Paths.CurrentDirectory + @"\" + filename))
                {
                    File.Create(Paths.CurrentDirectory + @"\" + filename).Dispose();
                }
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Append the filename with the current directory path
            _filename = Paths.CurrentDirectory + filename;

            _fileIsOpen = true;

            try
            {
                _text = VICS(File.ReadAllText(_filename));
                if (_openNextFile == true)
                {
                    OpenFile();
                }
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                KernelExtensions.PressAnyKey();
            }
            if (_text != null && _fileNeedsToBeSaved == true)
            {

                File.WriteAllText(_filename, _text);
                Console.WriteLine("Content has been saved to " + filename);
            }
        }
        /// <summary>
        /// No command line args
        /// </summary>
        public static void StartVICS()
        {
            Console.Clear();
            try
            {
                _running = true;
                _text = VICS(null);
                _running = false;
                if (_openNextFile == true)
                {
                    OpenFile();
                }
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                KernelExtensions.PressAnyKey();
            }

            if (_text != null && _fileNeedsToBeSaved == true)
            {

                if (_filename == Paths.CurrentDirectory || _filename == "" || _filename == null)
                {
                    // File hasn't previously been saved.
                    Console.WriteLine("Enter the filename to save: ");
                    string? filename = Console.ReadLine();
                    _filename = Paths.CurrentDirectory + filename;
                }

                File.WriteAllText(_filename, _text);
                Console.WriteLine("Content has been saved to " + _filename);
            }
        }

        public static void CreateFile()
        {
            Console.Clear();
            Console.Write("Enter filename to create: ");
            string? filename = Console.ReadLine();
            if (!File.Exists(Paths.CurrentDirectory + filename))
            {
                Console.WriteLine("Creating file!");
                File.Create(Paths.CurrentDirectory + filename).Dispose();
            }
            else
            {
                Console.WriteLine("File already exists!");
                Console.WriteLine("Would you like to open it?");
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key != ConsoleKey.Y)
                {
                    return;
                }
            }


            _filename = Paths.CurrentDirectory + filename;
            _fileIsOpen = true;
            _running = true;

            try
            {
                _text = VICS(File.ReadAllText(_filename));
                _running = false;
                if (_text != null && _fileNeedsToBeSaved == true)
                {
                    File.WriteAllText(_filename, _text);
                    Console.WriteLine("Content has been saved to " + _filename);
                }
            }
            catch (Exception ex)
            {
                _running = false;
                Console.WriteLine(ex.Message);
                KernelExtensions.PressAnyKey();
                return;
            }


        }

        public static void OpenFile()
        {
            Console.Clear();
            Console.Write("Enter filename to open: ");
            string filename = Console.ReadLine();
            try
            {
                if (!File.Exists(Paths.CurrentDirectory + @"\" + filename))
                {

                    Console.WriteLine("File does not exist!");
                    Console.WriteLine("Would you like to create it?");
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Y)
                    {
                        // Append the filename with the current directory path
                        _filename = Paths.CurrentDirectory + filename;
                        File.Create(_filename).Dispose();
                    }
                    else
                    {
                        return;
                    }
                }
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                KernelExtensions.PressAnyKey();
                return;
            }


            // Append the filename with the current directory path
            _filename = Paths.CurrentDirectory + filename;
            _fileIsOpen = true;
            _running = true;

            try
            {
                StartVICS(filename);
            }
            catch (Exception ex)
            {
                _running = false;
                Console.WriteLine(ex.Message);
                KernelExtensions.PressAnyKey();
                return;
            }
        }
    }
}