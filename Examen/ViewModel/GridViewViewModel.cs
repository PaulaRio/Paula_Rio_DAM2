using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Examen.Model;
using Examen.Utils;

namespace Examen.ViewModel
{
    public partial class Ventana2ViewModel : ViewModelBase
    {
        public Ventana2ViewModel()
        {
            
            Planetas = new ObservableCollection<GalaxyModel>();
        }
        [ObservableProperty]
        private ObservableCollection<GalaxyModel> planetas;

        public async Task CargarTabla()
        {

            List<GalaxyModel> requestData = await HttpJsonClient<GalaxyModel>.GetListMyApi(Constantes.PLANETAS_PATH) ?? new List<GalaxyModel>();
            foreach (var element in requestData)
            {
                Planetas.Add(element);
            }

        }
        public override async Task LoadAsync()
        {
            Planetas.Clear();
            await CargarTabla();
        }
    }

}
