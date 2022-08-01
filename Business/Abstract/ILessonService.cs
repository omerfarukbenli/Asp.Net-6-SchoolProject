using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ILessonService
    {
        IResult Add(Lesson lesson);
        IResult Update(Lesson lesson);
        IDataResult<List<Lesson>> GetList();
        IDataResult<Lesson> GetById(int id);
    }
}
