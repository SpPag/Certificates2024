using Certificates2024.Data.Base;
using Certificates2024.Models;

namespace Certificates2024.Data.Services
{
    public interface IQuestionsService : IEntityBaseRepository<Question>
    {
        Task<IEnumerable<CertificateTopic>> GetAllTopicsAsync(); // Method to get all topics
        Task<IEnumerable<Question>> GetQuestionsByTopicIdAsync(int topicId); //Gets questions by topic

    }
}