using Microsoft.Extensions.Configuration;
using System.Reflection;
namespace AutomationPractice.UITests.Support
{
    public static class Settings
    {
        private static IConfigurationRoot _configuration;
        static Settings()
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var appSettingsFilePath = Path.Combine(basePath, "appsettings.json");
            _configuration = new ConfigurationBuilder()
                .AddJsonFile(appSettingsFilePath, false)
                .AddEnvironmentVariables()
                .Build();
        }
        public static string HostUrl => _configuration.GetValue<string>("hostUrl");
        public static User User1 => _configuration.GetSection("user1").Get<User>();
        public static User User2 => _configuration.GetSection("user2").Get<User>();
        public static DriverFactoryConfiguration DriverFactoryConfiguration => _configuration.GetSection("DriverFactoryConfiguration").Get<DriverFactoryConfiguration>();
    }
}