using Business.Abstract;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AdminstratorManager : IAdminstratorService
    {
        private readonly IAdministratorDal _administratorDal;

        public AdminstratorManager(IAdministratorDal administratorDal)
        {
            _administratorDal = administratorDal;
        }
    }
}
