using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BillProject.ViewModel
{
    public class To : System.Windows.Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ChartValues<double> _values;
        CartesianChart _chart;
        CartesianChart Chart {  get { return _chart; } set { _chart = value; Notify(nameof(Chart)); } }
        public ChartValues<double> Values { get { return _values; } set { _values = value; Notify(nameof(Values));} }

        public ICommand GetAccountValue {  get; set; } 

        public To() 
        {
            GetAccountValue = new Tobtn(this);
        }

        private void Notify([CallerMemberName] String propertyName = "")
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
