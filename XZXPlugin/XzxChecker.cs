using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace XZXPlugin
{
    [Export(typeof(IPlugin))]
    public class XzxChecker : IPlugin
    {
        public string Name { get; set; } = "新中新";
        public string CheckProjectNames { get; set; } = "打开com口";

        public Result SelfCheck()
        {
            var port = Methods.Syn_FindUSBReader();
            if (port <= 0)
            {
                return Result.Fail("身份证读卡器连接异常");
            }
            if (Methods.Syn_OpenPort(port) < 0)
            {
                return Result.Fail("身份证读卡器连接异常");
            }
            Methods.Syn_ClosePort(port);
            return Result.Success($"Com端口: {port}");
        }
    }
}
