using System;
namespace LMS.Model
{
    public class StudentAddress
    {
        public int StudentId { get; set; }

        public Student Student { get; set; }

        public string Address { get; set; }

        public int PostCode { get; set; }

        public int Id { get; set; }

        public StudentAddress()
        {
        }
    }
}
