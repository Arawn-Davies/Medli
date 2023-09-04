/*
Copyright (c) 2012-2013, dewitcher Team
All rights reserved.

Redistribution and use in source and binary forms, with or without modification,
are permitted provided that the following conditions are met:

* Redistributions of source code must retain the above copyright notice
   this list of conditions and the following disclaimer.

* Redistributions in binary form must reproduce the above copyright notice,
  this list of conditions and the following disclaimer in the documentation
  and/or other materials provided with the distribution.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR
IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR
CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER
IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF
THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

using System;
using System.Collections.Generic;
using Cosmos.Hardware.BlockDevice;

namespace dewitcher.dev.Filesystem.WitchFS
{
	public class WitchFS
	{
        private AtaPio ATA = null;
        private Partition OSPartition = null;
        private Cosmos.System.Filesystem.FileSystem FS = null;
        private string osname;
        /// <summary>
        /// Initialize the Filesystem
        /// </summary>
        /// <param name="OSname"></param>
        public void Init(string OSname)
        {
            osname = OSname;
            if (FindHardDrive())
            {
                if (FindPartition())
                {
                    FS = new Cosmos.System.Filesystem.FileSystem();
                    if (!MapFS()) Core.Bluescreen.Init("WitchFS MappingException", "Mapping the filesystem to X drive failed!", false);
                }
                else
                {
                    Core.Bluescreen.Init("WitchFS PartitionException", "WitchFS cannot find a partition on your computer.", false);
                }
            }
            else
            {
                Core.Bluescreen.Init("WitchFS ATAException", "WitchFS cannot find a harddrive on your computer.", false);
            }
        }
        private bool FindHardDrive()
        {
            int harddrives = 0;
            for (int i = 0; i < BlockDevice.Devices.Count; i++)
            {
                if (BlockDevice.Devices[i] is AtaPio)
                {
                    ATA = (AtaPio)BlockDevice.Devices[i];
                    ++harddrives;
                    break;
                }
            }
            if (harddrives > 0) return true;
            else return false;
        }
        private bool FindPartition()
        {
            int partitions = 0;
            for (int j = 0; j < BlockDevice.Devices.Count; j++)
            {
                if (BlockDevice.Devices[j] is Partition)
                {
                    OSPartition = (Partition)BlockDevice.Devices[j];
                    ++partitions;
                    break;
                }
            }
            if (partitions > 0) return true;
            else return false;
        }
        private bool MapFS()
        {
            try
            {
                Cosmos.System.Filesystem.FileSystem.AddMapping("\\" + osname + "\\", FS);
                return true;
            }
            catch { return false; }
        }
	}
}
*/