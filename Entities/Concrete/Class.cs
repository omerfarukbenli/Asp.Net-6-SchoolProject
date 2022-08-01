using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public partial class Class : IEntity
    {       
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public ICollection<ClassroomTeacher> ClassroomTeacher { get; set; }
        public ICollection<ClassroomLesson> ClassroomLesson { get; set; }
        public ICollection<ClassStudent> ClassStudent { get; set; }

    }
}
