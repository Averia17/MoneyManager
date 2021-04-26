using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using MoneyManager.Core.RepositoryIntarfaces;
using MoneyManager.Core.RepositoryIntarfaces.AuthenticationRepository;
using MoneyManager.Infrastructure;
using MoneyManager.Infrastructure.Repositories;
using MoneyManager.Main.States.Accounts;
using MoneyManager.Main.States.Authenticators;
using MoneyManager.Main.ViewModels;
using System;
using System.Windows;

namespace MoneyManager.Main
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>6uu
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            IServiceProvider serviceProvider = CreateServiceProvider();
            //IAuthenticationRepository authentication = serviceProvider.GetRequiredService<IAuthenticationRepository>();

            //authentication.Login("alexbutner", "Qwer1");
            Window window = serviceProvider.GetRequiredService<MainWindow>();
            window.Show();
            base.OnStartup(e);
        }
        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<MoneyManagerContext>();
            services.AddSingleton<IHistoryRepository, HistoryRepository>();
            services.AddSingleton<IAuthenticationRepository, AuthenticationRepository>();
            services.AddSingleton<IAccountRepository, AccountRepository>();

            services.AddSingleton<IPasswordHasher, PasswordHasher>();


            services.AddSingleton<BalanceViewModel>();
            services.AddSingleton<CreateHistoryViewModel>();
            services.AddSingleton<EditHistoryViewModel>();
            services.AddSingleton<SettingsViewModel>();
            services.AddSingleton<FilterBalanceViewModel>();
            services.AddSingleton<LoginViewModel>();
            services.AddSingleton<RegisterViewModel>();
            services.AddSingleton<BaseViewModel>();


           /* services.AddSingleton<ViewModelDelegateRenavigator<LoginViewModel>>();
            services.AddSingleton<CreateViewModel<RegisterViewModel>>(services =>
            {
                return () => new RegisterViewModel(
                    services.GetRequiredService<IAuthenticator>()
                    );
            });


            services.AddSingleton<ViewModelDelegateRenavigator<RegisterViewModel>>();
            services.AddSingleton<ViewModelDelegateRenavigator<ProfileViewModel>>();
            services.AddSingleton<CreateViewModel<LoginViewModel>>(services =>
            {
                return () => new LoginViewModel(
                    services.GetRequiredService<IAuthenticator>()
                    );
            });
*/
            services.AddSingleton<IAuthenticator, Authenticator>();
            services.AddSingleton<IAccountStore, AccountStore>();

            services.AddScoped<MainViewModel>();

            services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));
            return services.BuildServiceProvider();

        }
    }
}
