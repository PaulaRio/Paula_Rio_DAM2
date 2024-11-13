using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestorArchivos.Models;

namespace GestorArchivos.ViewModel
{
   public class AbrirFileViewModel : ViewModelBase
    {
        public ObservableCollection<StackPanelModel> Items { get; set; }
      

        private async Task GenerateFILESStackPanelItems()
        {
            int n = 0;//Especificar numero de ficheros

            for (int i = 0; i < n; i++)
            {
                Items.Add(new StackPanelModel
                {
                    //ImagePath = sprite.sprites.back_default ?? Constantes.MISSINGNO_IMAGE_PATH,
                    NameFileDirectory = Utils.DirectoryUtils.GenerateRandomDirectoryName()
                });
            }
        }
        private async Task GenerateNewStackPanelItems(String tipoArchivo)
        {
            int n = 0;//Especificar numero de ficheros
            if (tipoArchivo != null)
            {
               
            }
            for (int i = 0; i <n; i++)
            {
                Items.Add(new StackPanelModel
                {
                    //ImagePath = sprite.sprites.back_default ?? Constantes.MISSINGNO_IMAGE_PATH,
                    NameFileDirectory = Utils.DirectoryUtils.GenerateRandomDirectoryName()
                });
            }
        }
    }
}
