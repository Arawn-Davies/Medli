using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Medli.Common;
using Medli.Common.Services;
using MDFS;
using Medli.System;
using Medli.Main;
using Cosmos.System.FileSystem;

namespace Medli.System
{
    public class FS
    {
		/// <summary>
		/// Checks if the system is running in live mode
		/// Should optionally be called before any filesystem IO
		/// Create an interrupt for this?
		/// </summary>
		/// <exception cref="Exception"></exception>
		public static void IsLiveSystem()
		{
			if (FSService.Active == false)
			{
				throw new Exception("Medli is currently running in live mode!\nFilesystem IO is disabled.");
			}
		}

		/// <summary>
		/// Get information for the available filesystems
		/// </summary>
        public static void ListDisk()
        {
            FSService.ListDisk();
		}

		/// <summary>
		/// Run the disk formatting utility
		/// </summary>
		public static void MFSU()
        {
            try
            {
                //IsLiveSystem();
                MFSUtility.Main(SystemFunctions.IDEs);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        /// <summary>
        /// Copies the specified file from the source to the destination
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dest"></param>
        public static void Copy(string src, string dest)
        {
            try
            {
                IsLiveSystem();
                File.Copy(src, dest);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        /// <summary>
        /// Creates a directory, checking if the specified parameter is a Medli system directory
        /// </summary>
        /// <param name="dirname"></param>
        /// <param name="issys"></param>
        public static void Makedir(string dirname, bool issys = false)
        {
            try
            {
				if (issys == true)
                {
                    if (!Directory.Exists(dirname))
                    {
						Directory.CreateDirectory(dirname);
                    }
					else
					{
						//AreaInfo.SystemDevInfo.WriteDevicePrefix("FS", "Directory " + dirname + " already exists!");
					}
                }
                else
                {
					IsLiveSystem();
					if (!Directory.Exists(dirname))
                    {
                        Directory.CreateDirectory(Paths.CurrentDirectory + @"\" + dirname);
                    }
					else
					{
						Console.WriteLine("Directory " + dirname + " already exists!");
					}
				}
            }
            catch (Exception ex)
            {
				Console.WriteLine(ex.Message);
                Console.WriteLine("mkdir: failed to create directory");
            }
        }

		/// <summary>
		/// Move the specified file from the source to the destination
		/// </summary>
		/// <param name="src"></param>
		/// <param name="dest"></param>
        public static void mv(string src, string dest)
        {
			try
			{
				IsLiveSystem();
				if (File.Exists(src))
				{
					File.Copy(src, dest);
					File.Delete(src);
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

		/// <summary>
		/// Change to the parent directory
		/// </summary>
        public static void cdp()
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
                                            
                    var dir = FSService.vFS.GetDirectory(Paths.CurrentDirectory);
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

		/// <summary>
		/// Changes to the specified directory
		/// </summary>
		/// <param name="input"></param>
        public static void cd(string input)
        {
			try
			{
				IsLiveSystem();
				string path = input;
				if (Directory.Exists(Paths.CurrentDirectory + path))
				{
					Paths.CurrentDirectory = Paths.CurrentDirectory + @"\" + path;
                    Directory.SetCurrentDirectory(Paths.CurrentDirectory);
				}
				else if (Directory.Exists(path))
				{
					Paths.CurrentDirectory = path;
                    Directory.SetCurrentDirectory(Paths.CurrentDirectory);
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

		/// <summary>
		/// Writes the specified contents to the specified file
		/// </summary>
		/// <param name="path"></param>
		/// <param name="contents"></param>
		public static void WriteContents(string path, string contents)
		{
			try
			{
				IsLiveSystem();
				File.WriteAllText(path, contents);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		/// <summary>
		/// Reads the contents of the specified file and returns it in a byte array format
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
        public static byte[] ReadContents(string path)
        {
            try
            {
                IsLiveSystem();
                return File.ReadAllBytes(path);
            }
            catch (Exception ex)
            {
                Framework.AConsole.Error.WriteLine(ex.Message);
            }
            return new byte[]{ 0, 0};
        }

		/// <summary>
		/// Deletes the specified file or directory
		/// </summary>
		/// <param name="filename"></param>
		/// <param name="recursive"></param>
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

		/// <summary>
		/// Lists the contents of the current directory
		/// </summary>
        public static void Dir()
        {
            Dir(Paths.CurrentDirectory);
        }

		/// <summary>
		/// Lists the contents of the specified directory
		/// </summary>
		/// <param name="path"></param>
        public static void Dir(string path)
        {
			try
			{
				IsLiveSystem();
				DirectoryInfo DI = new DirectoryInfo(path);
				FileInfo[] files = DI.GetFiles();
				//Array.Sort(directories);
				//Array.Sort(files);
				DirectoryInformation.ShowDirectories(path);
				DirectoryInformation.ShowFiles(path);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				Console.WriteLine("Failed to retrieve files/directories");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <exception cref="NotImplementedException"></exception>
		public static void ListVol()
		{
#warning ListVol() Implement this
			throw new NotImplementedException();
			//Console.WriteLine("Name: " + Paths.vol.mName + ", Size: " + Paths.vol.mSize);
		}

		/// <summary>
		/// Lists the volumes available to the operating systems
		/// </summary>
		/// <exception cref="NotImplementedException"></exception>
		public static void ListVols()
		{
#warning ListVols() Implement this
			throw new NotImplementedException();
			/*
			var volumes = KernelVariables.vFS.GetVolumes();
			foreach (var volume in volumes)
			{
				if (volume == Paths.vol)
				{
					Console.WriteLine("* Name: " + volume.mName + ", Size: " + volume.mSize);
				}
				Console.WriteLine("Name: " + volume.mName + ", Size: " + volume.mSize);
			}
			*/
		}
    }
}
