using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace HuaDaPlugin
{
    [Export(typeof(IPlugin))]
    public class HuaDaChecker : IPlugin
    {
        private int _handle;
        private string _deviceName = "USB1";
        public string Name { get; set; } = "华大";
        public string CheckProjectNames { get; set; } = "打开USB口,峰鸣";

        public Result SelfCheck()
        {
            try
            {
                _handle = Methods.ICC_Reader_Open(_deviceName);
                if (_handle > 0 && Methods.ICC_PosBeep(_handle, 30) >= 0)
                {
                    return Result.Success();
                }
            }
            finally
            {
                Methods.ICC_Reader_Close(_handle);
            }
            return Result.Fail("连接失败");
        }
    }
}
