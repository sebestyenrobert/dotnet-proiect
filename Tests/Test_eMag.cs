using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Tests
{
    public class Test_eMag
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
        public void EmagGeniustextExists()
        {
            _driver.Url = "https://www.emag.ro";
            bool foundGenius = false;

            foreach (var span in _driver.FindElements(By.TagName("span")))
            {
                if (span.Text == "eMAG Genius")
                {
                    foundGenius = true;
                    break;
                }
            }
            Assert.IsTrue(foundGenius);
        }

        [Test]
        public void EmagGeniusHasLogo()
        {
            _driver.Url = "https://www.emag.ro";
            bool foundGenius = false;

            foreach (var span in _driver.FindElements(By.TagName("span")))
            {
                if (span.Text == "eMAG Genius")
                {
                    foundGenius = true;
                    span.Click();
                    try
                    {
                        _driver.FindElement(By.ClassName("g-logo"));
                        //Assert.True(true);
                    } catch
                    {
                        Assert.Fail("Emag genius logo not found");
                    }
                    
                    break;
                }
            }
            Assert.IsTrue(foundGenius); 
        }
    }
}
