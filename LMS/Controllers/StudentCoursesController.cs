using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LMS.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LMS.Controllers
{
    [Route("api/studentcourses")]
    public class StudentCoursesController : Controller
    {   
        private ILMSDataStore _dbstore;
        public StudentCoursesController(ILMSDataStore dbstore)
        {
            _dbstore = dbstore;
        }


        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {   
            IActionResult result;
            var enrollment = _dbstore.GetEnrolmentByStudent(id);
            if (enrollment != null)
            {
                result = Ok(enrollment);
            }
            else
            {
                result = NotFound();
            }
            return result;
            //return Ok(_dbstore.);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
