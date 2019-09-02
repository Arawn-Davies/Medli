using System;
using System.Collections.Generic;
using System.Text;

namespace Medli.Common.Drivers
{
    public abstract class Driver
    {
        public string Name;

        public Driver()
        {
            Kernel.Drivers.Add(this);
        }

        public abstract bool Init();
    }
}
