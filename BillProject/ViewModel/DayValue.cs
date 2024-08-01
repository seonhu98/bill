using LiveCharts;
using LiveCharts.Wpf;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace BillProject.ViewModel
{
    public class DayValue : System.Windows.Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string[] _value;
        public string[] Labels { get { return _value; } set { _value = value; Notify(nameof(Labels)); } }

        //public Func<double, string> formatter;
        //public Func<double, string> Formatter { get { }; set; }

        public DayValue() 
        {
             bindd bi = new bindd();
            //adding series will update and animate the chart automatically
             JObject j = JObject.Parse(bi.Day());
            double max = ((double)j["MAX"]);
            double min = ((double)j["MIN"]);
            double avg = ((double)j["AVG"]);
            SeriesCollctions = new SeriesCollection();
            SeriesCollctions.Add(new ColumnSeries
            {
                Title = "사용금액",
                Values = new ChartValues<double> { },
                Fill = new SolidColorBrush(Color.FromRgb(255, 245, 238))
            });

            //also adding values updates and animates the chart automatically
            SeriesCollctions[0].Values.Add(max);
            SeriesCollctions[0].Values.Add(min);
            SeriesCollctions[0].Values.Add(avg);

            Labels = new[] { "Max", "Min", "Avarage" };
            //Formatter = value => value.ToString("N");
        }
        private void Notify([CallerMemberName] String name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private SeriesCollection _SERIES;
        public SeriesCollection SeriesCollctions { get { return _SERIES; } set { _SERIES = value; Notify(nameof(SeriesCollctions));} }
    }
}
