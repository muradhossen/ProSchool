using AutoMapper;
using Manager;
using ManagerAbstructions.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.ReturnDtos;

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassManager _classManager;
        private readonly IMapper _mapper;

        public ClassController(IClassManager classManager
            , IMapper mapper)
        {
            _classManager = classManager;
            _mapper = mapper;
        }

        [HttpGet("/api/classes")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var classes = await _classManager.GetAsync();

                if (classes is null)
                {
                    return NotFound();
                }
                return Ok(_mapper.Map<IList<ClassReturnDto>>(classes));

            }
            catch (Exception ex)
            {

                throw;
            }
        }


    }
}
