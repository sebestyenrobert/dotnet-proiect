using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Tests
{
    public class Test_FrontEndSite
    {
        private IWebDriver _driver;
        [SetUp]
        public void SetupDriver()
        {
            _driver = new ChromeDriver("/Users/robert/Downloads");
        }

        [TearDown]
        public void closeBrowser()
        {
            _driver.Close();
        }

        [Test]
        public void LoginAndDeleteMovie()
        {
            _driver.Url = "http://localhost:8100/";

            var emailInput = _driver.FindElement(By.XPath("/html/body/app-root/ion-app/ion-router-outlet/app-login/ion-content/div/form/ion-item[1]/ion-input/input"));
            emailInput.SendKeys("robi@asd.com");
            System.Threading.Thread.Sleep(2000);

            var password = _driver.FindElement(By.XPath("/html/body/app-root/ion-app/ion-router-outlet/app-login/ion-content/div/form/ion-item[2]/ion-input/input"));
            System.Threading.Thread.Sleep(2000);
            password.SendKeys("abc_ASB123#@");

            var loginBtn = _driver.FindElement(By.XPath("/html/body/app-root/ion-app/ion-router-outlet/app-login/ion-content/div/form/ion-button"));
            loginBtn.Click();
            System.Threading.Thread.Sleep(2000);

            var deleteMovieIcon = _driver.FindElement(By.XPath("/html/body/app-root/ion-app/ion-router-outlet/app-movies/ion-content/ion-list/ion-item[8]/ion-icon[1]"));
            deleteMovieIcon.Click();
            System.Threading.Thread.Sleep(2000);
        }

        [Test]
        public void LoginAndAddMovie()
        {
            _driver.Url = "http://localhost:8100/";

            var emailInput = _driver.FindElement(By.XPath("/html/body/app-root/ion-app/ion-router-outlet/app-login/ion-content/div/form/ion-item[1]/ion-input/input"));
            emailInput.SendKeys("robi@asd.com");
            System.Threading.Thread.Sleep(2000);

            var password = _driver.FindElement(By.XPath("/html/body/app-root/ion-app/ion-router-outlet/app-login/ion-content/div/form/ion-item[2]/ion-input/input"));
            System.Threading.Thread.Sleep(2000);
            password.SendKeys("abc_ASB123#@");

            var loginBtn = _driver.FindElement(By.XPath("/html/body/app-root/ion-app/ion-router-outlet/app-login/ion-content/div/form/ion-button"));
            loginBtn.Click();
            System.Threading.Thread.Sleep(2000);

            var deleteMovieIcon = _driver.FindElement(By.XPath("/html/body/app-root/ion-app/ion-router-outlet/app-movies/ion-content/ion-list/ion-item[8]/ion-icon[1]"));
            deleteMovieIcon.Click();
            System.Threading.Thread.Sleep(2000);
        }
    }
}
