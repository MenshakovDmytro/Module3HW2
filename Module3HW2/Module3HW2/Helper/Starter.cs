using Microsoft.Extensions.DependencyInjection;
using Module3HW2.Providers;
using Module3HW2.Providers.Abstractions;
using Module3HW2.Services;
using Module3HW2.Services.Abstarctions;

namespace Module3HW2.Helper
{
    public class Starter
    {
        public void Run()
        {
            var start = new ServiceCollection()
                .AddTransient<IConfigProvider, ConfigProvider>()
                .AddSingleton<IConfigService, ConfigService>()
                .AddTransient<IFileConversionService, JsonConversionService>()
                .AddTransient<App>()
                .BuildServiceProvider();
            var application = start.GetService<App>();
            application.SimulateWork();
        }
    }
}