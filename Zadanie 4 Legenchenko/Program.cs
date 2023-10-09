using System;
using System.Collections.Generic;
using System.Linq;

namespace Zadanie_4_Legenchenko
{
    // Определение делегата для фильтрации данных
    public delegate bool FilterDelegate<T>(T item);

    public class Program
    {
        static void Main(string[] args)
        {
            // Пример списка данных для фильтрации
            List<string> data = new List<string> { "data1", "data2", "data3", "example", "test" };

            Console.WriteLine("Выберите фильтр: 1 - по ключевым словам, 2 - по длине строки, 3 - по первой букве");
            var filterChoice = Console.ReadLine();

            FilterDelegate<string> filter = null;

            switch (filterChoice)
            {
                case "1":
                    // Фильтр по ключевым словам
                    filter = new FilterDelegate<string>(item => item.Contains("ex"));
                    break;
                case "2":
                    // Фильтр по длине строки
                    filter = new FilterDelegate<string>(item => item.Length > 5);
                    break;
                case "3":
                    // Фильтр по первой букве
                    filter = new FilterDelegate<string>(item => item.StartsWith("t"));
                    break;
                default:
                    Console.WriteLine("Неверный выбор фильтра");
                    return;
            }

            var filteredData = FilterData(data, filter);

            foreach (var item in filteredData)
            {
                Console.WriteLine(item);
            }
        }

        // Метод для фильтрации данных с использованием делегата фильтра
        public static List<T> FilterData<T>(List<T> data, FilterDelegate<T> filter)
        {
            return data.Where(item => filter(item)).ToList();
        }
    }
}
