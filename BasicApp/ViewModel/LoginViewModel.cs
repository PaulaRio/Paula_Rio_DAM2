using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BasicApp.View;
using CommunityToolkit.Mvvm.Input;

namespace BasicApp.ViewModel
{
    public partial class LoginViewModel : ViewModelBase
    {


        private readonly MainViewModel _mainViewModel;

        public LoginViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

  
        [RelayCommand]
        private void Register_Click()
        {
            _mainViewModel.SelectedViewModel = _mainViewModel.RegistrationViewModel;
        }

        public override Task LoadAsync()
        {
            
            return Task.CompletedTask;
        }
    }
}
