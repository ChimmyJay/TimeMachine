using System.Text;
using System.Text.Json;
using TimeMachine.Core.AnkiImporter;
using TimeMachine.Core.AnkiImporter.DomainModels;
using TimeMachine.Infrastructure.AnkiImporter.AnkiConnectApiDtos;

namespace TimeMachine.Infrastructure.AnkiImporter;

public class AnkiConnectApi : IAnkiApi
{
    private readonly HttpClient _httpClient;
    private readonly Uri _requestUri = new("http://127.0.0.1:8765/");

    public AnkiConnectApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task AddCards(IEnumerable<AnkiCard> cards)
    {
        throw new NotImplementedException();
    }

    public async Task CreateDeck(string deckName)
    {
        throw new NotImplementedException();
        var request = new CreateDeckRequest
        {
            Action = "createDeck",
            Version = 6,
            Params = new CreateDeckParam()
            {
                Deck = deckName
            }
        };
        var payload = JsonSerializer.Serialize(
            request, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
        var httpContent = new StringContent(payload, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(_requestUri, httpContent);
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<CreateDeckResponse>(responseBody);
        if (result?.Result == null)
        {
            throw new Exception(result?.Error);
        }
    }
}