using System;
using System.Collections.Generic;
using System.IO;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Task1(args);
            Task2();
            Task3();
        }

        /// <summary>
        /// Считает количество гласных и согласных букв в массиве символов.
        /// </summary>
        /// <param name="chars">Массив символов для анализа.</param>
        /// <returns>Кортеж, содержащий количество гласных и согласных.</returns>
        static (int, int) CountVowelsAndConsonants(char[] chars)
        {
            string vowels = "aeiouyаеёиоуыэюя";
            string consonants = "bcdfghjklmnpqrstvwxyzбвгджзйклмнпрстфхцчшщ";

            int vowelsCount = 0;
            int consonantsCount = 0;

            foreach (char c in chars)
            {
                char lowerChar = char.ToLower(c);

                if (vowels.Contains(lowerChar))
                {
                    vowelsCount++;
                }
                else if (consonants.Contains(lowerChar))
                {
                    consonantsCount++;
                }
            }

            return (vowelsCount, consonantsCount);
        }


        static void Task1(string[] args1)
        {
            Console.WriteLine("\nУпражнение 6.1(задание)\n");
            Console.WriteLine("Написать программу, которая вычисляет число гласных и согласных букв в файле. Имя файла передавать как аргумент в функцию Main. Содержимое текстового файла заносится в массив символов. Количество гласных и согласных букв определяется проходом по массиву. Предусмотреть метод, входным параметром которого является массив символов. Метод вычисляет количество гласных и согласных букв.");
            string filePath = args1[0];
            try
            {
                Console.WriteLine($"Чтение файла по пути: {filePath}");

                string content = File.ReadAllText(filePath);
                char[] chars = content.ToCharArray();
                (int vowelsCount, int consonantsCount) = CountVowelsAndConsonants(chars);

                Console.WriteLine($"Количество гласных: {vowelsCount}");
                Console.WriteLine($"Количество согласных: {consonantsCount}");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Ошибка: файл '{filePath}' не найден.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }

        static void Task2()
        {
            Console.WriteLine("\nУпражнение 6.2(задание)\n");
            Console.WriteLine("Написать программу, реализующую умножению двух матриц, заданных в виде двумерного массива. В программе предусмотреть два метода: метод печати матрицы, метод умножения матриц (на вход две матрицы, возвращаемое значение – матрица).");
            Console.WriteLine("Инициализируем первую матрицу:");
            var matrix1 = CreateTwoDimLinkedList(3, 3);
            Console.WriteLine("Инициализируем вторую матрицу:");
            var matrix2 = CreateTwoDimLinkedList(3, 3);

            Console.WriteLine("Первая матрица:");
            PrintMatrix(matrix1);

            Console.WriteLine("Вторая матрица:");
            PrintMatrix(matrix2);

            var resultMatrix = MatrixMultiply(matrix1, matrix2);

            Console.WriteLine("Результат перемножения матриц:");
            PrintMatrix(resultMatrix);
        }

        /// <summary>
        /// Создает двумерный связный список (матрицу) с заданным количеством строк и столбцов.
        /// Запрашивает значения у пользователя.
        /// </summary>
        /// <param name="rows">Количество строк.</param>
        /// <param name="cols">Количество столбцов.</param>
        /// <returns>Связный список, представляющий двумерную матрицу.</returns>
        static LinkedList<LinkedList<int>> CreateTwoDimLinkedList(int rows, int cols)
        {
            var matrix = new LinkedList<LinkedList<int>>();
            for (int i = 1; i <= rows; i++)
            {
                var row = new LinkedList<int>();
                for (int j = 1; j <= cols; j++)
                {
                    Console.WriteLine($"Введите элемент {i}-й строки {j}-го столбца:");
                    row.AddLast(EnterNumber());
                }
                matrix.AddLast(row);
            }

            return matrix;
        }

        /// <summary>
        /// Проверяет ввод пользователя, пока не будет введено корректное целое число.
        /// </summary>
        /// <returns>Целое число, введенное пользователем.</returns>
        static int EnterNumber()

        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int number))
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("Неверный ввод. Введите целое число.");
                }
            }
        }

        /// <summary>
        /// Умножает две матрицы, заданные в виде двумерных связных списков.
        /// </summary>
        /// <param name="matrix1">Первая матрица.</param>
        /// <param name="matrix2">Вторая матрица.</param>
        /// <returns>Результат умножения матриц в виде связного списка.</returns>
        /// <exception cref="InvalidOperationException">
        /// Если количество столбцов первой матрицы не равно количеству строк второй.
        /// </exception>
        static LinkedList<LinkedList<int>> MatrixMultiply(LinkedList<LinkedList<int>> matrix1, LinkedList<LinkedList<int>> matrix2)

        {
            int rows1 = matrix1.Count;
            int cols1 = GetRowLength(matrix1.First);
            int rows2 = matrix2.Count;
            int cols2 = GetRowLength(matrix2.First);    
            if (cols1 != rows2)
            {
                throw new InvalidOperationException("Количество столбцов первой матрицы должно совпадать с количеством строк второй матрицы.");
            }

            var resultMatrix = new LinkedList<LinkedList<int>>();

            var matrix1Rows = new List<LinkedList<int>>(matrix1);
            var matrix2Rows = new List<LinkedList<int>>(matrix2);

            for (int i = 0; i < rows1; i++)
            {
                var resultRow = new LinkedList<int>();
                for (int j = 0; j < cols2; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < cols1; k++)
                    {
                        sum += GetElement(matrix1Rows[i], k) * GetElement(matrix2Rows[k], j);
                    }
                    resultRow.AddLast(sum);
                }
                resultMatrix.AddLast(resultRow);
            }

            return resultMatrix;
        }
        /// <summary>
        /// Получает длину строки (количество элементов) в узле связного списка.
        /// </summary>
        /// <param name="rowNode">Узел строки.</param>
        /// <returns>Длина строки или 0, если строка отсутствует.</returns>
        static int GetRowLength(LinkedListNode<LinkedList<int>> rowNode)

        {
            return rowNode?.Value?.Count ?? 0;
        }

        /// <summary>
        /// Извлекает элемент из строки связного списка по указанному индексу.
        /// </summary>
        /// <param name="row">Строка связного списка.</param>
        /// <param name="index">Индекс элемента.</param>
        /// <returns>Значение элемента.</returns>
        static int GetElement(LinkedList<int> row, int index)

        {
            var currentNode = row.First;
            for (int i = 0; i < index; i++)
            {
                currentNode = currentNode?.Next;
            }
            return currentNode?.Value ?? 0;
        }

        /// <summary>
        /// Печатает матрицу, заданную в виде двумерного связного списка.
        /// </summary>
        /// <param name="matrix">Матрица для печати.</param>
        static void PrintMatrix(LinkedList<LinkedList<int>> matrix)

        {
            foreach (var row in matrix)
            {
                foreach (var element in row)
                {
                    Console.Write($"{element} ");
                }
                Console.WriteLine();
            }
        }
        static void Task3()
        {
            Console.WriteLine("\nУпражнение 6.3(задание)\n");
            Console.WriteLine("Написать программу, вычисляющую среднюю температуру за год. Создать двумерный рандомный массив temperature[12,30], в котором будет храниться температура для каждого дня месяца (предполагается, что в каждом месяце 30 дней). Сгенерировать значения температур случайным образом. Для каждого месяца распечатать среднюю температуру. Для этого написать метод, который по массиву temperature [12,30] для каждого месяца вычисляет среднюю температуру в нем, и в качестве результата возвращает массив средних температур. Полученный массив средних температур отсортировать по возрастанию.");
            Random rand = new Random();
            Dictionary<string, int[]> temperature = new Dictionary<string, int[]>();
            string[] monthNames = { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
            foreach (string month in monthNames)
            {
                int[] monthDay = new int[30];
                for (int i = 0; i < monthDay.Length; i++)
                {
                    monthDay[i] = rand.Next(-40, 40);
                }

                temperature.Add(month, monthDay);
            }
            double[] ans = AvgTemp(temperature);
            for (int i = 0; i < 12; i++) 
            {
                Console.WriteLine($"{temperature.Keys.ElementAt(i)}: {ans[i]:F1}{"\u00B0"}C");
            }
            Console.WriteLine($"Среднегодовая температура{(double)(ans.Sum()/12)}");

        }
        /// <summary>
        /// Вычисляет среднюю температуру для каждого месяца на основе данных о температуре.
        /// </summary>
        /// <param name="temperature">
        /// Словарь, где ключи — названия месяцев, а значения — массивы температур по дням.
        /// </param>
        /// <returns>Массив средних температур для каждого месяца.</returns>
        static double[] AvgTemp(Dictionary<string, int[]> temperature)

        {
            double[] meanTemp = new double[temperature.Count];
            int index = 0;
            foreach (var month in temperature)
            {
                double sum = 0;
                foreach (int temp in month.Value)
                {
                    sum += temp;
                }
                meanTemp[index++] = sum / month.Value.Length;
            }
            return meanTemp;
        }

    }
}
