using BusinessEntities;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class ProductRepository : InMemoryRepository<Product>, IProductRepository
    {
        public IEnumerable<Product> Get(string name = null, decimal? minPrice = null, decimal? maxPrice = null, string category = null)
        {
            var query = _store.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(p => p.Name != null && p.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            if (minPrice.HasValue)
            {
                query = query.Where(p => p.Price >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(p => p.Price <= maxPrice.Value);
            }

            if (!string.IsNullOrWhiteSpace(category))
            {
                query = query.Where(p => p.Category != null && p.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
            }

            return query.ToList();
        }

        public Product GetById(Guid id)
        {
            return Get(id);
        }

    }
}
