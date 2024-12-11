using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Examen.Interfaces;
using Examen.Model;
using Examen.Utils;
using Examen.ViewModel;
using Microsoft.Win32;

namespace Examen.ViewModel
{
    public partial class ExportViewModel : ViewModelBase
    {
        private readonly IFileService<GalaxyModel> _fileService;



        public ExportViewModel(IFileService<GalaxyModel> fileService)
        {
            _fileService = fileService;
            Planetas = new ObservableCollection<GalaxyModel>();
        }

        [ObservableProperty]
        public ObservableCollection<GalaxyModel>? planetas = [];

        public override Task LoadAsync()
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = Constantes.JSON_FILTER
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                _fileService.Save(saveFileDialog.FileName, Planetas);
            }
            return Task.CompletedTask;
        }

       
    }
}
