using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicApp.View;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace BasicApp.ViewModel
{
    public partial class ValorarPropuestaViewModel : ViewModelBase
    {

        [RelayCommand]
        private void Rechazar_Click()
        {
            var popUpWindow = App.Current.Services.GetService<AddView>();

            popUpWindow?.Show();


        }
    }
}
