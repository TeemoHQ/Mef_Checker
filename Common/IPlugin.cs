using System.Collections.Generic;

namespace Common
{
    public interface IPlugin
    {
        string Name { get; set; }

        Result SelfCheck();

        string CheckProjectNames { get; set; }
    }
}