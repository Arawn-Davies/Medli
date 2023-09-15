using System;
using Medli.System.Framework;

namespace Medli.System
{
    // ~~Gradually port from Medli-Classic to current source model~~
    // yeah nah mate lowe dat utter nonsense

    class Accounts
    {
        // 0 = Root
        // 1 = Normal
        // 2 = Guest
        // 3 = Uninitialised
        private static byte mType = UserType.Root;

        private static string usrname;
        private static string pass;

        public static void InitNewUser()
        {
            NewUser();
            Kernel.username = usrname;
            MEnvironment.usrpass = pass;
            MEnvironment.currentUserType = mType;
        }

        public static void NewUser(bool is_installer = true)
        {
            string utype;
            if (is_installer == true)
            {
                Installer.WriteLine("Enter new account name:");
                usrname = Installer.ReadLine();
				pass = "example";
				string pass2 = "";
				while (pass != pass2)
				{
					Installer.Write("Enter the new account password:");
					pass = Installer.ReadPasswd();
					Installer.Write("Confirm password: ");
					pass2 = Installer.ReadPasswd();
				}
				
				
                Installer.WriteLine("Enter the new account type:");
                utype = Installer.ReadLine();
            }
            else
            {
                Console.WriteLine("Enter new account name:");
                usrname = Console.ReadLine();
                Console.Write("Enter the new account password:");
                pass = Installer.ReadPasswd();
                Console.WriteLine("Enter the new account type:");
                utype = Console.ReadLine();
            }
            
           
            if (utype == "guest")
            {
                mType = UserType.Guest;
            }
            else if (utype == "normal")
            {
                mType = UserType.Normal;
            }
            else if (utype == "root")
            {
                mType = UserType.Root;
            }
            if (is_installer == true)
            {
                CreateUser(usrname, pass, mType, true);
            }
            else
            {
                CreateUser(usrname, pass, mType, false);
            }
            
        }

        public static string CreUsr_Output = "";

        public static void CreateUser(string usrname, string pass, byte type, bool is_installer = true)
        {
            if (is_installer == true)
            {
                Installer.ScreenSetup(is_login: true);
                Installer.WritePrefix("Adding user - " + usrname + ":" + pass);
            }
            else
            {
                KernelExtensions.PressAnyKey();
                Console.Write("\nAdding user - " + usrname + ":" + pass);
            }

            new AccountDef(usrname, pass, type);
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
    }
}