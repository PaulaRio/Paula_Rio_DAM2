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
        public MainViewModel()
        {
            LoginViewModel = new LoginViewModel(this);
            RegistrationViewModel = new RegistrationViewModel(this);
            SelectedViewModel = LoginViewModel;


        }
        public ViewModelBase? SelectedViewModel
        {
            get => _selectedViewModel;
            set
            {
                SetProperty(ref _selectedViewModel, value);
            }
        }

        public LoginViewModel LoginViewModel { get; set; }
        public RegistrationViewModel RegistrationViewModel { get; set; }


        public async override Task LoadAsync()
        {
            if (SelectedViewModel is not null)
            {
                await SelectedViewModel.LoadAsync();
            }
        }
        [RelayCommand]
        private async void SelectViewModel(object? parameter)
        {
            SelectedViewModel = parameter as ViewModelBase;
            await LoadAsync();
        }



    }
}

