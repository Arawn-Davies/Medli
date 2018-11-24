using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Medli.Common;

namespace Medli
{
    public class usr_vars
    {
        public static string varsfile = Paths.System + @"\vars.txt";
        public static Dictionary<string, string> usr_var = new Dictionary<string, string>();
        public static void Store(string variable, string contents, bool force)
        {
            if (usr_var.ContainsKey(variable))
            {
                if (force == true)
                {
                    usr_var.Remove(variable);

                    contents = contents.Replace(" -u", "");
                    usr_var.Add(variable, contents);
                }
                else
                {
                    Console.WriteLine("Key already exists!");
                }
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
                Console.Write("| Key:" + key.Key);
                Console.WriteLine(" | Value: " + key.Value + "|");
            }
        }
        public static void ReadVars()
        {
            try
            {
                if (File.Exists(varsfile))
                {
                    string[] vars = File.ReadAllLines(varsfile);
                    for (int i = 1; i < vars.Length; i++)
                    {
                        string[] varcontent = vars[i].Split('=');
                        if (!usr_var.ContainsKey(varcontent[0]))
                        {
                            Console.WriteLine(varcontent[0] + ":" + varcontent[1]);
                            usr_var.Add(varcontent[0], varcontent[1]);
                        }
                        else
                        {
                            Console.WriteLine("Variable already loaded: " + varcontent[0]);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("File does not exist! The user probably hasn't made any variables");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to retrieve variables");
                Console.WriteLine(ex.Message);
            }

        }

        public static void Clear()
        {
            usr_var.Clear();
        }

        public static void SaveVars()
        {
            try
            {

                if (File.Exists(varsfile))
                {
                    foreach (var entry in usr_var)
                    {
                        File.WriteAllText(varsfile, ("\n" + entry.Key + "=" + entry.Value));
                    }
                }
                else
                {
                    Console.WriteLine("Cannot find the file that stores the variable file.");
                    Console.WriteLine("The system will now save the variables to the default file.");
                    foreach (var entry in usr_var)
                    {
                        File.WriteAllText(varsfile, ("\n" + entry.Key + "=" + entry.Value));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }
}
