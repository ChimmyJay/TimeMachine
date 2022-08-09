using TimeMachine.Core.AnkiImporter.Enums;

namespace TimeMachine.Core.AnkiImporter;

public class FileResolverLocator
{
    private readonly IServiceProvider _serviceProvider;

    public FileResolverLocator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IFileResolver Locate(EnumResolveDataType type)
    {
        var fileResolver = type switch
        {
            EnumResolveDataType.QTranslateCsv =>
                _serviceProvider.GetService(typeof(IQTranslateCsvResolver)) as IFileResolver,
            EnumResolveDataType.QuizletCsv => throw new NotImplementedException(),
            EnumResolveDataType.Unknown => throw new ArgumentException("Unknown"),
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };

        return fileResolver!;
    }
}