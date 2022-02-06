using System;
using System.Collections.Generic;
using System.Linq;

namespace Medli.Apps
{
    /// <summary>
    /// Class definition for Cowsay
    /// 
    /// A must-have for any command line operating system
    /// </summary>
    public class Cowsay : Command
    {
        /// <summary>
        /// Gets the name of the command.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public override string Name
		{
			get
			{
				return "cowsay";
			}
		}

        /// <summary>
        /// Gets the summary for the command.
        /// </summary>
        public override string Summary
		{
			get
			{
				return "A little *nix easter egg";
			}
		}

        /// <summary>
        /// Executes the specified parameter.
        /// </summary>
        /// <param name="param">The parameter.</param>
        public override void Execute(string param)
		{
			if (param == null)
			{
				Cowsay.Cow("Say something using 'Cowsay <message>'");
				Console.WriteLine(@"You can also use 'cowsay -f' tux for penguin, cow, sheep and robot");
			}
			else
			{
				string[] args = param.Split(' ');
				if (args[0] == "-f")
				{
					if (args[1] == "cow")
					{
						Cowsay.Cow(param.Remove(0, args[0].Length + args[1].Length + 2));
					}
					else if (args[1] == "tux")
					{
						Cowsay.Tux(param.Remove(0, args[0].Length + args[1].Length + 2));
					}
					else if (args[1] == "sheep")
					{
						Cowsay.Sheep(param.Remove(0, args[0].Length + args[1].Length + 2));
					}
                    else if (args[1] == "confused_sheep")
                    {
                        Cowsay.ConfusedSheep(param.Remove(0, args[0].Length + args[1].Length + 2));
                    }
                    else if (args[1] == "medli")
                    {
                        Cowsay.Medli(param.Remove(0, args[0].Length + args[1].Length + 2));
                    }
                }
				else
				{
					Cowsay.Cow(param);
				}
			}
		}
		/// <summary>
		/// Prints the argument passed to 'cowsay' into the
		/// speech bubble said by the cow
		/// </summary>
		/// <param name="args"></param>
		public static void print(string args)
        {
            int length = args.Length;
            for (int i = 1; i <= length; i++)
            {
                Console.Write("-");
            }
        }

        /// <summary>
        /// Medli cowsay
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Medli(string args)
        {
            Console.Write("/--"); print(args); Console.WriteLine(@"--\");
            Console.WriteLine("|- " + args + @" -|");
            Console.Write("/--"); print(args); Console.WriteLine(@"--\");
            Console.WriteLine(@"
       \
        \   
         \    /\
          \  /  \ 
            /____\
           /\    /\
          /  \  /  \
         /____\/____\
");
        }

        /// <summary>
        /// Main method for Medli cowsay, standard feature :P
        /// This basically prints the cow onto the screen, 
        /// then calls 'print()' to render the message
        /// </summary>
        /// <param name="args"></param>
        public static void Cow(string args)
        {

            Console.Write("/--"); print(args); Console.WriteLine(@"--\");
            Console.WriteLine("|- " + args + @" -|");
            Console.Write(@"\--"); print(args); Console.Write(@"--/");
            Console.WriteLine(@"
       \
        \   ^__^
         \  (oo)\_______
            (__)\       )\/\
                ||----w |
                ||     ||");
        }

        /// <summary>
        /// Tux cowsay.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Tux(string args)
        {
            Console.Write("/--"); print(args); Console.WriteLine(@"--\");
            Console.WriteLine("|- " + args + @" -|");
            Console.Write(@"\--"); print(args); Console.Write(@"--/");
            Console.WriteLine(@"
       \
        \   
         \     .--.
          \   |o_o |
              |:_/ |
             //   \ \
            (|     | )
           /'\_   _/`\
           \___)=(___/
");
        }

        /// <summary>
        /// Sheep cowsay.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Sheep(string args)
        {
            Console.Write("/--"); print(args); Console.WriteLine(@"--\");
            Console.WriteLine("|- " + args + @" -|");
            Console.Write(@"\--"); print(args); Console.Write(@"--/");
            Console.WriteLine(@"
  \                
   \               
    \              
     \             
       __         
      UooU\./@@@@@@\,
      \__/(@@@@@@@@@@)
           (@@@@@@@@)
           `YY~~~~YY' 
            ||    ||   
");
        }

        /// <summary>
        /// Confused sheep cowsay.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void ConfusedSheep (string args)
        {
            Console.Write("/--"); print(args); Console.WriteLine(@"--\");
            Console.WriteLine("|- " + args.ToUpper() + @" -|");
            Console.Write(@"\--"); print(args); Console.Write(@"--/");
            Console.WriteLine(@"
  \                 __
   \               (oo)
    \              (  )
     \             /--\
       __         / \  \
      UooU\.'@@@@@@`.\  )
      \__/(@@@@@@@@@@) /
           (@@@@@@@@)((
           `YY~~~~YY' \\
            ||    ||   >>
");
        }
    }
}