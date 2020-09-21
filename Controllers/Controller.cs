using System.Web.Http;
using BasicAuthentication;

namespace Webcam_WS
{
    public class WebcamController : ApiController
    {
        [BasicAuthentication]
        [HttpPost]
        [ActionName("GetWebcam")]
        public string GetWebcam()
        {
            Camera camera = new Camera();
            camera.WebcamLoad();
            camera.StartWebcam();
            camera.CaptureImage();
            camera.StopWebcam();
            return "Image Captured!";
        }
    }
}