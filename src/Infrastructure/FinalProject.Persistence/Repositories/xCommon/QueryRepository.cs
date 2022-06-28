using FinalProject.Application.Interfaces.Repositories.Common;
using FinalProject.Domain.Entities.Common;
using FinalProject.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace FinalProject.Persistence.Repositories.Common
{
    public class QueryRepository<T> : IQueryRepository<T> where T : BaseEntity
    {
        private readonly PostgreSqlDbContext _context;

        public QueryRepository(PostgreSqlDbContext context)
        {
            _context = context;
        }
        DbSet<T> IRepository<T>.Table => throw new NotImplementedException();//TODO burdada exception eklenecek

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {

            return Table.AsNoTracking();
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> expression, bool tracking = true)
        {
            return await Table.FirstOrDefaultAsync(expression);
        }
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool tracking = true)
        {
            return Table.Where(expression);

        }
        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
            return await Table.FindAsync(Guid.Parse(id));
        }

    }
}
