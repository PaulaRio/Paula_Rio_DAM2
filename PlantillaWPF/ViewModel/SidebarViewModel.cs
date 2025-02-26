using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantillaWPF.ViewModel
{
    public partial class SidebarViewModel : ViewModelBase
    {
        public ObservableCollection<MenuItemModel> MenuItems { get; set; }
        public ViewModelBase SelectedViewModel { get; set; }
        public SidebarViewModel()
        {
            MenuItems = new ObservableCollection<MenuItemModel>
        {
            new MenuItemModel { Title = "Login", ViewModel = new LoginViewModel() },
            new MenuItemModel { Title = "Register", ViewModel = new RegisterViewModel() },
            new MenuItemModel { Title = "StackPanel View", ViewModel = new StackPanelViewModel() }
        };

            SelectedViewModel = MenuItems[0].ViewModel; // Selección inicial
        }
    }
}
