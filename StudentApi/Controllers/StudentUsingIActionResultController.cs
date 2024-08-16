using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentApi.Models;

namespace StudentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Student1Controller : ControllerBase
    {
        // perform CRUD operations on Student Entity in Collection
        static List<Student> students = null;
        public Student1Controller()
        {
            if (students == null)
            {
                students = new List<Student>()
                {
                    new Student() { Id = 1, Name = "Ajay", Batch = "B001", Score = 90 },

                    new Student() { Id = 2, Name = "Deepak", Batch = "B001", Score = 90 },

                    new Student() { Id = 3, Name = "Chandan", Batch = "B001", Score = 90 },

                    new Student() { Id = 4, Name = "Vijay", Batch = "B001", Score = 90 },
                };
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Student temp = null;
            foreach (var student in students)
            {
                if (student.Id == id)
                {
                    temp = student;
                    break;
                }
            }
            if (temp == null)
                return NotFound();
            else

                return Ok(temp);
        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            students.Add(student);
            return Created("Record added", student);
        }

        [HttpPut("{id}")]
        public IActionResult EditStudent(int id, Student student)
        {
            Student temp = null;
            foreach (var obj in students)
            {
                if (obj.Id == id)
                {
                    temp = student;
                    break;
                }
            }
            if (temp != null)
            {
                temp.Batch = student.Batch;
                temp.Score = student.Score;
                return Ok(temp);
            }
            else
                return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            Student temp = null;
            foreach (var obj in students)
            {
                if (obj.Id == id)
                {

                    students.Remove(temp);
                    break;
                }
            }
            return Ok();
        }
    }


}