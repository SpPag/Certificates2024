using Certificates2024.Models;

namespace Certificates2024.Data.Services;
public interface ITestsService
{
    Task<double> CalculateScoreAsync(int topicId, List<CandidateResponse> responses);
    Task SaveTestResultAsync(CandidateTest candidateTest);
}