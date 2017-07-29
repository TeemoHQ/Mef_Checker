using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace HuaDa900Plugin
{
    [Export(typeof(IPlugin))]
    public class HuaDa900Checker : IPlugin
    {
        public string Name { get; set; } = "华大900";
        public string CheckProjectNames { get; set; } = "连接";

        public Result SelfCheck()
        {
            foreach (var port in PluginConfigHelper.Ports)
            {
                try
                {
                    if (Methods.HD_InitComm(port) == 0)
                    {
                        return Result.Success($"Com端口: {port}");
                    }
                }
                finally
                {
                    Methods.HD_CloseComm(port);
                }

            }
            return Result.Fail("连接失败");
        }
    }
}
