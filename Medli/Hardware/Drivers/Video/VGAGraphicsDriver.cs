#define COSMOSDEBUG
using System;
using System.Drawing;

using Cosmos.Core;
using Cosmos.Debug.Kernel;

/*****************************************************************************
Sets VGA-compatible video modes without using the BIOS
 * http://bos.asmhackers.net/docs/vga_without_bios/
 * adapted from code by Chris Giese <geezer@execpc.com>	http://www.execpc.com/~geezer
 * by Stephen Remde
//*/

namespace Medli.Hardware.Drivers.Graphics
{
    public class VGADriver
    {
        internal Debugger mDebugger = new Debugger("HAL", "VGA");
        private const byte NumSeqRegs = 5;
        private const byte NumCRTCRegs = 25;
        private const byte NumGCRegs = 9;
        private const byte NumACRegs = 21;

        private readonly Cosmos.Core.IOGroup.VGA mIO = new Cosmos.Core.IOGroup.VGA();

        private void WriteVGARegisters(byte[] registers)
        {
            int xIdx = 0;
            byte i;

            /* write MISCELLANEOUS reg */
            mIO.MiscellaneousOutput_Write.Byte = registers[xIdx];
            xIdx++;
            /* write SEQUENCER regs */
            for (i = 0; i < NumSeqRegs; i++)
            {
                mIO.Sequencer_Index.Byte = i;
                mIO.Sequencer_Data.Byte = registers[xIdx];
                xIdx++;
            }
            /* unlock CRTC registers */
            mIO.CRTController_Index.Byte = 0x03;
            mIO.CRTController_Data.Byte = (byte)(mIO.CRTController_Data.Byte | 0x80);
            mIO.CRTController_Index.Byte = 0x11;
            mIO.CRTController_Data.Byte = (byte)(mIO.CRTController_Data.Byte & 0x7F);

            /* make sure they remain unlocked */
            registers[0x03] |= 0x80;
            registers[0x11] &= 0x7f;

            /* write CRTC regs */
            for (i = 0; i < NumCRTCRegs; i++)
            {
                mIO.CRTController_Index.Byte = i;
                mIO.CRTController_Data.Byte = registers[xIdx];
                xIdx++;
            }
            /* write GRAPHICS CONTROLLER regs */
            for (i = 0; i < NumGCRegs; i++)
            {
                mIO.GraphicsController_Index.Byte = i;
                mIO.GraphicsController_Data.Byte = registers[xIdx];
                xIdx++;
            }
            /* write ATTRIBUTE CONTROLLER regs */
            for (i = 0; i < NumACRegs; i++)
            {
                var xDoSomething = mIO.Instat_Read.Byte;
                mIO.AttributeController_Index.Byte = i;
                mIO.AttributeController_Write.Byte = registers[xIdx];
                xIdx++;
            }
            /* lock 16-color palette and unblank display */
            var xNothing = mIO.Instat_Read.Byte;
            mIO.AttributeController_Index.Byte = 0x20;
        }

        private void SetPlane(byte p)
        {
            byte pmask;

            p &= 3;
            pmask = (byte)(1 << p);
            /* set read plane */
            mIO.GraphicsController_Index.Byte = 4;
            mIO.GraphicsController_Data.Byte = p;
            /* set write plane */
            mIO.Sequencer_Index.Byte = 2;
            mIO.Sequencer_Data.Byte = pmask;
        }

        //int offset = 0xb8000;
        private MemoryBlock08 GetFramebufferSegment()
        {
            mIO.GraphicsController_Index.Byte = 6;
            int seg = mIO.GraphicsController_Data.Byte;
            mDebugger.Send($"VGA: raw seg value: {seg}");
            seg >>= 2;

            seg &= 3;
            switch (seg)
            {
                case 0:
                case 1:
                    return mIO.VGAMemoryBlock;
                case 2:
                    return mIO.MonochromeTextMemoryBlock;
                case 3:
                    return mIO.CGATextMemoryBlock;
            }
            throw new Exception("Unable to determine memory segment!");
        }

        public SetPixelDelegate SetPixel;
        public GetPixelDelegate GetPixel;

        public VGADriver()
        {
            SetPixel = new SetPixelDelegate(SetPixelNoMode);
            GetPixel = new GetPixelDelegate(GetPixelNoMode);
        }

        public delegate void SetPixelDelegate(uint x, uint y, uint c);

        public delegate uint GetPixelDelegate(uint x, uint y);

