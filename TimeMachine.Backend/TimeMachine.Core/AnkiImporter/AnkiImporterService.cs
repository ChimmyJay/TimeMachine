using TimeMachine.Core.AnkiImporter.DomainModels;
using TimeMachine.Core.AnkiImporter.Enums;
using TimeMachine.Core.AnkiImporter.Queries;

namespace TimeMachine.Core.AnkiImporter;

public class AnkiImporterService : IAnkiImporterService
{
    private readonly FileResolverLocator _fileResolverLocator;

    public AnkiImporterService(FileResolverLocator fileResolverLocator)
    {
        _fileResolverLocator = fileResolverLocator;
    }

    public async Task<IEnumerable<AnkiCard>> ResolveFile(ResolveFileQuery query)
    {
        await Task.CompletedTask;

        return _fileResolverLocator.Locate(query.Type)
            .Resolve(query.Stream);
    }
}