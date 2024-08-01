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
    public class GetWindows : System.Windows.Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand Tb {  get; set; }
        public ICommand Ab { get; set; }

        public ICommand Fb { get; set; }

        public ICommand Startbtn { get; set; }
        public GetWindows() 
        {
            Tb = new TotalBtn(this);
            Ab = new AccountBookBtn(this);
            Fb = new FLEX(this);
            Startbtn = new GoMain(this);
        }
    
        private void Notify([CallerMemberName] String name ="")
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
        }
    
    
    }

}
