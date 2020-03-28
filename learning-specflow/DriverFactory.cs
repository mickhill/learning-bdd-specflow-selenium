using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;

namespace learning_specflow
{
    class DriverFactory
    {
        public enum Browser
        {
            CHROME,
            CHROME_HEADLESS,
            FIREFOX,
            IE,
        }

        public static IWebDriver GetBrownser()
        {
            return GetBrownser(Browser.CHROME); // Browser Default
        }

        public static IWebDriver GetBrownser(Browser browserUser)
        {
            IWebDriver resultBrowser;

            switch (browserUser)
            {
                case Browser.CHROME:
                    resultBrowser = new ChromeDriver();
                    break;
                case Browser.CHROME_HEADLESS:
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments(
                        new List<string>()
                        {
                            "--silent-launch",
                            "--no-startup-window",
                            "no-sandbox",
                            "headless",
                        }
                    );
                    ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
                    chromeDriverService.HideCommandPromptWindow = true;
                    resultBrowser = new ChromeDriver(chromeDriverService, chromeOptions);
                    break;
                case Browser.FIREFOX:
                    resultBrowser = new FirefoxDriver();
                    break;
                case Browser.IE:
                    //Browser = new InternetExplorerDriver();
                    //break;
                default:
                    throw new NotSupportedException("Browser Nao Suportado");
            }
            return resultBrowser;
        }
    }
}
