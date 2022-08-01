using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost("add")]
        public IActionResult Add(StudentRegisterDto registerDto)
        {
            _studentService.Add(registerDto);
            var results = _studentService.GetList();
            return Ok(results);
        }

        [HttpGet("getlist")]
        public IActionResult GetList()
        {
            var results = _studentService.GetList();
            return Ok(results);
        }
    }
}
