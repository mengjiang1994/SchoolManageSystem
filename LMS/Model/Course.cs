using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
namespace LMS.Model
{
    public class Course
    {
        public static Course CreateNewCourseFromBody(Course courseFromPost)
        {
            Course newCourse = new Course();
            //Mapping value in here
            //Ignore the ID
            newCourse.Name = courseFromPost.Name;
            newCourse.CourseCode = courseFromPost.CourseCode;
            return newCourse;
        }

        /*
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        */
        public int Id { get; set; }

        public string Name { get; set; }

        public string CourseCode { get; set; }

        //[JsonProperty("Enrolments", NullValueHandling = NullValueHandling.Ignore)]
        [JsonProperty("Enrolments")]
        public ICollection<Enrolment> Enrollments { get; set; }

        [JsonProperty("Teaching")]
        public ICollection<Teaching> Teachings { get; set; }
    }
}
