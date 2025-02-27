using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;

namespace PlantillaWPF.ViewModel
{
    public partial class SidebarViewModel : ViewModelBase
    {
        private readonly MainViewModel _mainViewModel;

        public SidebarViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        [RelayCommand]
        public async Task SelectViewModel(ViewModelBase? viewModel)
        {
            if (viewModel is not null)
            {
                _mainViewModel.SelectedViewModel = viewModel;
                await _mainViewModel.LoadAsync();
            }
        }

        public LoginViewModel LoginViewModel => _mainViewModel.LoginViewModel;
        public RegistrationViewModel RegistrationViewModel => _mainViewModel.RegistrationViewModel;

        public StackPanelViewModel StackPanelViewModel => _mainViewModel.StackPanelViewModel;
    }
}
