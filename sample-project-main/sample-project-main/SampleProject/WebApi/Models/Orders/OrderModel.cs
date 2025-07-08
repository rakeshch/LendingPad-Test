using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Orders
{
    public class OrderModel
    {
        [Required(ErrorMessage = "Product ID is required.")]
        public Guid ProductId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than zero.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Order date is required.")]
        public DateTime OrderDate { get; set; }
    }
}