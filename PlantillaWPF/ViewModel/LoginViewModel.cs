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
using PlantillaWPF.Interfaces;

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
        private void Register()
        {
            //_mainViewModel.SelectViewModel(_mainViewModel.RegistrationViewModel);
            var mainViewModel = App.Current.Services.GetService<MainViewModel>();
            var RegistroViewModel = App.Current.Services.GetService<RegistrationViewModel>();
            mainViewModel.SelectViewModelCommand.Execute(RegistroViewModel);
            //mainViewModel.SelectViewModel(mainViewModel.LoginViewModel);

        }

        [RelayCommand]
        private async void Data_Click()
        {
            if (await LoginAsync())
            {
                _mainViewModel.SetLoginStatus(true);
                var mainViewModel = App.Current.Services.GetService<MainViewModel>();
                var OverviewViewModel = App.Current.Services.GetService<OverviewViewModel>();
                mainViewModel.SelectViewModelCommand.Execute(OverviewViewModel);
            }
            // await Login();

        }

        public override Task LoadAsync()
        {
            _mainViewModel = App.Current.Services.GetService<MainViewModel>();
            return Task.CompletedTask;
        }

        
        private async Task<bool> LoginAsync()
        {
            App.Current.Services.GetService<LoginDTO>().Email = Email;
            App.Current.Services.GetService<LoginDTO>().Password = Password;

            try
            {
                UserDTO user = await _httpsJsonClientProvider.LoginPostAsync($"{Constantes.LOGIN_PATH}/login", App.Current.Services.GetService<LoginDTO>());

                if (user != null && user.Result != null && !string.IsNullOrEmpty(user.Result.Token))
                {
                    App.Current.Services.GetService<LoginDTO>().Token = user.Result.Token;
                    return user.IsSuccess;
                }
                else
                {
                    MessageBox.Show("Error: Usuario o contraseña incorrectos.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }

        //private async Task<bool> LoginAsync()
        //{
        //    try
        //    {

        //        LoginDTO user = new LoginDTO
        //        {

        //            Email = _Email,
        //            Password = _Password

        //        };
        //        var resultado = await _httpsJsonClientProvider.LoginPostAsync($"{Constantes.LOGIN_PATH}/login", user);
        //        //var resultado = await HttpJsonClient<LoginDTO>.LoginPost($"{Constantes.LOGIN_PATH}/login", user);
        //        return resultado.IsSuccess;

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error al guardar los datos del registro: {ex.Message}");
        //        return false;
        //    }
        //}
    }
}
