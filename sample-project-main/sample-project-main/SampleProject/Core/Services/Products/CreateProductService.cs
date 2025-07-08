using BusinessEntities;
using Common;
using Core.Factories;
using System;
using Data.Repositories;

namespace Core.Services.Products
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class CreateProductService : ICreateProductService
    {
        private readonly IUpdateProductService _updateProductService;
        private readonly IIdObjectFactory<Product> _productFactory;
        private readonly IProductRepository _productRepository;

        public CreateProductService(
            IIdObjectFactory<Product> productFactory,
            IProductRepository productRepository,
            IUpdateProductService updateProductService)
        {
            _productFactory = productFactory;
            _productRepository = productRepository;
            _updateProductService = updateProductService;
        }

        public Product Create(Guid id, string name, decimal price, string category)
        {
            var product = _productRepository.Get(id);
            if (product == null)
            {
                product = _productFactory.Create(id); // create new product if doesn't exist
            }

            _updateProductService.Update(product, name, price, category);
            _productRepository.Save(product);
            return product;
        }
    }
}
