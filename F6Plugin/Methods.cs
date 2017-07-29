using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace F6Plugin
{
    public class Methods
    {

        private const string DllPathActF6 = "External\\Act_F6\\F6_30_API.dll";

        [DllImport(DllPathActF6, EntryPoint = "F6_Connect", CharSet = CharSet.Ansi)]
        public static extern int F6_Connect(int dwPort, int dwSpeed, ref int phReader);

        [DllImport(DllPathActF6, EntryPoint = "F6_Disconnect", CharSet = CharSet.Ansi)]
        public static extern int F6_Disconnect(int phReader);

        [DllImport(DllPathActF6, EntryPoint = "F6_LedControl", CharSet = CharSet.Ansi)]
        public static extern int F6_LedControl(int hReader, byte pm);

    }
}
