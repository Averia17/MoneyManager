using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using MoneyManager.Core.Models;
using MoneyManager.Core.RepositoryIntarfaces;
using MoneyManager.Core.RepositoryIntarfaces.AuthenticationRepository;
using MoneyManager.Infrastructure;
using MoneyManager.Infrastructure.Repositories;
using MoneyManager.Main.States.Accounts;
using MoneyManager.Main.States.Authenticators;
using MoneyManager.Main.ViewModels;
using System;
using System.Collections.Generic;
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
            //IServiceProvider serviceProvider = CreateServiceProvider();
            //Window window = serviceProvider.GetRequiredService<MainWindow>();
            //window.Show();
            InsertingData();
/*            SingleCurrentAccount currentAccount = SingleCurrentAccount.GetInstance();
            currentAccount.Account = new AccountRepository().GetByEmail("feterfox@gmail.com");*/
            base.OnStartup(e);
        }
        protected void InsertingData()
        {
            ActivityTypeRepository activityTypeRepository = new ActivityTypeRepository();
            ActivityRepository activityRepository = new ActivityRepository();
            List<Activity> listActivities = (List<Activity>)activityRepository.List();
            List<ActivityType> listActivitiesTypes = (List<ActivityType>)activityTypeRepository.List();
            if (listActivities.Count == 0 && listActivitiesTypes.Count == 0)
            {
                ActivityType expence = new ActivityType() { Id = Guid.NewGuid(), Title = "Расходы" };
                activityTypeRepository.Create(expence);
                ActivityType encome = new ActivityType() { Id = Guid.NewGuid(), Title = "Доходы" };
                activityTypeRepository.Create(encome);

                Activity activity = new Activity() { Id = Guid.NewGuid(), Title = "Инвестиции", ActivityTypeId = encome.Id };
                activityRepository.Create(activity);
                activity = new Activity() { Id = Guid.NewGuid(), Title = "Выигрыш", ActivityTypeId = encome.Id };
                activityRepository.Create(activity);
                activity = new Activity() { Id = Guid.NewGuid(), Title = "Зарплата", ActivityTypeId = encome.Id };
                activityRepository.Create(activity);
                activity = new Activity() { Id = Guid.NewGuid(), Title = "Подарок", ActivityTypeId = encome.Id };
                activityRepository.Create(activity);
                activity = new Activity() { Id = Guid.NewGuid(), Title = "Развлечение", ActivityTypeId = expence.Id };
                activityRepository.Create(activity);
                activity = new Activity() { Id = Guid.NewGuid(), Title = "Подарок", ActivityTypeId = expence.Id };
                activityRepository.Create(activity);
                activity = new Activity() { Id = Guid.NewGuid(), Title = "Транспорт", ActivityTypeId = expence.Id };
                activityRepository.Create(activity);
                activity = new Activity() { Id = Guid.NewGuid(), Title = "Еда", ActivityTypeId = expence.Id };
                activityRepository.Create(activity);
                activity = new Activity() { Id = Guid.NewGuid(), Title = "Инвестиции", ActivityTypeId = expence.Id };
                activityRepository.Create(activity);
                activity = new Activity() { Id = Guid.NewGuid(), Title = "Покупка", ActivityTypeId = expence.Id };
                activityRepository.Create(activity);
                activity = new Activity() { Id = Guid.NewGuid(), Title = "Другое", ActivityTypeId = expence.Id };
                activityRepository.Create(activity); 
                activity = new Activity() { Id = Guid.NewGuid(), Title = "Другое", ActivityTypeId = encome.Id };
                activityRepository.Create(activity);
               
            }
        }
 /*       private IServiceProvider CreateServiceProvider()
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


            services.AddSingleton<ViewModelDelegateRenavigator<LoginViewModel>>();
            services.AddSingleton<CreateViewModel<RegisterViewModel>>(services =>
            {
                return () => new RegisterViewModel(
                    services.GetRequiredService<IAuthenticator>()
                    );
            });

            

                    services.AddSingleton<IAuthenticator, Authenticator>();
            services.AddSingleton<IAccountStore, AccountStore>();

            return services.BuildServiceProvider();

        }*/
    }
}