        public uint this[uint x, uint y]
        {
            get
            {
                return GetPixel(x, y);
            }
            set
            {
                SetPixel(x, y, value);
            }
        }



        public enum ScreenSize
        {
            /// <summary>
            /// 640x480 graphics mode  - 2 and 4 bit color depth avaible
            /// </summary>
            Size640x480,

            /// <summary>
            /// 720x480 graphics mode  - 16 bit color depth avaible
            /// </summary>
            Size720x480,

            /// <summary>
            /// 320x200 graphics mode  - 4 and 8 bit color depth avaible
            /// </summary>
            Size320x200
        };

        public enum ColorDepth
        {
            BitDepth2,
            BitDepth4,
            BitDepth8,
            BitDepth16
        };

        

        public void SetGraphicsMode(ScreenSize aSize, ColorDepth aDepth)
        {
            switch (aSize)
            {
                case ScreenSize.Size320x200:
                    if (aDepth == ColorDepth.BitDepth8)
                    {
                        mDebugger.Send("Setting graphic mode to 320x200@256");
                        WriteVGARegisters(g_320x200x8);

                        PixelWidth = 320;
                        PixelHeight = 200;
                        Colors = 256;
                        SetPixel = new SetPixelDelegate(SetPixel320x200x8);
                        GetPixel = new GetPixelDelegate(GetPixel320x200x8);
                    }
                    else if (aDepth == ColorDepth.BitDepth4)
                    {
                        WriteVGARegisters(g_320x200x4);

                        PixelWidth = 320;
                        PixelHeight = 200;
                        Colors = 16;
                        //SetPixel = new SetPixelDelegate(SetPixel320x200x4);
                        //GetPixel = new GetPixelDelegate(GetPixel320x200x4);
                    }
                    else throw new Exception("Unsupported color depth passed for specified screen size");
                    break;
                case ScreenSize.Size640x480:
                    if (aDepth == ColorDepth.BitDepth2)
                    {
                        WriteVGARegisters(g_640x480x2);

                        PixelWidth = 640;
                        PixelHeight = 480;
                        Colors = 4;
                        //SetPixel = new SetPixelDelegate(SetPixel640x480x2);
                        //GetPixel = new GetPixelDelegate(GetPixel640x480x2);
                    }
                    else if (aDepth == ColorDepth.BitDepth4)
                    {
                        WriteVGARegisters(g_640x480x4);

                        PixelWidth = 640;
                        PixelHeight = 480;
                        Colors = 16;
                        SetPixel = new SetPixelDelegate(SetPixel640x480x4);
                        GetPixel = new GetPixelDelegate(GetPixel640x480x4);
                    }
                    else throw new Exception("Unsupported color depth passed for specified screen size");
                    break;
                case ScreenSize.Size720x480:
                    if (aDepth == ColorDepth.BitDepth4)
                    {
                        WriteVGARegisters(g_720x480x4);

                        PixelWidth = 720;
                        PixelHeight = 480;
                        Colors = 16;
                        SetPixel = new SetPixelDelegate(SetPixel720x480x4);
                        GetPixel = new GetPixelDelegate(GetPixel720x480x4);
                    }
                    else throw new Exception("Unsupported color depth passed for specified screen size");
                    break;
                default:
                    throw new Exception("Unknown screen size");
            }
        }

        //public void SetPixel320x200x4(uint x, uint y, uint c);
        //public uint GetPixel320x200x4(uint x, uint y);
        public void SetPixel320x200x8(uint x, uint y, uint c)
        {
            uint where = (y * 320) + x;
            byte color = (byte)(c & 0xFF);

            mDebugger.Send($"Drawing pixel at {where}, with color {color}");
            mIO.VGAMemoryBlock[where] = color;
            mDebugger.Send($"Pixel drawn but you cannot see it!");
        }

        public uint GetPixel320x200x8(uint x, uint y)
        {
            return mIO.VGAMemoryBlock[(y * 320) + x];
        }

        //public void SetPixel640x480x2(uint x, uint y, uint c);
        //public uint GetPixel640x480x2(uint x, uint y);

        public void SetPixel640x480x4(uint x, uint y, uint c)
        {
            uint offset = (uint)(x / 8 + (PixelWidth / 8) * y);

            x = (x & 7) * 1;

            uint mask = (byte)(0x80 >> (int)x);
            uint pmask = 1;

            for (byte p = 0; p < 4; p++)
            {
                SetPlane(p);

                if ((pmask & c) != 0)
                {
                    mIO.VGAMemoryBlock[offset] = (byte)(mIO.VGAMemoryBlock[offset] | mask);
                }

                else
                {
                    mIO.VGAMemoryBlock[offset] = (byte)(mIO.VGAMemoryBlock[offset] & ~mask);
                }

                pmask <<= 1;
            }
        }

