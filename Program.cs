namespace DelegatesAndLambdas;

internal static class Program
{
    private static void Main()
    {
        var numbers = new NumberProcessor();
        var messages = new MessageProcessor();

        try
        {
            while (true)
            {
                Console.WriteLine("\nDelegatesAndLambdas");
                Console.WriteLine("1 — Обработка чисел");
                Console.WriteLine("2 — Обработка сообщений");
                Console.WriteLine("3 — История");
                Console.WriteLine("0 — Выход");

                int choice = ConsoleInput.ReadInt("Выберите пункт: ", 0, 3);
                if (choice == 0) return;
                if (choice == 1)
                    numbers.Process(ConsoleInput.ReadNumbers(), Console.Out);
                else if (choice == 2)
                    messages.Process(ConsoleInput.ReadMessages(), Console.Out);
                else
                {
                    Console.WriteLine("История чисел:");
                    foreach (int number in numbers.History)
                        Console.WriteLine(number);
                    Console.WriteLine("История сообщений:");
                    foreach (string message in messages.History)
                        Console.WriteLine(message);
                }
            }
        }
        catch (EndOfStreamException)
        {
            Console.WriteLine("Ввод завершён.");
        }
    }
}