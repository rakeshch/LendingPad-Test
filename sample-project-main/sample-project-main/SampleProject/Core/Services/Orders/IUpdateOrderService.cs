using System;
using BusinessEntities;

namespace Core.Services.Orders
{
    public interface IUpdateOrderService
    {
        void Update(Order order, Guid productId, int quantity, DateTime orderDate);
    }
}
