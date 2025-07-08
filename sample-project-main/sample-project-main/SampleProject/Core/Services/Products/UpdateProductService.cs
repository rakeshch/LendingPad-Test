using BusinessEntities;
using Common;
using System;

namespace Core.Services.Products
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class UpdateProductService : IUpdateProductService
    {
        public void Update(Product product, string name, decimal price, string category)
        {
            product.SetName(name);
            product.SetPrice(price);
            product.SetCategory(category);
        }
    }
}
