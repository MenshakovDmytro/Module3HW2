using Module3HW2.Models;
using Module3HW2.Providers.Abstractions;
using Module3HW2.Services.Abstarctions;

namespace Module3HW2.Services
{
    public class ConfigService : IConfigService
    {
        private readonly IConfigProvider _configProvider;

        public ConfigService(IConfigProvider configProvider)
        {
            _configProvider = configProvider;
        }

        public CultureConfig CultureConfig => _configProvider.Config.CultureConfig;
    }
}