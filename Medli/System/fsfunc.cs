using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Medli.Common;

namespace Medli.System
{
    public class FS
    {
		private static void IsLiveSystem()
		{
			if (KernelVariables.IsLive == true)
			{
				throw new Exception("Medli is currently running in live mode!\nFilesystem IO is disabled.");
			}
			else
			{

			}
		}

		/// <summary>
		/// Creates a directory, checking if the specified parameter is a Medli system directory
		/// </summary>
		/// <param name="dirname"></param>
		/// <param name="issys"></param>
		public static void mkdir(string dirname, bool issys)
        {
            try
            {
				IsLiveSystem();
				if (issys == true)
                {
                    if (!Directory.Exists(dirname))
                    {
						AreaInfo.SystemDevInfo.WriteDevicePrefix("FS", "Creating directory " + dirname + "...");
						Directory.CreateDirectory(dirname);
                    }
                }
                else
                {
                    if (!Directory.Exists(dirname))
                    {
                        Directory.CreateDirectory(Paths.CurrentDirectory + @"\" + dirname);
                    }
                }
            }
            catch (Exception ex)
            {
				Console.WriteLine(ex.Message);
                Console.WriteLine("mkdir: failed to create directory");
            }
        }
        public static void mv(string src, string dest)
        {
			try
			{
				IsLiveSystem();
				if (File.Exists(src))
				{
					//Small little hack
					File.Copy(src, dest);
					File.Delete(src);

					//Do nowt for now - File.Move isn't plugged
					//Console.WriteLine("File.Move needs plugging!");
					//File.Move(src, dest);
				}
				else
				{
					Console.WriteLine("file does not exist");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
        }
        public static void CDP()
        {
            try
            {
				IsLiveSystem();
                if (Paths.CurrentDirectory == Paths.Root)
                {
                    Console.WriteLine("Cannot go up any more levels!");
                }
                else
                {
                    //var pos = Paths.CurrentDirectory.LastIndexOf('\\');
                    //if (pos >= 0)
                    //{
                        //Paths.CurrentDirectory = Paths.CurrentDirectory.Substring(0, pos) + @"\";
                    //}
                                            
                    var dir = KernelVariables.vFS.GetDirectory(Paths.CurrentDirectory);
                    string p = dir.mParent.mName;
                    if (!string.IsNullOrEmpty(p))
                    {
                        Paths.CurrentDirectory = p;
                        Directory.SetCurrentDirectory(p);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //ErrorHandler.Init(0, ex.Message, false, "");
            }
        }
        public static void cd(string input)
        {
			try
			{
				IsLiveSystem();
				string path = input;
				if (Directory.Exists(Paths.CurrentDirectory + path))
				{
					Paths.CurrentDirectory = Paths.CurrentDirectory + @"\" + path;
					string cd = Directory.GetCurrentDirectory();
					Directory.SetCurrentDirectory(cd + path);
				}
				else if (Directory.Exists(path))
				{
					Paths.CurrentDirectory = path;
					Directory.SetCurrentDirectory(path);
				}
				else
				{
					Console.WriteLine("Folder does not exist " + Paths.CurrentDirectory + @"\" + path);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
            
        }
        public static void del(string filename, bool recursive)
        {
			try
			{
				IsLiveSystem();
				if (File.Exists(filename))
				{
					try
					{
						File.Delete(Paths.CurrentDirectory + filename);
					}
					catch
					{
						Console.WriteLine("Failed to delete file!");
					}
				}
				else if (Directory.Exists(filename))
				{
					if (recursive == true)
					{
						try
						{
							Directory.Delete(filename, true);
						}
						catch
						{
							Console.WriteLine("Failed to recursively delete directory!");
						}
					}
					try
					{
						Directory.Delete(Paths.CurrentDirectory + filename);
					}
					catch
					{
						Console.WriteLine("Failed to delete directory!");
					}
				}
				else
				{
					Console.WriteLine("File/Directory doesn't exist!");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
        }
        public static void dir()
        {
            dir(Paths.CurrentDirectory);
        }
        public static void dir(string path)
        {
			try
			{
				IsLiveSystem();
				string[] directories = Directory.GetDirectories(path);
				string[] files = Directory.GetFiles(path);
				//Array.Sort(directories);
				//Array.Sort(files);
				try
				{

					Console.WriteLine("-: Directories :-");
					foreach (string dir in directories)
					{
						Console.WriteLine("<Directory>\t" + dir);
					}
				}
				catch
				{
					Console.WriteLine("Failed to retrieve directories");
				}
				try
				{
					Console.WriteLine("-: Files :-");
					foreach (string file in files)
					{
						Console.ForegroundColor = ConsoleColor.Yellow;
						string[] sp = file.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries);
						Console.WriteLine(sp[sp.Length - 1] + "\t" + file);
						Console.ForegroundColor = ConsoleColor.White;
					}
				}
				catch
				{
					Console.WriteLine("Failed to retrieve files");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
    }
}
