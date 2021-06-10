using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Medli.Common;
using AIC.Main.Extensions;

namespace Medli.System
{
    public class AccountDef
    {
        public static List<AccountDef> Accounts = new List<AccountDef>();
        public string Name { get; set; }
        public string Password { get; set; }
        public string Userhomedir { get; set; }

        public string Usrpass_sha { get; set; }

        public string upf = "pass.sys";
        public byte UType { get; set; }

        /// <summary>
        /// Create an account.
        /// </summary>
        /// <param name="nm">The user name.</param>
        /// <param name="pass">The user password.</param>
        public AccountDef(string nm, string pass, byte type) //, UserType type = UserType.Normal)
        {
            Name = nm;
            Password = pass;
            UType = type;
            Userhomedir = Paths.Users + MEnvironment.dir_ext + Name + MEnvironment.dir_ext;
            Usrpass_sha = StringExtensions.SHA256(Password);
            Directory.CreateDirectory(Userhomedir);
            File.WriteAllText(Userhomedir + upf, Usrpass_sha);
            //Console.WriteLine("Created new user directory: " + userhomedir);
            File.AppendAllText(Kernel.usrinfo, Name + Environment.NewLine);
            Accounts.Add(this);
        }
    }
    public class UserType
    {
        public static byte Guest = 2;
        public static byte Normal = 1;
        public static byte Root = 0;
    }

}
