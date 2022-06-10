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

    public class CategoriesController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _service;

        
        public CategoriesController(IMapper mapper, ICategoryService service)
        {
            _mapper = mapper;
            _service = service;
        }
        [SwaggerResponse((int)HttpStatusCode.OK, "[Action]", typeof(IEnumerable<int>))]
        [HttpGet("[action]/{categoryId}")]
        public async Task<IActionResult> GetProductsWithCategory(int categoryId)
        {

            return CreateActionResult(await _service.GetSingleCategoryByIdWithProducts(categoryId));

        }

        [SwaggerResponse((int)HttpStatusCode.OK, "[Action]", typeof(IEnumerable<int>))]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var categories = await _service.GetAllAsync();

            var categoriesDtos = _mapper.Map<List<CategoryDto>>(categories.ToList());

            return CreateActionResult(CustomResponseDto<List<CategoryDto>>.Success(200, categoriesDtos));

        }


        [SwaggerResponse((int)HttpStatusCode.OK, "[Action]", typeof(IEnumerable<int>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _service.GetByIdAsync(id);

            var categoryDto = _mapper.Map<CategoryDto>(category);

            return CreateActionResult(CustomResponseDto<CategoryDto>.Success(200, categoryDto));

        }

        [SwaggerResponse((int)HttpStatusCode.OK, "[Action]", typeof(IEnumerable<int>))]
        [HttpPost]
        public async Task<IActionResult> Save(CategoryDto categoryDto)
        {
            var mappedCategory = _mapper.Map<Category>(categoryDto);

            var category = await _service.AddAsync(mappedCategory);

            var newCategoryDto = _mapper.Map<CategoryDto>(category);

            return CreateActionResult(CustomResponseDto<CategoryDto>.Success(201, newCategoryDto));

        }

        [SwaggerResponse((int)HttpStatusCode.OK, "[Action]", typeof(IEnumerable<int>))]
        [HttpPut]
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
            var mappedCategory = _mapper.Map<Category>(categoryDto);

            // Geriye birşey dönmediği için atama yapamıyoruz.
            await _service.UpdateAsync(mappedCategory);

            // NoContentDto ' nun işlevi burda devreye giriyor geriye birşey dönmediğimiz için 2 tane constructor oluşturmustuk burda kullandık.
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));

        }

        [SwaggerResponse((int)HttpStatusCode.OK, "[Action]", typeof(IEnumerable<int>))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var category = await _service.GetByIdAsync(id);

            await _service.RemoveAsync(category);



            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));

        }

    }
}
