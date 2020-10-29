using System.Linq;

namespace ConoceTe.Citas.Domain.SeedWork
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
        T Add(T obj);
        T GetById(int id);
        IQueryable<T> GetAll();
        void Update(T obj);
        void Remove(int id);
    }

}
