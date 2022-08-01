using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public partial class ClassroomLesson : IEntity
    {
        public int Id { get; set; }
        public Class Class { get; set; }
        public Lesson Lesson { get; set; }
        public int ClassId { get; set; }
        public int LessonsId { get; set; }
    }
}
