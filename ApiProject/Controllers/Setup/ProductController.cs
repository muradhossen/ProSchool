using ApiProject.Extentions;
using AutoMapper;
using ManagerAbstructions.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.CreateDtos;
using Model.CriteriaDto.Setup;
using Model.Entities;
using Model.ReturnDtos.Setup;

namespace ApiProject.Controllers.Setup
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _productService;
       private readonly IMapper _mapper;

        public ProductController(IProductManager productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductCreateDto model)
        {
            try
            {
                if (model is null) return BadRequest("Invalid input");

                var addableProduct = _mapper.Map<Product>(model);

                var result = await _productService.AddAsync(addableProduct);

                if (result is true)
                {
                    return Ok("Created successfully");
                }

                return BadRequest("Failed to create bank");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {



                var data = await _productService.GetAsync();


                //var unitsReturnDto = _mapper.Map<IEnumerable<BankReturnDto>>(result);


                if (data is not null)
                {
                    return Ok(data);
                }

                return NotFound();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] ProductCreateDto model)
        {
            try
            {
                if (model is null || id <= 0) return BadRequest("Invalid input");

                bool result = false;
                var existingItem = await _productService.GetFirstOrDefaultAsync(c => c.Id == id);

                var updateAbleItem = _mapper.Map(model, existingItem);



                result = await _productService.UpdateAsync(updateAbleItem);

                if (result is true)
                {
                   
                    return Ok("Successfully updated.");
                }

                return BadRequest("Failed to update");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            if (id <= 0) return BadRequest("Invalid Id");

            var item = await _productService.GetByIdAsync(id);

            var returnItem = _mapper.Map<ProductReturnDto>(item);

            if (returnItem is null)
                return NotFound();

            return Ok(returnItem);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                if (id <= 0) return BadRequest("Invalid input");

                var deleteableItem = await _productService.GetByIdAsync(id);

                if (deleteableItem is null) return NotFound();

                var result = await _productService.RemoveAsync(deleteableItem);

                if (result is true) return Ok(result);

                return BadRequest("Failed to delete bank");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ProductCriteriaDto criteria)
        {
            try
            {
                if (criteria is null) return BadRequest("Invald input");


                var result = await _productService.GetByCriteria(criteria);


                var unitsReturnDto = _mapper.Map<IEnumerable<ProductReturnDto>>(result);

                //var startCount = result.PageSize * (result.CurrentPage - 1);
                //foreach (var region in unitsReturnDto)
                //{
                //    startCount = startCount + 1;
                //    region.Sl = startCount;
                //}

                Response.AddPagination(result.CurrentPage, result.PageSize, result.TotalCount, result.TotalPages);
                if (unitsReturnDto is not null)
                {
                    return Ok(unitsReturnDto);
                }

                return NotFound();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
