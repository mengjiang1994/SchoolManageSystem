using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace LMS.Model
{
    public class Student
    {
        // None = nothing // Identity ++  //Computed + annd -
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)] // None = nothing // Identity ++  //Computed + annd -

        public static Student CreateNewStudentFromBody(Student studentFromBody)
        {
            Student newStudent = new Student();
            //Mapping value in here
            //Ignore the ID
            newStudent.Name = studentFromBody.Name;
            newStudent.StudentDetail = studentFromBody.StudentDetail;
            return newStudent;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public StudentDetail StudentDetail { get; set; }

        public ICollection<Enrolment> Enrollments { get; set; }

        public ICollection<StudentAddress> StudentAddresses { get; set; }

        public Student()
        {
        }
    }
}
