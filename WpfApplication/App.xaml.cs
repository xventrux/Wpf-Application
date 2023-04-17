using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPF.MVVM.Base;
using WPF.MVVM.Services.NavigationServices;
using WPF.MVVM.ViewModels;
using WPF.MVVM.Views;

namespace WpfApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<Func<Type, BaseViewModel>>(serviceProvider => viewModelType => (BaseViewModel)serviceProvider.GetRequiredService(viewModelType));
            services.AddSingleton<INavigationService, NavigationService>();

            services.AddSingleton<MainViewModel>();
            services.AddSingleton<HomeViewModel>();
            services.AddSingleton<AdditionalViewModel>();

            services.AddSingleton<MainWindow>(serviceProvider => new MainWindow() 
            { 
                DataContext = serviceProvider.GetRequiredService<MainViewModel>() 
            });
            services.AddSingleton<HomePage>();
            services.AddSingleton<AdditionalPage>();

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _serviceProvider.GetRequiredService<MainWindow>().Show();
            base.OnStartup(e);
        }
    }
}
