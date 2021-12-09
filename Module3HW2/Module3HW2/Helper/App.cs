using System;
using Module3HW2.Collections;
using Module3HW2.Models;
using Module3HW2.Services.Abstarctions;

namespace Module3HW2.Helper
{
    public class App
    {
        private readonly IConfigService _configProvider;

        public App(IConfigService configService)
        {
            _configProvider = configService;
        }

        public void SimulateWork()
        {
            var collection = new ContactCollection();
            foreach (var item in _configProvider.CultureConfig.Alphabets)
            {
                collection.AddAlphabet(item.Key, item.Value);
            }

            collection.Add(new Contact { FirstName = "John", LastName = "Doe" });
            collection.Add(new Contact { FirstName = "-", LastName = "5454" });
            collection.Add(new Contact { FirstName = "Эрика", LastName = "Тимофеевна" });
            collection.Add(new Contact { FirstName = "12122", LastName = "21221" });
            collection.Add(new Contact { FirstName = "Christopher", LastName = "Melendrez" });

            collection.SetCulture("ru-RU");
            collection.Add(new Contact { FirstName = "Anne", LastName = "Dix" });
            collection.Add(new Contact { FirstName = "123", LastName = "33212" });
            collection.Add(new Contact { FirstName = "Эльвира", LastName = "Константиновна" });
            collection.Add(new Contact { FirstName = "/", LastName = "Smith" });
            collection.Add(new Contact { FirstName = "Инесса", LastName = "Эфимовна" });

            foreach (var item in collection)
            {
                foreach (var listElement in item.Value)
                {
                    Console.WriteLine($"{item.Key,-5}{listElement.FullName}");
                }
            }
        }
    }
}