using System;
using System.Web.UI.WebControls;
using System.Windows.Controls;
using System.Windows.Media;
using BillProject.ViewModel;
using LiveCharts;
using LiveCharts.Wpf;

namespace BillProject
{
    public partial class DayDay : System.Windows.Window
    {
        public DayDay()
        {
            InitializeComponent();
            DayValue dayValue = new DayValue();

            //SeriesCollection = new SeriesCollection();

            ////adding series will update and animate the chart automatically
            //SeriesCollection.Add(new ColumnSeries
            //{
            //    Title = "사용금액",
            //    Values = new ChartValues<double> { 11, 56, 42},
            //    Fill = new SolidColorBrush(Color.FromRgb(255,245,238))
            //});

            ////also adding values updates and animates the chart automatically
            ////SeriesCollection[0].Values

            //Labels = new[] { "Max", "Min", "Avarage" };
            ////Formatter = value => value.ToString("N");

            DataContext = dayValue;
        }

        //public SeriesCollection SeriesCollection { get; set; }
        //public string[] Labels { get; set; }
        //public Func<double, string> Formatter { get; set; }

    }
}