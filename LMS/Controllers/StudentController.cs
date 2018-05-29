using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using LMS.Model;
namespace LMS.Controllers
{
    [Route("api/student")]
    public class StudentController : Controller
    {

        private ILMSDataStore _dbstore;
        public StudentController(ILMSDataStore dbstore)
        {
            _dbstore = dbstore;
        }

        //GET
        [HttpGet]
        public IActionResult Get()
        {
            var result = _dbstore.GetAllStudent();
            //sonResult resultJSObj = new JsonResult(result);
            return Ok(result);
        }

        //GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult result;
            var student = _dbstore.GetStudent(id);
            if (student != null)
            {
                result = Ok(student);
            }
            else
            {
                result = NotFound();
            }
            return result;
        }

        //POST
        [HttpPost]
        public IActionResult Post([FromBody]Student student)
        {
            Student newCourse = Student.CreateNewStudentFromBody(student);
            _dbstore.AddStudent(newCourse);
            _dbstore.Save();
            return Ok();
        }

        //PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Student input)
        {   
            Student newStudent = Student.CreateNewStudentFromBody(input);
            _dbstore.EditStudent(id, newStudent);
            return Ok();


        }


        //DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _dbstore.RemoveStudent(id);
        }
    }
}