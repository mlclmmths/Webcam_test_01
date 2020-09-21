using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Threading;

namespace Webcam_WS
{
    class Camera
    {
        private readonly AutoResetEvent wait = new AutoResetEvent(false);
        const int imgWidth = 400;
        const int imgHeight = 400;
        public string pathFolder = @"C:\Captures\";
        Bitmap bitmap = new Bitmap(imgWidth, imgHeight);

        FilterInfoCollection captureDevice;
        VideoCaptureDevice videoSource;

        public List<string> CameraName { get; set; }
        public void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            bitmap = (Bitmap)eventArgs.Frame.Clone();
        }

        public void WebcamLoad()
        {
            Console.WriteLine("WebcamLoad");
            captureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            //foreach (FilterInfo filterInfo in captureDevice)
            //    CameraName.Add(filterInfo.Name);
            videoSource = new VideoCaptureDevice();
        }

        public void StartWebcam()
        {
            
            videoSource = new VideoCaptureDevice(captureDevice[0].MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(VideoSource_NewFrame);
            videoSource.Start();
        }

        public void StopWebcam()
        {
            videoSource.SignalToStop();
        }

        public void CaptureImage()
        {
            wait.WaitOne(2000);
            Bitmap capture = (Bitmap)bitmap.Clone();
            string displayName = "WS_Demo";
            string _tempName = $"{displayName}_{DateTime.Now.ToString("yyyyMMddHHmmss")}.bmp";
            if (Directory.Exists(pathFolder))
            {
                capture.Save(pathFolder + _tempName, ImageFormat.Bmp);
            }
            else
            {
                Directory.CreateDirectory(pathFolder);
                capture.Save(pathFolder + _tempName, ImageFormat.Bmp);
            }
        }
    }
}
