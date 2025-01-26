using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace BasicApp.ViewModel
{
    public partial class RegistrationViewModel : ViewModelBase
    {
        private MainViewModel _mainViewModel;

        public RegistrationViewModel()
        {
            
        }


        [RelayCommand]
        private void Login_Click()
        {
            _mainViewModel.SelectedViewModel = _mainViewModel.LoginViewModel;
        }

        public override Task LoadAsync()
        {
            _mainViewModel = App.Current.Services.GetService<MainViewModel>();
            return Task.CompletedTask;
        }
    }
}

