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
    [Route("api/enrolment")]
    public class EnrolmentController : Controller
    {
        private ILMSDataStore _dbstore;
        public EnrolmentController(ILMSDataStore dbstore)
        {
            _dbstore = dbstore;
        }

        //GET
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    return Ok(_dbstore.GetAllEnrolment());
        //}


        // POST api/values
        [HttpPost]
        //[HttpPost()]
        public void Post([FromBody]EnrolmentDTO value)
        {
            _dbstore.AddEnrolment(value.StudentID,value.CourseID);
        }

        // DELETE api/values/5
        [HttpDelete]
        public void Delete([FromBody]EnrolmentDTO value)
        {
            _dbstore.RemoveEnrolment(value.StudentID, value.CourseID);
        }
    }
}
