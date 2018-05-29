using System;
namespace LMS.Model
{
    public class StudentDetail
    {
        public int Id { get; set; }

        public string detail { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; }

        public StudentDetail()
        {
        }
    }
}
