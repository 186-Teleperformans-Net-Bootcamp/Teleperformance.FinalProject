using FinalProject.Application.Interfaces.Repositories.Common;
using FinalProject.Domain.Entities.Common;
using FinalProject.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace FinalProject.Persistence.Repositories.Common
{
    public class CommandRepository<T> : ICommandRepository<T> where T : BaseEntity
    {
        private readonly PostgreSqlDbContext _context;

        public CommandRepository(PostgreSqlDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task AddAsync(T model)
        {
            await Table.AddAsync(model);
        }

        public async Task AddMultipleAsync(List<T> models)
        {
            await Table.AddRangeAsync(models);
        }

        public void Remove(T model)
        {
            Table.Remove(model);
        }

        public async Task RemoveByIdAsync(string id)
        {
            T model = await Table.FindAsync(Guid.Parse(id));
            Remove(model);//TODO buralara exeption koy
        }

        public void RemoveMultiple(List<T> models)
        {
            Table.RemoveRange(models);
        }

        public void Update(T model)
        {
            Table.Update(model);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
