using Certificates2024.Data.Services;
using Certificates2024.Data.Static;
using Certificates2024.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

[Authorize]
public class TestsController : Controller
{
    private readonly IQuestionsService _questionsService;
    private readonly ITestsService _testsService;
    private readonly ICandidatesService _candidatesService;
    private readonly UserManager<ApplicationUser> _userManager;

    public TestsController(IQuestionsService questionsService, ITestsService testsService, ICandidatesService candidatesService, UserManager<ApplicationUser> userManager)
    {
        _questionsService = questionsService;
        _testsService = testsService;
        _candidatesService = candidatesService;
        _userManager = userManager;
    }

    // GET: Tests/Start/{topicId}
    public async Task<IActionResult> Start(int topicId)
    {
        var questions = await _questionsService.GetQuestionsByTopicIdAsync(topicId);
        if (!questions.Any())
        {
            return NotFound("No questions available for this topic.");
        }

        ViewBag.CertificateTopicId = topicId;
        return View(questions);
    }

    // POST: Tests/Submit
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Submit(int topicId, List<CandidateResponse> responses)
    {
        if (responses == null || !responses.Any())
        {
            return BadRequest("No responses provided.");
        }

        var score = await _testsService.CalculateScoreAsync(topicId, responses);

        var applicationUserId = _userManager.GetUserId(User); // Get the logged-in user's ApplicationUserId
        var candidate = await _candidatesService.GetCandidateByApplicationUserIdAsync(applicationUserId);

        //int candidateId = candidate.Id;

        var candidateTest = new CandidateTest
        {
            //CandidateId = candidateId,
            CandidateId = candidate.Id,
            CertificateTopicId = topicId,
            TestDate = DateTime.UtcNow,
            Responses = responses,
            Score = score
        };

        await _testsService.SaveTestResultAsync(candidateTest);

        ViewBag.Score = score;
        return View("Result", candidateTest);
    }
}
