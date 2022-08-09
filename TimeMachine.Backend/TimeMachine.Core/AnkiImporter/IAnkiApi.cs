using TimeMachine.Core.AnkiImporter.DomainModels;

namespace TimeMachine.Core.AnkiImporter;

public interface IAnkiApi
{
    Task AddCards(IEnumerable<AnkiCard> cards);
    Task CreateDeck(string deckName);
}