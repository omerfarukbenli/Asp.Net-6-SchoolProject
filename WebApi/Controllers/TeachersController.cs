using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] TeacherRegisterDto registerDto)
        {
            var result = _teacherService.Add(registerDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getlist")]
        public IActionResult GetList()
        {
            var results = _teacherService.GetList();
            if (results.Success)
            {
                return Ok(results);
            }
            return BadRequest(results.Message);
        }

        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var result = _teacherService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] TeacherRegisterDto teacherDto)
        {
            var result = _teacherService.Update(teacherDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
