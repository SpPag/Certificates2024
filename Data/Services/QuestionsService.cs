using Certificates2024.Data.Base;
using Certificates2024.Models;
using Microsoft.EntityFrameworkCore;

namespace Certificates2024.Data.Services
{
    public class QuestionsService:EntityBaseRepository<Question>, IQuestionsService
    {
        private readonly AppDbContext _context;
        public QuestionsService(AppDbContext context) : base(context) {
            _context = context ?? throw new ArgumentNullException(nameof(context), "DbContext was not injected properly.");
        }
        public async Task<IEnumerable<CertificateTopic>> GetAllTopicsAsync()
        {
            return await _context.CertificateTopics.ToListAsync();
        }
    }
}
