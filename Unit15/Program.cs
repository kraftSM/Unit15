using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Unit15
{
    // Модель автомобиля
    public class Car
    {
        public string Model { get; set; }
        public string Manufacturer { get; set; }
    }

    // Завод - изготовитель
    public class Manufacturer
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Список моделей
            var cars = new List<Car>()
            {
                new Car() { Model  = "SX4", Manufacturer = "Suzuki"},
                new Car() { Model  = "Grand Vitara", Manufacturer = "Suzuki"},
                new Car() { Model  = "Jimny", Manufacturer = "Suzuki"},
                new Car() { Model  = "Land Cruiser Prado", Manufacturer = "Toyota"},
                new Car() { Model  = "Camry", Manufacturer = "Toyota"},
                new Car() { Model  = "Polo", Manufacturer = "Volkswagen"},
                new Car() { Model  = "Passat", Manufacturer = "Volkswagen"},
            };

            // Список автопроизводителей
            var manufacturers = new List<Manufacturer>()
            {
                new Manufacturer() { Country = "Japan", Name = "Suzuki" },
                new Manufacturer() { Country = "Japan", Name = "Toyota" },
                new Manufacturer() { Country = "Germany", Name = "Volkswagen" },
            };
            var result = from car in cars // выберем машины
                         join m in manufacturers on car.Manufacturer equals m.Name // соединим по общему ключу (имя производителя) с производителями
                         select new //   спроецируем выборку в новую анонимную сущность
                         {
                             Name = car.Model,
                             Manufacturer = m.Name,
                             Country = m.Country
                         };

            // выведем результаты
            foreach (var item in result.OrderBy(c => c.Country).ThenBy(m=>m.Manufacturer).ThenBy(n => n.Name))
                Console.WriteLine($"{item.Name} - {item.Manufacturer} ({item.Country})");
            Console.ReadKey();
        }
    }
}
