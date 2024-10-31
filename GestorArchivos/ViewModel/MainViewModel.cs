using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorArchivos.ViewModel
{
    public partial class MainViewModel : ViewModelBase
    {
        private ViewModelBase? _selectedViewModel;
        public MainViewModel(FileAbrirViewModel fileAbrir, InfoViewModel info,PrincipalViewModel principal)
        {
            FileAbrirViewModel = fileAbrir;
            InfoViewModel = info;
            PrincipalViewModel=principal;


        }
        public ViewModelBase? SelectedViewModel
        {
            get => _selectedViewModel;
            set
            {
                SetProperty(ref _selectedViewModel, value);
            }
        }

        public FileAbrirViewModel FileAbrirViewModel { get; }
        public InfoViewModel InfoViewModel { get; }
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
