using Business.Abstract;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ClassroomLessonManager : IClassroomLessonService
    {
        private readonly IClassRoomLessonDal _classRoomLessonDal;

        public ClassroomLessonManager(IClassRoomLessonDal classRoomLessonDal)
        {
            _classRoomLessonDal = classRoomLessonDal;
        }
    }
}
