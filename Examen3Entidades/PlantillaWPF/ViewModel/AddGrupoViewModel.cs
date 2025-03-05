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
using PlantillaWPF.Models;
using PlantillaWPF.Utils;
using System.Collections.ObjectModel;

namespace PlantillaWPF.ViewModel
{
   public partial class AddGrupoViewModel : ViewModelBase
    {
        
        [ObservableProperty]
        public string _Nombre;
        [ObservableProperty]
        public string _Precio;
       

        
        private readonly IObjectProvider _objectProvider;
        private readonly IGrupoProvider _grupoProvider;

        public AddGrupoViewModel( IObjectProvider objectProvider, IGrupoProvider grupoProvider)
        {
            _objectProvider=objectProvider;
            _grupoProvider =grupoProvider;



        }

       
        [RelayCommand]
        private void CancelarVentana(object? parameter)
        {
            Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w is AddGrupoView)?.Close();
        }

        //TODO: comprobacion campos
        [RelayCommand]
        private async Task Save()
        {
            if (await PostGrupoAsync())
            {
                MessageBox.Show("Post exitoso");
                
            }
            else
            {
                MessageBox.Show("Post fallido");
                
            }
            


        }
        public override async Task LoadAsync()
        {
            



        }


        private async Task<bool> PostGrupoAsync()
        {
            //List<int> objetosIds = string.IsNullOrEmpty(_ObjetosIds) ? new List<int>() : _ObjetosIds.Split(',').Select(int.Parse).ToList();
            //if (!await _objectProvider.ExistenObjetos(objetosIds.ToList()))
            //{
            //    MessageBox.Show("Uno o más objetos no existen. Debes crear los autores primero.");
            //    _ObjetosIds = string.Empty;
            //    return false;
            //}
            try
            {
                
                GrupoDTO nuevoGrupo = new GrupoDTO
                {
                    Name=_Nombre,
                    Precio=int.Parse(_Precio),
                    


                };
                await _grupoProvider.PostGrupo(nuevoGrupo);
                MessageBox.Show("Grupo creado exitosamente");
                return true;
               
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }
        private int[] listNum(string cad)
        {
            if (string.IsNullOrEmpty(cad))
            {
                return new int[0];
            }


            cad = cad.Replace(" ", "");
            string[] numeros;


            if (cad.Contains(","))
            {
                numeros = cad.Split(',');
            }
            else
            {

                numeros = new string[] { cad };
            }


            return numeros.Select(n => int.Parse(n)).ToArray();
        }
    }
}
