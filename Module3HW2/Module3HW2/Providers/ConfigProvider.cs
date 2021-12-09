using System.Collections.Generic;
using Module3HW2.Models;
using Module3HW2.Providers.Abstractions;
using Module3HW2.Services.Abstarctions;

namespace Module3HW2.Providers
{
    public class ConfigProvider : IConfigProvider
    {
        private const string ConfigFile = "config.json";

        private readonly Config _config;
        private readonly IFileConversionService _fileConversionService;

        public ConfigProvider(IFileConversionService fileConversionService)
        {
            _fileConversionService = fileConversionService;

            _config = LoadConfig();
        }

        public Config Config => _config;

        private Config LoadConfig()
        {
            return _fileConversionService.ConvertJsonToConfig(ConfigFile);
        }
    }
}