using MoneyManager.Core.Models;
using MoneyManager.Core.RepositoryIntarfaces;
using MoneyManager.Infrastructure.Repositories;
using MoneyManager.Main.States.Accounts;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace MoneyManager.Main
{
    public class BelarusBankInformation
    {
        private const string URL = "https://ibank.asb.by/";
        private IUnitOfWork unitOfWork;
        History history;
        public Account CurrentAccount { get; set; }
        public List<History> Histories { get; set; }
        public BelarusBankInformation()
        {
            unitOfWork = new UnitOfWork();
            Histories = new List<History>();
            CurrentAccount = SingleCurrentAccount.GetInstance().Account;
        }
        public void GetBelarusBankHistories()
        {
            List<Activity> activities = unitOfWork.ActivityRepository.List().ToList();
            List<ActivityType> activityTypes = unitOfWork.ActivityTypeRepository.List().ToList();
            List<IWebElement> rows = GetHistoriesTable();
            for (int i = 0; i < rows.Count; i += 2)
            {
                var rowTd = rows[i].FindElements(By.TagName("td")).ToList();
                ActivityType activityType;
                if (rowTd[1].Text == "-")
                    activityType = unitOfWork.ActivityTypeRepository.GetByTitle("Расходы");
                else
                    activityType = unitOfWork.ActivityTypeRepository.GetByTitle("Доходы");

                Activity activity = unitOfWork.ActivityRepository.List(x => x.ActivityType.Id == activityType.Id).Where(x => x.Title == "Другое").First();

                history = new History();
                history.Id = Guid.NewGuid();
                history.AccountId = CurrentAccount.Id;
                history.Account = CurrentAccount;
                history.Date = DateTime.Parse(rowTd[0].Text);
                Match match = new Regex(@"(\d+.\d+)").Match(rowTd[3].Text);
                history.Amount = double.Parse(match.Value.Replace('.', ','));
                //history.Date = new DateTime();
                string description = new Regex(@"обслуживания: (.*)").Match(rows[i + 1].Text).Value;
                history.Description = description.Split(' ')[1];
                history.ActivityId = activity.Id;
                history.Activity = activity;
                Histories.Add(history);

            }
        }

        private List<IWebElement> GetHistoriesTable()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = URL;
            WebDriverWait wait = new WebDriverWait(driver, new System.TimeSpan(0, 2, 0));
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
    }
}
