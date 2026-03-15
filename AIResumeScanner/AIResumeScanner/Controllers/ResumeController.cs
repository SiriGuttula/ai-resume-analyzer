using Microsoft.AspNetCore.Mvc;
using AIResumeScanner.Services;
using AIResumeScanner.Models;
using UglyToad.PdfPig;
using System.Text.Json;

namespace AIResumeScanner.Controllers;

[ApiController]
[Route("api/resume")]
public class ResumeController : ControllerBase
{
    private readonly ResumeAIService _service;

    public ResumeController(ResumeAIService service)
    {
        _service = service;
    }

    [HttpPost("analyze")]
    public async Task<IActionResult> Analyze(IFormFile file, [FromForm] string jobDescription)
    {
        if (file == null)
            return BadRequest("File missing");

        string text = "";

        using (var stream = file.OpenReadStream())
        using (var pdf = PdfDocument.Open(stream))
        {
            foreach (var page in pdf.GetPages())
            {
                text += page.Text;
            }
        }

        var aiResult = await _service.AnalyzeResume(text, jobDescription);

        var parsed = JsonSerializer.Deserialize<ResumeAnalysis>(aiResult);

        return Ok(parsed);
    }
}