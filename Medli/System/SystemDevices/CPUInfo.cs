/*
 * The following class contains code released under the MIT Licence
 * 
 * ORIGIN:          Aura Operating System Development
 * CONTENT:         Computer Information
 * PROGRAMMERS:     Alexy DA CRUZ <dacruzalexy@gmail.com>
*/

using System;
using System.Collections.Generic;
using System.Text;
//using Cosmos.HAL.PCInformation;

namespace Medli.System
{
    class CPUInfo
    {
        /*public static void ListFlags()
		{
			int j = 1;
			foreach (Processor proc in ListProcessors)
			{
				if (j == 1)
				{
					lsflags(proc);
				}
			}
		}
		
		public static List<Processor> Processors = new List<Processor>();

        public static int CPUCount()
		{
			int number = 0;
			foreach (var x in ListProcessors)
			{
				Processors.Add(x);
				number++;
			}
			return number;
		}

		private static List<ProcessorFlags> _procflags;

		private static List<Processor> _listProcessors;
		public static List<Processor> ListProcessors
		{
			get
			{
				//This is to allow multiprocessor on a future
				//TODO: search a list of processors based on the topology
				if (_listProcessors == null)
				{
					_listProcessors = new List<Processor>();
					_listProcessors.Add(new Processor());
				}
				return _listProcessors;
			}
		}

		public static void LSCPU()
		{
			Console.WriteLine("Processor(s): " + CPUCount() + " installed processor(s).");
			int j = 1;
			foreach (Processor processor in ListProcessors)
			{
				if (j == 1)
				{
					//lsflags(processor);
				}
				Console.WriteLine("[" + j + "] : " + processor.GetBrandName() + (int)processor.Frequency + " Mhz");
				j++;
				
			}
			Processors.Clear();
		}
		
		public static void lsflags(Processor proc)
		{
			foreach (ProcessorFlags flag in proc.Flags)
			{
				_procflags.Add(flag);
			}
			foreach (ProcessorFlags procflag in _procflags)
			{
				Console.Write(procflag + " ");
			}
			_procflags.Clear();
		}*/
		
	}
}
