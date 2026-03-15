

using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace AIResumeScanner.Services;

public class ResumeAIService
{
    private readonly HttpClient _httpClient;

    public ResumeAIService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> AnalyzeResume(string resumeText, string jobDescription)
    {
        var prompt = $@"
Analyze the following resume and job description.

Return ONLY valid JSON in this format:

{{
  ""resumeScore"": number,
  ""matchScore"": number,
  ""skills"": ""list of skills"",
  ""strengths"": ""candidate strengths"",
  ""missingSkills"": ""skills missing for the job"",
  ""improvements"": ""how the candidate can improve the resume""
}}

Resume:
{resumeText}

Job Description:
{jobDescription}
";

        var requestBody = new
        {
            model = "openai/gpt-3.5-turbo",
            messages = new[]
            {
                new { role = "user", content = prompt }
            }
        };

        var json = JsonSerializer.Serialize(requestBody);

        var request = new HttpRequestMessage(
            HttpMethod.Post,
            "https://openrouter.ai/api/v1/chat/completions"
        );

        request.Headers.Authorization =
            new AuthenticationHeaderValue("Bearer", "key");

        request.Content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.SendAsync(request);

        var responseString = await response.Content.ReadAsStringAsync();

        using var doc = JsonDocument.Parse(responseString);

        var content = doc
            .RootElement
            .GetProperty("choices")[0]
            .GetProperty("message")
            .GetProperty("content")
            .GetString();

        return content;
    }
}