using TimeMachine.Core.AnkiImporter.DomainModels;

namespace TimeMachine.WebApi.Contracts.AnkiImporter;

public class AnalyzeFileResponse
{
    public AnalyzeFileResponse(IEnumerable<AnkiCard> ankiCards)
    {
        Cards = ankiCards.Select(
            x => new AnkiCardViewModel
            {
                Back = x.Back,
                Front = x.Front
            });
    }

    public IEnumerable<AnkiCardViewModel> Cards { get; }
}