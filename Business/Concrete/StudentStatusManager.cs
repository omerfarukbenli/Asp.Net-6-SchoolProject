using Business.Abstract;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class StudentStatusManager : IStudentStatusService
    {
        private readonly IStudentStatusDal _studentStatusDal;

        public StudentStatusManager(IStudentStatusDal studentStatusDal)
        {
            _studentStatusDal = studentStatusDal;
        }
    }
}
