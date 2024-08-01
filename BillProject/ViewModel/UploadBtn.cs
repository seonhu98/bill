using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BillProject.ViewModel
{
    public class UploadBtn : ICommand
    {
        private VideoViewModel _videoViewModel;
        public event EventHandler CanExecuteChanged;

        public UploadBtn(VideoViewModel videoViewModel) 
        { 
            _videoViewModel = videoViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            try
            {
                Mat binary = new Mat();
                string save_name = DateTime.Now.ToString("yyyy-MM-dd-hh시mm분ss초");
                string file_path = @"C:\Users\lms\Desktop\BillProject\BillProject\images\" + save_name + ".jpg";
                //string file_path2 = @"C:\Users\iot\source\repos\BillProject4\BillProject\images\bill7.png";
                //Cv2.ImWrite(file_path2, src);
                //MessageBox.Show("이미지가 저장되었습니다: " + file_path, "저장 완료", MessageBoxButton.OK, MessageBoxImage.Information);
                Mat src = Cv2.ImRead(file_path);
                //Cv2.Threshold(src, binary, 150, 255, ThresholdTypes.Binary);
                //Cv2.ImShow("frame", frame);
                Cv2.ImShow("src", src);
                //Cv2.ImShow("binary", binary);


                //Mat canney = new Mat();
                //Cv2.Canny(src, canney, 150, 200);
                //Cv2.ImWrite(file_path, canney);
                //Cv2.ImShow("canney", canney);

                // 이 부분이 문제

                OpenCvSharp.Point[] squares = ractangle.Square(src);
                Mat square = ractangle.DrawSquare(src, squares);
                Mat dst = ractangle.PerspectiveTransform(src, squares);//전송할 잘린 파일
                                                                       // Cv2.DestroyAllWindows();
                                                                       //mats.Add(dst);
                String texts = ractangle.OCR(dst);//전송할 읽은 텍스트
                texts = texts.Replace(" .", ".").Replace(",", ".").Replace(". ", ".");
                MessageBox.Show($"{texts}");
                var matches = Regex.Matches(texts, @"([0-9]{1,3}\.[0-9]{1,2})")
                //var matches = Regex.Matches(texts, @"[0-9]+[0-9]{2}")
                .Cast<Match>()
                .OrderByDescending(m => m.Value);
                List<double> values = new List<double>();
                foreach (Match match in matches)
                {
                    values.Add(Convert.ToDouble(match.Value.ToString()));
                }
                values.Sort();
                var data = values.Max();
                MessageBox.Show(data.ToString());


                //string[] spr;
                //string bill = null;
                //string sum = "SUM";
                //if (texts.Contains(sum))
                //{
                //    spr = texts.Split(new string[] { sum }, StringSplitOptions.RemoveEmptyEntries);
                //    bill = spr[1];
                //    bill = Regex.Replace(bill, @"[^0-9]", "");
                //}


                //bill.Replace(" ", string.Empty);


                Go.shoot(dst, data.ToString());
                Cv2.DestroyAllWindows();
                Console.WriteLine(texts);
                Cv2.ImShow("dst", dst);
                Cv2.ImWrite(file_path, dst);
                MessageBox.Show(texts);
                Cv2.WaitKey(0);
                Cv2.DestroyAllWindows();
            }
            catch (Exception ex)
            {
                MessageBox.Show("이미지 저장 중 오류가 발생했습니다: " + ex.Message, "오류", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
