using System;
using System.Collections.Generic;
using System.Text;

namespace Medli.Hardware
{
    public interface IPS2Device
    {
        byte PS2Port { get; }
        void Initialize();
    }
}
