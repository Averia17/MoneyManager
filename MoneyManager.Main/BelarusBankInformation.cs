using MoneyManager.Core.Models;
using MoneyManager.Core.RepositoryIntarfaces;
using MoneyManager.Infrastructure.Repositories;
using MoneyManager.Main.States.Accounts;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace MoneyManager.Main
{
    public class BelarusBankInformation : INotifyPropertyChanged
    {
        private const string URL = "https://ibank.asb.by/";
        private IUnitOfWork unitOfWork;

        History history;

        public event PropertyChangedEventHandler PropertyChanged;

        public IWebDriver driver { get; set; }
        public Account CurrentAccount { get; set; }
        private List<History> _histories { get; set; }
        public List<History> Histories
        {
            get { return _histories; }
            set
            {
                _histories = value;
                OnPropertyChanged(nameof(Histories));
            }
        }

        public BelarusBankInformation()
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
          
            unitOfWork = new UnitOfWork();
            Histories = new List<History>();
            CurrentAccount = SingleCurrentAccount.GetInstance().Account;
            driver = new ChromeDriver(service);

        }
        public void GetBelarusBankHistories()
        {
            List<Activity> activities = unitOfWork.ActivityRepository.List().ToList();
            List<IWebElement> rows = GetHistoriesTable();

            for (int i = 0; i < rows.Count; i += 2)
            {
                var rowTd = rows[i].FindElements(By.TagName("td")).ToList();
                ActivityType activityType;
                if (rowTd[1].Text == "-")
                    activityType = unitOfWork.ActivityTypeRepository.GetByTitle("Расходы");
                else
                    activityType = unitOfWork.ActivityTypeRepository.GetByTitle("Доходы");


                history = new History();
                history.Id = Guid.NewGuid();
                history.AccountId = CurrentAccount.Id;
                history.Account = CurrentAccount;
                history.Date = DateTime.Parse(rowTd[0].Text);
                Match match = new Regex(@"(\d+.\d+)").Match(rowTd[3].Text);
                history.Amount = double.Parse(match.Value.Replace('.', ','));
                //history.Date = new DateTime();
                string description = new Regex(@"обслуживания: (.*)").Match(rows[i + 1].Text).Value;
                Activity activity = new Activity();
                switch(description)
                {
                    case var k when Regex.IsMatch(description, @".*shop.*", RegexOptions.IgnoreCase):
                        activity = activities.Where(x => x.ActivityTypeId == activityType.Id && x.Title == "Покупка").First();
                        break;
                    case var k when Regex.IsMatch(description, @".*PEREVOD.*", RegexOptions.IgnoreCase):
                        activity = activities.Where(x => x.ActivityTypeId == activityType.Id && x.Title == "Перевод").First();
                        break;
                    case var k when Regex.IsMatch(description, @".*STOLOVAYA.*", RegexOptions.IgnoreCase):
                        activity = activities.Where(x => x.ActivityTypeId == activityType.Id && x.Title == "Еда").First();
                        break;
                    case var k when Regex.IsMatch(description, @".*MTS.*", RegexOptions.IgnoreCase):
                        activity = activities.Where(x => x.ActivityTypeId == activityType.Id && x.Title == "Платежи").First();
                        break;
                    default:
                        activity = activities.Where(x => x.ActivityTypeId == activityType.Id && x.Title == "Другое").First();
                        break;
                }
                history.Description = description.Split(new char[] { ' ' }, 2)[1].Trim();
                history.ActivityId = activity.Id;
                history.Activity = activity;
                Histories.Add(history);

            }
        }

        private List<IWebElement> GetHistoriesTable()
        {
            driver.Url = URL;
            WebDriverWait wait = new WebDriverWait(driver, new System.TimeSpan(0, 3, 0));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("top_link_1")));

            IWebElement webElement = driver.FindElement(By.XPath("//*[@id='top_link_1']/a"));
            webElement.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("stmtLink")));
            driver.FindElement(By.ClassName("stmtLink")).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[4]/div/div[3]/div/div[2]/table/tbody/tr/td/div/form/table/tbody/tr[2]/td/div[2]/a")));
            driver.FindElement(By.XPath("/html/body/div[4]/div/div[3]/div/div[2]/table/tbody/tr/td/div/form/table/tbody/tr[2]/td/div[2]/a")).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[4]/div/div[3]/div/div[2]/table/tbody/tr/td/div/form/table/tbody/tr[1]/td/div/table[3]/tbody/tr")));
            List<IWebElement> rows = driver.FindElements(By.XPath("/html/body/div[4]/div/div[3]/div/div[2]/table/tbody/tr/td/div/form/table/tbody/tr[1]/td/div/table[3]/tbody/tr")).ToList();
            return rows;
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
