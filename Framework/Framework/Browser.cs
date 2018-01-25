using System;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Framework
{
    public class Browser
    {
        private readonly IWebDriver _driver;

        private static readonly TimeSpan PageLoadDefaultTimeoutSeconds = TimeSpan.FromSeconds(15);
        private static readonly TimeSpan WaitElementTimeout = TimeSpan.FromSeconds(5);
        private static Browser _instance = null;
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        public Browser(IWebDriver driver)
        {
            this._driver = driver;
        }

        public static Browser Get()
        {
            if (_instance != null)
            {
                return _instance;
            }
            return _instance = Init();
        }

        private static Browser Init()
        {
            Log.Info("Initializing browser...");
            IWebDriver driver = new ChromeDriver("C:\\SeleniumDrivers");

            driver.Manage().Timeouts().PageLoad = PageLoadDefaultTimeoutSeconds;
            driver.Manage().Window.Maximize();
            return new Browser(driver);
        }

        public static void Kill()
        {
            if (_instance != null)
            {
                try
                {
                    _instance._driver.Quit();
                }
                catch (Exception e)
                {
                    Log.Error(e, "Cannot kill browser");
                }
                finally
                {
                    _instance = null;
                }
            }
        }

        public void GoTo(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public void Type(By locator, string text)
        {
            WaitForElementPresent(locator);
            WaitForElementEnabled(locator);
            WaitForElementVisible(locator);
            Log.Info($"Writing '{text}' to '{locator}'");
            _driver.FindElement(locator).SendKeys(text);
        }

        public void Click(By locator)
        {
            WaitForElementPresent(locator);
            WaitForElementEnabled(locator);
            WaitForElementVisible(locator);
            Log.Info($"Clicking '{locator}'");
            _driver.FindElement(locator).Click();
        }

        public string Read(By locator)
        {
            WaitForElementPresent(locator);
            WaitForElementEnabled(locator);
            WaitForElementVisible(locator);
            Log.Info($"Reading text: '{_driver.FindElement(locator).Text}'");
            return _driver.FindElement(locator).Text;
        }

        public void Submit(By locator)
        {
            IWebElement element = _driver.FindElement(locator);
            Log.Info($"Submit text '{locator}'");
            element.Submit();
        }

        public void WaitForElementPresent(By locator)
        {
            new WebDriverWait(_driver, WaitElementTimeout).Until(driver => driver.FindElements(locator).Count > 0);
        }

        public void WaitForElementVisible(By locator)
        {
            new WebDriverWait(_driver, WaitElementTimeout).Until(driver => driver.FindElement(locator).Displayed);
        }

        public void WaitForElementEnabled(By locator)
        {
            new WebDriverWait(_driver, WaitElementTimeout).Until(driver => driver.FindElement(locator).Enabled);
        }

        public bool IsElementPresent(By locator)
        {
            var isPresent = _driver.FindElements(locator).Count != 0;
            Log.Debug($"Element '{locator}' is present: {isPresent}");
            return isPresent;
        }

        public bool IsElementDisplayed(By locator)
        {
            Log.Debug($"Element '{locator}' is displayed");
            return _driver.FindElement(locator).Displayed;
        }
    }
}
