using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ZTPlugin
{
    public class Methods
    {
        #region[证通金属键盘]

        private const string DllPathZtKeyboard = "External\\ZtEpp\\ZT_EPP_API.dll";

        [DllImport(DllPathZtKeyboard, EntryPoint = "ZT_EPP_OpenCom", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short ZT_EPP_OpenCom(int iPort, int lBaud);

        [DllImport(DllPathZtKeyboard, EntryPoint = "ZT_EPP_CloseCom", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short ZT_EPP_CloseCom();

        [DllImport(DllPathZtKeyboard, EntryPoint = "ZT_EPP_PinInitialization", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short ZT_EPP_PinInitialization(short iInitMode);

        [DllImport(DllPathZtKeyboard, EntryPoint = "ZT_EPP_PinReadVersion", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short ZT_EPP_PinReadVersion(StringBuilder cpVersion, StringBuilder cpSN,
            StringBuilder cpRechang);

        [DllImport(DllPathZtKeyboard, EntryPoint = "ZT_EPP_SetDesPara", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short ZT_EPP_SetDesPara(short iPara, short iFCode);

        [DllImport(DllPathZtKeyboard, EntryPoint = "ZT_EPP_PinLoadMasterKey", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short ZT_EPP_PinLoadMasterKey(short iKMode, short iKeyNo, string
            lpKey, StringBuilder cpExChk);

        [DllImport(DllPathZtKeyboard, EntryPoint = "ZT_EPP_PinLoadWorkKey", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short ZT_EPP_PinLoadWorkKey(short iKMode, short iMKeyNo, short
            iKeyNo, string lpKey, StringBuilder cpExChk);

        [DllImport(DllPathZtKeyboard, EntryPoint = "ZT_EPP_ActivWorkPin", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short ZT_EPP_ActivWorkPin(short iMKeyNo, short iWKeyNo);

        [DllImport(DllPathZtKeyboard, EntryPoint = "ZT_EPP_PinLoadCardNo", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short ZT_EPP_PinLoadCardNo(string lpCardNo);

        [DllImport(DllPathZtKeyboard, EntryPoint = "ZT_EPP_OpenKeyVoic", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short ZT_EPP_OpenKeyVoic(short iValue);

        [DllImport(DllPathZtKeyboard, EntryPoint = "ZT_EPP_PinStartAdd", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short ZT_EPP_PinStartAdd(short iPinLen, short iDispMode, short iPINMode, short
            iPromMode, short iTimeOut);

        [DllImport(DllPathZtKeyboard, EntryPoint = "ZT_EPP_PinReportPressed", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short ZT_EPP_PinReportPressed(StringBuilder cpKey, short iTimeOut);

        [DllImport(DllPathZtKeyboard, EntryPoint = "ZT_EPP_PinReadPin", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short ZT_EPP_PinReadPin(short iKMode, StringBuilder cpPinBlock);

        [DllImport(DllPathZtKeyboard, EntryPoint = "ZT_EPP_PinCalMAC", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short ZT_EPP_PinCalMAC(short iKMode, short iMacMode, string lpValue,
            StringBuilder cpExValue);

        [DllImport(DllPathZtKeyboard, EntryPoint = "ZT_EPP_PinAdd", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short ZT_EPP_PinAdd(short iKMode, short iMode, string lpValue, StringBuilder cpExValue);

        [DllImport(DllPathZtKeyboard, EntryPoint = "ZT_EPP_PinUnAdd", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short ZT_EPP_PinUnAdd(short iKMode, short iMode, string lpValue, StringBuilder cpExValue);

        [DllImport(DllPathZtKeyboard, EntryPoint = "ZT_EPP_SetICType", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short ZT_EPP_SetICType(short iIC, short iICType);

        [DllImport(DllPathZtKeyboard, EntryPoint = "ZT_EPP_ICOnPower", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short ZT_EPP_ICOnPower(StringBuilder chOutData);

        [DllImport(DllPathZtKeyboard, EntryPoint = "ZT_EPP_ICDownPower", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short ZT_EPP_ICDownPower();

        [DllImport(DllPathZtKeyboard, EntryPoint = "ZT_EPP_ICControl", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short ZT_EPP_ICControl(string lpValue, StringBuilder cpExValue);

        [DllImport(DllPathZtKeyboard, EntryPoint = "ZT_EPP_GetDLLVersion", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short ZT_EPP_GetDLLVersion(StringBuilder v1, StringBuilder v2);

        [DllImport(DllPathZtKeyboard, EntryPoint = "ZT_EPP_ReadICType()", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short ZT_EPP_ReadICType(short ic, StringBuilder type);

        [DllImport(DllPathZtKeyboard, EntryPoint = "ZT_EPP_PinGeneratecalMAC", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short ZT_EPP_PinGeneratecalMAC(StringBuilder v1, StringBuilder v2, StringBuilder v3);

        [DllImport(DllPathZtKeyboard, EntryPoint = "ZT_EPP_TerminalNum", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short ZT_EPP_TerminalNum(StringBuilder v1, StringBuilder v2);

        [DllImport(DllPathZtKeyboard, EntryPoint = "ZT_EPP_Des", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short ZT_EPP_Des(StringBuilder v1, StringBuilder v2, StringBuilder v3);

        [DllImport(DllPathZtKeyboard, EntryPoint = "ZT_EPP_DllSplitBcd", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short ZT_EPP_DllSplitBcd(StringBuilder v1, StringBuilder v2, short v3);

        [DllImport(DllPathZtKeyboard, EntryPoint = "ZT_EPP_Undes", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short ZT_EPP_Undes(string v1, string v2, StringBuilder v3);

        [DllImport(DllPathZtKeyboard, EntryPoint = "SZZT_DownloadKey", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short SZZT_DownloadKey(short nKeyNo, short nMKeyNo, short nKMode, string lpValue,
            StringBuilder lpExKCV);

        #endregion
    }
}
