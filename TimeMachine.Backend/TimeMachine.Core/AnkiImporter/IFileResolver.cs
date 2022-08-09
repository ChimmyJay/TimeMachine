using TimeMachine.Core.AnkiImporter.DomainModels;

namespace TimeMachine.Core.AnkiImporter;

public interface IFileResolver
{
    IEnumerable<AnkiCard> Resolve(Stream stream);
}