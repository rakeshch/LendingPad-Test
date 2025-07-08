using BusinessEntities;
using Common;
using Core.Factories;
using System;
using Data.Repositories;

namespace Core.Services.Orders
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class CreateOrderService : ICreateOrderService
    {
        private readonly IUpdateOrderService _updateOrderService;
        private readonly IIdObjectFactory<Order> _orderFactory;
        private readonly IOrderRepository _orderRepository;

        public CreateOrderService(
            IIdObjectFactory<Order> orderFactory,
            IOrderRepository orderRepository,
            IUpdateOrderService updateOrderService)
        {
            _orderFactory = orderFactory;
            _orderRepository = orderRepository;
            _updateOrderService = updateOrderService;
        }

        public Order Create(Guid id, Guid productId, int quantity, DateTime orderDate)
        {
            var order = _orderRepository.Get(id);
            if (order == null)
            {
                order = _orderFactory.Create(id); // create new order if doesn't exist
            }

            _updateOrderService.Update(order, productId, quantity, orderDate);
            _orderRepository.Save(order);
            return order;
        }
    }
}
