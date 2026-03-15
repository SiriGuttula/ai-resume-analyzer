namespace AIResumeScanner.Models;

public class ResumeAnalysis
{
    public int resumeScore { get; set; }
    public int matchScore { get; set; }

    public List<string> skills { get; set; }

    public string strengths { get; set; }

    public List<string> missingSkills { get; set; }

    public string improvements { get; set; }
}