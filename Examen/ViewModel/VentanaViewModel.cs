using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using CommunityToolkit.Mvvm.Input;
using Examen.Interfaces;
using Examen.Models;
using Examen.View;

namespace Examen.ViewModel
{
    public partial class VentanaViewModel : ViewModelBase
    {
        public ObservableCollection<StackPanelFilesModel> Items { get; set; }
        private FileOrDirectoryModel _fileOrDir;
        private IDirectoryProvider _directoryService;
        private ICreateFileProvider _fileService;
        public PopUpCreateFileDirectoryView PopUpCreateFileDirectoryView { get; }
        public VentanaViewModel(IDirectoryProvider directoryService, ICreateFileProvider fileService, PopUpCreateFileDirectoryView popUp)
        {
            Items = new ObservableCollection<StackPanelFilesModel>();
            PopUpCreateFileDirectoryView = popUp;
            _directoryService = directoryService;
            _fileService = fileService;
        }
        


        [RelayCommand]
        private async Task OpenCreateDirectory()
        {
            _fileOrDir = new FileOrDirectoryModel();
            _fileOrDir.TypeFileorDirectory = "Carpeta";
            PopUpCreateFileDirectoryView.ShowDialog();
            await LoadAsync();
        }
        public override async Task LoadAsync()
        {
            Items.Clear();
            Utils.DirectoryFileUtils.CreateDirectoryFILES();

            await GenerateNewStackPanelItems();
        }

        [RelayCommand]
        private async Task OpenCreateFile()
        {
            _fileOrDir = new FileOrDirectoryModel();
            _fileOrDir.TypeFileorDirectory = "Fichero";
            PopUpCreateFileDirectoryView.ShowDialog();
            await LoadAsync();

        }
        private async Task GenerateNewStackPanelItems()
        {
            foreach (var item in _directoryService.getNameDirectories())
            {
                Items.Add(new StackPanelFilesModel
                {
                    ImageFileDirectory = "/Resources/Carpeta.jpg",
                    NameFileDirectory = item
                });
            }
            foreach (var item in _fileService.getNameFiles())
            {
                Items.Add(new StackPanelFilesModel
                {
                    ImageFileDirectory = "/Resources/Fichero.png",
                    NameFileDirectory = item
                });
            }
        }
    }
}    