        public uint GetPixel640x480x4(uint x, uint y)
        {
            uint offset = (uint)(x / 8 + (PixelWidth / 8) * y);

            uint pmask = 1;

            uint color = 0;

            for (byte p = 0; p < 4; p++)
            {
                SetPlane(p);

                if (mIO.VGAMemoryBlock[offset] == 255)
                {
                    color += pmask;
                }

                pmask <<= 1;
            }

            return color;
        }

        public void SetPixel720x480x4(uint x, uint y, uint c)
        {
            uint offset = (uint)(x / 8 + (PixelWidth / 8) * y);

            x = (x & 7) * 1;

            uint mask = (byte)(0x80 >> (int)x);
            uint pmask = 1;

            for (byte p = 0; p < 4; p++)
            {
                SetPlane(p);

                if ((pmask & c) != 0)
                {
                    mIO.VGAMemoryBlock[offset] = (byte)(mIO.VGAMemoryBlock[offset] | mask);
                }

                else
                {
                    mIO.VGAMemoryBlock[offset] = (byte)(mIO.VGAMemoryBlock[offset] & ~mask);
                }

                pmask <<= 1;
            }
        }

        public uint GetPixel720x480x4(uint x, uint y)
        {
            uint offset = (uint)(x / 8 + (PixelWidth / 8) * y);

            uint pmask = 1;

            uint color = 0;

            for (byte p = 0; p < 4; p++)
            {
                SetPlane(p);

                if (mIO.VGAMemoryBlock[offset] == 255)
                {
                    color += pmask;
                }

                pmask <<= 1;
            }

            return color;
        }

        private void SetPixelNoMode(uint x, uint y, uint c)
        {
            throw new Exception("No video mode set!");
        }

        private uint GetPixelNoMode(uint x, uint y)
        {
            throw new Exception("No video mode set!");
        }

        public int PixelWidth { private set; get; }
        public int PixelHeight { private set; get; }
        public int Colors { private set; get; }

        public void TestMode320x200x8()
        {
            SetGraphicsMode(ScreenSize.Size320x200, ColorDepth.BitDepth8);

            for (byte i = 0; i < 64; i++)
            {
                SetPaletteEntry(i, i, 0, 0);
                SetPaletteEntry(i + 64, 63, i, 0);
                SetPaletteEntry(i + 128, 63, 63, i);
                SetPaletteEntry(i + 192, (byte)(63 - i), (byte)(63 - i), (byte)(63 - i));
            }

            var xSegment = GetFramebufferSegment();

            for (uint y = 0; y < PixelHeight; y++)
            {
                for (uint x = 0; x < PixelWidth; x++)
                {
                    xSegment[(y * 320) + x] = (byte)(x + y);
                }
            }
        }

        public void Clear(int color)
        {
            for (int y = 0; y < PixelHeight; y++)
            {
                for (int x = 0; x < PixelWidth; x++)
                {
                    SetPixel((uint)x, (uint)y, (uint)color);
                }
            }
        }

        // TODO: Enable code that uses Color when we move to .NET Core 2.1 (plug won't be needed)

        //private Color[] _Palette = new Color[256];

        //public Color GetPaletteEntry(int index)
        //{
        //    return _Palette[index];
        //}

        public void SetPalette(int index, byte[] pallete)
        {
            mIO.DACIndex_Write.Byte = (byte)index;
            for (int i = 0; i < pallete.Length; i++)
                mIO.DAC_Data.Byte = (byte)(pallete[i] >> 2);
        }

        //public void SetPaletteEntry(int index, Color color)
        //{
        //    SetPaletteEntry(index, color.R, color.G, color.B);
        //}

        public void SetPaletteEntry(int index, byte r, byte g, byte b)
        {
            mIO.DACIndex_Write.Byte = (byte)index;
            mIO.DAC_Data.Byte = (byte)(r >> 2);
            mIO.DAC_Data.Byte = (byte)(g >> 2);
            mIO.DAC_Data.Byte = (byte)(b >> 2);
        }

        #region MODES

