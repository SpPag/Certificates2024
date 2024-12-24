using Certificates2024.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Certificates2024.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {

        private readonly AppDbContext _context;

        public EntityBaseRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context)); ;
        }
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            //var entity = await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
            //We use the below because it is more efficient/faster and searches by primary key only
            var entity = await _context.FindAsync<T>(id);
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var query = _context.Set<T>().AsQueryable();

            // Check if T is CandidateCertificate type and apply includes
            if (typeof(T) == typeof(CandidateCertificate))
            {
                query = query.Include(c => (c as CandidateCertificate).Candidate)         // Include Candidate
                             .Include(c => (c as CandidateCertificate).CertificateTopic);  // Include CertificateTopic
            }

            return await query.ToListAsync();
            //return await _context.Set<T>().ToListAsync();
        }
        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.ToListAsync();
        }

        //public virtual async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
        public virtual async Task<T> GetByIdAsync(int id)
        {

            var query = _context.Set<T>().AsQueryable();

            // Check if T is CandidateCertificate type and apply includes
            if (typeof(T) == typeof(CandidateCertificate))
            {
                query = query.Include(c => (c as CandidateCertificate).Candidate)         // Include Candidate
                             .Include(c => (c as CandidateCertificate).CertificateTopic);  // Include CertificateTopic
            }

            return await query.FirstOrDefaultAsync(n => EF.Property<int>(n, "Id") == id);
        }
        public async Task UpdateAsync(int id, T entity)
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
