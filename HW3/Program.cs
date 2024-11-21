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
            Console.WriteLine("Дана последовательность из 10 чисел. Определить, является ли эта последовательность упорядоченной по возрастанию. В случае отрицательного ответа определить порядковый номер первого числа, которое нарушает данную последовательность.");
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
            Console.WriteLine("Игральным картам условно присвоены следующие порядковые номера в зависимости от их достоинства: «валету» — 11, «даме» — 12, «королю» — 13, «тузу» — 14. Порядковые номера остальных карт соответствуют их названиям («шестерка», «девятка» и т. п.). По заданному номеру карты k (6 <=k <= 14) определить достоинство соответствующей карты.");
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
            Console.WriteLine("Напишите программу , которая принимает на входе строку и производит выходные данные в соответствии со следующей таблицей.");
            var AlcoDict = new Dictionary<string, string>() {
                {"jabroni", "Patron Tequila"} ,
                {"school counselor", "Anything with Alcohol"} ,
                {"programmer", "Hipster Craft Beer"} ,
                {"bike gang member", "Moonshine"} ,
                {"politician", "Your tax dollars"} ,
                {"rapper", "Cristal"}
            };
            Console.WriteLine("Введите значение из таблицы.");
            string AlcoAlcoAlco = Console.ReadLine() ?? string.Empty;
            if (AlcoDict.TryGetValue(AlcoAlcoAlco.ToLower().Trim(), out string result))
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
            Console.WriteLine("Составить программу , которая в зависимости от порядкового номера дня недели (1, 2, ...,7) выводит на экран его название (понедельник, вторник, ..., воскресенье).");
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
            Console.WriteLine("Создать массив строк. При помощи foreach обойти весь массив. При встрече элемента 'Hello Kitty' или 'Barbie doll' необходимо положить их в “сумку”, т.е. прибавить к результату . Вывести на экран сколько кукол в “сумке”.");
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
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Task4();
            Task5();
        }
    }
}