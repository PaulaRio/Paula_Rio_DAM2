using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.ViewModel
{
    public partial class MainViewModel : ViewModelBase
    {
        private ViewModelBase? _selectedViewModel;
        public MainViewModel(BattleViewModel battle, TeamViewModel team, HistoricoViewModel historico, ImportViewModel import)
        {
            BattleViewModel = battle;
            TeamViewModel = team;
            HistoricoViewModel = historico;
            ImportViewModel = import;
            SelectedViewModel = battle;


        }
        public ViewModelBase? SelectedViewModel
        {
            get => _selectedViewModel;
            set
            {
                SetProperty(ref _selectedViewModel, value);
            }
        }

        public BattleViewModel BattleViewModel { get; }
        public TeamViewModel TeamViewModel { get; }
        public HistoricoViewModel HistoricoViewModel { get; }
        public ImportViewModel ImportViewModel { get; }


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
