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
    public class ProductFeaturesController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<ProductFeature> _service;

        public ProductFeaturesController(IMapper mapper, IService<ProductFeature> service)
        {
            _mapper = mapper;
            _service = service;
        }

        [SwaggerResponse((int)HttpStatusCode.OK, "[Action]", typeof(IEnumerable<int>))]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var productFeatures = await _service.GetAllAsync();

            var productFeatureDto = _mapper.Map<List<ProductFeature>>(productFeatures.ToList());

            return CreateActionResult(CustomResponseDto<List<ProductFeature>>.Success(200, productFeatureDto));

        }


        [SwaggerResponse((int)HttpStatusCode.OK, "[Action]", typeof(IEnumerable<int>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var productFeature = await _service.GetByIdAsync(id);

            var productFeatureDto = _mapper.Map<ProductFeatureDto>(productFeature);

            return CreateActionResult(CustomResponseDto<ProductFeatureDto>.Success(200, productFeatureDto));

        }

        [SwaggerResponse((int)HttpStatusCode.OK, "[Action]", typeof(IEnumerable<int>))]
        [HttpPost]
        public async Task<IActionResult> Save(ProductFeatureDto productFeatureDto)
        {
            var mappedProductFeatureDto = _mapper.Map<ProductFeature>(productFeatureDto);

            var productFeature = await _service.AddAsync(mappedProductFeatureDto);

            var newProductFeatureDto = _mapper.Map<ProductFeatureDto>(productFeature);

            return CreateActionResult(CustomResponseDto<ProductFeatureDto>.Success(201, newProductFeatureDto));

        }

        [SwaggerResponse((int)HttpStatusCode.OK, "[Action]", typeof(IEnumerable<int>))]
        [HttpPut]
        public async Task<IActionResult> Update(ProductFeatureDto productFeatureDto)
        {
            var mappedProductFeature = _mapper.Map<ProductFeature>(productFeatureDto);

            // Geriye birşey dönmediği için atama yapamıyoruz.
            await _service.UpdateAsync(mappedProductFeature);

            // NoContentDto ' nun işlevi burda devreye giriyor geriye birşey dönmediğimiz için 2 tane constructor oluşturmustuk burda kullandık.
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));

        }

        [SwaggerResponse((int)HttpStatusCode.OK, "[Action]", typeof(IEnumerable<int>))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var productFeature = await _service.GetByIdAsync(id);

            await _service.RemoveAsync(productFeature);



            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));

        }
    }
}
