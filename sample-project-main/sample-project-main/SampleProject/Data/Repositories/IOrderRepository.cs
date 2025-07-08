using BusinessEntities;
using System;
using System.Collections.Generic;

namespace Data.Repositories
{
    public interface IOrderRepository : IInMemoryRepository<Order>
    {
        IEnumerable<Order> GetOrder(Guid? productId = null, int? minQuantity = null, int? maxQuantity = null, DateTime? fromDate = null, DateTime? toDate = null);
        Order GetById(Guid id);
        void DeleteAll();
    }
}
