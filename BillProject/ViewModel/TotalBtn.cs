using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BillProject.ViewModel
{
    public class TotalBtn :System.Windows.Window,ICommand
    {
        public event EventHandler CanExecuteChanged;

        private GetWindows Gw;
        
        public TotalBtn(GetWindows _gw) 
        {            
            Gw = _gw;            
        }
        

        
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
           VidioPage vp = new VidioPage();
           vp.Show();
        }
    }
}
