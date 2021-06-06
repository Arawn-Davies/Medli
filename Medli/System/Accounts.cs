using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Medli.Common;
using AIC.Main.Extensions;

namespace Medli.System
{
    // ~~Gradually port from Medli-Classic to current source model~~
    // yeah nah mate lowe dat utter nonsense

    class Accounts
    {

        private static string usrname;
        private static string pass;
        private static string user_type;

        public static void InitNewUser()
        {
            NewUser();
            Kernel.username = usrname;
            MEnvironment.usrpass = pass;
        }

        public static void NewUser()
        {
            Console.WriteLine("Enter new account name:");
            usrname = Console.ReadLine();
            Console.WriteLine("Enter the new account password:");
            pass = Console.ReadLine();
            CreateUser(usrname, pass);
        }

        public static string CreUsr_Output = "";

        public static void CreateUser(string usrname, string pass)
        {
            Extensions.PressAnyKey();
            Console.WriteLine("Adding user - " + usrname + ":" + pass);
            new AccountDef(usrname, pass);
        }

        public static void PermCheck()
        {
            if (Kernel.username != MEnvironment.current_usr_dir)
            {
                Console.WriteLine("You are not logged in as this user! Access Denied.");
            }
            else
            {

            }
        }
        public static void ResetConsoleColor()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public static void Changepass()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.WriteLine("Change password:");
            Console.CursorTop = 5;
            ResetConsoleColor();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("Enter the new user password");
            string usrpass = Console.ReadLine();
            File.WriteAllText(Paths.Users + MEnvironment.dir_ext + Kernel.username + @"\pass.sys", AIC.Main.Crypto.SHA256.Hash(usrpass));
        }
        public static void UserLogin()
        {

            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("User Login:");
            ResetConsoleColor();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.CursorTop = 5;
            Console.WriteLine("You can either log in as an existing user or create a new one.\n");
            Console.Write("Username >");
            string usrlogon = Console.ReadLine();
            if (usrlogon == "root")
            {
                Console.Write("Password >");
                Console.ForegroundColor = ConsoleColor.Blue;
                string pass = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                MEnvironment.rootpass_sha = File.ReadAllLines(MEnvironment.rpf)[0];
                if (pass == MEnvironment.rootpass)
                {
                    Kernel.username = "root";
                    KernelExtensions.PressAnyKey();
                }
                else
                {
                    Console.WriteLine("Incorrect root password. ");
                    KernelExtensions.PressAnyKey();
                    UserLogin();
                }
            }
            else if (Directory.Exists(Paths.Users + MEnvironment.dir_ext + usrlogon))
            {
                Console.Write("Password >");
                Console.ForegroundColor = ConsoleColor.Blue;
                string pass = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                //MEnvironment.usrpass_sha = File.ReadAllLines(MEnvironment.upf)[0];
                MEnvironment.usrpass_sha = File.ReadAllLines((Paths.Users + MEnvironment.dir_ext + usrlogon + MEnvironment.dir_ext + "pass.sys"))[0];
                if (AIC.Main.Crypto.SHA256.Hash(pass) == MEnvironment.usrpass_sha)
                {
                    Kernel.username = usrlogon;
                }
                else
                {
                    Console.WriteLine("Incorrect password.");
                    KernelExtensions.PressAnyKey("Press any key to retry...");
                    UserLogin();
                }
            }
            else
            {
                Console.WriteLine("User does not exist!");
                KernelExtensions.PressAnyKey("Press any key to retry...");
                UserLogin();
            }
        }
    }
}