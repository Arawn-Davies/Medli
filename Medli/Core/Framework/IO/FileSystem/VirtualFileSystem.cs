/*
Copyright (c) 2012-2013, dewitcher Team
Copyright (c) 2019, Siaranite Solutions
Copyright (c) 2019, Cosmos

All rights reserved.

See in the /Licenses folder for the licenses for each respected project.


// I got kind of lazy and decieded to use the code from GDOS....


//Can be updated and implemented at a later stage

//If the Joker was a high-level programming language what would he say to Batman?
//Y SO LOW LEVEL???

using System;
using System.Collections.Generic;
using System.Text;

namespace Medli.Core.Framework.IO.FileSystem
{
    public class Drive
    {
        public GruntyOS.HAL.StorageDevice Filesystem;
        public string DeviceFile;
    }
    public class VirtualFileSystem
    {
        private List<Drive> fileSystems = new List<Drive>();
        public void AddDrive(Drive fileSystem)
        {
            fileSystems.Add(fileSystem);
        }
        public GruntyOS.HAL.StorageDevice getDrive(string path)
        {
            int DriveNum = (int)(((byte)path.ToCharArray()[0]) - 65);
            return fileSystems[DriveNum].Filesystem;
        }
        public string GetDeviceHandle(string path)
        {
            int DriveNum = (int)(((byte)path.ToCharArray()[0]) - 65);
            return fileSystems[DriveNum].DeviceFile;
        }
        public void Chmod(string f, string perms)
        {
            string RealPath = f.Substring(3);
            getDrive(f).Chmod(RealPath, perms);
        }
        public void Delete(string Path)
        {
            string RealPath = Path.Substring(3);
            getDrive(Path).Delete(RealPath);
        }
        public void Chown(string f, string perms)
        {

            string RealPath = f.Substring(2);
            getDrive(f).Chmod(RealPath, perms);
        }
        public GruntyOS.HAL.fsEntry[] getLongList(string dir)
        {
            string RealPath = dir.Substring(2);
            return getDrive(dir).getLongList(RealPath);
        }
        public string[] ListDirectories(string dir)
        {
            string RealPath = dir.Substring(2);
            return getDrive(dir).ListDirectories(RealPath);
        }
        public string[] ListFiles(string dir)
        {

            string RealPath = dir.Substring(2);

            return getDrive(dir).ListFiles(RealPath);
        }
        public string[] ListJustFiles(string dir)
        {

            string RealPath = dir.Substring(2);
            return getDrive(dir).ListJustFiles(RealPath);
        }
        public void makeDir(string name, string owner)
        {
            string RealPath = name.Substring(2);
            getDrive(name).makeDir(RealPath, owner);
        }
        public void Move(string s1, string s2)
        {
            throw new NotImplementedException();
        }
        public byte[] readFile(string name)
        {
            string RealPath = name.Substring(2);
            return getDrive(name).readFile(RealPath);
        }
        public void saveFile(byte[] data, string name, string owner)
        {
            string RealPath = name.Substring(2);
            getDrive(name).saveFile(data, RealPath, owner);
        }
    }

}
*/