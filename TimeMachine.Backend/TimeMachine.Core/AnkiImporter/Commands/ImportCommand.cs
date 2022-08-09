using TimeMachine.Core.AnkiImporter.DomainModels;

namespace TimeMachine.Core.AnkiImporter.Commands;

public class ImportCommand
{
    public string DeckName { get; init; }
    public IEnumerable<AnkiCard> Cards { get; init; }
}