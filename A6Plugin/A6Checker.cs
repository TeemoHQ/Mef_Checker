using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading;
using Common;

namespace A6Plugin
{
    [Export(typeof(IPlugin))]
    public class A6Checker : IPlugin
    {
        private int _handle;
        public string Name { get; set; } = "A6";
        public string CheckProjectNames { get; set; } = "连接,初始化";

        public Result SelfCheck()
        {
            var bufferLen = 1024;
            var buffer = new byte[bufferLen];
            foreach (var baud in PluginConfigHelper.Bauds)
            {
                foreach (var port in PluginConfigHelper.Ports)
                {
                    try
                    {
                        if (Methods.A6_Connect(port, baud, ref _handle) == 0 && Methods.A6_Initialize(_handle, 0x30, buffer, ref bufferLen) == 0)
                        {
                            return Result.Success($"Com端口: {port},波特率: {baud}");
                        }
                    }
                    finally
                    {
                        Methods.A6_Disconnect(_handle);
                    }

                }
            }
            return Result.Fail("");
        }
    }
}