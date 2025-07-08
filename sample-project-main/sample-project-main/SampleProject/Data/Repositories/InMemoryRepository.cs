using System;
using System.Collections.Generic;
using System.Linq;
using BusinessEntities;
using Common;

namespace Data.Repositories
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class InMemoryRepository<T> : IInMemoryRepository<T> where T : IdObject
    {
        protected readonly List<T> _store = new List<T>();

        public void Save(T entity)
        {
            var existing = Get(entity.Id);
            if (existing != null)
            {
                _store.Remove(existing);
            }
            _store.Add(entity);
        }

        public void Delete(T entity)
        {
            _store.Remove(entity);
        }

        public T Get(Guid id)
        {
            return _store.FirstOrDefault(e => e.Id == id);
        }

        public void DeleteAll()
        {
            _store.Clear();
        }
    }
}
