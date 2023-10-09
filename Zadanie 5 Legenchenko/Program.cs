using System;

namespace Zadanie_5_Legenchenko
{
    internal class Program
    {
        // Делегат для метода сортировки
        delegate void SortDelegate(int[] numbers);

        static void Main(string[] args)
        {
            // Создаем массив чисел для сортировки
            int[] numbers = new int[] { 5, 8, 1, 3, 7, 9, 2 };

            Console.WriteLine("Выберите метод сортировки: 1 - Сортировка пузырьком, 2 - Быстрая сортировка");
            string choice = Console.ReadLine();

            // Создаем экземпляр делегата
            SortDelegate sortMethod;

            if (choice == "1")
            {
                sortMethod = BubbleSort; // Сортировка пузырьком
            }
            else
            {
                sortMethod = QuickSortWrapper; // Быстрая сортировка
            }

            // Вызываем метод сортировки через делегат
            sortMethod(numbers);

            // Выводим отсортированный массив
            foreach (int num in numbers)
            {
                Console.Write(num + " ");
            }
        }

        // Метод для сортировки пузырьком
        static void BubbleSort(int[] numbers)
        {
            int temp;
            for (int j = 0; j <= numbers.Length - 2; j++)
            {
                for (int i = 0; i <= numbers.Length - 2; i++)
                {
                    if (numbers[i] > numbers[i + 1])
                    {
                        temp = numbers[i + 1];
                        numbers[i + 1] = numbers[i];
                        numbers[i] = temp;
                    }
                }
            }
        }

        // Вспомогательный метод для быстрой сортировки
        static void QuickSortWrapper(int[] numbers)
        {
            QuickSort(numbers, 0, numbers.Length - 1);
        }

        // Метод для быстрой сортировки
        static void QuickSort(int[] numbers, int left, int right)
        {
            int i = left, j = right;
            int pivot = numbers[(left + right) / 2];

            while (i <= j)
            {
                while (numbers[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (numbers[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Перестановка элементов
                    int tmp = numbers[i];
                    numbers[i] = numbers[j];
                    numbers[j] = tmp;

                    i++;
                    j--;
                }
            }

            // Рекурсивные вызовы, если остались нерассмотренные элементы
            if (left < j)
            {
                QuickSort(numbers, left, j);
            }

            if (i < right)
            {
                QuickSort(numbers, i, right);
            }
        }
    }
}
