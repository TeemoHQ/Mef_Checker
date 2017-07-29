using System.Collections.Generic;
using System.IO.Ports;

namespace Common
{
    public class PluginConfigHelper
    {
        public static List<int> Bauds = new List<int> { 2400, 4800, 9600, 19200, 38400 };

        public static List<int> Ports => GetLocalPort();

        private static List<int> GetLocalPort()
        {
            var res = new List<int>();
            var localPortNames = SerialPort.GetPortNames();
            foreach (var portName in localPortNames)
            {
                LogHelper.SystemInitInfo($"读取端口:{portName}:");
                res.Add(int.Parse(portName.Replace("COM", "")));
            }
            return res;
        }
    }
}
