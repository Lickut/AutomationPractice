using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace AutomationPractice.UITests.Support
{
    public class Settings
    {
        private IConfigurationRoot _configuration;

        public Settings()
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var appSettingsFilePath = Path.Combine(basePath, "appsettings.json");

            _configuration = new ConfigurationBuilder()
                .AddJsonFile(appSettingsFilePath, false)
                .AddEnvironmentVariables()
                .Build();
        }

        public string HostUrl => _configuration.GetValue<string>("hostUrl");
        public User User1 => _configuration.GetSection("user1").Get<User>();
        public User User2 => _configuration.GetSection("user2").Get<User>();
    }
}
