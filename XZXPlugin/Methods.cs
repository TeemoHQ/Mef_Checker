using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace XZXPlugin
{
    class Methods
    {
        #region[新中新身份证读卡器]

        private const string DllPathXzx = "External\\Xzx\\SynIDCardAPI.dll";

        #region DLL Import

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct IdCardData
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)] public string Name; //姓名   
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6)] public string Sex; //性别
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)] public string Nation; //名族
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)] public string Born; //出生日期
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 72)] public string Address; //住址
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 38)] public string IDCardNo; //身份证号
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)] public string GrantDept; //发证机关
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)] public string UserLifeBegin; // 有效开始日期
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)] public string UserLifeEnd; // 有效截止日期

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 38)] public string reserved; // 保留
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)] public string PhotoFileName; // 照片路径
        }

        /************************端口类API *************************/

        [DllImport(DllPathXzx, EntryPoint = "Syn_GetCOMBaud", CharSet = CharSet.Ansi)]
        public static extern int Syn_GetCOMBaud(int nPort, ref uint puiBaudRate);

        [DllImport(DllPathXzx, EntryPoint = "Syn_SetCOMBaud", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetCOMBaud(int nPort, uint uiCurrBaud, uint uiSetBaud);

        [DllImport(DllPathXzx, EntryPoint = "Syn_OpenPort", CharSet = CharSet.Ansi)]
        public static extern int Syn_OpenPort(int nPort);

        [DllImport(DllPathXzx, EntryPoint = "Syn_ClosePort", CharSet = CharSet.Ansi)]
        public static extern int Syn_ClosePort(int nPort);

        /**************************SAM类函数 **************************/

        [DllImport(DllPathXzx, EntryPoint = "Syn_SetMaxRFByte", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetMaxRFByte(int nPort, byte ucByte, int iIfOpen);

        [DllImport(DllPathXzx, EntryPoint = "Syn_ResetSAM", CharSet = CharSet.Ansi)]
        public static extern int Syn_ResetSAM(int nPort, int iIfOpen);

        [DllImport(DllPathXzx, EntryPoint = "Syn_GetSAMStatus", CharSet = CharSet.Ansi)]
        public static extern int Syn_GetSAMStatus(int nPort, int iIfOpen);

        [DllImport(DllPathXzx, EntryPoint = "Syn_GetSAMID", CharSet = CharSet.Ansi)]
        public static extern int Syn_GetSAMID(int nPort, ref byte pucSAMID, int iIfOpen);

        [DllImport(DllPathXzx, EntryPoint = "Syn_GetSAMIDToStr", CharSet = CharSet.Ansi)]
        public static extern int Syn_GetSAMIDToStr(int nPort, ref byte pcSAMID, int iIfOpen);

        /*************************身份证卡类函数 ***************************/

        [DllImport(DllPathXzx, EntryPoint = "Syn_StartFindIDCard", CharSet = CharSet.Ansi)]
        public static extern int Syn_StartFindIDCard(int nPort, ref byte pucIIN, int iIfOpen);

        [DllImport(DllPathXzx, EntryPoint = "Syn_SelectIDCard", CharSet = CharSet.Ansi)]
        public static extern int Syn_SelectIDCard(int nPort, ref byte pucSN, int iIfOpen);

        [DllImport(DllPathXzx, EntryPoint = "Syn_ReadBaseMsg", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadBaseMsg(int nPort, ref byte pucCHMsg, ref uint puiCHMsgLen, ref byte pucPHMsg,
            ref uint puiPHMsgLen, int iIfOpen);

        [DllImport(DllPathXzx, EntryPoint = "Syn_ReadBaseMsgToFile", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadBaseMsgToFile(int nPort, ref byte pcCHMsgFileName, ref uint puiCHMsgFileLen,
            ref byte pcPHMsgFileName, ref uint puiPHMsgFileLen, int iIfOpen);

        [DllImport(DllPathXzx, EntryPoint = "Syn_ReadBaseFPMsg", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadBaseFPMsg(int nPort, ref byte pucCHMsg, ref uint puiCHMsgLen, ref byte pucPHMsg,
            ref uint puiPHMsgLen, ref byte pucFPMsg, ref uint puiFPMsgLen, int iIfOpen);

        [DllImport(DllPathXzx, EntryPoint = "Syn_ReadBaseFPMsgToFile", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadBaseFPMsgToFile(int nPort, ref byte pcCHMsgFileName, ref uint puiCHMsgFileLen,
            ref byte pcPHMsgFileName, ref uint puiPHMsgFileLen, ref byte pcFPMsgFileName, ref uint puiFPMsgFileLen,
            int iIfOpen);

        [DllImport(DllPathXzx, EntryPoint = "Syn_ReadNewAppMsg", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadNewAppMsg(int nPort, ref byte pucAppMsg, ref uint puiAppMsgLen, int iIfOpen);

        [DllImport(DllPathXzx, EntryPoint = "Syn_GetBmp", CharSet = CharSet.Ansi)]
        public static extern int Syn_GetBmp(int nPort, ref byte Wlt_File);

        [DllImport(DllPathXzx, EntryPoint = "Syn_ReadMsg", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadMsg(int nPortID, int iIfOpen, ref IdCardData pIDCardData);

        [DllImport(DllPathXzx, EntryPoint = "Syn_ReadFPMsg", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadFPMsg(int nPortID, int iIfOpen, ref IdCardData pIDCardData,
            ref byte cFPhotoname);

        [DllImport(DllPathXzx, EntryPoint = "Syn_FindReader", CharSet = CharSet.Ansi)]
        public static extern int Syn_FindReader();

        [DllImport(DllPathXzx, EntryPoint = "Syn_FindUSBReader", CharSet = CharSet.Ansi)]
        public static extern int Syn_FindUSBReader();

        /***********************设置附加功能函数 ************************/

        [DllImport(DllPathXzx, EntryPoint = "Syn_SetPhotoPath", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetPhotoPath(int iOption, ref byte cPhotoPath);

        [DllImport(DllPathXzx, EntryPoint = "Syn_SetPhotoType", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetPhotoType(int iType);

        [DllImport(DllPathXzx, EntryPoint = "Syn_SetPhotoName", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetPhotoName(int iType);

        [DllImport(DllPathXzx, EntryPoint = "Syn_SetSexType", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetSexType(int iType);

        [DllImport(DllPathXzx, EntryPoint = "Syn_SetNationType", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetNationType(int iType);

        [DllImport(DllPathXzx, EntryPoint = "Syn_SetBornType", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetBornType(int iType);

        [DllImport(DllPathXzx, EntryPoint = "Syn_SetUserLifeBType", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetUserLifeBType(int iType);

        [DllImport(DllPathXzx, EntryPoint = "Syn_SetUserLifeEType", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetUserLifeEType(int iType, int iOption);

        #endregion

        #endregion
    }
}
