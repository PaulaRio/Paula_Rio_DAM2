using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Examen.Interfaces;
using Examen.Model;
using Examen.Utils;
using Examen.ViewModel;
using Microsoft.Win32;

namespace Examen.ViewModel
{
    public partial class ImportViewModel : ViewModelBase
    {
        private readonly IFileService<GalaxyModel> _fileService;



        public ImportViewModel(IFileService<GalaxyModel> fileService)
        {
            _fileService = fileService;
            Planetas = new ObservableCollection<GalaxyModel>();
        }

        [ObservableProperty]
        public ObservableCollection<GalaxyModel>? planetas = [];

        public override  Task LoadAsync()
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = Constantes.JSON_FILTER
            };

            if (openFileDialog.ShowDialog() == true)
            {

                var loadedPlanetas = _fileService.Load(openFileDialog.FileName);
                Planetas.Clear();
                Planetas = new ObservableCollection<GalaxyModel>(loadedPlanetas);
            }
            return Task.CompletedTask;

        }

        
    }
}   
