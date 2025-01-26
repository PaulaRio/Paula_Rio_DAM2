using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;

namespace BasicApp.ViewModel
{
    public partial class MainViewModel : ViewModelBase
    {
        private ViewModelBase? _selectedViewModel;
        public LoginViewModel LoginViewModel { get; set; }
        public RegistrationViewModel RegistrationViewModel { get; set; }

        public DataViewModel DataViewModel { get; set; }
        public MainViewModel(LoginViewModel loginViewModel, RegistrationViewModel registrationViewModel, DataViewModel dataViewModel )
        {
            _selectedViewModel = loginViewModel;
            LoginViewModel = loginViewModel;
            RegistrationViewModel =registrationViewModel;
            DataViewModel = dataViewModel;

        }
         
        public ViewModelBase? SelectedViewModel
        {
            get => _selectedViewModel;
            set
            {
                SetProperty(ref _selectedViewModel, value);
            }
        }


        public async override Task LoadAsync()
        {
            if (SelectedViewModel is not null)
            {
                await SelectedViewModel.LoadAsync();
            }
        }
        [RelayCommand]
        public async void SelectViewModel(object? parameter)
        {
            SelectedViewModel = parameter as ViewModelBase;
            await LoadAsync();
        }



    }
}

