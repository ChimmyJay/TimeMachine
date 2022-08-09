using CsvHelper.Configuration;

namespace TimeMachine.Infrastructure.AnkiImporter;

public sealed class QTranslateCsvRowDataMap : ClassMap<QTranslateCsvRowData>
{
    public QTranslateCsvRowDataMap()
    {
        Map(m => m.TranslateBy).Index(0);
        Map(m => m.LanguageFrom).Index(1);
        Map(m => m.OriginalContent).Index(2);
        Map(m => m.LanguageTo).Index(3);
        Map(m => m.TranslatedContent).Index(4);
    }
}