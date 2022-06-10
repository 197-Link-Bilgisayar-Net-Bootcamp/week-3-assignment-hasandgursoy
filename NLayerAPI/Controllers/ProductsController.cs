using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace NLayerAPI.Controllers
{

    public class ProductsController : CustomBaseController
    {

        private readonly IMapper _mapper;

        private readonly IProductService _service;

        public ProductsController(IMapper mapper, IProductService service)
        {
            _mapper = mapper;
            _service = service;

        }

        // Get api/products/GetProductsWithCategory
        [SwaggerResponse((int)HttpStatusCode.OK, "GetProductsWithCategory", typeof(IEnumerable<int>))]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductsWithCategory()
        {

            return CreateActionResult(await _service.GetProductsCategory());

        }

        [SwaggerResponse((int)HttpStatusCode.OK, "All", typeof(IEnumerable<int>))]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products = await _service.GetAllAsync();

            var productsDtos = _mapper.Map<List<ProductDto>>(products.ToList());

            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productsDtos));

        }


        [SwaggerResponse((int)HttpStatusCode.OK, "GetById", typeof(IEnumerable<int>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);

            var productDto = _mapper.Map<ProductDto>(product);

            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productDto));

        }

        [SwaggerResponse((int)HttpStatusCode.OK, "Save", typeof(IEnumerable<int>))]

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var mappedProduct = _mapper.Map<Product>(productDto);

            var product = await _service.AddAsync(mappedProduct);

            var newProductDto = _mapper.Map<ProductDto>(product);

            return CreateActionResult(CustomResponseDto<ProductDto>.Success(201, newProductDto));

        }

        [SwaggerResponse((int)HttpStatusCode.OK, "Update", typeof(IEnumerable<int>))]

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productDto)
        {
            var mappedProduct = _mapper.Map<Product>(productDto);

            // Geriye birşey dönmediği için atama yapamıyoruz.
            await _service.UpdateAsync(mappedProduct);

            // NoContentDto ' nun işlevi burda devreye giriyor geriye birşey dönmediğimiz için 2 tane constructor oluşturmustuk burda kullandık.
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));

        }
        
        [SwaggerResponse((int)HttpStatusCode.OK, "Remove", typeof(IEnumerable<int>))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _service.GetByIdAsync(id);

            await _service.RemoveAsync(product);



            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));

        }

    }
}
