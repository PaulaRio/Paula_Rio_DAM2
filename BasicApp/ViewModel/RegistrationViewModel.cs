using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;

namespace BasicApp.ViewModel
{
    public partial class RegistrationViewModel : ViewModelBase
    {
        private readonly MainViewModel _mainViewModel;

        public RegistrationViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }


        [RelayCommand]
        private void Login_Click()
        {
            _mainViewModel.SelectedViewModel = _mainViewModel.LoginViewModel;
        }

        public override Task LoadAsync()
        {

            return Task.CompletedTask;
        }
    }
}

