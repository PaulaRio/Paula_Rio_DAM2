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
    public partial class LoginViewModel : ViewModelBase
    {


        private  MainViewModel _mainViewModel;

        //public LoginViewModel(MainViewModel mainViewModel)
        public LoginViewModel()
        {
           // _mainViewModel = App.Current.Services.GetService<MainViewModel>();
        }

  
        [RelayCommand]
        private void Register_Click()
        {
            _mainViewModel.SelectViewModel(_mainViewModel.RegistrationViewModel) ;
           
        }

        [RelayCommand]
        private void Data_Click()
        {
           
            _mainViewModel.SelectViewModel(_mainViewModel.DataViewModel);
           
           
        }

        public override Task LoadAsync()
        {
            _mainViewModel = App.Current.Services.GetService<MainViewModel>();
            return Task.CompletedTask;
        }
    }
}
