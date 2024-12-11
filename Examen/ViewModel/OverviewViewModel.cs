using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using CommunityToolkit.Mvvm.Input;
using Examen.View;

namespace Examen.ViewModel
{
    public partial class PrincipalViewModel : ViewModelBase
    {
        public PopUpCreateFileDirectoryView PopUpCreateFileDirectoryView { get; }
        
        public PrincipalViewModel(PopUpCreateFileDirectoryView popUp)
        {
            PopUpCreateFileDirectoryView = popUp;
        }
        public override Task LoadAsync()
        {
            return base.LoadAsync();
        }

        [RelayCommand]
        private async Task Add_Click(object? parameter)
        {
            PopUpCreateFileDirectoryView.ShowDialog();
            await LoadAsync();
        }
    }
}
