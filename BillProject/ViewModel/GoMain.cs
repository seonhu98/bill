using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BillProject.ViewModel
{
    internal class GoMain : System.Windows.Window, ICommand
    {
        public event EventHandler CanExecuteChanged;

        private GetWindows Gw;
        
        public GoMain(GetWindows gw)
        {
            Gw = gw;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            mainPage mainPage = new mainPage();
            mainPage.Show();
        }
    }
}
