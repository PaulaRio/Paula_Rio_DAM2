using CommunityToolkit.Mvvm.Input;
using Examen.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ViewModel
{
    public partial class MainViewModel : ViewModelBase
    {
        private ViewModelBase? _selectedViewModel;
        public MainViewModel(VentanaViewModel ventana, Ventana2ViewModel ventana2, PrincipalViewModel principal)
        {
            VentanaViewModel = ventana;
            Ventana2ViewModel = ventana2;
            PrincipalViewModel =principal;
            SelectedViewModel = principal;


        }
        public ViewModelBase? SelectedViewModel
        {
            get => _selectedViewModel;
            set
            {
                SetProperty(ref _selectedViewModel, value);
            }
        }

        public VentanaViewModel VentanaViewModel { get; }

        public Ventana2ViewModel Ventana2ViewModel { get; }

        public PrincipalViewModel PrincipalViewModel { get; }

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
