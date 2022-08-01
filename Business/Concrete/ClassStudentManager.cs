using Business.Abstract;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ClassStudentManager : IClassStudentService
    {
        private readonly IClassStudentDal _classStudentDal;

        public ClassStudentManager(IClassStudentDal classStudentDal)
        {
            _classStudentDal = classStudentDal;
        }
    }
}
