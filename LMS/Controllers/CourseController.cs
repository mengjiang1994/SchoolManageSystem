using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using LMS.Model;

namespace LMS.Controllers
{
    [Route("api/course")]
    public class CourseController : Controller
    {
        private ILMSDataStore _dbstore;
        public CourseController(ILMSDataStore dbstore)
        {
            _dbstore = dbstore;
        }

        //GET
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dbstore.GetAllCourses());
        }

        //GET by ID
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult result;
            var course = _dbstore.GetCourse(id);
            if(course != null) {
                result = Ok(course);
            } else {
                result = NotFound();
            }
            return result;
        }

        //POST
        [HttpPost]
        public IActionResult Post([FromBody]Course input)
        {
            Course newCourse = Course.CreateNewCourseFromBody(input);
            _dbstore.AddCourse(newCourse);
            return Ok();
        }

        //PUT
        [HttpPut("{id}")]
        public IActionResult Put(int id,[FromBody]Course input)
        {
            Course newCourse = Course.CreateNewCourseFromBody(input);
            _dbstore.EditCourse(id,newCourse);
            return Ok();
        }

        //DELETE
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _dbstore.RemoveCourse(id);
        }

    }
}
