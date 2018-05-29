using System;
namespace LMS.Model
{
    public class Enrolment
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public Student Student { get; set; }
        public Course Course { get; set; }

        public int test { get; set; }
    }
}
