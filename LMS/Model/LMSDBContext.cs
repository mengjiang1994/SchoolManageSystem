using System;
using Microsoft.EntityFrameworkCore;

namespace LMS.Model
{
    public class LMSDBContext : DbContext
    {

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrolment> Enrolments { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Teaching> Teachings { get; set; }
        public LMSDBContext(DbContextOptions<LMSDBContext> options) :base(options)
        {
            Database.EnsureCreated();
            //Database.Migrate();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            //Course

            modelBuilder.Entity<Course>()
                        .Property(a => a.Id).ValueGeneratedOnAdd();
            
            modelBuilder.Entity<Course>()
                        .HasKey(a => a.Id);

            //Student                
            modelBuilder.Entity<Student>()
                        .Property(a => a.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Student>()
                        .HasKey(a => a.Id);

            //Student Detail               
            modelBuilder.Entity<StudentDetail>()
            .Property(a => a.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<StudentDetail>()
                        .HasKey(a => a.Id);
            
            modelBuilder.Entity<Student>()
                        .HasOne(a => a.StudentDetail)
                        .WithOne(stdDetail => stdDetail.Student)
                        .HasForeignKey<StudentDetail>(stdDetail => stdDetail.StudentId);


            //Student Address
            modelBuilder.Entity<StudentAddress>()
            .Property(a => a.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<StudentAddress>()
                        .HasKey(a => a.Id);

            modelBuilder.Entity<Student>()
                        .HasMany(s => s.StudentAddresses)
                        .WithOne(address => address.Student);

            //Enrollment
            modelBuilder.Entity<Enrolment>()
                        .HasKey(a => new{a.CourseId,a.StudentId}); //Remeber the Order


            modelBuilder.Entity<Enrolment>()
                        .HasOne(bc => bc.Course)
                        .WithMany(b => b.Enrollments)
                        .HasForeignKey(bc => bc.CourseId);

            modelBuilder.Entity<Enrolment>()
                        .HasOne(bc => bc.Student)
                        .WithMany(b => b.Enrollments)
                        .HasForeignKey(bc => bc.StudentId);

            //Teaching
            modelBuilder.Entity<Teaching>()
                        .HasKey(a => new { a.lecturerId, a.courseId }); //Remeber the Order


            modelBuilder.Entity<Teaching>()
                        .HasOne(bc => bc.lecturer)
                        .WithMany(b => b.Teachings)
                        .HasForeignKey(bc => bc.lecturerId);
            
            modelBuilder.Entity<Teaching>()
                        .HasOne(bc => bc.course)
                        .WithMany(b => b.Teachings)
                        .HasForeignKey(bc => bc.courseId);

            //Lecturer
            modelBuilder.Entity<Lecturer>()
                        .Property(a => a.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Lecturer>()
                        .HasKey(a => a.Id);

            //LecturerDetail
            modelBuilder.Entity<LecturerDetail>()
            .Property(a => a.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<LecturerDetail>()
                        .HasKey(a => a.Id);


            modelBuilder.Entity<Lecturer>()
                        .HasOne(a => a.LecturerDetail)
                        .WithOne(b => b.Lecturer)
                        .HasForeignKey<LecturerDetail>(b => b.LecturerId);


            // To ignore a class :modelBuilder.Ignore<StudentAddress>();

            /*
            modelBuilder.Entity<Student>()
                        .HasOne(a => a.StudentAddress)
                        .WithOne(b => b.Student);
                        */
        }


       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       {
            // DB setting is set here 
            var connectionString = "server=13.54.17.147;userid=lms_teambroot;pwd=password;port=3306;database=lms_teamb;sslmode=none;";
            optionsBuilder.UseMySQL(connectionString);
            base.OnConfiguring(optionsBuilder);
       }

    }
}
