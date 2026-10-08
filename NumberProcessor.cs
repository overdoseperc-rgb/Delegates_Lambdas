namespace DelegatesAndLambdas;

public sealed class NumberProcessor
{
    private readonly List<int> history = new();
    public IReadOnlyList<int> History => history.AsReadOnly();

    public void Process(List<int> numbers, TextWriter output)
    {
        Func<int, bool> filter = number => number % 2 == 0;
        Func<int, int> transform = number => checked(number * number);
        Action<int> print = result => output.WriteLine($"Результат: {result}");
        Action<int> remember = result => history.Add(result);
        Action<int> combined = print;
        combined += remember;
        int processed = 0;
        foreach (int number in numbers)
        {
            if (!filter(number)) continue;
            int result;
            try { result = transform(number); }
            catch (OverflowException)
            {
                output.WriteLine($"Число {number} пропущено: квадрат выходит за диапазон int.");
                continue;
            }
            combined(result);
            processed++;
        }
        output.WriteLine($"Обработано: {processed}; в истории: {history.Count}.");
    }
}