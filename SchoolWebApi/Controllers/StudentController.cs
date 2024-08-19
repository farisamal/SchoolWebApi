using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolWebApi.Models;
using SchoolWebApi.Services;

namespace SchoolWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                IEnumerable<Student> students = _studentService.GetAll();
                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(499, ex.Message);
                //return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _studentService.Get(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add(Student student)
        {
            var result = _studentService.Add(student);
            return Ok("Jumlah student total: " + result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int deletedRow = _studentService.Delete(id);
            return Ok("Jumlah student dihapus: " + deletedRow);
        }
    }
}
