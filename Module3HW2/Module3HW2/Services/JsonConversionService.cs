using System.Collections.Generic;
using System.IO;
using Module3HW2.Models;
using Module3HW2.Services.Abstarctions;
using Newtonsoft.Json;

namespace Module3HW2.Services
{
    public class JsonConversionService : IFileConversionService
    {
        public Config ConvertJsonToConfig(string jsonConfig)
        {
            var configFile = File.ReadAllText(jsonConfig);
            var config = JsonConvert.DeserializeObject<Config>(configFile);
            return config;
        }
    }
}