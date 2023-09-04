using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Medli.Common;
using Medli.System.Framework;

namespace Medli.System
{
    /// <summary>
    /// Class definition of type Account
    /// </summary>
    public class AccountDef
    {
        /// <summary>
        /// The accounts
        /// </summary>
        public static List<AccountDef> Accounts = new List<AccountDef>();
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        private string Password { get; set; }
        /// <summary>
        /// Gets or sets the user's home directory.
        /// </summary>
        /// <value>
        /// The homedir.
        /// </value>
        public string homedir{ get; set; }
        /// <summary>
        /// Gets or sets the password SHA.
        /// </summary>
        /// <value>
        /// The pass sha.
        /// </value>
        private string pass_sha { get; set; }

        /// <summary>
        /// The user password filename
        /// </summary>
        private string upf = "pass.sys";

        /// <summary>
        /// Gets or sets the user level.
        /// </summary>
        /// <value>
        /// The user level.
        /// </value>
        public byte UserLevel{ get; set; }

        /// <summary>
        /// Create an account.
        /// </summary>
        /// <param name="nm">The user name.</param>
        /// <param name="pass">The user password.</param>
        /// <param name="type">The user type</param>
        public AccountDef(string nm, string pass, byte type) //, UserType type = UserType.Normal)
        {
            Name = nm;
            Password = pass;
            UserLevel = type;
            homedir = Paths.Users + MEnvironment.dir_ext + Name + MEnvironment.dir_ext;
            pass_sha = StringExtensions.SHA256(Password);
            Directory.CreateDirectory(homedir);
            File.WriteAllText(homedir + upf, pass_sha);
            //Console.WriteLine("Created new user directory: " + userhomedir);
            File.AppendAllText(Kernel.usrinfo, Name + Environment.NewLine);
            Accounts.Add(this);
        }
    }
    /// <summary>
    /// Class definition of the user levels
    /// </summary>
    public class UserType
    {
        /// <summary>
        /// The guest level, very limited access
        /// </summary>
        public static byte Guest = 2;
        /// <summary>
        /// The normal level, typical daily use access (web browser, printing, desktop applications
        /// </summary>
        public static byte Normal = 1;
        /// <summary>
        /// The root level, full administrative access to all settings, applications, files and devices
        /// </summary>
        public static byte Root = 0;
    }

}
