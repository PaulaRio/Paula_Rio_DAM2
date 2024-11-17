using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestorArchivos.Interfaces;
using GestorArchivos.Models;
using GestorArchivos.View;

namespace GestorArchivos.ViewModel
{
   public partial class  OpenFileViewModel : ViewModelBase
    {
        public ObservableCollection<StackPanelModel> Items { get; set; }


        
        private FileOrDirectoryModel _fileOrDir;

        [ObservableProperty]
        public string _Name;

        private IDirectoryProvider _directoryService;
        private IFileProvider _fileService;
        private ICreateFILESService _createFILESService;
        public PopUpCreateFileDirectoryView PopUpCreateFileDirectoryView { get; }
        public OpenFileViewModel(IDirectoryProvider directoryService,IFileProvider fileService,ICreateFILESService createFILESService, PopUpCreateFileDirectoryView popUp
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
            _fileOrDir = new FileOrDirectoryModel();
            _fileOrDir.TypeFileorDirectory = "Carpeta";
            PopUpCreateFileDirectoryView.ShowDialog();
              await LoadAsync();
        }

        [RelayCommand]
        private async Task OpenCreateFile()
        {
            _fileOrDir = new FileOrDirectoryModel();
            _fileOrDir.TypeFileorDirectory = "Fichero";
            PopUpCreateFileDirectoryView.ShowDialog();
            await LoadAsync();

        }

        [RelayCommand]
        private void GetName()
        {
            string name = _Name;
            _fileOrDir.NameFileorDirectory =name;
        }



        [RelayCommand]
        private async Task Create()
        {   
            if (_fileOrDir.TypeFileorDirectory.Equals("Fichero"))
            {
                _fileService.CreateNewFile(_fileOrDir.NameFileorDirectory);
            }
            else
            {
                _directoryService.CreateNewDirectory(_fileOrDir.NameFileorDirectory);

            }
        }

       
        [RelayCommand]
        private void Cancel()
        {
            PopUpCreateFileDirectoryView.Close();
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
