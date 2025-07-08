using BusinessEntities;
using System;

namespace WebApi.Models.Orders
{
    public class OrderData : IdObjectData
    {
        public OrderData(Order order) : base(order)
        {
            ProductId = order.ProductId;
            Quantity = order.Quantity;
            OrderDate = order.OrderDate;
        }

        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