        private static byte[] g_640x480x4 = new byte[]
                                            {
                                                /* MISC */
                                                0xE3,
                                                /* SEQ */
                                                0x03, 0x01, 0x08, 0x00, 0x06,
                                                /* CRTC */
                                                0x5F, 0x4F, 0x50, 0x82, 0x54, 0x80, 0x0B, 0x3E,
                                                0x00, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                                0xEA, 0x0C, 0xDF, 0x28, 0x00, 0xE7, 0x04, 0xE3,
                                                0xFF,
                                                /* GC */
                                                0x00, 0x00, 0x00, 0x00, 0x03, 0x00, 0x05, 0x0F,
                                                0xFF,
                                                /* AC */
                                                0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x14, 0x07,
                                                0x38, 0x39, 0x3A, 0x3B, 0x3C, 0x3D, 0x3E, 0x3F,
                                                0x01, 0x00, 0x0F, 0x00, 0x00
                                            };

        private static byte[] g_320x200x8 = new byte[]
                                            {
                                                /* MISC */
                                                0x63,
                                                /* SEQ */
                                                0x03, 0x01, 0x0F, 0x00, 0x0E,
                                                /* CRTC */
                                                0x5F, 0x4F, 0x50, 0x82, 0x54, 0x80, 0xBF, 0x1F,
                                                0x00, 0x41, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                                0x9C, 0x0E, 0x8F, 0x28, 0x40, 0x96, 0xB9, 0xA3,
                                                0xFF,
                                                /* GC */
                                                0x00, 0x00, 0x00, 0x00, 0x00, 0x40, 0x05, 0x0F,
                                                0xFF,
                                                /* AC */
                                                0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07,
                                                0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F,
                                                0x41, 0x00, 0x0F, 0x00, 0x00
                                            };

        private static byte[] g_720x480x4 = new byte[]
                                            {
                                                /* MISC */
                                                0xE7,
                                                /* SEQ */
                                                0x03, 0x01, 0x08, 0x00, 0x06,
                                                /* CRTC */
                                                0x6B, 0x59, 0x5A, 0x82, 0x60, 0x8D, 0x0B, 0x3E,
                                                0x00, 0x40, 0x06, 0x07, 0x00, 0x00, 0x00, 0x00,
                                                0xEA, 0x0C, 0xDF, 0x2D, 0x08, 0xE8, 0x05, 0xE3,
                                                0xFF,
                                                /* GC */
                                                0x00, 0x00, 0x00, 0x00, 0x03, 0x00, 0x05, 0x0F,
                                                0xFF,
                                                /* AC */
                                                0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07,
                                                0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F,
                                                0x01, 0x00, 0x0F, 0x00, 0x00,
                                            };

        

        private static byte[] g_320x200x4 = new byte[]
                                            {
                                                /* MISC */
                                                0x63,
                                                /* SEQ */
                                                0x03, 0x09, 0x03, 0x00, 0x02,
                                                /* CRTC */
                                                0x2D, 0x27, 0x28, 0x90, 0x2B, 0x80, 0xBF, 0x1F,
                                                0x00, 0x41, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                                0x9C, 0x0E, 0x8F, 0x14, 0x00, 0x96, 0xB9, 0xA3,
                                                0xFF,
                                                /* GC */
                                                0x00, 0x00, 0x00, 0x00, 0x00, 0x30, 0x02, 0x00,
                                                0xFF,
                                                /* AC */
                                                0x00, 0x13, 0x15, 0x17, 0x02, 0x04, 0x06, 0x07,
                                                0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17,
                                                0x01, 0x00, 0x03, 0x00, 0x00
                                            };

        private static byte[] g_640x480x2 = new byte[]
                                            {
                                                /* MISC */
                                                0xE3,
                                                /* SEQ */
                                                0x03, 0x01, 0x0F, 0x00, 0x06,
                                                /* CRTC */
                                                0x5F, 0x4F, 0x50, 0x82, 0x54, 0x80, 0x0B, 0x3E,
                                                0x00, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                                0xEA, 0x0C, 0xDF, 0x28, 0x00, 0xE7, 0x04, 0xE3,
                                                0xFF,
                                                /* GC */
                                                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x05, 0x0F,
                                                0xFF,
                                                /* AC */
                                                0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x14, 0x07,
                                                0x38, 0x39, 0x3A, 0x3B, 0x3C, 0x3D, 0x3E, 0x3F,
                                                0x01, 0x00, 0x0F, 0x00, 0x00
                                            };

        #endregion
    }
}
