using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace A6Plugin
{
    public class Methods
    {

        private const string DllPathActA6 = "External\\Act_A6\\A6CRTAPI.dll";

        [DllImport(DllPathActA6, EntryPoint = "A6_Connect", CharSet = CharSet.Ansi)]
        public static extern int A6_Connect(int dwPort, int dwSpeed, ref int phReader);

        [DllImport(DllPathActA6, EntryPoint = "A6_Disconnect", CharSet = CharSet.Ansi)]
        public static extern int A6_Disconnect(int hReader);

        [DllImport(DllPathActA6, EntryPoint = "A6_Initialize", CharSet = CharSet.Ansi)]
        public static extern int A6_Initialize(int hReader, byte bResetMode, byte[] pbVerBuff, ref int pcbVerLength);

        [DllImport(DllPathActA6, EntryPoint = "A6_GetCRCondition", CharSet = CharSet.Ansi)]
        public static extern int A6_GetCRCondition(int hReader, byte[] pStatus);

        [DllImport(DllPathActA6, EntryPoint = "A6_SetCardIn", CharSet = CharSet.Ansi)]
        public static extern int A6_SetCardIn(int hReader, byte bFrontSet, byte bRearSet);

        [DllImport(DllPathActA6, EntryPoint = "A6_SetDockedPos", CharSet = CharSet.Ansi)]
        public static extern int A6_SetDockedPos(int hReader, byte bDockedPos);

        [DllImport(DllPathActA6, EntryPoint = "A6_MoveCard", CharSet = CharSet.Ansi)]
        public static extern int A6_MoveCard(int hReader, int bMoveMethod);

        [DllImport(DllPathActA6, EntryPoint = "A6_LedOn", CharSet = CharSet.Ansi)]
        public static extern int A6_LedOn(int hReader);

        [DllImport(DllPathActA6, EntryPoint = "A6_LedOff", CharSet = CharSet.Ansi)]
        public static extern int A6_LedOff(int hReader);

        [DllImport(DllPathActA6, EntryPoint = "A6_LedBlink", CharSet = CharSet.Ansi)]
        public static extern int A6_LedBlink(int hReader, byte bOnTime, byte bOffTime);

        [DllImport(DllPathActA6, EntryPoint = "A6_DetectIccType", CharSet = CharSet.Ansi)]
        public static extern int A6_DetectIccType(int hReader, ref byte pbType);

        [DllImport(DllPathActA6, EntryPoint = "A6_IccPowerOn", CharSet = CharSet.Ansi)]
        public static extern int A6_IccPowerOn(int hReader);

        [DllImport(DllPathActA6, EntryPoint = "A6_IccPowerOff", CharSet = CharSet.Ansi)]
        public static extern int A6_IccPowerOff(int hReader);

        [DllImport(DllPathActA6, EntryPoint = "A6_CpuColdReset", CharSet = CharSet.Ansi)]
        public static extern int A6_CpuColdReset(int hReader, byte[] pbATRBuff, ref int pcbATRLength);

        [DllImport(DllPathActA6, EntryPoint = "A6_CpuWarmReset", CharSet = CharSet.Ansi)]
        public static extern int A6_CpuWarmReset(int hReader, byte[] pbATRBuff, ref int pcbATRLength);

        [DllImport(DllPathActA6, EntryPoint = "A6_CpuTransmit", CharSet = CharSet.Ansi)]
        public static extern int A6_CpuTransmit(int hReader, byte bProtocol, byte[] pbSendBuff, int cbSendLength,
            byte[] pbRecvBuff, ref int pcbRecvLength);

        [DllImport(DllPathActA6, EntryPoint = "A6_ReadTracks", CharSet = CharSet.Ansi)]
        public static extern int A6_ReadTracks(int hReader, byte bMode, uint iTrackID, ref TrackInfo pTrackInfo);

        [DllImport(DllPathActA6, EntryPoint = "A6_TypeACpuSelect", CharSet = CharSet.Ansi)]
        public static extern int A6_TypeACpuSelect(int hReader, byte[] pbATRBuff, ref int pcbATRLength);

        [DllImport(DllPathActA6, EntryPoint = "A6_TypeBCpuSelect", CharSet = CharSet.Ansi)]
        public static extern int A6_TypeBCpuSelect(int hReader, byte[] pbATRBuff, ref int pcbATRLength);

        [DllImport(DllPathActA6, EntryPoint = "A6_TypeABCpuDeselect", CharSet = CharSet.Ansi)]
        public static extern int A6_TypeABCpuDeselect(int hReader);

        [DllImport(DllPathActA6, EntryPoint = "A6_TypeABCpuTransmit", CharSet = CharSet.Ansi)]
        public static extern int A6_TypeABCpuTransmit(int hReader, byte[] pbSendBuff, ushort cbSendLength,
            byte[] pbRecvBuff, ref int pcbRecvLength);

        [DllImport(DllPathActA6, EntryPoint = "A6_TypeACpuGetUID", CharSet = CharSet.Ansi)]
        public static extern int A6_TypeACpuGetUID(int hReader, byte[] pbUIDBuff, ref int pcbUIDLength);

        //for M1 card
        [DllImport(DllPathActA6, EntryPoint = "A6_SxxSelect", CharSet = CharSet.Ansi)]
        public static extern int A6_SxxSelect(int hReader);

        [DllImport(DllPathActA6, EntryPoint = "A6_SxxGetUID", CharSet = CharSet.Ansi)]
        public static extern int A6_SxxGetUID(int hReader, byte[] pbUIDBuff, ref int pcbUIDLength);

        [DllImport(DllPathActA6, EntryPoint = "A6_SxxVerifyPassword", CharSet = CharSet.Ansi)]
        public static extern int A6_SxxVerifyPassword(int hReader, byte sec, bool isKeyA, byte[] data);

        [DllImport(DllPathActA6, EntryPoint = "A6_SxxReadBlock", CharSet = CharSet.Ansi)]
        public static extern int A6_SxxReadBlock(int hReader, byte sec, byte block, byte[] data);

        [DllImport(DllPathActA6, EntryPoint = "A6_SxxWriteBlock", CharSet = CharSet.Ansi)]
        public static extern int A6_SxxWriteBlock(int hReader, byte sec, byte block, byte[] data);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TrackInfo
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3 * 512)]
        public byte[] Contents;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public int[] Lengths;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] Status;
    }
}
