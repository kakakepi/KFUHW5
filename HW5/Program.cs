using System;
using System.Collections.Generic;
using System.IO;

namespace Lab3
{
    class Program
    {
        static void Task1(string[] args)
        {
            Console.WriteLine("Упражнение 1");
            Console.WriteLine("Создать студента из вашей группы (фамилия, имя, год рождения, с каким экзаменом поступил, баллы). Создать словарь для студентов из вашей группы (10 человек). Необходимо прочитать информацию о студентах с файла. В консоли необходимо создать меню:");
            if (args.Length == 0)
            {
                Console.WriteLine("Ошибка: путь к файлу не указан.");
                return;
            }

            string filePath = args[0];
            var students = new Dictionary<string, object[]>();

            try
            {
                Console.WriteLine($"Чтение файла по пути: {filePath}");

                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] lineParts = line.Split("; ");

                    if (lineParts.Length >= 5)
                    {
                        string surname = lineParts[0];
                        string name = lineParts[1];
                        int.TryParse(lineParts[2], out int birthYear);
                        string exam = lineParts[3];
                        int.TryParse(lineParts[4], out int examScore);

                        students.Add(surname, new object[] { name, birthYear, exam, examScore });
                        foreach (var student in students)
                        {
                            Console.WriteLine($"{student.Key}: Имя - {student.Value[0]}, Год рождения - {student.Value[1]}, Экзамен - {student.Value[2]}, Баллы - {student.Value[3]}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Ошибка: некорректный формат строки - {line}");
                    }
                }
                Console.WriteLine("Введите 'Новый студент', если хотите добавить нового студента, 'Удалить', если хотите удалить студента, 'Сортировать', если хотите отсортировать по баллам.");
                Console.WriteLine("\nДоступные действия:");
                Console.WriteLine("1. Добавить нового студента (введите 'Добавить')");
                Console.WriteLine("2. Удалить студента (введите 'Удалить')");
                Console.WriteLine("3. Сортировать студентов по баллам (введите 'Сортировать')");

                string action = Console.ReadLine()?.Trim().ToLower();

                switch (action)
                {
                    case "добавить":
                    Console.WriteLine("Введите данные студента через '; ': Фамилия; Имя; Год рождения; Экзамен; Баллы");
                    string input = Console.ReadLine();
                    string[] parts = input.Split("; ");
                    if (parts.Length != 5)
                    {
                        Console.WriteLine("Ошибка: некорректный формат данных.");
                        return;
                    }

                    string surname = parts[0];
                    string name = parts[1];
                    int.TryParse(parts[2], out int birthYear);
                    string exam = parts[3];
                    int.TryParse(parts[4], out int examScore);

                    if (!students.ContainsKey(surname))
                    {
                        students.Add(surname, new object[] { name, birthYear, exam, examScore });
                        Console.WriteLine("Студент успешно добавлен.");
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: студент с такой фамилией уже существует.");
                    }
                    foreach (var student in students)
                    {
                        Console.WriteLine($"{student.Key}: Имя - {student.Value[0]}, Год рождения - {student.Value[1]}, Экзамен - {student.Value[2]}, Баллы - {student.Value[3]}");
                    }
                        return;
                    case "удалить":
                        Console.WriteLine("Введите фамилию студента, которого хотите удалить:");
                        string surnm = Console.ReadLine();

                        if (students.Remove(surnm))
                        {
                            Console.WriteLine("Студент успешно удален.");
                        }
                        else
                        {
                            throw new Exception("Такого студента не существует");
                        }
                        foreach (var student in students)
                        {
                            Console.WriteLine($"{student.Key}: Имя - {student.Value[0]}, Год рождения - {student.Value[1]}, Экзамен - {student.Value[2]}, Баллы - {student.Value[3]}");
                        }
                        return;
                    case "сортировать":
                        Console.WriteLine("Сортировка студентов по баллам:");
                        students.OrderBy(s => (int)s.Value[4]).ToList();
                        foreach (var student in students)
                        {
                            Console.WriteLine($"{student.Key}: Имя - {student.Value[0]}, Год рождения - {student.Value[1]}, Экзамен - {student.Value[2]}, Баллы - {student.Value[3]}");
                        }
                        return;
                        
                    default:
                        Console.WriteLine("Неизвестная команда. Попробуйте снова.");
                        
                        return;
                }
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

        static void Main(string[] args)
        {
            Task1(args);
        }
    }
}
