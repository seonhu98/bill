using LiveCharts.Wpf;
using LiveCharts.Wpf.Charts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BillProject.ViewModel
{
    internal class Tobtn : System.Windows.Window, ICommand

    {
        public event EventHandler CanExecuteChanged;

        private To to;

        public Tobtn(To _to) 
        { 
            to= _to;
        }  

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            
            to.Values = new LiveCharts.ChartValues<double> { 0 };
            bindd bi = new bindd();
            double[] datas =  bi.Conn();

            foreach (double data in datas)
            {
                to.Values.Add(data);
            }
            

        }
    }
}
