using TimeMachine.Core.AnkiImporter.Enums;

namespace TimeMachine.Core.AnkiImporter.Queries;

public class ResolveFileQuery
{
    public Stream Stream { get; init; }
    public EnumResolveDataType Type { get; init; }
}