using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public partial class ClassroomTeacher : IEntity
    {
        public int Id { get; set; }
        public Teacher Teacher { get; set; }
        public Class Class { get; set; }
        public int TeacherId { get; set; }
        public int ClassId { get; set; }

    }
}
