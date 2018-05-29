using System;
using System.Collections.Generic;


namespace LMS.Model
{
    public interface ILMSDataStore
    {   
        //Course
        IEnumerable<Course> GetAllCourses();
        Course GetCourse(int courseID);
        void AddCourse(Course course);
        void EditCourse(int courseID, Course course);
        void RemoveCourse(int courseID);
        IEnumerable<Enrolment> GetEnrolmentByCourse(int courseID);

        //Student
        IEnumerable<Student> GetAllStudent();
        Student GetStudent(int studentID);
        void AddStudent(Student student);
        void EditStudent(int studentID, Student student);
        void RemoveStudent(int studentID);
        IEnumerable<Enrolment> GetEnrolmentByStudent(int studentID);

        //Lecturer
        IEnumerable<Lecturer> GetAllLecturer();
        Lecturer GetLecturer(int lecturerID);
        void AddLecturer(Lecturer lecturer);
        void EditLecturer(int lecturerID, Lecturer lecturer);
        void RemoveLecturer(int lecturerId);

        //Teaching
        void AddTeaching(int lecturerId, int courseId);
        void RemoveTeaching(int lecturerId, int courseId);

        //Enrolment
        IEnumerable<Enrolment> GetAllEnrolment();
        void AddEnrolment(int studentID, int courseID);
        void RemoveEnrolment(int studentID, int courseID);

        bool Save();
    }
}
