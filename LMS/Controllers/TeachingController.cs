using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LMS.Model;
using LMS.Model.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LMS.Controllers
{
    [Route("api/teaching")]
    public class TeachingController : Controller
    {
        private ILMSDataStore _dbstore;
        public TeachingController(ILMSDataStore dbstore)
        {
            _dbstore = dbstore;
        }


        // POST api/values
        [HttpPost]
        public void Post([FromBody]TeachingDTO value)
        {
            _dbstore.AddTeaching(value.courseId, value.lecturerId);
        }


        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete([FromBody]TeachingDTO value)
        {
            _dbstore.RemoveTeaching(value.courseId, value.lecturerId);
        }
    }
}
