using BusinessEntities;
using Common;
using System;

namespace Core.Services.Orders
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class UpdateOrderService : IUpdateOrderService
    {
        public void Update(Order order, Guid productId, int quantity, DateTime orderDate)
        {
            order.SetProductId(productId);
            order.SetQuantity(quantity);
            order.SetOrderDate(orderDate);
        }
    }
}
