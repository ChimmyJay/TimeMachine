using System.Globalization;
using System.Text;
using CsvHelper;
using TimeMachine.Core.AnkiImporter;
using TimeMachine.Core.AnkiImporter.DomainModels;

namespace TimeMachine.Infrastructure.AnkiImporter;

public class IqTranslateCsvResolver : IQTranslateCsvResolver
{
    public IEnumerable<AnkiCard> Resolve(Stream stream)
    {
        using var reader = new StreamReader(stream, Encoding.UTF8);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        csv.Context.RegisterClassMap<QTranslateCsvRowDataMap>();

        return csv.GetRecords<QTranslateCsvRowData>()
            .ToList()
            .Select(x => AnkiCard.CreateEnglishWordCard(x.OriginalContent, x.TranslatedContent));
    }
}