using BusinessEntities;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class OrderRepository : InMemoryRepository<Order>, IOrderRepository
    {
        public IEnumerable<Order> GetOrder(Guid? productId = null, int? minQuantity = null, int? maxQuantity = null, DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = _store.AsQueryable();

            if (productId.HasValue)
            {
                query = query.Where(o => o.ProductId == productId.Value);
            }

            if (minQuantity.HasValue)
            {
                query = query.Where(o => o.Quantity >= minQuantity.Value);
            }

            if (maxQuantity.HasValue)
            {
                query = query.Where(o => o.Quantity <= maxQuantity.Value);
            }

            if (startDate.HasValue)
            {
                query = query.Where(o => o.OrderDate >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                query = query.Where(o => o.OrderDate <= endDate.Value);
            }

            return query.ToList();
        }

        public Order GetById(Guid id)
        {
            return Get(id);
        }
    }
}
