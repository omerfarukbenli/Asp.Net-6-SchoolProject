using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Context
{
    public class SchoolContextDb : DbContext
    {  
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=okuldatabase;Trusted_Connection=True;");
        }               

        public virtual DbSet<Adminstrator> Adminstrators { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<ClassStudent> ClassStudents { get; set; }
        public virtual DbSet<ClassroomLesson> ClassroomLessons { get; set; }
        public virtual DbSet<ClassroomTeacher> ClassroomTeachers { get; set; }
        public virtual DbSet<Lesson> Lessons { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentStatus> StudentStatuses { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }

    }   
}
