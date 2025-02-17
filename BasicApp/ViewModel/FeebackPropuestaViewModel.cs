using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using System.Windows;

namespace BasicApp.ViewModel
{
    public partial class FeebackPropuestaViewModel : ViewModelBase
    {
        public Window? CurrentWindow { get; set; }

        [RelayCommand]
        private void Back_Click()
        {
            CurrentWindow?.Close();
        }

        [RelayCommand]
        private void Send_Click()
        {




        }
    }
}
