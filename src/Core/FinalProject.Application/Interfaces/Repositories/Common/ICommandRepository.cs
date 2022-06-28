using FinalProject.Domain.Entities.Common;


namespace FinalProject.Application.Interfaces.Repositories.Common
{
    public interface ICommandRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task AddAsync(T model);
        Task AddMultipleAsync(List<T> datas);
        void Remove(T model);
        void RemoveMultiple(List<T> datas);
        Task RemoveByIdAsync(string id);
        void Update(T model);

        Task SaveAsync();
    }
}
