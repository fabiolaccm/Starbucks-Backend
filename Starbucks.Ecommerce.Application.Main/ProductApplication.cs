using AutoMapper;
using Starbucks.Ecommerce.Application.DTO;
using Starbucks.Ecommerce.Application.Interface;
using Starbucks.Ecommerce.Domain.Interface;
using Starbucks.Ecommerce.Transversal.Common;

namespace Starbucks.Ecommerce.Application.Main
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductDomain _productDomain;
        private readonly IMapper _mapper;
        public ProductApplication(IProductDomain productDomain, IMapper mapper)
        {
            _productDomain = productDomain;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<ProductResponseDto>>> GetAllProducts()
        {
            var products = await _productDomain.FindAll();
            var data = _mapper.Map<IEnumerable<ProductResponseDto>>(products);
            return Response<IEnumerable<ProductResponseDto>>.Ok(data);
        }

        public async Task<Response<ProductResponseDto>> GetProductById(Guid id)
        {
            var product = await _productDomain.FindById(id);
            if (product == null)
            {
                return Response<ProductResponseDto>.Fail("Produc Not exists");
            }
            var data = _mapper.Map<ProductResponseDto>(product);
            return Response<ProductResponseDto>.Ok(data);
        }
    }
}
