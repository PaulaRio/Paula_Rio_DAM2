using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PlantillaWPF.View;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using CommunityToolkit.Mvvm.ComponentModel;
using PlantillaWPF.Interfaces;
using PlantillaWPF.DTOs;

namespace PlantillaWPF.ViewModel
{
   public partial class AddViewModel : ViewModelBase
    {
        [ObservableProperty]
        public string _Nombre;
        [ObservableProperty]
        public string _Descripcion;
        [ObservableProperty]
        public string _Photo;


        IObjectProvider _objectProvider;
        public AddViewModel(IObjectProvider objectProvider)
        {
            _objectProvider=objectProvider;
        }

       
        [RelayCommand]
        private void CancelarVentana(object? parameter)
        {
            Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w is AddView)?.Close();
        }

        //TODO: comprobacion campos
        [RelayCommand]
        private async Task Save()
        {
            if (await PostObjectAsync())
            {
                MessageBox.Show("Post exitoso");
                
            }
            else
            {
                MessageBox.Show("Post fallido");
                
            }
            


        }
        public override Task LoadAsync()
        {
            
            return Task.CompletedTask;
        }


        private async Task<bool> PostObjectAsync()
        {

            try
            {
                ObjectDTO nuevoObjeto = new ObjectDTO
                {
                    Name=_Nombre,
                    Description=_Descripcion,
                    Photo=_Photo,


                };
                await _objectProvider.PostObjeto(nuevoObjeto);
                return true;
               
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }
    }
}
