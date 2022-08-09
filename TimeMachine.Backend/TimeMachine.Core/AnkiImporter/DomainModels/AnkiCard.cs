namespace TimeMachine.Core.AnkiImporter.DomainModels;

public class AnkiCard
{
    public static AnkiCard CreateEnglishWordCard(string? english, string? chinese)
    {
        return new AnkiCard(english, chinese);
    }

    public AnkiCard(string? front, string? back)
    {
        Front = front;
        Back = back;
    }

    public string? Front { get; }
    public string? Back { get; }
}