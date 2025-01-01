using Certificates2024.Models;

namespace Certificates2024.Data.Services;
public interface ITestsService
{
    Task<(int CorrectAnswers, int QuestionCount)> CalculateScoreAsync(int topicId, List<CandidateResponse> responses);
    Task SaveTestResultAsync(CandidateTest candidateTest);
}