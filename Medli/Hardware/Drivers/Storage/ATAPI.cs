using System;
using System.Collections.Generic;
using System.Text;
using Medli.Core;

namespace Medli.Hardware.Drivers.Storage
{
	public class ATAPI : BusIO
	{
        protected UInt16 DataReg;
        protected UInt16 FeatureReg;
        protected UInt16 SectorCountReg;
        protected UInt16 CommandReg;
        protected UInt16 StatusReg;
        protected UInt16 AltStatusReg;
        protected UInt16 ControlReg;

        protected UInt16 LBA0;
        protected UInt16 LBA1;
        protected UInt16 LBA2;

        protected UInt16 DeviceSelect;

        protected UInt32 mCylinder;
        protected UInt32 mHeads;
        protected UInt32 mSize;
        protected UInt32 mSectorsPerTrack;
        protected UInt32 mCommandSet;
        protected string mModel;
        protected string mSerialNo;
        protected bool mLBASupport;
        protected bool mIsRemovable;
        protected int mBufferSize;
        protected byte[] mATAPI_Packet;

        protected bool IRQInvoked;

        protected Cosmos.HAL.BlockDevice.Ata.ControllerIdEnum cID;
        protected Cosmos.HAL.BlockDevice.Ata.BusPositionEnum BPos;

        public static void Init()
        {
            
        }
    }
}
