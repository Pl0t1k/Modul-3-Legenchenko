using System;

namespace Zadanie_1_Legenchenko
{
    // Базовый класс "Фигура"
    public abstract class Фигура
    {
        // Метод для вычисления площади
        public abstract double ВычислитьПлощадь();
    }

    // Производный класс "Круг"
    public class Круг : Фигура
    {
        private double радиус;

        public Круг(double радиус)
        {
            this.радиус = радиус;
        }

        public override double ВычислитьПлощадь()
        {
            return Math.PI * Math.Pow(радиус, 2);
        }
    }

    // Производный класс "Прямоугольник"
    public class Прямоугольник : Фигура
    {
        private double ширина;
        private double высота;

        public Прямоугольник(double ширина, double высота)
        {
            this.ширина = ширина;
            this.высота = высота;
        }

        public override double ВычислитьПлощадь()
        {
            return ширина * высота;
        }
    }

    // Производный класс "Треугольник"
    public class Треугольник : Фигура
    {
        private double основание;
        private double высота;

        public Треугольник(double основание, double высота)
        {
            this.основание = основание;
            this.высота = высота;
        }

        public override double ВычислитьПлощадь()
        {
            return 0.5 * основание * высота;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите фигуру: 1 - Круг, 2 - Прямоугольник, 3 - Треугольник");
            int выбор;
            while (!int.TryParse(Console.ReadLine(), out выбор) || выбор < 1 || выбор > 3)
            {
                Console.WriteLine("Неверный ввод. Пожалуйста, введите число от 1 до 3.");
            }

            Фигура выбраннаяФигура;

            switch (выбор)
            {
                case 1:
                    Console.WriteLine("Введите радиус круга:");
                    double радиус;
                    while (!double.TryParse(Console.ReadLine(), out радиус) || радиус <= 0)
                    {
                        Console.WriteLine("Неверный ввод. Пожалуйста, введите положительное число.");
                    }
                    выбраннаяФигура = new Круг(радиус);
                    break;
                case 2:
                    Console.WriteLine("Введите ширину прямоугольника:");
                    double ширина;
                    while (!double.TryParse(Console.ReadLine(), out ширина) || ширина <= 0)
                    {
                        Console.WriteLine("Неверный ввод. Пожалуйста, введите положительное число.");
                    }
                    Console.WriteLine("Введите высоту прямоугольника:");
                    double высота;
                    while (!double.TryParse(Console.ReadLine(), out высота) || высота <= 0)
                    {
                        Console.WriteLine("Неверный ввод. Пожалуйста, введите положительное число.");
                    }
                    выбраннаяФигура = new Прямоугольник(ширина, высота);
                    break;
                case 3:
                    Console.WriteLine("Введите основание треугольника:");
                    double основание;
                    while (!double.TryParse(Console.ReadLine(), out основание) || основание <= 0)
                    {
                        Console.WriteLine("Неверный ввод. Пожалуйста, введите положительное число.");
                    }
                    Console.WriteLine("Введите высоту треугольника:");
                    double треугВысота;
                    while (!double.TryParse(Console.ReadLine(), out треугВысота) || треугВысота <= 0)
                    {
                        Console.WriteLine("Неверный ввод. Пожалуйста, введите положительное число.");
                    }
                    выбраннаяФигура = new Треугольник(основание, треугВысота);
                    break;
                default:
                    throw new Exception("Неверный выбор");
            }

            Console.WriteLine($"Площадь выбранной фигуры: {выбраннаяФигура.ВычислитьПлощадь()}");
        }
    }
}
