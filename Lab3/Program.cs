using System.Globalization;
using System.IO.Compression;

namespace Lab1 {
    class Program {
        static void Task1() {
            bool ValidInputInfo = false;
            while (!ValidInputInfo){
                if (int.TryParse(Console.ReadLine(), out int DayNumber)) {
                    Console.WriteLine("Введите дни");
                    DateTime UserDate = new DateTime(2024, 1, 1).AddDays(DayNumber-1);
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
            bool ValidInputInfo = false;
            while (!ValidInputInfo){
                if (int.TryParse(Console.ReadLine(), out int DayNumber) && DayNumber >= 1 && DayNumber <= 365) {
                    Console.WriteLine("Введите дни");
                    DateTime UserDate = new DateTime(2024, 1, 1).AddDays(DayNumber-1);
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
            Console.WriteLine("Введите год:");
            int.TryParse(Console.ReadLine(), out int Year);
            bool IsLeapYear = DateTime.IsLeapYear(Year);
            bool ValidInputInfo = false;
            while (!ValidInputInfo)
            {
                Console.WriteLine("Введите номер дня в году (от 1 до 365 или 366 для високосного года):");
                if (int.TryParse(Console.ReadLine(), out int DayNumber) && DayNumber >= 1 && DayNumber <= (IsLeapYear ? 366 : 365)) {
                    DateTime UserDate = new DateTime(Year, 1, 1).AddDays(DayNumber-1);
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