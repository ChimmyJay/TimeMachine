using Microsoft.AspNetCore.Mvc;
using TimeMachine.Core.AnkiImporter;
using TimeMachine.Core.AnkiImporter.Enums;
using TimeMachine.Core.AnkiImporter.Queries;
using TimeMachine.WebApi.Contracts.AnkiImporter;

namespace TimeMachine.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AnkiImporterController : ControllerBase
{
    private readonly IAnkiImporterService _service;

    public AnkiImporterController(IAnkiImporterService service)
    {
        _service = service;
    }

    [Route("ResolveFile")]
    [HttpPost]
    public async Task<ActionResult<AnalyzeFileResponse>> ResolveFile(
        IFormFile formFile,
        EnumResolveDataType type)
    {
        await using var stream = formFile.OpenReadStream();

        var ankiCards = await _service.ResolveFile(
            new ResolveFileQuery
            {
                Stream = stream,
                Type = type
            });
        return new AnalyzeFileResponse(ankiCards);
    }
}