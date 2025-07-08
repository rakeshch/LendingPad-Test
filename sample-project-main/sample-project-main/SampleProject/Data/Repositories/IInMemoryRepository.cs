using System;
using BusinessEntities;

namespace Data.Repositories
{
    public interface IInMemoryRepository<T> where T : IdObject
    {
        void Save(T entity);
        void Delete(T entity);
        T Get(Guid id);
    }
}