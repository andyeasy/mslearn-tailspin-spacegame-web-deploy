using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using TechTalk.SpecFlow;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System.IO;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using System.Text.RegularExpressions;

namespace NUnDotNetCoreTSSProj12c
{
    public class NUnDotNetCoreTSSProjTest
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors = new StringBuilder();
        private string baseURL;

        [SetUp]
        public void SetupTest()
        {

            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //driver = new FirefoxDriver();
            baseURL = "https://tailspin-space-game-web-andyeasy2.azurewebsites.net";
            //driver.Navigate().GoToUrl(baseURL + "/");
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void NUnDotNetCoreTSSTestTest()
        {

            //Navigate to PHPTravels Homepage and verify 'Flight' menu/Icon is present 
            driver.Navigate().GoToUrl(baseURL + "/");
            Thread.Sleep(5000);
            Assert.AreEqual("https://tailspin-space-game-web-andyeasy2.azurewebsites.net/", driver.Url);
            Assert.AreEqual("Download game", driver.FindElement(By.LinkText("Download game")).Text);

        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}