using System;
namespace LMS.Model
{
    public class LecturerDetail
    {
        public int Id { get; set; }

        public string detail { get; set; }

        public int LecturerId { get; set; }

        public Lecturer Lecturer { get; set; }

        public LecturerDetail()
        {
        }
    }
}

