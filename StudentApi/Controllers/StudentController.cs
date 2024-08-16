using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentApi.Models;

namespace StudentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // perform CRUD operations on Student Entity in Collection
        static List<Student> students = null;
        public StudentController()
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
        public List<Student> Get()
        {
            return students;
        }
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            foreach (var student in students)
            {
                if (student.Id == id)
                {
                    return student;
                    break;
                }
            }
            return null;
        }

        [HttpPost]
        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        [HttpPut("{id}")]
        public void EditStudent(int id, Student student)
        {
            Student temp = Get(student.Id);
            if (temp != null)
            {
                temp.Batch = student.Batch;
                temp.Score = student.Score;
            }
        }

        [HttpDelete("{id}")]
        public void DeleteStudent(int id)
        {
            Student temp = Get(id);
            if (temp != null)
            {
                students.Remove(temp);

            }
        }


    }
}