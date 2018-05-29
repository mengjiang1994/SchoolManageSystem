using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LMS.Model
{
    public class LMSDataStore:ILMSDataStore
    {
        private LMSDBContext _ctx;

        public LMSDataStore(LMSDBContext ctx)
        {
            _ctx = ctx;
        }
        // For Course API 
        public IEnumerable<Course> GetAllCourses()
        {
            return _ctx.Courses.OrderBy(course => course.Id).ToList();
        }

        public Course GetCourse(int courseID){
            //Console.WriteLine("Below is the truth you wanna get: ");
            //Console.WriteLine( _ctx.Courses.Find(1).CourseCode);
            //Console.WriteLine("Above is the truth you wanna get: ");
            return _ctx.Courses.Find(courseID);
        }


        public void AddCourse(Course course)
        {
            _ctx.Courses.Add(course);
            Save();
        }

        public void EditCourse(int courseID, Course course){
            Course courseToEdit = _ctx.Courses.Find(courseID);
            courseToEdit.Name = course.Name;
            courseToEdit.CourseCode = course.CourseCode;
            Save();
        }

        public void RemoveCourse(int courseID)
        {
            var del_course = _ctx.Courses.Find(courseID);
            if (del_course != null)
            {
                _ctx.Courses.Remove(del_course);
            }Save();
        }            




        // For Student API 
        public IEnumerable<Student> GetAllStudent()
        {
            var result = _ctx.Students
                             .Include(s => s.StudentDetail)
                             .Include(s=> s.Enrollments).ThenInclude(cw=>cw.Course)
                             .OrderBy(student => student.Id).ToList();

            return result;
        }

        public void AddStudent(Student student)
        {
            _ctx.Students.Add(student);
        }

        public Student GetStudent(int studentID)
        {
            return _ctx.Students.Find(studentID);
        }

        public void EditStudent(int studentID, Student student)
        {
            Student studentToEdit = _ctx.Students.Find(studentID);
            studentToEdit.Name = student.Name;
            studentToEdit.StudentDetail = student.StudentDetail;
            studentToEdit.StudentAddresses = student.StudentAddresses;
            Save();
        }

        public void RemoveStudent(int studentID)
        {
            var del_student = _ctx.Students.Find(studentID);
            if (del_student != null)
            {
                _ctx.Students.Remove(del_student);
            }
            Save();
        }


        // For Lecturer API 
        public IEnumerable<Lecturer> GetAllLecturer()
        {
            var result = _ctx.Lecturers
                             .Include(s => s.LecturerDetail)
                             .Include(s => s.Teachings).ThenInclude(cw => cw.course)
                             .OrderBy(Lecturer => Lecturer.Id).ToList();

            return result;
        }

        public Lecturer GetLecturer(int lecturerID) 
        {
            return _ctx.Lecturers.Find(lecturerID);
        }

        public void AddLecturer(Lecturer lecturer)
        {
            _ctx.Lecturers.Add(lecturer);
        }

        public void EditLecturer(int lecturerID, Lecturer lecturer)
        {
            Lecturer LecturerToEdit = _ctx.Lecturers.Find(lecturerID);
            LecturerToEdit.Name = lecturer.Name;
            LecturerToEdit.LecturerDetail = lecturer.LecturerDetail;
            //LecturerToEdit.Teachings = lecturer.Teachings;
            Save();
        }

        public void RemoveLecturer(int lecturerId){
            var del_lecturer = _ctx.Lecturers.Find(lecturerId);
            if (del_lecturer != null)
            {
                _ctx.Lecturers.Remove(del_lecturer);
            }
            Save();
        }


        // For Enrolment API 
        public IEnumerable<Enrolment> GetAllEnrolment()
        {
            var result = _ctx.Enrolments
                             .Include(s => s.StudentId)
                             .Include(s => s.Student)
                             .Include(s => s.CourseId)
                             .Include(s => s.Course)
                             .OrderBy(Enrolment => Enrolment.StudentId).ToList();

            return result;
        }

        public void AddEnrolment(int studentId, int courseId){
            Student student = _ctx.Students.Find(studentId);
            Course course = _ctx.Courses.Find(courseId);

            var newEnrol = new Enrolment {StudentId=studentId,CourseId=courseId};
            _ctx.Enrolments.Add(newEnrol);
            Save();
        }

        public void RemoveEnrolment(int studentID, int courseID){
            var enrol = _ctx.Enrolments.Find(courseID,studentID);
            if(enrol != null) {
                _ctx.Enrolments.Remove(enrol);
            }
            Save();
        }

        public IEnumerable<Enrolment> GetEnrolmentByStudent(int studentID)
        {   
            ////Find(CourseID, StudentID)
            //Console.WriteLine("Hi there");
            ////var result = _ctx.Enrolments.Where<Enrolment>(a => a.CourseId == 5).First().CourseId;
            ////var result = _ctx.Enrolments.Where<Enrolment>(a => a.CourseId == 5).First().CourseId;
            //var result = _ctx.Enrolments.Select().All();
            //Console.WriteLine(result); 
            //Console.WriteLine(_ctx.Enrolments.Find(5,2).CourseId);
            //Console.WriteLine(_ctx.Enrolments.Find(5,2).StudentId);
            //Console.WriteLine("Hi Bro");
            //return _ctx.Students.Find(studentID).Enrollments;
            return _ctx.Courses.Find(studentID).Enrollments;
        }

        public IEnumerable<Enrolment> GetEnrolmentByCourse(int courseID)
        {   

            return _ctx.Courses.Find(courseID).Enrollments;
        }

        // For Teaching API 
        public void AddTeaching(int lecturerId, int courseId)
        {
            Lecturer lecturer = _ctx.Lecturers.Find(lecturerId);
            Course course = _ctx.Courses.Find(courseId);

            var newTeaching = new Teaching { lecturerId = lecturerId, courseId = courseId };
            _ctx.Teachings.Add(newTeaching);
            Save();
        }

        public void RemoveTeaching(int lecturerId, int courseId)
        {
            var teach = _ctx.Teachings.Find(lecturerId, courseId);
            if (teach != null)
            {
                _ctx.Teachings.Remove(teach);
            }
            Save();
        }

        ////TO-DS
        ////List all the courses which the student take
        //public IEnumerable<Course> ListStudentCourses(int studentID)
        //{   
        //    //TO-DO 1st
        //    throw new NotImplementedException();
        //    //Enrolment enrolment = _ctx.Enrolments.Find(studentID);
        //    //var result = _ctx.Enrolments
        //    //                .Include(s => s.StudentId)
        //    //                .Include(s => s.Student)
        //    //                .Include(s => s.CourseId)
        //    //                .Include(s => s.Course)
        //    //                .OrderBy(Enrolment => Enrolment.StudentId).ToList();
        //    //return result;
        //}

        ////TO-DO
        ////List all the student which the course have
        //public IEnumerable<Student> ListCourseStudents(int courseID)
        //{   
        //    //TO-DO 2nd
        //    throw new NotImplementedException();
        //}

        public bool Save()
        {
            //True for success , False should throw exception
            return (_ctx.SaveChanges() >= 0);
        }

       
    }
}
