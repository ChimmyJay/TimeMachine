namespace TimeMachine.WebApi.Contracts.AnkiImporter;

public class AddCardsRequest
{
    public string DeckName { get; init; }
    public IEnumerable<AnkiCardViewModel> Cards { get; init; }
}