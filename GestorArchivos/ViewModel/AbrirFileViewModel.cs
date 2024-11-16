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
            int n = 2;

            for (int i = 0; i < n; i++)
            {
                Items.Add(new StackPanelModel
                {
                    ImageFileDirectory = "/Resources/Fichero.png",
                    NameFileDirectory = Utils.FileUtils.generateRandomFileTxtName()
                });
            }
            Items.Add(new StackPanelModel
            {
                ImageFileDirectory = "/Resources/Carpeta.png",
                NameFileDirectory = Utils.DirectoryUtils.GenerateRandomDirectoryName()
            });
        }
        //Probar a crear dos métodos con relaycommand que pasen tipo de Archivo diferente y con binding a items del menu context y que ademas de crear el stack cree el archivo en concreto
        private async Task GenerateNewStackPanelItems(string tipoArchivo)
        {
            //Acuerdate porfa de crear la view para poder meter el nombre y que cree el archivo con el nombre para meterlo en el mismo metodo que el anterior
            if (tipoArchivo.Equals("Directory"))
            {
                Items.Add(new StackPanelModel
                {
                    //ImagePath = sprite.sprites.back_default ?? Constantes.MISSINGNO_IMAGE_PATH,
                    NameFileDirectory = Utils.DirectoryUtils.GenerateRandomDirectoryName()
                });
            }
            else
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
