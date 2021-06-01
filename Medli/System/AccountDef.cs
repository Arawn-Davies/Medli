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

        public string Usrpass_md5 { get; set; }
        public string upf = "pass.sys";
        public UserType Type { get; set; }

        /// <summary>
        /// Create an account.
        /// </summary>
        /// <param name="nm">The user name.</param>
        /// <param name="pass">The user password.</param>
        public AccountDef(string nm, string pass) //, UserType type = UserType.Normal)
        {
            Name = nm;
            Password = pass;
            //Type = type;
            Userhomedir = Paths.Users + MEnvironment.dir_ext + Name + MEnvironment.dir_ext;
            Usrpass_md5 = StringExtensions.SHA256(Password);
            Directory.CreateDirectory(Userhomedir);
            File.WriteAllText(Userhomedir + upf, Usrpass_md5);
            //Console.WriteLine("Created new user directory: " + userhomedir);
            File.AppendAllText(Kernel.usrinfo, Name + Environment.NewLine);
            Accounts.Add(this);
        }
    }
    public enum UserType
    {
        Guest = 0,
        Normal = 1,
        Root = 2,
    }

}
