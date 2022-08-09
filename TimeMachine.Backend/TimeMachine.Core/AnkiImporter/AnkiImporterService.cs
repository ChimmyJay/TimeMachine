using TimeMachine.Core.AnkiImporter.Commands;
using TimeMachine.Core.AnkiImporter.DomainModels;
using TimeMachine.Core.AnkiImporter.Queries;

namespace TimeMachine.Core.AnkiImporter;

public class AnkiImporterService : IAnkiImporterService
{
    private readonly FileResolverLocator _fileResolverLocator;
    private readonly IAnkiApi _ankiApi;

    public AnkiImporterService(FileResolverLocator fileResolverLocator, IAnkiApi ankiApi)
    {
        _fileResolverLocator = fileResolverLocator;
        _ankiApi = ankiApi;
    }

    public async Task<IEnumerable<AnkiCard>> ResolveFile(ResolveFileQuery query)
    {
        await Task.CompletedTask;

        return _fileResolverLocator.Locate(query.Type)
            .Resolve(query.Stream);
    }

    public async Task Import(ImportCommand command)
    {
        await _ankiApi.CreateDeck(command.DeckName);
        await _ankiApi.AddCards(command.Cards);
    }
}