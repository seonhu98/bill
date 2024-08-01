using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using BillProject.ViewModel;
using LiveCharts;

namespace BillProject
{
    /// <summary>
    /// Interaction logic for SolidColorExample.xaml
    /// </summary>
    public partial class Total : System.Windows.Window
    {
        public Total()
        {
            InitializeComponent();

            //Values = new ChartValues<double> { 150, 375, 420, 500, 160, 140 };
            To to=new To();
            DataContext = to;
        }

        //public ChartValues<double> Values { get; set; }

        //private void UpdateOnclick(object sender, RoutedEventArgs e)
        //{
        //    Chart.Update(true);
        //}
    }
}