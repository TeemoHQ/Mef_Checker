using NLog;

namespace Common
{
    public class LogHelper
    {
        public static Logger logger = LogManager.GetCurrentClassLogger();

        public static void SystemInitInfo(string msg)
        {
            logger.Info($"[系统初始化]:{msg}");
        }

        public static void Error(string msg)
        {
            logger.Error($"[系统异常]:{msg}");
        }

        public static void CheckerInfo(string msg)
        {
            logger.Error($"[硬件检测]:{msg}");
        }
    }
}