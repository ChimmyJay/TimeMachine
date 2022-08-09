using TimeMachine.Core.AnkiImporter.Commands;
using TimeMachine.Core.AnkiImporter.DomainModels;
using TimeMachine.Core.AnkiImporter.Queries;

namespace TimeMachine.Core.AnkiImporter;

public interface IAnkiImporterService
{
    Task<IEnumerable<AnkiCard>> ResolveFile(ResolveFileQuery query);
    Task Import(ImportCommand command);
}