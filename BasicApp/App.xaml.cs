using System.Configuration;
using System.Data;
using System.Windows;
using BasicApp.Interfaces;
using BasicApp.Services;
using BasicApp.View;
using BasicApp.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace BasicApp
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
            services.AddSingleton<MainWindow>();
            services.AddTransient<AddView>();


            //view viewModels


            services.AddSingleton<MainViewModel>();
            services.AddSingleton<LoginViewModel>();
            services.AddSingleton<RegistrationViewModel>();
            services.AddSingleton<DataViewModel>();
            services.AddSingleton<AddViewModel>();

            //Services
            services.AddSingleton<IGhibliProvider, GhibliService>();
            //services.AddSingleton(typeof(IFileService<>), typeof(FileService<>));
            return services.BuildServiceProvider();
        }
    }


}
