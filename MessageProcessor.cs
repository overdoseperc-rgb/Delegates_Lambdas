namespace DelegatesAndLambdas;

public sealed class MessageProcessor
{
    private readonly List<string> history = new();
    public IReadOnlyList<string> History => history.AsReadOnly();

    public void Process(List<string> messages, TextWriter output)
    {
        Func<string, bool> filter = message => message.Length > 3;
        Func<string, string> transform = message => "[LOG] " + message.ToUpperInvariant();
        Action<string> print = result => output.WriteLine(result);
        Action<string> remember = result => history.Add(result);
        Action<string> combined = print;
        combined += remember;
        int processed = 0;
        foreach (string message in messages)
        {
            if (!filter(message)) continue;
            combined(transform(message));
            processed++;
        }
        output.WriteLine($"Обработано: {processed}; в истории: {history.Count}.");
    }
}