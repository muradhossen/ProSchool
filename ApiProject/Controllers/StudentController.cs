using ApiProject.Extentions;
using AutoMapper;
using ManagerAbstructions.Contracts;
using Microsoft.AspNetCore.Mvc;
using Model.CreateDtos;
using Model.CriteriaDto;
using Model.Entities;
using Model.ReturnDtos;

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentManager _studentManager;
        private readonly IMapper _mapper;

        public StudentController(IStudentManager studentManager
            , IMapper mapper)
        {
            _studentManager = studentManager;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StudentCreateDto studetnDto)
        {
            try
            {
                if (studetnDto is null) return BadRequest("Invalid input");

                var student = _mapper.Map<Student>(studetnDto);


                if (await _studentManager.AddAsync(student))
                {
                    return Ok("Created successfully");
                }

                return BadRequest("Failed to create student!");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] StudentCreateDto studentDto)
        {
            try
            {
                if (studentDto is null || id <= 0) return BadRequest("Invalid input");

                var student = await _studentManager.GetByIdAsync(id);

                student = _mapper.Map(studentDto, student);


                if (await _studentManager.UpdateAsync(student))
                {
                    return Ok("Successfully updated.");
                }

                return BadRequest("Failed to update!");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0) return BadRequest("Invalid Id");

            var student = await _studentManager.GetByIdAsync(id);

            if (student is null) return NotFound();

            return Ok(_mapper.Map<StudentReturnDto>(student, opt => opt.AfterMap((src, des) =>
            {
                des.Sl = 1;
            })));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id <= 0) return BadRequest("Invalid input");

                var student = await _studentManager.GetByIdAsync(id);

                if (student is null) return NotFound();

                if (await _studentManager.RemoveAsync(student)) return Ok("Deleted.");

                return BadRequest("Failed to delete bank");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("/api/students")]
        public async Task<IActionResult> Get([FromQuery] StudentCriteriaDto criteria)
        {
            try
            {
                //await Task.Delay(5000);

                if (criteria is null) return BadRequest("Invald input");


                var students = await _studentManager.GetByCriteria(criteria);


                var studentsReturnDto = _mapper.Map<IEnumerable<StudentReturnDto>>(students);

                var startCount = students.PageSize * (students.CurrentPage - 1);
                foreach (var region in studentsReturnDto)
                {
                    startCount = startCount + 1;
                    region.Sl = startCount;
                }

                Response.AddPagination(students.CurrentPage, students.PageSize, students.TotalCount, students.TotalPages);
                if (studentsReturnDto is not null)
                {
                    return Ok(new StudentPaginetedDto
                    {
                        Data = studentsReturnDto,
                        RecordsTotal = students.TotalCount,
                        RecordsFiltered = students.TotalCount
                    });
                }

                return NotFound();
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        [HttpGet("/api/students/all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var students = await _studentManager.GetAllStudentsAsync();

                if (students is null)
                {
                    return NotFound();                   
                }                 
                return Ok(_mapper.Map<IList<StudentReturnDto>>(students));

            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
