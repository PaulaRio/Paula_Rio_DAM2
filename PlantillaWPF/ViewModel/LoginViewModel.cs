using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PlantillaWPF.DTO;
using PlantillaWPF.Utils;
using PlantillaWPF.View;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using PlantillaWPF.Providers;

namespace PlantillaWPF.ViewModel
{
    public partial class LoginViewModel : ViewModelBase
    {


        private  MainViewModel _mainViewModel;
        [ObservableProperty]
        public string _Email;
        [ObservableProperty]
        public string _Password;

        IHttpsJsonClientProvider<UserDTO> _httpsJsonClientProvider;
        public LoginViewModel(IHttpsJsonClientProvider<UserDTO> httpsJsonClientProvider)
        {
            _httpsJsonClientProvider = httpsJsonClientProvider;
        }

  
        [RelayCommand]
        private void Register_Click()
        {
            _mainViewModel.SelectViewModel(_mainViewModel.RegistrationViewModel) ;
           
        }

        [RelayCommand]
        private async void Data_Click()
        {
            if (await LoginAsync())
            {
                //_mainViewModel.SelectViewModel(_mainViewModel.DataViewModel);
            }


        }

        public override Task LoadAsync()
        {
            _mainViewModel = App.Current.Services.GetService<MainViewModel>();
            return Task.CompletedTask;
        }
        private async Task<bool> LoginAsync()
        {
            try
            {

                LoginDTO user = new LoginDTO
            {
            
                Email = _Email,
                Password = _Password
               
            };
            var resultado = await _httpsJsonClientProvider.LoginPostAsync($"{Constantes.LOGIN_PATH}/login", user);
                return resultado.IsSuccess;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar los datos del registro: {ex.Message}");
                return false;
            }
        }
    }
}
