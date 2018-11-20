using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Medli.Common;

namespace Medli
{
    public class usr_vars
    {
        public static string varsfile = Paths.System + @"\" + "vars.sys";
        public static Dictionary<string, string> usr_var = new Dictionary<string, string>();
        public static void Store(string variable, string contents)
        {
            if (usr_var.ContainsKey(variable))
            {
                Console.WriteLine("Key already exists!");
            }
            else
            {
                usr_var.Add(variable, contents);
            }
        }
        public static string Retrieve(string variable)
        {

            if (usr_var.ContainsKey(variable))
            {
                string content = usr_var[variable];
                return content;
            }
            else
            {
                return "Value not found!";
            }
        }
        public static void PrintVars()
        {
            foreach (var key in usr_vars.usr_var)
            {
                Console.Write("Key:" + key.Key);
                Console.WriteLine(" - Value: " + key.Value);
            }
        }
        public static void ReadVars()
        {
            try
            {
                string[] vars = File.ReadAllLines(varsfile);
                foreach (string variable in vars)
                {
                    string[] varcontent = variable.Split(' ');
                    if (!usr_var.ContainsKey(variable))
                    {
                        usr_var.Add(variable, varcontent[1]);
                    }
                    else
                    {
                        Console.WriteLine("Variable already loaded: " + varcontent[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to retrieve variables");
                Console.WriteLine(ex.Message);
            }

        }
        public static void SaveVars()
        {
            if (File.Exists(varsfile))
            {
                using (StreamWriter file = new StreamWriter(File.OpenWrite(varsfile)))
                {
                    foreach (var entry in usr_var)
                    {
                        file.WriteLine("\n{0} {1}", entry.Key, entry.Value);
                    }
                }
            }
            else
            {
                Console.WriteLine("Cannot find the file that stores the variable file...");
                Console.WriteLine("The system will now ");
            }

        }
    }
}
