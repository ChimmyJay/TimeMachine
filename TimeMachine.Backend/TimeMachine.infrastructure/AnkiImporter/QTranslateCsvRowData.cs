namespace TimeMachine.Infrastructure.AnkiImporter;

public class QTranslateCsvRowData
{
    public string? TranslateBy { get; set; }
    public string? LanguageFrom { get; set; }
    public string? OriginalContent { get; set; }
    public string? LanguageTo { get; set; }
    public string? TranslatedContent { get; set; }
}