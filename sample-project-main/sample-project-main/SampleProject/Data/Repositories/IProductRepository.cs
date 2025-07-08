using BusinessEntities;
using System;
using System.Collections.Generic;

namespace Data.Repositories
{
    public interface IProductRepository : IInMemoryRepository<Product>
    {
        IEnumerable<Product> Get(string name = null, decimal? minPrice = null, decimal? maxPrice = null, string category = null);
        Product GetById(Guid id);
        void DeleteAll();
    }
}
