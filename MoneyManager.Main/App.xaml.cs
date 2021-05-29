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

            InsertingData();
/*            SingleCurrentAccount currentAccount = SingleCurrentAccount.GetInstance();
            currentAccount.Account = new AccountRepository().GetByUsername("artyom");*/
            base.OnStartup(e);
        }
        protected void InsertingData()
        {

            IUnitOfWork unitOfWork = new UnitOfWork();
            List<Activity> listActivities = (List<Activity>)unitOfWork.ActivityRepository.List();
            List<ActivityType> listActivitiesTypes = (List<ActivityType>)unitOfWork.ActivityTypeRepository.List();
/*            ActivityType expense = new ActivityType();
            Activity Activity = new Activity();
            expense = activityTypeRepository.GetByTitle("Доходы");
            Activity = new Activity() { Id = Guid.NewGuid(), Title = "Перевод", ActivityTypeId = expense.Id, Image = "/Assets/credit-card-plus.png" };
            activityRepository.Create(Activity);*/
            if (listActivities.Count == 0 && listActivitiesTypes.Count == 0)
            {
                ActivityType expence = new ActivityType() { Id = Guid.NewGuid(), Title = "Расходы" };
                unitOfWork.ActivityTypeRepository.Create(expence);
                ActivityType encome = new ActivityType() { Id = Guid.NewGuid(), Title = "Доходы" };
                unitOfWork.ActivityTypeRepository.Create(encome);

                Activity activity = new Activity() { Id = Guid.NewGuid(), Title = "Инвестиции", ActivityTypeId = encome.Id, Image="/Assets/chart-line_encome.png"};
                unitOfWork.ActivityRepository.Create(activity);
                activity = new Activity() { Id = Guid.NewGuid(), Title = "Выигрыш", ActivityTypeId = encome.Id, Image = "/Assets/slot-machine.png" };
                unitOfWork.ActivityRepository.Create(activity);
                activity = new Activity() { Id = Guid.NewGuid(), Title = "Перевод", ActivityTypeId = encome.Id, Image = "/Assets/credit-card-plus.png" };
                unitOfWork.ActivityRepository.Create(activity);
                activity = new Activity() { Id = Guid.NewGuid(), Title = "Перевод", ActivityTypeId = expence.Id, Image = "/Assets/credit-card-remove.png" };
                unitOfWork.ActivityRepository.Create(activity); 
                activity = new Activity() { Id = Guid.NewGuid(), Title = "Вклад", ActivityTypeId = encome.Id, Image = "/Assets/sack-percent.png" };
                unitOfWork.ActivityRepository.Create(activity);
                activity = new Activity() { Id = Guid.NewGuid(), Title = "Зарплата", ActivityTypeId = encome.Id, Image = "/Assets/cash-multiple.png" };
                unitOfWork.ActivityRepository.Create(activity);
                activity = new Activity() { Id = Guid.NewGuid(), Title = "Подарок", ActivityTypeId = encome.Id, Image="/Assets/gift-encome.png" };
                unitOfWork.ActivityRepository.Create(activity);
                activity = new Activity() { Id = Guid.NewGuid(), Title = "Развлечение", ActivityTypeId = expence.Id, Image = "/Assets/theater.png" };
                unitOfWork.ActivityRepository.Create(activity);
                activity = new Activity() { Id = Guid.NewGuid(), Title = "Фитнес", ActivityTypeId = expence.Id, Image="/Assets/weight-lifter.png" };
                unitOfWork.ActivityRepository.Create(activity);
                activity = new Activity() { Id = Guid.NewGuid(), Title = "Одежда", ActivityTypeId = expence.Id,  Image="/Assets/tshirt.png"};
                unitOfWork.ActivityRepository.Create(activity);
                activity = new Activity() { Id = Guid.NewGuid(), Title = "Благотворительность", ActivityTypeId = expence.Id, Image = "/Assets/charity.png" };
                unitOfWork.ActivityRepository.Create(activity);
                activity = new Activity() { Id = Guid.NewGuid(), Title = "Награда", ActivityTypeId = encome.Id, Image = "/Assets/seal.png" };
                unitOfWork.ActivityRepository.Create(activity);
                activity = new Activity() { Id = Guid.NewGuid(), Title = "Подарок", ActivityTypeId = expence.Id, Image="/Assets/gift-expence.png" };
                unitOfWork.ActivityRepository.Create(activity);
                activity = new Activity() { Id = Guid.NewGuid(), Title = "Транспорт", ActivityTypeId = expence.Id, Image = "/Assets/car-multiple.png" };
                unitOfWork.ActivityRepository.Create(activity);
                activity = new Activity() { Id = Guid.NewGuid(), Title = "Еда", ActivityTypeId = expence.Id, Image = "/Assets/hamburger.png" };
                unitOfWork.ActivityRepository.Create(activity);
                activity = new Activity() { Id = Guid.NewGuid(), Title = "Инвестиции", ActivityTypeId = expence.Id, Image = "/Assets/chart-line_expence.png" };
                unitOfWork.ActivityRepository.Create(activity);
                activity = new Activity() { Id = Guid.NewGuid(), Title = "Покупка", ActivityTypeId = expence.Id, Image = "/Assets/cart-variant.png" };
                unitOfWork.ActivityRepository.Create(activity);              
                activity = new Activity() { Id = Guid.NewGuid(), Title = "Платежи", ActivityTypeId = expence.Id, Image = "/Assets/mail.png" };
                unitOfWork.ActivityRepository.Create(activity);
                activity = new Activity() { Id = new Guid("ACAEB171-50B8-457E-ABAC-00006FBE7EA9"), Title = "Другое", ActivityTypeId = expence.Id, Image = "/Assets/view-grid-plus_expence.png" };
                unitOfWork.ActivityRepository.Create(activity); 
                activity = new Activity() { Id = new Guid("C506E1EB-CF72-49AD-939E-00008C32915B"), Title = "Другое", ActivityTypeId = encome.Id, Image = "/Assets/view-grid-plus_encome.png" };
                unitOfWork.ActivityRepository.Create(activity);
               
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
