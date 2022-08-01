using Business.Abstract;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ClassroomTeacherManager : IClassroomTeacherService
    {
        private readonly IClassRoomTeacherDal _classRoomTeacherDal;

        public ClassroomTeacherManager(IClassRoomTeacherDal classRoomTeacherDal)
        {
            _classRoomTeacherDal = classRoomTeacherDal;
        }
    }
}
