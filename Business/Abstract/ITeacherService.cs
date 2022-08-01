using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface ITeacherService
    {
        IResult Add(TeacherRegisterDto teacherRegisterDto);
        IResult Update(TeacherRegisterDto teacherRegisterDto);
        IDataResult<List<Teacher>> GetList();
        IDataResult<Teacher> GetById(int id);
    }
}
