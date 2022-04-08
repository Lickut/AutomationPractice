using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace AutomationPractice.UITests.Support
{
    public static class DriverFactory
    {
        private static readonly Dictionary<DriverType, int> Drivers = new Dictionary<DriverType, int>();
        private static readonly object s_lock = new object();

        static DriverFactory()
        {
            foreach (DriverType driverType in (DriverType[])Enum.GetValues(typeof(DriverType)))
            {
                Drivers.Add(driverType, 0);
            }
        }

        public static IWebDriver CreateWebDriver()
        {
            DriverType driverType;
            lock (s_lock)
            {
                driverType = GetDriverType();
                Drivers[driverType]++;
            };
            switch (driverType)
            {
                case DriverType.Chrome:
                    return CreateChromeDriver();
                case DriverType.Firefox:
                    return CreateFirefoxDriver();
                default:
                    throw new ArgumentException($"Invalid driverType:{driverType}");
            }
        }

        public static void CloseDriver(IWebDriver driver)
        {
            driver.Quit();
            var driverType = driver.GetType();
            lock (s_lock)
            {
                if (driverType == typeof(ChromeDriver))
                {
                    Drivers[DriverType.Chrome]--;
                }
                else if (driverType == typeof(FirefoxDriver))
                {
                    Drivers[DriverType.Firefox]--;
                }
                else
                {
                    throw new ArgumentException($"Invalid driver type:{driverType}");
                }
            }
        }

        private static FirefoxDriver CreateFirefoxDriver()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AddArgument("start-maximized");
            options.AddArgument("start-maximized");
            options.AddArguments("−−incognito");
            var driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return driver;
        }

        private static ChromeDriver CreateChromeDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");
            options.AddArgument("disable-extensions");
            options.AddArguments("−−incognito");
            var driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return driver;
        }

        private static DriverType GetDriverType()
        {
            var driverConfigurations = Settings.DriverFactoryConfiguration.DriverConfigurations.OrderBy(d => d.Priority);
            foreach (var configuration in driverConfigurations)
            {
                if (Drivers[configuration.DriverType] < configuration.Quantity)
                {
                    return configuration.DriverType;
                }
            }
            throw new Exception($"Invalid configuration, parallelism level is large than summarize max quantity:{JsonConvert.SerializeObject(driverConfigurations)}");
        }
    }
}
