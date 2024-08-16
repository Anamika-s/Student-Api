using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentApi.Models;

namespace StudentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Student2Controller : ControllerBase
    {
        // perform CRUD operations on Student Entity in Collection
        static List<Student> students = null;
        public Student2Controller()
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
        public ActionResult<List<Student>> Get()
        {
            if (students.Count==0)
            {
                return NotFound();
                
            }
            return students;
        }

        [HttpGet("{id}")]
        public ActionResult<Student> Get(int id)
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

                return temp;
        }

        [HttpPost]
        public ActionResult<string> AddStudent(Student student)
        {
            students.Add(student);
            //return Created("Record added", student);
            return "record added";
        }

        [HttpPut("{id}")]
        public ActionResult<bool> EditStudent(int id, Student student)
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
                return false;
            
        }

        [HttpDelete("{id}")]
        public ActionResult<int> DeleteStudent(int id)
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
            return 1;
        }
    }


}