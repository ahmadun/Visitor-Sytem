using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ZXing;
using System.Windows;

namespace Visitor_Sytem.ViewModel
{
    class RegistrationVm
    {
        FilterInfoCollection filterInfo;
        VideoCaptureDevice videoCapture;
        public RegistrationVm()
        {
            filterInfo = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in filterInfo)
            {

            }

        }

        private void Starting()
        {
            videoCapture = new VideoCaptureDevice("ss");
            videoCapture.NewFrame += VideoCapture_NewFrame;
            videoCapture.Start();
        }

        private void VideoCapture_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            BarcodeReader reader = new BarcodeReader();
            var rslt = reader.Decode(bitmap);
            if (rslt != null)
            {
                MessageBox.Show(rslt.ToString());
            }
        }

        private void Closing()
        {
            if(videoCapture != null)
            {
                if (videoCapture.IsRunning)
                    videoCapture.Stop();
            }
        }
    }
}
