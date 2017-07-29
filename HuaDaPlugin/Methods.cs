using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HuaDaPlugin
{
    public class Methods
    {
        #region 华大四合一读卡器

        private const string DllPathHuaDa = "External\\HuaDa\\SSSE32.dll";

        #region 公共函数

        [DllImport(DllPathHuaDa, EntryPoint = "ICC_Reader_Open", CharSet = CharSet.Ansi)]
        public static extern int ICC_Reader_Open(string dev_Name);

        [DllImport(DllPathHuaDa, EntryPoint = "ICC_Reader_Close", CharSet = CharSet.Ansi)]
        public static extern int ICC_Reader_Close(int readerHandle);

        [DllImport(DllPathHuaDa, EntryPoint = "ICC_PosBeep", CharSet = CharSet.Ansi)]
        public static extern int ICC_PosBeep(int readerHandle, byte time);

        [DllImport(DllPathHuaDa, EntryPoint = "ICC_Reader_ReadEEPROM", CharSet = CharSet.Ansi)]
        public static extern int ICC_Reader_ReadEEPROM(int readerHandle, int offset, int length, byte[] buffer);

        [DllImport(DllPathHuaDa, EntryPoint = "ICC_Reader_WriteEEPROM", CharSet = CharSet.Ansi)]
        public static extern int ICC_Reader_WriteEEPROM(int ReaderHandle, int offset, int length, byte[] buffer);

        [DllImport(DllPathHuaDa, EntryPoint = "ICC_Reader_GetDeviceVersion", CharSet = CharSet.Ansi)]
        public static extern int ICC_Reader_GetDeviceVersion(int ReaderHandle, byte[] VSoftware, byte[] VHardware,
            byte[] VBoot, byte[] VDate);

        [DllImport(DllPathHuaDa, EntryPoint = "ICC_Reader_GetDeviceCSN", CharSet = CharSet.Ansi)]
        public static extern int ICC_Reader_GetDeviceCSN(int ReaderHandle, StringBuilder dev_Ser);

        [DllImport(DllPathHuaDa, EntryPoint = "ICC_Reader_GetDeviceSN", CharSet = CharSet.Ansi)]
        public static extern int ICC_Reader_GetDeviceSN(int ReaderHandle, StringBuilder dev_Ser);

        [DllImport(DllPathHuaDa, EntryPoint = "ICC_Reader_SetDeviceSN", CharSet = CharSet.Ansi)]
        public static extern int ICC_Reader_SetDeviceSN(int ReaderHandle, string dev_Ser);

        [DllImport(DllPathHuaDa, EntryPoint = "ICC_Reader_GetKeyBoardVersion", CharSet = CharSet.Ansi)]
        public static extern int ICC_Reader_GetKeyBoardVersion(int ReaderHandle, StringBuilder ver);

        [DllImport(DllPathHuaDa, EntryPoint = "ICC_Reader_DisCardType", CharSet = CharSet.Ansi)]
        public static extern int ICC_Reader_DisCardType(int ReaderHandle);

        [DllImport(DllPathHuaDa, EntryPoint = "ICC_Reader_GetMagCardMode", CharSet = CharSet.Ansi)]
        public static extern int ICC_Reader_GetMagCardMode(int ReaderHandle, ref int Mode, ref int Track);

        [DllImport(DllPathHuaDa, EntryPoint = "ICC_Reader_SetMagCardMode", CharSet = CharSet.Ansi)]
        public static extern int ICC_Reader_SetMagCardMode(int ReaderHandle, int Mode, int Track);

        [DllImport(DllPathHuaDa, EntryPoint = "ICC_Reader_ChangeSlot", CharSet = CharSet.Ansi)]
        public static extern int ICC_Reader_ChangeSlot(int ReaderHandle, byte slot);

        [DllImport(DllPathHuaDa, EntryPoint = "StrToHex", CharSet = CharSet.Ansi)]
        public static extern int StrToHex(byte[] strIn, int inLen, byte[] strOut);

        [DllImport(DllPathHuaDa, EntryPoint = "HexToStr", CharSet = CharSet.Ansi)]
        public static extern int HexToStr(byte[] strIn, int inLen, byte[] strOut);

        [DllImport(DllPathHuaDa, EntryPoint = "ICC_DispSound", CharSet = CharSet.Ansi)]
        public static extern int ICC_DispSound(int ReaderHandle, byte type, byte nMode);

        #endregion

        #region 接触CPU卡操作函数

        [DllImport(DllPathHuaDa, EntryPoint = "ICC_Reader_PowerOn", CharSet = CharSet.Ansi)]
        public static extern int ICC_Reader_PowerOn(int ReaderHandle, byte ICC_Slot_No, byte[] Response);

        [DllImport(DllPathHuaDa, EntryPoint = "ICC_Reader_PowerOnHEX", CharSet = CharSet.Ansi)]
        public static extern int ICC_Reader_PowerOnHEX(int ReaderHandle, byte ICC_Slot_No, byte[] Response);

        [DllImport(DllPathHuaDa, EntryPoint = "ICC_Reader_PowerOff", CharSet = CharSet.Ansi)]
        public static extern int ICC_Reader_PowerOff(int ReaderHandle, byte ICC_Slot_No);

        [DllImport(DllPathHuaDa, EntryPoint = "ICC_Reader_GetStatus", CharSet = CharSet.Ansi)]
        public static extern int ICC_Reader_GetStatus(int ReaderHandle, byte ICC_Slot_No);

        [DllImport(DllPathHuaDa, EntryPoint = "ICC_Reader_Application", CharSet = CharSet.Ansi)]
        public static extern int ICC_Reader_Application(int ReaderHandle, byte ICC_Slot_No, int Lenth_of_Command_APDU,
            byte[] Command_APDU, byte[] Response_APDU);

        [DllImport(DllPathHuaDa, EntryPoint = "ICC_Reader_ApplicationHEX", CharSet = CharSet.Ansi)]
        public static extern int ICC_Reader_ApplicationHEX(int ReaderHandle, byte ICC_Slot_No, int Lenth_of_Command_APDU,
            byte[] Command_APDU, byte[] Response_APDU);

        [DllImport(DllPathHuaDa, EntryPoint = "ICC_SetCpupara", CharSet = CharSet.Ansi)]
        public static extern int ICC_SetCpupara(int ReaderHandle, byte ICC_Slot_No, byte cpupro, byte cpuetu);

        #endregion

        #region 非接基本操作函数

        [DllImport(DllPathHuaDa, EntryPoint = "PICC_Reader_SetTypeA", CharSet = CharSet.Ansi)]
        public static extern int PICC_Reader_SetTypeA(int ReaderHandle);

        [DllImport(DllPathHuaDa, EntryPoint = "PICC_Reader_SetTypeB", CharSet = CharSet.Ansi)]
        public static extern int PICC_Reader_SetTypeB(int ReaderHandle);

        [DllImport(DllPathHuaDa, EntryPoint = "PICC_Reader_Select", CharSet = CharSet.Ansi)]
        public static extern int PICC_Reader_Select(int ReaderHandle, byte cardtype);

        [DllImport(DllPathHuaDa, EntryPoint = "PICC_Reader_Request", CharSet = CharSet.Ansi)]
        public static extern int PICC_Reader_Request(int ReaderHandle);

        [DllImport(DllPathHuaDa, EntryPoint = "PICC_Reader_anticoll", CharSet = CharSet.Ansi)]
        public static extern int PICC_Reader_anticoll(int ReaderHandle, byte[] uid);

        [DllImport(DllPathHuaDa, EntryPoint = "PICC_Reader_RFControl", CharSet = CharSet.Ansi)]
        public static extern int PICC_Reader_RFControl(int ReaderHandle);

        [DllImport(DllPathHuaDa, EntryPoint = "PICC_Reader_FindCard", CharSet = CharSet.Ansi)]
        public static extern int PICC_Reader_FindCard(int ReaderHandle);

        #endregion

        #region 非接CPU卡基本操作函数

        [DllImport(DllPathHuaDa, EntryPoint = "PICC_Reader_PowerOnTypeA", CharSet = CharSet.Ansi)]
        public static extern int PICC_Reader_PowerOnTypeA(int ReaderHandle, byte[] Response);

        [DllImport(DllPathHuaDa, EntryPoint = "PICC_Reader_PowerOnTypeB", CharSet = CharSet.Ansi)]
        public static extern int PICC_Reader_PowerOnTypeB(int ReaderHandle, byte[] Response);

        [DllImport(DllPathHuaDa, EntryPoint = "PICC_Reader_Application", CharSet = CharSet.Ansi)]
        public static extern int PICC_Reader_Application(int ReaderHandle, int Lenth_of_Command_APDU,
            byte[] Command_APDU, byte[] Response_APDU);

        #endregion

        #region M1卡基本操作函数



        [DllImport(DllPathHuaDa, EntryPoint = "PICC_Reader_Authentication", CharSet = CharSet.Ansi)]
        public static extern int PICC_Reader_Authentication(int ReaderHandle, byte Mode, byte SecNr);

        [DllImport(DllPathHuaDa, EntryPoint = "PICC_Reader_Authentication_Pass", CharSet = CharSet.Ansi)]
        public static extern int PICC_Reader_Authentication_Pass(int ReaderHandle, byte Mode, byte SecNr,
            byte[] PassWord);

        [DllImport(DllPathHuaDa, EntryPoint = "PICC_Reader_Read", CharSet = CharSet.Ansi)]
        public static extern int PICC_Reader_Read(int ReaderHandle, byte Addr, byte[] Data);

        [DllImport(DllPathHuaDa, EntryPoint = "PICC_Reader_ReadHEX", CharSet = CharSet.Ansi)]
        public static extern int PICC_Reader_ReadHEX(int ReaderHandle, byte Addr, byte[] DataHex);

        [DllImport(DllPathHuaDa, EntryPoint = "PICC_Reader_Write", CharSet = CharSet.Ansi)]
        public static extern int PICC_Reader_Write(int ReaderHandle, byte Addr, byte[] Data);

        [DllImport(DllPathHuaDa, EntryPoint = "PICC_Reader_WriteHEX", CharSet = CharSet.Ansi)]
        public static extern int PICC_Reader_WriteHEX(int ReaderHandle, byte Addr, byte[] DataHex);

        [DllImport(DllPathHuaDa, EntryPoint = "PICC_Reader_LoadKey", CharSet = CharSet.Ansi)]
        public static extern int PICC_Reader_LoadKey(int ReaderHandle, byte Mode, byte SecNr, byte[] Key);

        [DllImport(DllPathHuaDa, EntryPoint = "PICC_Reader_LoadKeyHEX", CharSet = CharSet.Ansi)]
        public static extern int PICC_Reader_LoadKeyHEX(int ReaderHandle, byte Mode, byte SecNr, byte[] KeyHex);

        #endregion M1卡基本操作函数

        #region 磁条卡基本操作函数

        [DllImport(DllPathHuaDa, EntryPoint = "Rcard", CharSet = CharSet.Ansi)]
        public static extern int Rcard(int ReaderHandle, byte ctime, int track, ref byte rlen, StringBuilder getdata);

        #endregion

        #region 身份证操作函数

        //private const string DllPathHuaDaID = "External\\HuaDa\\IDReader.dll";
        [DllImport(DllPathHuaDa, EntryPoint = "PICC_Reader_ReadIDMsg", CharSet = CharSet.Ansi)]
        public static extern int PICC_Reader_ReadIDMsg(int ReaderHandle, StringBuilder pBmpFile, byte[] pName,
            byte[] pSex, byte[] pNation, byte[] pBirth, StringBuilder pAddress, StringBuilder pCertNo,
            StringBuilder pDepartment, StringBuilder pEffectData, StringBuilder pExpire, StringBuilder pErrMsg);

        //public static extern int PICC_Reader_ReadIDMsg(int ReaderHandle, StringBuilder pBmpFile, StringBuilder pName, StringBuilder pSex, StringBuilder pNation, StringBuilder pBirth, StringBuilder pAddress, StringBuilder pCertNo, StringBuilder pDepartment, StringBuilder pEffectData, StringBuilder pExpire, StringBuilder pErrMsg);

        [DllImport(DllPathHuaDa, EntryPoint = "PICC_Reader_ReadIDInfo", CharSet = CharSet.Ansi)]
        public static extern int PICC_Reader_ReadIDInfo(int ReaderHandle, string pBmpFile, StringBuilder pName,
            StringBuilder pSex, StringBuilder pNation, StringBuilder pBirth, StringBuilder pAddress,
            StringBuilder pCertNo, StringBuilder pDepartment, StringBuilder pEffectData, StringBuilder pExpire,
            StringBuilder pErrMsg);

        #endregion

        #endregion
    }
}
