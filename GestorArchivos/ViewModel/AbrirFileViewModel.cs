using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using GestorArchivos.Interfaces;
using GestorArchivos.Models;
using GestorArchivos.View;

namespace GestorArchivos.ViewModel
{
   public partial class  AbrirFileViewModel : ViewModelBase
    {
        public ObservableCollection<StackPanelModel> Items { get; set; }
        private IDirectoryProvider _directoryService;
        private IFileProvider _fileService;
        private ICreateFILESService _createFILESService;
        public PopUpCreateFileDirectoryView PopUpCreateFileDirectoryView { get; }
        public AbrirFileViewModel(IDirectoryProvider directoryService,IFileProvider fileService,ICreateFILESService createFILESService, PopUpCreateFileDirectoryView popUp
            )
        {
            Items = new ObservableCollection<StackPanelModel>();
            _directoryService = directoryService;
            _fileService = fileService;
            _createFILESService = createFILESService;
            PopUpCreateFileDirectoryView = popUp; 
        }

        public override async Task LoadAsync()
        {
            Items.Clear();
            _createFILESService.CreateDirectoryFILES();
            await GenerateNewStackPanelItems();
        }
        //Seguir con el ejemplo que tengo en MainWindow con el cambio de Views
        [RelayCommand]
        private async Task OpenCreateDirectory()
        {

            PopUpCreateFileDirectoryView.ShowDialog();
              await LoadAsync();
        }

        [RelayCommand]
        private async Task OpenCreateFile()
        {

            PopUpCreateFileDirectoryView.ShowDialog();
            await LoadAsync();
        }
        private async Task GenerateNewStackPanelItems()
        {
            foreach (var item in _directoryService.getNameDirectories())
            {
                Items.Add(new StackPanelModel
                {
                    ImageFileDirectory = "/Resources/Carpeta.jpg",
                    NameFileDirectory = item
                });
            }
            foreach (var item in _fileService.getNameFiles())
            {
                Items.Add(new StackPanelModel
                {
                    ImageFileDirectory = "/Resources/Fichero.png",
                    NameFileDirectory = item
                });
            }
                
            
        }
    }
}
