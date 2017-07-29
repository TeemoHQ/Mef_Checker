using AForge.Video.DirectShow;
using Common;
using System.ComponentModel.Composition;

namespace CameraPlugin
{
    [Export(typeof(IPlugin))]
    public class CameraChecker : IPlugin
    {
        public string Name { get; set; } = "Camera";
        public Result SelfCheck()
        {
            var videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            return videoDevices.Count == 0 ? Result.Fail("未检测到有摄像头设备") : Result.Success();
        }

        public string CheckProjectNames { get; set; } = "是否含有摄像头设备";
    }
}
