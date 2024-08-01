using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.IO;

namespace BillProject.ViewModel
{
    public class VideoViewModel : System.Windows.Window ,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Mat frame;
        private DispatcherTimer timer;
        private bool is_initCam, is_initTimer;
        private ractangle rac = new ractangle();
        private BitmapSource _image;
        VideoCapture cam;
        
        public ICommand Upload { get; set; }
        
        public VideoViewModel()
        {

            Upload = new UploadBtn(this);
            is_initCam = init_camera();
            is_initTimer = init_Timer(0.01);

            // 초기화 완료면 타이머 실행
            if (is_initTimer && is_initCam) timer.Start();

        }

        public  BitmapSource Camimage { get { return _image; } set { _image = value; Notify(nameof(Camimage));} }
        
        private void Notify([CallerMemberName] String name ="" )
        {
            PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( name ));
        }



        private bool init_Timer(double interval_ms)
        {
            try
            {
                timer = new DispatcherTimer();

                timer.Interval = TimeSpan.FromMilliseconds(interval_ms);
                timer.Tick += new EventHandler(timer_tick);

                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool init_camera()
        {
            try
            {
                // 0번 카메라로 VideoCapture 생성 (카메라가 없으면 안됨)
                cam = new VideoCapture(0);
                cam.FrameHeight = 300;
                cam.FrameWidth = 500;

                // 카메라 영상을 담을 Mat 변수 생성
                frame = new Mat();

                return true;
            }
            catch
            {
                return false;
            }
        }

        private void timer_tick(object sender, EventArgs e)
        {
            // 0번 장비로 생성된 VideoCapture 객체에서 frame을 읽어옴
            cam.Read(frame);
            string save_name = DateTime.Now.ToString("yyyy-MM-dd-hh시mm분ss초");
            string file_path = @"C:\Users\lms\Desktop\BillProject\BillProject\images\" + save_name + ".jpg";
            Cv2.ImWrite(file_path, frame);
            Camimage = OpenCvSharp.WpfExtensions.BitmapSourceConverter.ToBitmapSource(frame);

            // 읽어온 Mat 데이터를 Bitmap 데이터로 변경 후 컨트롤에 그려줌

        }

    }
}
