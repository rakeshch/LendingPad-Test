using System;
using BusinessEntities;

namespace Core.Services.Orders
{
    public interface ICreateOrderService
    {
        Order Create(Guid id, Guid productId, int quantity, DateTime orderDate);
    }
}
