using Certificates2024.Data.Base;
using Certificates2024.Models;

namespace Certificates2024.Data.Services
{
    public class QuestionsService:EntityBaseRepository<Question>, IQuestionsService
    {
        private readonly AppDbContext _context;
        public QuestionsService(AppDbContext context) : base(context) { }
    }
}
