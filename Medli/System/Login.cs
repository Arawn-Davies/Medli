using System;
using System.IO;
using System.Threading;
using Medli.System.Framework.Crypto;
using Medli.Common;
using Medli.System.Framework;

namespace Medli.System
{
	public class AccountAccess
	{
		public static void ResetConsoleColor()
		{
			Console.ForegroundColor = ConsoleColor.White;
			Console.BackgroundColor = ConsoleColor.Black;
		}
		public static void Changepass()
		{
			Installer.ScreenSetup(is_login: true);
			Console.Clear();
			Console.BackgroundColor = ConsoleColor.Gray;
			Console.WriteLine("Change password:");
			Console.CursorTop = 5;
			ResetConsoleColor();
			Console.BackgroundColor = ConsoleColor.Blue;
			Console.WriteLine("Enter the new user password");
			string usrpass = Installer.ReadPasswd();
			File.WriteAllText(Paths.Users + MEnvironment.dir_ext + Kernel.username + @"\pass.sys", SHA256.Hash(usrpass));
			Kernel.SetColourScheme();
		}

		public static void Login()
		{
			while (Kernel._isLoggedIn == false)
			{
				Installer.ScreenSetup(is_login: true);
				Console.BackgroundColor = ConsoleColor.Gray;
				Console.ForegroundColor = ConsoleColor.Black;
				Console.WriteLine("User Login:\n\n");
				ResetConsoleColor();
				Console.BackgroundColor = ConsoleColor.Blue;

				Console.WriteLine("You can either log in as an existing user or create a new one.");
				Console.Write("Username >");

				string usrlogon = Console.ReadLine();
				if (String.IsNullOrEmpty(usrlogon) == true)
				{
					Console.WriteLine("Username is invalid");
					Installer.PressAnyKey("Press any key to retry...");
				}
				else
				{
					if (usrlogon == "root")
					{
						Console.Write("Password >");
						//Console.ForegroundColor = ConsoleColor.Blue;
						string pass = Installer.ReadLine();
						//Console.ForegroundColor = ConsoleColor.White;
						MEnvironment.rootpass_sha = File.ReadAllLines(MEnvironment.rpf)[0];
						if (pass == MEnvironment.rootpass)
						{
							Kernel.username = "root";
							Kernel._isLoggedIn = true;
						}
						else
						{
							Console.WriteLine("Incorrect password.");
							Installer.PressAnyKey("Press any key to retry...");
							continue;
						}
					}
					else
					{
						if (Directory.Exists(Paths.Users + MEnvironment.dir_ext + usrlogon))
						{
							Console.Write("Password >");
							string pass = global::System.Console.ReadLine();

							//MEnvironment.usrpass_sha = File.ReadAllLines(MEnvironment.upf)[0];
							MEnvironment.usrpass_sha = File.ReadAllLines((Paths.Users + MEnvironment.dir_ext + usrlogon + MEnvironment.dir_ext + "pass.sys"))[0];
							if (SHA256.Hash(pass) == MEnvironment.usrpass_sha)
							{
								// Successful login
								Kernel.username = usrlogon;
								Kernel._isLoggedIn = true;
							}
							else
							{
								Console.WriteLine("Incorrect password.");
								Installer.PressAnyKey("Press any key to retry...");
								continue;
							}
						}
						else
						{
							Console.WriteLine("Incorrect password.");
							Installer.PressAnyKey("Press any key to retry...");
							continue;
						}
					}
				}
			}
			Console.Clear();
			Kernel._isLoggedIn = true;
		}

		public static void Logout()
		{
			EnvironmentVariables.SaveVars();
			Kernel.username = "";
			Console.Clear();
			Kernel.SetColourScheme();
		}
	}
}
