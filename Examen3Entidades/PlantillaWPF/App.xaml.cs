using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using PlantillaWPF.DTO;
using PlantillaWPF.Interfaces;
using PlantillaWPF.Service;
using PlantillaWPF.Services;
using PlantillaWPF.View;
using PlantillaWPF.ViewModel;

namespace PlantillaWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Services = ConfigureServices();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = Current.Services.GetService<MainWindow>();
            mainWindow?.Show();
        }
        public new static App Current => (App)Application.Current;
        public IServiceProvider Services { get; }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            //view principal
            services.AddTransient<MainWindow>();
            services.AddSingleton<AddObjetoView>();


            //view viewModels
            services.AddTransient<MainViewModel>();
            services.AddTransient<LoginViewModel>();
            services.AddTransient<RegistrationViewModel>();
            services.AddTransient<DataGridViewModel>();
            services.AddTransient<StackPanelViewModel>();
            services.AddTransient<OverviewViewModel>();
            services.AddSingleton<AddObjetoViewModel>();
            services.AddTransient<AddAutorViewModel>();
            services.AddTransient<AddGrupoViewModel>();




            //Services
            services.AddSingleton<LoginDTO>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton(typeof(IFileService<>), typeof(FileService<>));
            services.AddSingleton(typeof(IHttpsJsonClientProvider<>), typeof(HttpsJsonClientService<>));
            services.AddSingleton<IObjectProvider, ObjectService>();
            services.AddSingleton<IAutorProvider, AutorService>();
            services.AddSingleton<IGrupoProvider, GrupoService>();
            services.AddSingleton<IStringUtils, StringUtils>();
            return services.BuildServiceProvider();
        }
    }

}
