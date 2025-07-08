using BusinessEntities;
using Core.Factories;
using Core.Services.Orders;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApi.Models.Orders;

namespace WebApi.Controllers
{
    [RoutePrefix("orders")]
    public class OrdersController : BaseApiController
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUpdateOrderService _updateOrderService;
        private readonly IIdObjectFactory<Order> _orderFactory;

        public OrdersController(IOrderRepository orderRepository, IUpdateOrderService updateOrderService, IIdObjectFactory<Order> orderFactory)
        {
            _orderRepository = orderRepository;
            _updateOrderService = updateOrderService;
            _orderFactory = orderFactory;
        }

        [HttpPost]
        [Route("{orderId:guid}/create")]
        public IHttpActionResult Create(Guid orderId, [FromBody] OrderModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var order = _orderRepository.GetById(orderId);
            if (order == null)
            {
                order = _orderFactory.Create(orderId);
            }

            _updateOrderService.Update(order, model.ProductId, model.Quantity, model.OrderDate);
            _orderRepository.Save(order);

            return Found(new OrderData(order));
        }

        [HttpPost]
        [Route("{orderId:guid}/update")]
        public IHttpActionResult Update(Guid orderId, [FromBody] OrderModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var order = _orderRepository.GetById(orderId);
            if (order == null)
                return DoesNotExist();

            _updateOrderService.Update(order, model.ProductId, model.Quantity, model.OrderDate);
            return Found(new OrderData(order));
        }

        [HttpDelete]
        [Route("{orderId:guid}/delete")]
        public IHttpActionResult Delete(Guid orderId)
        {
            var order = _orderRepository.GetById(orderId);
            if (order == null)
                return DoesNotExist();

            _orderRepository.Delete(order);
            return Found();
        }

        [HttpGet]
        [Route("{orderId:guid}")]
        public IHttpActionResult GetById(Guid orderId)
        {
            var order = _orderRepository.GetById(orderId);
            if (order == null)
                return DoesNotExist();

            return Found(new OrderData(order));
        }

        [HttpGet]
        [Route("list")]
        public IHttpActionResult List(Guid? productId = null, int? minQuantity = null, int? maxQuantity = null, DateTime? from = null, DateTime? to = null, int skip = 0, int take = 10)
        {
            var orders = _orderRepository
                .GetOrder(productId, minQuantity, maxQuantity, from, to)
                .Skip(skip)
                .Take(take)
                .Select(o => new OrderData(o))
                .ToList();

            return Found(orders);
        }


        [HttpDelete]
        [Route("clear")]
        public IHttpActionResult DeleteAll()
        {
            _orderRepository.DeleteAll();
            return Found();
        }
    }
}
