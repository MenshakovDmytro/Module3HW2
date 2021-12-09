using Module3HW2.Models;

namespace Module3HW2.Services.Abstarctions
{
    public interface IFileConversionService
    {
        public Config ConvertJsonToConfig(string jsonConfig);
    }
}