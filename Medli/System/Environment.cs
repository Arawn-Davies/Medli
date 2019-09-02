﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Medli
{
    /// <summary>
    /// Will hold the environment methods which will be called by various components in Medli
    /// </summary>
    public class MEnvironment
    {
        /// <summary>
        /// Directory separator
        /// </summary>
        public static string dir_ext = @"\";
        
        /// <summary>
        /// Small and simple method saves typing these lines out 
        /// over and over again. Calls the method with the default text
        /// </summary>
        public static void PressAnyKey()
        {
            PressAnyKey("Press any key to continue...");
        }

        /// <summary>
        /// Small and simple method saves typing these lines out 
        /// over and over again. Developer can specify text to use
        /// </summary>
        /// <param name="text"></param>
        public static void PressAnyKey(string text)
        {
            Console.WriteLine(text);
            Console.ReadKey(true);
        }

        /// <summary>
        /// Sets the filesystems current directory to its initial value
        /// i.e. the root of the storage device, same initial value but keeps them separate
        /// </summary>
        public static string current_dir = @"0:\";

        /// <summary>
        /// Defines the root directory's value, same as current_dir's initial value but keeps them separate
        /// </summary>
        public static string root_dir = @"0:\";

        /// <summary>
        /// String storing the user password
        /// </summary>
        public static string usrpass;

        /// <summary>
        /// String storing the user password with MD5 hash
        /// </summary>
        public static string usrpass_md5; //= AIC_Framework.Crypto.MD5.hash(usrpass);

        /// <summary>
        /// File path of the user password
        /// </summary>
        public static string upf = Common.Paths.Users + Kernel.username + dir_ext + "pass.sys";

        /// <summary>
        /// File path of the root password
        /// </summary>
        public static string rpf = Common.Paths.System + dir_ext + "pass.sys";

        /// <summary>
        /// String storing the root password
        /// </summary>
        public static string rootpass;

        /// <summary>
        /// String storing the root password with MD5 hash
        /// </summary>
        public static string rootpass_md5; //= AIC_Framework.Crypto.MD5.hash(rootpass);

        /// <summary>
        /// Stores the encrypted user password as a file
        /// </summary>
        public static void WriteUserPass()
        {
            usrpass_md5 = AIC_Framework.Crypto.MD5.hash(usrpass);
            File.WriteAllText(upf, usrpass_md5);
        }

        /// <summary>
        /// Stores the encrypted user password as a file
        /// </summary>
        public static void WriteRootPass()
        {
            usrpass_md5 = AIC_Framework.Crypto.MD5.hash(rootpass);
            File.WriteAllText(rpf, rootpass_md5);
        }

        /// <summary>
        /// Current user's home directory
        /// </summary>
        public static string current_usr_dir = Common.Paths.Users + dir_ext + Kernel.username;
    }
}
