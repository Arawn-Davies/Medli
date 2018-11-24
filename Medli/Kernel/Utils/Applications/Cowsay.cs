using System;
using System.Collections.Generic;
using System.Linq;

namespace Medli.Apps
{
    /// <summary>
    /// A must-have for any command line operating system
    /// Doesn't have the other characters from the actual cowsay,
    /// but it'll do for now :P
    /// </summary>
    public class Cowsay : Command
    {
		public override string Name
		{
			get
			{
				return "cowsay";
			}
		}
		public override string Summary
		{
			get
			{
				return "A little *nix easter egg";
			}
		}
		public override void Execute(string param)
		{
			if (param == null)
			{
				Cowsay.Cow("Say something using 'Cowsay <message>'");
				Console.WriteLine(@"You can also use 'cowsay -f' tux for penguin, cow for cow and 
sodomized-sheep for, you guessed it, a sodomized-sheep");
			}
			else
			{
				string[] args = param.Split(' ');
				if (args[0] == "-f")
				{
					if (args[1] == "cow")
					{
						Cowsay.Cow(param.Remove(0, args[0].Length + args[1].Length + 3));
					}
					else if (args[1] == "tux")
					{
						Cowsay.Tux(param.Remove(0, args[0].Length + args[1].Length + 3));
					}
					else if (args[1] == "sodomized-sheep")
					{
						Cowsay.SodomizedSheep(param.Remove(0, args[0].Length + args[1].Length + 3));
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
        public static void SodomizedSheep (string args)
        {
            Console.Write("/--"); print(args); Console.WriteLine(@"--\");
            Console.WriteLine("|- " + args + @" -|");
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