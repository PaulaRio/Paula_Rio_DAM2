using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using BasicApp.DTO;
using BasicApp.Utils;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace BasicApp.ViewModel
{
    public partial class RegistrationViewModel : ViewModelBase
    {
        private MainViewModel _mainViewModel;
        [ObservableProperty]
        public string _Name;
        [ObservableProperty]
        public string _Email;
        [ObservableProperty]
        public string _Password;
        [ObservableProperty]
        public string _ConfirmPassword;

       
        


            [RelayCommand]
        private void Login_Click()
        {
            _mainViewModel.SelectedViewModel = _mainViewModel.LoginViewModel;
        }

        [RelayCommand]
        private async Task Register_Click()
        {
            if (!ComprobacionPassword(Password, ConfirmPassword))
            {
                Password = string.Empty;
                ConfirmPassword = string.Empty;
            }
            else { 
            await GuardarRegistroAsync();
            }
        }

        private  Boolean ComprobacionPassword(string firstPass, string secondPass)
        {
            if (!firstPass.Equals(secondPass))
            {
                MessageBox.Show("Las contraseñas no coinciden. Por favor, repítelas."); 

                return false;

            }
            return true;




        }


        public override Task LoadAsync()
        {
            _mainViewModel = App.Current.Services.GetService<MainViewModel>();
            return Task.CompletedTask;
        }
        private async Task<bool> GuardarRegistroAsync()
        {
            try
            {
                

                    RegisterDTO user = new RegisterDTO
                {
                    Name = _Name,
                    Email = _Email,
                    Password = _Password,
                    Role ="Admin"
                };
                


                var resultado = await HttpJsonClient<RegisterDTO>.Post(Constants.REGISTER_PATH, user);

                return resultado != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar los datos del registro: {ex.Message}");
                return false;
            }
        }
    }
}

