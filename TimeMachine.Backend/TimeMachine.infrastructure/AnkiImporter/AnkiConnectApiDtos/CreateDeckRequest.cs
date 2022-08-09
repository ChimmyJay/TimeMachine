namespace TimeMachine.Infrastructure.AnkiImporter.AnkiConnectApiDtos;

public class CreateDeckRequest
{
    public string Action { get; set; }
    public int Version { get; set; }
    public CreateDeckParam Params { get; set; }
}