using Microsoft.Extensions.Configuration;

namespace TechChallenge4.Tests.Integration
{
    public class BaseIntegrationTest
    {
        public IConfigurationRoot Configuration { get; }
        public static string ConnectionString { get; private set; } = string.Empty;
        public BaseIntegrationTest()
        {
            var configBuilder = new ConfigurationBuilder()
                                              .SetBasePath(Directory.GetCurrentDirectory())
                                              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = configBuilder.Build();
            ConnectionString = Configuration.GetConnectionString("DefaultConnection");
        }
    }
}
