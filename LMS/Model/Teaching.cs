using System;
namespace LMS.Model
{
    public class Teaching
    {

        public int lecturerId { get; set; }
        public int courseId { get; set; }

        public Lecturer lecturer { get; set; }
        public Course course { get; set; }

        public int duration { get; set; }

        public Teaching()
        {

        }

    }
}



