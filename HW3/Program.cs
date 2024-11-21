namespace Lab1 {
    class Program {
        /// <summary>
        /// Перечисление для обозначения достоинств игральных карт.
        /// </summary>
        enum CardSpecies
        {
            /// <summary>
            /// Карта Шестёрка (6).
            /// </summary>
            Шестёрка = 6,

            /// <summary>
            /// Карта Семёрка (7).
            /// </summary>
            Семёрка = 7,

            /// <summary>
            /// Карта Восьмёрка (8).
            /// </summary>
            Восьмёрка = 8,

            /// <summary>
            /// Карта Девятка (9).
            /// </summary>
            Девятка = 9,

            /// <summary>
            /// Карта Десятка (10).
            /// </summary>
            Десятка = 10,

            /// <summary>
            /// Карта Валет (11).
            /// </summary>
            Валет = 11,

            /// <summary>
            /// Карта Дама (12).
            /// </summary>
            Дама = 12,

            /// <summary>
            /// Карта Король (13).
            /// </summary>
            Король = 13,

            /// <summary>
            /// Карта Туз (14).
            /// </summary>
            Туз = 14
        }
        /// <summary>
        /// Перечисление для обозначения дней недели.
        /// </summary>
        enum DaysOfWeek
        {
            /// <summary>
            /// Понедельник.
            /// </summary>
            Пн = 1,

            /// <summary>
            /// Вторник.
            /// </summary>
            Вт = 2,

            /// <summary>
            /// Среда.
            /// </summary>
            Ср = 3,

            /// <summary>
            /// Четверг.
            /// </summary>
            Чт = 4,

            /// <summary>
            /// Пятница.
            /// </summary>
            Пт = 5,

            /// <summary>
            /// Суббота.
            /// </summary>
            Сб = 6,

            /// <summary>
            /// Воскресенье.
            /// </summary>
            Вс = 7
        }
        static void Task1() {
            Console.WriteLine("\nЗадание 1\n");
            Console.WriteLine("Введите числовую последовательность, если она окажется невозрастающей, то я остановлю поток ввода.");
            int[] numbers = new int[10];
            for (int i = 0; i < 10; i++)
        {
            Console.Write($"Число {i + 1}: ");
            while (!int.TryParse(Console.ReadLine(), out numbers[i]))
            {
                Console.WriteLine("Некорректный ввод. Попробуйте снова.");
            }

            if (i > 0 && numbers[i] < numbers[i - 1])
            {
                Console.WriteLine($"Последовательность нарушена на позиции {i + 1} (число {numbers[i]}).");
                break;
            }
        }
        }
        static void Task2() {
            Console.WriteLine("\nЗадание 2\n");
            try
            {
                Console.WriteLine("Введите номер карты - число от 6 до 14");
                int.TryParse(Console.ReadLine(), out int CardSH);
                if (6 >= CardSH || 14 <= CardSH)
                {
                    Console.WriteLine("Ошибка. Введите номер от 6 до 14");
                }
                else {
                Console.WriteLine($"Эта карта - {(CardSpecies)CardSH}!");}
            }
            catch (FormatException)
            {
                Console.WriteLine("Неправильный ввод.");
            }
            finally
            {
                Console.WriteLine("Конец задания.");
            }
        }
        static void Task3() {
            Console.WriteLine("\nЗадание 3\n");
            var AlcoDict = new Dictionary<string, string>() {
                {"jabroni", "Patron Tequila"} ,
                {"school counselor", "Anything with Alcohol"} ,
                {"programmer", "Hipster Craft Beer"} ,
                {"bike gang member", "Moonshine"} ,
                {"politician", "Your tax dollars"} ,
                {"rapper", "Cristal"}
            };
            Console.WriteLine("Введите значение из таблицы.");
            string AlcoAlcoAlco = Console.ReadLine()?.Trim();
            if (AlcoDict.TryGetValue(AlcoAlcoAlco.ToLower(), out string result))
            {
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Beer");
            }
        }
        static void Task4() {
            Console.WriteLine("\nЗадание 4\n");
            Console.WriteLine("Введите номер дня недели (от 1 до 7):");
            if (int.TryParse(Console.ReadLine(), out int dayNumber) && dayNumber >= 1 && dayNumber <= 7)
            {
                DaysOfWeek day = (DaysOfWeek)dayNumber;
                Console.WriteLine($"День недели: {day}");
            }
            else
            {
                Console.WriteLine("Ошибка: введите число от 1 до 7.");
            }
        }
        static void Task5() {
            Console.WriteLine("\nЗадание 5\n");
            string[] items = { "Hello Kitty", "Toy Car", "Barbie doll", "Lego Set", "Hello Kitty", "Action Figure", "Barbie doll" };
            int bagCount = 0;
            foreach (string item in items)
            {
                if (item == "Hello Kitty" || item == "Barbie doll")
                {
                    bagCount++;
                }
            }
            Console.WriteLine($"В сумке {bagCount} куклы(ол).");
        }
    }
}