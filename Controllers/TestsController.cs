using Certificates2024.Data.Services;
using Certificates2024.Data.Static;
using Certificates2024.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

[Authorize]
public class TestsController : Controller
{
    private readonly IQuestionsService _questionsService;
    private readonly ITestsService _testsService;
    private readonly ICandidatesService _candidatesService;
    private readonly ICandidateCertificatesService _candidateCertificatesService;
    private readonly UserManager<ApplicationUser> _userManager;

    public TestsController(IQuestionsService questionsService, ITestsService testsService, ICandidatesService candidatesService, UserManager<ApplicationUser> userManager, ICandidateCertificatesService candidateCertificatesService)
    {
        _questionsService = questionsService;
        _testsService = testsService;
        _candidatesService = candidatesService;
        _userManager = userManager;
        _candidateCertificatesService = candidateCertificatesService;
    }

    // GET: Tests/Start/{topicId}
    public async Task<IActionResult> Start(int topicId, int candidateCertificateId)
    {
        // Fetch the CandidateCertificate to check eligibility
        var candidateCertificate = await _candidateCertificatesService.GetByIdAsync(candidateCertificateId);
        if (candidateCertificate == null)
        {
            return NotFound("Candidate Certificate not found.");
        }
        // Check if the user is eligible to start the test
        if (!candidateCertificate.IsTestEligible)
        {
            return BadRequest("You are not eligible to start this test.");
        }
        var questions = await _questionsService.GetQuestionsByTopicIdAsync(topicId);
        if (!questions.Any())
        {
            return NotFound("No questions available for this topic.");
        }

        ViewBag.CertificateTopicId = topicId;
        ViewBag.CandidateCertificateId = candidateCertificateId; // Pass this to the view for future use
        return View(questions);
    }

    // POST: Tests/Submit
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Submit(int topicId, int candidateCertificateId, List<CandidateResponse> responses)
    {
        if (responses == null || !responses.Any())
        {
            return BadRequest("No responses provided.");
        }

        var result = await _testsService.CalculateScoreAsync(topicId, responses);
        int CorrectAnswers = result.CorrectAnswers;
        int QuestionCount = result.QuestionCount;
        Console.WriteLine($"CorrectAnswers: {CorrectAnswers}, QuestionCount: {QuestionCount}");
        var score = (double)result.CorrectAnswers / result.QuestionCount * 100;
        Console.WriteLine($"Score: {score}");

        var applicationUserId = _userManager.GetUserId(User); // Get the logged-in user's ApplicationUserId
        var candidate = await _candidatesService.GetCandidateByApplicationUserIdAsync(applicationUserId);

        //int candidateId = candidate.Id;

        var candidateTest = new CandidateTest
        {
            //CandidateId = candidateId,
            CandidateId = candidate.Id,
            CertificateTopicId = topicId,
            CandidateCertificateId = candidateCertificateId, // Associate this test with the certificate
            TestDate = DateTime.UtcNow,
            Responses = responses,
            Score = score
        };
        await _testsService.SaveTestResultAsync(candidateTest);
        var candidateCertificate = await _candidateCertificatesService.GetCandidateCertificateByTestIdAsync(candidateTest);
        candidateCertificate.CandidateScore = CorrectAnswers;
        candidateCertificate.MaximumScore = QuestionCount;
        candidateCertificate.ResultLabel = score >= 50;
        candidateCertificate.CandidateTestId = candidateTest.Id;
        await _candidateCertificatesService.UpdateAsync(candidateCertificate.Id, candidateCertificate);
        ViewBag.Score = score;
        return View("Result", candidateTest);
    }
}