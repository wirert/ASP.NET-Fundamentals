using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using WebShopDemo.Core.Contracts;

namespace WebShopDemo.Grpc.Services
{
    public class ProductGrpcService : Product.ProductBase
    {
        private readonly IProductService productService;

        public ProductGrpcService(IProductService _productService)
        {
            productService = _productService;
        }

        public override async Task<ProductList> GetAll(Empty request, ServerCallContext context)
        {
            var result = new ProductList();

            var products = await productService.GetAllAsync();

            result.Items.AddRange(products.Select(p => new ProductItem()
            {
                Id = p.Id.ToString(),
                Name = p.Name,
                Price = (double)p.Price,
                Quantity = p.Quantity
            }));

            return result;
        }

    }
}
