using BusinessEntities;
using Core.Factories;
using Core.Services.Products;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApi.Models.Products;

namespace WebApi.Controllers
{
    [RoutePrefix("products")]
    public class ProductsController : BaseApiController
    {
        private readonly IProductRepository _productRepository;
        private readonly IUpdateProductService _updateProductService;
        private readonly IIdObjectFactory<Product> _productFactory;

        public ProductsController(IProductRepository productRepository, IUpdateProductService updateProductService, IIdObjectFactory<Product> productFactory)
        {
            _productRepository = productRepository;
            _updateProductService = updateProductService;
            _productFactory = productFactory;
        }

        [HttpPost]
        [Route("{productId:guid}/create")]
        public IHttpActionResult Create(Guid productId, [FromBody] ProductModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = _productRepository.GetById(productId);
            if (product == null)
            {
                product = _productFactory.Create(productId);
            }

            _updateProductService.Update(product, model.Name, model.Price, model.Category);
            _productRepository.Save(product);

            return Found(new ProductData(product));
        }

        [HttpPost]
        [Route("{productId:guid}/update")]
        public IHttpActionResult Update(Guid productId, [FromBody] ProductModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = _productRepository.GetById(productId);
            if (product == null)
                return DoesNotExist();

            _updateProductService.Update(product, model.Name, model.Price, model.Category);
            return Found(new ProductData(product));
        }

        [HttpDelete]
        [Route("{productId:guid}/delete")]
        public IHttpActionResult Delete(Guid productId)
        {
            var product = _productRepository.GetById(productId);
            if (product == null)
                return DoesNotExist();

            _productRepository.Delete(product);
            return Found();
        }

        [HttpGet]
        [Route("{productId:guid}")]
        public IHttpActionResult GetById(Guid productId)
        {
            var product = _productRepository.GetById(productId);
            if (product == null)
                return DoesNotExist();

            return Found(new ProductData(product));
        }

        [HttpGet]
        [Route("list")]
        public IHttpActionResult List(string name = null, decimal? minPrice = null, decimal? maxPrice = null, string category = null, int skip = 0, int take = 10)
        {
            var products = _productRepository
                .Get(name, minPrice, maxPrice, category)
                .Skip(skip)
                .Take(take)
                .Select(p => new ProductData(p))
                .ToList();

            return Found(products);
        }

        [HttpDelete]
        [Route("clear")]
        public IHttpActionResult DeleteAll()
        {
            _productRepository.DeleteAll();
            return Found();
        }
    }
}
