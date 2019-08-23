using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Medli.System
{
    // Gradually port from Medli-Classic to current source model

    class Accounts
    {
        public static void NewUser()
        {
            Console.WriteLine("Enter new account name:");
            string usrname = Console.ReadLine();
            Console.WriteLine("Enter the new account password:");
            string pass = Console.ReadLine();
            Console.WriteLine("Enter the new account type (guest, normal, root) :");
            string user_type = Console.ReadLine();
            CreateUser(usrname, pass, user_type);
        }
        public static void CreateUser(string usrname, string pass, string user_type)
        {
            if (user_type.ToLower() == "guest")
            {
                Account.Accounts.Add(new Account(usrname, pass, UserType.Guest));
            }
            else if (user_type.ToLower() == "normal")
            {
                Account.Accounts.Add(new Account(usrname, pass, UserType.Normal));
            }
            else if (user_type.ToLower() == "root")
            {
                Account.Accounts.Add(new Account(usrname, pass, UserType.Root));
            }
            else
            {
                Console.WriteLine("Invalid user type:" + user_type);
            }
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
            Console.WriteLine("Enter the new user password");
            string usrpass = Console.ReadLine();
            File.WriteAllText(Common.Paths.Users + MEnvironment.dir_ext + Kernel.username + @"\pass.sys", AIC_Framework.Crypto.MD5.hash(usrpass));
        }
        public static void UserLogin()
        {

            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("User Login:");
            ResetConsoleColor();
            Console.CursorTop = 5;
            Console.WriteLine("You can either log in as an existing user or create a new one.\n");
            Console.Write("Username >");
            string usrlogon = Console.ReadLine();
            if (usrlogon == "root")
            {
                Console.Write("Password >");
                Console.ForegroundColor = ConsoleColor.Black;
                string pass = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                MEnvironment.rootpass_md5 = File.ReadAllLines(MEnvironment.rpf)[0];
                if (pass == MEnvironment.rootpass)
                {
                    Kernel.username = "root";
                    MEnvironment.PressAnyKey();
                }
                else
                {
                    Console.WriteLine("Incorrect root password. ");
                    MEnvironment.PressAnyKey();
                    UserLogin();
                }
            }
            else if (Directory.Exists(Common.Paths.Users + MEnvironment.dir_ext + usrlogon))
            {
                Console.Write("Password >");
                Console.ForegroundColor = ConsoleColor.Black;
                string pass = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                MEnvironment.usrpass_md5 = File.ReadAllLines(MEnvironment.upf)[0];
                if (pass == MEnvironment.usrpass)
                {
                    Kernel.username = usrlogon;
                }
                else
                {
                    Console.WriteLine("Incorrect password.");
                    MEnvironment.PressAnyKey();
                    UserLogin();
                }
            }
            else
            {
                Console.WriteLine("User does not exist!");
                Console.WriteLine("Press any key to retry...");
                Console.ReadKey(true);
                UserLogin();
            }
        }
    }
    public class Account
    {
        public static List<Account> Accounts;
        public string Name { get; set; }
        public string Password { get; set; }
        public string Userhomedir { get; set; }

        public string Usrpass_md5 { get; set; }
        public string upf = "pass.sys";
        public UserType Type { get; set; }

        /// <summary>
        /// Create an account.
        /// </summary>
        /// <param name="nm">The user name.</param>
        /// <param name="pass">The user password.</param>
        public Account(string nm, string pass, UserType type = UserType.Normal)
        {
            Name = nm;
            Password = pass;
            Type = type;
            Userhomedir = Common.Paths.Users + MEnvironment.dir_ext + Name + MEnvironment.dir_ext;
            Usrpass_md5 = AIC_Framework.Crypto.MD5.hash(Password);
            Directory.CreateDirectory(Userhomedir);
            //Console.WriteLine("Created new user directory: " + userhomedir);
            File.WriteAllText(Userhomedir + upf, Usrpass_md5);
            File.AppendAllText(Kernel.usrinfo, Name + Environment.NewLine);
        }
    }
    public enum UserType
    {
        Guest = 0,
        Normal = 1,
        Root = 2,
    }
    
}
