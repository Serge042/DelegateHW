using System;

// Создаем собственный тип исключения
public class MyCustomException : Exception
{
    public MyCustomException() : base("Это мое пользовательское исключение!") { }
    
    public MyCustomException(string message) : base(message) { }
    
    public MyCustomException(string message, Exception innerException) 
        : base(message, innerException) { }
}

class Program
{
    static void Main()
    {
        // Массив из пяти различных исключений, включая собственное
        Exception[] exceptions = {
            new MyCustomException(),
            new ArgumentNullException("Параметр не может быть null"),
            new IndexOutOfRangeException("Выход за границы массива"),
            new DivideByZeroException("Деление на ноль"),
            new InvalidOperationException("Недопустимая операция")
        };

        // Обработка каждого исключения в цикле
        foreach (var ex in exceptions)
        {
            try
            {
                // Генерируем исключение
                throw ex;
            }
            catch (MyCustomException e)
            {
                Console.WriteLine($"Поймано пользовательское исключение: {e.Message}");
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"Поймано ArgumentNullException: {e.Message}");
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine($"Поймано IndexOutOfRangeException: {e.Message}");
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine($"Поймано DivideByZeroException: {e.Message}");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"Поймано InvalidOperationException: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Поймано общее исключение: {e.Message}");
            }
            finally
            {
                Console.WriteLine("Блок finally выполнен для: " + ex.GetType().Name + "\n");
            }
        }
    }
}
