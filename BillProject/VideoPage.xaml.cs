using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


// OpenCV 사용을 위한 using
using OpenCvSharp;
using OpenCvSharp.WpfExtensions;
using Tesseract;

// Timer 사용을 위한 using
using System.Windows.Threading;
using BillProject.ViewModel;

namespace BillProject
{
    // OpenCvSharp 설치 시 Window를 명시적으로 사용해 주어야 함 (window -> System.Windows.Window)
    
    public partial class VidioPage : System.Windows.Window
    {
        public VidioPage()
        {
            InitializeComponent();
            
            VideoViewModel videoViewModel = new VideoViewModel();
            
            DataContext = videoViewModel;
        }

     
    }
}