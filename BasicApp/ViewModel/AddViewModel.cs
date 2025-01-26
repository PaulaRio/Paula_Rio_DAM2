using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BasicApp.View;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace BasicApp.ViewModel
{
   public partial class AddViewModel : ViewModelBase
    {

        public Window? CurrentWindow { get; set; }

        [RelayCommand]
        private void Back_Click()
        {
            CurrentWindow?.Close();
        }

        [RelayCommand]
        private void Save_Click()
        {

            


        }
    }
}
