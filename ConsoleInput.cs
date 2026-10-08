namespace DelegatesAndLambdas;

internal static class ConsoleInput
{
    public static string ReadLine() => Console.ReadLine() ?? throw new EndOfStreamException();

    public static int ReadInt(string prompt, int min, int max)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(ReadLine(), out int value) && value >= min && value <= max)
                return value;
            Console.WriteLine($"Введите целое число от {min} до {max}.");
        }
    }

    public static List<int> ReadNumbers()
    {
        int count = ReadInt("Количество чисел (0–10000): ", 0, 10000);
        var numbers = new List<int>(count);
        for (int i = 0; i < count; i++)
            numbers.Add(ReadInt($"Число {i + 1}: ", int.MinValue, int.MaxValue));
        return numbers;
    }

    public static List<string> ReadMessages()
    {
        int count = ReadInt("Количество сообщений (0–10000): ", 0, 10000);
        var messages = new List<string>(count);
        for (int i = 0; i < count; i++)
        {
            Console.Write($"Сообщение {i + 1} (пустая строка допустима): ");
            messages.Add(ReadLine());
        }
        return messages;
    }
}