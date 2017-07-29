using System;
using System.ComponentModel.Composition;
using System.Threading;
using Common;

namespace F6Plugin
{
    [Export(typeof(IPlugin))]
    public class F6Checker : IPlugin
    {
        private int _handle;
        public string Name { get; set; } = "F6";
        public string CheckProjectNames { get; set; } = "打开com口,点亮LED灯";

        public Result SelfCheck()
        {
            foreach (var baud in PluginConfigHelper.Bauds)
            {
                foreach (var port in PluginConfigHelper.Ports)
                {
                    try
                    {
                        if (Methods.F6_Connect(port, baud, ref _handle) == 0 && Methods.F6_LedControl(_handle, 0x31) == 0 && Methods.F6_LedControl(_handle, 0x30) == 0)
                        {
                            return Result.Success($"Com端口: {port},波特率: {baud}");
                        }
                    }
                    finally
                    {
                        Methods.F6_Disconnect(_handle);
                    }

                }
            }
            return Result.Fail("");
        }
    }
}