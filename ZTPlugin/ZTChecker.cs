using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace ZTPlugin
{
    [Export(typeof(IPlugin))]
    public class ZTChecker : IPlugin
    {
        public string Name { get; set; } = "证通";
        public string CheckProjectNames { get; set; } = "连接,初始化,读取版本号";

        public Result SelfCheck()
        {
            var ver = new StringBuilder();
            var sn = new StringBuilder();
            var charge = new StringBuilder();
            foreach (var baud in PluginConfigHelper.Bauds)
            {
                foreach (var port in PluginConfigHelper.Ports)
                {
                    try
                    {
                        if (Methods.ZT_EPP_OpenCom(port, baud) == 0 && Methods.ZT_EPP_PinInitialization(0) == 0 && Methods.ZT_EPP_PinReadVersion(ver, sn, charge) == 0)
                        {
                            Methods.ZT_EPP_CloseCom();
                            return Result.Success($"port:{port},baud:{baud},ver:{ver}");
                        }
                    }
                    finally
                    {
                        Methods.ZT_EPP_CloseCom();
                    }

                }
            }
            return Result.Fail("连接失败"); ;
        }
    }
}
