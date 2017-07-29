using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HuaDa900Plugin
{
    public class Methods
    {
        #region[华大900 身份证读卡器]
        private const string DllPathHuaDa900 = "External\\HuaDa900\\HDstdapi.dll";
        public static readonly Dictionary<int, string> HuaDa900_ErrorDictionary = new Dictionary<int, string>
        {
            [0] = "执行成功",
            [-1] = "设备连接错",
            [-2] = "设备未建立连接(没有执行打开设备函数)",
            [-3] = "(动态库)加载失败",
            [-4] = "(发给动态库的)参数错",
            [-5] = "寻卡失败",
            [-6] = "选卡失败",
            [-7] = "读卡失败",
            [-8] = "读取追加信息失败",
            [-9] = "读取追加信息失败",
            [-10] = "管理通信失败",
            [-11] = "检验通信失败",
            [-12] = "管理通信模块不支持获取指纹",
            [-999] = "其他异常错误",
        };
        [DllImport(DllPathHuaDa900, EntryPoint = "HD_InitComm", CharSet = CharSet.Ansi)]
        public static extern int HD_InitComm(int port);
        [DllImport(DllPathHuaDa900, EntryPoint = "HD_CloseComm", CharSet = CharSet.Ansi)]
        public static extern int HD_CloseComm(int port);
        [DllImport(DllPathHuaDa900, EntryPoint = "HD_Authenticate", CharSet = CharSet.Ansi)]
        public static extern int HD_Authenticate();
        [DllImport(DllPathHuaDa900, EntryPoint = "HD_Read_BaseInfo", CharSet = CharSet.Ansi)]
        public static extern int HD_Read_BaseInfo(string pBmpFile, StringBuilder pBmpData, StringBuilder pName, StringBuilder pSex, StringBuilder pNation, StringBuilder pBirth, StringBuilder pAddress, StringBuilder pCertNo, StringBuilder pDepartment, StringBuilder pEffectData, StringBuilder pExpire);
        #endregion
    }
}
