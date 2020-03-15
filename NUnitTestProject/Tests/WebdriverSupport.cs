using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Text;
using TechTalk.SpecFlow;

namespace NUnitTestProject.Tests
{
    public class WebDriverSupport
    {
        private static IWebDriver _webDriver;
        private static string _mainWindowHandler;

        private static IWebDriver WebDriver
        {
            get { return _webDriver ?? StartWebDriver(); }
        }

        [SetUp]
        public static void Start()
        {
            _webDriver = StartWebDriver();
        }

        public static void Navigate(String url)
        {
            WebDriver.Navigate().GoToUrl(url);
        }

        [TearDown]
        public static void Quit()
        {
            if (_webDriver == null) return;

            _webDriver.Quit();
            _webDriver = null;
        }
     
        private static IWebDriver StartWebDriver()
        {
            Contract.Ensures(Contract.Result<IWebDriver>() != null);

            if (_webDriver != null) return _webDriver;      
            _webDriver = StartChrome();                  
            _webDriver.Manage().Window.Maximize();
            _mainWindowHandler = _webDriver.CurrentWindowHandle;
            return WebDriver;
        }

        private static ChromeDriver StartChrome()
        {
            var chromeOptions = new ChromeOptions();
            var defaultDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) 
                + @"\..\Local\Google\Chrome\User Data\Default";

            return new ChromeDriver(Directory.GetCurrentDirectory(), chromeOptions);
        }
    }
}
