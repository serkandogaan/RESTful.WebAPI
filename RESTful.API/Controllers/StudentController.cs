using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTful.API.Entity.Models;
using RESTful.API.Repository.Abstract;
using RESTful.API.Repository.Concrete;

namespace RESTful.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IRepository _studentRepository;
        public StudentController(IRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet(Name = "GetAllStudent")]
        public List<Student> GetAll()
        {
            return _studentRepository.GetAll();
        }

        [HttpGet("{id:int}", Name = "GetByID")]
        public ActionResult<Student> GetStudentByID(int id)
        {
            var user = _studentRepository.GetByID(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpPost(Name = "AddStudent")]
        public ActionResult AddStudent(Student student)
        {

            _studentRepository.Add(student);
            return CreatedAtRoute("GetByID", new { id = student.Id }, student);

        }

        [HttpPut(Name = "UpdateStudent")]
        public IActionResult UpdateStudent(int id, Student student)
        {
            var studentInfo = _studentRepository.GetByID(id);

            if (studentInfo == null)
            {
                return NotFound();
            }
            studentInfo.Name = student.Name;
            studentInfo.Surname = student.Surname;
            _studentRepository.Update(studentInfo);
            return CreatedAtRoute("GetByID", new { id = student.Id }, studentInfo);

        }

        [HttpDelete(Name = "DeleteStudent")]
        public IActionResult DeleteStudent(int id)
        {
            var user = _studentRepository.GetByID(id);

            if(user == null) 
            {
                return NotFound();
            }
            _studentRepository.Delete(id);
            return NoContent();

        }

    }


}
