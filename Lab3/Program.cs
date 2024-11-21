using System.Globalization;
using System.IO.Compression;

namespace Lab1 {
    class Program {
        static void Task1() {
            bool ValidInputInfo = false;
            Console.WriteLine("Написать программу, которая читает с экрана число от 1 до 365 (номер дня в году), переводит этот число в месяц и день месяца. Например, число 40 соответствует 9 февраля (високосный год не учитывать).");
            Console.WriteLine("Введите дни, а я вычислю день года для этого дня");
            while (!ValidInputInfo){
                if (int.TryParse(Console.ReadLine(), out int DayNumber)) {
                    DateTime UserDate = new DateTime(2023, 1, 1).AddDays(DayNumber - 1);
                    CultureInfo RuText = new CultureInfo("ru-RU");
                    Console.WriteLine($"День номер {DayNumber} соответствует дате: {UserDate.ToString("dd MMMM", RuText)}.");
                    ValidInputInfo = true;
                }
                else {
                    Console.WriteLine("Ошибка. Введите число заново.");
                }
            }

        }
        static void Task2() {
            Console.WriteLine("Добавить к задаче из предыдущего упражнения проверку числа введенного пользователем. Если число меньше 1 или больше 365, программа должна вырабатывать исключение, и выдавать на экран сообщение.");
            bool ValidInputInfo = false;
            Console.WriteLine("Введите дни, а я вычислю день года для этого дня");
            while (!ValidInputInfo){
                if (int.TryParse(Console.ReadLine(), out int DayNumber) && DayNumber >= 1 && DayNumber <= 365) {
                    DateTime UserDate = new DateTime(2023, 1, 1).AddDays(DayNumber - 1);
                    CultureInfo RuText = new CultureInfo("ru-RU");
                    Console.WriteLine($"День номер {DayNumber} соответствует дате: {UserDate.ToString("dd MMMM", RuText)}.");
                    ValidInputInfo = true;
                }
                else {
                    Console.WriteLine("Ошибка. Введите число заново.");
                }
            }
        }
        static void Task3() {
            Console.WriteLine("Изменить программу из упражнений 4.1 и 4.2 так, чтобы она учитывала год (високосный или нет). Год вводится с экрана. (Год високосный, если он делится на четыре без остатка, но если он делится на 100 без остатка, это не високосный год. Однако, если он делится без остатка на 400, это високосный год.)");
            Console.WriteLine("Введите год, чтобы я высчитал, високосный он или нет:");
            int.TryParse(Console.ReadLine(), out int Year);
            bool IsLeapYear = DateTime.IsLeapYear(Year);
            bool ValidInputInfo = false;
            while (!ValidInputInfo)
            {
                Console.WriteLine("Введите номер дня в году (от 1 до 365 или 366 для високосного года):");
                if (int.TryParse(Console.ReadLine(), out int DayNumber) && DayNumber >= 1 && DayNumber <= (IsLeapYear ? 366 : 365)) {
                    DateTime UserDate = new DateTime(Year, 1, 1).AddDays(DayNumber - 1);
                    CultureInfo RuText = new CultureInfo("ru-RU");
                    Console.WriteLine($"День номер {DayNumber} соответствует дате: {UserDate.ToString("dd MMMM", RuText)}.");
                    ValidInputInfo = true;
                }
                else
                {
                    Console.WriteLine("Ошибка. Введите число заново.");
                }
                }
        }
        static void Main(string[] args) {
            Task1();
            Task2();
            Task3();
        }
    }
}