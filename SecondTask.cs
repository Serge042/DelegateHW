using System;
using System.Collections.Generic;

// Собственный тип исключения для неверного ввода
public class InvalidInputException : Exception
{
    public InvalidInputException() : base("Некорректный ввод. Введите 1 или 2.") { }
    public InvalidInputException(string message) : base(message) { }
}

class Program
{
    // Делегат для события сортировки
    public delegate void SortHandler(List<string> surnames, int sortDirection);
    
    // Событие сортировки
    public static event SortHandler OnSort;

    static void Main()
    {
        // Инициализация списка фамилий
        List<string> surnames = new List<string> 
        { 
            "Иванов", 
            "Петров", 
            "Сидоров", 
            "Алексеев", 
            "Зайцев" 
        };

        // Подписка на событие сортировки
        OnSort += SortSurnames;

        Console.WriteLine("Исходный список фамилий:");
        PrintList(surnames);

        while (true)
        {
            try
            {
                Console.WriteLine("\nВведите 1 для сортировки А-Я или 2 для сортировки Я-А:");
                string input = Console.ReadLine();

                // Проверка ввода
                if (!int.TryParse(input, out int sortDirection) || (sortDirection != 1 && sortDirection != 2))
                {
                    throw new InvalidInputException();
                }

                // Вызов события сортировки
                OnSort?.Invoke(surnames, sortDirection);

                Console.WriteLine("\nОтсортированный список:");
                PrintList(surnames);
            }
            catch (InvalidInputException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Неизвестная ошибка: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("\nДля выхода нажмите ESC, для продолжения - любую другую клавишу");
                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                    break;
            }
        }
    }

    // Метод для сортировки фамилий
    private static void SortSurnames(List<string> surnames, int sortDirection)
    {
        switch (sortDirection)
        {
            case 1:
                surnames.Sort(); // Сортировка А-Я
                break;
            case 2:
                surnames.Sort();
                surnames.Reverse(); // Сортировка Я-А
                break;
        }
    }

    // Метод для вывода списка
    private static void PrintList(List<string> list)
    {
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
    }
}
