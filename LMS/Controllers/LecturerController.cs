using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using LMS.Model;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LMS.Controllers
{
    [Route("api/lecturer")]
    public class LecturerController : Controller
    {   
        private ILMSDataStore _dbstore;
        public LecturerController(ILMSDataStore dbstore)
        {
            _dbstore = dbstore;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var result = _dbstore.GetAllLecturer();
            return Ok(result);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult result;
            var lecturer = _dbstore.GetLecturer(id);
            if(lecturer != null) {
                result = Ok(lecturer);
            } else {
                result = NotFound();
            }
            return result;
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Lecturer lecturer)
        {
            Lecturer newCourse = Lecturer.CreateNewLecturerFromBody(lecturer);
            _dbstore.AddLecturer(newCourse);
            _dbstore.Save();
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Lecturer input)
        {
            Lecturer newLecturer = Lecturer.CreateNewLecturerFromBody(input);
            _dbstore.EditLecturer(id, newLecturer);
            return Ok();
        }

        //DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _dbstore.RemoveLecturer(id);
        }

        //
    }
}
